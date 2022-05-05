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
        string imagelocation = @"";
        public void OpenImage()
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.ShowDialog();
                imagelocation = open.FileName.ToString();
                Image img = Image.FromFile(imagelocation);
                pictureBox7.Image = img;
            }
            catch { }
        } // mở ảnh
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            txtTenKhachHang.Text = "";
        }

        void ResetThongTin()
        {
            txtMaKH.Clear();
            txtTenKhachHang.Clear();
            txtSDT.Clear();
            txtCMND.Clear();
            txtDiaChi.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            dtpNgayCapCMND.Value = DateTime.Now;
            pictureBox7.Image = null; 
        }

        void HienThiThongTin(Boolean hien)
        {
            this.txtMaKH.Enabled = hien;
            this.txtTenKhachHang.Enabled = hien;
            this.txtSDT.Enabled = hien;
            this.txtCMND.Enabled = hien;
            this.txtDiaChi.Enabled = hien;
            this.dtpNgaySinh.Enabled = hien;
            this.dtpNgayCapCMND.Enabled = hien;
            this.pictureBox7.Enabled = hien;
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
            btnThemKH.Enabled = true;

        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == null)
            {
                MessageBox.Show("Vui Lòng Chọn Khách Hàng Cần Xóa");
                return;
            }
            int ID_KhachHang = Convert.ToInt32(txtMaKH.Text);
            DialogResult tb = MessageBox.Show("Bạn Có Muốn Xóa Khách Hàng Này Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                KhachHangDAO.Instance.DeleteCustomer(ID_KhachHang);
                btnSuaKH.Enabled = false;
            }
            else
            {
                return;
            }
            LoadKhachHang();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            btnSuaKH.Enabled = false;
            btnXoaKH.Enabled = false;
            ResetThongTin();
            HienThiThongTin(true);
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            btnThemKH.Enabled = false;
            HienThiThongTin(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnThemKH.Enabled == true)
            {
                if (txtTenKhachHang.Text != "")
                {
                    string TenKH = txtTenKhachHang.Text;
                    int SDT = Convert.ToInt32(txtSDT.Text);
                    int CMND = Convert.ToInt32(txtCMND.Text);
                    DateTime NamSinh = (DateTime)Convert.ToDateTime(dtpNgaySinh.Value);
                    string DiaChi = txtDiaChi.Text;
                    DateTime NgayCapCMND = (DateTime)Convert.ToDateTime(dtpNgayCapCMND.Value);
                    string HinhAnh = imagelocation;
                    if (KhachHangDAO.Instance.InsertCustomer(TenKH, SDT, CMND, NamSinh,DiaChi,NgayCapCMND,HinhAnh))
                    {
                        MessageBox.Show("Thêm Khách Hàng Thành Công", "Thông Báo");
                    }
                    else
                    {
                        MessageBox.Show("Thêm Thất Bại! Vui Lòng Nhập Lại", "Thông Báo");
                    }
                    LoadKhachHang();
                }
                else
                {
                    MessageBox.Show("Không được để trống Tên", "thông báo");
                    txtTenKhachHang.Focus();
                }
                ResetThongTin();
            }
            else if (btnSuaKH.Enabled == true)
            {
                int MaKH = Convert.ToInt32(txtMaKH.Text);
                string TenKH = txtTenKhachHang.Text;
                int SDT = Convert.ToInt32(txtSDT.Text);
                int CMND = Convert.ToInt32(txtCMND.Text);
                DateTime NamSinh = (DateTime)Convert.ToDateTime(dtpNgaySinh.Value);
                string DiaChi = txtDiaChi.Text;
                DateTime NgayCapCMND = (DateTime)Convert.ToDateTime(dtpNgayCapCMND.Value);
                string HinhAnh = imagelocation;
                if (MaKH > 0 && TenKH != "")
                {

                    if (KhachHangDAO.Instance.UpdateCustomer(MaKH, TenKH, SDT, CMND, NamSinh, DiaChi, NgayCapCMND, HinhAnh))
                    {
                        MessageBox.Show("Sửa Thành Công");
                        LoadKhachHang();
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
                btnThemKH.Enabled = true;
            }
        }

        private void btnAnhKH_Click(object sender, EventArgs e)
        {
            OpenImage();
        }
    }
}
