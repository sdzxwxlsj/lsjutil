﻿using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Kernel32.dll
    /// </summary>
    public static partial class Kernel32
    {
        /// <summary>
        /// NUMA_NO_PREFERRED_NODE
        /// </summary>
        public const uint NUMA_NO_PREFERRED_NODE = 0xffffffff;

        /// <summary>
        /// <para>
        /// Converts a file time to system time format. System time is based on Coordinated Universal Time (UTC).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/timezoneapi/nf-timezoneapi-filetimetosystemtime
        /// </para>
        /// </summary>
        /// <param name="lpFileTime">
        /// A pointer to a <see cref="FILETIME"/> structure containing the file time to be converted to system (UTC) date and time format.
        /// This value must be less than 0x8000000000000000. Otherwise, the function fails.
        /// </param>
        /// <param name="lpSystemTime">
        /// A pointer to a <see cref="SYSTEMTIME"/> structure to receive the converted file time.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FileTimeToSystemTime", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FileTimeToSystemTime([In]ref Structs.FILETIME lpFileTime, [In][Out]ref SYSTEMTIME lpSystemTime);

        /// <summary>
        /// <para>
        /// Retrieves the product type for the operating system on the local computer,
        /// and maps the type to the product types supported by the specified operating system.
        /// To retrieve product type information on versions of Windows prior to the minimum supported operating systems specified
        /// in the Requirements section, use the <see cref="GetVersionEx"/> function.
        /// You can also use the OperatingSystemSKU property of the Win32_OperatingSystem WMI class.
        /// </para>
        /// </summary>
        /// <param name="dwOSMajorVersion">
        /// The major version number of the operating system. The minimum value is 6.
        /// The combination of the <paramref name="dwOSMajorVersion"/>, <paramref name="dwOSMinorVersion"/>, <paramref name="dwSpMajorVersion"/>,
        /// and <paramref name="dwSpMinorVersion"/> parameters describes the maximum target operating system version for the application.
        /// For example, Windows Vista and Windows Server 2008 are version 6.0.0.0 and Windows 7 and Windows Server 2008 R2 are version 6.1.0.0.
        /// All Windows 10 based releases will be listed as version 6.3.
        /// </param>
        /// <param name="dwOSMinorVersion">
        /// The minor version number of the operating system. The minimum value is 0.
        /// </param>
        /// <param name="dwSpMajorVersion">
        /// The major version number of the operating system service pack. The minimum value is 0.
        /// </param>
        /// <param name="dwSpMinorVersion">
        /// The minor version number of the operating system service pack. The minimum value is 0.
        /// </param>
        /// <param name="pdwReturnedProductType">
        /// The product type. This parameter cannot be <see cref="IntPtr.Zero"/>.
        /// If the specified operating system is less than the current operating system,
        /// this information is mapped to the types supported by the specified operating system.
        /// If the specified operating system is greater than the highest supported operating system,
        /// this information is mapped to the types supported by the current operating system.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To detect whether a server role or feature is installed, use the Server Feature WMI provider.
        /// Subsequent releases of Windows will map the product types it supports to the set of product types supported
        /// by each supported previous release of Windows, back to version 6.0.0.0.
        /// Therefore, an application that does an equality test for any of these values will continue to work on future releases,
        /// even when new product types are added.
        /// PRODUCT_*_SERVER_CORE values are not returned in Windows Server 2012, and later.
        /// For example, the base server edition, Server Datacenter,
        /// is used to build the two different installation options: "full server" and "core server".
        /// With Windows Server 2012, <see cref="GetProductInfo"/> will return <see cref="PRODUCT_DATACENTER"/> regardless of
        /// the option used during product installation.
        /// As noted above, for Server Core installations of Windows Server 2012 and later, use the method Determining whether Server Core is running.
        /// The following table indicates the product types that were introduced in 6.1.0.0,
        /// and what they will map to if <see cref="GetProductInfo"/> is called with version 6.0.0.0 on a 6.1.0.0 system.
        /// New for 6.1.0.0	Value                   returned with 6.0.0.0
        /// <see cref="PRODUCT_PROFESSIONAL"/>      <see cref="PRODUCT_BUSINESS"/>
        /// <see cref="PRODUCT_PROFESSIONAL_N"/>    <see cref="PRODUCT_BUSINESS_N"/>
        /// <see cref="PRODUCT_STARTER_N"/>         <see cref="PRODUCT_STARTER"/>
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProductInfo", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetProductInfo([In]uint dwOSMajorVersion, [In]uint dwOSMinorVersion, [In]uint dwSpMajorVersion,
            [In]uint dwSpMinorVersion, [In][Out]ref ProductTypes pdwReturnedProductType);

        /// <summary>
        /// <para>
        /// Retrieves the path of the system directory.
        /// The system directory contains system files such as dynamic-link libraries and drivers.
        /// This function is provided primarily for compatibility.
        /// Applications should store code in the Program Files folder and persistent data in the Application Data folder in the user's profile.
        /// For more information, see <see cref="ShGetFolderPath"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/sysinfoapi/nf-sysinfoapi-getsystemdirectoryw
        /// </para>
        /// </summary>
        /// <param name="lpBuffer">
        /// A pointer to the buffer to receive the path.
        /// This path does not end with a backslash unless the system directory is the root directory.
        /// For example, if the system directory is named Windows\System32 on drive C,
        /// the path of the system directory retrieved by this function is C:\Windows\System32.
        /// </param>
        /// <param name="uSize">
        /// The maximum size of the buffer, in TCHARs.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length, in TCHARs, of the string copied to the buffer,
        /// not including the terminating null character.
        /// If the length is greater than the size of the buffer, the return value is the size of the buffer required to hold the path,
        /// including the terminating null character.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Applications should not create files in the system directory.
        /// If the user is running a shared version of the operating system, the application does not have write access to the system directory.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemDirectoryW", SetLastError = true)]
        public static extern uint GetSystemDirectory([Out]StringBuilder lpBuffer, [In]uint uSize);

        /// <summary>
        /// <para>
        /// Retrieves the path of the shared Windows directory on a multi-user system.
        /// This function is provided primarily for compatibility.
        /// Applications should store code in the Program Files folder and persistent data in the Application Data folder in the user's profile.
        /// For more information, see <see cref="ShGetFolderPath"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/sysinfoapi/nf-sysinfoapi-getsystemwindowsdirectoryw
        /// </para>
        /// </summary>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the path.
        /// This path does not end with a backslash unless the Windows directory is the root directory.
        /// For example, if the Windows directory is named Windows on drive C, the path of the Windows directory retrieved by this function is C:\Windows.
        /// If the system was installed in the root directory of drive C, the path retrieved is C:.
        /// </param>
        /// <param name="uSize">
        /// The maximum size of the buffer specified by the lpBuffer parameter, in TCHARs.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length of the string copied to the buffer, in TCHARs,
        /// not including the terminating null character.
        /// If the length is greater than the size of the buffer, the return value is the size of the buffer required to hold the path.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// On a system that is running Terminal Services, each user has a unique Windows directory.
        /// The system Windows directory is shared by all users,
        /// so it is the directory where an application should store initialization and help files that apply to all users.
        /// With Terminal Services, the <see cref="GetSystemWindowsDirectory"/> function retrieves the path of the system Windows directory,
        /// while the <see cref="GetWindowsDirectory"/> function retrieves the path of a Windows directory that is private for each user.
        /// On a single-user system, <see cref="GetSystemWindowsDirectory"/> is the same as <see cref="GetWindowsDirectory"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemWindowsDirectoryW", SetLastError = true)]
        public static extern uint GetSystemWindowsDirectory([MarshalAs(UnmanagedType.LPWStr)][Out]StringBuilder lpBuffer, [In]uint uSize);

        /// <summary>
        /// <para>
        /// With the release of Windows 8.1, the behavior of the <see cref="GetVersionEx"/> API has changed in the value
        /// it will return for the operating system version.
        /// The value returned by the <see cref="GetVersionEx"/> function now depends on how the application is manifested.
        /// Applications not manifested for Windows 8.1 or Windows 10 will return the Windows 8 OS version value (6.2).
        /// Once an application is manifested for a given operating system version,
        /// <see cref="GetVersionEx"/> will always return the version that the application is manifested for in future releases.
        /// To manifest your applications for Windows 8.1 or Windows 10, refer to Targeting your application for Windows.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/sysinfoapi/nf-sysinfoapi-getversionexw
        /// </para>
        /// </summary>
        /// <param name="lpVersionInformation">
        /// An <see cref="OSVERSIONINFO"/> or <see cref="OSVERSIONINFOEX"/> structure that receives the operating system information.
        /// Before calling the <see cref="GetVersionEx"/> function, set the <see cref="OSVERSIONINFO.dwOSVersionInfoSize"/> member of the structure
        /// as appropriate to indicate which data structure is being passed to this function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The function fails if you specify an invalid value for the <see cref="OSVERSIONINFO.dwOSVersionInfoSize"/> member
        /// of the <see cref="OSVERSIONINFO"/> or <see cref="OSVERSIONINFOEX"/> structure.
        /// </returns>
        /// <remarks>
        /// Identifying the current operating system is usually not the best way to determine whether a particular operating system feature is present.
        /// This is because the operating system may have had new features added in a redistributable DLL.
        /// Rather than using <see cref="GetVersionEx"/> to determine the operating system platform or version number, 
        /// test for the presence of the feature itself. For more information, see Operating System Version.
        /// The <see cref="GetSystemMetrics"/> function provides additional information about the current operating system.
        /// Windows XP Media Center Edition: <see cref="SM_MEDIACENTER"/>
        /// Windows XP Starter Edition: <see cref="SM_STARTER"/>
        /// Windows XP Tablet PC Edition :<see cref="SM_TABLETPC"/>
        /// Windows Server 2003 R2: <see cref="SM_SERVERR2"/>
        /// To check for specific operating systems or operating system features, use the <see cref="IsOS"/> function.
        /// The <see cref="GetProductInfo"/> function retrieves the product type.
        /// To retrieve information for the operating system on a remote computer, use the <see cref="NetWkstaGetInfo"/> function,
        /// the Win32_OperatingSystem WMI class, or the OperatingSystem property of the IADsComputer interface.
        /// To compare the current system version to a required version, use the <see cref="VerifyVersionInfo"/> function instead of
        /// using <see cref="GetVersionEx"/> to perform the comparison yourself.
        /// If compatibility mode is in effect, the <see cref="GetVersionEx"/> function reports the operating system as it identifies itself,
        /// which may not be the operating system that is installed.
        /// For example, if compatibility mode is in effect,
        /// <see cref="GetVersionEx"/> reports the operating system that is selected for application compatibility.
        /// </remarks>
        [Obsolete("GetVersionEx may be altered or unavailable for releases after Windows 8.1. Instead, use the Version Helper functions")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetVersionExW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetVersionEx(
          [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AlternativeStructObjectMarshaler<OSVERSIONINFO, OSVERSIONINFOEX>))]
          [In]AlternativeStructObject<OSVERSIONINFO, OSVERSIONINFOEX> lpVersionInformation);

        /// <summary>
        /// <para>
        /// Retrieves the path of the Windows directory.
        /// This function is provided primarily for compatibility with legacy applications.
        /// New applications should store code in the Program Files folder and persistent data in the Application Data folder in the user's profile.
        /// For more information, see <see cref="ShGetFolderPath"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/sysinfoapi/nf-sysinfoapi-getwindowsdirectoryw
        /// </para>
        /// </summary>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the path.
        /// This path does not end with a backslash unless the Windows directory is the root directory.
        /// For example, if the Windows directory is named Windows on drive C, the path of the Windows directory retrieved by this function is C:\Windows.
        /// If the system was installed in the root directory of drive C, the path retrieved is C:.
        /// </param>
        /// <param name="uSize">
        /// The maximum size of the buffer specified by the lpBuffer parameter, in TCHARs.
        /// This value should be set to <see cref="MAX_PATH"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length of the string copied to the buffer, in TCHARs,
        /// not including the terminating null character.
        /// If the length is greater than the size of the buffer, the return value is the size of the buffer required to hold the path.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The Windows directory is the directory where some legacy applications store initialization and help files.
        /// New applications should not store files in the Windows directory;
        /// instead, they should store system-wide data in the application's installation directory, and user-specific data in the user's profile.
        /// If the user is running a shared version of the system, the Windows directory is guaranteed to be private for each user.
        /// If an application creates other files that it wants to store on a per-user basis,
        /// it should place them in the directory specified by the HOMEPATH environment variable.
        /// This directory will be different for each user, if so specified by an administrator, through the User Manager administrative tool.
        /// HOMEPATH always specifies either the user's home directory, which is guaranteed to be private for each user, or a default directory
        /// (for example, C:\USERS\DEFAULT) where the user will have all access.
        /// Terminal Services:
        /// If the application is running in a Terminal Services environment, each user has a private Windows directory.
        /// There is also a shared Windows directory for the system.
        /// If the application is Terminal-Services-aware (has the <see cref="IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE"/> flag set in the image header),
        /// this function returns the path of the system Windows directory, just as the <see cref="GetSystemWindowsDirectory"/> function does.
        /// Otherwise, it retrieves the path of the private Windows directory for the user.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowsDirectoryW", SetLastError = true)]
        public static extern uint GetWindowsDirectory([MarshalAs(UnmanagedType.LPWStr)][Out]StringBuilder lpBuffer, [In]uint uSize);

        /// <summary>
        /// <para>
        /// Adds a character string to the global atom table and returns a unique value (an atom) identifying the string.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-globaladdatomw
        /// </para>
        /// </summary>
        /// <param name="lpString">
        /// The null-terminated string to be added.
        /// The string can have a maximum size of 255 bytes.
        /// Strings that differ only in case are considered identical.
        /// The case of the first string of this name added to the table is preserved and returned by the <see cref="GlobalGetAtomName"/> function.
        /// Alternatively, you can use an integer atom that has been converted using the <see cref="MAKEINTATOM"/> macro.
        /// See the Remarks for more information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the newly created atom.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the string already exists in the global atom table,
        /// the atom for the existing string is returned and the atom's reference count is incremented.
        /// The string associated with the atom is not deleted from memory until its reference count is zero.
        /// For more information, see the <see cref="GlobalDeleteAtom"/> function.
        /// Global atoms are not deleted automatically when the application terminates.
        /// For every call to the <see cref="GlobalAddAtom"/> function, there must be a corresponding call to the <see cref="GlobalDeleteAtom"/> function.
        /// If the <paramref name="lpString"/> parameter has the form "#1234",
        /// <see cref="GlobalAddAtom"/> returns an integer atom whose value is the 16-bit representation of the decimal number
        /// specified in the string (0x04D2, in this example).
        /// If the decimal value specified is 0x0000 or is greater than or equal to 0xC000, the return value is zero, indicating an error.
        /// If <paramref name="lpString"/> was created by the <see cref="MAKEINTATOM"/> macro,
        /// the low-order word must be in the range 0x0001 through 0xBFFF.
        /// If the low-order word is not in this range, the function fails.
        /// If <paramref name="lpString"/> has any other form, <see cref="GlobalAddAtom"/> returns a string atom.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalAddAtom", SetLastError = true)]
        public static extern ushort GlobalAddAtom([MarshalAs(UnmanagedType.LPWStr)][In]string lpString);

        /// <summary>
        /// <para>
        /// Retrieves a copy of the character string associated with the specified global atom.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-globalgetatomnamew
        /// </para>
        /// </summary>
        /// <param name="nAtom">
        /// The global atom associated with the character string to be retrieved.
        /// </param>
        /// <param name="lpBuffer">
        /// The buffer for the character string.
        /// </param>
        /// <param name="nSize">
        /// The size, in characters, of the buffer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length of the string copied to the buffer, in characters,
        /// not including the terminating null character.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The string returned for an integer atom (an atom whose value is in the range 0x0001 to 0xBFFF) is a null-terminated string
        /// in which the first character is a pound sign (#) and the remaining characters represent the unsigned integer atom value.
        /// Security Considerations
        /// Using this function incorrectly might compromise the security of your program.
        /// Incorrect use of this function includes not correctly specifying the size of the <paramref name="lpBuffer"/> parameter.
        /// Also, note that a global atom is accessible by anyone; thus, privacy and the integrity of its contents is not assured.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalGetAtomNameW", SetLastError = true)]
        public static extern uint GlobalGetAtomName([In]ushort nAtom, [MarshalAs(UnmanagedType.LPWStr)][Out]StringBuilder lpBuffer, [In]int nSize);

        /// <summary>
        /// <para>
        /// Decrements the reference count of a global string atom.
        /// If the atom's reference count reaches zero, <see cref="GlobalDeleteAtom"/> removes the string associated with the atom
        /// from the global atom table.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-globaldeleteatom
        /// </para>
        /// </summary>
        /// <param name="nAtom">
        /// The atom and character string to be deleted.
        /// </param>
        /// <returns>
        /// The function always returns (ATOM) 0.
        /// To determine whether the function has failed,
        /// call <see cref="SetLastError"/> with <see cref="ERROR_SUCCESS"/> before calling <see cref="GlobalDeleteAtom"/>,
        /// then call <see cref="GetLastError"/>.
        /// If the last error code is still <see cref="ERROR_SUCCESS"/>, <see cref="GlobalDeleteAtom"/> has succeeded.
        /// </returns>
        /// <remarks>
        /// A string atom's reference count specifies the number of times the string has been added to the atom table.
        /// The <see cref="GlobalAddAtom"/> function increments the reference count of a string
        /// that already exists in the global atom table each time it is called.
        /// Each call to <see cref="GlobalAddAtom"/> should have a corresponding call to <see cref="GlobalDeleteAtom"/>.
        /// Do not call <see cref="GlobalDeleteAtom"/> more times than you call <see cref="GlobalAddAtom"/>,
        /// or you may delete the atom while other clients are using it.
        /// Applications using Dynamic Data Exchange (DDE) should follow the rules on global atom management to prevent leaks and premature deletion.
        /// <see cref="GlobalDeleteAtom"/> has no effect on an integer atom (an atom whose value is in the range 0x0001 to 0xBFFF).
        /// The function always returns zero for an integer atom.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalDeleteAtom", SetLastError = true)]
        public static extern ushort GlobalDeleteAtom([In]uint nAtom);
    }
}
