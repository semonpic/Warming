namespace ATS.UI.CST.Controls
{
	partial class LogTabPanel
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
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogTabPanel));
            this.listView = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.buttonAdd10 = new System.Windows.Forms.Button();
            this.buttonSub10 = new System.Windows.Forms.Button();
            this.buttonSub100 = new System.Windows.Forms.Button();
            this.buttonAdd100 = new System.Windows.Forms.Button();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(4, 3);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(1407, 674);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "black.png");
            this.imageList.Images.SetKeyName(1, "blue.png");
            // 
            // buttonAdd10
            // 
            this.buttonAdd10.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonAdd10.Location = new System.Drawing.Point(1417, 391);
            this.buttonAdd10.Name = "buttonAdd10";
            this.buttonAdd10.Size = new System.Drawing.Size(140, 140);
            this.buttonAdd10.TabIndex = 2;
            this.buttonAdd10.Text = "+10";
            this.buttonAdd10.UseVisualStyleBackColor = true;
            this.buttonAdd10.Click += new System.EventHandler(this.buttonAdd10_Click);
            // 
            // buttonSub10
            // 
            this.buttonSub10.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonSub10.Location = new System.Drawing.Point(1417, 149);
            this.buttonSub10.Name = "buttonSub10";
            this.buttonSub10.Size = new System.Drawing.Size(140, 140);
            this.buttonSub10.TabIndex = 3;
            this.buttonSub10.Text = "-10";
            this.buttonSub10.UseVisualStyleBackColor = true;
            this.buttonSub10.Click += new System.EventHandler(this.buttonSub10_Click);
            // 
            // buttonSub100
            // 
            this.buttonSub100.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonSub100.Location = new System.Drawing.Point(1417, 3);
            this.buttonSub100.Name = "buttonSub100";
            this.buttonSub100.Size = new System.Drawing.Size(140, 140);
            this.buttonSub100.TabIndex = 4;
            this.buttonSub100.Text = "▲";
            this.buttonSub100.UseVisualStyleBackColor = true;
            this.buttonSub100.Click += new System.EventHandler(this.buttonSub100_Click);
            // 
            // buttonAdd100
            // 
            this.buttonAdd100.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonAdd100.Location = new System.Drawing.Point(1417, 537);
            this.buttonAdd100.Name = "buttonAdd100";
            this.buttonAdd100.Size = new System.Drawing.Size(140, 140);
            this.buttonAdd100.TabIndex = 5;
            this.buttonAdd100.Text = "+100";
            this.buttonAdd100.UseVisualStyleBackColor = true;
            this.buttonAdd100.Click += new System.EventHandler(this.buttonAdd100_Click);
            // 
            // labelFrom
            // 
            this.labelFrom.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelFrom.Location = new System.Drawing.Point(1417, 292);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(139, 30);
            this.labelFrom.TabIndex = 6;
            this.labelFrom.Text = "0000";
            this.labelFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTo
            // 
            this.labelTo.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelTo.Location = new System.Drawing.Point(1417, 356);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(139, 30);
            this.labelTo.TabIndex = 7;
            this.labelTo.Text = "0000";
            this.labelTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(1417, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 30);
            this.label3.TabIndex = 8;
            this.label3.Text = "~";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogTabPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonAdd100);
            this.Controls.Add(this.buttonSub100);
            this.Controls.Add(this.buttonSub10);
            this.Controls.Add(this.buttonAdd10);
            this.Controls.Add(this.listView);
            this.Name = "LogTabPanel";
            this.Size = new System.Drawing.Size(1560, 680);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Button buttonAdd10;
		private System.Windows.Forms.Button buttonSub10;
		private System.Windows.Forms.Button buttonSub100;
		private System.Windows.Forms.Button buttonAdd100;
		private System.Windows.Forms.Label labelFrom;
		private System.Windows.Forms.Label labelTo;
		private System.Windows.Forms.Label label3;
	}
}
