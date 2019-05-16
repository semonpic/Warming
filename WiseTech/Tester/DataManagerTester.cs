using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiseTech.Data;

namespace WiseTech.Tester
{
	public partial class DataManagerTester : Form
	{
		private DataManager DM = DataManager.Instance;
		public DataManagerTester()
		{
			InitializeComponent();

		}

		private void DataManagerTester_Load(object sender, EventArgs e)
		{

			DM = DM.Setup(AppData.exePath);
			Task.Run(() =>
			{
				for (int i = 0; i < 1000; i++)
				{
					DM.Save(i.ToString(), "456");
				}
				DM.SaveApply();
				for (int j = 0; j < 1000; j++)
				{
					DM.Save(j.ToString(), "456");
				}
				DM.SaveApply();
				for (int k = 0; k < 1000; k++)
				{
					DM.Save(k.ToString(), "456");
				}
				DM.SaveApply();
				Console.WriteLine("Finish");
			});
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			try
			{
				DM.Save(textBoxKey.Text, textBoxValue.Text);
				DM.SaveApply();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		private void buttonLoad_Click(object sender, EventArgs e)
		{
			try
			{
				textBoxValue.Text = DM.Load(textBoxKey.Text);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		private void buttonTest_Click(object sender, EventArgs e)
		{
			try
			{
				DM.InitializeTable();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}

		}
	}
}
