namespace ATS.UI.CST.Controls
{
    partial class IOStationPanel
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
            this.IOListView2 = new System.Windows.Forms.ListView();
            this.IOListView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // IOListView2
            // 
            this.IOListView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IOListView2.Location = new System.Drawing.Point(0, 347);
            this.IOListView2.MultiSelect = false;
            this.IOListView2.Name = "IOListView2";
            this.IOListView1.Location = new System.Drawing.Point(4, 3);
            this.IOListView2.Size = new System.Drawing.Size(1360, 333);
            this.IOListView2.TabIndex = 1;
            this.IOListView2.UseCompatibleStateImageBehavior = false;
            this.IOListView2.View = System.Windows.Forms.View.Details;
            // 
            // IOListView1
            // 
            this.IOListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IOListView1.Location = new System.Drawing.Point(0, 0);
            this.IOListView1.MultiSelect = false;
            this.IOListView1.Name = "IOListView1";
            this.IOListView1.Size = new System.Drawing.Size(1360, 348);
            this.IOListView1.TabIndex = 0;
            this.IOListView1.UseCompatibleStateImageBehavior = false;
            this.IOListView1.View = System.Windows.Forms.View.Details;
            // 
            // IOStationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.IOListView2);
            this.Controls.Add(this.IOListView1);
            this.Name = "IOStationPanel";
            this.Size = new System.Drawing.Size(1560, 680);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView IOListView2;
        private System.Windows.Forms.ListView IOListView1;
    }
}
