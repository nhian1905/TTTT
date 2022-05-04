using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;
using DoAnTTTT_QuanLyCuaHieuCamDo.DAO;
using System.Data.SqlClient;

namespace DoAnTTTT_QuanLyCuaHieuCamDo
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            txtTenKhachHang.Text = "Tên khách hàng";
            LoadKhachHang();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            txtTenKhachHang.Text = "";
        }

        void LoadKhachHang()
        {
            LVKH.Items.Clear();
            List<KhachHangDTO> list = KhachHangDAO.Instance.LoadListKH();
            foreach (KhachHangDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaKH.ToString());
                lvitem.SubItems.Add(item.TenKH.ToString());
                lvitem.SubItems.Add(item.SDT.ToString());
                lvitem.SubItems.Add(item.CMND.ToString());
                lvitem.SubItems.Add(item.NamSinh.ToString());
                lvitem.SubItems.Add(item.DiaChi.ToString());
                lvitem.SubItems.Add(item.NgayCapCMND.ToString());
                lvitem.SubItems.Add(item.HinhAnh.ToString());
                LVKH.Items.Add(lvitem);
            }
        }

        private void LVKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListView.SelectedListViewItemCollection lv = this.LVKH.SelectedItems;
                int id = 0;
                string tenkh = "";
                int sdt = 0;
                int cmnd = 0;
                string namsinh = "";
                string diachi = "";
                string ngaycap = "";
                string hinhanh = "";
                pictureBox7.Image = null;

                foreach (ListViewItem item in lv)
                {
                    id += Int32.Parse(item.SubItems[0].Text);
                    tenkh += item.SubItems[1].Text;
                    sdt += Int32.Parse(item.SubItems[2].Text);
                    cmnd += Int32.Parse(item.SubItems[3].Text);
                    namsinh += item.SubItems[4].Text;
                    diachi += item.SubItems[5].Text;
                    ngaycap += item.SubItems[6].Text;
                    hinhanh += item.SubItems[7].Text;
                }
                txtMaKH.Text = id.ToString();
                txtTenKhachHang.Text = tenkh.ToString();
                txtSDT.Text = sdt.ToString();
                txtCMND.Text = cmnd.ToString();
                dtpNgaySinh.Text = namsinh.ToString();
                txtDiaChi.Text = diachi.ToString();
                dtpNgayCapCMND.Text = ngaycap.ToString();
                if (!string.IsNullOrWhiteSpace(hinhanh.ToString()))
                {
                    pictureBox7.Image = Image.FromFile(hinhanh.ToString());
                }
            }
            catch
            {

            }


        }
    }
}
