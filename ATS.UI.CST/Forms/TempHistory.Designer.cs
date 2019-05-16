namespace ATS.UI.CST.Forms
{
    partial class TempHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.BtnSelect = new System.Windows.Forms.Button();
            this.chartCold = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartWarm = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TempColdTitle = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.TempWarmTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartCold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartWarm)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // DatePicker
            // 
            this.DatePicker.CalendarFont = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DatePicker.CalendarTitleBackColor = System.Drawing.Color.AliceBlue;
            this.DatePicker.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.DatePicker.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DatePicker.Location = new System.Drawing.Point(46, 52);
            this.DatePicker.MaximumSize = new System.Drawing.Size(200, 40);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(175, 33);
            this.DatePicker.TabIndex = 86;
            // 
            // BtnSelect
            // 
            this.BtnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSelect.Location = new System.Drawing.Point(258, 49);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(74, 36);
            this.BtnSelect.TabIndex = 87;
            this.BtnSelect.Text = "查詢";
            this.BtnSelect.UseVisualStyleBackColor = true;
            this.BtnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // chartCold
            // 
            chartArea1.AxisX.CustomLabels.Add(customLabel1);
            chartArea1.AxisX2.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.Maximum = 10D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chartCold.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartCold.Legends.Add(legend1);
            this.chartCold.Location = new System.Drawing.Point(3, 39);
            this.chartCold.Name = "chartCold";
            this.chartCold.Size = new System.Drawing.Size(818, 311);
            this.chartCold.TabIndex = 88;
            this.chartCold.Text = "chart1";
            // 
            // chartWarm
            // 
            chartArea2.AxisY.Maximum = 28D;
            chartArea2.AxisY.Minimum = 23D;
            chartArea2.Name = "ChartArea1";
            this.chartWarm.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartWarm.Legends.Add(legend2);
            this.chartWarm.Location = new System.Drawing.Point(3, 39);
            this.chartWarm.Name = "chartWarm";
            this.chartWarm.Size = new System.Drawing.Size(819, 309);
            this.chartWarm.TabIndex = 89;
            this.chartWarm.Text = "chart1";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.TempColdTitle);
            this.panel5.Controls.Add(this.chartCold);
            this.panel5.Location = new System.Drawing.Point(5, 102);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(826, 355);
            this.panel5.TabIndex = 90;
            // 
            // TempColdTitle
            // 
            this.TempColdTitle.BackColor = System.Drawing.Color.Black;
            this.TempColdTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.TempColdTitle.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TempColdTitle.ForeColor = System.Drawing.Color.White;
            this.TempColdTitle.Location = new System.Drawing.Point(0, 0);
            this.TempColdTitle.Name = "TempColdTitle";
            this.TempColdTitle.Size = new System.Drawing.Size(824, 36);
            this.TempColdTitle.TabIndex = 10;
            this.TempColdTitle.Text = "冷藏區溫度紀錄";
            this.TempColdTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.TempWarmTitle);
            this.panel6.Controls.Add(this.chartWarm);
            this.panel6.Location = new System.Drawing.Point(5, 463);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(826, 355);
            this.panel6.TabIndex = 91;
            // 
            // TempWarmTitle
            // 
            this.TempWarmTitle.BackColor = System.Drawing.Color.Black;
            this.TempWarmTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.TempWarmTitle.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TempWarmTitle.ForeColor = System.Drawing.Color.White;
            this.TempWarmTitle.Location = new System.Drawing.Point(0, 0);
            this.TempWarmTitle.Name = "TempWarmTitle";
            this.TempWarmTitle.Size = new System.Drawing.Size(824, 36);
            this.TempWarmTitle.TabIndex = 10;
            this.TempWarmTitle.Text = "回溫區溫度紀錄";
            this.TempWarmTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TempHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 824);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.BtnSelect);
            this.Controls.Add(this.DatePicker);
            this.Name = "TempHistory";
            this.Text = "TempHistory";
            this.TopMost = false;
            this.Controls.SetChildIndex(this.DatePicker, 0);
            this.Controls.SetChildIndex(this.BtnSelect, 0);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.panel6, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chartCold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartWarm)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DatePicker;
        private System.Windows.Forms.Button BtnSelect;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCold;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartWarm;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label TempColdTitle;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label TempWarmTitle;
    }
}