using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DoAnTTTT_QuanLyCuaHieuCamDo.DAO;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;
using System.Data.SqlClient;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.Design
{
    public partial class TrangChu : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
    (
        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse
    );

        public TrangChu(AccountDTO Acc)
        {
            this.Loginacc = Acc;
            InitializeComponent();
            Quyen();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnTrangChu.Height;
            pnlNav.Top = btnTrangChu.Top;
            pnlNav.Left = btnTrangChu.Left;
            btnTrangChu.BackColor = Color.FromArgb(46, 51, 73);
            this.callform(new Main());
        }

        private AccountDTO loginacc;

        public AccountDTO Loginacc
        {
            get { return loginacc; }
            set { loginacc = value; }
        }

      
        void Quyen()
        {
            
        }
        public void callform(object formhija)
        {
            if (this.panel3.Controls.Count > 0)
                this.panel3.Controls.RemoveAt(0);
            Form f = formhija as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(f);
            this.panel3.Tag = f;
            f.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnTrangChu.Height;
            pnlNav.Top = btnTrangChu.Top;
            pnlNav.Left = btnTrangChu.Left;
            btnTrangChu.BackColor = Color.FromArgb(46, 51, 73);
            this.callform(new Main());
        }

        private void btnTrangChu_Leave(object sender, EventArgs e)
        {
            btnTrangChu.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnSanPham.Height;
            pnlNav.Top = btnSanPham.Top;
            pnlNav.Left = btnSanPham.Left;
            btnSanPham.BackColor = Color.FromArgb(46, 51, 73);
            this.callform(new SanPham());
        }

        private void btnCamDo_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnCamDo.Height;
            pnlNav.Top = btnCamDo.Top;
            pnlNav.Left = btnCamDo.Left;
            btnCamDo.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnDongLai_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDongLai.Height;
            pnlNav.Top = btnDongLai.Top;
            pnlNav.Left = btnDongLai.Left;
            btnDongLai.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnThanhLy_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnThanhLy.Height;
            pnlNav.Top = btnThanhLy.Top;
            pnlNav.Left = btnThanhLy.Left;
            btnThanhLy.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDoanhThu.Height;
            pnlNav.Top = btnDoanhThu.Top;
            pnlNav.Left = btnDoanhThu.Left;
            btnDoanhThu.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnKhachHang.Height;
            pnlNav.Top = btnKhachHang.Top;
            pnlNav.Left = btnKhachHang.Left;
            btnKhachHang.BackColor = Color.FromArgb(46, 51, 73);
            this.callform(new KhachHang());
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnBaoCao.Height;
            pnlNav.Top = btnBaoCao.Top;
            pnlNav.Left = btnBaoCao.Left;
            btnBaoCao.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnSanPham_Leave(object sender, EventArgs e)
        {
            btnSanPham.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnCamDo_Leave(object sender, EventArgs e)
        {
            btnCamDo.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnDongLai_Leave(object sender, EventArgs e)
        {
            btnDongLai.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnThanhLy_Leave(object sender, EventArgs e)
        {
            btnThanhLy.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnDoanhThu_Leave(object sender, EventArgs e)
        {
            btnDoanhThu.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnKhachHang_Leave(object sender, EventArgs e)
        {
            btnKhachHang.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnBaoCao_Leave(object sender, EventArgs e)
        {
            btnBaoCao.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

