﻿using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// An unsigned integer, whose length is dependent on processor word size.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/openspecs/windows_protocols/ms-tsts/f959534d-51f2-4103-8fb5-812620efe49b
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct UINT_PTR
    {
        [FieldOffset(0)]
        private UIntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator UIntPtr(UINT_PTR val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator UINT_PTR(UIntPtr val) => new UINT_PTR { _value = val };
    }
}
