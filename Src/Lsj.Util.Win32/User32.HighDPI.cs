﻿using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DPI_AWARENESS;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public partial class User32
    {
        /// <summary>
        /// <para>
        /// Determines whether two <see cref="DPI_AWARENESS_CONTEXT"/> values are identical.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-aredpiawarenesscontextsequal
        /// </para>
        /// </summary>
        /// <param name="dpiContextA">
        /// The first value to compare.
        /// </param>
        /// <param name="dpiContextB">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the values are equal, otherwise <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// A <see cref="DPI_AWARENESS_CONTEXT"/> contains multiple pieces of information.
        /// For example, it includes both the current and the inherited <see cref="DPI_AWARENESS"/> values.
        /// <see cref="AreDpiAwarenessContextsEqual"/> ignores informational flags and determines if the values are equal.
        /// You can't use a direct bitwise comparison because of these informational flags.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "AreDpiAwarenessContextsEqual", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AreDpiAwarenessContextsEqual([In]DPI_AWARENESS_CONTEXT dpiContextA, [In]DPI_AWARENESS_CONTEXT dpiContextB);

        /// <summary>
        /// <para>
        /// Calculates the required size of the window rectangle, based on the desired size of the client rectangle and the provided DPI.
        /// This window rectangle can then be passed to the <see cref="CreateWindowEx"/> function to create a window with a client area of the desired size.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-adjustwindowrectexfordpi
        /// </para>
        /// </summary>
        /// <param name="lpRect">
        /// A pointer to a <see cref="RECT"/> structure that contains the coordinates of the top-left and bottom-right corners of the desired client area.
        /// When the function returns, the structure contains the coordinates of the top-left and bottom-right corners of the window
        /// to accommodate the desired client area.
        /// </param>
        /// <param name="dwStyle">
        /// The Window Style of the window whose required size is to be calculated.
        /// Note that you cannot specify the <see cref="WS_OVERLAPPED"/> style.
        /// </param>
        /// <param name="bMenu">
        /// Indicates whether the window has a menu.
        /// </param>
        /// <param name="dwExStyle">
        /// The Extended Window Style of the window whose required size is to be calculated.
        /// </param>
        /// <param name="dpi">
        /// The DPI to use for scaling.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function returns the same result as <see cref="AdjustWindowRectEx"/> but scales it according to an arbitrary DPI you provide if appropriate.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "AdjustWindowRectEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AdjustWindowRectExForDpi([In][Out]ref RECT lpRect, [In]WindowStyles dwStyle, [In]BOOL bMenu,
            [In]WindowStylesEx dwExStyle, [In]UINT dpi);

        /// <summary>
        /// <para>
        /// Returns the dots per inch (dpi) value for the associated window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getdpiforwindow
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// The window you want to get information about.
        /// </param>
        /// <returns>
        /// The DPI for the window which depends on the <see cref="DPI_AWARENESS"/> of the window.
        /// See the Remarks for more information.
        /// An invalid hwnd value will result in a return value of 0.
        /// </returns>
        /// <remarks>
        /// The following table indicates the return value of <see cref="GetDpiForWindow"/> based on the <see cref="DPI_AWARENESS"/> of the provided hwnd.
        /// <see cref="DPI_AWARENESS_UNAWARE"/>: 96
        /// <see cref="DPI_AWARENESS_SYSTEM_AWARE"/>: The system DPI.
        /// <see cref="DPI_AWARENESS_PER_MONITOR_AWARE"/>: The DPI of the monitor where the window is located.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDpiForWindow", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetDpiForWindow([In]HWND hwnd);

        /// <summary>
        /// <para>
        /// Retrieves the value of one of the system-wide parameters, taking into account the provided DPI value.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-systemparametersinfofordpi
        /// </para>
        /// </summary>
        /// <param name="uiAction">
        /// The system-wide parameter to be retrieved.
        /// This function is only intended for use with <see cref="SPI_GETICONTITLELOGFONT"/>,
        /// <see cref="SPI_GETICONMETRICS"/>, or <see cref="SPI_GETNONCLIENTMETRICS"/>.
        /// See <see cref="SystemParametersInfo"/> for more information on these values.
        /// </param>
        /// <param name="uiParam">
        /// A parameter whose usage and format depends on the system parameter being queried.
        /// For more information about system-wide parameters, see the <paramref name="uiAction"/> parameter.
        /// If not otherwise indicated, you must specify zero for this parameter.
        /// </param>
        /// <param name="pvParam">
        /// A parameter whose usage and format depends on the system parameter being queried.
        /// For more information about system-wide parameters, see the <paramref name="uiAction"/> parameter.
        /// If not otherwise indicated, you must specify <see cref="NULL"/> for this parameter.
        /// For information on the <see cref="PVOID"/> datatype, see Windows Data Types.
        /// </param>
        /// <param name="fWinIni">
        /// Has no effect for with this API.
        /// This parameter only has an effect if you're setting parameter.
        /// </param>
        /// <param name="dpi">
        /// The DPI to use for scaling the metric.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function returns a similar result as <see cref="SystemParametersInfo"/>,
        /// but scales it according to an arbitrary DPI you provide (if appropriate).
        /// It only scales with the following possible values for <paramref name="uiAction"/>:
        /// <see cref="SPI_GETICONTITLELOGFONT"/>, <see cref="SPI_GETICONMETRICS"/>, <see cref="SPI_GETNONCLIENTMETRICS"/>.
        /// Other possible <paramref name="uiAction"/> values do not provide ForDPI behavior,
        /// and therefore this function returns 0 if called with them.
        /// For <paramref name="uiAction"/> values that contain strings within their associated structures,
        /// only Unicode (LOGFONTW) strings are supported in this function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SystemParametersInfoForDpi", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SystemParametersInfoForDpi([In]SystemParametersInfoParameters uiAction, [In]UINT uiParam,
            [In]PVOID pvParam, [In]SystemParametersInfoFlags fWinIni, [In]UINT dpi);
    }
}