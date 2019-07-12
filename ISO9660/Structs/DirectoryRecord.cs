/*
 * Created by SharpDevelop.
 * User: I36107
 * Date: 23/10/2015
 * Time: 16:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ISO9660
{
	/// <summary>
	/// Description of DirectoryRecord.
	/// </summary>
    /// 
    [Flags]
    public enum FileFlags
    {
        Existence = 0x01,
        Directory = 0x02,
        AssociatedFile = 0x04,
        Record = 0x08,
        Protection = 0x10,
        Reserved1 = 0x20,
        Reserved2 = 0x40,
        MultiExtent = 0x80
    }
    [StructLayout(LayoutKind.Sequential,Size =34,Pack =1)]
    public struct _DirectoryRecord
    {
        [MarshalAs(UnmanagedType.U1)]
        public byte LengthDR;
        [MarshalAs(UnmanagedType.U1)]
        public byte LengthAR;
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 ExtentLocation;
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 ExtentLocationBE;
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 DataLength;
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 DataLengthBE;
        [MarshalAs(UnmanagedType.Struct)]
        public _ISO9660NumericDate RecordingDate;
        [MarshalAs(UnmanagedType.U1)]
        public byte FileFlags;
        [MarshalAs(UnmanagedType.U1)]
        public byte FileUnitSize;
        [MarshalAs(UnmanagedType.U1)]
        public byte InterleaveGapSize;
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 VolumeSequenceNumber;
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 VolumeSequenceNumberBE;
        [MarshalAs(UnmanagedType.U1)]
        public byte LengthFI;
        [MarshalAs(UnmanagedType.U1)]
        public byte padding;
    }
	public class DirectoryRecord
	{
        private _DirectoryRecord dr;
        private List<DirectoryRecord> children;
        private string fi;
        public DirectoryRecord()
		{
            dr = new _DirectoryRecord();
            children = new List<DirectoryRecord>();

        }
        public DirectoryRecord(byte[] data) : this()
        {
            ReadBytes(data);
        }
        public byte Length
        {
            get { return dr.LengthDR; }
            set { dr.LengthDR = value; }
        }
        public byte AttributeLength
        {
            get { return dr.LengthAR; }
            set { dr.LengthAR = value; }
        }
        public UInt32 ExtentLocation
        {
            get { return dr.ExtentLocation; }
            set { dr.ExtentLocation = value; }
        }
        public UInt32 DataLength
        {
            get { return dr.DataLength; }
            set { dr.DataLength = value; }
        }

        public DateTime RecordingDate
        {
            get
            {
                return new DateTime(
                    dr.RecordingDate.year, 
                    dr.RecordingDate.month, 
                    dr.RecordingDate.day, 
                    dr.RecordingDate.hour, 
                    dr.RecordingDate.minute, 
                    dr.RecordingDate.second
                );
            }
            set
            {
                dr.RecordingDate.year = (byte)value.Year;
                dr.RecordingDate.month = (byte)value.Month;
                dr.RecordingDate.day = (byte)value.Day;
                dr.RecordingDate.hour = (byte)value.Hour;
                dr.RecordingDate.minute = (byte)value.Minute;
                dr.RecordingDate.second = (byte)value.Second;
            }
        }
        public FileFlags Flags
        {
            get { return (FileFlags)dr.FileFlags;}
            set { dr.FileFlags = (byte)value; }
        }
        public byte FileUnitSize
        {
            get { return dr.FileUnitSize; }
            set { dr.FileUnitSize = value; }
        }
        public byte InterleaveGapSize
        {
            get { return dr.InterleaveGapSize; }
            set { dr.InterleaveGapSize = value; }
        }
        public UInt16 VolumeSequenceNumber
        {
            get { return dr.VolumeSequenceNumber; }
            set { dr.VolumeSequenceNumber = value; }
        }
        public byte FileIdentifierLength
        {
            get { return dr.LengthFI; }
            set { dr.LengthFI = value; }
        }
        public string FileIdentifier
        {
            get { return fi; }
            set { fi = value; }
        }
        public List<DirectoryRecord> Children
        {
            get { return children; }
        }
        public void ReadBytes(byte[] data)
        {
            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            dr = (_DirectoryRecord)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(_DirectoryRecord));
            handle.Free();
        }
        public byte[] GetBytes()
        {
            int size = Marshal.SizeOf(dr);
            byte[] result = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(dr));
            Marshal.StructureToPtr(dr, ptr, true);
            Marshal.Copy(ptr, result, 0, size);
            Marshal.FreeHGlobal(ptr);
            return result;
        }
    }
}
