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
        }

        void LoadCboKhachHang()
        {
            cboKhachHang.DataSource = KhachHangDAO.Instance.LoadListKH();
            cboKhachHang.DisplayMember = "TenKH";
            cboKhachHang.ValueMember = "MaKH";
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
                float TongTienCam = (float)Convert.ToDouble(0);
                int MaKH = (cboKhachHang.SelectedItem as KhachHangDTO).MaKH;
                if (HoaDonCamDAO.Instance.InsertHDC(MaKH, NgayLap, NgayHetHan, TongTienCam ))
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
                float TongTienCam = (float)Convert.ToDouble(0);
                int MaKH = (cboKhachHang.SelectedItem as KhachHangDTO).MaKH;
                if (HoaDonCamDAO.Instance.UpdateHDC(MaHoaDonCam,MaKH,NgayLap,NgayHetHan,TongTienCam))
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
            dtpNgayCamHD.Text =ngaylaphdc.ToString();
            dtpNgayHetHan.Text = ngayhethan.ToString();
            txtTongTien.Text = tongtiencam.ToString();
        }
    }
}
