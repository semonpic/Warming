using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATS.UI.CST.Forms;
using WiseTech;

namespace ATS.UI.CST
{
	public static class FormManager
	{
		public static bool IsResetFormOpen = false;
		

		public static bool SafetyDoorAlarmFormOpen = false;
		internal static void OpenSafetyDoorAlarmForm(Control ui, object data)
		{
			if (!SafetyDoorAlarmFormOpen)
			{
				SafetyDoorAlarmFormOpen = true;
				ThreadSafeHelper.UIThread(ui, () =>
				{
					var form = new SafetyDoorAlarmForm();
					form.Show();
					form.FormClosing += (sender,e)=> { SafetyDoorAlarmFormOpen = false; };
				});
			}
		}
		
	}
}
