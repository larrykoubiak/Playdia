using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ISO9660
{
    public enum SectorType
    {
        XAForm1,
        XAForm2
    }
    [Flags]
    public enum Submodes : byte
    {
        EOR = 0x01,
        Video = 0x02,
        Audio = 0x04,
        Data = 0x08,
        Trigger = 0x10,
        Form = 0x20,
        RTS = 0x40,
        EOF = 0x80
    }
    [StructLayout(LayoutKind.Sequential, Size=24,Pack=1)]
    struct _SectorHeader
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=12)]
        public string syncPattern;
        [MarshalAs(UnmanagedType.U1)]
        public byte minute;
        [MarshalAs(UnmanagedType.U1)]
        public byte second;
        [MarshalAs(UnmanagedType.U1)]
        public byte block;
        [MarshalAs(UnmanagedType.U1)]
        public byte mode;
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=2)]
        public UInt32[] subheader;
    }
    public class SectorHeader
    {
        private _SectorHeader _sector;
        private int _filestreamid;
        private long _filestreamoffset;
        private SectorType _type;

        public SectorHeader()
        {
            _sector = new _SectorHeader();
        }

        public SectorHeader(byte[] data, int filestreamid, long filestreamoffset, SectorType type): this()
        {
            _filestreamid = filestreamid;
            _filestreamoffset = filestreamoffset;
            _type = type;
            ReadBytes(data);
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
        public byte FileNumber
        {
            get { return (byte)((_sector.subheader[0] & 0x000000FF)); }
        }
        public byte Channel
        {
            get { return (byte)((_sector.subheader[0] & 0x0000FF00) >> 8); }
        }
        public Submodes Submode
        {
            get { return (Submodes)((_sector.subheader[0] & 0x00FF0000) >> 16); }
        }
        public byte Coding
        {
            get { return (byte)((_sector.subheader[0] & 0xFF000000) >> 24); }
        }
        public String ChannelMode
        {
            get {  return ((Coding & 0x01) > 0) ? "Stereo": "Mono"; }
        }
        public String SampleRate
        {
            get { return ((Coding & 0x04) > 0) ? "18.9kHz" : "37.8kHz"; }
        }
        public String BitsPerSample
        {
            get { return ((Coding & 0x10) > 0) ? "8bit" : "4bit"; }
        }
        public bool Emphasis
        {
            get { return ((Coding & 0x40) > 0); }
        }
        public int FileStreamId
        {
            get { return _filestreamid; }
            set { _filestreamid = value; }
        }
        public long FileStreamOffset
        {
            get { return _filestreamoffset; }
            set { _filestreamoffset = value; }
        }
        public SectorType SectorType
        {
            get { return _type; }
            set { _type = value; }
        }

        public void ReadBytes(byte[] data)
        {
            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            _sector = (_SectorHeader)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(_SectorHeader));
            handle.Free();            
        }
    }
 } 