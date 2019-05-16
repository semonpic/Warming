namespace ATS.UI.CST
{
	partial class CSTForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSTForm));
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.mainTabsPanel = new ATS.UI.CST.Controls.MainTabsPanel();
            this.statusBar = new ATS.UI.CST.Controls.StatusBar();
            this.controlPanel = new ATS.UI.CST.Controls.ControlPanel();
            this.titleBar = new ATS.UI.CST.Controls.TitleBar();
            this.statusPanel = new ATS.UI.CST.Controls.StatusPanel();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1494, 235);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Copy";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1382, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "UITest";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1270, 235);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // mainTabsPanel
            // 
            this.mainTabsPanel.Location = new System.Drawing.Point(0, 166);
            this.mainTabsPanel.Name = "mainTabsPanel";
            this.mainTabsPanel.Size = new System.Drawing.Size(1610, 866);
            this.mainTabsPanel.TabIndex = 8;
            // 
            // statusBar
            // 
            this.statusBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusBar.BackColor = System.Drawing.SystemColors.Desktop;
            this.statusBar.Location = new System.Drawing.Point(0, 1048);
            this.statusBar.Margin = new System.Windows.Forms.Padding(0);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1920, 32);
            this.statusBar.TabIndex = 7;
            // 
            // controlPanel
            // 
            this.controlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlPanel.Location = new System.Drawing.Point(1620, 232);
            this.controlPanel.Margin = new System.Windows.Forms.Padding(0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(300, 800);
            this.controlPanel.TabIndex = 6;
            //this.controlPanel.Load += new System.EventHandler(this.controlPanel_Load);
            // 
            // titleBar
            // 
            this.titleBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleBar.BackColor = System.Drawing.Color.Black;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Margin = new System.Windows.Forms.Padding(0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(1920, 32);
            this.titleBar.TabIndex = 4;
            // 
            // statusPanel
            // 
            this.statusPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusPanel.Location = new System.Drawing.Point(0, 32);
            this.statusPanel.Margin = new System.Windows.Forms.Padding(0);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(1920, 200);
            this.statusPanel.TabIndex = 5;
            // 
            // CSTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.mainTabsPanel);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.titleBar);
            this.Controls.Add(this.statusPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CSTForm";
            this.Text = "CSTForm";
            this.ResumeLayout(false);

		}

		#endregion

		private Controls.StatusBar statusBar;
		private Controls.ControlPanel controlPanel;
		private Controls.StatusPanel statusPanel;
		private Controls.TitleBar titleBar;
		private Controls.MainTabsPanel mainTabsPanel;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}