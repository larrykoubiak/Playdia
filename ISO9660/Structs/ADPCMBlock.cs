using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ISO9660
{
    [StructLayout(LayoutKind.Sequential, Size = 128, Pack = 1)]
    struct _ADPCMBlock
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] soundParameters;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 112)]
        public byte[] soundSamples;
    }
    class ADPCMBlock
    {
        private _ADPCMBlock _block;
        private int[] K0 = new int[] { 0, 960, 1840, 1568};
        private int[] K1 = new int[] { 0, 0, -832, -880 };
        public ADPCMBlock()
        {
            _block = new _ADPCMBlock();
        }
        public ADPCMBlock(byte[] data) : this()
        {
            ReadBytes(data);
        }
        public List<Int16> getPCM()
        {
            List<Int16> pcms = new List<Int16>();
            Int32 prev1, prev2;
            prev1 = 0;
            prev2 = 0;
            for (int blk = 0; blk < 4; blk++)
                {
                for (int nibble = 0; nibble < 2; nibble++)
                {
                    for (int sd = 0; sd < 28; sd++)
                    {
                        int shift = _block.soundParameters[(blk * 2) + nibble] & 0xF;
                        if (shift > 12)
                            shift = 9;
                        int filter = (_block.soundParameters[(blk * 2) + nibble] & 0x30) >> 4;
                        int f0 = -K0[filter];
                        int f1 = -K1[filter];
                        int idx = ((sd * 4)+ blk);
                        byte adpcmsample = (byte)((_block.soundSamples[idx] >> (nibble * 4)) & 0xF);
                        int extendedsample = (((adpcmsample << 0x1C))>>0x10) >> shift;
                        Int32 result = (extendedsample << 4) - (((prev1*f0) + (prev2*f1)) >> 10);
                        prev2 = prev1;
                        prev1 = result;
                        result = result >> 4;
                        if (result > 32767)
                            result = 32767;
                        else if (result < -32768)
                            result = -32768;
                        pcms.Add((Int16)result);
                    }
                }

            }
            return upsampling_linear(pcms);
        }
        private List<Int16> upsampling_linear(List<Int16> samples)
        {
            float step = 1f / (7f / 3f);
            List<Int16> result = new List<Int16>();
            float stepidx = 0f;
            int idx = 0;
            while(idx < (samples.Count-1))
            {
                Int16 cursample = samples[idx];
                Int16 nextsample = samples[idx + 1];
                Int16 sample = (Int16)(cursample + ((nextsample - cursample)*stepidx));
                result.Add(sample);
                stepidx += step;
                if(stepidx > 1f)
                {
                    stepidx -= 1f;
                    idx++;
                }
            }
            result.Add(samples[idx]);
            return result;
        }
        private List<Int16> upsampling_zigzag(List<Int16> samples)
        {
            Int16[] ringbuffer = new Int16[32];
            List<Int16> result = new List<Int16>();
            int p = 0;
            int threestep = 3;
            while(p < samples.Count)
            {
                ringbuffer[p & 0x1F] = samples[p];
                p++;
                threestep--;
                if(threestep==0)
                {
                    threestep = 3;
                    result.Add(ZigZagInterpolate(ringbuffer, p, 0));
                    result.Add(ZigZagInterpolate(ringbuffer, p, 1));
                    result.Add(ZigZagInterpolate(ringbuffer, p, 2));
                    result.Add(ZigZagInterpolate(ringbuffer, p, 2));
                    result.Add(ZigZagInterpolate(ringbuffer, p, 4));
                    result.Add(ZigZagInterpolate(ringbuffer, p, 5));
                    result.Add(ZigZagInterpolate(ringbuffer, p, 6));
                }
            }
            return result;
        }
        private Int16 ZigZagInterpolate(Int16[] ringbuffer,int p, int tableid)
        {
            int[,] tables = new int[7,29]{
                {0,0,0,0,0,-0x0002,0x000A,-0x0022,0x0041,-0x0054,0x0034,0x0009,-0x010A,0x0400,-0x0A78,0x234C,0x6794,-0x1780,0x0BCD,-0x0623,0x0350,-0x016D,0x006B,0x000A,-0x0010,0x0011,-0x0008,0x0003,-0x0001},
                {0,0,0,-0x0002,0,0x0003,-0x0013,0x003C,-0x004B,0x00A2,-0x00E3,0x0132,-0x0043,-0x0267,0x0C9D,0x74BB,-0x11B4,0x09B8,-0x05BF,0x0372,-0x01A8,0x00A6,-0x001B,0x0005,0x0006,-0x0008,0x0003,-0x0001,0},
                {0,0,-0x0001,0x0003,-0x0002,-0x0005,0x001F,-0x004A,0x00B3,-0x0192,0x02B1,-0x039E,0x04F8,-0x05A6,0x7939,-0x05A6,0x04F8,-0x039E,0x02B1,-0x0192,0x00B3,-0x004A,0x001F,-0x0005,-0x0002,0x0003,-0x0001,0,0},
                {0,-0x0001,0x0003,-0x0008,0x0006,0x0005,-0x001B,0x00A6,-0x01A8,0x0372,-0x05BF,0x09B8,-0x11B4,0x74BB,0x0C9D,-0x0267,-0x0043,0x0132,-0x00E3,0x00A2,-0x004B,0x003C,-0x0013,0x0003,0,-0x0002,0,0,0},
                {-0x0001,0x0003,-0x0008,0x0011,-0x0010,0x000A,0x006B,-0x016D,0x0350,-0x0623,0x0BCD,-0x1780,0x6794,0x234C,-0x0A78,0x0400,-0x010A,0x0009,0x0034,-0x0054,0x0041,-0x0022,0x000A,-0x0001,0,0x0001,0,0,0},
                {0x0002,-0x0008,0x0010,-0x0023,0x002B,0x001A,-0x00EB,0x027B,-0x0548,0x0AFA,-0x16FA,0x53E0,0x3C07,-0x1249,0x080E,-0x0347,0x015B,-0x0044,-0x0017,0x0046,-0x0023,0x0011,-0x0005,0,0,0,0,0,0},
                {-0x0005,0x0011,-0x0023,0x0046,-0x0017,-0x0044,0x015B,-0x0347,0x080E,-0x1249,0x3C07,0x53E0,-0x16FA,0x0AFA,-0x0548,0x027B,-0x00EB,0x001A,0x002B,-0x0023,0x0010,-0x0008,0x0002,0,0,0,0,0,0}
            };
            Int32 sum = 0;
            for(int i=1; i<30;i++)
            {
                Int16 sample = ringbuffer[(p - i) & 0x1F];
                int tableval = tables[tableid, i - 1];
                sum = sum + ((sample * tableval) >> 0xF);
            }
            if (sum > 32767)
                sum = 32767;
            else if (sum< -32768)
                sum = -32768;
            return (Int16)sum;
        }
        public void ReadBytes(byte[] data)
        {
            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            _block = (_ADPCMBlock)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(_ADPCMBlock));
            handle.Free();
        }
    }
}
