namespace GUI
{
    partial class frmThongTinDatVe
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
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnThanhVien = new System.Windows.Forms.Panel();
            this.txtMaThanhVien = new System.Windows.Forms.TextBox();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ckbThanhVien = new System.Windows.Forms.CheckBox();
            this.pnThanhVien.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.AutoSize = true;
            this.btnXacNhan.Location = new System.Drawing.Point(34, 172);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(120, 42);
            this.btnXacNhan.TabIndex = 8;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 13;
            // 
            // pnThanhVien
            // 
            this.pnThanhVien.Controls.Add(this.txtMaThanhVien);
            this.pnThanhVien.Controls.Add(this.txtTenKhachHang);
            this.pnThanhVien.Controls.Add(this.label4);
            this.pnThanhVien.Controls.Add(this.label3);
            this.pnThanhVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnThanhVien.Enabled = false;
            this.pnThanhVien.Location = new System.Drawing.Point(0, 0);
            this.pnThanhVien.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnThanhVien.Name = "pnThanhVien";
            this.pnThanhVien.Size = new System.Drawing.Size(510, 122);
            this.pnThanhVien.TabIndex = 15;
            // 
            // txtMaThanhVien
            // 
            this.txtMaThanhVien.Location = new System.Drawing.Point(187, 78);
            this.txtMaThanhVien.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMaThanhVien.Name = "txtMaThanhVien";
            this.txtMaThanhVien.Size = new System.Drawing.Size(302, 30);
            this.txtMaThanhVien.TabIndex = 2;
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Location = new System.Drawing.Point(187, 23);
            this.txtTenKhachHang.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(302, 30);
            this.txtTenKhachHang.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Mã Thành Viên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Họ Tên:";
            // 
            // ckbThanhVien
            // 
            this.ckbThanhVien.AutoSize = true;
            this.ckbThanhVien.Location = new System.Drawing.Point(34, 136);
            this.ckbThanhVien.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ckbThanhVien.Name = "ckbThanhVien";
            this.ckbThanhVien.Size = new System.Drawing.Size(277, 29);
            this.ckbThanhVien.TabIndex = 16;
            this.ckbThanhVien.Text = "Là Khách Hàng Thành Viên";
            this.ckbThanhVien.UseVisualStyleBackColor = true;
            this.ckbThanhVien.CheckedChanged += new System.EventHandler(this.ckbThanhVien_CheckedChanged);
            // 
            // frmThongTinDatVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 219);
            this.Controls.Add(this.ckbThanhVien);
            this.Controls.Add(this.pnThanhVien);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmThongTinDatVe";
            this.Text = "frmThongTinDatVe";
            this.Load += new System.EventHandler(this.frmThongTinDatVe_Load);
            this.pnThanhVien.ResumeLayout(false);
            this.pnThanhVien.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnThanhVien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtMaThanhVien;
        public System.Windows.Forms.TextBox txtTenKhachHang;
        public System.Windows.Forms.CheckBox ckbThanhVien;
    }
}