using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;
using DoAnTTTT_QuanLyCuaHieuCamDo.DAO;
using System.Data.SqlClient;

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
            LoadSanPham();
            LoadLoaiSP();
            cboTenLoai.DataSource = LoaiSPDAO.Instance.LoadListLoaiSP();
            cboTenLoai.DisplayMember = "TenLoai";
        }

        void LoadSanPham()
        {
            LVSP.Items.Clear();
            List<SanPhamDTO> list = SanPhamDAO.Instance.LoadListSP();
            foreach (SanPhamDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaSP.ToString());
                lvitem.SubItems.Add(item.TenLoai.ToString());
                lvitem.SubItems.Add(item.TenSP.ToString());
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

        private void btnThemKH_Click(object sender, EventArgs e)
        {

        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text != "")
            {
                string MaSP = txtTenSP.Text;
                int MaLoai = (cboTenLoai.SelectedItem as LoaiSPDTO).MaLoai;
                string TenSP = txtTenSP.Text;
                float DinhGia = (float)Convert.ToDouble(txtDinhGia.Text);
                float GiaThanhLy = (float)Convert.ToDouble(txtGiaThanhLy.Text);
                string MoTa = txtMoTa.Text;
                string MauSac = txtMauSac.Text;
                string HienTrang = txtHienTrang.Text;
                string NhanHieu = txtNhanHieu.Text;
                bool QuaHan = (bool)Convert.ToBoolean(0);
                bool DaChuoc = (bool)Convert.ToBoolean(0);
                bool ThanhLy = (bool)Convert.ToBoolean(0);
                bool DaThanhLy = (bool)Convert.ToBoolean(0);
                
                if (SanPhamDAO.Instance.InsertSP(MaSP, MaLoai, TenSP, DinhGia, GiaThanhLy, MoTa, MauSac, HienTrang, NhanHieu, QuaHan, DaChuoc, ThanhLy, DaThanhLy))
                {
                    MessageBox.Show("Thêm Sản Phẩm Thành Công", "Thông Báo");
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
        }

        private void LVSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListView.SelectedListViewItemCollection lv = this.LVSP.SelectedItems;
                string masp = "";
                int maloai = 0;
                string tensp = "";
                float dinhgia = 0;
                float giathanhly = 0;
                string mota = "";
                string mausac = "";
                string hientrang = "";
                string nhanhieu = "";
                foreach (ListViewItem item in lv)
                {
                    masp += item.SubItems[0].Text;
                    tensp += item.SubItems[1].Text;
                    dinhgia += float.Parse(item.SubItems[2].Text);
                    giathanhly += float.Parse(item.SubItems[3].Text);
                    maloai += Int32.Parse(item.SubItems[4].Text);
                    mota += item.SubItems[5].Text;
                    mausac += item.SubItems[6].Text;
                    hientrang += item.SubItems[7].Text;
                    nhanhieu += item.SubItems[8].Text;
                }
                txtMaSP.Text = masp.ToString();
                txtTenSP.Text = tensp.ToString();
                txtDinhGia.Text = dinhgia.ToString();
                txtGiaThanhLy.Text = giathanhly.ToString();
                cboTenLoai.SelectedItem = maloai.ToString();
                txtMoTa.Text = mota.ToString();
                txtMauSac.Text = mausac.ToString();
                txtHienTrang.Text = hientrang.ToString();
                txtNhanHieu.Text = nhanhieu.ToString();
            }
            catch
            {

            }
        }
    }
}
