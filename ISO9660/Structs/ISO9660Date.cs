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
	public struct _ISO9660Date
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
}
