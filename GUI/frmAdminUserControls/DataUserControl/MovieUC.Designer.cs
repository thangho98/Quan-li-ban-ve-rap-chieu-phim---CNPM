namespace GUI.frmAdminUserControls.DataUserControl
{
    partial class MovieUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel47 = new System.Windows.Forms.Panel();
            this.btnShowMovie = new System.Windows.Forms.Button();
            this.btnUpdateMovie = new System.Windows.Forms.Button();
            this.btnDeleteMovie = new System.Windows.Forms.Button();
            this.btnAddMovie = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgvMovie = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUpLoadPictureFilm = new System.Windows.Forms.Button();
            this.picFilm = new System.Windows.Forms.PictureBox();
            this.clbMovieGenre = new System.Windows.Forms.CheckedListBox();
            this.dtmMovieEnd = new System.Windows.Forms.DateTimePicker();
            this.dtmMovieStart = new System.Windows.Forms.DateTimePicker();
            this.txtMovieYear = new System.Windows.Forms.TextBox();
            this.txtMovieDirector = new System.Windows.Forms.TextBox();
            this.txtMovieProductor = new System.Windows.Forms.TextBox();
            this.txtMovieLength = new System.Windows.Forms.TextBox();
            this.lblMovieEndDate = new System.Windows.Forms.Label();
            this.lblMovieStartDate = new System.Windows.Forms.Label();
            this.lblMovieLength = new System.Windows.Forms.Label();
            this.txtMovieDesc = new System.Windows.Forms.TextBox();
            this.lblMovieYear = new System.Windows.Forms.Label();
            this.lblMovieGenre = new System.Windows.Forms.Label();
            this.lblMovieDirector = new System.Windows.Forms.Label();
            this.lblMovieProductor = new System.Windows.Forms.Label();
            this.lblMovieDesc = new System.Windows.Forms.Label();
            this.txtMovieName = new System.Windows.Forms.TextBox();
            this.lblMovieName = new System.Windows.Forms.Label();
            this.txtMovieID = new System.Windows.Forms.TextBox();
            this.lblMovieID = new System.Windows.Forms.Label();
            this.panel47.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMovie)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFilm)).BeginInit();
            this.SuspendLayout();
            // 
            // panel47
            // 
            this.panel47.Controls.Add(this.btnShowMovie);
            this.panel47.Controls.Add(this.btnUpdateMovie);
            this.panel47.Controls.Add(this.btnDeleteMovie);
            this.panel47.Controls.Add(this.btnAddMovie);
            this.panel47.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel47.Location = new System.Drawing.Point(0, 278);
            this.panel47.Margin = new System.Windows.Forms.Padding(4);
            this.panel47.Name = "panel47";
            this.panel47.Size = new System.Drawing.Size(1548, 64);
            this.panel47.TabIndex = 10;
            // 
            // btnShowMovie
            // 
            this.btnShowMovie.Location = new System.Drawing.Point(328, 4);
            this.btnShowMovie.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowMovie.Name = "btnShowMovie";
            this.btnShowMovie.Size = new System.Drawing.Size(100, 57);
            this.btnShowMovie.TabIndex = 3;
            this.btnShowMovie.Text = "Xem";
            this.btnShowMovie.UseVisualStyleBackColor = true;
            this.btnShowMovie.Click += new System.EventHandler(this.btnShowMovie_Click);
            // 
            // btnUpdateMovie
            // 
            this.btnUpdateMovie.Location = new System.Drawing.Point(220, 4);
            this.btnUpdateMovie.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateMovie.Name = "btnUpdateMovie";
            this.btnUpdateMovie.Size = new System.Drawing.Size(100, 57);
            this.btnUpdateMovie.TabIndex = 2;
            this.btnUpdateMovie.Text = "Sửa";
            this.btnUpdateMovie.UseVisualStyleBackColor = true;
            this.btnUpdateMovie.Click += new System.EventHandler(this.btnUpdateMovie_Click);
            // 
            // btnDeleteMovie
            // 
            this.btnDeleteMovie.Location = new System.Drawing.Point(112, 4);
            this.btnDeleteMovie.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteMovie.Name = "btnDeleteMovie";
            this.btnDeleteMovie.Size = new System.Drawing.Size(100, 57);
            this.btnDeleteMovie.TabIndex = 1;
            this.btnDeleteMovie.Text = "Xóa";
            this.btnDeleteMovie.UseVisualStyleBackColor = true;
            this.btnDeleteMovie.Click += new System.EventHandler(this.btnDeleteMovie_Click);
            // 
            // btnAddMovie
            // 
            this.btnAddMovie.Location = new System.Drawing.Point(4, 4);
            this.btnAddMovie.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddMovie.Name = "btnAddMovie";
            this.btnAddMovie.Size = new System.Drawing.Size(100, 57);
            this.btnAddMovie.TabIndex = 0;
            this.btnAddMovie.Text = "Thêm";
            this.btnAddMovie.UseVisualStyleBackColor = true;
            this.btnAddMovie.Click += new System.EventHandler(this.btnAddMovie_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgvMovie);
            this.panel1.Controls.Add(this.panel47);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1548, 638);
            this.panel1.TabIndex = 11;
            // 
            // dtgvMovie
            // 
            this.dtgvMovie.AllowUserToAddRows = false;
            this.dtgvMovie.AllowUserToDeleteRows = false;
            this.dtgvMovie.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvMovie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvMovie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvMovie.Location = new System.Drawing.Point(0, 342);
            this.dtgvMovie.Margin = new System.Windows.Forms.Padding(4);
            this.dtgvMovie.Name = "dtgvMovie";
            this.dtgvMovie.ReadOnly = true;
            this.dtgvMovie.Size = new System.Drawing.Size(1548, 296);
            this.dtgvMovie.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnUpLoadPictureFilm);
            this.panel2.Controls.Add(this.picFilm);
            this.panel2.Controls.Add(this.clbMovieGenre);
            this.panel2.Controls.Add(this.dtmMovieEnd);
            this.panel2.Controls.Add(this.dtmMovieStart);
            this.panel2.Controls.Add(this.txtMovieYear);
            this.panel2.Controls.Add(this.txtMovieDirector);
            this.panel2.Controls.Add(this.txtMovieProductor);
            this.panel2.Controls.Add(this.txtMovieLength);
            this.panel2.Controls.Add(this.lblMovieEndDate);
            this.panel2.Controls.Add(this.lblMovieStartDate);
            this.panel2.Controls.Add(this.lblMovieLength);
            this.panel2.Controls.Add(this.txtMovieDesc);
            this.panel2.Controls.Add(this.lblMovieYear);
            this.panel2.Controls.Add(this.lblMovieGenre);
            this.panel2.Controls.Add(this.lblMovieDirector);
            this.panel2.Controls.Add(this.lblMovieProductor);
            this.panel2.Controls.Add(this.lblMovieDesc);
            this.panel2.Controls.Add(this.txtMovieName);
            this.panel2.Controls.Add(this.lblMovieName);
            this.panel2.Controls.Add(this.txtMovieID);
            this.panel2.Controls.Add(this.lblMovieID);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1548, 278);
            this.panel2.TabIndex = 0;
            // 
            // btnUpLoadPictureFilm
            // 
            this.btnUpLoadPictureFilm.Location = new System.Drawing.Point(972, 231);
            this.btnUpLoadPictureFilm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpLoadPictureFilm.Name = "btnUpLoadPictureFilm";
            this.btnUpLoadPictureFilm.Size = new System.Drawing.Size(127, 41);
            this.btnUpLoadPictureFilm.TabIndex = 56;
            this.btnUpLoadPictureFilm.Text = "Chọn hình ảnh";
            this.btnUpLoadPictureFilm.UseVisualStyleBackColor = true;
            this.btnUpLoadPictureFilm.Click += new System.EventHandler(this.btnUpLoadPictureFilm_Click);
            // 
            // picFilm
            // 
            this.picFilm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFilm.Location = new System.Drawing.Point(943, 2);
            this.picFilm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picFilm.Name = "picFilm";
            this.picFilm.Size = new System.Drawing.Size(186, 217);
            this.picFilm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFilm.TabIndex = 55;
            this.picFilm.TabStop = false;
            // 
            // clbMovieGenre
            // 
            this.clbMovieGenre.CheckOnClick = true;
            this.clbMovieGenre.FormattingEnabled = true;
            this.clbMovieGenre.Location = new System.Drawing.Point(15, 151);
            this.clbMovieGenre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clbMovieGenre.MultiColumn = true;
            this.clbMovieGenre.Name = "clbMovieGenre";
            this.clbMovieGenre.Size = new System.Drawing.Size(333, 106);
            this.clbMovieGenre.TabIndex = 54;
            // 
            // dtmMovieEnd
            // 
            this.dtmMovieEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmMovieEnd.Location = new System.Drawing.Point(641, 85);
            this.dtmMovieEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtmMovieEnd.Name = "dtmMovieEnd";
            this.dtmMovieEnd.Size = new System.Drawing.Size(201, 22);
            this.dtmMovieEnd.TabIndex = 53;
            // 
            // dtmMovieStart
            // 
            this.dtmMovieStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmMovieStart.Location = new System.Drawing.Point(641, 50);
            this.dtmMovieStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtmMovieStart.Name = "dtmMovieStart";
            this.dtmMovieStart.Size = new System.Drawing.Size(201, 22);
            this.dtmMovieStart.TabIndex = 52;
            // 
            // txtMovieYear
            // 
            this.txtMovieYear.Location = new System.Drawing.Point(640, 201);
            this.txtMovieYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMovieYear.Name = "txtMovieYear";
            this.txtMovieYear.Size = new System.Drawing.Size(201, 22);
            this.txtMovieYear.TabIndex = 50;
            // 
            // txtMovieDirector
            // 
            this.txtMovieDirector.Location = new System.Drawing.Point(640, 166);
            this.txtMovieDirector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMovieDirector.Name = "txtMovieDirector";
            this.txtMovieDirector.Size = new System.Drawing.Size(201, 22);
            this.txtMovieDirector.TabIndex = 49;
            // 
            // txtMovieProductor
            // 
            this.txtMovieProductor.Location = new System.Drawing.Point(640, 128);
            this.txtMovieProductor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMovieProductor.Name = "txtMovieProductor";
            this.txtMovieProductor.Size = new System.Drawing.Size(201, 22);
            this.txtMovieProductor.TabIndex = 48;
            // 
            // txtMovieLength
            // 
            this.txtMovieLength.Location = new System.Drawing.Point(641, 16);
            this.txtMovieLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMovieLength.Name = "txtMovieLength";
            this.txtMovieLength.Size = new System.Drawing.Size(201, 22);
            this.txtMovieLength.TabIndex = 47;
            // 
            // lblMovieEndDate
            // 
            this.lblMovieEndDate.AutoSize = true;
            this.lblMovieEndDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieEndDate.Location = new System.Drawing.Point(505, 85);
            this.lblMovieEndDate.Name = "lblMovieEndDate";
            this.lblMovieEndDate.Size = new System.Drawing.Size(92, 23);
            this.lblMovieEndDate.TabIndex = 44;
            this.lblMovieEndDate.Text = "Ngày KT:";
            // 
            // lblMovieStartDate
            // 
            this.lblMovieStartDate.AutoSize = true;
            this.lblMovieStartDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieStartDate.Location = new System.Drawing.Point(505, 50);
            this.lblMovieStartDate.Name = "lblMovieStartDate";
            this.lblMovieStartDate.Size = new System.Drawing.Size(94, 23);
            this.lblMovieStartDate.TabIndex = 42;
            this.lblMovieStartDate.Text = "Ngày KC:";
            // 
            // lblMovieLength
            // 
            this.lblMovieLength.AutoSize = true;
            this.lblMovieLength.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieLength.Location = new System.Drawing.Point(505, 14);
            this.lblMovieLength.Name = "lblMovieLength";
            this.lblMovieLength.Size = new System.Drawing.Size(109, 23);
            this.lblMovieLength.TabIndex = 35;
            this.lblMovieLength.Text = "Thời lượng:";
            // 
            // txtMovieDesc
            // 
            this.txtMovieDesc.Location = new System.Drawing.Point(147, 90);
            this.txtMovieDesc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMovieDesc.Multiline = true;
            this.txtMovieDesc.Name = "txtMovieDesc";
            this.txtMovieDesc.Size = new System.Drawing.Size(201, 22);
            this.txtMovieDesc.TabIndex = 46;
            // 
            // lblMovieYear
            // 
            this.lblMovieYear.AutoSize = true;
            this.lblMovieYear.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieYear.Location = new System.Drawing.Point(504, 199);
            this.lblMovieYear.Name = "lblMovieYear";
            this.lblMovieYear.Size = new System.Drawing.Size(103, 26);
            this.lblMovieYear.TabIndex = 41;
            this.lblMovieYear.Text = "Năm SX:";
            // 
            // lblMovieGenre
            // 
            this.lblMovieGenre.AutoSize = true;
            this.lblMovieGenre.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieGenre.Location = new System.Drawing.Point(11, 123);
            this.lblMovieGenre.Name = "lblMovieGenre";
            this.lblMovieGenre.Size = new System.Drawing.Size(103, 26);
            this.lblMovieGenre.TabIndex = 40;
            this.lblMovieGenre.Text = "Thể loại:";
            // 
            // lblMovieDirector
            // 
            this.lblMovieDirector.AutoSize = true;
            this.lblMovieDirector.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieDirector.Location = new System.Drawing.Point(504, 161);
            this.lblMovieDirector.Name = "lblMovieDirector";
            this.lblMovieDirector.Size = new System.Drawing.Size(111, 26);
            this.lblMovieDirector.TabIndex = 39;
            this.lblMovieDirector.Text = "Đạo diễn:";
            // 
            // lblMovieProductor
            // 
            this.lblMovieProductor.AutoSize = true;
            this.lblMovieProductor.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieProductor.Location = new System.Drawing.Point(504, 123);
            this.lblMovieProductor.Name = "lblMovieProductor";
            this.lblMovieProductor.Size = new System.Drawing.Size(109, 26);
            this.lblMovieProductor.TabIndex = 38;
            this.lblMovieProductor.Text = "Sản xuất:";
            // 
            // lblMovieDesc
            // 
            this.lblMovieDesc.AutoSize = true;
            this.lblMovieDesc.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieDesc.Location = new System.Drawing.Point(11, 85);
            this.lblMovieDesc.Name = "lblMovieDesc";
            this.lblMovieDesc.Size = new System.Drawing.Size(81, 26);
            this.lblMovieDesc.TabIndex = 37;
            this.lblMovieDesc.Text = "Mô tả:";
            // 
            // txtMovieName
            // 
            this.txtMovieName.Location = new System.Drawing.Point(147, 54);
            this.txtMovieName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMovieName.Name = "txtMovieName";
            this.txtMovieName.Size = new System.Drawing.Size(201, 22);
            this.txtMovieName.TabIndex = 51;
            // 
            // lblMovieName
            // 
            this.lblMovieName.AutoSize = true;
            this.lblMovieName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieName.Location = new System.Drawing.Point(11, 49);
            this.lblMovieName.Name = "lblMovieName";
            this.lblMovieName.Size = new System.Drawing.Size(117, 26);
            this.lblMovieName.TabIndex = 36;
            this.lblMovieName.Text = "Tên phim:";
            // 
            // txtMovieID
            // 
            this.txtMovieID.Location = new System.Drawing.Point(147, 16);
            this.txtMovieID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMovieID.Name = "txtMovieID";
            this.txtMovieID.Size = new System.Drawing.Size(201, 22);
            this.txtMovieID.TabIndex = 45;
            this.txtMovieID.TextChanged += new System.EventHandler(this.txtMovieID_TextChanged);
            // 
            // lblMovieID
            // 
            this.lblMovieID.AutoSize = true;
            this.lblMovieID.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieID.Location = new System.Drawing.Point(11, 11);
            this.lblMovieID.Name = "lblMovieID";
            this.lblMovieID.Size = new System.Drawing.Size(113, 26);
            this.lblMovieID.TabIndex = 43;
            this.lblMovieID.Text = "Mã phim:";
            // 
            // MovieUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MovieUC";
            this.Size = new System.Drawing.Size(1548, 638);
            this.panel47.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMovie)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFilm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel47;
        private System.Windows.Forms.Button btnShowMovie;
        private System.Windows.Forms.Button btnUpdateMovie;
        private System.Windows.Forms.Button btnDeleteMovie;
        private System.Windows.Forms.Button btnAddMovie;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUpLoadPictureFilm;
        private System.Windows.Forms.PictureBox picFilm;
        private System.Windows.Forms.CheckedListBox clbMovieGenre;
        private System.Windows.Forms.DateTimePicker dtmMovieEnd;
        private System.Windows.Forms.DateTimePicker dtmMovieStart;
        private System.Windows.Forms.TextBox txtMovieYear;
        private System.Windows.Forms.TextBox txtMovieDirector;
        private System.Windows.Forms.TextBox txtMovieProductor;
        private System.Windows.Forms.TextBox txtMovieLength;
        private System.Windows.Forms.Label lblMovieEndDate;
        private System.Windows.Forms.Label lblMovieStartDate;
        private System.Windows.Forms.Label lblMovieLength;
        private System.Windows.Forms.TextBox txtMovieDesc;
        private System.Windows.Forms.Label lblMovieYear;
        private System.Windows.Forms.Label lblMovieGenre;
        private System.Windows.Forms.Label lblMovieDirector;
        private System.Windows.Forms.Label lblMovieProductor;
        private System.Windows.Forms.Label lblMovieDesc;
        private System.Windows.Forms.TextBox txtMovieName;
        private System.Windows.Forms.Label lblMovieName;
        private System.Windows.Forms.TextBox txtMovieID;
        private System.Windows.Forms.Label lblMovieID;
        private System.Windows.Forms.DataGridView dtgvMovie;
    }
}
