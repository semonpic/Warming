namespace ATS.UI.CST.Controls
{
    partial class TaskNumberSelect
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
            this.label1 = new System.Windows.Forms.Label();
            this.CBNumberSelect = new System.Windows.Forms.ComboBox();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.LbInformation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.Black;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(474, 36);
            this.labelTitle.TabIndex = 11;
            this.labelTitle.Text = "此次作業數量選擇";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(42, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 44);
            this.label1.TabIndex = 12;
            this.label1.Text = "此次數量選擇:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CBNumberSelect
            // 
            this.CBNumberSelect.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CBNumberSelect.FormattingEnabled = true;
            this.CBNumberSelect.Location = new System.Drawing.Point(243, 114);
            this.CBNumberSelect.Name = "CBNumberSelect";
            this.CBNumberSelect.Size = new System.Drawing.Size(192, 39);
            this.CBNumberSelect.TabIndex = 13;
            // 
            // BtnClose
            // 
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnClose.Location = new System.Drawing.Point(266, 237);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(170, 66);
            this.BtnClose.TabIndex = 14;
            this.BtnClose.Text = "Cancle";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.BtnStart.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStart.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnStart.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnStart.Location = new System.Drawing.Point(48, 237);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(170, 66);
            this.BtnStart.TabIndex = 15;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = false;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label8.Location = new System.Drawing.Point(57, 142);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(229, 26);
            this.label8.TabIndex = 16;
            this.label8.Text = "選擇此次作業瓶數(瓶)";
            // 
            // LbInformation
            // 
            this.LbInformation.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LbInformation.Location = new System.Drawing.Point(15, 193);
            this.LbInformation.Name = "LbInformation";
            this.LbInformation.Size = new System.Drawing.Size(456, 28);
            this.LbInformation.TabIndex = 17;
            // 
            // TaskNumberSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.LbInformation);
            this.Controls.Add(this.CBNumberSelect);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTitle);
            this.Name = "TaskNumberSelect";
            this.Size = new System.Drawing.Size(474, 342);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBNumberSelect;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LbInformation;
    }
}
