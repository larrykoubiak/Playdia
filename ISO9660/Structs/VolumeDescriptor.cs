/*
 * Created by SharpDevelop.
 * User: I36107
 * Date: 21/10/2015
 * Time: 10:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ISO9660
{
    public enum SectorType : byte
    {
        Boot = 0,
        PrimaryVolumeDescriptor = 1,
        SupplementaryVolumeDescriptor = 2,
        VolumePartitionDescriptor = 3,
        VolumeDescriptionSetTerminator = 255
    }

    [StructLayout(LayoutKind.Sequential, Size=2048,Pack=1)]
	struct _VolumeDescriptor
	{
		[MarshalAs(UnmanagedType.U1)]
		public SectorType volumeDescriptorType;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=5)]
		public char[] standardIdentifier;
		[MarshalAs(UnmanagedType.U1)]
		public byte volumeDescriptorVersion;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=2041)]
		public byte[] data;
	}
	
	public class VolumeDescriptor
	{
        _VolumeDescriptor _volumeDescriptor;
		public VolumeDescriptor()
		{
			_volumeDescriptor = new _VolumeDescriptor();
		}
        public VolumeDescriptor(byte[] data) : this()
        {
            ReadByte(data);
        }
		public virtual SectorType VolumeDescriptorType 
		{ 
			get { return _volumeDescriptor.volumeDescriptorType; }
			set { _volumeDescriptor.volumeDescriptorType = value; }
		}
		public virtual string StandardIdentifier 
		{ 
			get { return new String(_volumeDescriptor.standardIdentifier);}
			set { _volumeDescriptor.standardIdentifier = value.ToCharArray();}
		}
		public virtual byte VolumeDescriptorVersion 
		{ 
			get { return _volumeDescriptor.volumeDescriptorVersion; }
			set { _volumeDescriptor.volumeDescriptorVersion = value; }
		}
		public virtual byte[] Data
		{
			get { return _volumeDescriptor.data;}
			set { _volumeDescriptor.data = value;}
		}
		public virtual void ReadByte(byte[] data)
		{
			GCHandle handle = GCHandle.Alloc(data,GCHandleType.Pinned);
			_volumeDescriptor = (_VolumeDescriptor)Marshal.PtrToStructure(handle.AddrOfPinnedObject(),typeof(_VolumeDescriptor));
			handle.Free();
		}
	}
}
