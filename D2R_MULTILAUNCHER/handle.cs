using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace handles
{
    class ProcessHandles
    {
        public static IEnumerable<Native.SYSTEM_HANDLE> getHandles(int pid)
        {
            int handleInfoSize = 0x40000;
            IntPtr handleInfoPointer = Marshal.AllocHGlobal(handleInfoSize);

            try
            {
                int returnLength;
                while (Native.NtQuerySystemInformation(
                    Native.SystemHandleInformation,
                    handleInfoPointer,
                    handleInfoSize,
                    out returnLength
                    ) == NtStatus.InfoLengthMismatch)
                {
                    handleInfoSize = returnLength * 2;
                    Marshal.FreeHGlobal(handleInfoPointer);
                    handleInfoPointer = Marshal.AllocHGlobal(handleInfoSize);
                }

                long handleCount;
                IntPtr ipHandle;

                if (Is64Bits())
                {
                    handleCount = Marshal.ReadInt64(handleInfoPointer);
                    ipHandle = new IntPtr(handleInfoPointer.ToInt64() + 8);
                }
                else
                {
                    handleCount = Marshal.ReadInt32(handleInfoPointer);
                    ipHandle = new IntPtr(handleInfoPointer.ToInt32() + 4);
                }

                var handleList = new List<Native.SYSTEM_HANDLE>();

                for (long i = 0; i < handleCount; i++)
                {
                    Native.SYSTEM_HANDLE handle;

                    if (Is64Bits())
                    {
                        handle = (Native.SYSTEM_HANDLE)Marshal.PtrToStructure(ipHandle, typeof(Native.SYSTEM_HANDLE));
                        ipHandle = new IntPtr(ipHandle.ToInt64() + Marshal.SizeOf(handle));
                    }
                    else
                    {
                        handle = (Native.SYSTEM_HANDLE)Marshal.PtrToStructure(ipHandle, typeof(Native.SYSTEM_HANDLE));
                        ipHandle = new IntPtr(ipHandle.ToInt64() + Marshal.SizeOf(handle));
                    }

                    if (handle.ProcessId != pid)
                    {
                        continue;
                    }

                    handleList.Add(handle);
                }

                return handleList;
            }
            finally
            {
                Marshal.FreeHGlobal(handleInfoPointer);
            }
        }

        public static string getObjectTypeInformation(SafeFileHandle handle)
        {
            int objectTypeInfoSize = 0x1000;
            IntPtr objectTypeInfo = Marshal.AllocHGlobal(objectTypeInfoSize);

            try
            {
                int returnLength;
                if (Native.NtQueryObject(
                    handle,
                    Native.ObjectTypeInformation,
                    objectTypeInfo,
                    objectTypeInfoSize,
                    out returnLength
                    ) != NtStatus.Success)
                {
                    return null;
                }

                var objectTypeInfoStruct = (Native.OBJECT_TYPE_INFORMATION)Marshal.PtrToStructure(objectTypeInfo, typeof(Native.OBJECT_TYPE_INFORMATION));

                return objectTypeInfoStruct.Name.ToString();
            }
            finally
            {
                Marshal.FreeHGlobal(objectTypeInfo);
            }
        }

        public static string getObjectNameInformation(SafeFileHandle dupHandle)
        {
            int objectNameInfoSize = 0x1000;
            IntPtr objectNameInfo = Marshal.AllocHGlobal(objectNameInfoSize);

            try
            {
                int returnLength;
                NtStatus status = Native.NtQueryObject(
                    dupHandle,
                    Native.ObjectNameInformation,
                    objectNameInfo,
                    objectNameInfoSize,
                    out returnLength
                    );


                if (status == NtStatus.InfoLengthMismatch || status == NtStatus.BufferOverflow)
                {
                    Marshal.FreeHGlobal(objectNameInfo);
                    objectNameInfo = Marshal.AllocHGlobal(returnLength);
                    status = Native.NtQueryObject(
                        dupHandle,
                        Native.ObjectNameInformation,
                        objectNameInfo,
                        returnLength,
                        out returnLength
                        );
                }

                if (status != NtStatus.Success)
                {
                    return null;
                }

                var objectNameInfoStruct = (Native.OBJECT_NAME_INFORMATION)Marshal.PtrToStructure(objectNameInfo, typeof(Native.OBJECT_NAME_INFORMATION));

                return objectNameInfoStruct.Name.ToString();
            }
            finally
            {
                Marshal.FreeHGlobal(objectNameInfo);
            }
        }

        private static bool Is64Bits()
        {
            return Marshal.SizeOf(typeof(IntPtr)) == 8;
        }
    }
}