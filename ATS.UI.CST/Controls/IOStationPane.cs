using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATS.UI.CST.Controls
{
    public partial class IOStationPanel : UserControl
    {
        public IOStationPanel()
        {
            InitializeComponent();
            IOListView1.View = View.Details;
            IOListView1.FullRowSelect = true;
            IOListView1.Columns.Add("No", 60, HorizontalAlignment.Center);
            IOListView1.Columns.Add("State", 60, HorizontalAlignment.Center);
            IOListView1.Columns.Add("Location", 100, HorizontalAlignment.Left);
            IOListView1.Columns.Add("Message", 100, HorizontalAlignment.Left);

            IOListView2.View = View.Details;
            IOListView2.FullRowSelect = true;
            IOListView2.Columns.Add("No", 60, HorizontalAlignment.Center);
            IOListView2.Columns.Add("State", 60, HorizontalAlignment.Center);
            IOListView2.Columns.Add("Location", 100, HorizontalAlignment.Left);
            IOListView2.Columns.Add("Message", 100, HorizontalAlignment.Left);


        }
    }
}
