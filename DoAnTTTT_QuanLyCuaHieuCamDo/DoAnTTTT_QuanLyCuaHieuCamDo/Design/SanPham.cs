using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;
using DoAnTTTT_QuanLyCuaHieuCamDo.DAO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using LicenseContext = OfficeOpenXml.LicenseContext;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Data.SqlClient;
using System.Data;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.Design
{
    public partial class SanPham : Form
    {
        public SanPham()
        {
            InitializeComponent();
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            
            LoadLoaiSP();
            LoadCboLoaiSP();
            LoadSPQuaHan();
            LoadSanPham();
            btnSuaSP.Enabled = false;
            HienThiThongTin(false);
            ResetButtonSP();

            
        }

        void LoadSPQuaHan()
        {
            DateTime NgayHienTai = DateTime.Now;
            SanPhamDAO.Instance.UpdateSPQuaHan(NgayHienTai);
            LoadSanPham();
        }
        void LoadCboLoaiSP()
        {
            cboTenLoai.DataSource = LoaiSPDAO.Instance.LoadListLoaiSP();
            cboTenLoai.DisplayMember = "TenLoai";
        }
        void LoadSanPham()
        {
            LVSP.Items.Clear();
            List<SanPhamDTO> list = SanPhamDAO.Instance.LoadListSP();
            foreach (SanPhamDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.IDSP.ToString());
                lvitem.SubItems.Add(item.MaSP.ToString());
                lvitem.SubItems.Add(item.TenLoai.ToString());
                lvitem.SubItems.Add(item.TenSP.ToString());
                lvitem.SubItems.Add(item.LaiXuat.ToString());
                lvitem.SubItems.Add(item.DinhGia.ToString());
                lvitem.SubItems.Add(item.GiaThanhLy.ToString());
                lvitem.SubItems.Add(item.MoTa.ToString());
                lvitem.SubItems.Add(item.MauSac.ToString());
                lvitem.SubItems.Add(item.HienTrang.ToString());
                lvitem.SubItems.Add(item.NhanHieu.ToString());
                lvitem.SubItems.Add(item.QuaHan.ToString());
                lvitem.SubItems.Add(item.DaChuoc.ToString());
                lvitem.SubItems.Add(item.ThanhLy.ToString());
                lvitem.SubItems.Add(item.DaThanhLy.ToString());
                LVSP.Items.Add(lvitem);
            }

        }
        void ResetThongTin()
        {
            txtId.Clear();
            txtTenSP.Clear();
            txtDinhGia.Clear();
            txtGiaThanhLy.Clear();
            txtHienTrang.Clear();
            txtNhanHieu.Clear();
            txtMoTa.Clear();
            txtMauSac.Clear();
        }

        void HienThiThongTin(Boolean hien)
        {
            this.txtId.Enabled = hien;
            this.txtTenSP.Enabled = hien;
            this.txtDinhGia.Enabled = hien;
            this.txtGiaThanhLy.Enabled = hien;
            this.txtHienTrang.Enabled = hien;
            this.txtNhanHieu.Enabled = hien;
            this.txtMoTa.Enabled = hien;
            this.txtMauSac.Enabled = hien;
        }
        private void ResetButtonSP()
        {
            btnSuaSP.Enabled = false;
            btnSuaSP.BackColor = Color.Gray;
            btnSuaSP.ForeColor = Color.Black;

            btnThanhLy.Enabled = false;
            btnThanhLy.BackColor = Color.Gray;
            btnThanhLy.ForeColor = Color.Black;

            btnXoaSP.Enabled = false;
            btnXoaSP.BackColor = Color.Gray;
            btnXoaSP.ForeColor = Color.Black;

            btnLuu.Enabled = false;
            btnLuu.BackColor = Color.Gray;
            btnLuu.ForeColor = Color.Black;
        }

        void ResetSP()
        {
            txtId.Clear();
            txtTenSP.Clear();
            txtDinhGia.Clear();
            txtGiaThanhLy.Clear();
            txtMoTa.Clear();
            txtHienTrang.Clear();
            txtHienTrang.Clear();
        }

        void ResetLoaiSP ()
        {
            txtMaLoai.Clear();
            txtTenLoai.Clear();
            txtLaiSuat.Clear();
        }

        void LoadLoaiSP ()
        {
            LVLoaiSP.Items.Clear();
            List<LoaiSPDTO> list = LoaiSPDAO.Instance.LoadListLoaiSP();
            foreach (LoaiSPDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaLoai.ToString());
                lvitem.SubItems.Add(item.TenLoai.ToString());
                lvitem.SubItems.Add(item.LaiXuat.ToString());
                LVLoaiSP.Items.Add(lvitem);
            }
        }

        private void LVSP_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            ListView.SelectedListViewItemCollection lv = this.LVSP.SelectedItems;
            string id = "";
            string masp = "";
            string maloai = "";
            string tensp = "";
            string laixuat = "";
            string dinhgia = "";
            string giathanhly = "";
            string mota = "";
            string mausac = "";
            string hientrang = "";
            string nhanhieu = "";
            foreach (ListViewItem item in lv)
            {
                id += item.SubItems[0].Text;
                masp += item.SubItems[1].Text;
                maloai += item.SubItems[2].Text;
                tensp += item.SubItems[3].Text;
                laixuat += item.SubItems[4].Text;
                dinhgia += item.SubItems[5].Text;
                giathanhly += item.SubItems[6].Text;
                mota += item.SubItems[7].Text;
                mausac += item.SubItems[8].Text;
                hientrang += item.SubItems[9].Text;
                nhanhieu += item.SubItems[10].Text;
            }
            txtId.Text = id.ToString();
            txtMaSP.Text = masp.ToString();
            txtTenSP.Text = tensp.ToString();
            txtTenLoai.Text = maloai.ToString();
            txtLaiSuat.Text = laixuat.ToString();
            txtDinhGia.Text = dinhgia.ToString();
            txtGiaThanhLy.Text = giathanhly.ToString();
            cboTenLoai.Text = maloai.ToString();
            txtMoTa.Text = mota.ToString();
            txtMauSac.Text = mausac.ToString();
            txtHienTrang.Text = hientrang.ToString();
            txtNhanHieu.Text = nhanhieu.ToString();

            btnThemSP.Enabled = true;
            btnThemSP.BackColor = Color.FromArgb(0, 126, 249);
            btnThemSP.ForeColor = Color.White;

            btnSuaSP.Enabled = true;
            btnSuaSP.BackColor = Color.FromArgb(0, 126, 249);
            btnSuaSP.ForeColor = Color.White;

            btnXoaSP.Enabled = true;
            btnXoaSP.BackColor = Color.FromArgb(0, 126, 249);
            btnXoaSP.ForeColor = Color.White;

            btnThanhLy.Enabled = true;
            btnThanhLy.BackColor = Color.FromArgb(0, 126, 249);
            btnThanhLy.ForeColor = Color.White;

            btnLuu.Enabled = false;
            btnLuu.BackColor = Color.Gray;
            btnLuu.ForeColor = Color.Black;
        }
       

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            //btnSuaSP.Enabled = false;
            //btnXoaSP.Enabled = false;
            ResetThongTin();
            HienThiThongTin(true);
            txtId.Focus();
            //btnThemSP.Enabled = true;
            //btnThemSP.BackColor = Color.FromArgb(0, 126, 249);
            //btnThemSP.ForeColor = Color.White;
            btnSuaSP.Enabled = false;
            btnSuaSP.BackColor = Color.Gray;
            btnSuaSP.ForeColor = Color.Black;

            btnXoaSP.Enabled = false;
            btnXoaSP.BackColor = Color.Gray;
            btnXoaSP.ForeColor = Color.Black;

            btnLuu.Enabled = true;
            btnLuu.BackColor = Color.FromArgb(0, 126, 249);
            btnLuu.ForeColor = Color.White;
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            btnXoaSP.Enabled = false;
            btnXoaSP.BackColor = Color.Gray;
            btnXoaSP.ForeColor = Color.Black;

            btnThemSP.Enabled = false;
            btnThemSP.BackColor = Color.Gray;
            btnThemSP.ForeColor = Color.Black;

            btnLuu.Enabled = true;
            btnLuu.BackColor = Color.FromArgb(0, 126, 249);
            btnLuu.ForeColor = Color.White;
            HienThiThongTin(true);
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == null)
                {
                    MessageBox.Show("Vui Lòng Chọn Sản Phẩm Cần Xóa");
                    return;
                }
                string MaSP = txtId.Text;
                DialogResult tb = MessageBox.Show("Bạn Có Muốn Xóa Sản Phẩm Này Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tb == DialogResult.Yes)
                {
                    SanPhamDAO.Instance.DeleteSP(MaSP);
                }
                else
                {
                    return;
                }
                LoadSanPham();
                ResetThongTin();
            }
            catch
            {
                MessageBox.Show("Sản Phẩm Đang Câm Không Thể Xóa !!!");
            }
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(btnThemSP.Enabled == true)
            {
                if (txtId.Text != "" && txtTenSP.Text !="")
                {
                    string MaSP = txtMaSP.Text;
                    string IDSP = txtId.Text;
                    int MaLoai = (cboTenLoai.SelectedItem as LoaiSPDTO).MaLoai;
                    string TenSP = txtTenSP.Text;
                    float DinhGia = (float)Convert.ToDouble(txtDinhGia.Text);
                    float GiaThanhLy = (float)Convert.ToDouble(0);
                    string MoTa = txtMoTa.Text;
                    string MauSac = txtMauSac.Text;
                    string HienTrang = txtHienTrang.Text;
                    string NhanHieu = txtNhanHieu.Text;
                    bool QuaHan = (bool)Convert.ToBoolean(0);
                    bool DaChuoc = (bool)Convert.ToBoolean(0);
                    bool ThanhLy = (bool)Convert.ToBoolean(0);
                    bool DaThanhLy = (bool)Convert.ToBoolean(0);

                    if (SanPhamDAO.Instance.InsertSP(MaSP, MaLoai, TenSP, DinhGia, GiaThanhLy, MoTa, MauSac, HienTrang, NhanHieu, QuaHan, DaChuoc, ThanhLy, DaThanhLy,IDSP))
                    {
                        MessageBox.Show("Thêm Sản Phẩm Thành Công", "Thông Báo");
                        ResetSP();
                    }
                    else
                    {
                        MessageBox.Show("Thêm Thất Bại! Vui Lòng Nhập Lại", "Thông Báo");
                    }
                    LoadSanPham();
                }
                else
                {
                    MessageBox.Show("Không được để trống Tên", "thông báo");
                    txtTenSP.Focus();
                }
                ResetThongTin();
                
            }
            else if(btnSuaSP.Enabled == true)
            {
                string MaSP = txtMaSP.Text;
                string IDSP = txtId.Text;
                int MaLoai = (cboTenLoai.SelectedItem as LoaiSPDTO).MaLoai;
                string TenSP = txtTenSP.Text;
                float DinhGia = (float)Convert.ToDouble(txtDinhGia.Text);
                float GiaThanhLy = (float)Convert.ToDouble(txtGiaThanhLy.Text);
                string MoTa = txtMoTa.Text;
                string MauSac = txtMauSac.Text;
                string HienTrang = txtHienTrang.Text;
                string NhanHieu = txtNhanHieu.Text;
                if (MaSP != "" && TenSP !=""  )
                {

                    if (SanPhamDAO.Instance.UpdateSP(MaSP, MaLoai, TenSP, DinhGia, GiaThanhLy, MoTa, MauSac, HienTrang, NhanHieu,IDSP))
                    {
                        MessageBox.Show("Sửa Thành Công");
                        LoadSanPham();
                    }
                    else
                    {
                        MessageBox.Show("Sửa Thất bại, Vui lòng nhập lại !", "thông Báo");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Vui Lòng Sửa Đầy Đủ Thông Tin");
                    return;
                }
                ResetButtonSP();
                btnThemSP.Enabled = true;
                btnThemSP.BackColor = Color.FromArgb(0, 126, 249);
                btnThemSP.ForeColor = Color.White;
            }
        }
        private void btnThanhLy_Click(object sender, EventArgs e)
        {
            string MaSP = txtMaSP.Text;
            double GiaThanhLy = (double)Convert.ToDouble(txtGiaThanhLy.Text);
            bool ThanhLy = (bool)Convert.ToBoolean(1);
            if(txtGiaThanhLy.Text != "0")
            {
                if (SanPhamDAO.Instance.UpdateTienTL(MaSP, GiaThanhLy))
                {
                    if (SanPhamDAO.Instance.ThanhLySP(MaSP,ThanhLy))
                    {
                        MessageBox.Show("Đã Thanh Lý Thành Công");
                        LoadSanPham();
                    }
                    else
                    {
                        MessageBox.Show("Thanh Lý Thất Bại", "thông Báo");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Thêm Giá Thanh Lý");
            }
        }

        // LOẠI SẢN PHẨM
        private void LVLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection lv = this.LVLoaiSP.SelectedItems;
            string tenloai = "";
            int maloai = 0;
            string laixuat = "";
            foreach (ListViewItem item in lv)
            {
                maloai +=Convert.ToInt32(item.SubItems[0].Text);
                tenloai += item.SubItems[1].Text;
                laixuat += item.SubItems[2].Text;
            }
            txtMaLoai.Text = maloai.ToString();
            txtTenLoai.Text = tenloai.ToString();
            txtLaiSuat.Text = laixuat.ToString();
            
        }
        private void btnThemLoaiSP_Click(object sender, EventArgs e)
        {
            if (txtTenLoai.Text != "")
            {
                string TenLoai = txtTenLoai.Text;
                //int MaLoai = (int)Convert.ToInt32(txtMaLoai.Text);
                float LaiXuat = (float)Convert.ToDouble(txtLaiSuat.Text);
                if (LoaiSPDAO.Instance.InsertLoaiSP( TenLoai, LaiXuat))
                {
                    MessageBox.Show("Thêm Loại Sản Phẩm Thành Công", "Thông Báo");
                    ResetLoaiSP();
                    LoadCboLoaiSP();
                }
                else
                {
                    MessageBox.Show("Thêm Thất Bại! Vui Lòng Nhập Lại", "Thông Báo");
                }
                LoadLoaiSP();
            }
            else
            {
                MessageBox.Show("Không được để trống Tên", "thông báo");
                txtTenLoai.Focus();
            }
        }

        private void btnSuaLoaiSP_Click(object sender, EventArgs e)
        {
            string TenLoai = txtTenLoai.Text;
            int MaLoai = (int)Convert.ToInt32(txtMaLoai.Text);
            float LaiXuat = (float)Convert.ToDouble(txtLaiSuat.Text);
            if (txtMaLoai.Text != "")
            {

                if (LoaiSPDAO.Instance.UpdateLoaiSP( MaLoai, TenLoai , LaiXuat))
                {
                    MessageBox.Show("Sửa Thành Công");
                    LoadLoaiSP();
                }
                else
                {
                    MessageBox.Show("Sửa Thất bại, Vui lòng nhập lại !", "thông Báo");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin");
                return;
            }
        }

        private void btnXoaLoaiSP_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaLoai.Text == null)
                {
                    MessageBox.Show("Vui Lòng Chọn Loại Sản Phẩm Cần Xóa");
                    return;
                }
                int LoaiSP =(int)Convert.ToInt32(txtMaLoai.Text);
                DialogResult tb = MessageBox.Show("Bạn Có Muốn Xóa Loại Sản Phẩm Này Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tb == DialogResult.Yes)
                {
                    LoaiSPDAO.Instance.DeleteLoaiSP(LoaiSP);
                }
                else
                {
                    return;
                }
                LoadLoaiSP();
            }
            catch
            {
                MessageBox.Show("Không Thể Xóa !!");
            }
        }

        //private void btnLoc_Click(object sender, EventArgs e)
        //{
        //    bool ThanhLy = (bool)Convert.ToBoolean(rboThanhLy.Checked );
        //    bool QuaHan = (bool)Convert.ToBoolean(rboQuaHan.Checked );
        //    bool DaChuoc = (bool)Convert.ToBoolean(rboDaChuoc.Checked );
        //    bool DaThanhLy = (bool)Convert.ToBoolean(rboDaThanhLy.Checked);
        //    LVSP.Items.Clear();
        //    List<SanPhamDTO> list = SanPhamDAO.Instance.TimKiem(ThanhLy,QuaHan, DaChuoc,DaThanhLy);
        //    foreach (SanPhamDTO item in list)
        //    {
        //        ListViewItem lvitem = new ListViewItem(item.MaSP.ToString());
        //        lvitem.SubItems.Add(item.TenLoai.ToString());
        //        lvitem.SubItems.Add(item.TenSP.ToString());
        //        lvitem.SubItems.Add(item.DinhGia.ToString());
        //        lvitem.SubItems.Add(item.GiaThanhLy.ToString());
        //        lvitem.SubItems.Add(item.MoTa.ToString());
        //        lvitem.SubItems.Add(item.MauSac.ToString());
        //        lvitem.SubItems.Add(item.HienTrang.ToString());
        //        lvitem.SubItems.Add(item.NhanHieu.ToString());
        //        lvitem.SubItems.Add(item.QuaHan.ToString());
        //        lvitem.SubItems.Add(item.DaChuoc.ToString());
        //        lvitem.SubItems.Add(item.ThanhLy.ToString());
        //        lvitem.SubItems.Add(item.DaThanhLy.ToString());
        //        LVSP.Items.Add(lvitem);
        //    }
        //}

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if(rboDaChuoc.Checked==true)
            {
                
                string filePath = "";
                // tạo SaveFileDialog để lưu file excel
                SaveFileDialog dialog = new SaveFileDialog();

                // chỉ lọc ra các file có định dạng Excel
                dialog.Filter = "Excel Workbook|*.xls";

                // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = dialog.FileName;
                }

                // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                    return;
                }

                try
                {
                    ExcelPackage.LicenseContext = LicenseContext.Commercial;
                    using (ExcelPackage p = new ExcelPackage())
                    {
                        // đặt tên người tạo file
                        p.Workbook.Properties.Author = "NhiAn";

                        // đặt tiêu đề cho file
                        p.Workbook.Properties.Title = "Báo cáo";

                        //Tạo một sheet để làm việc trên đó
                        p.Workbook.Worksheets.Add("NhiAn");

                        // lấy sheet vừa add ra để thao tác
                        ExcelWorksheet ws = p.Workbook.Worksheets[0];

                        // đặt tên cho sheet
                        ws.Name = "NhiAn";
                        // fontsize mặc định cho cả sheet
                        ws.Cells.Style.Font.Size = 13;
                        // font family mặc định cho cả sheet
                        ws.Cells.Style.Font.Name = "Calibri";

                        // Tạo danh sách các column header
                        string[] arrColumnHeader = {
                                                "Mã sản phẩm",
                                                "Tên loại",
                                                "Tên sản phẩm",
                                                "Định giá",
                                                //"Giá thanh lý",
                                                "Mô tả",
                                                "Màu sắc",
                                                "Hiện trạng",
                                                "Nhãn hiệu"
                };

                        // lấy ra số lượng cột cần dùng dựa vào số lượng header
                        var countColHeader = arrColumnHeader.Count();

                        // merge các column lại từ column 1 đến số column header
                        // gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                        ws.Cells[1, 1].Value = "Thống kê thông tin sản phẩm đã chuộc";
                        ws.Cells[1, 1, 1, countColHeader].Merge = true;
                        // in đậm
                        ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                        // căn giữa
                        ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        int colIndex = 1;
                        int rowIndex = 2;

                        //tạo các header từ column header đã tạo từ bên trên
                        foreach (var item in arrColumnHeader)
                        {
                            var cell = ws.Cells[rowIndex, colIndex];

                            //set màu thành gray
                            var fill = cell.Style.Fill;
                            fill.PatternType = ExcelFillStyle.Solid;
                            fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                            //căn chỉnh các border
                            var border = cell.Style.Border;
                            border.Bottom.Style =
                                border.Top.Style =
                                border.Left.Style =
                                border.Right.Style = ExcelBorderStyle.Thin;

                            //gán giá trị
                            cell.Value = item;

                            colIndex++;
                        }

                        // lấy ra danh sách UserInfo từ ItemSource của DataGrid
                        List<SanPhamDTO> ListBC = SanPhamDAO.Instance.LoadListSPDaChuoc();
                        double? tongtien = 0;
                        // với mỗi item trong danh sách sẽ ghi trên 1 dòng
                        foreach (var item in ListBC)
                        {
                            // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                            colIndex = 1;

                            // rowIndex tương ứng từng dòng dữ liệu
                            rowIndex++;

                            //gán giá trị cho từng cell                      
                            ws.Cells[rowIndex, colIndex++].Value = item.MaSP;
                            ws.Cells[rowIndex, colIndex++].Value = item.TenLoai;
                            ws.Cells[rowIndex, colIndex++].Value = item.TenSP;
                            ws.Cells[rowIndex, colIndex++].Value = item.DinhGia;
                            ws.Cells[rowIndex, colIndex++].Value = item.MoTa;
                            ws.Cells[rowIndex, colIndex++].Value = item.MauSac;
                            ws.Cells[rowIndex, colIndex++].Value = item.HienTrang;
                            ws.Cells[rowIndex, colIndex++].Value = item.NhanHieu;
                            tongtien = tongtien + item.DinhGia;
                            // lưu ý phải .ToShortDateString để dữ liệu khi in ra Excel là ngày như ta vẫn thấy.Nếu không sẽ ra tổng số :v


                        }
                        ws.Cells[rowIndex + 1, 4, rowIndex + 1, countColHeader].Merge = true;
                        //Lưu file lại
                        Byte[] bin = p.GetAsByteArray();
                        File.WriteAllBytes(filePath, bin);
                    }
                    MessageBox.Show("Xuất excel thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi luôn, mà chưa biết lỗi gì");
                }
            }
            else if(rboThanhLy.Checked==true)
            {
                string filePath = "";
                // tạo SaveFileDialog để lưu file excel
                SaveFileDialog dialog = new SaveFileDialog();

                // chỉ lọc ra các file có định dạng Excel
                dialog.Filter = "Excel Workbook|*.xls";

                // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = dialog.FileName;
                }

                // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                    return;
                }

                try
                {
                    ExcelPackage.LicenseContext = LicenseContext.Commercial;
                    using (ExcelPackage p = new ExcelPackage())
                    {
                        // đặt tên người tạo file
                        p.Workbook.Properties.Author = "NhiAn";

                        // đặt tiêu đề cho file
                        p.Workbook.Properties.Title = "Báo cáo";

                        //Tạo một sheet để làm việc trên đó
                        p.Workbook.Worksheets.Add("NhiAn");

                        // lấy sheet vừa add ra để thao tác
                        ExcelWorksheet ws = p.Workbook.Worksheets[0];

                        // đặt tên cho sheet
                        ws.Name = "NhiAn";
                        // fontsize mặc định cho cả sheet
                        ws.Cells.Style.Font.Size = 13;
                        // font family mặc định cho cả sheet
                        ws.Cells.Style.Font.Name = "Calibri";

                        // Tạo danh sách các column header
                        string[] arrColumnHeader = {
                                                "Mã sản phẩm",
                                                "Tên loại",
                                                "Tên sản phẩm",
                                                "Định giá",
                                                "Giá thanh lý",
                                                "Mô tả",
                                                "Màu sắc",
                                                "Hiện trạng",
                                                "Nhãn hiệu"
                };

                        // lấy ra số lượng cột cần dùng dựa vào số lượng header
                        var countColHeader = arrColumnHeader.Count();

                        // merge các column lại từ column 1 đến số column header
                        // gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                        ws.Cells[1, 1].Value = "Thống kê thông tin sản phẩm đã chuộc";
                        ws.Cells[1, 1, 1, countColHeader].Merge = true;
                        // in đậm
                        ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                        // căn giữa
                        ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        int colIndex = 1;
                        int rowIndex = 2;

                        //tạo các header từ column header đã tạo từ bên trên
                        foreach (var item in arrColumnHeader)
                        {
                            var cell = ws.Cells[rowIndex, colIndex];

                            //set màu thành gray
                            var fill = cell.Style.Fill;
                            fill.PatternType = ExcelFillStyle.Solid;
                            fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                            //căn chỉnh các border
                            var border = cell.Style.Border;
                            border.Bottom.Style =
                                border.Top.Style =
                                border.Left.Style =
                                border.Right.Style = ExcelBorderStyle.Thin;

                            //gán giá trị
                            cell.Value = item;

                            colIndex++;
                        }

                        // lấy ra danh sách UserInfo từ ItemSource của DataGrid
                        List<SanPhamDTO> ListBC = SanPhamDAO.Instance.LoadListSPThanhLy();
                        double? tongtien = 0;
                        // với mỗi item trong danh sách sẽ ghi trên 1 dòng
                        foreach (var item in ListBC)
                        {
                            // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                            colIndex = 1;

                            // rowIndex tương ứng từng dòng dữ liệu
                            rowIndex++;

                            //gán giá trị cho từng cell                      
                            ws.Cells[rowIndex, colIndex++].Value = item.MaSP;
                            ws.Cells[rowIndex, colIndex++].Value = item.TenLoai;
                            ws.Cells[rowIndex, colIndex++].Value = item.TenSP;
                            ws.Cells[rowIndex, colIndex++].Value = item.DinhGia;
                            ws.Cells[rowIndex, colIndex++].Value = item.GiaThanhLy;
                            ws.Cells[rowIndex, colIndex++].Value = item.MoTa;
                            ws.Cells[rowIndex, colIndex++].Value = item.MauSac;
                            ws.Cells[rowIndex, colIndex++].Value = item.HienTrang;
                            ws.Cells[rowIndex, colIndex++].Value = item.NhanHieu;
                            tongtien = tongtien + item.DinhGia;
                            // lưu ý phải .ToShortDateString để dữ liệu khi in ra Excel là ngày như ta vẫn thấy.Nếu không sẽ ra tổng số :v


                        }
                        ws.Cells[rowIndex + 1, 4, rowIndex + 1, countColHeader].Merge = true;
                        //Lưu file lại
                        Byte[] bin = p.GetAsByteArray();
                        File.WriteAllBytes(filePath, bin);
                    }
                    MessageBox.Show("Xuất excel thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi luôn, mà chưa biết lỗi gì");
                }
            }
            else if(rboQuaHan.Checked==true)
            {

                {
                    string filePath = "";
                    // tạo SaveFileDialog để lưu file excel
                    SaveFileDialog dialog = new SaveFileDialog();

                    // chỉ lọc ra các file có định dạng Excel
                    dialog.Filter = "Excel Workbook|*.xls";

                    // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = dialog.FileName;
                    }

                    // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
                    if (string.IsNullOrEmpty(filePath))
                    {
                        MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                        return;
                    }

                    try
                    {
                        ExcelPackage.LicenseContext = LicenseContext.Commercial;
                        using (ExcelPackage p = new ExcelPackage())
                        {
                            // đặt tên người tạo file
                            p.Workbook.Properties.Author = "NhiAn";

                            // đặt tiêu đề cho file
                            p.Workbook.Properties.Title = "Báo cáo";

                            //Tạo một sheet để làm việc trên đó
                            p.Workbook.Worksheets.Add("NhiAn");

                            // lấy sheet vừa add ra để thao tác
                            ExcelWorksheet ws = p.Workbook.Worksheets[0];

                            // đặt tên cho sheet
                            ws.Name = "NhiAn";
                            // fontsize mặc định cho cả sheet
                            ws.Cells.Style.Font.Size = 13;
                            // font family mặc định cho cả sheet
                            ws.Cells.Style.Font.Name = "Calibri";

                            // Tạo danh sách các column header
                            string[] arrColumnHeader = {
                                                "Mã sản phẩm",
                                                "Tên loại",
                                                "Tên sản phẩm",
                                                "Định giá",
                                                //"Giá thanh lý",
                                                "Mô tả",
                                                "Màu sắc",
                                                "Hiện trạng",
                                                "Nhãn hiệu"
                };

                            // lấy ra số lượng cột cần dùng dựa vào số lượng header
                            var countColHeader = arrColumnHeader.Count();

                            // merge các column lại từ column 1 đến số column header
                            // gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                            ws.Cells[1, 1].Value = "Thống kê thông tin sản phẩm đã quá hạn";
                            ws.Cells[1, 1, 1, countColHeader].Merge = true;
                            // in đậm
                            ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                            // căn giữa
                            ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            int colIndex = 1;
                            int rowIndex = 2;

                            //tạo các header từ column header đã tạo từ bên trên
                            foreach (var item in arrColumnHeader)
                            {
                                var cell = ws.Cells[rowIndex, colIndex];

                                //set màu thành gray
                                var fill = cell.Style.Fill;
                                fill.PatternType = ExcelFillStyle.Solid;
                                fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                                //căn chỉnh các border
                                var border = cell.Style.Border;
                                border.Bottom.Style =
                                    border.Top.Style =
                                    border.Left.Style =
                                    border.Right.Style = ExcelBorderStyle.Thin;

                                //gán giá trị
                                cell.Value = item;

                                colIndex++;
                            }

                            // lấy ra danh sách UserInfo từ ItemSource của DataGrid
                            List<SanPhamDTO> ListBC = SanPhamDAO.Instance.LoadListSPQuaHan();
                            double? tongtien = 0;
                            // với mỗi item trong danh sách sẽ ghi trên 1 dòng
                            foreach (var item in ListBC)
                            {
                                // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                                colIndex = 1;

                                // rowIndex tương ứng từng dòng dữ liệu
                                rowIndex++;

                                //gán giá trị cho từng cell                      
                                ws.Cells[rowIndex, colIndex++].Value = item.MaSP;
                                ws.Cells[rowIndex, colIndex++].Value = item.TenLoai;
                                ws.Cells[rowIndex, colIndex++].Value = item.TenSP;
                                ws.Cells[rowIndex, colIndex++].Value = item.DinhGia;
                                ws.Cells[rowIndex, colIndex++].Value = item.MoTa;
                                ws.Cells[rowIndex, colIndex++].Value = item.MauSac;
                                ws.Cells[rowIndex, colIndex++].Value = item.HienTrang;
                                ws.Cells[rowIndex, colIndex++].Value = item.NhanHieu;
                                tongtien = tongtien + item.DinhGia;
                                // lưu ý phải .ToShortDateString để dữ liệu khi in ra Excel là ngày như ta vẫn thấy.Nếu không sẽ ra tổng số :v


                            }
                            ws.Cells[rowIndex + 1, 4, rowIndex + 1, countColHeader].Merge = true;
                            //Lưu file lại
                            Byte[] bin = p.GetAsByteArray();
                            File.WriteAllBytes(filePath, bin);
                        }
                        MessageBox.Show("Xuất excel thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi luôn, mà chưa biết lỗi gì");
                    }
                }
            }
            else if(rboDaThanhLy.Checked==true)
            {

                {

                    {
                        string filePath = "";
                        // tạo SaveFileDialog để lưu file excel
                        SaveFileDialog dialog = new SaveFileDialog();

                        // chỉ lọc ra các file có định dạng Excel
                        dialog.Filter = "Excel Workbook|*.xls";

                        // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            filePath = dialog.FileName;
                        }

                        // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
                        if (string.IsNullOrEmpty(filePath))
                        {
                            MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                            return;
                        }

                        try
                        {
                            ExcelPackage.LicenseContext = LicenseContext.Commercial;
                            using (ExcelPackage p = new ExcelPackage())
                            {
                                // đặt tên người tạo file
                                p.Workbook.Properties.Author = "NhiAn";

                                // đặt tiêu đề cho file
                                p.Workbook.Properties.Title = "Báo cáo";

                                //Tạo một sheet để làm việc trên đó
                                p.Workbook.Worksheets.Add("NhiAn");

                                // lấy sheet vừa add ra để thao tác
                                ExcelWorksheet ws = p.Workbook.Worksheets[0];

                                // đặt tên cho sheet
                                ws.Name = "NhiAn";
                                // fontsize mặc định cho cả sheet
                                ws.Cells.Style.Font.Size = 13;
                                // font family mặc định cho cả sheet
                                ws.Cells.Style.Font.Name = "Calibri";

                                // Tạo danh sách các column header
                                string[] arrColumnHeader = {
                                                "Mã sản phẩm",
                                                "Tên loại",
                                                "Tên sản phẩm",
                                                "Định giá",
                                                "Giá thanh lý",
                                                "Mô tả",
                                                "Màu sắc",
                                                "Hiện trạng",
                                                "Nhãn hiệu"
                };

                                // lấy ra số lượng cột cần dùng dựa vào số lượng header
                                var countColHeader = arrColumnHeader.Count();

                                // merge các column lại từ column 1 đến số column header
                                // gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                                ws.Cells[1, 1].Value = "Thống kê thông tin sản phẩm đã chuộc";
                                ws.Cells[1, 1, 1, countColHeader].Merge = true;
                                // in đậm
                                ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                                // căn giữa
                                ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                                int colIndex = 1;
                                int rowIndex = 2;

                                //tạo các header từ column header đã tạo từ bên trên
                                foreach (var item in arrColumnHeader)
                                {
                                    var cell = ws.Cells[rowIndex, colIndex];

                                    //set màu thành gray
                                    var fill = cell.Style.Fill;
                                    fill.PatternType = ExcelFillStyle.Solid;
                                    fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                                    //căn chỉnh các border
                                    var border = cell.Style.Border;
                                    border.Bottom.Style =
                                        border.Top.Style =
                                        border.Left.Style =
                                        border.Right.Style = ExcelBorderStyle.Thin;

                                    //gán giá trị
                                    cell.Value = item;

                                    colIndex++;
                                }

                                // lấy ra danh sách UserInfo từ ItemSource của DataGrid
                                List<SanPhamDTO> ListBC = SanPhamDAO.Instance.LoadListSPDaThanhLy();
                                double? tongtien = 0;
                                // với mỗi item trong danh sách sẽ ghi trên 1 dòng
                                foreach (var item in ListBC)
                                {
                                    // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                                    colIndex = 1;

                                    // rowIndex tương ứng từng dòng dữ liệu
                                    rowIndex++;

                                    //gán giá trị cho từng cell                      
                                    ws.Cells[rowIndex, colIndex++].Value = item.MaSP;
                                    ws.Cells[rowIndex, colIndex++].Value = item.TenLoai;
                                    ws.Cells[rowIndex, colIndex++].Value = item.TenSP;
                                    ws.Cells[rowIndex, colIndex++].Value = item.DinhGia;
                                    ws.Cells[rowIndex, colIndex++].Value = item.GiaThanhLy;
                                    ws.Cells[rowIndex, colIndex++].Value = item.MoTa;
                                    ws.Cells[rowIndex, colIndex++].Value = item.MauSac;
                                    ws.Cells[rowIndex, colIndex++].Value = item.HienTrang;
                                    ws.Cells[rowIndex, colIndex++].Value = item.NhanHieu;
                                    tongtien = tongtien + item.DinhGia;
                                    // lưu ý phải .ToShortDateString để dữ liệu khi in ra Excel là ngày như ta vẫn thấy.Nếu không sẽ ra tổng số :v


                                }
                                ws.Cells[rowIndex + 1, 4, rowIndex + 1, countColHeader].Merge = true;
                                //Lưu file lại
                                Byte[] bin = p.GetAsByteArray();
                                File.WriteAllBytes(filePath, bin);
                            }
                            MessageBox.Show("Xuất excel thành công!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Có lỗi luôn, mà chưa biết lỗi gì");
                        }
                    }
                }
            }
            else if (rboDangCam.Checked == true)
            {

                {

                    {
                        string filePath = "";
                        // tạo SaveFileDialog để lưu file excel
                        SaveFileDialog dialog = new SaveFileDialog();

                        // chỉ lọc ra các file có định dạng Excel
                        dialog.Filter = "Excel Workbook|*.xls";

                        // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            filePath = dialog.FileName;
                        }

                        // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
                        if (string.IsNullOrEmpty(filePath))
                        {
                            MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                            return;
                        }

                        try
                        {
                            ExcelPackage.LicenseContext = LicenseContext.Commercial;
                            using (ExcelPackage p = new ExcelPackage())
                            {
                                // đặt tên người tạo file
                                p.Workbook.Properties.Author = "NhiAn";

                                // đặt tiêu đề cho file
                                p.Workbook.Properties.Title = "Báo cáo";

                                //Tạo một sheet để làm việc trên đó
                                p.Workbook.Worksheets.Add("NhiAn");

                                // lấy sheet vừa add ra để thao tác
                                ExcelWorksheet ws = p.Workbook.Worksheets[0];

                                // đặt tên cho sheet
                                ws.Name = "NhiAn";
                                // fontsize mặc định cho cả sheet
                                ws.Cells.Style.Font.Size = 13;
                                // font family mặc định cho cả sheet
                                ws.Cells.Style.Font.Name = "Calibri";

                                // Tạo danh sách các column header
                                string[] arrColumnHeader = {
                                                "Mã sản phẩm",
                                                "Tên loại",
                                                "Tên sản phẩm",
                                                "Định giá",
                                                "Giá thanh lý",
                                                "Mô tả",
                                                "Màu sắc",
                                                "Hiện trạng",
                                                "Nhãn hiệu"
                };

                                // lấy ra số lượng cột cần dùng dựa vào số lượng header
                                var countColHeader = arrColumnHeader.Count();

                                // merge các column lại từ column 1 đến số column header
                                // gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                                ws.Cells[1, 1].Value = "Thống kê thông tin sản phẩm đang cầm";
                                ws.Cells[1, 1, 1, countColHeader].Merge = true;
                                // in đậm
                                ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                                // căn giữa
                                ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                                int colIndex = 1;
                                int rowIndex = 2;

                                //tạo các header từ column header đã tạo từ bên trên
                                foreach (var item in arrColumnHeader)
                                {
                                    var cell = ws.Cells[rowIndex, colIndex];

                                    //set màu thành gray
                                    var fill = cell.Style.Fill;
                                    fill.PatternType = ExcelFillStyle.Solid;
                                    fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                                    //căn chỉnh các border
                                    var border = cell.Style.Border;
                                    border.Bottom.Style =
                                        border.Top.Style =
                                        border.Left.Style =
                                        border.Right.Style = ExcelBorderStyle.Thin;

                                    //gán giá trị
                                    cell.Value = item;

                                    colIndex++;
                                }

                                // lấy ra danh sách UserInfo từ ItemSource của DataGrid
                                List<SanPhamDTO> ListBC = SanPhamDAO.Instance.LoadListSPDangCam();
                                double? tongtien = 0;
                                // với mỗi item trong danh sách sẽ ghi trên 1 dòng
                                foreach (var item in ListBC)
                                {
                                    // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                                    colIndex = 1;

                                    // rowIndex tương ứng từng dòng dữ liệu
                                    rowIndex++;

                                    //gán giá trị cho từng cell                      
                                    ws.Cells[rowIndex, colIndex++].Value = item.MaSP;
                                    ws.Cells[rowIndex, colIndex++].Value = item.TenLoai;
                                    ws.Cells[rowIndex, colIndex++].Value = item.TenSP;
                                    ws.Cells[rowIndex, colIndex++].Value = item.DinhGia;
                                    ws.Cells[rowIndex, colIndex++].Value = item.GiaThanhLy;
                                    ws.Cells[rowIndex, colIndex++].Value = item.MoTa;
                                    ws.Cells[rowIndex, colIndex++].Value = item.MauSac;
                                    ws.Cells[rowIndex, colIndex++].Value = item.HienTrang;
                                    ws.Cells[rowIndex, colIndex++].Value = item.NhanHieu;
                                    tongtien = tongtien + item.DinhGia;
                                    // lưu ý phải .ToShortDateString để dữ liệu khi in ra Excel là ngày như ta vẫn thấy.Nếu không sẽ ra tổng số :v


                                }
                                ws.Cells[rowIndex + 1, 4, rowIndex + 1, countColHeader].Merge = true;
                                //Lưu file lại
                                Byte[] bin = p.GetAsByteArray();
                                File.WriteAllBytes(filePath, bin);
                            }
                            MessageBox.Show("Xuất excel thành công!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Có lỗi luôn, mà chưa biết lỗi gì");
                        }
                    }
                }
            }
            else
            {
                string filePath = "";
                // tạo SaveFileDialog để lưu file excel
                SaveFileDialog dialog = new SaveFileDialog();

                // chỉ lọc ra các file có định dạng Excel
                dialog.Filter = "Excel Workbook|*.xls";

                // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = dialog.FileName;
                }

                // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                    return;
                }

                try
                {
                    ExcelPackage.LicenseContext = LicenseContext.Commercial;
                    using (ExcelPackage p = new ExcelPackage())
                    {
                        // đặt tên người tạo file
                        p.Workbook.Properties.Author = "NhiAn";

                        // đặt tiêu đề cho file
                        p.Workbook.Properties.Title = "Báo cáo";

                        //Tạo một sheet để làm việc trên đó
                        p.Workbook.Worksheets.Add("NhiAn");

                        // lấy sheet vừa add ra để thao tác
                        ExcelWorksheet ws = p.Workbook.Worksheets[0];

                        // đặt tên cho sheet
                        ws.Name = "NhiAn";
                        // fontsize mặc định cho cả sheet
                        ws.Cells.Style.Font.Size = 13;
                        // font family mặc định cho cả sheet
                        ws.Cells.Style.Font.Name = "Calibri";

                        // Tạo danh sách các column header
                        string[] arrColumnHeader = {
                                                "Mã sản phẩm",
                                                "Tên loại",
                                                "Tên sản phẩm",
                                                "Định giá",
                                                "Giá thanh lý",
                                                "Mô tả",
                                                "Màu sắc",
                                                "Hiện trạng",
                                                "Nhãn hiệu"
                };

                        // lấy ra số lượng cột cần dùng dựa vào số lượng header
                        var countColHeader = arrColumnHeader.Count();

                        // merge các column lại từ column 1 đến số column header
                        // gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                        ws.Cells[1, 1].Value = "Thống kê thông tin sản phẩm";
                        ws.Cells[1, 1, 1, countColHeader].Merge = true;
                        // in đậm
                        ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                        // căn giữa
                        ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        int colIndex = 1;
                        int rowIndex = 2;

                        //tạo các header từ column header đã tạo từ bên trên
                        foreach (var item in arrColumnHeader)
                        {
                            var cell = ws.Cells[rowIndex, colIndex];

                            //set màu thành gray
                            var fill = cell.Style.Fill;
                            fill.PatternType = ExcelFillStyle.Solid;
                            fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                            //căn chỉnh các border
                            var border = cell.Style.Border;
                            border.Bottom.Style =
                                border.Top.Style =
                                border.Left.Style =
                                border.Right.Style = ExcelBorderStyle.Thin;

                            //gán giá trị
                            cell.Value = item;

                            colIndex++;
                        }

                        // lấy ra danh sách UserInfo từ ItemSource của DataGrid
                        List<SanPhamDTO> ListBC = SanPhamDAO.Instance.LoadListSP();
                        double? tongtien = 0;
                        // với mỗi item trong danh sách sẽ ghi trên 1 dòng
                        foreach (var item in ListBC)
                        {
                            // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                            colIndex = 1;

                            // rowIndex tương ứng từng dòng dữ liệu
                            rowIndex++;

                            //gán giá trị cho từng cell                      
                            ws.Cells[rowIndex, colIndex++].Value = item.MaSP;
                            ws.Cells[rowIndex, colIndex++].Value = item.TenLoai;
                            ws.Cells[rowIndex, colIndex++].Value = item.TenSP;
                            ws.Cells[rowIndex, colIndex++].Value = item.DinhGia;
                            ws.Cells[rowIndex, colIndex++].Value = item.GiaThanhLy;
                            ws.Cells[rowIndex, colIndex++].Value = item.MoTa;
                            ws.Cells[rowIndex, colIndex++].Value = item.MauSac;
                            ws.Cells[rowIndex, colIndex++].Value = item.HienTrang;
                            ws.Cells[rowIndex, colIndex++].Value = item.NhanHieu;
                            //tongtien = tongtien + item.DinhGia;
                            // lưu ý phải .ToShortDateString để dữ liệu khi in ra Excel là ngày như ta vẫn thấy.Nếu không sẽ ra tổng số :v


                        }
                        //ws.Cells[rowIndex + 1, 8, rowIndex + 1, countColHeader].Merge = true;
                        //ws.Cells[rowIndex + 1, 8].Value = "Tổng tiền cầm: " + tongtien;
                        //Lưu file lại
                        Byte[] bin = p.GetAsByteArray();
                        File.WriteAllBytes(filePath, bin);
                    }
                    MessageBox.Show("Xuất excel thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi luôn, mà chưa biết lỗi gì");
                }
            }
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            rboDaChuoc.Checked = false;
            rboDaThanhLy.Checked = false;
            rboQuaHan.Checked = false;
            rboThanhLy.Checked = false;
            rboDangCam.Checked = false;
            LoadSanPham();
        }

        private void rboDaChuoc_CheckedChanged(object sender, EventArgs e)
        {
            LVSP.Items.Clear();
            List<SanPhamDTO> list = SanPhamDAO.Instance.LoadListSPDaChuoc();
            foreach (SanPhamDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.IDSP.ToString());
                lvitem.SubItems.Add(item.MaSP.ToString());
                lvitem.SubItems.Add(item.TenLoai.ToString());
                lvitem.SubItems.Add(item.TenSP.ToString());
                lvitem.SubItems.Add(item.LaiXuat.ToString());
                lvitem.SubItems.Add(item.DinhGia.ToString());
                lvitem.SubItems.Add(item.GiaThanhLy.ToString());
                lvitem.SubItems.Add(item.MoTa.ToString());
                lvitem.SubItems.Add(item.MauSac.ToString());
                lvitem.SubItems.Add(item.HienTrang.ToString());
                lvitem.SubItems.Add(item.NhanHieu.ToString());
                lvitem.SubItems.Add(item.QuaHan.ToString());
                lvitem.SubItems.Add(item.DaChuoc.ToString());
                lvitem.SubItems.Add(item.ThanhLy.ToString());
                lvitem.SubItems.Add(item.DaThanhLy.ToString());
                LVSP.Items.Add(lvitem);
            }
        }

        private void rboQuaHan_CheckedChanged(object sender, EventArgs e)
        {
            LVSP.Items.Clear();
            List<SanPhamDTO> list = SanPhamDAO.Instance.LoadListSPQuaHan();
            foreach (SanPhamDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.IDSP.ToString());
                lvitem.SubItems.Add(item.MaSP.ToString());
                lvitem.SubItems.Add(item.TenLoai.ToString());
                lvitem.SubItems.Add(item.TenSP.ToString());
                lvitem.SubItems.Add(item.LaiXuat.ToString());
                lvitem.SubItems.Add(item.DinhGia.ToString());
                lvitem.SubItems.Add(item.GiaThanhLy.ToString());
                lvitem.SubItems.Add(item.MoTa.ToString());
                lvitem.SubItems.Add(item.MauSac.ToString());
                lvitem.SubItems.Add(item.HienTrang.ToString());
                lvitem.SubItems.Add(item.NhanHieu.ToString());
                lvitem.SubItems.Add(item.QuaHan.ToString());
                lvitem.SubItems.Add(item.DaChuoc.ToString());
                lvitem.SubItems.Add(item.ThanhLy.ToString());
                lvitem.SubItems.Add(item.DaThanhLy.ToString());
                LVSP.Items.Add(lvitem);
            }
        }

        private void rboThanhLy_CheckedChanged(object sender, EventArgs e)
        {
            LVSP.Items.Clear();
            List<SanPhamDTO> list = SanPhamDAO.Instance.LoadListSPThanhLy();
            foreach (SanPhamDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.IDSP.ToString());
                lvitem.SubItems.Add(item.MaSP.ToString());
                lvitem.SubItems.Add(item.TenLoai.ToString());
                lvitem.SubItems.Add(item.TenSP.ToString());
                lvitem.SubItems.Add(item.LaiXuat.ToString());
                lvitem.SubItems.Add(item.DinhGia.ToString());
                lvitem.SubItems.Add(item.GiaThanhLy.ToString());
                lvitem.SubItems.Add(item.MoTa.ToString());
                lvitem.SubItems.Add(item.MauSac.ToString());
                lvitem.SubItems.Add(item.HienTrang.ToString());
                lvitem.SubItems.Add(item.NhanHieu.ToString());
                lvitem.SubItems.Add(item.QuaHan.ToString());
                lvitem.SubItems.Add(item.DaChuoc.ToString());
                lvitem.SubItems.Add(item.ThanhLy.ToString());
                lvitem.SubItems.Add(item.DaThanhLy.ToString());
                LVSP.Items.Add(lvitem);
            }
        }

        private void rboDaThanhLy_CheckedChanged(object sender, EventArgs e)
        {
            LVSP.Items.Clear();
            List<SanPhamDTO> list = SanPhamDAO.Instance.LoadListSPDaThanhLy();
            foreach (SanPhamDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.IDSP.ToString());
                lvitem.SubItems.Add(item.MaSP.ToString());
                lvitem.SubItems.Add(item.TenLoai.ToString());
                lvitem.SubItems.Add(item.TenSP.ToString());
                lvitem.SubItems.Add(item.LaiXuat.ToString());
                lvitem.SubItems.Add(item.DinhGia.ToString());
                lvitem.SubItems.Add(item.GiaThanhLy.ToString());
                lvitem.SubItems.Add(item.MoTa.ToString());
                lvitem.SubItems.Add(item.MauSac.ToString());
                lvitem.SubItems.Add(item.HienTrang.ToString());
                lvitem.SubItems.Add(item.NhanHieu.ToString());
                lvitem.SubItems.Add(item.QuaHan.ToString());
                lvitem.SubItems.Add(item.DaChuoc.ToString());
                lvitem.SubItems.Add(item.ThanhLy.ToString());
                lvitem.SubItems.Add(item.DaThanhLy.ToString());
                LVSP.Items.Add(lvitem);
            }
        }

        private void rboDangCam_CheckedChanged(object sender, EventArgs e)
        {
            LVSP.Items.Clear();
            List<SanPhamDTO> list = SanPhamDAO.Instance.LoadListSPDangCam();
            foreach (SanPhamDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.IDSP.ToString());
                lvitem.SubItems.Add(item.MaSP.ToString());
                lvitem.SubItems.Add(item.TenLoai.ToString());
                lvitem.SubItems.Add(item.TenSP.ToString());
                lvitem.SubItems.Add(item.LaiXuat.ToString());
                lvitem.SubItems.Add(item.DinhGia.ToString());
                lvitem.SubItems.Add(item.GiaThanhLy.ToString());
                lvitem.SubItems.Add(item.MoTa.ToString());
                lvitem.SubItems.Add(item.MauSac.ToString());
                lvitem.SubItems.Add(item.HienTrang.ToString());
                lvitem.SubItems.Add(item.NhanHieu.ToString());
                lvitem.SubItems.Add(item.QuaHan.ToString());
                lvitem.SubItems.Add(item.DaChuoc.ToString());
                lvitem.SubItems.Add(item.ThanhLy.ToString());
                lvitem.SubItems.Add(item.DaThanhLy.ToString());
                LVSP.Items.Add(lvitem);
            }
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            if (rboDaChuoc.Checked == true)
            {
                SqlConnection sqlCon;
                string conString = null;
                string sqlQuery = null;

                conString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyCamDo;Integrated Security=True";
                sqlCon = new SqlConnection(conString);
                sqlCon.Open();
                sqlQuery = "select a.ID_SP,a.MaSP,a.TenSP,b.TenLoai,a.DinhGia,a.MauSac,a.MoTa,a.NhangHieu,a.HienTrang from SanPham a,LoaiSP b where a.MaLoai=b.MaLoai and a.DaChuoc=1";
                SqlDataAdapter dscmd = new SqlDataAdapter(sqlQuery, sqlCon);
                DataTable dtData = new DataTable();
                dscmd.Fill(dtData);
                dataGridView1.DataSource = dtData;
                if (dataGridView1.Rows.Count > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "PDF (*.pdf)|*.pdf";
                    sfd.FileName = "Output.pdf";
                    bool fileError = false;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(sfd.FileName))
                        {
                            try
                            {
                                File.Delete(sfd.FileName);
                            }
                            catch (IOException ex)
                            {
                                fileError = true;
                            }
                        }
                        if (!fileError)
                        {
                            try
                            {
                                PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                                pdfTable.DefaultCell.Padding = 3;
                                pdfTable.WidthPercentage = 100;
                                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                                foreach (DataGridViewColumn column in dataGridView1.Columns)
                                {
                                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                    pdfTable.AddCell(cell);
                                }

                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        pdfTable.AddCell(cell.Value.ToString());
                                    }
                                }

                                using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                                {
                                    Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                    PdfWriter.GetInstance(pdfDoc, stream);
                                    pdfDoc.Open();
                                    pdfDoc.Add(new Paragraph("Bao cao san pham da chuoc"));
                                    pdfDoc.Add(new Paragraph("                                                                                                                         "));
                                    //pdfDoc.Close();
                                    //pdfDoc.Open();
                                    //pdfDoc.Add(new Paragraph(" "/*+rboDaChuoc.Text*/));
                                    //pdfDoc.Close();
                                    //pdfDoc.Open();
                                    pdfDoc.Add(pdfTable);
                                    pdfDoc.Close();
                                    stream.Close();
                                }

                                MessageBox.Show("Xuất PDF thành công");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error :" + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Xuất lỗi");
                }
            }
            else if (rboDangCam.Checked == true)
            {
                {
                    SqlConnection sqlCon;
                    string conString = null;
                    string sqlQuery = null;

                    conString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyCamDo;Integrated Security=True";
                    sqlCon = new SqlConnection(conString);
                    sqlCon.Open();
                    sqlQuery = "select a.ID_SP,a.MaSP,a.TenSP,b.TenLoai,a.DinhGia,a.MauSac,a.MoTa,a.NhangHieu,a.HienTrang from SanPham a,LoaiSP b where a.MaLoai=b.MaLoai and a.DaChuoc=0 and a.DaThanhLy=0 and a.ThanhLy=0 and a.QuaHan=0";
                    SqlDataAdapter dscmd = new SqlDataAdapter(sqlQuery, sqlCon);
                    DataTable dtData = new DataTable();
                    dscmd.Fill(dtData);
                    dataGridView1.DataSource = dtData;
                    if (dataGridView1.Rows.Count > 0)
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "PDF (*.pdf)|*.pdf";
                        sfd.FileName = "Output.pdf";
                        bool fileError = false;
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            if (File.Exists(sfd.FileName))
                            {
                                try
                                {
                                    File.Delete(sfd.FileName);
                                }
                                catch (IOException ex)
                                {
                                    fileError = true;
                                }
                            }
                            if (!fileError)
                            {
                                try
                                {
                                    PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                                    pdfTable.DefaultCell.Padding = 3;
                                    pdfTable.WidthPercentage = 100;
                                    pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                                    {
                                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                        pdfTable.AddCell(cell);
                                    }

                                    foreach (DataGridViewRow row in dataGridView1.Rows)
                                    {
                                        foreach (DataGridViewCell cell in row.Cells)
                                        {
                                            pdfTable.AddCell(cell.Value.ToString());
                                        }
                                    }

                                    using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                                    {
                                        Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                        PdfWriter.GetInstance(pdfDoc, stream);
                                        pdfDoc.Open();
                                        pdfDoc.Add(new Paragraph("Bao cao san pham dang cam"));
                                        pdfDoc.Add(new Paragraph("                                                                                                                         "));
                                        //pdfDoc.Close();
                                        //pdfDoc.Open();
                                        //pdfDoc.Add(new Paragraph(" "/*+rboDaChuoc.Text*/));
                                        //pdfDoc.Close();
                                        //pdfDoc.Open();
                                        pdfDoc.Add(pdfTable);
                                        pdfDoc.Close();
                                        stream.Close();
                                    }

                                    MessageBox.Show("Xuất PDF thành công");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error :" + ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Xuất lỗi");
                    }
                }
            }
            else if (rboDaThanhLy.Checked == true)
            {

                {
                    {
                        SqlConnection sqlCon;
                        string conString = null;
                        string sqlQuery = null;

                        conString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyCamDo;Integrated Security=True";
                        sqlCon = new SqlConnection(conString);
                        sqlCon.Open();
                        sqlQuery = "select a.ID_SP,a.MaSP,a.TenSP,b.TenLoai,a.DinhGia,a.MauSac,a.MoTa,a.NhangHieu,a.HienTrang from SanPham a,LoaiSP b where a.MaLoai=b.MaLoai and a.DaThanhLy=1";
                        SqlDataAdapter dscmd = new SqlDataAdapter(sqlQuery, sqlCon);
                        DataTable dtData = new DataTable();
                        dscmd.Fill(dtData);
                        dataGridView1.DataSource = dtData;
                        if (dataGridView1.Rows.Count > 0)
                        {
                            SaveFileDialog sfd = new SaveFileDialog();
                            sfd.Filter = "PDF (*.pdf)|*.pdf";
                            sfd.FileName = "Output.pdf";
                            bool fileError = false;
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                if (File.Exists(sfd.FileName))
                                {
                                    try
                                    {
                                        File.Delete(sfd.FileName);
                                    }
                                    catch (IOException ex)
                                    {
                                        fileError = true;
                                    }
                                }
                                if (!fileError)
                                {
                                    try
                                    {
                                        PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                                        pdfTable.DefaultCell.Padding = 3;
                                        pdfTable.WidthPercentage = 100;
                                        pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                                        {
                                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                            pdfTable.AddCell(cell);
                                        }

                                        foreach (DataGridViewRow row in dataGridView1.Rows)
                                        {
                                            foreach (DataGridViewCell cell in row.Cells)
                                            {
                                                pdfTable.AddCell(cell.Value.ToString());
                                            }
                                        }

                                        using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                                        {
                                            Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                            PdfWriter.GetInstance(pdfDoc, stream);
                                            pdfDoc.Open();
                                            pdfDoc.Add(new Paragraph("Bao cao san pham da thanh ly"));
                                            pdfDoc.Add(new Paragraph("                                                                                                                         "));
                                            //pdfDoc.Close();
                                            //pdfDoc.Open();
                                            //pdfDoc.Add(new Paragraph(" "/*+rboDaChuoc.Text*/));
                                            //pdfDoc.Close();
                                            //pdfDoc.Open();
                                            pdfDoc.Add(pdfTable);
                                            pdfDoc.Close();
                                            stream.Close();
                                        }

                                        MessageBox.Show("Xuất PDF thành công");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error :" + ex.Message);
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Xuất lỗi");
                        }
                    }
                }
            }
            else if (rboThanhLy.Checked == true)
            {

                {

                    {
                        {
                            SqlConnection sqlCon;
                            string conString = null;
                            string sqlQuery = null;

                            conString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyCamDo;Integrated Security=True";
                            sqlCon = new SqlConnection(conString);
                            sqlCon.Open();
                            sqlQuery = "select a.ID_SP,a.MaSP,a.TenSP,b.TenLoai,a.DinhGia,a.MauSac,a.MoTa,a.NhangHieu,a.HienTrang from SanPham a,LoaiSP b where a.MaLoai=b.MaLoai and a.ThanhLy=1";
                            SqlDataAdapter dscmd = new SqlDataAdapter(sqlQuery, sqlCon);
                            DataTable dtData = new DataTable();
                            dscmd.Fill(dtData);
                            dataGridView1.DataSource = dtData;
                            if (dataGridView1.Rows.Count > 0)
                            {
                                SaveFileDialog sfd = new SaveFileDialog();
                                sfd.Filter = "PDF (*.pdf)|*.pdf";
                                sfd.FileName = "Output.pdf";
                                bool fileError = false;
                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    if (File.Exists(sfd.FileName))
                                    {
                                        try
                                        {
                                            File.Delete(sfd.FileName);
                                        }
                                        catch (IOException ex)
                                        {
                                            fileError = true;
                                        }
                                    }
                                    if (!fileError)
                                    {
                                        try
                                        {
                                            PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                                            pdfTable.DefaultCell.Padding = 3;
                                            pdfTable.WidthPercentage = 100;
                                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                                            {
                                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                                pdfTable.AddCell(cell);
                                            }

                                            foreach (DataGridViewRow row in dataGridView1.Rows)
                                            {
                                                foreach (DataGridViewCell cell in row.Cells)
                                                {
                                                    pdfTable.AddCell(cell.Value.ToString());
                                                }
                                            }

                                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                                            {
                                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                                PdfWriter.GetInstance(pdfDoc, stream);
                                                pdfDoc.Open();
                                                pdfDoc.Add(new Paragraph("Bao cao san pham thanh ly"));
                                                pdfDoc.Add(new Paragraph("                                                                                                                         "));
                                                //pdfDoc.Close();
                                                //pdfDoc.Open();
                                                //pdfDoc.Add(new Paragraph(" "/*+rboDaChuoc.Text*/));
                                                //pdfDoc.Close();
                                                //pdfDoc.Open();
                                                pdfDoc.Add(pdfTable);
                                                pdfDoc.Close();
                                                stream.Close();
                                            }

                                            MessageBox.Show("Xuất PDF thành công");
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error :" + ex.Message);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Xuất lỗi");
                            }
                        }
                    }
                }
            }
            else if (rboQuaHan.Checked == true)
            {

                {

                    {
                        {
                            SqlConnection sqlCon;
                            string conString = null;
                            string sqlQuery = null;

                            conString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyCamDo;Integrated Security=True";
                            sqlCon = new SqlConnection(conString);
                            sqlCon.Open();
                            sqlQuery = "select a.ID_SP,a.MaSP,a.TenSP,b.TenLoai,a.DinhGia,a.MauSac,a.MoTa,a.NhangHieu,a.HienTrang from SanPham a,LoaiSP b where a.MaLoai=b.MaLoai and a.QuaHan=1";
                            SqlDataAdapter dscmd = new SqlDataAdapter(sqlQuery, sqlCon);
                            DataTable dtData = new DataTable();
                            dscmd.Fill(dtData);
                            dataGridView1.DataSource = dtData;
                            if (dataGridView1.Rows.Count > 0)
                            {
                                SaveFileDialog sfd = new SaveFileDialog();
                                sfd.Filter = "PDF (*.pdf)|*.pdf";
                                sfd.FileName = "Output.pdf";
                                bool fileError = false;
                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    if (File.Exists(sfd.FileName))
                                    {
                                        try
                                        {
                                            File.Delete(sfd.FileName);
                                        }
                                        catch (IOException ex)
                                        {
                                            fileError = true;
                                        }
                                    }
                                    if (!fileError)
                                    {
                                        try
                                        {
                                            PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                                            pdfTable.DefaultCell.Padding = 3;
                                            pdfTable.WidthPercentage = 100;
                                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                                            {
                                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                                pdfTable.AddCell(cell);
                                            }

                                            foreach (DataGridViewRow row in dataGridView1.Rows)
                                            {
                                                foreach (DataGridViewCell cell in row.Cells)
                                                {
                                                    pdfTable.AddCell(cell.Value.ToString());
                                                }
                                            }

                                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                                            {
                                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                                PdfWriter.GetInstance(pdfDoc, stream);
                                                pdfDoc.Open();
                                                pdfDoc.Add(new Paragraph("Bao cao san pham qua han"));
                                                pdfDoc.Add(new Paragraph("                                                                                                                         "));
                                                //pdfDoc.Close();
                                                //pdfDoc.Open();
                                                //pdfDoc.Add(new Paragraph(" "/*+rboDaChuoc.Text*/));
                                                //pdfDoc.Close();
                                                //pdfDoc.Open();
                                                pdfDoc.Add(pdfTable);
                                                pdfDoc.Close();
                                                stream.Close();
                                            }

                                            MessageBox.Show("Xuất PDF thành công");
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error :" + ex.Message);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Xuất lỗi");
                            }
                        }
                    }
                }
            }
            else
            {

                {

                    {
                        {
                            SqlConnection sqlCon;
                            string conString = null;
                            string sqlQuery = null;

                            conString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyCamDo;Integrated Security=True";
                            sqlCon = new SqlConnection(conString);
                            sqlCon.Open();
                            sqlQuery = "select a.ID_SP,a.MaSP,a.TenSP,b.TenLoai,a.DinhGia,a.MauSac,a.MoTa,a.NhangHieu,a.HienTrang from SanPham a,LoaiSP b where a.MaLoai=b.MaLoai";
                            SqlDataAdapter dscmd = new SqlDataAdapter(sqlQuery, sqlCon);
                            DataTable dtData = new DataTable();
                            dscmd.Fill(dtData);
                            dataGridView1.DataSource = dtData;
                            if (dataGridView1.Rows.Count > 0)
                            {
                                SaveFileDialog sfd = new SaveFileDialog();
                                sfd.Filter = "PDF (*.pdf)|*.pdf";
                                sfd.FileName = "Output.pdf";
                                bool fileError = false;
                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    if (File.Exists(sfd.FileName))
                                    {
                                        try
                                        {
                                            File.Delete(sfd.FileName);
                                        }
                                        catch (IOException ex)
                                        {
                                            fileError = true;
                                        }
                                    }
                                    if (!fileError)
                                    {
                                        try
                                        {
                                            PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                                            pdfTable.DefaultCell.Padding = 3;
                                            pdfTable.WidthPercentage = 100;
                                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                                            {
                                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                                pdfTable.AddCell(cell);
                                            }

                                            foreach (DataGridViewRow row in dataGridView1.Rows)
                                            {
                                                foreach (DataGridViewCell cell in row.Cells)
                                                {
                                                    pdfTable.AddCell(cell.Value.ToString());
                                                }
                                            }

                                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                                            {
                                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                                PdfWriter.GetInstance(pdfDoc, stream);

                                                pdfDoc.Open();
                                                
                                                pdfDoc.Add(new Paragraph("Bao cao tat ca san pham"));
                                                pdfDoc.Add(new Paragraph("                                                                                                                         "));
                                                //pdfDoc.Close();
                                                //pdfDoc.Open();
                                                //pdfDoc.Add(new Paragraph(" "/*+rboDaChuoc.Text*/));
                                                //pdfDoc.Close();
                                                //pdfDoc.Open();
                                                pdfDoc.Add(pdfTable);
                                                pdfDoc.Close();
                                                stream.Close();
                                            }

                                            MessageBox.Show("Xuất PDF thành công");
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error :" + ex.Message);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Xuất lỗi");
                            }
                        }
                    }
                }
            }
        }
    }
}
