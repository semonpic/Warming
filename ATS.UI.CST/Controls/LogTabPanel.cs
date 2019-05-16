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
using WiseTech.Log;

namespace ATS.UI.CST.Controls
{
    public partial class LogTabPanel : UserControl
    {
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public string LogType
        {
            get { return logType; }
            set { logType = value; }
        }
        private string logType = "ATSCore";
        private int from = 0;
        private int limit = 20;
        private bool inited = false;
        public LogTabPanel()
        {
            InitializeComponent();

            listView.View = View.Details;
            listView.FullRowSelect = true;
            listView.Columns.Add("No", 80, HorizontalAlignment.Center);
            listView.Columns.Add("DateTime", 320, HorizontalAlignment.Left);
            listView.Columns.Add("Message", 1000, HorizontalAlignment.Left);



            if (AppData.IsRuntime)
            {
                Load += RunLogTabPanel_Load;
            }
        }

        private void RunLogTabPanel_Load(object sender, EventArgs e)
        {
            InitListViewItems();
        }

        private void InitListViewItems()
        {

            labelFrom.Text = from.ToString("0000");
            labelTo.Text = (from + limit).ToString("0000");
            if (LogType != "ProductLog")
            {

                var list = Logger.Select(LogType, from, limit);

                listView.BeginUpdate();

                //ListView中的每個Log內容
                listView.Items.Clear();
                var index = 0;
                foreach (var item in list)
                {
                    var newItem = new ListViewItem(new string[] {
                    (from + index++).ToString("0000"),
                    item.LogDateTime.ToString(),
                    item.LogData.ToString(),
                });

                    listView.Items.Add(newItem);
                }

                listView.EndUpdate();

                Refresh();

                inited = true;
            }
            else
            {
                listView.Columns.Clear();
                listView.View = View.Details;
                listView.FullRowSelect = true;
                listView.Columns.Add("No", 80, HorizontalAlignment.Center);
                listView.Columns.Add("Slot", 100, HorizontalAlignment.Center);
                listView.Columns.Add("DateTime", 320, HorizontalAlignment.Left);
                listView.Columns.Add("Message", 1000, HorizontalAlignment.Left);


                var list = Logger.SelectResin(LogType, from, limit);
                listView.BeginUpdate();
                listView.Items.Clear();
                var index = 0;
                foreach (var item in list)
                {
                    var newItem = new ListViewItem(new string[] {
                    (from + index++).ToString("0000"),
                    item.SlotID.ToString(),
                    item.IncoldTime.ToString(),
                    item.InColdOperator
                });
                    listView.Items.Add(newItem);
                }

                listView.EndUpdate();

                Refresh();

                inited = true;
            }
        
    
		}
		private void RefreshListViewItems()
		{
			if (!inited)
			{
				InitListViewItems();
			}
			labelFrom.Text = from.ToString("0000");
			labelTo.Text = (from + limit).ToString("0000");

			var logs = Logger.Select(LogType, from, limit);

			var i = 0;
			foreach (var log in logs)
			{
				var listViewItem = listView.Items[i];
				listViewItem.SubItems[0].Text = (from + i++).ToString("0000");
				listViewItem.SubItems[1].Text = log.LogDateTime.ToString();
				listViewItem.SubItems[2].Text = log.LogData.ToString();
			}
		}
		private void buttonSub10_Click(object sender, EventArgs e)
		{
			from = from >= 10 ? from - 10 : from;
			RefreshListViewItems();
		}

		private void buttonSub100_Click(object sender, EventArgs e)
		{
			//from = from >= 100 ? from - 100 : from;
			from = 0;
			RefreshListViewItems();
		}

		private void buttonAdd10_Click(object sender, EventArgs e)
		{
			from += 10;
			RefreshListViewItems();
		}

		private void buttonAdd100_Click(object sender, EventArgs e)
		{
			from += 100;
			RefreshListViewItems();
		}
	}
}
