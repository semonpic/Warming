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
using ATS;

namespace ATS
{
	public partial class ATSCore
	{

		public enum UICommandType
		{
			Init,
			None,
		}

		public bool End { get { return coreEnd && safetyCoreEnd; } }
		private bool exit = false;
		private bool coreEnd = false;
		private bool safetyCoreEnd = false;
		private static ATSCore instance = new ATSCore();//單例模式;
		public static ATSCore Instance
		{
			get
			{
				return instance;
			}
		}
		
		private ATSCore()
		{

		}
	}
}
