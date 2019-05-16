namespace WiseTech.Tester
{
	partial class DataManagerTester
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelKey = new System.Windows.Forms.Label();
			this.labelResult = new System.Windows.Forms.Label();
			this.textBoxResult = new System.Windows.Forms.TextBox();
			this.labelValue = new System.Windows.Forms.Label();
			this.buttonLoad = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.textBoxValue = new System.Windows.Forms.TextBox();
			this.textBoxKey = new System.Windows.Forms.TextBox();
			this.buttonTest = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelKey
			// 
			this.labelKey.AutoSize = true;
			this.labelKey.Location = new System.Drawing.Point(101, 33);
			this.labelKey.Name = "labelKey";
			this.labelKey.Size = new System.Drawing.Size(24, 12);
			this.labelKey.TabIndex = 25;
			this.labelKey.Text = "Key";
			// 
			// labelResult
			// 
			this.labelResult.AutoSize = true;
			this.labelResult.Location = new System.Drawing.Point(101, 121);
			this.labelResult.Name = "labelResult";
			this.labelResult.Size = new System.Drawing.Size(56, 12);
			this.labelResult.TabIndex = 24;
			this.labelResult.Text = "Test Result";
			// 
			// textBoxResult
			// 
			this.textBoxResult.Location = new System.Drawing.Point(103, 136);
			this.textBoxResult.Name = "textBoxResult";
			this.textBoxResult.Size = new System.Drawing.Size(100, 22);
			this.textBoxResult.TabIndex = 23;
			// 
			// labelValue
			// 
			this.labelValue.AutoSize = true;
			this.labelValue.Location = new System.Drawing.Point(258, 33);
			this.labelValue.Name = "labelValue";
			this.labelValue.Size = new System.Drawing.Size(32, 12);
			this.labelValue.TabIndex = 22;
			this.labelValue.Text = "Value";
			// 
			// buttonLoad
			// 
			this.buttonLoad.Location = new System.Drawing.Point(260, 76);
			this.buttonLoad.Name = "buttonLoad";
			this.buttonLoad.Size = new System.Drawing.Size(75, 23);
			this.buttonLoad.TabIndex = 21;
			this.buttonLoad.Text = "Load";
			this.buttonLoad.UseVisualStyleBackColor = true;
			this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(100, 76);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 20;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// textBoxValue
			// 
			this.textBoxValue.Location = new System.Drawing.Point(260, 48);
			this.textBoxValue.Name = "textBoxValue";
			this.textBoxValue.Size = new System.Drawing.Size(100, 22);
			this.textBoxValue.TabIndex = 19;
			// 
			// textBoxKey
			// 
			this.textBoxKey.Location = new System.Drawing.Point(100, 48);
			this.textBoxKey.Name = "textBoxKey";
			this.textBoxKey.Size = new System.Drawing.Size(100, 22);
			this.textBoxKey.TabIndex = 18;
			// 
			// buttonTest
			// 
			this.buttonTest.Location = new System.Drawing.Point(260, 134);
			this.buttonTest.Name = "buttonTest";
			this.buttonTest.Size = new System.Drawing.Size(75, 23);
			this.buttonTest.TabIndex = 26;
			this.buttonTest.Text = "Connect Test";
			this.buttonTest.UseVisualStyleBackColor = true;
			this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
			// 
			// DataManagerTester
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(561, 259);
			this.Controls.Add(this.buttonTest);
			this.Controls.Add(this.labelKey);
			this.Controls.Add(this.labelResult);
			this.Controls.Add(this.textBoxResult);
			this.Controls.Add(this.labelValue);
			this.Controls.Add(this.buttonLoad);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.textBoxValue);
			this.Controls.Add(this.textBoxKey);
			this.Name = "DataManagerTester";
			this.Text = "DataManagerTester";
			this.Load += new System.EventHandler(this.DataManagerTester_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelKey;
		private System.Windows.Forms.Label labelResult;
		private System.Windows.Forms.TextBox textBoxResult;
		private System.Windows.Forms.Label labelValue;
		private System.Windows.Forms.Button buttonLoad;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.TextBox textBoxValue;
		private System.Windows.Forms.TextBox textBoxKey;
		private System.Windows.Forms.Button buttonTest;
	}
}