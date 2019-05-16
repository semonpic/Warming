using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiseTech;
using ATS.Models;

namespace ATS.UI.CST.Forms
{
    public partial class WeightHistory : UserFormBase
    {
        public WeightHistory()
        {
            InitializeComponent();
            Load += WeightHistory_Load;
            Language.SetText("WeightHistory.Title", "WeightHistory", "磅秤記錄歷史");
        }
        private void WeightHistory_Load(object Sender, EventArgs e)
        {
            SetTitle(Language.Text("WeightHistory.Title"));
            DataTable Dt = GetWeightHistory();
            DGWeightHistory.DataSource = Dt;
            DGWeightHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            
        }


        private List<UserData.WeightInfo> GetWeightHistoryInfo()
        {
            return UserData.Instance.GetWeightHistory();
        }

        private DataTable GetWeightHistory()
        {
            return UserData.Instance.GetWeightHistoryDatatable();
        }
    }
}
