using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Events;
using WiseTech;
using WiseTech.Log;

namespace ATS.Data
{
	public static class AlarmManager
	{
		public static event EventHandler AlarmReset;

		public static event EventHandler<AlarmEventArgs> ViewInspectionTimeoutAlarm;//View量測Timeout需重啟

		public static event EventHandler<AlarmEventArgs> ViewSoapAlarm;//拔片Alarm
		public static event EventHandler<AlarmEventArgs> RobotDeviceAlarm;//拔片Alarm
		public static event EventHandler<AlarmEventArgs> DeviceAlarm;//拔片Alarm
		public static event EventHandler<AlarmEventArgs> MappingAlarm;//拔片Alarm
		public static event EventHandler<AlarmEventArgs> ViewPresentAlarm;//View Present 拔片Alarm
		public static event EventHandler<AlarmEventArgs> AlignerPresentAlarm;//Aligner Present 拔片Alarm
		public static event EventHandler<AlarmEventArgs> RobotPresentAlarm;//Robot Present 拔片Alarm
		public static event EventHandler<AlarmEventArgs> LoadportUnloadAlarm;//Loadport 關門警報
		public static event EventHandler<AlarmEventArgs> StaticElectricityBarAlarm;//靜電棒警報
		public static event EventHandler<AlarmEventArgs> SafetyDoorAlarm;//安全門/維修門警報
		public static event EventHandler<AlarmEventArgs> AirPositiveNegativeAlarm;//正負壓警報

		public static event EventHandler<AlarmEventArgs> ChuckPositionErrorAlarm;//Chuck 夾爪不在取放位

		public static event EventHandler<AlarmEventArgs> HaveToResetAlarm;//需要 重新初始化
		
		public static event EventHandler<AlarmEventArgs> LoadportRfidFail;
		public static event EventHandler<AlarmEventArgs> ReaderWaferIDFail;
		public static event EventHandler<AlarmEventArgs> AlignFailRemove;
		public static event EventHandler<AlarmEventArgs> RobotGetPutErrorRemove;//取放動作失敗

		public static event EventHandler<AlarmEventArgs> ConnectionErrorAlarm;//斷線警告

		private const string alarmPrefix = "Alarm.";

		//設備類型
		public const string SYSTEM = "System";
		public const string ALIGNER = "Aligner";
		public const string VIEW = "View";
		public const string ROBOT = "Robot";
		public const string LOADPORT = "Loadport";

		public const string ConnectionError = alarmPrefix + "ConnectionError";

		public const string ViewInspectionTimeout = alarmPrefix + "ViewInspectionTimeout";

		public const string ChuckPositionError = alarmPrefix + "ChuckPositionErrorAlarm";
		public const string HaveToReset = alarmPrefix + "HaveToResetAlarm";

		public const string ViewChuckLockFail = alarmPrefix + "ViewChuckLockFail";


		public const string View1StartInspectionFail = alarmPrefix + "View1StartInspectionFail";
		public const string View2StartInspectionFail = alarmPrefix + "View2StartInspectionFail";

		public const string View1ChuckVacuumOnFail = alarmPrefix + "View1ChuckVacuumOnFail";
		public const string View1ChuckPositiveFail = alarmPrefix + "View1ChuckPositiveFail";
		public const string View1ChuckPinUpFail = alarmPrefix + "View1ChuckPinUpFail";
		public const string View1ChuckPinDownFail = alarmPrefix + "View1ChuckPinDownFail";
		public const string View1ChuckClampOnFail = alarmPrefix + "View1ChuckClampOnFail";
		public const string View1ChuckClampOffFail = alarmPrefix + "View1ChuckClampOffFail";
		public const string View1ChuckLockFail = alarmPrefix + "View1ChuckLockFail";
		public const string View1ChuckUnlockFail = alarmPrefix + "View1ChuckUnlockFail";

		public const string View2ChuckVacuumOnFail = alarmPrefix + "View2ChuckVacuumOnFail";
		public const string View2ChuckPositiveFail = alarmPrefix + "View2ChuckPositiveFail";
		public const string View2ChuckPinUpFail = alarmPrefix + "View2ChuckPinUpFail";
		public const string View2ChuckPinDownFail = alarmPrefix + "View2ChuckPinDownFail";
		public const string View2ChuckClampOnFail = alarmPrefix + "View2ChuckClampOnFail";
		public const string View2ChuckClampOffFail = alarmPrefix + "View2ChuckClampOffFail";
		public const string View2ChuckLockFail = alarmPrefix + "View2ChuckLockFail";
		public const string View2ChuckUnlockFail = alarmPrefix + "View2ChuckUnlockFail";

		public const string AlignerFail = alarmPrefix + "AlignerFail";

		public const string AlignerPresentNotMatch = alarmPrefix + "AlignerPresentNotMatch";
		public const string ViewPresentNotMatch = alarmPrefix + "ViewPresentNotMatch";
		public const string RobotPresentNotMatch = alarmPrefix + "RobotPresentNotMatch";
		public const string LoadportUnloadFail = alarmPrefix + "LoadportUnloadFail";
		public const string StaticElectricityBarStoped = alarmPrefix + "StaticElectricityBarStoped";
		public const string SafetyDoorOpenClose = alarmPrefix + "SafetyDoorOpenClose";
		
		public const string AirPositiveNegative = alarmPrefix + "AirPositiveNegative";//總正壓/總負壓異常

		public const string Loadport1RfidFail = alarmPrefix + "Loadport1RfidFail";
		public const string Loadport2RfidFail = alarmPrefix + "Loadport2RfidFail";
		public const string WaferIDFail = alarmPrefix + "WaferIDFail";
		public const string RobotGetPutError = alarmPrefix + "RobotGetPutError";

		public const string EmergencyStop = alarmPrefix + "EmergencyStop";

		public const string RobotDeviceAlarmStop = alarmPrefix + "RobotDeviceAlarmStop";
		public const string DeviceAlarmStop = alarmPrefix + "DeviceAlarmStop";
		public const string MappingAlarmStop = alarmPrefix + "MappingAlarmStop";
		public const string ViewSoapAlarmNoStop = alarmPrefix + "ViewSoapAlarmNoStop";

		
		private static Dictionary<string, Alarm> alarms = new Dictionary<string, Alarm>();

		public static bool IsAlarm
		{
			get
			{
				return (alarms.Count > 0);
			}
		}
		public static int AlarmCount { get { return alarms.Count; } }

		//異常狀態重新檢查是否恢復
		public static void ResetAlarm()
		{
			var alarmkeys = new List<string>(alarms.Keys);

			//錯誤全清
			foreach (var item in alarmkeys)
			{
				Console.WriteLine("清除Alarm" + item);
				RemoveAlarm(item);
			}
		}

		public static void AddAlarm(object alarmDevice, string name, string device, string message, bool Warning = false)
		{
			if (!alarms.ContainsKey(name))
			{
				if (!Warning)
				{
					ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Error;					
				}

				var alarm = new Alarm(name);
				alarms.Add(name, alarm);
				Logger.Log(ATSData.AlarmLog, "Alarm: " + name + ", " + device + ": " + message);
				try
				{
					//觸發Alarm事件
					switch (name)
					{
						case SafetyDoorOpenClose:
							SafetyDoorAlarm.Invoke(alarm, new AlarmEventArgs());
							break;
						default:
							break;
					}
				}
				catch (Exception)
				{
					throw;
				}

			}
		}
		public static void RemoveAlarm(string name)
		{
			if (alarms.ContainsKey(name))
			{
				alarms.Remove(name);
				Logger.Log(ATSData.AlarmLog, "Alarm Reset: " + name);
				if (!IsAlarm)
				{
					if (ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Error)
					{
						ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Pause;
					}
					AlarmReset.Invoke(typeof(AlarmManager), new EventArgs());
				}
			}
		}
	}
}
