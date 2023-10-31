using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CH.Windows32
{
    public partial class Registry
    {
        /// <summary>
        /// Default Constructor of Class Regist
        /// </summary>
        public Registry()
        {
        }

        /// <summary>
        /// Enumerator of Windows Registry Hierarchy
        /// </summary>
        public enum HIVE
        {
            /// <summary>
            /// Hierarchy of HKEY_CLASSES_ROOT
            /// </summary>
            HKEY_CLASSES_ROOT = 0x01,
            /// <summary>
            /// An abbreviated form of HKEY_CLASSES_ROOT
            /// </summary>
            HKCR = 0x01,
            /// <summary>
            /// Hierarchy of HKEY_CURRENT_USER
            /// </summary>
            HKEY_CURRENT_USER = 0x02,
            /// <summary>
            /// An abbreviated form of HKEY_CURRENT_USER
            /// </summary>
            HKCU = 0x02,
            /// <summary>
            /// Hierarchy of HKEY_LOCAL_MACHINE
            /// </summary>
            HKEY_LOCAL_MACHINE = 0x03,
            /// <summary>
            /// An abbreviated form of HKEY_LOCAL_MACHINE
            /// </summary>
            HKLM = 0x03,
            /// <summary>
            /// Hierarchy of HKEY_USERS
            /// </summary>
            HKEY_USERS = 0x04,
            /// <summary>
            /// An abbreviated form of HKEY_USERS
            /// </summary>
            HKUSR = 0x04,
            /// <summary>
            /// Hierarchy of HKEY_CURRENT_CONFIG
            /// </summary>
            HKEY_CURRENT_CONFIG = 0x05,
            /// <summary>
            /// An abbreviated form of HKEY_CURRENT_CONFIG
            /// </summary>
            HKCF = 0x05,
            /// <summary>
            /// Hierarchy of HKEY_DYN_DATA
            /// </summary>
            HKEY_DYN_DATA = 0x06,
            /// <summary>
            /// An abbreviated form of HKEY_DYN_DATA
            /// </summary>
            HKDYD = 0x06,
            /// <summary>
            /// Hierarchy of HKEY_PERFORMANCE_DATA
            /// </summary>
            HKEY_PERFORMANCE_DATA = 0x07,
            /// <summary>
            /// An abbreviated form of HKEY_PERFORMANCE_DATA
            /// </summary>
            HKPERD = 0x07
        }


        /// <summary>
        /// Get System Program Files directory path from registry
        /// </summary>
        /// <returns>Program Files directory path (String)</returns>
        public static String GetProgramFileDir()
        {
            try
            {
                return (String)Read(HIVE.HKLM, @"SOFTWARE\Microsoft\Windows\CurrentVersion", "ProgramFilesDir");
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Set Program Path that run when windows system operate
        /// </summary>
        /// <param name="ProgramName">Program Name that you want to run when system initialization</param>
        /// <param name="ProgramDir">Program Directory that you want to run when system initialization</param>
        /// <returns>false if operation failed</returns>
        public static void SetWindowRun(String ProgramName, String ProgramDir)
        {
            try
            {
                Write(HIVE.HKLM, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", ProgramName, ProgramDir);
            }
            catch
            {
            	throw;
            }
        }


        /// <summary>
        /// Set Program Path that run once when windows system operate
        /// </summary>
        /// <param name="ProgramName">Program Name that you want to run once when system initialization</param>
        /// <param name="ProgramDir">Program Directory that you want to run once when system initialization</param>
        /// <returns>true if operation is succeed, false in other case</returns>
        public static void SetWindowRunOnce(String ProgramName, String ProgramDir)
        {
            try
            {
                Write(HIVE.HKLM, @"SOFTWARE\Microsoft\Windows\CurrentVersion\RunOnce", ProgramName, ProgramDir);
            }
            catch
            {
            	throw;
            }
        }


        /// <summary>
        /// Write data to windows regsitry
        /// </summary>
        /// <param name="RegistryHIVE">Windows registry Hive archive</param>
        /// <param name="Key">Registry Key</param>
        /// <param name="Name">Registry Name</param>
        /// <param name="Data">Registry Data</param>
        /// <returns>true if operation is succeed, false in other case</returns>
        public static void Write(HIVE RegistryHIVE, String Key, String Name, object Data)
        {
            try
            {
                Microsoft.Win32.RegistryKey RegHive = null;
                Microsoft.Win32.RegistryKey RegKey = null;

                switch (RegistryHIVE)
                {
                    case HIVE.HKEY_CLASSES_ROOT:
                        RegHive = Microsoft.Win32.Registry.ClassesRoot;
                        break;
                    case HIVE.HKEY_CURRENT_USER:
                        RegHive = Microsoft.Win32.Registry.CurrentUser;
                        break;
                    case HIVE.HKEY_LOCAL_MACHINE:
                        RegHive = Microsoft.Win32.Registry.LocalMachine;
                        break;
                    case HIVE.HKEY_USERS:
                        RegHive = Microsoft.Win32.Registry.Users;
                        break;
                    case HIVE.HKEY_CURRENT_CONFIG:
                        RegHive = Microsoft.Win32.Registry.CurrentConfig;
                        break;
                    case HIVE.HKEY_DYN_DATA:
                        //RegHive = Microsoft.Win32.Registry.DynData;
                        break;
                    case HIVE.HKEY_PERFORMANCE_DATA:
                        RegHive = Microsoft.Win32.Registry.PerformanceData;
                        break;
                }
                if (null == (RegKey = RegHive.CreateSubKey(Key)))
                {
                    throw new Exception("Can't create subkey.");
                }
                RegKey.SetValue(Name, Data);
                RegKey.Close();
                RegKey = null;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// if registry data is already existed, it'll return read data. but when there is no data in specificated registry, write default data to registry
        /// </summary>
        /// <param name="RegistryHIVE">Windows registry Hive archive</param>
        /// <param name="Key">Registry Key</param>
        /// <param name="Name">Registry Name</param>
        /// <param name="Data">Registry Data</param>
        /// <returns>object if operation is succeed, inserted object in other case</returns>
        public static object TryRead(HIVE RegistryHIVE, String Key, String Name, object Data)
        {
            try
            {
                object obj = null;
                if (null != (obj = Read(RegistryHIVE, Key, Name)))
                {
                    return obj;
                }
                else
                {
                    Write(RegistryHIVE, Key, Name, Data);
                    return Data;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Read data from registry
        /// </summary>
        /// <param name="RegistryHIVE">Windows registry Hive archive</param>
        /// <param name="Key">Registry Key</param>
        /// <param name="Name">Registry Name</param>
        /// <param name="Data">Registry Data</param>
        /// <returns>object if operation is succeed, null in other case</returns>
        public static object Read(HIVE RegistryHIVE, String Key, String Name)
        {
            try
            {
                Microsoft.Win32.RegistryKey RegHive = null;
                Microsoft.Win32.RegistryKey RegKey = null;

                switch (RegistryHIVE)
                {
                    case HIVE.HKEY_CLASSES_ROOT:
                        RegHive = Microsoft.Win32.Registry.ClassesRoot;
                        break;
                    case HIVE.HKEY_CURRENT_USER:
                        RegHive = Microsoft.Win32.Registry.CurrentUser;
                        break;
                    case HIVE.HKEY_LOCAL_MACHINE:
                        RegHive = Microsoft.Win32.Registry.LocalMachine;
                        break;
                    case HIVE.HKEY_USERS:
                        RegHive = Microsoft.Win32.Registry.Users;
                        break;
                    case HIVE.HKEY_CURRENT_CONFIG:
                        RegHive = Microsoft.Win32.Registry.CurrentConfig;
                        break;
                    case HIVE.HKEY_DYN_DATA:
                        //RegHive = Microsoft.Win32.Registry.DynData;
                        break;
                    case HIVE.HKEY_PERFORMANCE_DATA:
                        RegHive = Microsoft.Win32.Registry.PerformanceData;
                        break;
                }
                if (null == (RegKey = RegHive.OpenSubKey(Key)))
                {
                    throw new Exception("Can't open subkey.");
                }
                object obj = RegKey.GetValue(Name);
                RegKey.Close();
                RegKey = null;
                return obj;
            }
            catch
            {
                throw;
            }
        }

        public static String[] ReadValueNames(HIVE RegistryHIVE, String Key)
        {
            try
            {
                Microsoft.Win32.RegistryKey RegHive = null;
                Microsoft.Win32.RegistryKey RegKey = null;

                switch (RegistryHIVE)
                {
                    case HIVE.HKEY_CLASSES_ROOT:
                        RegHive = Microsoft.Win32.Registry.ClassesRoot;
                        break;
                    case HIVE.HKEY_CURRENT_USER:
                        RegHive = Microsoft.Win32.Registry.CurrentUser;
                        break;
                    case HIVE.HKEY_LOCAL_MACHINE:
                        RegHive = Microsoft.Win32.Registry.LocalMachine;
                        break;
                    case HIVE.HKEY_USERS:
                        RegHive = Microsoft.Win32.Registry.Users;
                        break;
                    case HIVE.HKEY_CURRENT_CONFIG:
                        RegHive = Microsoft.Win32.Registry.CurrentConfig;
                        break;
                    case HIVE.HKEY_DYN_DATA:
                        //RegHive = Microsoft.Win32.Registry.DynData;
                        break;
                    case HIVE.HKEY_PERFORMANCE_DATA:
                        RegHive = Microsoft.Win32.Registry.PerformanceData;
                        break;
                }

                if (null == (RegKey = RegHive.OpenSubKey(Key)))
                {
                    throw new Exception("Can't open subkey.");
                }
                String[] strValueNames = RegKey.GetValueNames();
                RegKey.Close();
                RegKey = null;
                return strValueNames;
            }
            catch
            {
                throw;
            }
        }
    }
}
