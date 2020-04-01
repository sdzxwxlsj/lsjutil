﻿using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32
{
    public partial class User32
    {
        /// <summary>
        /// <para>
        /// The <see cref="CopyRect"/> function copies the coordinates of one rectangle to another.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-copyrect
        /// </para>
        /// </summary>
        /// <param name="lprcDst">
        /// Pointer to the <see cref="RECT"/> structure that receives the logical coordinates of the source rectangle.
        /// </param>
        /// <param name="lprcSrc">
        /// Pointer to the <see cref="RECT"/> structure whose coordinates are to be copied in logical units.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
        /// Instead, all rectangle coordinates and dimensions are given in signed, logical values.
        /// The mapping mode and the function in which the rectangle is used determine the units of measure.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CopyRect", SetLastError = true)]
        public static extern BOOL CopyRect([In][Out]ref RECT lprcDst, [MarshalAs(UnmanagedType.LPStruct)][In]RECT lprcSrc);

        /// <summary>
        /// <para>
        /// The <see cref="EqualRect"/> function determines whether the two specified rectangles are equal
        /// by comparing the coordinates of their upper-left and lower-right corners.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-equalrect
        /// </para>
        /// </summary>
        /// <param name="lprc1">
        /// Pointer to a <see cref="RECT"/> structure that contains the logical coordinates of the first rectangle.
        /// </param>
        /// <param name="lprc2">
        /// Pointer to a <see cref="RECT"/> structure that contains the logical coordinates of the second rectangle.
        /// </param>
        /// <returns>
        /// If the two rectangles are identical, the return value is <see cref="TRUE"/>.
        /// If the two rectangles are not identical, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="EqualRect"/> function does not treat empty rectangles as equal if their coordinates are different.
        /// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
        /// Instead, all rectangle coordinates and dimensions are given in signed, logical values.
        /// The mapping mode and the function in which the rectangle is used determine the units of measure.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EqualRect", SetLastError = true)]
        public static extern BOOL EqualRect([MarshalAs(UnmanagedType.LPStruct)][In]RECT lprc1, [MarshalAs(UnmanagedType.LPStruct)][In]RECT lprc2);

        /// <summary>
        /// <para>
        /// The <see cref="IntersectRect"/> function calculates the intersection of two source rectangles and
        /// places the coordinates of the intersection rectangle into the destination rectangle.
        /// If the source rectangles do not intersect, an empty rectangle (in which all coordinates are set to zero) is placed into the destination rectangle.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-intersectrect
        /// </para>
        /// </summary>
        /// <param name="lprcDst">
        /// A pointer to the <see cref="RECT"/> structure that is to receive the intersection of the rectangles pointed to
        /// by the <paramref name="lprcSrc1"/> and <paramref name="lprcSrc2"/> parameters.
        /// This parameter cannot be <see langword="null"/>.
        /// </param>
        /// <param name="lprcSrc1">
        /// A pointer to the <see cref="RECT"/> structure that contains the first source rectangle.
        /// </param>
        /// <param name="lprcSrc2">
        /// A pointer to the <see cref="RECT"/> structure that contains the second source rectangle.
        /// </param>
        /// <returns>
        /// If the rectangles intersect, the return value is <see cref="TRUE"/>.
        /// If the rectangles do not intersect, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
        /// Instead, all rectangle coordinates and dimensions are given in signed, logical values.
        /// The mapping mode and the function in which the rectangle is used determine the units of measure.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IntersectRect", SetLastError = true)]
        public static extern BOOL IntersectRect([In][Out]ref RECT lprcDst, [MarshalAs(UnmanagedType.LPStruct)][In]RECT lprcSrc1,
            [MarshalAs(UnmanagedType.LPStruct)][In]RECT lprcSrc2);

        /// <summary>
        /// <para>
        /// The <see cref="IsRectEmpty"/> function determines whether the specified rectangle is empty.
        /// An empty rectangle is one that has no area; that is, the coordinate of the right side is less than or equal to the coordinate of the left side,
        /// or the coordinate of the bottom side is less than or equal to the coordinate of the top side.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-isrectempty
        /// </para>
        /// </summary>
        /// <param name="lprc">
        /// Pointer to a <see cref="RECT"/> structure that contains the logical coordinates of the rectangle.
        /// </param>
        /// <returns>
        /// If the rectangle is empty, the return value is <see cref="TRUE"/>.
        /// If the rectangle is not empty, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
        /// Instead, all rectangle coordinates and dimensions are given in signed, logical values.
        /// The mapping mode and the function in which the rectangle is used determine the units of measure.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsRectEmpty", SetLastError = true)]
        public static extern BOOL IsRectEmpty([MarshalAs(UnmanagedType.LPStruct)][In]RECT lprc);

        /// <summary>
        /// <para>
        /// The <see cref="SetRect"/> function sets the coordinates of the specified rectangle.
        /// This is equivalent to assigning the left, top, right, and bottom arguments to the appropriate members of the <see cref="RECT"/> structure.
        /// </para>
        /// </summary>
        /// <param name="lprc">
        /// Pointer to the <see cref="RECT"/> structure that contains the rectangle to be set.
        /// </param>
        /// <param name="xLeft">
        /// Specifies the x-coordinate of the rectangle's upper-left corner.
        /// </param>
        /// <param name="yTop">
        /// Specifies the y-coordinate of the rectangle's upper-left corner.
        /// </param>
        /// <param name="xRight">
        /// Specifies the x-coordinate of the rectangle's lower-right corner.
        /// </param>
        /// <param name="yBottom">
        /// Specifies the y-coordinate of the rectangle's lower-right corner.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
        /// Instead, all rectangle coordinates and dimensions are given in signed, logical values.
        /// The mapping mode and the function in which the rectangle is used determine the units of measure.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetRect", SetLastError = true)]
        public static extern BOOL SetRect([In][Out]ref RECT lprc, [In]int xLeft, [In]int yTop, [In]int xRight, [In]int yBottom);

        /// <summary>
        /// <para>
        /// The <see cref="SetRectEmpty"/> function creates an empty rectangle in which all coordinates are set to zero.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setrectempty
        /// </para>
        /// </summary>
        /// <param name="lprc">
        /// Pointer to the <see cref="RECT"/> structure that contains the coordinates of the rectangle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
        /// Instead, all rectangle coordinates and dimensions are given in signed, logical values.
        /// The mapping mode and the function in which the rectangle is used determine the units of measure.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetRectEmpty", SetLastError = true)]
        public static extern BOOL SetRectEmpty([In][Out]ref RECT lprc);
    }
}
