using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATS.Models;
using WiseTech;

namespace ATS.UI.CST.Controls
{
	public partial class TransportPanel : UserControl
	{
		public TransportPanel()
		{
			InitializeComponent();
			if (AppData.IsRuntime)
			{
				Load += TransportPanel_Load;
				Language.OnRefreshed += Language_OnRefreshed;
				Language.Refresh();
			}
		}

		private void TransportPanel_Load(object sender, EventArgs e)
		{
		}

		private void Instance_OnTransportModeChenged(object sender, EventArgs e)
		{
			RefreshButtonText();
		}

		private void Language_OnRefreshed(object sender, EventArgs e)
		{
			RefreshButtonText();
		}

		private void buttonMixedMode_Click(object sender, EventArgs e)
		{
			if (ATSData.TransportMode == ATSData.TransportModeType.MixedMode)
			{
				return;
			}
			SwitchTransportMode(ATSData.TransportModeType.MixedMode);
		}
		private void buttonView1Mode_Click(object sender, EventArgs e)
		{
			if (ATSData.TransportMode == ATSData.TransportModeType.View1Mode)
			{
				return;
			}
			SwitchTransportMode(ATSData.TransportModeType.View1Mode);
		}
		private void buttonView2Mode_Click(object sender, EventArgs e)
		{
			if (ATSData.TransportMode == ATSData.TransportModeType.View2Mode)
			{
				return;
			}
			SwitchTransportMode(ATSData.TransportModeType.View2Mode);
		}
		private void SwitchTransportMode(ATSData.TransportModeType mode)
		{

			switch (ATSData.SystemMode)
			{
				case ATSData.SystemModeType.Maintain:
					LockButton();
					ATSData.RequestTransportMode = mode;
					break;
				default:
					MessageBox.Show("設備運轉中禁止手動切換模式", "設備運轉中禁止手動切換模式", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
			}
		}
		private void RefreshButtonText()
		{
			ThreadSafeHelper.UIThread(this, () =>
			{
				var defaultText = Language.Text("TransportPanel.Switch");
				var defaultColor = Color.WhiteSmoke;
				var selectedText = Language.Text("TransportPanel.Selected");
				var selectedColor = Color.LightBlue;

				buttonMixedMode.Text = defaultText;
				buttonView1Mode.Text = defaultText;
				buttonView2Mode.Text = defaultText;
				buttonMixedMode.BackColor = defaultColor;
				buttonView1Mode.BackColor = defaultColor;
				buttonView2Mode.BackColor = defaultColor;
				switch (ATSData.TransportMode)
				{
					case ATSData.TransportModeType.MixedMode:
						buttonMixedMode.Text = selectedText;
						buttonMixedMode.BackColor = selectedColor;
						break;
					case ATSData.TransportModeType.View1Mode:
						buttonView1Mode.Text = selectedText;
						buttonView1Mode.BackColor = selectedColor;
						break;
					case ATSData.TransportModeType.View2Mode:
						buttonView2Mode.Text = selectedText;
						buttonView2Mode.BackColor = selectedColor;
						break;
				}

				labelView1Mode.Text = Language.Text("TransportPanel.View1");
				labelView2Mode.Text = Language.Text("TransportPanel.View2");
				labelMixedMode.Text = Language.Text("TransportPanel.MixedMode");
				UnlockButton();
			});
		}
		private void LockButton()
		{
			buttonMixedMode.Enabled = false;
			buttonView1Mode.Enabled = false;
			buttonView2Mode.Enabled = false;
		}
		private void UnlockButton()
		{
			buttonMixedMode.Enabled = ATSCore.View1MachineEnable && ATSCore.View2MachineEnable;//實際有View1與View2
			buttonView1Mode.Enabled = ATSCore.View1MachineEnable;//實際有View1
			buttonView2Mode.Enabled = ATSCore.View2MachineEnable;//實際有View2
		}
	}
}
