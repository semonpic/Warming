using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATS.Data;
using WiseTech;

namespace ATS
{
	public static class ATSData
	{
		public static event EventHandler OnAutomaticModeStatusChenged;
		public static event EventHandler OnSecsGemModeStatusChenged;

		public static string SystemLog = "SystemLog";
		public static string ViewLog = "ViewLog";
		public static string RobotLog = "RobotLog";
		public static string LoadportLog = "LoadportLog";
		public static string AlignerLog = "AlignerLog";
		public static string RunLog = "RunLog"; 
		public static string SecsLog = "SecsLog";
		public static string AlarmLog = "AlarmLog";
		public static string ProductLog = "ProductLog";


		public static bool Startup = false;
		public static bool WaferSortAsc = true;
		public static bool ResetOK = false;

		public static bool EmergencyEtop = false;


		public enum SystemModeType { Handmode, Automatic, Maintain }
		public static SystemModeType RequestSystemMode = SystemModeType.Maintain;
		public static SystemModeType SystemMode= SystemModeType.Handmode;

        public enum SystemTaskMode { Incold,Inwarm,Outwarm}
        public static SystemTaskMode TaskMode = SystemTaskMode.Incold;

        public enum MaintainModeStatusType { Init, Idle, Busy, Error }
		public static MaintainModeStatusType MaintainModeStatus = MaintainModeStatusType.Init;
		//手動模式只有分 動作中或不是動作中

		public enum AutomaticModeStatusType { Reset, Pause, Run, Stop, Error }
		public static AutomaticModeStatusType AutomaticModeStatus
		{
			get { return automaticModeStatus; }
			set
			{
				if (value != automaticModeStatus)
				{
					automaticModeStatus = value;
                    if (OnAutomaticModeStatusChenged != null)
                    {
                        OnAutomaticModeStatusChenged.Invoke(typeof(ATSData), new EventArgs());
                    }
                }
					
			}
		}
		private static AutomaticModeStatusType automaticModeStatus = AutomaticModeStatusType.Stop;
		//自動模式分為 閒置、暫停、動作中、停止

		public enum SecsGemModeStatusType { Idle, Ready, Running, InTrouble, Offline }
		public static SecsGemModeStatusType SecsGemModeStatus {
			get { return secsGemModeStatus; }
			set {
				if (value != secsGemModeStatus)
				{
                    secsGemModeStatus = value; 
                    if (OnSecsGemModeStatusChenged != null)
                    {
                        OnSecsGemModeStatusChenged.Invoke(typeof(ATSData), new EventArgs());
                    }
				}
			} }
		public static SecsGemModeStatusType secsGemModeStatus = SecsGemModeStatusType.Offline;
		//IDLE	1	閒置狀態等待選擇recipe
		//READY	2	已選擇recipe等待接收執行程序
		//RUNNING	3	程序執行中
		//IN TROUBLE	4	當出現錯誤時，當錯誤恢復後將回到IDLE或RUNNING
		//OFFLINE	5	作業人員從人機介面切換為Offline模式

		public enum TransportModeType { MixedMode, View1Mode, View2Mode }
		public static TransportModeType RequestTransportMode = TransportModeType.View1Mode;
		public static TransportModeType TransportMode = TransportModeType.View1Mode;


		public static string TabsString = "Main,Mode,Log,Maintain,IO,Settings,Manage";
		public static string ResultFolder = "Result";

		public static bool Resetting;
	}
}
