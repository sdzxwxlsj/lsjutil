﻿using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// An <see cref="HRESULT"/> is a 32-bit value that is used to describe an error or warning and contains the following fields:
    /// A 1-bit code that indicates severity, where 0 represents success and 1 represents failure.
    /// A 4-bit reserved value.
    /// An 11-bit code, also known as a facility code, that indicates responsibility for the error or warning.
    /// A 16-bit code that describes the error or warning.
    /// For details on HRESULT values, see [MS-ERREF].
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/openspecs/windows_protocols/ms-dtyp/a9046ed2-bfb2-4d56-a719-2824afce59ac
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct HRESULT
    {
        /// <summary>
        /// CACHE_E_NOCACHE_UPDATED
        /// </summary>
        public static readonly HRESULT CACHE_E_NOCACHE_UPDATED = new HRESULT { _value = unchecked((int)0x80040170) };

        /// <summary>
        /// CACHE_S_FORMATETC_NOTSUPPORTED
        /// </summary>
        public static readonly HRESULT CACHE_S_FORMATETC_NOTSUPPORTED = new HRESULT { _value = 0x00040170 };

        /// <summary>
        /// CACHE_S_SAMECACHE
        /// </summary>
        public static readonly HRESULT CACHE_S_SAMECACHE = new HRESULT { _value = 0x00040171 };

        /// <summary>
        /// CACHE_S_SOMECACHES_NOTUPDATED
        /// </summary>
        public static readonly HRESULT CACHE_S_SOMECACHES_NOTUPDATED = new HRESULT { _value = 0x00040172 };

        /// <summary>
        /// E_OUTOFMEMORY
        /// </summary>
        public static readonly HRESULT E_OUTOFMEMORY = new HRESULT { _value = unchecked((int)0x8007000E) };

        /// <summary>
        /// E_INVALIDARG
        /// </summary>
        public static readonly HRESULT E_INVALIDARG = new HRESULT { _value = unchecked((int)0x80070057) };

        /// <summary>
        /// S_OK
        /// </summary>
        public static readonly HRESULT S_OK = new HRESULT();

        [FieldOffset(0)]
        private int _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <summary>
        /// Is Succeed
        /// </summary>
        public bool Succeed => _value >= 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator bool(HRESULT val) => val.Succeed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator uint(HRESULT val) => unchecked((uint)val._value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator int(HRESULT val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HRESULT(int val) => new HRESULT { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HRESULT(uint val) => new HRESULT { _value = unchecked((int)val) };
    }
}