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

        void LoadCTThanhLy()
        {

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
            string tenkh = "";
            string ngaylap = "";
            string tongtienthanhly = "";
            foreach (ListViewItem item in lv)
            {
                mathanhly += Int32.Parse(item.SubItems[0].Text);
                tenkh += item.SubItems[1].Text;
                ngaylap += DateTime.Parse(item.SubItems[2].Text);
                tongtienthanhly += item.SubItems[3].Text;
            }
            txtMaThanhLy.Text = mathanhly.ToString();
            cbKhachHang.Text = tenkh.ToString();
            dtpNgayLap.Text = ngaylap.ToString();
            txtTongTien.Text = tongtienthanhly.ToString();
        }
    }
}
