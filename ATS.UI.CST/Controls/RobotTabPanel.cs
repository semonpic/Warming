using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATS.Devices;

namespace ATS.UI.CST.Controls
{
	public partial class RobotTabPanel : UserControl
	{
		public RobotTabPanel()
		{
			InitializeComponent();
		}

		private void buttonRetract_Click(object sender, EventArgs e)
		{
			try
			{
				ATSCore.Instance.Robot.Command(RobotLogicHandler.UICommandType.Retract);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void buttonSHome_Click(object sender, EventArgs e)
		{
			try
			{
				ATSCore.Instance.Robot.Command(RobotLogicHandler.UICommandType.SliderHome);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void buttonReset_Click(object sender, EventArgs e)
		{
			try
			{
				ATSCore.Instance.Robot.Command(RobotLogicHandler.UICommandType.ResetAndHome);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}

		}
	}
}
