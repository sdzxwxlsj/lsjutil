﻿using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Ole32.dll
    /// </summary>
    public static class Ole32
    {
        /// <summary>
        /// Locates an object by means of its moniker, activates the object if it is inactive,
        /// and retrieves a pointer to the specified interface on that object.
        /// </summary>
        /// <param name="pmk">
        /// A pointer to the object's moniker. See <see cref="IMoniker"/>.
        /// </param>
        /// <param name="grfOpt">
        /// This parameter is reserved for future use and must be 0.
        /// </param>
        /// <param name="iidResult">
        /// The interface identifier to be used to communicate with the object.
        /// </param>
        /// <param name="ppvResult">
        /// The address of pointer variable that receives the interface pointer requested in <paramref name="iidResult"/>.
        /// Upon successful return, <paramref name="ppvResult"/> contains the requested interface pointer.
        /// If an error occurs, <paramref name="ppvResult"/> is <see langword="null"/>.
        /// If the call is successful, the caller is responsible for releasing the pointer with a call to the object's IUnknown::Release method.
        /// </param>
        /// <returns>
        /// This function can return the following error codes, or any of the error values returned by the <see cref="IMoniker.BindToObject"/> method.
        /// <see cref="S_OK"/>: The object was located and activated, if necessary, and a pointer to the requested interface was returned.
        /// <see cref="MK_E_NOOBJECT"/>: The object that the moniker object identified could not be found.
        /// </returns>
        /// <remarks>
        /// <see cref="BindMoniker"/> is a helper function supplied as a convenient way for a client that has the moniker of an object
        /// to obtain a pointer to one of that object's interfaces. <see cref="BindMoniker"/> packages the following calls:
        /// <code>
        /// CreateBindCtx(0, &amp;pbc); 
        /// pmk-&gt;BindToObject(pbc, NULL, riid, ppvObj);
        /// </code>
        /// <see cref="CreateBindCtx"/> creates a bind context object that supports the system implementation of <see cref="IBindContext"/>.
        /// The <paramref name="pmk"/> parameter is actually a pointer to the <see cref="IMoniker"/> implementation on a moniker object
        /// This implementation's <see cref="IMoniker.BindToObject"/> method supplies the pointer to the requested interface pointer.
        /// If you have several monikers to bind in quick succession and if you know that those monikers will activate the same object,
        /// it may be more efficient to call the <see cref="IMoniker.BindToObject"/> method directly,
        /// which enables you to use the same bind context object for all the monikers.
        /// See the <see cref="IBindCtx"/> interface for more information.
        /// Container applications that allow their documents to contain linked objects are a special client
        /// that generally does not make direct calls to <see cref="IMoniker"/> methods.
        /// Instead, the client manipulates the linked objects through the <see cref="IOleLink"/> interface.
        /// The default handler implements this interface and calls the appropriate <see cref="IMoniker"/> methods as needed.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "BindMoniker", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT BindMoniker([In]IMoniker pmk, [In]uint grfOpt, [MarshalAs(UnmanagedType.LPStruct)][In]Guid iidResult,
            [MarshalAs(UnmanagedType.IUnknown)][Out]object ppvResult);

        /// <summary>
        /// <para>
        /// Creates a single uninitialized object of the class associated with a specified CLSID.
        /// Call <see cref="CoCreateInstance"/> when you want to create only one object on the local system.
        /// To create a single object on a remote system, call the <see cref="CoCreateInstanceEx"/> function.
        /// To create multiple objects based on a single CLSID, call the <see cref="CoGetClassObject"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/combaseapi/nf-combaseapi-cocreateinstance
        /// </para>
        /// </summary>
        /// <param name="rclsid">
        /// The CLSID associated with the data and code that will be used to create the object.
        /// </param>
        /// <param name="pUnkOuter">
        /// If <see langword="null"/>, indicates that the object is not being created as part of an aggregate.
        /// If non-NULL, pointer to the aggregate object's IUnknown interface (the controlling IUnknown).
        /// </param>
        /// <param name="dwClsContext">
        /// Context in which the code that manages the newly created object will run.
        /// The values are taken from the enumeration <see cref="CLSCTX"/>.
        /// </param>
        /// <param name="riid">
        /// A reference to the identifier of the interface to be used to communicate with the object.
        /// </param>
        /// <param name="ppv">
        /// Address of pointer variable that receives the interface pointer requested in riid.
        /// Upon successful return, *ppv contains the requested interface pointer.
        /// Upon failure, *ppv contains <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This function can return the following values.
        /// <see cref="S_OK"/>: An instance of the specified object class was successfully created.
        /// <see cref="REGDB_E_CLASSNOTREG"/>:  A specified class is not registered in the registration database.
        /// Also can indicate that the type of server you requested in the <see cref="CLSCTX"/> enumeration is not registered
        /// or the values for the server types in the registry are corrupt.
        /// <see cref="CLASS_E_NOAGGREGATION"/>:
        /// This class cannot be created as part of an aggregate.
        /// <see cref="E_NOINTERFACE"/>:
        /// The specified class does not implement the requested interface, or the controlling IUnknown does not expose the requested interface.
        /// <see cref="E_POINTER"/>:
        /// The <paramref name="ppv"/> parameter is <see langword="null"/>.
        /// </returns>
        /// <remarks>
        /// The CoCreateInstance function provides a convenient shortcut by connecting to the class object associated with the specified CLSID,
        /// creating an uninitialized instance, and releasing the class object.
        /// As such, it encapsulates the following functionality:
        /// <code>
        /// CoGetClassObject(rclsid, dwClsContext, NULL, IID_IClassFactory, &amp;pCF); 
        /// hresult = pCF->CreateInstance(pUnkOuter, riid, ppvObj)
        /// pCF->Release();
        /// </code>
        /// It is convenient to use <see cref="CoCreateInstance"/> when you need to create only a single instance of an object on the local machine.
        /// If you are creating an instance on remote computer, call <see cref="CoCreateInstanceEx"/>.
        /// When you are creating multiple instances, it is more efficient to obtain a pointer to the class object's <see cref="IClassFactory"/> interface
        /// and use its methods as needed. In the latter case, you should use the <see cref="CoGetClassObject"/> function.
        /// In the <see cref="CLSCTX"/> enumeration, you can specify the type of server used to manage the object.
        /// The constants can be <see cref="CLSCTX_INPROC_SERVER"/>, <see cref="CLSCTX_INPROC_HANDLER"/>, <see cref="CLSCTX_LOCAL_SERVER"/>,
        /// <see cref="CLSCTX_REMOTE_SERVER"/> or any combination of these values.
        /// The constant <see cref="CLSCTX_ALL"/> is defined as the combination of all four.
        /// For more information about the use of one or a combination of these constants, see <see cref="CLSCTX"/>.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoCreateInstance", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoCreateInstance([MarshalAs(UnmanagedType.LPStruct)][In]Guid rclsid,
            [MarshalAs(UnmanagedType.IUnknown)]object pUnkOuter, [In]CLSCTX dwClsContext, [MarshalAs(UnmanagedType.LPStruct)][In]Guid riid,
            [MarshalAs(UnmanagedType.IUnknown)]out object ppv);

        /// <summary>
        /// <para>
        /// Retrieves a pointer to the default OLE task memory allocator (which supports the system implementation of the <see cref="IMalloc"/> interface)
        /// so applications can call its methods to manage memory.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/combaseapi/nf-combaseapi-cogetmalloc
        /// </para>
        /// </summary>
        /// <param name="dwMemContext">
        /// This parameter must be 1.
        /// </param>
        /// <param name="ppMalloc">
        /// The address of an IMalloc* pointer variable that receives the interface pointer to the memory allocator.
        /// </param>
        /// <returns>
        /// This function can return the standard return values <see cref="S_OK"/>, <see cref="E_INVALIDARG"/>, and <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// The pointer to the IMalloc interface pointer received through the <paramref name="ppMalloc"/> parameter cannot be used from a remote process;
        /// each process must have its own allocator.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoGetMalloc", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoGetMalloc([In]uint dwMemContext, [Out]out IntPtr ppMalloc);

        /// <summary>
        /// <para>
        /// Allocates a block of task memory in the same way that IMalloc::Alloc does.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/combaseapi/nf-combaseapi-cotaskmemalloc
        /// </para>
        /// </summary>
        /// <param name="cb">
        /// The size of the memory block to be allocated, in bytes.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns the allocated memory block.
        /// Otherwise, it returns <see cref="IntPtr.Zero"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="CoTaskMemAlloc"/> uses the default allocator to allocate a memory block in the same way that IMalloc::Alloc does.
        /// It is not necessary to call the <see cref="CoGetMalloc"/> function before calling <see cref="CoTaskMemAlloc"/>.
        /// The initial contents of the returned memory block are undefined – there is no guarantee that the block has been initialized.
        /// The allocated block may be larger than cb bytes because of the space required for alignment and for maintenance information.
        /// If <paramref name="cb"/> is 0, <see cref="CoTaskMemAlloc"/> allocates a zero-length item and returns a valid pointer to that item.
        /// If there is insufficient memory available, <see cref="CoTaskMemAlloc"/> returns <see cref="IntPtr.Zero"/>.
        /// Applications should always check the return value from this function, even when requesting small amounts of memory,
        /// because there is no guarantee that the memory will be allocated.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoTaskMemAlloc", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CoTaskMemAlloc([In]IntPtr cb);

        /// <summary>
        /// <para>
        /// Frees a block of task memory previously allocated through a call to the <see cref="CoTaskMemAlloc"/> or <see cref="CoTaskMemRealloc"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/combaseapi/nf-combaseapi-cotaskmemfree
        /// </para>
        /// </summary>
        /// <param name="pv">
        /// A pointer to the memory block to be freed.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the function has no effect.
        /// </param>
        /// <remarks>
        /// The <see cref="CoTaskMemFree"/> function uses the default OLE allocator.
        /// The number of bytes freed equals the number of bytes that were originally allocated or reallocated.
        /// After the call, the memory block pointed to by pv is invalid and can no longer be used.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoTaskMemFree", ExactSpelling = true, SetLastError = true)]
        public static extern void CoTaskMemFree([In]IntPtr pv);

        /// <summary>
        /// <para>
        /// Changes the size of a previously allocated block of task memory.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/combaseapi/nf-combaseapi-cotaskmemrealloc
        /// </para>
        /// </summary>
        /// <param name="pv">
        /// A pointer to the memory block to be reallocated.
        /// This parameter can be <see cref="IntPtr.Zero"/>, as discussed in Remarks.
        /// </param>
        /// <param name="cb">
        /// The size of the memory block to be reallocated, in bytes.
        /// This parameter can be 0, as discussed in Remarks.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns the reallocated memory block.
        /// Otherwise, it returns <see cref="IntPtr.Zero"/>.
        /// </returns>
        /// <remarks>
        /// This function changes the size of a previously allocated memory block in the same way that IMalloc::Realloc does.
        /// It is not necessary to call the <see cref="CoGetMalloc"/> function to get a pointer
        /// to the OLE allocator before calling <see cref="CoTaskMemRealloc"/>.
        /// The <paramref name="pv"/> parameter points to the beginning of the memory block.
        /// If <paramref name="pv"/> is <see cref="IntPtr.Zero"/>, <see cref="CoTaskMemRealloc"/> allocates a new memory block
        /// in the same way as the <see cref="CoTaskMemAlloc"/> function.
        /// If <paramref name="pv"/> is not <see cref="IntPtr.Zero"/>, it should be a pointer returned by a prior call to <see cref="CoTaskMemAlloc"/>.
        /// The <paramref name="cb"/> parameter specifies the size of the new block.
        /// The contents of the block are unchanged up to the shorter of the new and old sizes,
        /// although the new block can be in a different location.
        /// Because the new block can be in a different memory location, the pointer returned by <see cref="CoTaskMemRealloc"/> is not guaranteed
        /// to be the pointer passed through the <paramref name="pv"/> argument.
        /// If <paramref name="pv"/> is not <see cref="IntPtr.Zero"/> and <paramref name="cb"/> is 0,
        /// then the memory pointed to by <paramref name="pv"/> is freed.
        /// <see cref="CoTaskMemRealloc"/> returns a void pointer to the reallocated (and possibly moved) memory block.
        /// The return value is <see cref="IntPtr.Zero"/> if the size is 0 and the buffer argument is not <see cref="IntPtr.Zero"/>,
        /// or if there is not enough memory available to expand the block to the specified size.
        /// In the first case, the original block is freed; in the second case, the original block is unchanged.
        /// The storage space pointed to by the return value is guaranteed to be suitably aligned for storage of any type of object.
        /// To get a pointer to a type other than void, use a type cast on the return value.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoTaskMemRealloc", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CoTaskMemRealloc([In]IntPtr pv, [In]IntPtr cb);

        /// <summary>
        /// <para>
        /// Returns a pointer to an implementation of <see cref="IBindCtx"/> (a bind context object).
        /// This object stores information about a particular moniker-binding operation.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objbase/nf-objbase-createbindctx
        /// </para>
        /// </summary>
        /// <param name="reserved">
        /// This parameter is reserved and must be 0.
        /// </param>
        /// <param name="ppbc">
        /// Address of an <see cref="IBindCtx"/> pointer variable that receives the interface pointer to the new bind context object.
        /// When the function is successful, the caller is responsible for calling <see cref="Marshal.ReleaseComObject(object)"/> on the bind context.
        /// A <see langword="null"/> value for the bind context indicates that an error occurred.
        /// </param>
        /// <returns>
        /// This function can return the standard return values <see cref="E_OUTOFMEMORY"/> and <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// CreateBindCtx is most commonly used in the process of binding a moniker
        /// (locating and getting a pointer to an interface by identifying it through a moniker), as in the following steps:
        /// Get a pointer to a bind context by calling the <see cref="CreateBindCtx"/> function.
        /// Call the <see cref="IMoniker.BindToObject"/> on the moniker, retrieving an interface pointer to the object to which the moniker refers.
        /// Release the bind context.
        /// Use the interface pointer.
        /// Release the interface pointer.
        /// The following code fragment illustrates these steps.
        /// <code>
        /// // pMnk is an IMoniker * that points to a previously acquired moniker 
        /// IInterface* pInterface;
        /// IBindCtx* pbc;
        /// 
        /// CreateBindCtx( 0, &amp;pbc );
        /// pMnk-&gt;BindToObject(pbc, NULL, IID_IInterface, &amp;pInterface );
        /// pbc-&gt;Release();
        /// 
        /// // pInterface now points to the object; safe to use pInterface 
        /// pInterface-&gt;Release();
        /// </code>
        /// Bind contexts are also used in other methods of the <see cref="IMoniker"/> interface besides <see cref="IMoniker.BindToObject"/>
        /// and in the <see cref="MkParseDisplayName"/> function.
        /// A bind context retains references to the objects that are bound during the binding operation,
        /// causing the bound objects to remain active (keeping the object's server running) until the bind context is released.
        /// Reusing a bind context when subsequent operations bind to the same object can improve performance.
        /// You should, however, release the bind context as soon as possible, because you could be keeping the objects activated unnecessarily.
        /// A bind context contains a <see cref="BIND_OPTS"/> structure, which contains parameters that apply to all steps in a binding operation.
        /// When you create a bind context using <see cref="CreateBindCtx"/>, the fields of the <see cref="BIND_OPTS"/> structure are initialized as follows.
        /// <code>
        /// cbStruct = sizeof(BIND_OPTS) 
        /// grfFlags = 0 
        /// grfMode = STGM_READWRITE 
        /// dwTickCountDeadline = 0
        /// </code>
        /// You can call the <see cref="IBindCtx.SetBindOptions"/> method to modify these default values.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateBindCtx", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CreateBindCtx([In]DWORD reserved, [Out]out IBindCtx ppbc);
    }
}
