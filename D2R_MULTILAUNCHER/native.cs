using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace handles
{
    class Native
    {
        public const int PROCESS_DUP_HANDLE = 0x00000040;
        public const int ObjectTypeInformation = 2;
        public const int ObjectNameInformation = 1;
        public const int SystemHandleInformation = 16;

        [DllImport("kernel32.dll")]
        public static extern SafeFileHandle OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("ntdll.dll")]
        internal static extern NtStatus NtQuerySystemInformation(
            [In] int SystemInformationClass,
            [In] IntPtr SystemInformation,
            [In] int SystemInformationLength,
            [Out] out int ReturnLength);

        [DllImport("ntdll.dll")]
        internal static extern NtStatus NtDuplicateObject(
            [In] SafeFileHandle SourceProcessHandle,
            [In] IntPtr SourceHandle,
            [In] IntPtr TargetProcessHandle,
            [Out] out SafeFileHandle TargetHandle,
            [In] int DesiredAccess,
            [In] int InheritHandle,
            [In] int Options
    );

        [DllImport("ntdll.dll")]
        internal static extern NtStatus NtQueryObject(
            [In] SafeFileHandle Handle,
            [In] int ObjectInformationClass,
            [In] IntPtr ObjectInformation,
            [In] int ObjectInformationLength,
            [Out] out int ReturnLength);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetCurrentProcess();

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_HANDLE
        {
            public int ProcessId;
            public byte ObjectTypeNumber;
            public byte Flags;
            public ushort Handle;
            public IntPtr Object;
            public int GrantedAccess;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct UNICODE_STRING
        {
            public ushort Length;
            public ushort MaximumLength;
            public IntPtr Buffer;

            public override string ToString()
            {
                return Buffer != IntPtr.Zero ? Marshal.PtrToStringUni(Buffer, Length / 2) : null;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct GENERIC_MAPPING
        {
            public int GenericRead;
            public int GenericWrite;
            public int GenericExecute;
            public int GenericAll;
        }

        public enum POOL_TYPE
        {
            NonPagedPool,
            PagedPool,
            NonPagedPoolMustSucceed,
            DontUseThisType,
            NonPagedPoolCacheAligned,
            PagedPoolCacheAligned,
            NonPagedPoolCacheAlignedMustS
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct OBJECT_TYPE_INFORMATION
        {
            public UNICODE_STRING Name;
            int TotalNumberOfObjects;
            int TotalNumberOfHandles;
            int TotalPagedPoolUsage;
            int TotalNonPagedPoolUsage;
            int TotalNamePoolUsage;
            int TotalHandleTableUsage;
            int HighWaterNumberOfObjects;
            int HighWaterNumberOfHandles;
            int HighWaterPagedPoolUsage;
            int HighWaterNonPagedPoolUsage;
            int HighWaterNamePoolUsage;
            int HighWaterHandleTableUsage;
            int InvalidAttributes;
            GENERIC_MAPPING GenericMapping;
            int ValidAccess;
            bool SecurityRequired;
            bool MaintainHandleCount;
            ushort MaintainTypeList;
            POOL_TYPE PoolType;
            int PagedPoolUsage;
            int NonPagedPoolUsage;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct OBJECT_NAME_INFORMATION
        {
            public UNICODE_STRING Name;
        }
    }
}