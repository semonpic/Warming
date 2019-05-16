using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseTech;

namespace ATS.Data
{
	public class Alarm
	{
		public string Name { get { return name; } }
		private string name = "alarm";

		public bool IsSet { get { return isSet; } }
		private bool isSet = false;

		public string Message { get { return Language.Text(name); } }

		public Alarm(string name)
		{
			this.name = name;
		}


	}
}
