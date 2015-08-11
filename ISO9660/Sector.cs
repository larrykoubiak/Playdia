using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ISO9660
{
    [StructLayout(LayoutKind.Explicit, Size= 2352,Pack=1)]
    struct _XASectorForm1
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=12)]
        [FieldOffset(0)]
        public string syncPattern;
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(12)]
        public byte minute;
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(13)]
        public byte second;
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(14)]
        public byte block;
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(15)]
        public byte mode;
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=2)]
        [FieldOffset(16)]
        public UInt32[] subheader;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=2048)]
        [FieldOffset(24)]
        public byte[] data;
        [MarshalAs(UnmanagedType.U4)]
        [FieldOffset(2064)]
        public UInt32 EDC;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        [FieldOffset(2068)]
        public byte[] Space;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 172)]
        [FieldOffset(2076)]
        public byte[] ECCP;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 104)]
        [FieldOffset(2248)]
        public byte[] ECCQ;
    }
    public class XASectorForm1
    {
        private _XASectorForm1 _sector;

        public XASectorForm1()
        {
            _sector = new _XASectorForm1();
        }

        public string SyncPattern
        {
            get { return _sector.syncPattern;}
            set { _sector.syncPattern = value;} 
        }
        public byte Minute 
        { 
            get {  return (byte)((_sector.minute & 0xf) + (10 * (_sector.minute >> 4))); } 
            set { _sector.minute = (byte)((value % 10) | ((value /10) << 4)); } 
        }
        public byte Second
        {
            get { return (byte)((_sector.second & 0xf) + (10 * (_sector.second >> 4))); }
            set { _sector.second = (byte)((value % 10) | ((value / 10) << 4)); }
        }
        public byte Block
        {
            get { return (byte)((_sector.block & 0xf) + (10 * (_sector.block >> 4))); }
            set { _sector.block = (byte)((value % 10) | ((value / 10) << 4)); }
        }
        public byte Mode
        {
            get { return _sector.mode; }
            set { _sector.mode = value;}
        }
        public UInt32 SubHeader1
        {
            get { return _sector.subheader[0]; }
            set { _sector.subheader[0] = value; }
        }
        public UInt32 SubHeader2
        {
            get { return _sector.subheader[1]; }
            set { _sector.subheader[1] = value; }
        }
        public byte[] Data
        {
            get { return _sector.data; }
            set { _sector.data = value; }
        }
        public UInt32 EDC
        {
            get { return _sector.EDC; }
            set { _sector.EDC = value; }
        }
        public byte[] UnusedSapce
        {
            get { return _sector.Space; }
            set { _sector.Space = value; }
        }
        public byte[] ECCP
        {
            get { return _sector.ECCP; }
            set { _sector.ECCP = value;}
        }
        public byte[] ECCQ
        {
            get { return _sector.ECCQ; }
            set { _sector.ECCQ = value; }
        }

        public void ReadBytes(byte[] data)
        {
            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            _sector = (_XASectorForm1)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(_XASectorForm1));
            handle.Free();            
        }
    }
 } 