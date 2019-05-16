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
	public partial class CycleRunSwitch : UserControl
	{
		public CycleRunSwitch()
		{
			InitializeComponent();
			CSTForm.OnAnimationUpdate += CSTForm_OnAnimationUpdate;
		}

		private void CSTForm_OnAnimationUpdate(object sender, EventArgs e)
		{
			ThreadSafeHelper.UIThread(this, () =>
			{
				var isCycleRun = ATSCore.Instance.CycleRun;
				buttonCycleRunOn.BackColor = isCycleRun ? Color.LightBlue : Color.DimGray;
				buttonCycleRunOff.BackColor = isCycleRun ? Color.DimGray : Color.LightBlue;
			});
		}
		
		private void buttonCycleRunOn_Click(object sender, EventArgs e)
		{
			switch (ATSData.SystemMode)
			{
				case ATSData.SystemModeType.Maintain:
					ATSCore.Instance.CycleRun = true;
					break;
				default:
					MessageBox.Show("Maintain模式才可調整CycleRun設定");
					break;
			}
		}

		private void buttonCycleRunOff_Click(object sender, EventArgs e)
		{
			switch (ATSData.SystemMode)
			{
				case ATSData.SystemModeType.Maintain:
					ATSCore.Instance.CycleRun = false;
					break;
				default:
					MessageBox.Show("Maintain模式才可調整CycleRun設定");
					break;
			}
		}
	}
}
