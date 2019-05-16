using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Devices;

namespace ATS.Data
{
	public static class DeviceManager
	{
		public const string ALIGNER = "Aligner";
		public const string LOADPORT_1 = "Loadport1";
		public const string LOADPORT_2 = "Loadport2";
		public const string VIEW_1 = "View1";
		public const string VIEW_2 = "VIew2";
		public const string DATAMATRIXREADER = "DataMatrixReader";
		public const string OCRREADER = "OCRReader";
		
		public static Dictionary<string, bool> Empty = new Dictionary<string, bool>
		{
			{ALIGNER,true },
			{LOADPORT_1,true },
			{LOADPORT_2,true },
			{VIEW_1,true },
			{VIEW_2,true },
		};
		public static Dictionary<string, bool> WaittingForRobot = new Dictionary<string, bool>
		{
			{ALIGNER,false },
			{LOADPORT_1,false },
			{LOADPORT_2,false },
			{VIEW_1,false },
			{VIEW_2,false },
		};

		public static bool GetWaitForRobot(string deviceName)
		{
			if (WaittingForRobot.ContainsKey(deviceName))
			{
				return WaittingForRobot[deviceName];
			}
			else
			{
				throw new Exception("Device Name Error");
			}
		}
		public static void SetWaitForRobot(string deviceName, bool status)
		{
			if (WaittingForRobot.ContainsKey(deviceName))
			{
				WaittingForRobot[deviceName] = status;
			}
			else
			{
				throw new Exception("Device Name Error");
			}

		}
	}
}
