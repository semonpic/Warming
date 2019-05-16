namespace ATS.UI.CST.Controls
{
	partial class SafetyDoorSwitch
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
			this.labelSafetyDoor = new System.Windows.Forms.Label();
			this.buttonSafetyDoorEnable = new System.Windows.Forms.Button();
			this.buttonSafetyDoorDisable = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelSafetyDoor
			// 
			this.labelSafetyDoor.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelSafetyDoor.BackColor = System.Drawing.Color.Black;
			this.labelSafetyDoor.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelSafetyDoor.ForeColor = System.Drawing.Color.White;
			this.labelSafetyDoor.Location = new System.Drawing.Point(0, 0);
			this.labelSafetyDoor.Margin = new System.Windows.Forms.Padding(0);
			this.labelSafetyDoor.Name = "labelSafetyDoor";
			this.labelSafetyDoor.Size = new System.Drawing.Size(300, 40);
			this.labelSafetyDoor.TabIndex = 1;
			this.labelSafetyDoor.Text = "SafetyDoor";
			this.labelSafetyDoor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonSafetyDoorEnable
			// 
			this.buttonSafetyDoorEnable.BackColor = System.Drawing.Color.LightBlue;
			this.buttonSafetyDoorEnable.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.buttonSafetyDoorEnable.FlatAppearance.BorderSize = 0;
			this.buttonSafetyDoorEnable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonSafetyDoorEnable.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonSafetyDoorEnable.Location = new System.Drawing.Point(0, 40);
			this.buttonSafetyDoorEnable.Margin = new System.Windows.Forms.Padding(0);
			this.buttonSafetyDoorEnable.Name = "buttonSafetyDoorEnable";
			this.buttonSafetyDoorEnable.Size = new System.Drawing.Size(150, 40);
			this.buttonSafetyDoorEnable.TabIndex = 4;
			this.buttonSafetyDoorEnable.Text = "Enable";
			this.buttonSafetyDoorEnable.UseVisualStyleBackColor = false;
			this.buttonSafetyDoorEnable.Click += new System.EventHandler(this.buttonSafetyDoorEnable_Click);
			// 
			// buttonSafetyDoorDisable
			// 
			this.buttonSafetyDoorDisable.BackColor = System.Drawing.Color.DimGray;
			this.buttonSafetyDoorDisable.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.buttonSafetyDoorDisable.FlatAppearance.BorderSize = 0;
			this.buttonSafetyDoorDisable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonSafetyDoorDisable.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonSafetyDoorDisable.Location = new System.Drawing.Point(150, 40);
			this.buttonSafetyDoorDisable.Margin = new System.Windows.Forms.Padding(0);
			this.buttonSafetyDoorDisable.Name = "buttonSafetyDoorDisable";
			this.buttonSafetyDoorDisable.Size = new System.Drawing.Size(150, 40);
			this.buttonSafetyDoorDisable.TabIndex = 5;
			this.buttonSafetyDoorDisable.Text = "Disable";
			this.buttonSafetyDoorDisable.UseVisualStyleBackColor = false;
			this.buttonSafetyDoorDisable.Click += new System.EventHandler(this.buttonSafetyDoorDisable_Click);
			// 
			// SafetyDoorSwitch
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.buttonSafetyDoorDisable);
			this.Controls.Add(this.buttonSafetyDoorEnable);
			this.Controls.Add(this.labelSafetyDoor);
			this.Name = "SafetyDoorSwitch";
			this.Size = new System.Drawing.Size(300, 80);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label labelSafetyDoor;
		private System.Windows.Forms.Button buttonSafetyDoorEnable;
		private System.Windows.Forms.Button buttonSafetyDoorDisable;
	}
}
