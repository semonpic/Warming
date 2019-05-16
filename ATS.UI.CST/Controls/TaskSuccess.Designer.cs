namespace ATS.UI.CST.Controls
{
    partial class TaskSuccess
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelAlarm2 = new System.Windows.Forms.Label();
            this.labelAlarmInfomation = new System.Windows.Forms.Label();
            this.labelAlarm1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.LightBlue;
            this.buttonOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonOK.FlatAppearance.BorderSize = 0;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonOK.Location = new System.Drawing.Point(510, 219);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(5);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(200, 60);
            this.buttonOK.TabIndex = 102;
            this.buttonOK.Text = "Cancel";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelAlarm2
            // 
            this.labelAlarm2.AutoSize = true;
            this.labelAlarm2.Font = new System.Drawing.Font("微軟正黑體", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelAlarm2.ForeColor = System.Drawing.Color.LightGray;
            this.labelAlarm2.Location = new System.Drawing.Point(9, 166);
            this.labelAlarm2.Name = "labelAlarm2";
            this.labelAlarm2.Size = new System.Drawing.Size(469, 120);
            this.labelAlarm2.TabIndex = 99;
            this.labelAlarm2.Text = "TaskOver";
            // 
            // labelAlarmInfomation
            // 
            this.labelAlarmInfomation.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelAlarmInfomation.ForeColor = System.Drawing.Color.Black;
            this.labelAlarmInfomation.Location = new System.Drawing.Point(47, 100);
            this.labelAlarmInfomation.Name = "labelAlarmInfomation";
            this.labelAlarmInfomation.Size = new System.Drawing.Size(524, 153);
            this.labelAlarmInfomation.TabIndex = 101;
            this.labelAlarmInfomation.Text = "已完成作業";
            // 
            // labelAlarm1
            // 
            this.labelAlarm1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelAlarm1.ForeColor = System.Drawing.Color.Black;
            this.labelAlarm1.Location = new System.Drawing.Point(-3, 54);
            this.labelAlarm1.Name = "labelAlarm1";
            this.labelAlarm1.Size = new System.Drawing.Size(210, 36);
            this.labelAlarm1.TabIndex = 100;
            this.labelAlarm1.Text = "Success";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 32);
            this.panel1.TabIndex = 98;
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.Black;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTitle.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(705, 32);
            this.labelTitle.TabIndex = 83;
            this.labelTitle.Text = "WarmSuccess";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Brown;
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(705, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(42, 32);
            this.buttonClose.TabIndex = 82;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Visible = false;
            // 
            // TaskSuccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelAlarm2);
            this.Controls.Add(this.labelAlarmInfomation);
            this.Controls.Add(this.labelAlarm1);
            this.Controls.Add(this.panel1);
            this.Name = "TaskSuccess";
            this.Size = new System.Drawing.Size(741, 292);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelAlarm2;
        private System.Windows.Forms.Label labelAlarmInfomation;
        private System.Windows.Forms.Label labelAlarm1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonClose;
    }
}
