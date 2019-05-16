using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATS.UI.CST.Forms
{
	public partial class SafetyDoorAlarmForm : UserFormBase
	{
		protected event EventHandler OnOKClick;
		public SafetyDoorAlarmForm()
		{
			InitializeComponent();
			Load += AlarmForm_Load;

		}


		private void AlarmForm_Load(object sender, EventArgs e)
		{
			SetTitle("Alarm");
		}
		protected void SetAlarmInfomation(string text)
		{
			labelAlarmInfomation.Text = text;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			//if (IO.In(IO.IN_SAFETY_DOOR_B) && IO.In(IO.IN_MAINTAIN_DOOR_B))
			//{
				Close();
			//}
		}
	}
}
