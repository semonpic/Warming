namespace ATS.UI.CST.Controls
{
    partial class AlarmInformation
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelAlarm2 = new System.Windows.Forms.Label();
            this.TbInfo = new System.Windows.Forms.TextBox();
            this.BtnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.Black;
            this.labelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(1108, 36);
            this.labelTitle.TabIndex = 11;
            this.labelTitle.Text = "錯誤訊息";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAlarm2
            // 
            this.labelAlarm2.AutoSize = true;
            this.labelAlarm2.Font = new System.Drawing.Font("微軟正黑體", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelAlarm2.ForeColor = System.Drawing.Color.LightGray;
            this.labelAlarm2.Location = new System.Drawing.Point(23, 550);
            this.labelAlarm2.Name = "labelAlarm2";
            this.labelAlarm2.Size = new System.Drawing.Size(855, 120);
            this.labelAlarm2.TabIndex = 100;
            this.labelAlarm2.Text = "AlarmInformation";
            // 
            // TbInfo
            // 
            this.TbInfo.BackColor = System.Drawing.SystemColors.Control;
            this.TbInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbInfo.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TbInfo.Location = new System.Drawing.Point(29, 70);
            this.TbInfo.Multiline = true;
            this.TbInfo.Name = "TbInfo";
            this.TbInfo.ReadOnly = true;
            this.TbInfo.Size = new System.Drawing.Size(1059, 477);
            this.TbInfo.TabIndex = 101;
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.Color.Transparent;
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnClose.Location = new System.Drawing.Point(896, 578);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(192, 74);
            this.BtnClose.TabIndex = 102;
            this.BtnClose.Text = "關閉";
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // AlarmInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.TbInfo);
            this.Controls.Add(this.labelAlarm2);
            this.Controls.Add(this.labelTitle);
            this.Name = "AlarmInformation";
            this.Size = new System.Drawing.Size(1108, 708);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelAlarm2;
        private System.Windows.Forms.TextBox TbInfo;
        private System.Windows.Forms.Button BtnClose;
    }
}
