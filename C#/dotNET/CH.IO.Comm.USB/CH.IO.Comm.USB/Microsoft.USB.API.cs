﻿using System;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace CH.IO.Comm
{
    public partial class USB : DEVICE
    {
        #region === USB API ===
        //Constant definitions from setupapi.h, which we aren't allowed to include directly since this is C#
        internal const uint DIGCF_PRESENT = 0x02;
        internal const uint DIGCF_DEVICEINTERFACE = 0x10;
        //Constants for CreateFile() and other file I/O functions
        internal const short FILE_ATTRIBUTE_NORMAL = 0x80;
        internal const short INVALID_HANDLE_VALUE = -1;
        internal const uint GENERIC_READ = 0x80000000;
        internal const uint GENERIC_WRITE = 0x40000000;
        internal const uint CREATE_NEW = 1;
        internal const uint CREATE_ALWAYS = 2;
        internal const uint OPEN_EXISTING = 3;
        internal const uint FILE_SHARE_READ = 0x00000001;
        internal const uint FILE_SHARE_WRITE = 0x00000002;
        //Constant definitions for certain WM_DEVICECHANGE messages
        internal const uint WM_DEVICECHANGE = 0x0219;
        internal const uint DBT_DEVICEARRIVAL = 0x8000;
        internal const uint DBT_DEVICEREMOVEPENDING = 0x8003;
        internal const uint DBT_DEVICEREMOVECOMPLETE = 0x8004;
        internal const uint DBT_CONFIGCHANGED = 0x0018;
        //Other constant definitions
        internal const uint DBT_DEVTYP_DEVICEINTERFACE = 0x05;
        internal const uint DEVICE_NOTIFY_WINDOW_HANDLE = 0x00;
        internal const uint ERROR_SUCCESS = 0x00;
        internal const uint ERROR_NO_MORE_ITEMS = 0x00000103;
        internal const uint SPDRP_HARDWAREID = 0x00000001;

        //Various structure definitions for structures that this code will be using
        internal struct SP_DEVICE_INTERFACE_DATA
        {
            internal uint cbSize;               //DWORD
            internal Guid InterfaceClassGuid;   //GUID
            internal uint Flags;                //DWORD
            internal uint Reserved;             //ULONG_PTR MSDN says ULONG_PTR is "typedef unsigned __int3264 ULONG_PTR;"  
        }

        internal struct SP_DEVICE_INTERFACE_DETAIL_DATA
        {
            internal uint cbSize;               //DWORD
            internal char[] DevicePath;         //TCHAR array of any size
        }

        internal struct SP_DEVINFO_DATA
        {
            internal uint cbSize;       //DWORD
            internal Guid ClassGuid;    //GUID
            internal uint DevInst;      //DWORD
            internal uint Reserved;     //ULONG_PTR  MSDN says ULONG_PTR is "typedef unsigned __int3264 ULONG_PTR;"  
        }

        internal struct DEV_BROADCAST_DEVICEINTERFACE
        {
            internal uint dbcc_size;            //DWORD
            internal uint dbcc_devicetype;      //DWORD
            internal uint dbcc_reserved;        //DWORD
            internal Guid dbcc_classguid;       //GUID
            internal char[] dbcc_name;          //TCHAR array
        }

        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern IntPtr SetupDiGetClassDevs(
            ref Guid ClassGuid,     //LPGUID    Input: Need to supply the class GUID. 
            IntPtr Enumerator,      //PCTSTR    Input: Use NULL here, not important for our purposes
            IntPtr hwndParent,      //HWND      Input: Use NULL here, not important for our purposes
            uint Flags);            //DWORD     Input: Flags describing what kind of filtering to use.

        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool SetupDiEnumDeviceInterfaces(
            IntPtr DeviceInfoSet,           //Input: Give it the HDEVINFO we got from SetupDiGetClassDevs()
            IntPtr DeviceInfoData,          //Input (optional)
            ref Guid InterfaceClassGuid,    //Input 
            uint MemberIndex,               //Input: "Index" of the device you are interested in getting the path for.
            ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);    //Output: This function fills in an "SP_DEVICE_INTERFACE_DATA" structure.

        //SetupDiDestroyDeviceInfoList() frees up memory by destroying a DeviceInfoList
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool SetupDiDestroyDeviceInfoList(
            IntPtr DeviceInfoSet);          //Input: Give it a handle to a device info list to deallocate from RAM.

        //SetupDiEnumDeviceInfo() fills in an "SP_DEVINFO_DATA" structure, which we need for SetupDiGetDeviceRegistryProperty()
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool SetupDiEnumDeviceInfo(
            IntPtr DeviceInfoSet,
            uint MemberIndex,
            ref SP_DEVINFO_DATA DeviceInterfaceData);

        //SetupDiGetDeviceRegistryProperty() gives us the hardware ID, which we use to check to see if it has matching VID/PID
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool SetupDiGetDeviceRegistryProperty(
            IntPtr DeviceInfoSet,
            ref SP_DEVINFO_DATA DeviceInfoData,
            uint Property,
            ref uint PropertyRegDataType,
            IntPtr PropertyBuffer,
            uint PropertyBufferSize,
            ref uint RequiredSize);

        //SetupDiGetDeviceInterfaceDetail() gives us a device path, which is needed before CreateFile() can be used.
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool SetupDiGetDeviceInterfaceDetail(
            IntPtr DeviceInfoSet,                   //Input: Wants HDEVINFO which can be obtained from SetupDiGetClassDevs()
            ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,                    //Input: Pointer to an structure which defines the device interface.  
            IntPtr DeviceInterfaceDetailData,      //Output: Pointer to a SP_DEVICE_INTERFACE_DETAIL_DATA structure, which will receive the device path.
            uint DeviceInterfaceDetailDataSize,     //Input: Number of bytes to retrieve.
            ref uint RequiredSize,                  //Output (optional): The number of bytes needed to hold the entire struct 
            IntPtr DeviceInfoData);                 //Output (optional): Pointer to a SP_DEVINFO_DATA structure

        //Overload for SetupDiGetDeviceInterfaceDetail().  Need this one since we can't pass NULL pointers directly in C#.
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool SetupDiGetDeviceInterfaceDetail(
            IntPtr DeviceInfoSet,                   //Input: Wants HDEVINFO which can be obtained from SetupDiGetClassDevs()
            ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,               //Input: Pointer to an structure which defines the device interface.  
            IntPtr DeviceInterfaceDetailData,       //Output: Pointer to a SP_DEVICE_INTERFACE_DETAIL_DATA structure, which will contain the device path.
            uint DeviceInterfaceDetailDataSize,     //Input: Number of bytes to retrieve.
            IntPtr RequiredSize,                    //Output (optional): Pointer to a DWORD to tell you the number of bytes needed to hold the entire struct 
            IntPtr DeviceInfoData);                 //Output (optional): Pointer to a SP_DEVINFO_DATA structure

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern IntPtr RegisterDeviceNotification(
            IntPtr hRecipient,
            IntPtr NotificationFilter,
            uint Flags);

        //Takes in a device path and opens a handle to the device.
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern SafeFileHandle CreateFile(
            string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            IntPtr lpSecurityAttributes,
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        //Uses a handle (created with CreateFile()), and lets us write USB data to the device.
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern bool WriteFile(
            SafeFileHandle hFile,
            byte[] lpBuffer,
            uint nNumberOfBytesToWrite,
            ref uint lpNumberOfBytesWritten,
            IntPtr lpOverlapped);

        //Uses a handle (created with CreateFile()), and lets us read USB data from the device.
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern bool ReadFile(
            SafeFileHandle hFile,
            IntPtr lpBuffer,
            uint nNumberOfBytesToRead,
            ref uint lpNumberOfBytesRead,
            IntPtr lpOverlapped);

        bool AttachedState = false;
        bool AttachedButBroken = false;
        SafeFileHandle WriteHandleToUSBDevice = null;
        SafeFileHandle ReadHandleToUSBDevice = null;
        String DevicePath = null;
        //Globally Unique Identifier (GUID) for HID class devices.  Windows uses GUIDs to identify things.
        Guid InterfaceClassGuid = new Guid(0x4d1e55b2, 0xf16f, 0x11cf, 0x88, 0xcb, 0x00, 0x11, 0x11, 0x00, 0x00, 0x30);
        #endregion
    }
}
