namespace ATS.UI.CST.Controls
{
	partial class LoginPanel
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
			this.labelUser = new System.Windows.Forms.Label();
			this.labelPassowrd = new System.Windows.Forms.Label();
			this.labelPower = new System.Windows.Forms.Label();
			this.comboBoxUsers = new System.Windows.Forms.ComboBox();
			this.labelUserPower = new System.Windows.Forms.Label();
			this.buttonLogin = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelTitle = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.labelError = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelUser
			// 
			this.labelUser.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelUser.ForeColor = System.Drawing.Color.Black;
			this.labelUser.Location = new System.Drawing.Point(55, 60);
			this.labelUser.Name = "labelUser";
			this.labelUser.Size = new System.Drawing.Size(200, 36);
			this.labelUser.TabIndex = 0;
			this.labelUser.Text = "使用者";
			// 
			// labelPassowrd
			// 
			this.labelPassowrd.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelPassowrd.ForeColor = System.Drawing.Color.Black;
			this.labelPassowrd.Location = new System.Drawing.Point(55, 120);
			this.labelPassowrd.Name = "labelPassowrd";
			this.labelPassowrd.Size = new System.Drawing.Size(200, 36);
			this.labelPassowrd.TabIndex = 1;
			this.labelPassowrd.Text = "密碼";
			// 
			// labelPower
			// 
			this.labelPower.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelPower.ForeColor = System.Drawing.Color.Black;
			this.labelPower.Location = new System.Drawing.Point(55, 180);
			this.labelPower.Name = "labelPower";
			this.labelPower.Size = new System.Drawing.Size(200, 36);
			this.labelPower.TabIndex = 2;
			this.labelPower.Text = "權限等級";
			// 
			// comboBoxUsers
			// 
			this.comboBoxUsers.CausesValidation = false;
			this.comboBoxUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.comboBoxUsers.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.comboBoxUsers.ForeColor = System.Drawing.Color.Black;
			this.comboBoxUsers.FormattingEnabled = true;
			this.comboBoxUsers.Location = new System.Drawing.Point(255, 60);
			this.comboBoxUsers.Name = "comboBoxUsers";
			this.comboBoxUsers.Size = new System.Drawing.Size(280, 44);
			this.comboBoxUsers.TabIndex = 3;
			// 
			// labelUserPower
			// 
			this.labelUserPower.BackColor = System.Drawing.Color.White;
			this.labelUserPower.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelUserPower.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelUserPower.ForeColor = System.Drawing.Color.Black;
			this.labelUserPower.Location = new System.Drawing.Point(255, 180);
			this.labelUserPower.Margin = new System.Windows.Forms.Padding(3, 30, 3, 30);
			this.labelUserPower.Name = "labelUserPower";
			this.labelUserPower.Size = new System.Drawing.Size(280, 36);
			this.labelUserPower.TabIndex = 5;
			this.labelUserPower.Text = "權限等級";
			this.labelUserPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonLogin
			// 
			this.buttonLogin.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonLogin.ForeColor = System.Drawing.Color.Black;
			this.buttonLogin.Location = new System.Drawing.Point(255, 240);
			this.buttonLogin.Name = "buttonLogin";
			this.buttonLogin.Size = new System.Drawing.Size(120, 43);
			this.buttonLogin.TabIndex = 6;
			this.buttonLogin.Text = "登錄";
			this.buttonLogin.UseVisualStyleBackColor = true;
			this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonCancel.ForeColor = System.Drawing.Color.Black;
			this.buttonCancel.Location = new System.Drawing.Point(415, 240);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(120, 43);
			this.buttonCancel.TabIndex = 7;
			this.buttonCancel.Text = "取消";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// labelTitle
			// 
			this.labelTitle.BackColor = System.Drawing.Color.Black;
			this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelTitle.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelTitle.ForeColor = System.Drawing.Color.White;
			this.labelTitle.Location = new System.Drawing.Point(0, 0);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(800, 36);
			this.labelTitle.TabIndex = 9;
			this.labelTitle.Text = "登入";
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label6.Image = global::ATS.UI.CST.Properties.Resources.Icon_SystemUsers;
			this.label6.Location = new System.Drawing.Point(606, 100);
			this.label6.Margin = new System.Windows.Forms.Padding(3, 64, 64, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(128, 128);
			this.label6.TabIndex = 8;
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxPassword.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.textBoxPassword.ForeColor = System.Drawing.Color.Black;
			this.textBoxPassword.Location = new System.Drawing.Point(255, 120);
			this.textBoxPassword.MaxLength = 100;
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.Size = new System.Drawing.Size(280, 46);
			this.textBoxPassword.TabIndex = 10;
			this.textBoxPassword.UseSystemPasswordChar = true;
			// 
			// labelError
			// 
			this.labelError.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelError.ForeColor = System.Drawing.Color.FromArgb(237,28,36);
			this.labelError.Location = new System.Drawing.Point(255, 300);
			this.labelError.Name = "labelError";
			this.labelError.Size = new System.Drawing.Size(280, 36);
			this.labelError.TabIndex = 11;
			this.labelError.Text = "登入失敗";
			// 
			// LoginPanel
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.labelError);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonLogin);
			this.Controls.Add(this.labelUserPower);
			this.Controls.Add(this.comboBoxUsers);
			this.Controls.Add(this.labelPower);
			this.Controls.Add(this.labelPassowrd);
			this.Controls.Add(this.labelUser);
			this.Name = "LoginPanel";
			this.Size = new System.Drawing.Size(800, 360);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelUser;
		private System.Windows.Forms.Label labelPassowrd;
		private System.Windows.Forms.Label labelPower;
		private System.Windows.Forms.ComboBox comboBoxUsers;
		private System.Windows.Forms.Label labelUserPower;
		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Label labelError;
	}
}
