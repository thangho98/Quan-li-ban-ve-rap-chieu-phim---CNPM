namespace GUI
{
	partial class frmAccountSettings
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
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.lblUsername = new System.Windows.Forms.Label();
			this.txtStaffID = new System.Windows.Forms.TextBox();
			this.lblStaffID = new System.Windows.Forms.Label();
			this.lblPassword = new System.Windows.Forms.Label();
			this.lblReEnter = new System.Windows.Forms.Label();
			this.lblConfirmPass = new System.Windows.Forms.Label();
			this.txtNewPass = new System.Windows.Forms.TextBox();
			this.txtReEnter = new System.Windows.Forms.TextBox();
			this.txtConfirmPass = new System.Windows.Forms.TextBox();
			this.btnApply = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtUsername
			// 
			this.txtUsername.Enabled = false;
			this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUsername.Location = new System.Drawing.Point(265, 49);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(208, 31);
			this.txtUsername.TabIndex = 1;
			// 
			// lblUsername
			// 
			this.lblUsername.AutoSize = true;
			this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUsername.Location = new System.Drawing.Point(11, 55);
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.Size = new System.Drawing.Size(155, 25);
			this.lblUsername.TabIndex = 1;
			this.lblUsername.Text = "Tên tài khoản :";
			// 
			// txtStaffID
			// 
			this.txtStaffID.Enabled = false;
			this.txtStaffID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtStaffID.Location = new System.Drawing.Point(265, 12);
			this.txtStaffID.Name = "txtStaffID";
			this.txtStaffID.Size = new System.Drawing.Size(208, 31);
			this.txtStaffID.TabIndex = 0;
			// 
			// lblStaffID
			// 
			this.lblStaffID.AutoSize = true;
			this.lblStaffID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStaffID.Location = new System.Drawing.Point(11, 18);
			this.lblStaffID.Name = "lblStaffID";
			this.lblStaffID.Size = new System.Drawing.Size(154, 25);
			this.lblStaffID.TabIndex = 1;
			this.lblStaffID.Text = "Mã nhân viên :";
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPassword.Location = new System.Drawing.Point(11, 112);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(153, 25);
			this.lblPassword.TabIndex = 1;
			this.lblPassword.Text = "Mật khẩu mới :";
			// 
			// lblReEnter
			// 
			this.lblReEnter.AutoSize = true;
			this.lblReEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblReEnter.Location = new System.Drawing.Point(11, 149);
			this.lblReEnter.Name = "lblReEnter";
			this.lblReEnter.Size = new System.Drawing.Size(181, 25);
			this.lblReEnter.TabIndex = 1;
			this.lblReEnter.Text = "Nhập lại MK mới :";
			// 
			// lblConfirmPass
			// 
			this.lblConfirmPass.AutoSize = true;
			this.lblConfirmPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblConfirmPass.Location = new System.Drawing.Point(11, 219);
			this.lblConfirmPass.Name = "lblConfirmPass";
			this.lblConfirmPass.Size = new System.Drawing.Size(155, 25);
			this.lblConfirmPass.TabIndex = 1;
			this.lblConfirmPass.Text = "Mật khẩu cũ :";
			// 
			// txtNewPass
			// 
			this.txtNewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNewPass.Location = new System.Drawing.Point(265, 106);
			this.txtNewPass.Name = "txtNewPass";
			this.txtNewPass.Size = new System.Drawing.Size(208, 31);
			this.txtNewPass.TabIndex = 2;
			this.txtNewPass.UseSystemPasswordChar = true;
			// 
			// txtReEnter
			// 
			this.txtReEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtReEnter.Location = new System.Drawing.Point(265, 143);
			this.txtReEnter.Name = "txtReEnter";
			this.txtReEnter.Size = new System.Drawing.Size(208, 31);
			this.txtReEnter.TabIndex = 3;
			this.txtReEnter.UseSystemPasswordChar = true;
			// 
			// txtConfirmPass
			// 
			this.txtConfirmPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtConfirmPass.Location = new System.Drawing.Point(265, 213);
			this.txtConfirmPass.Name = "txtConfirmPass";
			this.txtConfirmPass.Size = new System.Drawing.Size(208, 31);
			this.txtConfirmPass.TabIndex = 4;
			this.txtConfirmPass.UseSystemPasswordChar = true;
			// 
			// btnApply
			// 
			this.btnApply.AutoSize = true;
			this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnApply.Location = new System.Drawing.Point(296, 259);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(95, 34);
			this.btnApply.TabIndex = 2;
			this.btnApply.Text = "Cập nhật";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(418, 259);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 34);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Thoát";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmAccountSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(518, 309);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.lblStaffID);
			this.Controls.Add(this.lblConfirmPass);
			this.Controls.Add(this.lblReEnter);
			this.Controls.Add(this.lblPassword);
			this.Controls.Add(this.lblUsername);
			this.Controls.Add(this.txtStaffID);
			this.Controls.Add(this.txtConfirmPass);
			this.Controls.Add(this.txtReEnter);
			this.Controls.Add(this.txtNewPass);
			this.Controls.Add(this.txtUsername);
			this.Name = "frmAccountSettings";
			this.Text = "frmAccountSettings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.Label lblUsername;
		private System.Windows.Forms.TextBox txtStaffID;
		private System.Windows.Forms.Label lblStaffID;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.Label lblReEnter;
		private System.Windows.Forms.Label lblConfirmPass;
		private System.Windows.Forms.TextBox txtNewPass;
		private System.Windows.Forms.TextBox txtReEnter;
		private System.Windows.Forms.TextBox txtConfirmPass;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Button btnCancel;
	}
}