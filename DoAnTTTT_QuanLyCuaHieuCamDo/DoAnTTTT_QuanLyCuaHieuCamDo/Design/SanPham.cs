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
            LoadCboLoaiSP();
        }

        void LoadCboLoaiSP()
        {
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

        void ResetSP()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtDinhGia.Clear();
            txtGiaThanhLy.Clear();
            txtMoTa.Clear();
            txtHienTrang.Clear();
            txtHienTrang.Clear();
        }

        void ResetLoaiSP ()
        {
            txtMaLoai.Clear();
            txtTenLoai.Clear();
            txtLaiSuat.Clear();
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

        private void LVSP_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                ListView.SelectedListViewItemCollection lv = this.LVSP.SelectedItems;
                string masp = "";
                string maloai = "";
                string tensp = "";
                string dinhgia = "";
                string giathanhly = "";
                string mota = "";
                string mausac = "";
                string hientrang = "";
                string nhanhieu = "";
                foreach (ListViewItem item in lv)
                {
                    masp += item.SubItems[0].Text;
                    maloai += item.SubItems[1].Text;
                    tensp += item.SubItems[2].Text;
                    dinhgia += item.SubItems[3].Text;
                    giathanhly += item.SubItems[4].Text;
                    mota += item.SubItems[5].Text;
                    mausac += item.SubItems[6].Text;
                    hientrang += item.SubItems[7].Text;
                    nhanhieu += item.SubItems[8].Text;
                }
                txtMaSP.Text = masp.ToString();
                txtTenSP.Text = tensp.ToString();
                txtDinhGia.Text = dinhgia.ToString();
                txtGiaThanhLy.Text = giathanhly.ToString();
                cboTenLoai.Text = maloai.ToString();
                txtMoTa.Text = mota.ToString();
                txtMauSac.Text = mausac.ToString();
                txtHienTrang.Text = hientrang.ToString();
                txtNhanHieu.Text = nhanhieu.ToString();
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
                    ResetSP();
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

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            string MaSP = txtMaSP.Text;
            int MaLoai = (cboTenLoai.SelectedItem as LoaiSPDTO).MaLoai;
            string TenSP = txtTenSP.Text;
            float DinhGia = (float)Convert.ToDouble(txtDinhGia.Text);
            float GiaThanhLy = (float)Convert.ToDouble(txtGiaThanhLy.Text);
            string MoTa = txtMoTa.Text;
            string MauSac = txtMauSac.Text;
            string HienTrang = txtHienTrang.Text;
            string NhanHieu = txtNhanHieu.Text;
            if (MaSP != "")
            {

                if (SanPhamDAO.Instance.UpdateSP(MaSP, MaLoai, TenSP, DinhGia, GiaThanhLy, MoTa, MauSac, HienTrang,NhanHieu))
                {
                    MessageBox.Show("Sửa Thành Công");
                    LoadSanPham();
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
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text == null)
            {
                MessageBox.Show("Vui Lòng Chọn Sản Phẩm Cần Xóa");
                return;
            }
            string MaSP = txtMaSP.Text;
            DialogResult tb = MessageBox.Show("Bạn Có Muốn Xóa Sản Phẩm Này Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                SanPhamDAO.Instance.DeleteSP(MaSP);
            }
            else
            {
                return;
            }
            LoadSanPham();
        }
        private void btnThanhLy_Click(object sender, EventArgs e)
        {
            string MaSP = txtMaSP.Text;
            bool ThanhLy = (bool)Convert.ToBoolean(1);
            if (SanPhamDAO.Instance.ThanhLySP(MaSP,ThanhLy))
            {
                MessageBox.Show("Đã Thanh Lý Thành Công");
                LoadSanPham();
            }
            else
            {
                MessageBox.Show("Thanh Lý Thất Bại", "thông Báo");
                return;
            }
        }

        // LOẠI SẢN PHẨM
        private void LVLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection lv = this.LVLoaiSP.SelectedItems;
            string tenloai = "";
            int maloai = 0;
            string laixuat = "";
            foreach (ListViewItem item in lv)
            {
                maloai +=Convert.ToInt32(item.SubItems[0].Text);
                tenloai += item.SubItems[1].Text;
                laixuat += item.SubItems[2].Text;
            }
            txtMaLoai.Text = maloai.ToString();
            txtTenLoai.Text = tenloai.ToString();
            txtLaiSuat.Text = laixuat.ToString();
            
        }
        private void btnThemLoaiSP_Click(object sender, EventArgs e)
        {
            if (txtTenLoai.Text != "")
            {
                string TenLoai = txtTenLoai.Text;
                //int MaLoai = (int)Convert.ToInt32(txtMaLoai.Text);
                float LaiXuat = (float)Convert.ToDouble(txtLaiSuat.Text);
                if (LoaiSPDAO.Instance.InsertLoaiSP( TenLoai, LaiXuat))
                {
                    MessageBox.Show("Thêm Loại Sản Phẩm Thành Công", "Thông Báo");
                    ResetLoaiSP();
                    LoadCboLoaiSP();
                }
                else
                {
                    MessageBox.Show("Thêm Thất Bại! Vui Lòng Nhập Lại", "Thông Báo");
                }
                LoadLoaiSP();
            }
            else
            {
                MessageBox.Show("Không được để trống Tên", "thông báo");
                txtTenLoai.Focus();
            }
        }

        private void btnSuaLoaiSP_Click(object sender, EventArgs e)
        {
            string TenLoai = txtTenLoai.Text;
            int MaLoai = (int)Convert.ToInt32(txtMaLoai.Text);
            float LaiXuat = (float)Convert.ToDouble(txtLaiSuat.Text);
            if (txtMaLoai.Text != "")
            {

                if (LoaiSPDAO.Instance.UpdateLoaiSP( MaLoai, TenLoai , LaiXuat))
                {
                    MessageBox.Show("Sửa Thành Công");
                    LoadLoaiSP();
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
        }

        private void btnXoaLoaiSP_Click(object sender, EventArgs e)
        {
            if (txtMaLoai.Text == null)
            {
                MessageBox.Show("Vui Lòng Chọn Loại Sản Phẩm Cần Xóa");
                return;
            }
            int LoaiSP =(int)Convert.ToInt32(txtMaLoai.Text);
            DialogResult tb = MessageBox.Show("Bạn Có Muốn Xóa Loại Sản Phẩm Này Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                LoaiSPDAO.Instance.DeleteLoaiSP(LoaiSP);
            }
            else
            {
                return;
            }
            LoadLoaiSP();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            bool ThanhLy = (bool)Convert.ToBoolean(cbThanhLy.Checked );
            bool QuaHan = (bool)Convert.ToBoolean(cbQuaHan.Checked );
            bool DaChuoc = (bool)Convert.ToBoolean(cbDaChuoc.Checked );
            bool DaThanhLy = (bool)Convert.ToBoolean(cbDaThanhLy.Checked);
            LVSP.Items.Clear();
            List<SanPhamDTO> list = SanPhamDAO.Instance.TimKiem(ThanhLy,QuaHan, DaChuoc,DaThanhLy);
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
    }
}
