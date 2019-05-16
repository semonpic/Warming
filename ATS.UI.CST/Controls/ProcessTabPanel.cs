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
	public partial class ProcessTabPanel : UserControl
	{
		public ProcessTabPanel()
		{
			InitializeComponent();
			if (AppData.IsRuntime)
			{
				Load += ProcessTabPanel_Load;
			}
		}

		private void ProcessTabPanel_Load(object sender, EventArgs e)
		{
			loadPortStatus1.Text = "LoadPort 1";
			loadPortStatus2.Text = "LoadPort 2";
			int i = 1;
			foreach (var item in loadPortStatus1.Slots)
			{
				item.Text = "Slot" + i.ToString();
				i++;
			}
			i = 1;
			foreach (var item in loadPortStatus2.Slots)
			{
				item.Text = "Slot" + i.ToString();
				i++;
			}

		}
	}
}
