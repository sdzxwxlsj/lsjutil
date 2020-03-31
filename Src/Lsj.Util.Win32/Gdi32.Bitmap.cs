﻿using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32
{
    public partial class Gdi32
    {
        /// <summary>
        /// <para>
        /// The <see cref="CreateBitmap"/> function creates a bitmap with the specified width, height, and color format (color planes and bits-per-pixel).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createbitmap
        /// </para>
        /// </summary>
        /// <param name="nWidth">
        /// The bitmap width, in pixels.
        /// </param>
        /// <param name="nHeight">
        /// The bitmap height, in pixels.
        /// </param>
        /// <param name="nPlanes">
        /// The number of color planes used by the device.
        /// </param>
        /// <param name="nBitCount">
        /// The number of bits required to identify the color of a single pixel.
        /// </param>
        /// <param name="lpBits">
        /// A pointer to an array of color data used to set the colors in a rectangle of pixels.
        /// Each scan line in the rectangle must be word aligned (scan lines that are not word aligned must be padded with zeros).
        /// If this parameter is <see cref="NULL"/>, the contents of the new bitmap is undefined.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to a bitmap.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// This function can return the following value.
        /// <see cref="ERROR_INVALID_BITMAP"/>: The calculated size of the bitmap is less than zero.
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateBitmap"/> function creates a device-dependent bitmap.
        /// After a bitmap is created, it can be selected into a device context by calling the <see cref="SelectObject"/> function.
        /// However, the bitmap can only be selected into a device context if the bitmap and the DC have the same format.
        /// The <see cref="CreateBitmap"/> function can be used to create color bitmaps.
        /// However, for performance reasons applications should use <see cref="CreateBitmap"/> to create monochrome bitmaps
        /// and <see cref="CreateCompatibleBitmap"/> to create color bitmaps.
        /// Whenever a color bitmap returned from <see cref="CreateBitmap"/> is selected into a device context,
        /// the system checks that the bitmap matches the format of the device context it is being selected into.
        /// Because <see cref="CreateCompatibleBitmap"/> takes a device context, it returns a bitmap that has the same format as the specified device context.
        /// Thus, subsequent calls to <see cref="SelectObject"/> are faster with a color bitmap from <see cref="CreateCompatibleBitmap"/>
        /// than with a color bitmap returned from <see cref="CreateBitmap"/>.
        /// If the bitmap is monochrome, zeros represent the foreground color and ones represent the background color for the destination device context.
        /// If an application sets the nWidth or nHeight parameters to zero, <see cref="CreateBitmap"/> returns the handle to a 1-by-1 pixel, monochrome bitmap.
        /// When you no longer need the bitmap, call the <see cref="DeleteObject"/> function to delete it.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateCompatibleBitmap", SetLastError = true)]
        public static extern HBITMAP CreateBitmap([In]int nWidth, [In]int nHeight, [In]UINT nPlanes, [In]UINT nBitCount, [In]IntPtr lpBits);

        /// <summary>
        /// <para>
        /// The <see cref="CreateBitmapIndirect"/> function creates a bitmap with the specified width, height, and color format (color planes and bits-per-pixel).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createbitmapindirect
        /// </para>
        /// </summary>
        /// <param name="pbm">
        /// A pointer to a <see cref="BITMAP"/> structure that contains information about the bitmap.
        /// If an application sets the <see cref="bmWidth"/> or <see cref="bmHeight"/> members to zero,
        /// <see cref="CreateBitmapIndirect"/> returns the handle to a 1-by-1 pixel, monochrome bitmap.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the bitmap.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// This function can return the following values.
        /// <see cref="ERROR_INVALID_PARAMETER"/>: One or more of the input parameters is invalid.
        /// <see cref="ERROR_NOT_ENOUGH_MEMORY"/>: The bitmap is too big for memory to be allocated.
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateBitmapIndirect"/> function creates a device-dependent bitmap.
        /// After a bitmap is created, it can be selected into a device context by calling the <see cref="SelectObject"/> function.
        /// However, the bitmap can only be selected into a device context if the bitmap and the DC have the same format.
        /// While the <see cref="CreateBitmapIndirect"/> function can be used to create color bitmaps,
        /// for performance reasons applications should use <see cref="CreateBitmapIndirect"/> to create monochrome bitmaps
        /// and <see cref="CreateCompatibleBitmap"/> to create color bitmaps.
        /// Whenever a color bitmap from <see cref="CreateBitmapIndirect"/> is selected into a device context,
        /// the system must ensure that the bitmap matches the format of the device context it is being selected into.
        /// Because <see cref="CreateCompatibleBitmap"/> takes a device context, it returns a bitmap that has the same format as the specified device context.
        /// Thus, subsequent calls to <see cref="SelectObject"/> are faster with a color bitmap
        /// from <see cref="CreateCompatibleBitmap"/> than with a color bitmap returned from <see cref="CreateBitmapIndirect"/>.
        /// If the bitmap is monochrome, zeros represent the foreground color and ones represent the background color for the destination device context.
        /// When you no longer need the bitmap, call the <see cref="DeleteObject"/> function to delete it.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateBitmapIndirect", SetLastError = true)]
        public static extern HBITMAP CreateBitmapIndirect([MarshalAs(UnmanagedType.LPStruct)][In]BITMAP pbm);

        /// <summary>
        /// <para>
        /// The <see cref="CreateCompatibleBitmap"/> function creates a bitmap compatible with the device that is associated with the specified device context.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createcompatiblebitmap
        /// </para>
        /// </summary>
        /// <param name="hdc">A handle to a device context.</param>
        /// <param name="nWidth">The bitmap width, in pixels.</param>
        /// <param name="nHeight">The bitmap height, in pixels.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the compatible bitmap (DDB).
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateCompatibleBitmap", SetLastError = true)]
        public static extern HBITMAP CreateCompatibleBitmap([In]HDC hdc, [In]int nWidth, [In]int nHeight);

        /// <summary>
        /// <para>
        /// The <see cref="CreateDiscardableBitmap"/> function creates a discardable bitmap that is compatible with the specified device.
        /// The bitmap has the same bits-per-pixel format and the same color palette as the device.
        /// An application can select this bitmap as the current bitmap for a memory device that is compatible with the specified device.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-creatediscardablebitmap
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context.
        /// </param>
        /// <param name="cx">
        /// The width, in pixels, of the bitmap.
        /// </param>
        /// <param name="cy">
        /// The height, in pixels, of the bitmap.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the compatible bitmap (DDB).
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// When you no longer need the bitmap, call the <see cref="DeleteObject"/> function to delete it.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            "Applications should use the CreateCompatibleBitmap function.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDiscardableBitmap", SetLastError = true)]
        public static extern HBITMAP CreateDiscardableBitmap([In]HDC hdc, [In]int cx, [In]int cy);

        /// <summary>
        /// <para>
        /// The <see cref="CreateDIBitmap"/> function creates a compatible bitmap (DDB) from a DIB and, optionally, sets the bitmap bits.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createdibitmap
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context.
        /// </param>
        /// <param name="pbmih">
        /// A pointer to a bitmap information header structure, <see cref="BITMAPV5HEADER"/>.
        /// If <paramref name="flInit"/> is <see cref="CBM_INIT"/>, the function uses the bitmap information header structure
        /// to obtain the desired width and height of the bitmap as well as other information.
        /// Note that a positive value for the height indicates a bottom-up DIB while a negative value for the height indicates a top-down DIB.
        /// Calling <see cref="CreateDIBitmap"/> with <paramref name="flInit"/> as <see cref="CBM_INIT"/> is equivalent
        /// to calling the <see cref="CreateCompatibleBitmap"/> function to create a DDB in the format of the device and
        /// then calling the <see cref="SetDIBits"/> function to translate the DIB bits to the DDB.
        /// </param>
        /// <param name="flInit">
        /// Specifies how the system initializes the bitmap bits. The following value is defined.
        /// <see cref="CBM_INIT"/>:
        /// If this flag is set, the system uses the data pointed to by the <paramref name="pjBits"/> and <paramref name="pbmi"/> parameters
        /// to initialize the bitmap bits.
        /// If this flag is clear, the data pointed to by those parameters is not used.
        /// If <paramref name="flInit"/> is zero, the system does not initialize the bitmap bits.
        /// </param>
        /// <param name="pjBits">
        /// A pointer to an array of bytes containing the initial bitmap data.
        /// The format of the data depends on the <see cref="BITMAPINFO.biBitCount"/> member of the <see cref="BITMAPINFO"/> structure
        /// to which the <paramref name="pbmi"/> parameter points.
        /// </param>
        /// <param name="pbmi">
        /// A pointer to a <see cref="BITMAPINFO"/> structure that describes the dimensions and color format of the array
        /// pointed to by the <paramref name="pjBits"/> parameter.
        /// </param>
        /// <param name="iUsage">
        /// Specifies whether the <see cref="BITMAPINFO.bmiColors"/> member of the <see cref="BITMAPINFO"/> structure was initialized and,
        /// if so, whether <see cref="BITMAPINFO.bmiColors"/> contains explicit red, green, blue (RGB) values or palette indexes.
        /// The <paramref name="iUsage"/> parameter must be one of the following values.
        /// <see cref="DIB_PAL_COLORS"/>:
        /// A color table is provided and consists of an array of 16-bit indexes into the logical palette of the device context into
        /// which the bitmap is to be selected.
        /// <see cref="DIB_RGB_COLORS"/>:
        /// A color table is provided and contains literal RGB values.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the compatible bitmap.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// The DDB that is created will be whatever bit depth your reference DC is.
        /// To create a bitmap that is of different bit depth, use <see cref="CreateDIBSection"/>.
        /// For a device to reach optimal bitmap-drawing speed, specify fdwInit as <see cref="CBM_INIT"/>.
        /// Then, use the same color depth DIB as the video mode.
        /// When the video is running 4- or 8-bpp, use <see cref="DIB_PAL_COLORS"/>.
        /// The <see cref="CBM_CREATDIB"/> flag for the fdwInit parameter is no longer supported.
        /// When you no longer need the bitmap, call the <see cref="DeleteObject"/> function to delete it.
        /// ICM: No color management is performed. The contents of the resulting bitmap are not color matched after the bitmap has been created.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDIBitmap", SetLastError = true)]
        public static extern HBITMAP CreateDIBitmap([In]HDC hdc, [MarshalAs(UnmanagedType.LPStruct)][In]BITMAPINFOHEADER pbmih, [In]DWORD flInit,
            [In]IntPtr pjBits, [MarshalAs(UnmanagedType.LPStruct)][In]BITMAPINFO pbmi, [In]UINT iUsage);

        /// <summary>
        /// <para>
        /// The <see cref="LoadBitmap"/> function loads the specified bitmap resource from a module's executable file.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadbitmapw
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the instance of the module whose executable file contains the bitmap to be loaded.
        /// </param>
        /// <param name="lpBitmapName">
        /// A pointer to a null-terminated string that contains the name of the bitmap resource to be loaded.
        /// Alternatively, this parameter can consist of the resource identifier in the low-order word and zero in the high-order word.
        /// The <see cref="MAKEINTRESOURCE"/> macro can be used to create this value.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the specified bitmap.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// If the bitmap pointed to by the <paramref name="lpBitmapName"/> parameter does not exist or
        /// there is insufficient memory to load the bitmap, the function fails.
        /// <see cref="LoadBitmap"/> creates a compatible bitmap of the display, which cannot be selected to a printer.
        /// To load a bitmap that you can select to a printer, call <see cref="LoadImage"/> and specify <see cref="LR_CREATEDIBSECTION"/> to create a DIB section.
        /// A DIB section can be selected to any device.
        /// An application can use the <see cref="LoadBitmap"/> function to access predefined bitmaps.
        /// To do so, the application must set the <paramref name="hInstance"/> parameter to <see cref="NULL"/>
        /// and the <paramref name="lpBitmapName"/> parameter to one of the following values.
        /// OBM_BTNCORNERS, OBM_BTSIZE, OBM_CHECK, OBM_CHECKBOXES, OBM_CLOSE, OBM_COMBO, OBM_DNARROW, OBM_DNARROWD, OBM_DNARROWI, OBM_LFARROW,
        /// OBM_LFARROWD, OBM_LFARROWI, OBM_MNARROW, OBM_OLD_CLOSE, OBM_OLD_DNARROW, OBM_OLD_LFARROW, OBM_OLD_REDUCE, OBM_OLD_RESTORE,
        /// OBM_OLD_RGARROW, OBM_OLD_UPARROW, OBM_OLD_ZOOM, OBM_REDUCE, OBM_REDUCED, OBM_RESTORE, OBM_RESTORED, OBM_RGARROW, OBM_RGARROWD,
        /// OBM_RGARROWI, OBM_SIZE, OBM_UPARROW, OBM_UPARROWD, OBM_UPARROWI, OBM_ZOOM, OBM_ZOOMD
        /// Bitmap names that begin with OBM_OLD represent bitmaps used by 16-bit versions of Windows earlier than 3.0.
        /// For an application to use any of the OBM_ constants,
        /// the constant <see cref="OEMRESOURCE"/> must be defined before the Windows.h header file is included.
        /// The application must call the <see cref="DeleteObject"/> function to delete each bitmap handle returned by the <see cref="LoadBitmap"/> function.
        /// </remarks>
        [Obsolete("LoadBitmap is available for use in the operating systems specified in the Requirements section." +
            "It may be altered or unavailable in subsequent versions. Instead, use LoadImage and DrawFrameControl.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadBitmapW", SetLastError = true)]
        public static extern HBITMAP LoadBitmap([In]HINSTANCE hInstance, [MarshalAs(UnmanagedType.LPWStr)][In]string lpBitmapName);
    }
}
