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
    public partial class DongLai : Form
    {
        public DongLai()
        {
            InitializeComponent();
        }

        private void DongLai_Load(object sender, EventArgs e)
        {
            LoadHoaDonCam();
            LoadCboKH();
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

        private void LvPhieuCam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LvPhieuCam_Click(object sender, EventArgs e)
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
            txtTenKhachHang.Text = tenkh.ToString();
            txtMaHDC.Text = mahoadoncam.ToString();
            dtpNgayCamHD.Text = ngaylaphdc.ToString();
            dtpNgayHetHan.Text = ngayhethan.ToString();
            txtTongTien.Text = tongtiencam.ToString();
            cboMaKH.Text = PhieuLaiDAO.Instance.MaKH(mahoadoncam);



            int MaHDC = Convert.ToInt32(txtMaHDC.Text);
            DateTime ngaydong = DateTime.Now;
            //double n = Convert.ToDouble(PhieuLaiDAO.Instance.Ngay(MaHDC, ngaydong));
            double TienLai = 0;
            string connectionStr = CSDL.connectionStr;
            SqlConnection kn = new SqlConnection(connectionStr);
            kn.Open();
            string sql = "select LoaiSP.LaiXuat * SanPham.DinhGia";
            sql += " from ChiTiet_HoaDonCam, SanPham, LoaiSP, HoaDonCam";
            sql += " where ChiTiet_HoaDonCam.MaSP = SanPham.MaSP and SanPham.MaLoai = LoaiSP.MaLoai and HoaDonCam.MaHoaDonCam = '" + MaHDC + "' and ChiTiet_HoaDonCam.MaHoaDonCam=HoaDonCam.MaHoaDonCam";
            SqlCommand cmdd = new SqlCommand(sql, kn);
            SqlDataReader kq = cmdd.ExecuteReader();
            StringBuilder a = new StringBuilder();
            while (kq.Read())
            {
                for (int i = 0; i < kq.FieldCount; i++)
                {
                    TienLai = TienLai + Convert.ToDouble(PhieuLaiDAO.Instance.Ngay(MaHDC,ngaydong)) * Convert.ToDouble(kq[i]) / 100;
                }

            }
            kn.Close();
            txtTienLai.Text = Convert.ToString(TienLai);
        }
        void LoadCboKH()
        {
            cboMaKH.DataSource = KhachHangDAO.Instance.LoadListKH();
            cboMaKH.DisplayMember = "MaKH";
            cboMaKH.ValueMember = "MaKH";
            cboMaKH.SelectedIndex = 0;
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
                txtTenKhachHang.Text = kq.GetString(1).ToString();
                txtSDT.Text = kq.GetInt32(2).ToString();
                txtCMND.Text = kq.GetInt32(3).ToString();
                dtpNgaySinh.Value = kq.GetDateTime(4).Date;
                txtDiaChi.Text = kq.GetString(5).ToString();
                dtpNgayCapCMND.Value = kq.GetDateTime(6).Date;
            }
            kn.Close();
        }

        private void btnDongLai_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
