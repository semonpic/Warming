namespace ATS.UI.CST.Controls
{
	partial class StatusBar
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusBar));
			this.labelVer = new System.Windows.Forms.Label();
			this.labelDateTime = new System.Windows.Forms.Label();
			this.buttonMin = new System.Windows.Forms.Button();
			this.buttonScreenshot = new System.Windows.Forms.Button();
			this.labelFps = new System.Windows.Forms.Label();
			this.labelLog = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelVer
			// 
			this.labelVer.Dock = System.Windows.Forms.DockStyle.Left;
			this.labelVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.labelVer.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelVer.ForeColor = System.Drawing.Color.White;
			this.labelVer.Location = new System.Drawing.Point(0, 0);
			this.labelVer.Margin = new System.Windows.Forms.Padding(0);
			this.labelVer.Name = "labelVer";
			this.labelVer.Size = new System.Drawing.Size(300, 32);
			this.labelVer.TabIndex = 0;
			this.labelVer.Text = "Ver";
			this.labelVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelVer.Click += new System.EventHandler(this.labelVer_Click);
			// 
			// labelDateTime
			// 
			this.labelDateTime.Dock = System.Windows.Forms.DockStyle.Right;
			this.labelDateTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.labelDateTime.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelDateTime.ForeColor = System.Drawing.Color.White;
			this.labelDateTime.Location = new System.Drawing.Point(1700, 0);
			this.labelDateTime.Margin = new System.Windows.Forms.Padding(0);
			this.labelDateTime.Name = "labelDateTime";
			this.labelDateTime.Size = new System.Drawing.Size(220, 32);
			this.labelDateTime.TabIndex = 1;
			this.labelDateTime.Text = "yyyy/MM/dd hh:mm:ss";
			this.labelDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// buttonMin
			// 
			this.buttonMin.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonMin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.buttonMin.FlatAppearance.BorderSize = 0;
			this.buttonMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonMin.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonMin.ForeColor = System.Drawing.Color.White;
			this.buttonMin.Image = global::ATS.UI.CST.Properties.Resources.Icon_Minimize;
			this.buttonMin.Location = new System.Drawing.Point(1636, 0);
			this.buttonMin.Name = "buttonMin";
			this.buttonMin.Size = new System.Drawing.Size(32, 32);
			this.buttonMin.TabIndex = 3;
			this.buttonMin.UseVisualStyleBackColor = false;
			this.buttonMin.Click += new System.EventHandler(this.buttonMin_Click);
			// 
			// buttonScreenshot
			// 
			this.buttonScreenshot.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonScreenshot.BackgroundImage")));
			this.buttonScreenshot.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonScreenshot.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.buttonScreenshot.FlatAppearance.BorderSize = 0;
			this.buttonScreenshot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonScreenshot.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonScreenshot.ForeColor = System.Drawing.Color.White;
			this.buttonScreenshot.Location = new System.Drawing.Point(1668, 0);
			this.buttonScreenshot.Name = "buttonScreenshot";
			this.buttonScreenshot.Size = new System.Drawing.Size(32, 32);
			this.buttonScreenshot.TabIndex = 2;
			this.buttonScreenshot.UseVisualStyleBackColor = false;
			this.buttonScreenshot.Click += new System.EventHandler(this.buttonScreenshot_Click);
			// 
			// labelFps
			// 
			this.labelFps.Dock = System.Windows.Forms.DockStyle.Right;
			this.labelFps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.labelFps.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelFps.ForeColor = System.Drawing.Color.White;
			this.labelFps.Location = new System.Drawing.Point(1556, 0);
			this.labelFps.Margin = new System.Windows.Forms.Padding(0);
			this.labelFps.Name = "labelFps";
			this.labelFps.Size = new System.Drawing.Size(80, 32);
			this.labelFps.TabIndex = 5;
			this.labelFps.Text = "0000";
			this.labelFps.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelLog
			// 
			this.labelLog.Dock = System.Windows.Forms.DockStyle.Left;
			this.labelLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.labelLog.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelLog.ForeColor = System.Drawing.Color.White;
			this.labelLog.Location = new System.Drawing.Point(300, 0);
			this.labelLog.Margin = new System.Windows.Forms.Padding(0);
			this.labelLog.Name = "labelLog";
			this.labelLog.Size = new System.Drawing.Size(1153, 32);
			this.labelLog.TabIndex = 6;
			this.labelLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// StatusBar
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.Controls.Add(this.labelLog);
			this.Controls.Add(this.labelFps);
			this.Controls.Add(this.buttonMin);
			this.Controls.Add(this.buttonScreenshot);
			this.Controls.Add(this.labelDateTime);
			this.Controls.Add(this.labelVer);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "StatusBar";
			this.Size = new System.Drawing.Size(1920, 32);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label labelVer;
		private System.Windows.Forms.Label labelDateTime;
		private System.Windows.Forms.Button buttonScreenshot;
		private System.Windows.Forms.Button buttonMin;
		private System.Windows.Forms.Label labelFps;
		private System.Windows.Forms.Label labelLog;
	}
}
