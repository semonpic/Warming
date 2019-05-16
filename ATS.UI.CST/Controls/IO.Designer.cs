namespace ATS.UI.CST.Controls
{
    partial class IO
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.LbIoName = new System.Windows.Forms.Label();
            this.PbIoOnOff = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbIoOnOff)).BeginInit();
            this.SuspendLayout();
            // 
            // LbIoName
            // 
            this.LbIoName.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LbIoName.Location = new System.Drawing.Point(0, 0);
            this.LbIoName.Name = "LbIoName";
            this.LbIoName.Size = new System.Drawing.Size(169, 34);
            this.LbIoName.TabIndex = 0;
            this.LbIoName.Text = "LbIoName";
            this.LbIoName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LbIoName.Click += new System.EventHandler(this.LbIoName_Click);
            // 
            // PbIoOnOff
            // 
            this.PbIoOnOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PbIoOnOff.Image = global::ATS.UI.CST.Properties.Resources.IOon;
            this.PbIoOnOff.Location = new System.Drawing.Point(167, -2);
            this.PbIoOnOff.Name = "PbIoOnOff";
            this.PbIoOnOff.Size = new System.Drawing.Size(48, 32);
            this.PbIoOnOff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbIoOnOff.TabIndex = 1;
            this.PbIoOnOff.TabStop = false;
            // 
            // IO
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.PbIoOnOff);
            this.Controls.Add(this.LbIoName);
            this.Name = "IO";
            this.Size = new System.Drawing.Size(218, 34);
            this.Load += new System.EventHandler(this.IO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbIoOnOff)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LbIoName;
        private System.Windows.Forms.PictureBox PbIoOnOff;
    }
}
