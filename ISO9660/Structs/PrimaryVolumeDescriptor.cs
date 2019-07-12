/*
 * Created by SharpDevelop.
 * User: I36107
 * Date: 21/10/2015
 * Time: 15:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.InteropServices;

namespace ISO9660
{
	[StructLayout(LayoutKind.Sequential, Size=2048,Pack=1)]
	struct _PrimaryVolumeDescriptor
	{
		[MarshalAs(UnmanagedType.U1)]
		public VolumeDescriptorType volumeDescriptorType;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=5)]
		public char[] standardIdentifier;
		[MarshalAs(UnmanagedType.U1)]
		public byte volumeDescriptorVersion;
		[MarshalAs(UnmanagedType.U1)]
        public byte unused1;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=32)]
		public char[] systemIdentifier;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=32)]
		public char[] volumeIdentifier;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
		public byte[] unused2;
		[MarshalAs(UnmanagedType.U4)]
		public UInt32 volumeSpaceSize;
		[MarshalAs(UnmanagedType.U4)]
		public UInt32 volumeSpaceSizeBE;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=32)]
		public byte[] unused3;
		[MarshalAs(UnmanagedType.U2)]
		public UInt16 volumeSetSize;
		[MarshalAs(UnmanagedType.U2)]
		public UInt16 volumeSetSizeBE;
		[MarshalAs(UnmanagedType.U2)]
		public UInt16 volumeSequenceNumber;		
		[MarshalAs(UnmanagedType.U2)]
		public UInt16 volumeSequenceNumberBE;
		[MarshalAs(UnmanagedType.U2)]
		public UInt16 logicalBlockSize;
		[MarshalAs(UnmanagedType.U2)]
		public UInt16 logicalBlockSizeBE;
		[MarshalAs(UnmanagedType.U4)]
		public UInt32 pathTableSize;
		[MarshalAs(UnmanagedType.U4)]
		public UInt32 pathTableSizeBE;
		[MarshalAs(UnmanagedType.U4)]
		public UInt32 locationPathTable;
		[MarshalAs(UnmanagedType.U4)]
		public UInt32 locationOptionalPathTable;
		[MarshalAs(UnmanagedType.U4)]
		public UInt32 locationPathTableBE;
		[MarshalAs(UnmanagedType.U4)]
		public UInt32 locationOptionalPathTableBE;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=34)]
		public byte[] rootDirectoryRecord;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=128)]
		public char[] volumeSetIdentifier;		
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=128)]
		public char[] publisherIdentifier;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=128)]
		public char[] dataPreparerIdentifier;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=128)]
		public char[] applicationIdentifier;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=37)]
		public char[] copyrightFileIdentifier;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=37)]
		public char[] abstractFileIdentifier;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=37)]
		public char[] bibliographicFileIdentifier;
		[MarshalAs(UnmanagedType.Struct)]
		public _ISO9660TextDate volumeCreationDateTime;
		[MarshalAs(UnmanagedType.Struct)]
		public _ISO9660TextDate volumeModificationDateTime;
		[MarshalAs(UnmanagedType.Struct)]
		public _ISO9660TextDate volumeExpirationDateTime;
		[MarshalAs(UnmanagedType.Struct)]
		public _ISO9660TextDate volumeEffectiveDateTime;
		[MarshalAs(UnmanagedType.U1)]
		public byte fileStructureVersion;
		[MarshalAs(UnmanagedType.U1)]
		public byte unused4;
		[MarshalAs(UnmanagedType.ByValArray,SizeConst=512)]
		public byte[] applicationUse;
		[MarshalAs(UnmanagedType.ByValArray,SizeConst=653)]
		public byte[] unused5;
	}
	/// <summary>
	/// Description of PrimaryVolumeDescriptor.
	/// </summary>
	public class PrimaryVolumeDescriptor : VolumeDescriptor
	{
		private _PrimaryVolumeDescriptor pvd;
		public PrimaryVolumeDescriptor()
		{
			pvd = new _PrimaryVolumeDescriptor();
		}
		   
        public PrimaryVolumeDescriptor(byte[] data) : this()
        {
            ReadByte(data);
        }

        public override VolumeDescriptorType VolumeDescriptorType
        {
            get { return pvd.volumeDescriptorType; }
            set { pvd.volumeDescriptorType = value; }
        }
        public override string StandardIdentifier
        {
            get { return new String(pvd.standardIdentifier); }
            set { pvd.standardIdentifier = value.ToCharArray(); }
        }
        public override byte VolumeDescriptorVersion
        {
            get { return pvd.volumeDescriptorVersion; }
            set { pvd.volumeDescriptorVersion = value; }
        }

        public string SystemIdentifier 
		{ 
			get { return new String(pvd.systemIdentifier);}
			set { pvd.systemIdentifier = value.ToCharArray();}
		}
		
		public string VolumeIdentifier 
		{ 
			get { return new String(pvd.volumeIdentifier);}
			set { pvd.volumeIdentifier = value.ToCharArray();}
		}
		
		public UInt32 VolumeSpaceSize 
		{ 
			get { return pvd.volumeSpaceSize;}
			set { pvd.volumeSpaceSize = value;}
		}
		
		public UInt16 VolumeSetSize 
		{ 
			get { return pvd.volumeSetSize;}
			set { pvd.volumeSetSize = value;}
		}
		
		public UInt16 VolumeSequenceNumber
		{
			get { return pvd.volumeSequenceNumber;}
			set { pvd.volumeSequenceNumber = value;}
		}
		
		public UInt16 LogicalBlockSize
		{
			get { return pvd.logicalBlockSize;}
			set { pvd.logicalBlockSize = value;}
		}
		
		public UInt32 PathTableSize
		{
			get { return pvd.pathTableSize;}
			set { pvd.pathTableSize = value;}
		}
		
		public UInt32 PathTableLocation
		{
			get { return pvd.locationPathTable; }
			set { pvd.locationPathTable = value; }
		}
		
		public UInt32 OptionalPathTableLocation
		{
			get { return pvd.locationOptionalPathTable;}
			set { pvd.locationOptionalPathTable = value;}
		}
		
        public DirectoryRecord RootDirectoryRecord
        {
            get { return new DirectoryRecord(pvd.rootDirectoryRecord); }
            set { pvd.rootDirectoryRecord = value.GetBytes(); }
        }

		public string VolumeSetIdentifier
		{
			get { return new String(pvd.volumeSetIdentifier);}
			set { pvd.volumeSetIdentifier = value.ToCharArray();}
		}
		
		public string PublisherIdentifier
		{
			get { return new String(pvd.publisherIdentifier);}
			set { pvd.publisherIdentifier = value.ToCharArray();}
		}
		
		public string DataPreparerIdentifier
		{
			get { return new String(pvd.dataPreparerIdentifier);}
			set { pvd.dataPreparerIdentifier = value.ToCharArray();}
		}
		
		public string ApplicationIdentifier
		{
			get { return new String(pvd.applicationIdentifier);}
			set { pvd.applicationIdentifier = value.ToCharArray();}
		}
		
		public string CopyrightFileIdentifier
		{
			get { return new String(pvd.copyrightFileIdentifier);}
			set { pvd.copyrightFileIdentifier = value.ToCharArray();}
		}
		
		public string AbstractFileIdentifier
		{
			get { return new String(pvd.abstractFileIdentifier);}
			set { pvd.abstractFileIdentifier = value.ToCharArray();}
		}
		
		public string BibliographicFileIdentifier
		{
			get { return new String(pvd.bibliographicFileIdentifier);}
			set { pvd.bibliographicFileIdentifier = value.ToCharArray();}
		}
		
		public DateTime VolumeCreationDate
		{
			get { return convertISODate2DateTime(pvd.volumeCreationDateTime);}
			set { pvd.volumeCreationDateTime = convertDateTime2ISODate(value);}
		}

        public DateTime VolumeModificationdDate
        {
            get { return convertISODate2DateTime(pvd.volumeModificationDateTime); }
            set { pvd.volumeModificationDateTime = convertDateTime2ISODate(value); }
        }

        public DateTime VolumeExpirationDate
        {
            get { return convertISODate2DateTime(pvd.volumeExpirationDateTime); }
            set { pvd.volumeExpirationDateTime = convertDateTime2ISODate(value); }
        }

        public DateTime VolumeEffectiveDate
        {
            get { return convertISODate2DateTime(pvd.volumeEffectiveDateTime); }
            set { pvd.volumeEffectiveDateTime = convertDateTime2ISODate(value); }
        }

        public override void ReadByte(byte[] data)
		{
			GCHandle handle = GCHandle.Alloc(data,GCHandleType.Pinned);
			pvd = (_PrimaryVolumeDescriptor)Marshal.PtrToStructure(handle.AddrOfPinnedObject(),typeof(_PrimaryVolumeDescriptor));
			handle.Free();
		}
		
		private DateTime convertISODate2DateTime(_ISO9660TextDate isodate)
		{
            if(new String(isodate.year)=="0000")
            {
                return DateTime.MinValue;
            }
            else
            {
				return new DateTime(
					int.Parse(new String(isodate.year)),
					int.Parse(new String(isodate.month)),
					int.Parse(new String(isodate.day)),
					int.Parse(new String(isodate.hour)),
					int.Parse(new String(isodate.minute)),
					int.Parse(new String(isodate.second)),
					int.Parse(new String(isodate.secondHundreth))*10
				);
            }
        }
		private _ISO9660TextDate convertDateTime2ISODate(DateTime value)
		{
            _ISO9660TextDate isodate = new _ISO9660TextDate();
			isodate.year = value.Year.ToString("0000").ToCharArray();
			isodate.month = value.Month.ToString("00").ToCharArray();
			isodate.day = value.Day.ToString("00").ToCharArray();
			isodate.hour = value.Hour.ToString("00").ToCharArray();
			isodate.minute = value.Minute.ToString("00").ToCharArray();
			isodate.second = value.Second.ToString("00").ToCharArray();
			isodate.secondHundreth = (value.Millisecond/10).ToString("00").ToCharArray();
			return isodate;
		}
		
	}
}
