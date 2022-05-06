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
                lvitem.SubItems.Add(item.MaRieng.ToString());
                lvitem.SubItems.Add(item.QuaHan.ToString());
                lvitem.SubItems.Add(item.DaChuoc.ToString());
                lvitem.SubItems.Add(item.ThanhLy.ToString());
                lvitem.SubItems.Add(item.DaThanhLy.ToString());
                LVSP.Items.Add(lvitem);
            }

        }
    }
}
