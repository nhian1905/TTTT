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
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;
using DoAnTTTT_QuanLyCuaHieuCamDo.DAO;
namespace DoAnTTTT_QuanLyCuaHieuCamDo.Design
{
    public partial class ThanhLy : Form
    {
        public ThanhLy()
        {
            InitializeComponent();
        }

        private void ThanhLy_Load(object sender, EventArgs e)
        {
            LoadThanhLy();
            LoadCboKhachHang();
            LoadCboSP();
        }

        void LoadThanhLy()
        {
            LVThanhLy.Items.Clear();
            List<ThanhLyDTO> list = ThanhLyDAO.Instance.LoadListThanhLy();
            foreach (ThanhLyDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaThanhLy.ToString());
                lvitem.SubItems.Add(item.TenKH.ToString());
                lvitem.SubItems.Add(item.NgayLap.ToString());
                lvitem.SubItems.Add(item.TongTienThanhLy.ToString());
                LVThanhLy.Items.Add(lvitem);
            }
        }

        void LoadCTThanhLy(int MaThanhLy)
        {
            LVCTThanhLy.Items.Clear();
            List<ChiTietHoaDonCamDTO> list = ChiTietHoaDonCamDAO.Instance.LoadListCTHDC(MaThanhLy);
            foreach (ChiTietHoaDonCamDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaSP.ToString());
                lvitem.SubItems.Add(item.TenSP.ToString());
                lvitem.SubItems.Add(item.GiaThanhLy.ToString());
                lvitem.SubItems.Add(item.MauSac.ToString());
                lvitem.SubItems.Add(item.NhanHieu.ToString());
                lvitem.SubItems.Add(item.MoTa.ToString());
                lvitem.SubItems.Add(item.HienTrang.ToString());
                LVCTThanhLy.Items.Add(lvitem);
            }
        }
        void LoadCboSP()
        {
            cboMaSP.DataSource = SanPhamDAO.Instance.LoadListSPThanhLy();
            cboMaSP.DisplayMember = "MaSP";
            cboMaSP.ValueMember = "MaSP";
        }
        void LoadCboKhachHang()
        {
            cbKhachHang.DataSource = KhachHangDAO.Instance.LoadListKH();
            cbKhachHang.DisplayMember = "TenKH";
            cbKhachHang.ValueMember = "MaKH";
        }

        private void cbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionStr = CSDL.connectionStr;
            SqlConnection kn = new SqlConnection(connectionStr);
            kn.Open();
            string sql = "select * from KhachHang where MaKH = '" + cbKhachHang.SelectedValue.ToString() + "'";
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

        private void LVThanhLy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection lv = this.LVThanhLy.SelectedItems;
            int mathanhly = 0;
            string tenKH = "";
            string ngaylap = "";
            string tongtienthanhly = "";
            foreach (ListViewItem item in lv)
            {
                mathanhly += Int32.Parse(item.SubItems[0].Text);
                tenKH += item.SubItems[1].Text;
                ngaylap += DateTime.Parse(item.SubItems[2].Text);
                tongtienthanhly += item.SubItems[3].Text;
            }
            txtMaThanhLy.Text = mathanhly.ToString();
            cbKhachHang.Text = tenKH.ToString();
            dtpNgayLap.Text = ngaylap.ToString();
            txtTongTien.Text = tongtienthanhly.ToString();

            ListView.SelectedListViewItemCollection lvv = this.LVThanhLy.SelectedItems;
            int id = 0;
            foreach (ListViewItem item in lvv)
            {
                id += Int32.Parse(item.SubItems[0].Text);
            }
            txtMaThanhLy.Text = id.ToString();
            int MaThanhLy = int.Parse(txtMaThanhLy.Text);
            LoadCTThanhLy(MaThanhLy);
        }

        private void cboMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionStr = CSDL.connectionStr;
            SqlConnection kn = new SqlConnection(connectionStr);
            kn.Open();
            string sql = "select * from SanPham where MaSP = '" + cboMaSP.SelectedValue.ToString() + "'";
            SqlCommand cmdd = new SqlCommand(sql, kn);
            SqlDataReader kq = cmdd.ExecuteReader();
            if (kq.HasRows)
            {
                kq.Read();
                txtTenSP.Text = kq.GetString(1).ToString();
                txtGiaThanhLy.Text = kq.GetDouble(3).ToString();
                txtMoTa.Text = kq.GetString(5).ToString();
                txtMauSac.Text = kq.GetString(6).ToString();
                txtHienTrang.Text = kq.GetString(7).ToString();
                txtNhanHieu.Text = kq.GetString(8).ToString();
            }
            kn.Close();
        }

        private void LVCTThanhLy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection lv = this.LVCTThanhLy.SelectedItems;
            string masp = "";
            string tensp = "";
            string giathanhly = "";
            string mota = "";
            string mausac = "";
            string hientrang = "";
            string nhanhieu = "";
            foreach (ListViewItem item in lv)
            { 
                masp += item.SubItems[0].Text;
                tensp += item.SubItems[1].Text;
                giathanhly += item.SubItems[2].Text;
                mausac += item.SubItems[3].Text;
                nhanhieu += item.SubItems[4].Text;
                mota += item.SubItems[5].Text;
                hientrang += item.SubItems[6].Text;
            }
            cboMaSP.Text = masp.ToString();
            txtTenSP.Text = tensp.ToString();
            txtGiaThanhLy.Text = giathanhly.ToString();
            txtMoTa.Text = mota.ToString();
            txtMauSac.Text = mausac.ToString();
            txtHienTrang.Text = hientrang.ToString();
            txtNhanHieu.Text = nhanhieu.ToString();
        }
    }
}
