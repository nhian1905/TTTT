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
    public partial class BaoCao : Form
    {
        public BaoCao()
        {
            InitializeComponent();
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {
            LoadHoaDonCam();
            LoadPhieuChuoc();
            LoadThanhLy();
            LoadHoaDonCamPL();
        }

        void LoadHoaDonCam()
        {
            LVHDC.Items.Clear();
            List<HoaDonCamDTO> list = HoaDonCamDAO.Instance.LoadListHoaDonCam();
            foreach (HoaDonCamDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaHoaDonCam.ToString());
                lvitem.SubItems.Add(item.TenKH.ToString());
                lvitem.SubItems.Add(item.NgayLap.ToString());
                lvitem.SubItems.Add(item.NgayHetHan.ToString());
                lvitem.SubItems.Add(item.TongTienCam.ToString());
                LVHDC.Items.Add(lvitem);
            }
        }

        void LoadCTHoaDonCam(int MaHDC)
        {
            LVCTHDC.Items.Clear();
            List<ChiTietHoaDonCamDTO> list = ChiTietHoaDonCamDAO.Instance.LoadListCTHDC(MaHDC);
            foreach (ChiTietHoaDonCamDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaHoaDonCam.ToString());
                lvitem.SubItems.Add(item.MaSP.ToString());
                lvitem.SubItems.Add(item.TenLoai.ToString());
                lvitem.SubItems.Add(item.TenSP.ToString());
                lvitem.SubItems.Add(item.DinhGia.ToString());
                lvitem.SubItems.Add(item.MoTa.ToString());
                lvitem.SubItems.Add(item.MauSac.ToString());
                lvitem.SubItems.Add(item.HienTrang.ToString());
                lvitem.SubItems.Add(item.NhanHieu.ToString());
                LVCTHDC.Items.Add(lvitem);
            }
        }
        /// <summary>
        /// ////////// PHIEU CHUOC
        /// </summary>
        void LoadPhieuChuoc()
        {
            LvPhieuChuoc.Items.Clear();
            List<PhieuChuocDTO> list = PhieuChuocDAO.Instance.LoadListPhieuChuoc();
            foreach (PhieuChuocDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaPhieuChuoc.ToString());
                lvitem.SubItems.Add(item.MaHoaDonCam.ToString());
                lvitem.SubItems.Add(item.NgayChuoc.ToString());
                lvitem.SubItems.Add(item.TongTien.ToString());
                LvPhieuChuoc.Items.Add(lvitem);
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


        /// <summary>
        /// ///// THANH LY
        /// </summary>
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
            List<ChiTietThanhLyDTO> list = ChiTietThanhLyDAO.Instance.LoadListCTThanhLy(MaThanhLy);
            foreach (ChiTietThanhLyDTO item in list)
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
        /// <summary>
        /// Phieu Lai
        /// </summary>
        void LoadHoaDonCamPL()
        {
            LVPhieuCam.Items.Clear();
            List<HoaDonCamDTO> list = HoaDonCamDAO.Instance.LoadListHoaDonCam();
            foreach (HoaDonCamDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaHoaDonCam.ToString());
                lvitem.SubItems.Add(item.TenKH.ToString());
                lvitem.SubItems.Add(item.NgayLap.ToString());
                lvitem.SubItems.Add(item.NgayHetHan.ToString());
                lvitem.SubItems.Add(item.TongTienCam.ToString());
                LVPhieuCam.Items.Add(lvitem);
            }
        }

        void LoadPhieuLai(int MaHoaDonCam)
        {
            LVPhieuLai.Items.Clear();
            List<PhieuLaiDTO> list = PhieuLaiDAO.Instance.LoadListPhieuLai(MaHoaDonCam);
            foreach (PhieuLaiDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaPhieuLai.ToString());
                lvitem.SubItems.Add(item.MaHoaDonCam.ToString());
                lvitem.SubItems.Add(item.NgayDongLai.ToString());
                lvitem.SubItems.Add(item.TongTien.ToString());
                LVPhieuLai.Items.Add(lvitem);
            }
        }


        private void LVHDC_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection lvv = this.LVHDC.SelectedItems;
            int id = 0;
            foreach (ListViewItem item in lvv)
            {
                id += Int32.Parse(item.SubItems[0].Text);
            }
            txtMaHDC.Text = id.ToString();
            int MaHoaDonCam = int.Parse(txtMaHDC.Text);
            LoadCTHoaDonCam(MaHoaDonCam);
        }

        private void LvPhieuChuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection lv = this.LvPhieuChuoc.SelectedItems;
            int maphieuchuoc = 0;
            foreach (ListViewItem item in lv)
            {
                maphieuchuoc += Int32.Parse(item.SubItems[0].Text);
            }
            txtMaPhieuChuoc.Text = maphieuchuoc.ToString();
            int MaPhieuChuoc = int.Parse(txtMaPhieuChuoc.Text);
            LoadCTPhieuChuoc(MaPhieuChuoc);
        }

        private void LVThanhLy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection lv = this.LVThanhLy.SelectedItems;
            int mathanhly = 0;
            foreach (ListViewItem item in lv)
            {
                mathanhly += Int32.Parse(item.SubItems[0].Text);
            }
            txtMaThanhLy.Text = mathanhly.ToString();
            int MaThanhLy = (int)Convert.ToInt32(txtMaThanhLy.Text);
            LoadCTThanhLy(MaThanhLy);
        }

        private void LVPhieuCam_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection lv = this.LVPhieuCam.SelectedItems;
            int mahoadoncam = 0;
            foreach (ListViewItem item in lv)
            {
                mahoadoncam += Int32.Parse(item.SubItems[0].Text);
            }
            txtMaHDC.Text = mahoadoncam.ToString();
            int MaHDC = (int)Convert.ToInt32(txtMaHDC.Text);
            LoadPhieuLai(MaHDC);
        }
    }
}
