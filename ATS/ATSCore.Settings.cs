using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Events;
using WiseTech.Log;
using WiseTech;
using ATS.Data;
using ATS.Models;

namespace ATS
{
	public partial class ATSCore
	{
		public bool View1Enable
		{
			set
			{
				Properties.Settings.Default.View1Enable = value;
				Properties.Settings.Default.Save();
				Logger.Log(ATSData.SystemLog, UserData.Instance.Now.Name + "將View1Enable變更為：" + Properties.Settings.Default.View1Enable);
			}
			get { return Properties.Settings.Default.View1Enable; }
		}
		public bool View2Enable
		{
			set
			{
				Properties.Settings.Default.View2Enable = value;
				Properties.Settings.Default.Save();
				Logger.Log(ATSData.SystemLog, UserData.Instance.Now.Name + "將View2Enable變更為：" + Properties.Settings.Default.View2Enable);
			}
			get { return Properties.Settings.Default.View2Enable; }
		}
		public bool CycleRun
		{
			set
			{
				Properties.Settings.Default.CycleRun = value;
				Properties.Settings.Default.Save();
				Logger.Log(ATSData.SystemLog, UserData.Instance.Now.Name + "將CycleRun變更為：" + Properties.Settings.Default.CycleRun);
			}
			get { return Properties.Settings.Default.CycleRun; }
		}
		public bool CheckSum
		{
			set
			{
				Properties.Settings.Default.Checksum = value;
				Properties.Settings.Default.Save();
				Logger.Log(ATSData.SystemLog, UserData.Instance.Now.Name + "將CheckSum變更為：" + Properties.Settings.Default.Checksum);
			}
			get { return Properties.Settings.Default.Checksum; }
		}
		public float Align1
		{
			set
			{
				Properties.Settings.Default.Align1 = value;
				Properties.Settings.Default.Save();
				Logger.Log(ATSData.SystemLog, UserData.Instance.Now.Name + "將Align1變更為：" + Properties.Settings.Default.Align1);
			}
			get { return Properties.Settings.Default.Align1; }
		}
		public float Align2
		{
			set
			{
				Properties.Settings.Default.Align2 = value;
				Properties.Settings.Default.Save();
				Logger.Log(ATSData.SystemLog, UserData.Instance.Now.Name + "將Align2變更為：" + Properties.Settings.Default.Align2);
			}
			get { return Properties.Settings.Default.Align2; }
		}

		public int VacuumOffDelay
		{
			set
			{
				Properties.Settings.Default.VacuumOffDelay = value;
				Properties.Settings.Default.Save();
				Logger.Log(ATSData.SystemLog, UserData.Instance.Now.Name + "將VacuumOffDelay變更為：" + Properties.Settings.Default.VacuumOffDelay);
			}
			get { return Properties.Settings.Default.VacuumOffDelay; }
		}
		public int PinUpDelay
		{
			set
			{
				Properties.Settings.Default.PinUpDelay = value;
				Properties.Settings.Default.Save();
				Logger.Log(ATSData.SystemLog, UserData.Instance.Now.Name + "將PinUpDelay變更為：" + Properties.Settings.Default.PinUpDelay);
			}
			get { return Properties.Settings.Default.PinUpDelay; }
		}
		public bool ClampUse
		{
			set
			{
				Properties.Settings.Default.ClampUse = value;
				Properties.Settings.Default.Save();
				Logger.Log(ATSData.SystemLog, UserData.Instance.Now.Name + "將ClampUse變更為：" + Properties.Settings.Default.ClampUse);
			}
			get { return Properties.Settings.Default.ClampUse; }
		}
		public bool SafetyDoor
		{
			set
			{
				Properties.Settings.Default.SafetyDoor = value;
				Properties.Settings.Default.Save();
				Logger.Log(ATSData.SystemLog, UserData.Instance.Now.Name + "將SafetyDoor變更為：" + Properties.Settings.Default.SafetyDoor);
			}
			get { return Properties.Settings.Default.SafetyDoor; }
		}
		public string Data1Path
		{
			set
			{
				Properties.Settings.Default.Data1Path = value;
				Properties.Settings.Default.Save();
				Logger.Log(ATSData.SystemLog, UserData.Instance.Now.Name + "將Data1Path變更為：" + Properties.Settings.Default.Data1Path);
			}
			get { return Properties.Settings.Default.Data1Path; }
		}
		public string Data2Path
		{
			set
			{
				Properties.Settings.Default.Data2Path = value;
				Properties.Settings.Default.Save();
				Logger.Log(ATSData.SystemLog, UserData.Instance.Now.Name + "將Data2Path變更為：" + Properties.Settings.Default.Data2Path);
			}
			get { return Properties.Settings.Default.Data2Path; }
		}
		public int InspectionTimeLimit
		{
			set
			{
				Properties.Settings.Default.InspectionTimeLimit = value;
				Properties.Settings.Default.Save();
				Logger.Log(ATSData.SystemLog, UserData.Instance.Now.Name + "將InspectionTimeLimit變更為：" + Properties.Settings.Default.InspectionTimeLimit);
			}
			get { return Properties.Settings.Default.InspectionTimeLimit; }
		}
	}
}
