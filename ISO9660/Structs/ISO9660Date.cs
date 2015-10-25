/*
 * Created by SharpDevelop.
 * User: I36107
 * Date: 22/10/2015
 * Time: 10:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.InteropServices;

namespace ISO9660
{
	/// <summary>
	/// Description of ISO9660Date.
	/// </summary>
	[StructLayout(LayoutKind.Sequential,Size=17,Pack=1)]
	public struct _ISO9660TextDate
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
		public char[] year;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
		public char[] month;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
		public char[] day;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
		public char[] hour;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
		public char[] minute;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
		public char[] second;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
		public char[] secondHundreth;
		[MarshalAs(UnmanagedType.I1)]
		public sbyte offset;
	}	
    [StructLayout(LayoutKind.Sequential,Size=7,Pack =1)]
    public struct _ISO9660NumericDate
    {
        [MarshalAs(UnmanagedType.U1)]
        public byte year;
        [MarshalAs(UnmanagedType.U1)]
        public byte month;
        [MarshalAs(UnmanagedType.U1)]
        public byte day;
        [MarshalAs(UnmanagedType.U1)]
        public byte hour;
        [MarshalAs(UnmanagedType.U1)]
        public byte minute;
        [MarshalAs(UnmanagedType.U1)]
        public byte second;
        [MarshalAs(UnmanagedType.I1)]
        public byte offset;
    }

}
