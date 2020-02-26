﻿using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes the cache attributes.
    /// </para>
    /// <para>
    /// https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-cache_descriptor
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CACHE_DESCRIPTOR
    {
        /// <summary>
        /// The cache level.
        /// This member can be one of the following values.
        /// 1: L1
        /// 2: L2
        /// 3: L3
        /// </summary>
        public byte Level;

        /// <summary>
        /// The cache associativity.
        /// If this member is <see cref="CACHE_FULLY_ASSOCIATIVE"/>, the cache is fully associative.
        /// </summary>
        public byte Associativity;

        /// <summary>
        /// The cache line size, in bytes.
        /// </summary>
        public ushort LineSize;

        /// <summary>
        /// The cache size, in bytes.
        /// </summary>
        public uint Size;

        /// <summary>
        /// The cache type. This member is a <see cref="PROCESSOR_CACHE_TYPE"/> value.
        /// </summary>
        public PROCESSOR_CACHE_TYPE Type;
    }
}