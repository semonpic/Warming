using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JackDataManager;
using WiseTech;
using System.Windows.Forms.DataVisualization.Charting;

namespace ATS.UI.CST.Forms
{
    public partial class TempHistory : UserFormBase
    {

        Cold C = new Cold();
        Warm W = new Warm();
        List<Double> ColdAverageList = new List<double>();
        List<Double> WarmAverageList = new List<double>();

        DataTable ColdDt = new DataTable();
        DataTable WarmDt = new DataTable();
        class Cold
        {
            internal List<double> Cold1 = new List<double>();
            internal List<double> Cold2 = new List<double>();
            internal List<double> Cold3 = new List<double>();
            internal List<double> Cold4 = new List<double>();
            internal List<double> Cold5 = new List<double>();
        }

        class Warm
        {
            internal List<double> Warm1 = new List<double>();
            internal List<double> Warm2 = new List<double>();
            internal List<double> Warm3 = new List<double>();
            internal List<double> Warm4 = new List<double>();
            internal List<double> Warm5 = new List<double>();
        }
        public TempHistory()
        {
            InitializeComponent();
            Language.Bind("TempHistory.TempColdTitle", TempColdTitle);
            Language.Bind("TempHistory.TempWarmTitle", TempWarmTitle);

            Language.SetText("TempHistory.Title", "TempHistory", "溫度紀錄");


            Load += TempHistory_Load;
        }

        void TempHistory_Load(object sender, EventArgs e)
        {
            DatePicker.Text = DateTime.Now.ToString();
            SetTitle(Language.Text("TempHistory.Title"));
            chartCold.Visible = false;
            chartWarm.Visible = false;
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            Read();
            return;
            #region OldVersion
            //C.Cold1.Clear();
            //C.Cold2.Clear();
            //C.Cold3.Clear();
            //C.Cold4.Clear();
            //C.Cold5.Clear();

            //W.Warm1.Clear();
            //W.Warm2.Clear();
            //W.Warm3.Clear();
            //W.Warm4.Clear();
            //W.Warm5.Clear();

            //try
            //{
            //    TempManager.SelectTemp(Convert.ToDateTime(DatePicker.Text));
            //}
            //catch (Exception err)
            //{
            //    chartCold.Visible = false;
            //    chartWarm.Visible = false;
            //    MessageBox.Show("選取日無資料");
            //    return;
            //}
                
            //List<TempManager.ColdTemp> ColdTempHistory = TempManager.ColdTempHistory;
            //List<TempManager.WarmTemp> WarmTempHistory = TempManager.WarmTempHistory;
            //ColdAverageList.Clear();
            //WarmAverageList.Clear();

            //double ColdAverage = 0;
            //double WarmAverage = 0;

            //try
            //{
            //    for (int i = 0; i < ColdTempHistory.Count; i++)
            //    {
            //        string[] Coldstr = ColdTempHistory[i].ColdReader1.Split('-');
            //        string[] Coldstr1 = ColdTempHistory[i].ColdReader2.Split('-');
            //        string[] Coldstr2 = ColdTempHistory[i].ColdReader3.Split('-');
            //        string[] Coldstr3 = ColdTempHistory[i].ColdReader4.Split('-');
            //        string[] Coldstr4 = ColdTempHistory[i].ColdReader5.Split('-');

            //        string[] Warmstr = WarmTempHistory[i].WarmReader1.Split('-');
            //        string[] Warmstr1 = WarmTempHistory[i].WarmReader2.Split('-');
            //        string[] Warmstr2 = WarmTempHistory[i].WarmReader3.Split('-');
            //        string[] Warmstr3 = WarmTempHistory[i].WarmReader4.Split('-');
            //        string[] Warmstr4 = WarmTempHistory[i].WarmReader5.Split('-');

            //        for (int j = 0; j < Coldstr.Length - 1; j++)
            //        {
            //            if (Coldstr[j] == "0" || Coldstr1[j] == "0" || Coldstr2[j] == "0" || Coldstr3[j] == "0" || Coldstr4[j] == "0")
            //            {
            //                continue;
            //            }
            //            else
            //            {
            //                C.Cold1.Add(double.Parse(Coldstr[j]) / 10);
            //                C.Cold2.Add(double.Parse(Coldstr1[j]) / 10);
            //                C.Cold3.Add(double.Parse(Coldstr2[j]) / 10);
            //                C.Cold4.Add(double.Parse(Coldstr3[j]) / 10);
            //                C.Cold5.Add(double.Parse(Coldstr4[j]) / 10);
            //                ColdAverage = double.Parse(Coldstr[j]) / 10 + double.Parse(Coldstr4[j]) / 10 + double.Parse(Coldstr1[j]) / 10 + double.Parse(Coldstr2[j]) / 10 + double.Parse(Coldstr3[j]) / 10;
            //            }

            //            ColdAverageList.Add(ColdAverage / 5);

            //            if (Warmstr[j] == "0" || Warmstr1[j] == "0" || Warmstr2[j] == "0" || Warmstr3[j] == "0" || Warmstr4[j] == "0")
            //            {
            //                continue;
            //            }
            //            else
            //            {
            //                W.Warm1.Add(double.Parse(Warmstr[j]) / 10);
            //                W.Warm2.Add(double.Parse(Warmstr1[j]) / 10);
            //                W.Warm3.Add(double.Parse(Warmstr2[j]) / 10);
            //                W.Warm4.Add(double.Parse(Warmstr3[j]) / 10);
            //                W.Warm5.Add(double.Parse(Warmstr4[j]) / 10);
            //                WarmAverage = double.Parse(Warmstr[j]) / 10 + double.Parse(Warmstr1[j]) / 10 + double.Parse(Warmstr2[j]) / 10 + double.Parse(Warmstr3[j]) / 10 + double.Parse(Warmstr4[j]) / 10;
            //            }

            //            WarmAverageList.Add(WarmAverage / 5);



            //        }
            //    }


            //    Show();
            //}
            //catch (Exception er)
            //{
            //    ATS.LCSCommon.WriteAppErrorLog(er.Message);
            //}
            #endregion
        }


        private void Show()
        {

            chartCold.Visible = true;
            chartWarm.Visible = true;
            chartCold.Series.Clear();
            chartWarm.Series.Clear();
            DataTableReader Dtr = ColdDt.CreateDataReader();
            chartCold.DataBindCrossTable(Dtr, "Cold", "Time", "ColdNum", "");
            chartCold.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chartCold.Series[0].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chartCold.Series[0].Name = "ColdTemp1";

            chartCold.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chartCold.Series[1].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chartCold.Series[1].Name = "ColdTemp2";

            chartCold.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chartCold.Series[2].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chartCold.Series[2].Name = "ColdTemp3";

            chartCold.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chartCold.Series[3].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chartCold.Series[3].Name = "ColdTemp4";

            chartCold.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chartCold.Series[4].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chartCold.Series[4].Name = "ColdTemp5";


            DataTableReader WarmDtr = WarmDt.CreateDataReader();
            chartWarm.DataBindCrossTable(WarmDtr, "Warm", "Time", "WarmNum", "");

            chartWarm.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chartWarm.Series[0].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chartWarm.Series[0].Name = "WarmTemp1";

            chartWarm.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chartWarm.Series[1].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chartWarm.Series[1].Name = "WarmTemp2";

            chartWarm.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chartWarm.Series[2].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chartWarm.Series[2].Name = "WarmTemp3";

            chartWarm.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chartWarm.Series[3].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chartWarm.Series[3].Name = "WarmTemp4";

            chartWarm.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chartWarm.Series[4].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chartWarm.Series[4].Name = "WarmTemp5";

        }


        public void Read()
        {




                ColdDt = new DataTable();
                DataColumn Dc1 = new DataColumn("Cold", Type.GetType("System.String"));
                DataColumn Dc2 = new DataColumn("ColdNum", Type.GetType("System.Double"));
                DataColumn Dc3 = new DataColumn("Order", Type.GetType("System.Int32"));
                DataColumn Dc4 = new DataColumn("Time", Type.GetType("System.String"));

                ColdDt.Columns.Add(Dc1);
                ColdDt.Columns.Add(Dc2);
                ColdDt.Columns.Add(Dc3);
                ColdDt.Columns.Add(Dc4);

                WarmDt = new DataTable();
                DataColumn WDc1 = new DataColumn("Warm", Type.GetType("System.String"));
                DataColumn WDc2 = new DataColumn("WarmNum", Type.GetType("System.Double"));
                DataColumn WDc3 = new DataColumn("Order", Type.GetType("System.Int32"));
                DataColumn WDc4 = new DataColumn("Time", Type.GetType("System.String"));

                WarmDt.Columns.Add(WDc1);
                WarmDt.Columns.Add(WDc2);
                WarmDt.Columns.Add(WDc3);
                WarmDt.Columns.Add(WDc4);


            try
            {
                TempManager.SelectTemp(Convert.ToDateTime(DatePicker.Text));
            }
            catch (Exception err)
            {
                chartCold.Visible = false;
                chartWarm.Visible = false;
                MessageBox.Show("選取日無資料");
                return;
            }

            List<TempManager.ColdTemp> ColdTempHistory = TempManager.ColdTempHistory;
            List<TempManager.WarmTemp> WarmTempHistory = TempManager.WarmTempHistory;
            int Index = 0;

            try
            {
                for (int i = 0; i < ColdTempHistory.Count; i++)
                {

   

                    string[] Coldstr = ColdTempHistory[i].ColdReader1.Split('-');
                    string[] Coldstr1 = ColdTempHistory[i].ColdReader2.Split('-');
                    string[] Coldstr2 = ColdTempHistory[i].ColdReader3.Split('-');
                    string[] Coldstr3 = ColdTempHistory[i].ColdReader4.Split('-');
                    string[] Coldstr4 = ColdTempHistory[i].ColdReader5.Split('-');

                    string[] Warmstr = WarmTempHistory[i].WarmReader1.Split('-');
                    string[] Warmstr1 = WarmTempHistory[i].WarmReader2.Split('-');
                    string[] Warmstr2 = WarmTempHistory[i].WarmReader3.Split('-');
                    string[] Warmstr3 = WarmTempHistory[i].WarmReader4.Split('-');
                    string[] Warmstr4 = WarmTempHistory[i].WarmReader5.Split('-');

                    for (int j = 0; j < Coldstr4.Length - 1; j++)
                    {
                        if (Index == 3514)
                        { }



                            if (Coldstr[j] == ""  || Coldstr1[j] == ""  || Coldstr2[j] == ""  || Coldstr3[j] == ""  || Coldstr4[j] == ""  )
                            { continue; }

                            else
                            {
                                DataRow Dr = ColdDt.NewRow();
                                Dr["ColdNum"] = double.Parse(Coldstr[j]) / 10;
                                Dr["Order"] = Index;
                                Dr["Cold"] = "Cold1";
                                Dr["Time"] = ColdTempHistory[i].Time;
                                ColdDt.Rows.Add(Dr);

                                Dr = ColdDt.NewRow();
                                Dr["ColdNum"] = double.Parse(Coldstr1[j]) / 10;
                                Dr["Order"] = Index;
                                Dr["Cold"] = "Cold2";
                                Dr["Time"] = ColdTempHistory[i].Time;
                                ColdDt.Rows.Add(Dr);

                                Dr = ColdDt.NewRow();
                                Dr["ColdNum"] = double.Parse(Coldstr2[j]) / 10;
                                Dr["Order"] = Index;
                                Dr["Cold"] = "Cold3";
                                Dr["Time"] = ColdTempHistory[i].Time;
                                ColdDt.Rows.Add(Dr);

                                Dr = ColdDt.NewRow();
                                Dr["ColdNum"] = double.Parse(Coldstr3[j]) / 10;
                                Dr["Order"] = Index;
                                Dr["Cold"] = "Cold4";
                                Dr["Time"] = ColdTempHistory[i].Time;
                                ColdDt.Rows.Add(Dr);


                                Dr = ColdDt.NewRow();
                                Dr["ColdNum"] = double.Parse(Coldstr4[j]) / 10;
                                Dr["Order"] = Index;
                                Dr["Cold"] = "Cold5";
                                Dr["Time"] = ColdTempHistory[i].Time;
                                ColdDt.Rows.Add(Dr);
                            
     
                        }


                            if (Warmstr[j] == "" ||Warmstr1[j] == "" ||Warmstr2[j] == "" ||Warmstr3[j] == "" ||Warmstr4[j] == ""  )
                            { continue; }

                            else
                            {

                                DataRow Dr = WarmDt.NewRow();
                                Dr["WarmNum"] = double.Parse(Warmstr[j]) / 10;
                                Dr["Order"] = Index;
                                Dr["Warm"] = "Warm1";
                                Dr["Time"] = WarmTempHistory[i].Time;
                                WarmDt.Rows.Add(Dr);


                                Dr = WarmDt.NewRow();
                                Dr["WarmNum"] = double.Parse(Warmstr1[j]) / 10;
                                Dr["Order"] = Index;
                                Dr["Warm"] = "Warm2";
                                Dr["Time"] = WarmTempHistory[i].Time;
                                WarmDt.Rows.Add(Dr);

                                Dr = WarmDt.NewRow();
                                Dr["WarmNum"] = double.Parse(Warmstr2[j]) / 10;
                                Dr["Order"] = Index;
                                Dr["Warm"] = "Warm3";
                                Dr["Time"] = WarmTempHistory[i].Time;
                                WarmDt.Rows.Add(Dr);

                                Dr = WarmDt.NewRow();
                                Dr["WarmNum"] = double.Parse(Warmstr3[j]) / 10;
                                Dr["Order"] = Index;
                                Dr["Warm"] = "Warm4";
                                Dr["Time"] = WarmTempHistory[i].Time;
                                WarmDt.Rows.Add(Dr);


                                Dr = WarmDt.NewRow();
                                Dr["WarmNum"] = double.Parse(Warmstr4[j]) / 10;
                                Dr["Order"] = Index;
                                Dr["Warm"] = "Warm5";
                                Dr["Time"] = WarmTempHistory[i].Time;
                                WarmDt.Rows.Add(Dr);
                            }
                        }

                        Index++;

                    
                }


                Show();
            }
            catch (Exception er)
            {
                ATS.LCSCommon.WriteAppErrorLog(er.Message);
            }


        }
    }
}
