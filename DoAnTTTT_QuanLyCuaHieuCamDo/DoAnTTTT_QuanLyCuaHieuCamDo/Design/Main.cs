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
            int thang = Convert.ToInt32(DateTime.Now.Month);
            
            SanPhamDAO.Instance.UpdateSPQuaHan(NgayHienTai);
            for(int i=1;i<=thang;i++)
            {
                cboThang.Items.Add(i);
            }
            cboThang.SelectedIndex = thang - 1;

            LoadThongKe();
            LoadChiTieuThang();
            LoadChiTieu();
        }
        public void LoadThongKe()
        {
            txtTienVon.Text = ThongKeDAO.Instance.TienVon();
            txtDongLai.Text = ThongKeDAO.Instance.DongLai();

            txtDaThanhLy.Text = ThongKeDAO.Instance.SPDaThanhLy();
            txtTienDaThanhLy.Text = ThongKeDAO.Instance.TienDaThanhLy();

            txtThanhLy.Text = ThongKeDAO.Instance.SPThanhLy();
            txtTienThanhLy.Text = ThongKeDAO.Instance.TienThanhLy();

            txtQuaHan.Text = ThongKeDAO.Instance.SPTQuaHan();
            txtTienQuaHan.Text = ThongKeDAO.Instance.TienQuaHan();

            txtChuoc.Text = ThongKeDAO.Instance.SPTDaChuoc();
            txtTienChuoc.Text = ThongKeDAO.Instance.TienDaChuoc();

            txtCam.Text = ThongKeDAO.Instance.SPCam();
            txtTienCam.Text = ThongKeDAO.Instance.TienCam();

            double TienLai = Convert.ToDouble(ThongKeDAO.Instance.DongLai());
            double TienLoi = Convert.ToDouble(ThongKeDAO.Instance.TienLoi());
            txtTienLoi.Text = Convert.ToString(TienLoi + TienLai);

            double TienVon = Convert.ToDouble(ThongKeDAO.Instance.TienVon());
            double TienDaThanhLy = Convert.ToDouble(ThongKeDAO.Instance.TienDaThanhLy());
            double TienCam = Convert.ToDouble(ThongKeDAO.Instance.TienCam());
            double TienChuoc = Convert.ToDouble(ThongKeDAO.Instance.TienDaChuoc());
            txtTienMat.Text = Convert.ToString(TienVon - TienCam + TienLai + TienDaThanhLy + TienChuoc);
        }
        public void LoadChiTieu()
        {
            double TienLai = Convert.ToDouble(ThongKeDAO.Instance.DongLai());
            double TienLoi = Convert.ToDouble(ThongKeDAO.Instance.TienLoi());
            double ChiTieu = Convert.ToDouble(ThongKeDAO.Instance.ChiTieu());
            double DoanhThu = (double)(TienLai + TienLoi) / ChiTieu;
            TongDoanhThu.Value = Convert.ToInt32(DoanhThu * 100);
        }
        public void LoadChiTieuThang()
        {
            string TienT = ThongKeDAO.Instance.DoanhThuThang(Convert.ToInt32(cboThang.Text));
            double ChiTieuT = Convert.ToDouble(ThongKeDAO.Instance.ChiTieuThang());
            if (TienT == "")
            {

                DoanhThuThang.Value = 0;
            }
            else
            {

                double DoanhThuT = (double)Convert.ToDouble(TienT) / ChiTieuT;
                DoanhThuThang.Value = Convert.ToInt32(DoanhThuT* 100);
            }
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

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChiTieuThang();
        }

        private void cboThang_SelectedValueChanged(object sender, EventArgs e)
        {
            //LoadChiTieuThang();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DateTime ngaydau =(DateTime)Convert.ToDateTime(dtpNgayDau.Text);
            DateTime ngaycuoi = (DateTime)Convert.ToDateTime(dtpNgayCuoi.Text);
            txtDaThanhLy.Text = ThongKeDAO.Instance.TKSPDaThanhLy(ngaydau,ngaycuoi);
            txtTienDaThanhLy.Text = ThongKeDAO.Instance.TKTienDaThanhLy(ngaydau, ngaycuoi);

            txtThanhLy.Text = ThongKeDAO.Instance.TKSPThanhLy(ngaydau, ngaycuoi);
            txtTienThanhLy.Text = ThongKeDAO.Instance.TKTienSPThanhLy(ngaydau, ngaycuoi);

            txtQuaHan.Text = ThongKeDAO.Instance.TKSPQuaHan(ngaydau, ngaycuoi);
            txtTienQuaHan.Text = ThongKeDAO.Instance.TKTienSPQuaHan(ngaydau, ngaycuoi);

            txtChuoc.Text = ThongKeDAO.Instance.TKSPDaChuoc(ngaydau, ngaycuoi);
            txtTienChuoc.Text = ThongKeDAO.Instance.TKTienSPDaChuoc(ngaydau, ngaycuoi);

            txtCam.Text = ThongKeDAO.Instance.TKSPCam(ngaydau, ngaycuoi);
            txtTienCam.Text = ThongKeDAO.Instance.TKTienSPCam(ngaydau, ngaycuoi);
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            LoadThongKe();
        }
    }
}
