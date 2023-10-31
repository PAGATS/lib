using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CH.IO.Comm
{
    public class AS5216Enum
    {
        public const string IntegrationTime = "IntegrationTime";
        public const string IntegrationDelay = "IntegrationDelay";
        public const string NumberOfAverage = "NumberOfAverage";
        public const string DynamicDarkCorrection = "DynamicDarkCorrection";
        public const string Smoothing = "Smoothing";
        public const string SaturationDetection = "SaturationDetection";
        public const string TriggerType = "TriggerType";
        public const string DisplayChart = "DisplayChart";
        public const string TopMost = "TopMost";
        public const string Close = "Close";
        public const string IOCTRL = "IOCTRL";
    }

    public class AS5216Command : MarshalByRefObject
    {
        private static Queue<string> g_qCommand = new Queue<string>();

        public string Command
        {
            set
            {
                try
                {
                    g_qCommand.Enqueue(value);
                }
                catch
                {
                    throw;
                }
            }

            get
            {
                try
                {
                    if (0 < g_qCommand.Count)
                        return g_qCommand.Dequeue();
                    else
                        return "";
                }
                catch
                {
                    throw;
                }
            }
        }

        public int Count
        {
            get
            {
                try
                {
                    return g_qCommand.Count;
                }
                catch
                {
                    throw;
                }
            }
        }
    }

    public class AS5216Response : MarshalByRefObject
    {
        private static Queue<string> g_qResponse = new Queue<string>();
        private static bool g_bIsRun = false;

        public bool IsRun
        {
            set
            {
                try
                {
                    g_bIsRun = value;
                }
                catch (System.Exception ex)
                {
                    throw;
                }
            }

            get
            {
                try
                {
                    return g_bIsRun;
                }
                catch (System.Exception ex)
                {
                    throw;
                }
            }
        }

        public string Response
        {
            set
            {
                try
                {
                    g_qResponse.Enqueue(value);
                }
                catch
                {
                    throw;
                }
            }

            get
            {
                try
                {
                    if (0 < g_qResponse.Count)
                        return g_qResponse.Dequeue();
                    else
                        return "";
                }
                catch
                {
                    throw;
                }
            }
        }

        public int Count
        {
            get
            {
                try
                {
                    return g_qResponse.Count;
                }
                catch
                {
                    throw;
                }
            }
        }
    }

    public class AS5216Data : MarshalByRefObject
    {
        // Device Count
        private static int g_DeviceCount = 0;        

        // Data
        private static string[] g_SerialNumber;
        private static double[][] g_Spectrum;
        private static double[][] g_Wavelength;
        private static ushort[] g_NumPixels;

        // Invalidate flag
        private static bool g_TriggerMode = false;
        private static bool g_Invalidate = false;

        public bool TriggerMode
        {
            get
            {
                return g_TriggerMode;
            }

            set
            {
                g_TriggerMode = value;
            }
        }

        public bool Invalidate
        {
            get
            {
                return g_Invalidate;
            }

            set
            {
                g_Invalidate = value;
            }
        }

        public int DeviceCount
        {
            set 
            {
                g_DeviceCount = value;
            }

            get 
            {            
                return g_DeviceCount;
            }
        }

        public string[] SerialNumber
        {
            set
            {
                g_SerialNumber = value;
            }

            get
            {
                return g_SerialNumber;
            }
        }

        public double[][] Spectrum
        {
            set
            {
                if (true == g_Invalidate ||
                    false == g_TriggerMode)
                {
                    g_Spectrum = value;
                    g_Invalidate = false;
                }
            }

            get
            {
                return g_Spectrum;
            }
        }

        public double[][] Wavelength
        {
            set
            {
                g_Wavelength = value;
            }

            get
            {
                return g_Wavelength;
            }
        }

        public ushort[] NumPixels
        {
            set
            {
                g_NumPixels = value;
            }

            get
            {
                return g_NumPixels;
            }
        }
    }
}
