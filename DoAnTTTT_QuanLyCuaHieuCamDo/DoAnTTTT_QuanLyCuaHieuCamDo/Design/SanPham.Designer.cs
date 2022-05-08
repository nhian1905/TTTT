
namespace DoAnTTTT_QuanLyCuaHieuCamDo.Design
{
    partial class SanPham
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
            this.LVSP = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnTatCa = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDaThanhLy = new System.Windows.Forms.CheckBox();
            this.cbThanhLy = new System.Windows.Forms.CheckBox();
            this.cbDaChuoc = new System.Windows.Forms.CheckBox();
            this.cbQuaHan = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnXoaLoaiSP = new System.Windows.Forms.Button();
            this.btnSuaLoaiSP = new System.Windows.Forms.Button();
            this.btnThemLoaiSP = new System.Windows.Forms.Button();
            this.txtLaiSuat = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.LVLoaiSP = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtTenLoai = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtHienTrang = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMauSac = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGiaThanhLy = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNhanHieu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDinhGia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTenLoai = new System.Windows.Forms.ComboBox();
            this.btnThanhLy = new System.Windows.Forms.Button();
            this.btnXoaSP = new System.Windows.Forms.Button();
            this.btnSuaSP = new System.Windows.Forms.Button();
            this.btnThemSP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXuat = new System.Windows.Forms.Button();
            this.txtMaLoai = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // LVSP
            // 
            this.LVSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.LVSP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader14,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.LVSP.ForeColor = System.Drawing.Color.White;
            this.LVSP.FullRowSelect = true;
            this.LVSP.GridLines = true;
            this.LVSP.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LVSP.HideSelection = false;
            this.LVSP.Location = new System.Drawing.Point(12, 450);
            this.LVSP.Name = "LVSP";
            this.LVSP.Size = new System.Drawing.Size(1302, 450);
            this.LVSP.TabIndex = 0;
            this.LVSP.UseCompatibleStateImageBehavior = false;
            this.LVSP.View = System.Windows.Forms.View.Details;
            this.LVSP.SelectedIndexChanged += new System.EventHandler(this.LVSP_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã SP";
            this.columnHeader1.Width = 104;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên Loại";
            this.columnHeader2.Width = 84;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Tên SP";
            this.columnHeader14.Width = 106;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Định Giá";
            this.columnHeader3.Width = 75;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Giá Thanh Lý";
            this.columnHeader4.Width = 111;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Mô Tả";
            this.columnHeader5.Width = 170;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Màu Sắc";
            this.columnHeader6.Width = 91;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Hiện Trạng";
            this.columnHeader7.Width = 217;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Nhãn Hiệu";
            this.columnHeader8.Width = 84;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Quá Hạn";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Đã Chuộc";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Thanh Lý";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Đã Thanh Lý";
            this.columnHeader13.Width = 78;
            // 
            // btnTatCa
            // 
            this.btnTatCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnTatCa.FlatAppearance.BorderSize = 0;
            this.btnTatCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTatCa.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTatCa.ForeColor = System.Drawing.Color.White;
            this.btnTatCa.Location = new System.Drawing.Point(1197, 21);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.Size = new System.Drawing.Size(99, 38);
            this.btnTatCa.TabIndex = 11;
            this.btnTatCa.Text = "Tất cả";
            this.btnTatCa.UseVisualStyleBackColor = false;
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnLoc.FlatAppearance.BorderSize = 0;
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(1066, 21);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(99, 38);
            this.btnLoc.TabIndex = 34;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDaThanhLy);
            this.groupBox1.Controls.Add(this.btnLoc);
            this.groupBox1.Controls.Add(this.cbThanhLy);
            this.groupBox1.Controls.Add(this.cbDaChuoc);
            this.groupBox1.Controls.Add(this.cbQuaHan);
            this.groupBox1.Controls.Add(this.btnTatCa);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 372);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1302, 72);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lọc sản phẩm";
            // 
            // cbDaThanhLy
            // 
            this.cbDaThanhLy.AutoSize = true;
            this.cbDaThanhLy.Location = new System.Drawing.Point(755, 31);
            this.cbDaThanhLy.Name = "cbDaThanhLy";
            this.cbDaThanhLy.Size = new System.Drawing.Size(131, 28);
            this.cbDaThanhLy.TabIndex = 3;
            this.cbDaThanhLy.Text = "Đã thanh lý";
            this.cbDaThanhLy.UseVisualStyleBackColor = true;
            // 
            // cbThanhLy
            // 
            this.cbThanhLy.AutoSize = true;
            this.cbThanhLy.Location = new System.Drawing.Point(504, 31);
            this.cbThanhLy.Name = "cbThanhLy";
            this.cbThanhLy.Size = new System.Drawing.Size(106, 28);
            this.cbThanhLy.TabIndex = 2;
            this.cbThanhLy.Text = "Thanh lý";
            this.cbThanhLy.UseVisualStyleBackColor = true;
            // 
            // cbDaChuoc
            // 
            this.cbDaChuoc.AutoSize = true;
            this.cbDaChuoc.Location = new System.Drawing.Point(250, 31);
            this.cbDaChuoc.Name = "cbDaChuoc";
            this.cbDaChuoc.Size = new System.Drawing.Size(113, 28);
            this.cbDaChuoc.TabIndex = 1;
            this.cbDaChuoc.Text = "Đã chuộc";
            this.cbDaChuoc.UseVisualStyleBackColor = true;
            // 
            // cbQuaHan
            // 
            this.cbQuaHan.AutoSize = true;
            this.cbQuaHan.Location = new System.Drawing.Point(15, 31);
            this.cbQuaHan.Name = "cbQuaHan";
            this.cbQuaHan.Size = new System.Drawing.Size(105, 28);
            this.cbQuaHan.TabIndex = 0;
            this.cbQuaHan.Text = "Quá hạn";
            this.cbQuaHan.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMaLoai);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.btnXoaLoaiSP);
            this.groupBox2.Controls.Add(this.btnSuaLoaiSP);
            this.groupBox2.Controls.Add(this.btnThemLoaiSP);
            this.groupBox2.Controls.Add(this.txtLaiSuat);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.LVLoaiSP);
            this.groupBox2.Controls.Add(this.txtTenLoai);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(724, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(607, 366);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loại sản phẩm";
            // 
            // btnXoaLoaiSP
            // 
            this.btnXoaLoaiSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnXoaLoaiSP.FlatAppearance.BorderSize = 0;
            this.btnXoaLoaiSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaLoaiSP.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaLoaiSP.ForeColor = System.Drawing.Color.White;
            this.btnXoaLoaiSP.Location = new System.Drawing.Point(418, 296);
            this.btnXoaLoaiSP.Name = "btnXoaLoaiSP";
            this.btnXoaLoaiSP.Size = new System.Drawing.Size(99, 38);
            this.btnXoaLoaiSP.TabIndex = 36;
            this.btnXoaLoaiSP.Text = "Xóa";
            this.btnXoaLoaiSP.UseVisualStyleBackColor = false;
            this.btnXoaLoaiSP.Click += new System.EventHandler(this.btnXoaLoaiSP_Click);
            // 
            // btnSuaLoaiSP
            // 
            this.btnSuaLoaiSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnSuaLoaiSP.FlatAppearance.BorderSize = 0;
            this.btnSuaLoaiSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaLoaiSP.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaLoaiSP.ForeColor = System.Drawing.Color.White;
            this.btnSuaLoaiSP.Location = new System.Drawing.Point(276, 296);
            this.btnSuaLoaiSP.Name = "btnSuaLoaiSP";
            this.btnSuaLoaiSP.Size = new System.Drawing.Size(99, 38);
            this.btnSuaLoaiSP.TabIndex = 35;
            this.btnSuaLoaiSP.Text = "Sửa";
            this.btnSuaLoaiSP.UseVisualStyleBackColor = false;
            this.btnSuaLoaiSP.Click += new System.EventHandler(this.btnSuaLoaiSP_Click);
            // 
            // btnThemLoaiSP
            // 
            this.btnThemLoaiSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnThemLoaiSP.FlatAppearance.BorderSize = 0;
            this.btnThemLoaiSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemLoaiSP.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemLoaiSP.ForeColor = System.Drawing.Color.White;
            this.btnThemLoaiSP.Location = new System.Drawing.Point(130, 296);
            this.btnThemLoaiSP.Name = "btnThemLoaiSP";
            this.btnThemLoaiSP.Size = new System.Drawing.Size(99, 38);
            this.btnThemLoaiSP.TabIndex = 34;
            this.btnThemLoaiSP.Text = "Thêm ";
            this.btnThemLoaiSP.UseVisualStyleBackColor = false;
            this.btnThemLoaiSP.Click += new System.EventHandler(this.btnThemLoaiSP_Click);
            // 
            // txtLaiSuat
            // 
            this.txtLaiSuat.AccessibleDescription = "";
            this.txtLaiSuat.AccessibleName = "";
            this.txtLaiSuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtLaiSuat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLaiSuat.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLaiSuat.ForeColor = System.Drawing.Color.White;
            this.txtLaiSuat.Location = new System.Drawing.Point(248, 67);
            this.txtLaiSuat.Name = "txtLaiSuat";
            this.txtLaiSuat.Size = new System.Drawing.Size(256, 22);
            this.txtLaiSuat.TabIndex = 32;
            this.txtLaiSuat.Tag = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(29, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(165, 22);
            this.label10.TabIndex = 33;
            this.label10.Text = "Lãi suất ( %/ ngày)";
            // 
            // LVLoaiSP
            // 
            this.LVLoaiSP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader15,
            this.columnHeader16});
            this.LVLoaiSP.FullRowSelect = true;
            this.LVLoaiSP.GridLines = true;
            this.LVLoaiSP.HideSelection = false;
            this.LVLoaiSP.Location = new System.Drawing.Point(33, 112);
            this.LVLoaiSP.Name = "LVLoaiSP";
            this.LVLoaiSP.Size = new System.Drawing.Size(551, 160);
            this.LVLoaiSP.TabIndex = 31;
            this.LVLoaiSP.UseCompatibleStateImageBehavior = false;
            this.LVLoaiSP.View = System.Windows.Forms.View.Details;
            this.LVLoaiSP.SelectedIndexChanged += new System.EventHandler(this.LVLoaiSP_SelectedIndexChanged);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Mã Loại";
            this.columnHeader9.Width = 112;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Tên Loại";
            this.columnHeader15.Width = 323;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Lãi Xuất";
            this.columnHeader16.Width = 109;
            // 
            // txtTenLoai
            // 
            this.txtTenLoai.AccessibleDescription = "";
            this.txtTenLoai.AccessibleName = "";
            this.txtTenLoai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtTenLoai.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTenLoai.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLoai.ForeColor = System.Drawing.Color.White;
            this.txtTenLoai.Location = new System.Drawing.Point(248, 31);
            this.txtTenLoai.Name = "txtTenLoai";
            this.txtTenLoai.Size = new System.Drawing.Size(256, 22);
            this.txtTenLoai.TabIndex = 29;
            this.txtTenLoai.Tag = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(29, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 22);
            this.label9.TabIndex = 30;
            this.label9.Text = "Tên loại";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtHienTrang);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtMoTa);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtMauSac);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtGiaThanhLy);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtNhanHieu);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtDinhGia);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cboTenLoai);
            this.groupBox3.Controls.Add(this.btnThanhLy);
            this.groupBox3.Controls.Add(this.btnXoaSP);
            this.groupBox3.Controls.Add(this.btnSuaSP);
            this.groupBox3.Controls.Add(this.btnThemSP);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtTenSP);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtMaSP);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(12, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(694, 366);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sản Phẩm";
            // 
            // txtHienTrang
            // 
            this.txtHienTrang.AccessibleDescription = "";
            this.txtHienTrang.AccessibleName = "";
            this.txtHienTrang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtHienTrang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHienTrang.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHienTrang.ForeColor = System.Drawing.Color.White;
            this.txtHienTrang.Location = new System.Drawing.Point(143, 244);
            this.txtHienTrang.Multiline = true;
            this.txtHienTrang.Name = "txtHienTrang";
            this.txtHienTrang.Size = new System.Drawing.Size(529, 46);
            this.txtHienTrang.TabIndex = 48;
            this.txtHienTrang.Tag = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(29, 256);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 22);
            this.label11.TabIndex = 49;
            this.label11.Text = "Hiện Trạng";
            // 
            // txtMoTa
            // 
            this.txtMoTa.AccessibleDescription = "";
            this.txtMoTa.AccessibleName = "";
            this.txtMoTa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtMoTa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMoTa.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoTa.ForeColor = System.Drawing.Color.White;
            this.txtMoTa.Location = new System.Drawing.Point(143, 184);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(529, 46);
            this.txtMoTa.TabIndex = 46;
            this.txtMoTa.Tag = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(29, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 22);
            this.label8.TabIndex = 47;
            this.label8.Text = "Mô tả";
            // 
            // txtMauSac
            // 
            this.txtMauSac.AccessibleDescription = "";
            this.txtMauSac.AccessibleName = "";
            this.txtMauSac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtMauSac.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMauSac.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMauSac.ForeColor = System.Drawing.Color.White;
            this.txtMauSac.Location = new System.Drawing.Point(500, 112);
            this.txtMauSac.Name = "txtMauSac";
            this.txtMauSac.Size = new System.Drawing.Size(172, 22);
            this.txtMauSac.TabIndex = 44;
            this.txtMauSac.Tag = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(367, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 22);
            this.label7.TabIndex = 45;
            this.label7.Text = "Màu Sắc";
            // 
            // txtGiaThanhLy
            // 
            this.txtGiaThanhLy.AccessibleDescription = "";
            this.txtGiaThanhLy.AccessibleName = "";
            this.txtGiaThanhLy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtGiaThanhLy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGiaThanhLy.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaThanhLy.ForeColor = System.Drawing.Color.White;
            this.txtGiaThanhLy.Location = new System.Drawing.Point(500, 68);
            this.txtGiaThanhLy.Name = "txtGiaThanhLy";
            this.txtGiaThanhLy.Size = new System.Drawing.Size(172, 22);
            this.txtGiaThanhLy.TabIndex = 42;
            this.txtGiaThanhLy.Tag = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(367, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 22);
            this.label6.TabIndex = 43;
            this.label6.Text = "Giá Thanh Lý";
            // 
            // txtNhanHieu
            // 
            this.txtNhanHieu.AccessibleDescription = "";
            this.txtNhanHieu.AccessibleName = "";
            this.txtNhanHieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtNhanHieu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNhanHieu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhanHieu.ForeColor = System.Drawing.Color.White;
            this.txtNhanHieu.Location = new System.Drawing.Point(500, 31);
            this.txtNhanHieu.Name = "txtNhanHieu";
            this.txtNhanHieu.Size = new System.Drawing.Size(172, 22);
            this.txtNhanHieu.TabIndex = 40;
            this.txtNhanHieu.Tag = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(367, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 22);
            this.label5.TabIndex = 41;
            this.label5.Text = "Nhãn Hiệu";
            // 
            // txtDinhGia
            // 
            this.txtDinhGia.AccessibleDescription = "";
            this.txtDinhGia.AccessibleName = "";
            this.txtDinhGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtDinhGia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDinhGia.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDinhGia.ForeColor = System.Drawing.Color.White;
            this.txtDinhGia.Location = new System.Drawing.Point(122, 139);
            this.txtDinhGia.Name = "txtDinhGia";
            this.txtDinhGia.Size = new System.Drawing.Size(182, 22);
            this.txtDinhGia.TabIndex = 38;
            this.txtDinhGia.Tag = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(29, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 22);
            this.label4.TabIndex = 39;
            this.label4.Text = "ĐỊnh Giá";
            // 
            // cboTenLoai
            // 
            this.cboTenLoai.FormattingEnabled = true;
            this.cboTenLoai.Location = new System.Drawing.Point(122, 58);
            this.cboTenLoai.Name = "cboTenLoai";
            this.cboTenLoai.Size = new System.Drawing.Size(182, 32);
            this.cboTenLoai.TabIndex = 37;
            // 
            // btnThanhLy
            // 
            this.btnThanhLy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnThanhLy.FlatAppearance.BorderSize = 0;
            this.btnThanhLy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhLy.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhLy.ForeColor = System.Drawing.Color.White;
            this.btnThanhLy.Location = new System.Drawing.Point(552, 312);
            this.btnThanhLy.Name = "btnThanhLy";
            this.btnThanhLy.Size = new System.Drawing.Size(99, 38);
            this.btnThanhLy.TabIndex = 36;
            this.btnThanhLy.Text = "Thanh Lý";
            this.btnThanhLy.UseVisualStyleBackColor = false;
            this.btnThanhLy.Click += new System.EventHandler(this.btnThanhLy_Click);
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnXoaSP.FlatAppearance.BorderSize = 0;
            this.btnXoaSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSP.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaSP.ForeColor = System.Drawing.Color.White;
            this.btnXoaSP.Location = new System.Drawing.Point(418, 312);
            this.btnXoaSP.Name = "btnXoaSP";
            this.btnXoaSP.Size = new System.Drawing.Size(99, 38);
            this.btnXoaSP.TabIndex = 36;
            this.btnXoaSP.Text = "Xóa";
            this.btnXoaSP.UseVisualStyleBackColor = false;
            this.btnXoaSP.Click += new System.EventHandler(this.btnXoaSP_Click);
            // 
            // btnSuaSP
            // 
            this.btnSuaSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnSuaSP.FlatAppearance.BorderSize = 0;
            this.btnSuaSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaSP.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaSP.ForeColor = System.Drawing.Color.White;
            this.btnSuaSP.Location = new System.Drawing.Point(276, 312);
            this.btnSuaSP.Name = "btnSuaSP";
            this.btnSuaSP.Size = new System.Drawing.Size(99, 38);
            this.btnSuaSP.TabIndex = 35;
            this.btnSuaSP.Text = "Sửa";
            this.btnSuaSP.UseVisualStyleBackColor = false;
            this.btnSuaSP.Click += new System.EventHandler(this.btnSuaSP_Click);
            // 
            // btnThemSP
            // 
            this.btnThemSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnThemSP.FlatAppearance.BorderSize = 0;
            this.btnThemSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSP.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemSP.ForeColor = System.Drawing.Color.White;
            this.btnThemSP.Location = new System.Drawing.Point(130, 312);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(99, 38);
            this.btnThemSP.TabIndex = 34;
            this.btnThemSP.Text = "Thêm ";
            this.btnThemSP.UseVisualStyleBackColor = false;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 22);
            this.label1.TabIndex = 30;
            this.label1.Text = "Tên Loại";
            // 
            // txtTenSP
            // 
            this.txtTenSP.AccessibleDescription = "";
            this.txtTenSP.AccessibleName = "";
            this.txtTenSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtTenSP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTenSP.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSP.ForeColor = System.Drawing.Color.White;
            this.txtTenSP.Location = new System.Drawing.Point(122, 101);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(182, 22);
            this.txtTenSP.TabIndex = 29;
            this.txtTenSP.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(29, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 22);
            this.label3.TabIndex = 30;
            this.label3.Text = "Tên SP";
            // 
            // txtMaSP
            // 
            this.txtMaSP.AccessibleDescription = "";
            this.txtMaSP.AccessibleName = "";
            this.txtMaSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtMaSP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaSP.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSP.ForeColor = System.Drawing.Color.White;
            this.txtMaSP.Location = new System.Drawing.Point(122, 30);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(182, 22);
            this.txtMaSP.TabIndex = 29;
            this.txtMaSP.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 22);
            this.label2.TabIndex = 30;
            this.label2.Text = "Mã SP";
            // 
            // btnXuat
            // 
            this.btnXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnXuat.FlatAppearance.BorderSize = 0;
            this.btnXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuat.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.ForeColor = System.Drawing.Color.White;
            this.btnXuat.Location = new System.Drawing.Point(1215, 907);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(99, 38);
            this.btnXuat.TabIndex = 35;
            this.btnXuat.Text = "Xuất";
            this.btnXuat.UseVisualStyleBackColor = false;
            // 
            // txtMaLoai
            // 
            this.txtMaLoai.AccessibleDescription = "";
            this.txtMaLoai.AccessibleName = "";
            this.txtMaLoai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.txtMaLoai.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaLoai.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLoai.ForeColor = System.Drawing.Color.White;
            this.txtMaLoai.Location = new System.Drawing.Point(551, 47);
            this.txtMaLoai.Name = "txtMaLoai";
            this.txtMaLoai.Size = new System.Drawing.Size(10, 22);
            this.txtMaLoai.TabIndex = 37;
            this.txtMaLoai.Tag = "";
            this.txtMaLoai.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(535, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 22);
            this.label12.TabIndex = 38;
            // 
            // SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1343, 957);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LVSP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SanPham";
            this.Text = "SanPham";
            this.Load += new System.EventHandler(this.SanPham_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LVSP;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Button btnTatCa;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbDaThanhLy;
        private System.Windows.Forms.CheckBox cbThanhLy;
        private System.Windows.Forms.CheckBox cbDaChuoc;
        private System.Windows.Forms.CheckBox cbQuaHan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtLaiSuat;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView LVLoaiSP;
        private System.Windows.Forms.TextBox txtTenLoai;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnXoaLoaiSP;
        private System.Windows.Forms.Button btnSuaLoaiSP;
        private System.Windows.Forms.Button btnThemLoaiSP;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtHienTrang;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMauSac;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGiaThanhLy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNhanHieu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDinhGia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTenLoai;
        private System.Windows.Forms.Button btnThanhLy;
        private System.Windows.Forms.Button btnXoaSP;
        private System.Windows.Forms.Button btnSuaSP;
        private System.Windows.Forms.Button btnThemSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.TextBox txtMaLoai;
        private System.Windows.Forms.Label label12;
    }
}