namespace ATS.UI.CST.Controls
{
	partial class RobotTabPanel
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
			this.buttonRetract = new System.Windows.Forms.Button();
			this.buttonSHome = new System.Windows.Forms.Button();
			this.buttonReset = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonRetract
			// 
			this.buttonRetract.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonRetract.Location = new System.Drawing.Point(4, 4);
			this.buttonRetract.Margin = new System.Windows.Forms.Padding(4);
			this.buttonRetract.Name = "buttonRetract";
			this.buttonRetract.Size = new System.Drawing.Size(211, 80);
			this.buttonRetract.TabIndex = 20;
			this.buttonRetract.Text = "Robot Retract";
			this.buttonRetract.UseVisualStyleBackColor = true;
			this.buttonRetract.Click += new System.EventHandler(this.buttonRetract_Click);
			// 
			// buttonSHome
			// 
			this.buttonSHome.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonSHome.Location = new System.Drawing.Point(4, 91);
			this.buttonSHome.Name = "buttonSHome";
			this.buttonSHome.Size = new System.Drawing.Size(211, 80);
			this.buttonSHome.TabIndex = 76;
			this.buttonSHome.Text = "Slider Home";
			this.buttonSHome.UseVisualStyleBackColor = true;
			this.buttonSHome.Click += new System.EventHandler(this.buttonSHome_Click);
			// 
			// buttonReset
			// 
			this.buttonReset.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonReset.Location = new System.Drawing.Point(4, 178);
			this.buttonReset.Margin = new System.Windows.Forms.Padding(4);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(211, 80);
			this.buttonReset.TabIndex = 21;
			this.buttonReset.Text = "Reset";
			this.buttonReset.UseVisualStyleBackColor = true;
			this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
			// 
			// RobotTabPanel
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.buttonSHome);
			this.Controls.Add(this.buttonReset);
			this.Controls.Add(this.buttonRetract);
			this.Name = "RobotTabPanel";
			this.Size = new System.Drawing.Size(1560, 680);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button buttonRetract;
		private System.Windows.Forms.Button buttonSHome;
		private System.Windows.Forms.Button buttonReset;
	}
}
