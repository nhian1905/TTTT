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
using DevExpress.XtraReports.UI;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.Design
{
    public partial class ChuocSP : Form
    {
        public ChuocSP()
        {
            InitializeComponent();
        }

        private void ChuocSP_Load(object sender, EventArgs e)
        {
            LoadHoaDonCam();
            LoadCboKH();
            //LoadCTPC();
        }

        void LoadHoaDonCam()
        {
            LvHoaDonCam.Items.Clear();
            List<HoaDonCamDTO> list = HoaDonCamDAO.Instance.LoadListHoaDonCam();
            foreach (HoaDonCamDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaHoaDonCam.ToString());
                lvitem.SubItems.Add(item.TenKH.ToString());
                lvitem.SubItems.Add(item.NgayLap.ToString());
                lvitem.SubItems.Add(item.NgayHetHan.ToString());
                lvitem.SubItems.Add(item.TongTienCam.ToString());
                LvHoaDonCam.Items.Add(lvitem);
            }
        }

        void LoadSP(int MaHDC)
        {
            LvSanPham.Items.Clear();
            List<ChiTietHoaDonCamDTO> list = ChiTietHoaDonCamDAO.Instance.LoadListSP(MaHDC);
            foreach (ChiTietHoaDonCamDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaSP.ToString());
                lvitem.SubItems.Add(item.TenLoai.ToString());
                lvitem.SubItems.Add(item.TenSP.ToString());
                lvitem.SubItems.Add(item.DinhGia.ToString());
                lvitem.SubItems.Add(item.MoTa.ToString());
                lvitem.SubItems.Add(item.MauSac.ToString());
                lvitem.SubItems.Add(item.HienTrang.ToString());
                lvitem.SubItems.Add(item.NhanHieu.ToString());
                LvSanPham.Items.Add(lvitem);
            }
        }

        void LoadCTPhieuChuoc(int MaPhieuChuoc)
        {
            LvCTPhieuChuoc.Items.Clear();
            List<ChiTietPhieuChuocDTO> list = ChiTietPhieuChuocDAO.Instance.LoadListCTPhieuChuocByPC(MaPhieuChuoc);
            foreach (ChiTietPhieuChuocDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaSP.ToString());
                //lvitem.SubItems.Add(item.MaSP.ToString());
                lvitem.SubItems.Add(item.TenSP.ToString());
                lvitem.SubItems.Add(item.DinhGia.ToString());
                lvitem.SubItems.Add(item.LaiXuat.ToString());
                lvitem.SubItems.Add(item.TienLai.ToString());
                lvitem.SubItems.Add(item.MauSac.ToString());
                lvitem.SubItems.Add(item.NhanHieu.ToString());
                lvitem.SubItems.Add(item.MoTa.ToString());
                lvitem.SubItems.Add(item.HienTrang.ToString());
                lvitem.SubItems.Add(item.TongTien.ToString());
                LvCTPhieuChuoc.Items.Add(lvitem);
            }
        }
        void LoadCboKH()
        {
            cboMaKH.DataSource = KhachHangDAO.Instance.LoadListKH();
            cboMaKH.DisplayMember = "MaKH";
            cboMaKH.ValueMember = "MaKH";
        }
        void LoadTongTien()
        {
            int MaPhieuChuoc =(int)Convert.ToInt32(lbMaHDChuoc.Text);
            txtTongTien.Text = PhieuChuocDAO.Instance.UpdateTongTien(MaPhieuChuoc);
        }
        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionStr = CSDL.connectionStr;
            SqlConnection kn = new SqlConnection(connectionStr);
            kn.Open();
            string sql = "select * from KhachHang where MaKH = '" + cboMaKH.SelectedValue.ToString() + "'";
            SqlCommand cmdd = new SqlCommand(sql, kn);
            SqlDataReader kq = cmdd.ExecuteReader();
            if (kq.HasRows)
            {
                kq.Read();
                txtTenKH.Text = kq.GetString(1).ToString();
                txtSDT.Text = kq.GetInt32(2).ToString();
                txtCMND.Text = kq.GetInt32(3).ToString();
                dtpNgaySinh.Value = kq.GetDateTime(4).Date;
                txtDiaChi.Text = kq.GetString(5).ToString();
                dtpNgayCapCMND.Value = kq.GetDateTime(6).Date;
            }
            kn.Close();
        }

        private void LvHoaDonCam_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection lv = this.LvHoaDonCam.SelectedItems;
            int mahoadoncam= 0;
            foreach (ListViewItem item in lv)
            {
                mahoadoncam +=Int32.Parse(item.SubItems[0].Text);
            }
            txtMaHDC.Text = mahoadoncam.ToString();
            cboMaKH.Text = PhieuChuocDAO.Instance.MaKH(mahoadoncam);

            int MaHoaDonCam = int.Parse(txtMaHDC.Text);
            LoadSP(MaHoaDonCam);
        }

        private void LvSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection lv = this.LvSanPham.SelectedItems;
            string masp = "";
            foreach (ListViewItem item in lv)
            {
                masp += item.SubItems[0].Text;
            }
            txtMaSP.Text = masp.ToString();
        }

        private void btnThemHDChuoc_Click(object sender, EventArgs e)
        {
            if (dtpNgayChuoc.Text != "")
            {
                string MaSP = txtMaSP.Text;
                DateTime NgayChuoc = (DateTime)Convert.ToDateTime(dtpNgayChuoc.Value).Date;
                float TongTien = (float)Convert.ToDouble(0);
                int MaHoaDonCam = (int)Convert.ToInt32(txtMaHDC.Text);
                if (PhieuChuocDAO.Instance.InsertPhieuChuoc(MaHoaDonCam, NgayChuoc, TongTien))
                {
                    MessageBox.Show("Thêm Hóa Đơn Thành Công");
                    lbMaHDChuoc.Text = PhieuChuocDAO.Instance.MaPC(MaHoaDonCam, NgayChuoc);
                    int MaPhieuChuoc = (int)Convert.ToInt32(lbMaHDChuoc.Text);
                    LoadCTPhieuChuoc(MaPhieuChuoc);
                    
                }
                else
                {
                    MessageBox.Show("Thêm Thật Bại");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Ngày Chuộc");
            }
        }

        private void ThemSP_Click(object sender, EventArgs e)
        {
            int MaHDC = (int)Convert.ToInt32(txtMaHDC.Text);
            DateTime ngaydong =(DateTime)Convert.ToDateTime(DateTime.Now);
            int MaPC = (int)Convert.ToInt32(lbMaHDChuoc.Text);
            string MaSP = txtMaSP.Text;

            //string connectionStr = CSDL.connectionStr;
            //SqlConnection kn = new SqlConnection(connectionStr);
            //kn.Open();
            //string sql = "select LoaiSP.LaiXuat * SanPham.DinhGia";
            //sql += " from ChiTiet_HoaDonCam, SanPham, LoaiSP, HoaDonCam";
            //sql += " where ChiTiet_HoaDonCam.MaSP = SanPham.MaSP and SanPham.MaLoai = LoaiSP.MaLoai and HoaDonCam.MaHoaDonCam = '" + MaHDC + "' and ChiTiet_HoaDonCam.MaHoaDonCam=HoaDonCam.MaHoaDonCam";
            //sql += " and SanPham.ThanhLy=0 and SanPham.DaThanhLy=0 and SanPham.DaChuoc=0 and SanPham.QuaHan=0 and SanPham.MaSP='"+MaSP+"'";
            //SqlCommand cmdd = new SqlCommand(sql, kn);
            //SqlDataReader kq = cmdd.ExecuteReader();
            //StringBuilder a = new StringBuilder();
            //while (kq.Read())
            //{
            //    for (int i = 0; i < kq.FieldCount; i++)
            //    {
            //        TienLai = TienLai + Convert.ToDouble(PhieuLaiDAO.Instance.Ngay(MaHDC,ngaydong)) * Convert.ToDouble(kq[i]) / 100;
            //    }

            //}
            //kn.Close();
            double TienLai =PhieuLaiDAO.Instance.TienLai(ngaydong,MaHDC);
            float TongTien = (float)Convert.ToDouble(ChiTietPhieuChuocDAO.Instance.LayGiaSP(MaSP))+(float)Convert.ToDouble(TienLai);
            if (ChiTietPhieuChuocDAO.Instance.InsertSPtoBillPhieuChuoc(MaPC, MaSP,Convert.ToDouble(TienLai), TongTien))
            {
                MessageBox.Show("Thêm Thành Công");
                ChiTietPhieuChuocDAO.Instance.UpdateSPDaChuoc(MaSP);
                LoadCTPhieuChuoc(MaPC);
                LoadTongTien();
                LoadSP(MaHDC);
                txtTongTien.Text = Convert.ToString(ChiTietPhieuChuocDAO.Instance.TongTien(MaPC));
                PhieuChuocDAO.Instance.UpdateTongTien(MaPC);
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void XoaSP_Click(object sender, EventArgs e)
        {
            int MaHDChuoc = int.Parse(lbMaHDChuoc.Text);
            if (txtMaSP.Text == null)
            {
                MessageBox.Show("Vui Lòng Chọn Sản Phẩm Cần Xóa");
                return;
            }
            string MaSP = txtMaSP.Text;
            int MaHDC = (int)Convert.ToInt32(txtMaHDC.Text);
            DialogResult tb = MessageBox.Show("Bạn Có Muốn Xóa Sản Phẩm Này Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                if (ChiTietPhieuChuocDAO.Instance.DeletetoBillThanhLy(MaSP))
                {
                    MessageBox.Show("Xóa Thành Công");
                    ChiTietPhieuChuocDAO.Instance.UpdateXoaSPDaChuoc(MaSP);
                    LoadSP(MaHDC);
                    LoadTongTien();
                    
                }
                else
                {
                    return;
                }
            }

            LoadCTPhieuChuoc(MaHDChuoc);
        }

        private void btnIN_Click(object sender, EventArgs e)
        {
            int MaPhieuChuoc = (int)Convert.ToInt32(lbMaHDChuoc.Text);
            if (MessageBox.Show("Bạn có muốn in hóa đơn ", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                rptPhieuChuoc rp = new rptPhieuChuoc();
                rp.DataSource = PhieuChuocDAO.Instance.LoadRpHDChuoc(MaPhieuChuoc);
                rp.FilterString = "[MaPhieuChuoc] = '" + MaPhieuChuoc + "'";
                rp.CreateDocument();
                rp.ShowPreviewDialog();
            }
        }
    }
}
