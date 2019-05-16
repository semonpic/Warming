namespace ATS.UI.CST.Controls
{
	partial class CycleRunSwitch
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
			this.labelCycleRun = new System.Windows.Forms.Label();
			this.buttonCycleRunOn = new System.Windows.Forms.Button();
			this.buttonCycleRunOff = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelCycleRun
			// 
			this.labelCycleRun.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelCycleRun.BackColor = System.Drawing.Color.Black;
			this.labelCycleRun.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelCycleRun.ForeColor = System.Drawing.Color.White;
			this.labelCycleRun.Location = new System.Drawing.Point(0, 0);
			this.labelCycleRun.Margin = new System.Windows.Forms.Padding(0);
			this.labelCycleRun.Name = "labelCycleRun";
			this.labelCycleRun.Size = new System.Drawing.Size(300, 40);
			this.labelCycleRun.TabIndex = 1;
			this.labelCycleRun.Text = "CycleRun";
			this.labelCycleRun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonCycleRunOn
			// 
			this.buttonCycleRunOn.BackColor = System.Drawing.Color.LightBlue;
			this.buttonCycleRunOn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.buttonCycleRunOn.FlatAppearance.BorderSize = 0;
			this.buttonCycleRunOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCycleRunOn.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonCycleRunOn.Location = new System.Drawing.Point(0, 40);
			this.buttonCycleRunOn.Margin = new System.Windows.Forms.Padding(0);
			this.buttonCycleRunOn.Name = "buttonCycleRunOn";
			this.buttonCycleRunOn.Size = new System.Drawing.Size(150, 40);
			this.buttonCycleRunOn.TabIndex = 4;
			this.buttonCycleRunOn.Text = "On";
			this.buttonCycleRunOn.UseVisualStyleBackColor = false;
			this.buttonCycleRunOn.Click += new System.EventHandler(this.buttonCycleRunOn_Click);
			// 
			// buttonCycleRunOff
			// 
			this.buttonCycleRunOff.BackColor = System.Drawing.Color.DimGray;
			this.buttonCycleRunOff.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.buttonCycleRunOff.FlatAppearance.BorderSize = 0;
			this.buttonCycleRunOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCycleRunOff.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonCycleRunOff.Location = new System.Drawing.Point(150, 40);
			this.buttonCycleRunOff.Margin = new System.Windows.Forms.Padding(0);
			this.buttonCycleRunOff.Name = "buttonCycleRunOff";
			this.buttonCycleRunOff.Size = new System.Drawing.Size(150, 40);
			this.buttonCycleRunOff.TabIndex = 5;
			this.buttonCycleRunOff.Text = "Off";
			this.buttonCycleRunOff.UseVisualStyleBackColor = false;
			this.buttonCycleRunOff.Click += new System.EventHandler(this.buttonCycleRunOff_Click);
			// 
			// CycleRunSwitch
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.buttonCycleRunOff);
			this.Controls.Add(this.buttonCycleRunOn);
			this.Controls.Add(this.labelCycleRun);
			this.Name = "CycleRunSwitch";
			this.Size = new System.Drawing.Size(300, 80);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label labelCycleRun;
		private System.Windows.Forms.Button buttonCycleRunOn;
		private System.Windows.Forms.Button buttonCycleRunOff;
	}
}
