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
        private int[] K0 = new int[] { 0, 60, 115, 98};
        private int[] K1 = new int[] { 0, 0, -52, -55 };
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
                        int shift = (12 - (_block.soundParameters[(blk * 2) + nibble] & 0xF));
                        int filter = (_block.soundParameters[(blk * 2) + nibble] & 0x30) >> 4;
                        int f0 = K0[filter];
                        int f1 = K1[filter];
                        int idx = ((sd * 4)+ blk);
                        byte adpcmsample = (byte)((_block.soundSamples[idx] >> (nibble * 4)) & 0xF);
                        Int16 extendedsample = (adpcmsample > 7 ? (Int16)(0xFFF0 | adpcmsample) : (Int16)adpcmsample);
                        Int32 result = (extendedsample << shift) + (((prev1*f0) + (prev2*f1))/64);
                        prev2 = prev1;
                        prev1 = result;
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
        public void ReadBytes(byte[] data)
        {
            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            _block = (_ADPCMBlock)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(_ADPCMBlock));
            handle.Free();
        }
    }
}
