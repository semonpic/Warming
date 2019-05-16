using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Data;
using WiseTech.Log;

namespace ATS
{
	//用於Maintain模式，UI 向 ATSCore 下指令時使用
	public static partial class ATSCoreCommander
	{
		public static bool IsAllowControl
		{
			get
			{
				return (ATSData.SystemMode == ATSData.SystemModeType.Maintain);
			}
		}
		public static bool Busy { get { return busy; } private set { busy = value; } }
		private static bool busy = false;
	}
}
