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
            List<ChiTietHoaDonCamDTO> list = ChiTietHoaDonCamDAO.Instance.LoadListCTHDC(MaHDC);
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

        void LoadCTPC()
        {
            LvCTPhieuChuoc.Items.Clear();
            List<ChiTietPhieuChuocDTO> list = ChiTietPhieuChuocDAO.Instance.LoadListCTPhieuChuoc();
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

            ListView.SelectedListViewItemCollection lvv = this.LvHoaDonCam.SelectedItems;
            int id = 0;
            foreach (ListViewItem item in lvv)
            {
                id += Int32.Parse(item.SubItems[0].Text);
            }
            txtMaHDC.Text = id.ToString();
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
                DateTime NgayChuoc = (DateTime)Convert.ToDateTime(dtpNgayChuoc.Value).Date;
                float TongTien = (float)Convert.ToDouble(0);
                int MaHoaDonCam = (int)Convert.ToInt32(txtMaHDC.Text);
                if (PhieuChuocDAO.Instance.InsertPhieuChuoc(MaHoaDonCam, NgayChuoc, TongTien))
                {
                    MessageBox.Show("Thêm Hóa Đơn Thành Công");
                    lbMaHDChuoc.Text = PhieuChuocDAO.Instance.MaPC(MaHoaDonCam, NgayChuoc);
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
            
            
            int MaPC = (int)Convert.ToInt32(lbMaHDChuoc.Text);
            string MaSP = txtMaSP.Text;
            float TienLai = (float)Convert.ToDouble(0);
            float TongTien = (float)Convert.ToDouble(0);
            if (ChiTietPhieuChuocDAO.Instance.InsertSPtoBillPhieuChuoc(MaPC, MaSP,TienLai, TongTien))
            {
                MessageBox.Show("Thêm Thành Công");
                //LoadCTPC();
                LoadTongTien();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }
    }
}
