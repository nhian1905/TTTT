using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DoAnTTTT_QuanLyCuaHieuCamDo.DAO;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.Design
{
    public partial class CamDo : Form
    {
        public CamDo()
        {
            InitializeComponent();
        }
        private void CamDo_Load(object sender, EventArgs e)
        {
            LoadHoaDonCam();
            LoadCboKhachHang();
            LoadCboLoaiSP();
            
        }

        void LoadCboKhachHang()
        {
            cboKhachHang.DataSource = KhachHangDAO.Instance.LoadListKH();
            cboKhachHang.DisplayMember = "TenKH";
            cboKhachHang.ValueMember = "MaKH";
        }

        void LoadCboLoaiSP()
        {
            cboLoaiSP.DataSource = LoaiSPDAO.Instance.LoadListLoaiSP();
            cboLoaiSP.DisplayMember = "TenLoai";
            cboLoaiSP.ValueMember = "MaLoai";
        }
        void LoadHoaDonCam()
        {
            LvPhieuCam.Items.Clear();
            List<HoaDonCamDTO> list = HoaDonCamDAO.Instance.LoadListHoaDonCam();
            foreach (HoaDonCamDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaHoaDonCam.ToString());
                lvitem.SubItems.Add(item.TenKH.ToString());
                lvitem.SubItems.Add(item.NgayLap.ToString());
                lvitem.SubItems.Add(item.NgayHetHan.ToString());
                lvitem.SubItems.Add(item.TongTienCam.ToString());
                LvPhieuCam.Items.Add(lvitem);
            }
        }

        void LoadCTHoaDonCam(int MaHDC)
        {
            LVCTHDC.Items.Clear();
            List<ChiTietHoaDonCamDTO> list = ChiTietHoaDonCamDAO.Instance.LoadListCTHDC(MaHDC);
            foreach (ChiTietHoaDonCamDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaHoaDonCam.ToString());
                lvitem.SubItems.Add(item.MaSP.ToString());
                lvitem.SubItems.Add(item.TenLoai.ToString());
                lvitem.SubItems.Add(item.TenSP.ToString());
                lvitem.SubItems.Add(item.DinhGia.ToString());
                lvitem.SubItems.Add(item.MoTa.ToString());
                lvitem.SubItems.Add(item.MauSac.ToString());
                lvitem.SubItems.Add(item.HienTrang.ToString());
                lvitem.SubItems.Add(item.NhanHieu.ToString());
                LVCTHDC.Items.Add(lvitem);
            }
        }

        
        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionStr = CSDL.connectionStr;
            SqlConnection kn = new SqlConnection(connectionStr);
            kn.Open();
            string sql = "select * from KhachHang where MaKH = '" + cboKhachHang.SelectedValue.ToString() + "'";
            SqlCommand cmdd = new SqlCommand(sql, kn);
            SqlDataReader kq = cmdd.ExecuteReader();
            if (kq.HasRows)
            {
                kq.Read();
                txtSDT.Text = kq.GetInt32(2).ToString();
                txtCMND.Text = kq.GetInt32(3).ToString();
                dtpNgaySinh.Value = kq.GetDateTime(4).Date;
                txtDiaChi.Text = kq.GetString(5).ToString();
                dtpNgayCapCMND.Value = kq.GetDateTime(6).Date;
            }
            kn.Close();
        }

        private void btnThemHoaDonCam_Click(object sender, EventArgs e)
        {
            if (txtCMND.Text != "" && txtSDT.Text != "")
            {
                DateTime NgayLap = (DateTime)Convert.ToDateTime(dtpNgayCamHD.Value).Date;
                DateTime NgayHetHan = (DateTime)Convert.ToDateTime(dtpNgayHetHan.Value).Date;
                DateTime NgayDongLai = NgayLap;
                float TongTienCam = (float)Convert.ToDouble(0);
                int MaKH = (cboKhachHang.SelectedItem as KhachHangDTO).MaKH;
                if (HoaDonCamDAO.Instance.InsertHDC(MaKH, NgayLap, NgayHetHan,NgayDongLai, TongTienCam))
                {
                    MessageBox.Show("Thêm Hóa Đơn Thành Công");
                    LoadHoaDonCam();
                }
                else
                {
                    MessageBox.Show("Thêm Thật Bại");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Chọn Khách Hàng");
            }
        }

        private void btnSuaHoaDonCam_Click(object sender, EventArgs e)
        {
            if (txtMaHDC.Text != "")
            {
                int MaHoaDonCam = (int)Convert.ToInt32(txtMaHDC.Text);
                DateTime NgayLap = (DateTime)Convert.ToDateTime(dtpNgayCamHD.Value).Date;
                DateTime NgayHetHan = (DateTime)Convert.ToDateTime(dtpNgayHetHan.Value).Date;
                DateTime NgayDongLai = NgayLap;
                int MaKH = (cboKhachHang.SelectedItem as KhachHangDTO).MaKH;
                if (HoaDonCamDAO.Instance.UpdateHDC(MaHoaDonCam, MaKH, NgayLap, NgayHetHan,NgayDongLai))
                {
                    MessageBox.Show("Sửa Thành Công", "Thông Báo");
                    LoadHoaDonCam();
                }
                else
                {
                    MessageBox.Show("Sửa Thất Bại");
                }
            }
            else
            {
                MessageBox.Show("Nhập Ngày Mới");
            }
        }

        private void btnXoaHoaDonCam_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("BẠN CÓ THẬT SỰ MUỐN XÓA HÓA ĐƠN", "THÔNG BÁO", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    int MaHDC = Convert.ToInt32(txtMaHDC.Text);
                    if (txtMaHDC.Text != "")
                    {
                        if (HoaDonCamDAO.Instance.DeleteHDC(MaHDC))
                        {
                            MessageBox.Show("Xóa Thành Công", "Thông báo");
                            LoadHoaDonCam();
                        }
                        else
                        {
                            MessageBox.Show("Xóa Thất Bại");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chọn Hóa Đơn Cần Xóa");
                    }
                }

                catch
                {
                    MessageBox.Show("Có lỗi Không Thể Xóa Do Sản Phẩm Đã Được Xuất ");
                }
            }
        }
        
        private void LvPhieuCam_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection lv = this.LvPhieuCam.SelectedItems;
            int mahoadoncam = 0;
            string tenkh = "";
            string ngaylaphdc = "";
            string ngayhethan = "";
            string tongtiencam = "";
            foreach (ListViewItem item in lv)
            {
                mahoadoncam += Int32.Parse(item.SubItems[0].Text);
                tenkh += item.SubItems[1].Text;
                ngaylaphdc += DateTime.Parse(item.SubItems[2].Text);
                ngayhethan += DateTime.Parse(item.SubItems[3].Text);
                tongtiencam += item.SubItems[4].Text;
            }
            cboKhachHang.Text = tenkh.ToString();
            txtMaHDC.Text = mahoadoncam.ToString();
            dtpNgayCamHD.Text = ngaylaphdc.ToString();
            dtpNgayHetHan.Text = ngayhethan.ToString();
            txtTongTien.Text = tongtiencam.ToString();


            ListView.SelectedListViewItemCollection lvv = this.LvPhieuCam.SelectedItems;
            int id = 0;
            foreach (ListViewItem item in lvv)
            {
                id += Int32.Parse(item.SubItems[0].Text);
            }
            txtMaHDC.Text = id.ToString();
            int MaHoaDonCam = int.Parse(txtMaHDC.Text);
            LoadCTHoaDonCam(MaHoaDonCam);
        }

        private void LVCTHDC_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection lv = this.LVCTHDC.SelectedItems;
            int mahdc = 0;
            string masp = "";
            string maloai = "";
            string tensp = "";
            string dinhgia = "";
            string mota = "";
            string mausac = "";
            string hientrang = "";
            string nhanhieu = "";
            foreach (ListViewItem item in lv)
            {
                mahdc += Int32.Parse(item.SubItems[0].Text);
                masp += item.SubItems[1].Text;
                maloai += item.SubItems[2].Text;
                tensp += item.SubItems[3].Text;
                dinhgia += item.SubItems[4].Text;
                mota += item.SubItems[5].Text;
                mausac += item.SubItems[6].Text;
                hientrang += item.SubItems[7].Text;
                nhanhieu += item.SubItems[8].Text;
            }
            txtMaHDC.Text = mahdc.ToString();
            txtMaSP.Text = masp.ToString();
            txtTenSP.Text = tensp.ToString();
            txtDinhGia.Text = dinhgia.ToString();
            cboLoaiSP.Text = maloai.ToString();
            txtMoTa.Text = mota.ToString();
            txtMauSac.Text = mausac.ToString();
            txtHienTrang.Text = hientrang.ToString();
            txtNhanHieu.Text = nhanhieu.ToString();
        }
        void LoadTongTien()
        {
            int MaHoaDonCam = Convert.ToInt32(txtMaHDC.Text);
            HoaDonCamDAO.Instance.UpdateTongTien(MaHoaDonCam);
            LoadHoaDonCam();
        }
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            
            int id = int.Parse(txtMaHDC.Text);
            if (txtTenSP.Text != "" && txtMaSP.Text != "")
            {
                int MaHoaDonCam = (int)Convert.ToInt32(txtMaHDC.Text);
                string MaSP = txtMaSP.Text;
                int MaLoai = (cboLoaiSP.SelectedItem as LoaiSPDTO).MaLoai;
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
                double tongtien = DinhGia+Convert.ToDouble(txtTongTien.Text);
                if (SanPhamDAO.Instance.InsertSP(MaSP, MaLoai, TenSP, DinhGia, GiaThanhLy, MoTa, MauSac, HienTrang, NhanHieu, QuaHan, DaChuoc, ThanhLy, DaThanhLy))
                {
                    if (ChiTietHoaDonCamDAO.Instance.InsertSPtoBillHDC(MaHoaDonCam, MaSP))
                    {
                        MessageBox.Show("Thêm Thành Công");
                        LoadCTHoaDonCam(id);
                        LoadTongTien();
                        //txtTongTien.Text = Convert.ToString(tongtien);
                        //HoaDonCamDAO.Instance.UpdateMoney(MaHoaDonCam,tongtien);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Chọn Sản Phẩm");
            }
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtMaHDC.Text);
            int MaHoaDonCam = (int)Convert.ToInt32(txtMaHDC.Text);
            string MaSP = txtMaSP.Text;
            int MaLoai = (cboLoaiSP.SelectedItem as LoaiSPDTO).MaLoai;
            string TenSP = txtTenSP.Text;
            float DinhGia = (float)Convert.ToDouble(txtDinhGia.Text);
            float GiaThanhLy = (float)Convert.ToDouble(0);
            string MoTa = txtMoTa.Text;
            string MauSac = txtMauSac.Text;
            string HienTrang = txtHienTrang.Text;
            string NhanHieu = txtNhanHieu.Text;
            if (MaSP != "")
            {
                if (SanPhamDAO.Instance.UpdateSP(MaSP, MaLoai, TenSP, DinhGia, GiaThanhLy, MoTa, MauSac, HienTrang, NhanHieu))
                {
                    if (ChiTietHoaDonCamDAO.Instance.UpdateSPtoBillHDC(MaHoaDonCam, MaSP))
                    {
                        MessageBox.Show("Sửa Thành Công");
                        LoadCTHoaDonCam(id);
                        //txtTongTien.Text = Convert.ToString(tongtien);
                        //HoaDonCamDAO.Instance.UpdateMoney(MaHoaDonCam, tongtien);
                        LoadTongTien();
                    }
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
            txtMaSP.Enabled = true;
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtMaHDC.Text);
            if (txtMaSP.Text == null)
            {
                MessageBox.Show("Vui Lòng Chọn Sản Phẩm Cần Xóa");
                return;
            }
            string MaSP = txtMaSP.Text;
            DialogResult tb = MessageBox.Show("Bạn Có Muốn Xóa Sản Phẩm Này Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                if (ChiTietHoaDonCamDAO.Instance.DeletetoBillHDC(MaSP))
                {
                    SanPhamDAO.Instance.DeleteSP(MaSP);
                    //txtTongTien.Text = Convert.ToString(tongtien);
                    //HoaDonCamDAO.Instance.UpdateMoney(MaHoaDonCam, tongtien);
                    LoadTongTien();
                }
                else
                {
                    return;
                }
            }

            LoadCTHoaDonCam(id);
        }

        private void LVCTHDC_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
