using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseTech.Log
{
	public class LogMessage
	{
		public string LogDateTime = "";
		public string LogData = "";
	}

    public class LogResinMessage
    {
        public string SlotID = "";
        public string ExpiredTime = "";
        public string ColdLocation = "";
        public string IncoldTime = "";
        public string InColdOperator = "";
        public string WarmLocation = "";
        public string InWarmTime = "";
        public string InWarmOperator = "";
        public string TotalWeight = "";
        public string EmptyWeight = "";
        public string WarmedTime = "";
        public string OutWarmOperator = "";
    }
}
