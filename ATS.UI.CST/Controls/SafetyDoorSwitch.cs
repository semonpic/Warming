using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiseTech;

namespace ATS.UI.CST.Controls
{
	public partial class SafetyDoorSwitch : UserControl
	{
		public SafetyDoorSwitch()
		{
			InitializeComponent();
			CSTForm.OnAnimationUpdate += CSTForm_OnAnimationUpdate;
		}

		private void CSTForm_OnAnimationUpdate(object sender, EventArgs e)
		{
			ThreadSafeHelper.UIThread(this, () =>
			{
				var isSafetyDoor = ATSCore.Instance.SafetyDoor;
				buttonSafetyDoorEnable.BackColor = isSafetyDoor ? Color.LightBlue : Color.DimGray;
				buttonSafetyDoorDisable.BackColor = isSafetyDoor ? Color.DimGray : Color.LightBlue;
			});
		}
		
		private void buttonSafetyDoorEnable_Click(object sender, EventArgs e)
		{

			switch (ATSData.SystemMode)
			{
				case ATSData.SystemModeType.Maintain:
					ATSCore.Instance.SafetyDoor = true;
					break;
				default:
					MessageBox.Show("Maintain模式才可調整SafetyDoor設定");
					break;
			}
		}

		private void buttonSafetyDoorDisable_Click(object sender, EventArgs e)
		{

			switch (ATSData.SystemMode)
			{
				case ATSData.SystemModeType.Maintain:
					ATSCore.Instance.SafetyDoor = false;
					break;
				default:
					MessageBox.Show("Maintain模式才可調整SafetyDoor設定");
					break;
			}
		}
	}
}
