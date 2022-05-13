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

        void LoadPhieuLai(int MaHoaDonCam)
        {
            LVPhieuLai.Items.Clear();
            List<PhieuLaiDTO> list = PhieuLaiDAO.Instance.LoadListPhieuLai(MaHoaDonCam);
            foreach (PhieuLaiDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaPhieuLai.ToString());
                lvitem.SubItems.Add(item.TenKH.ToString());
                lvitem.SubItems.Add(item.NgayDongLai.ToString());
                lvitem.SubItems.Add(item.TongTien.ToString());
                LVPhieuLai.Items.Add(lvitem);
            }
        }

        void LoadNgayDongLaiHDC()
        {
            int MaHoaDonCam = (int)Convert.ToInt32(txtMaHDC.Text);
            DateTime NgayDongLai = (DateTime)Convert.ToDateTime(DateTime.Now);
            PhieuLaiDAO.Instance.UpdateNgayLap(NgayDongLai, MaHoaDonCam);
            LoadHoaDonCam();
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
            int MaHoaDonCam = int.Parse(txtMaHDC.Text);
            DateTime NgayHienTai = (DateTime)Convert.ToDateTime(DateTime.Now);
            txtTienLai.Text =Convert.ToString(PhieuLaiDAO.Instance.TienLai( NgayHienTai, MaHoaDonCam));
            LoadPhieuLai(MaHoaDonCam);
        }
        void LoadCboKH()
        {
            cboMaKH.DataSource = KhachHangDAO.Instance.LoadListKH();
            cboMaKH.DisplayMember = "MaKH";
            cboMaKH.ValueMember = "MaKH";
            //cboMaKH.SelectedIndex = 0;
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
            int MaHoaDonCam = (int)Convert.ToInt32(txtMaHDC.Text);
            if(PhieuLaiDAO.Instance.InsertPhieuLai(Convert.ToInt32(txtMaHDC.Text),DateTime.Now, Convert.ToDouble(txtTienLai.Text)))
            {
                MessageBox.Show("Đóng Lãi Thành Công");
                LoadPhieuLai(MaHoaDonCam);
                LoadNgayDongLaiHDC();
                txtTienLai.Clear();
            }
        }
    }
}
