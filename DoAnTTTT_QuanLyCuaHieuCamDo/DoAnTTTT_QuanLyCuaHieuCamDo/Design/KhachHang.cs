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
            //txtTenKhachHang.Text = "Tên khách hàng";
            ResetBtnKH();
            btnThemKH.Enabled = true;
            btnThemKH.BackColor = Color.FromArgb(0, 126, 249);
            btnThemKH.ForeColor = Color.White;
            HienThiThongTin(false);
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
        }
        public void ResetBtnKH()
        {
            btnThemKH.Enabled = false;
            btnThemKH.BackColor = Color.Gray;
            btnThemKH.ForeColor = Color.Black;
            btnAnhKH.Enabled = false;
            btnAnhKH.BackColor = Color.Gray;
            btnAnhKH.ForeColor = Color.Black;
            btnXoaKH.Enabled = false;
            btnXoaKH.BackColor = Color.Gray;
            btnXoaKH.ForeColor = Color.Black;
            btnSuaKH.Enabled = false;
            btnSuaKH.BackColor = Color.Gray;
            btnSuaKH.ForeColor = Color.Black;
            btnLuu.Enabled = false;
            btnLuu.BackColor = Color.Gray;
            btnLuu.ForeColor = Color.Black;
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
            ResetBtnKH();
            btnSuaKH.Enabled = true;
            btnSuaKH.BackColor = Color.FromArgb(0, 126, 249);
            btnSuaKH.ForeColor = Color.White;

            btnXoaKH.Enabled = true;
            btnXoaKH.BackColor = Color.FromArgb(0, 126, 249);
            btnXoaKH.ForeColor = Color.White;

            btnThemKH.Enabled = true;
            btnThemKH.BackColor = Color.FromArgb(0, 126, 249);
            btnThemKH.ForeColor = Color.White;

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
                txtSDT.Text = 0+sdt.ToString();
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

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            try
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
                ResetBtnKH();
                btnThemKH.Enabled = true;
                btnThemKH.BackColor = Color.FromArgb(0, 126, 249);
                btnThemKH.ForeColor = Color.White;
                LoadKhachHang();
            }
            catch
            {
                MessageBox.Show("Không Thể Xóa Khách Hàng Khi Đã Có Hóa Đơn");
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            ResetBtnKH();
            btnThemKH.Enabled = true;
            btnThemKH.BackColor = Color.FromArgb(0, 126, 249);
            btnThemKH.ForeColor = Color.White;

            btnLuu.Enabled = true;
            btnLuu.BackColor = Color.FromArgb(0, 126, 249);
            btnLuu.ForeColor = Color.White;

            btnAnhKH.Enabled = true;
            btnAnhKH.BackColor = Color.FromArgb(0, 126, 249);
            btnAnhKH.ForeColor = Color.White;
            ResetThongTin();
            HienThiThongTin(true);
            this.txtMaKH.Enabled = false;
            txtTenKhachHang.Focus();
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            ResetBtnKH();
            btnSuaKH.Enabled = true;
            btnSuaKH.BackColor = Color.FromArgb(0, 126, 249);
            btnSuaKH.ForeColor = Color.White;

            btnLuu.Enabled = true;
            btnLuu.BackColor = Color.FromArgb(0, 126, 249);
            btnLuu.ForeColor = Color.White;

            btnAnhKH.Enabled = true;
            btnAnhKH.BackColor = Color.FromArgb(0, 126, 249);
            btnAnhKH.ForeColor = Color.White;
            HienThiThongTin(true);
            this.txtMaKH.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtSDT.TextLength != 10)
            {
                errorProvider1.SetError(txtSDT, "Số điện thoại là 10 số");
                return;
            }
            else errorProvider1.Clear();
            if (txtCMND.TextLength != 9 && txtCMND.TextLength != 12)
            {
                errorProvider2.SetError(txtCMND, "Vui lòng nhập đầy đủ số CMND");
                return;
            }
            else errorProvider2.Clear();
            if (txtTenKhachHang.TextLength <= 4 )
            {
                errorProvider3.SetError(txtTenKhachHang, "Vui lòng nhập tên đầy đủ");
                return;
            }
            else errorProvider3.Clear();
            if (txtDiaChi.TextLength <= 15)
            {
                errorProvider4.SetError(txtDiaChi, "Vui lòng nhập đầy đủ thông tin địa chỉ");
                return;
            }
            else errorProvider4.Clear();
            if (btnThemKH.Enabled == true)
            {
                if (txtTenKhachHang.Text != "" )
                {
                    string TenKH = txtTenKhachHang.Text;
                    long SDT = Convert.ToInt64(txtSDT.Text);
                    long CMND = Convert.ToInt64(txtCMND.Text);
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
                    MessageBox.Show("Không được để trống Tên ", "thông báo");
                    txtTenKhachHang.Focus();
                }
                ResetThongTin();
            }
            else if (btnSuaKH.Enabled == true)
            {
                int MaKH = Convert.ToInt32(txtMaKH.Text);
                string TenKH = txtTenKhachHang.Text;
                long SDT = Convert.ToInt64(txtSDT.Text);
                long CMND = Convert.ToInt64(txtCMND.Text);
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
                ResetBtnKH();
                btnThemKH.Enabled = true;
                btnThemKH.BackColor = Color.FromArgb(0, 126, 249);
                btnThemKH.ForeColor = Color.White;
            }
        }

        private void btnAnhKH_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
