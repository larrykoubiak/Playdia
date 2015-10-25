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
	/// <summary>
	/// Description of VolumeDescriptor.
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Size=2048,Pack=1)]
	struct _VolumeDescriptor
	{
		[MarshalAs(UnmanagedType.U1)]
		public byte volumeDescriptorType;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=5)]
		public char[] standardIdentifier;
		[MarshalAs(UnmanagedType.U1)]
		public byte volumeDescriptorVersion;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=2041)]
		public byte[] data;
	}
	
	public class VolumeDescriptor
	{	
		private _VolumeDescriptor _volumeDescriptor;
		public VolumeDescriptor()
		{
			_volumeDescriptor = new _VolumeDescriptor();
		}
		public byte VolumeDescriptorType 
		{ 
			get { return _volumeDescriptor.volumeDescriptorType; }
			set { _volumeDescriptor.volumeDescriptorType = value; }
		}
		public string StandardIdentifier 
		{ 
			get { return new String(_volumeDescriptor.standardIdentifier);}
			set { _volumeDescriptor.standardIdentifier = value.ToCharArray();}
		}
		public byte VolumeDescriptorVersion 
		{ 
			get { return _volumeDescriptor.volumeDescriptorVersion; }
			set { _volumeDescriptor.volumeDescriptorVersion = value; }
		}
		public byte[] Data
		{
			get { return _volumeDescriptor.data;}
			set { _volumeDescriptor.data = value;}
		}
		public void ReadByte(byte[] data)
		{
			GCHandle handle = GCHandle.Alloc(data,GCHandleType.Pinned);
			_volumeDescriptor = (_VolumeDescriptor)Marshal.PtrToStructure(handle.AddrOfPinnedObject(),typeof(_VolumeDescriptor));
			handle.Free();
		}
	}
}
