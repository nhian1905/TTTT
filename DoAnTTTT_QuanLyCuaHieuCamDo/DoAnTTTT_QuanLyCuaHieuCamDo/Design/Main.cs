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
using DoAnTTTT_QuanLyCuaHieuCamDo.Design;
namespace DoAnTTTT_QuanLyCuaHieuCamDo
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            DateTime NgayHienTai = DateTime.Now;
            SanPhamDAO.Instance.UpdateSPQuaHan(NgayHienTai);

            cboThang.Items.Add("1");
            cboThang.Items.Add("2");
            cboThang.Items.Add("3");
            cboThang.Items.Add("4");
            cboThang.Items.Add("5");
            cboThang.Items.Add("6");
            cboThang.Items.Add("7");
            cboThang.Items.Add("8");
            cboThang.Items.Add("9");
            cboThang.Items.Add("10");
            cboThang.Items.Add("11");
            cboThang.Items.Add("12");

            int thang = DateTime.Now.Month;
            cboThang.SelectedIndex = thang-1;

            double doanhthuthang = (double)20/100;
            DoanhThuThang.Value = Convert.ToInt32(doanhthuthang*100);
        }


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            TongTien f = new TongTien();
            f.Show();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //DoanhThuThang f = new DoanhThuThang();
            
            //f.Show();
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            ChiTieu f = new ChiTieu();
            f.Show();
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            ChiTieuThang f = new ChiTieuThang();
            f.Show();
        }
    }
}
