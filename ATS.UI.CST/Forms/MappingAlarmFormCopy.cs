using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATS.Data;
using ATS.Devices;
using WiseTech;

namespace ATS.UI.CST.Forms
{
	public partial class MappingAlarmForm : AlarmForm
	{
		private Timer timer = new Timer();
		private string deviceName = "";
		private LoadportLogicHandler loadport;
		public MappingAlarmForm(object device)
		{
			this.loadport = (device as LoadportLogicHandler);

			InitializeComponent();

			SetAlarmInfomation("Mapping異常:" + "Loadport " + loadport.ID);

			SetAlarmSolution(deviceName + "異常 請確認Mapping狀態");

			OnOKClick += MappingAlarmForm_OnOKClick;
			timer.Interval = 1000;
			timer.Tick += Timer_Tick;
			timer.Start();
			FormClosing += AlignFailRemoveForm_FormClosing;
		}

		private void AlignFailRemoveForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			timer.Tick -= Timer_Tick;
			OnOKClick += MappingAlarmForm_OnOKClick;
			FormClosing -= AlignFailRemoveForm_FormClosing;
		}

		private void MappingAlarmForm_OnOKClick(object sender, EventArgs e)
		{
			timer.Tick -= Timer_Tick;
			var loadportLogicHandler = loadport;

			AlarmManager.RemoveAlarm(AlarmManager.MappingAlarmStop);
			loadportLogicHandler.Transition(loadportLogicHandler.LoadOut);
			Close();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			timer.Stop();
						
			var mappingString = "Mapping:" + Environment.NewLine;
			foreach (var item in WaferManager.LoadportWafers(loadport.ID))
			{
				var wafer = item.Value;
				mappingString += "Slot " + wafer.SlotNo + " : " + Enum.GetName(typeof(WaferManager.SlotStatusType), wafer.SlotStatus) + Environment.NewLine;
			}
			SetAlarmStatus(mappingString);

			timer.Start();
		}
	}
}
