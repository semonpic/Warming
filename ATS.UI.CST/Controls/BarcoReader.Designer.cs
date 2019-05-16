namespace ATS.UI.CST.Controls
{
    partial class BarcoReader
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.BarcoText = new System.Windows.Forms.TextBox();
            this.LblBarcoLable = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnConfirm = new System.Windows.Forms.Button();
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
            this.labelTitle.Size = new System.Drawing.Size(1003, 36);
            this.labelTitle.TabIndex = 10;
            this.labelTitle.Text = "輸入條碼";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BarcoText
            // 
            this.BarcoText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BarcoText.Font = new System.Drawing.Font("微軟正黑體", 20F, System.Drawing.FontStyle.Bold);
            this.BarcoText.Location = new System.Drawing.Point(178, 64);
            this.BarcoText.Name = "BarcoText";
            this.BarcoText.Size = new System.Drawing.Size(660, 43);
            this.BarcoText.TabIndex = 11;
            this.BarcoText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LblBarcoLable
            // 
            this.LblBarcoLable.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LblBarcoLable.Location = new System.Drawing.Point(50, 71);
            this.LblBarcoLable.Name = "LblBarcoLable";
            this.LblBarcoLable.Size = new System.Drawing.Size(124, 37);
            this.LblBarcoLable.TabIndex = 12;
            this.LblBarcoLable.Text = "條碼編號 :";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnCancel.ForeColor = System.Drawing.Color.Black;
            this.BtnCancel.Location = new System.Drawing.Point(858, 132);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(120, 43);
            this.BtnCancel.TabIndex = 14;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnConfirm.ForeColor = System.Drawing.Color.Black;
            this.BtnConfirm.Location = new System.Drawing.Point(698, 132);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(120, 43);
            this.BtnConfirm.TabIndex = 13;
            this.BtnConfirm.Text = "確認";
            this.BtnConfirm.UseVisualStyleBackColor = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // BarcoReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnConfirm);
            this.Controls.Add(this.LblBarcoLable);
            this.Controls.Add(this.BarcoText);
            this.Controls.Add(this.labelTitle);
            this.Name = "BarcoReader";
            this.Size = new System.Drawing.Size(1003, 187);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox BarcoText;
        private System.Windows.Forms.Label LblBarcoLable;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnConfirm;
    }
}
