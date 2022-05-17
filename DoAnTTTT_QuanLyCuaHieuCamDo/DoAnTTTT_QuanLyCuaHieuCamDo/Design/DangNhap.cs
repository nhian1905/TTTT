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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        bool login(string taikhoan, string matkhau)
        {
            return AccountDAO.Instance.DangNhap(taikhoan, matkhau);
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taikhoan = txtTaiKhoan.Text;
            string matkhau = txtMatKhau.Text;
            if (taikhoan != "" && matkhau != "")
            {
                if (login(taikhoan, matkhau))
                {
                    AccountDTO loginacc = AccountDAO.Instance.GetAcc(taikhoan);
                    TrangChu TC = new TrangChu(loginacc);
                    this.Hide();
                    TC.Show();
                }
                else
                {
                    MessageBox.Show("ĐĂNG NHẬP THẤT BẠI VUI LÒNG KIỂM TRA ", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("VUI LÒNG NHẬP ĐẦY ĐỦ THÔNG TIN", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
