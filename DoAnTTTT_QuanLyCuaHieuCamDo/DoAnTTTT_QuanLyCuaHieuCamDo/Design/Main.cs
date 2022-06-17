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
            //cbQuy.FocusedColor = Color.White;
            cbQuy.Items.Add(1);
            cbQuy.Items.Add(2);
            cbQuy.Items.Add(3);
            cbQuy.Items.Add(4);
            cbQuy.SelectedIndex = -1;
            LoadThongKe();
            LoadChiTieuThang();
            LoadChiTieu();
        }
        public void LoadThongKe()
        {
            double TienLai;
            double TienLoi;
            double TienVon;
            double TienDaThanhLy;
            double TienCam;
            double TienChuoc;
            try { txtTienVon.Text = ThongKeDAO.Instance.TienVon(); }
            catch{ txtTienVon.Text = "0"; }

            try { txtDongLai.Text = ThongKeDAO.Instance.DongLai(); }
            catch { txtDongLai.Text = "0"; }

            try { txtDaThanhLy.Text = ThongKeDAO.Instance.SPDaThanhLy(); }
            catch { txtDaThanhLy.Text = "0"; }

            try { txtTienDaThanhLy.Text = ThongKeDAO.Instance.TienDaThanhLy(); }
            catch { txtTienDaThanhLy.Text = "0"; }

            try { txtThanhLy.Text = ThongKeDAO.Instance.SPThanhLy(); }
            catch { txtThanhLy.Text = "0"; }

            try { txtTienThanhLy.Text = ThongKeDAO.Instance.TienThanhLy(); }
            catch { txtTienThanhLy.Text = "0"; }

            try { txtQuaHan.Text = ThongKeDAO.Instance.SPTQuaHan(); }
            catch { txtQuaHan.Text = "0"; }

            try { txtTienQuaHan.Text = ThongKeDAO.Instance.TienQuaHan(); }
            catch { txtTienQuaHan.Text = "0"; }

            try { txtChuoc.Text = ThongKeDAO.Instance.SPTDaChuoc(); }
            catch { txtChuoc.Text = "0"; }

            try { txtTienChuoc.Text = ThongKeDAO.Instance.TienDaChuoc(); }
            catch { txtTienChuoc.Text = "0"; }

            try { txtCam.Text = ThongKeDAO.Instance.SPCam(); }
            catch { txtCam.Text = "0"; }

            try { txtTienCam.Text = ThongKeDAO.Instance.TienCam(); }
            catch { txtTienCam.Text = "0"; }

            try { TienLai = Convert.ToDouble(ThongKeDAO.Instance.DongLai()); }
            catch { TienLai = Convert.ToDouble(0); }

            try {  TienLoi = Convert.ToDouble(ThongKeDAO.Instance.TienLoi()); }
            catch { TienLoi = Convert.ToDouble(0); }

            txtTienLoi.Text = Convert.ToString(TienLoi + TienLai);

            try {  TienVon = Convert.ToDouble(ThongKeDAO.Instance.TienVon()); }
            catch {  TienVon = Convert.ToDouble(0); }

            try { TienDaThanhLy = Convert.ToDouble(ThongKeDAO.Instance.TienDaThanhLy()); }
            catch { TienDaThanhLy = Convert.ToDouble(0); }

            try { TienCam = Convert.ToDouble(ThongKeDAO.Instance.TienCam()); }
            catch { TienCam = Convert.ToDouble(0); }

            try { TienChuoc = Convert.ToDouble(ThongKeDAO.Instance.TienDaChuoc()); }
            catch { TienChuoc = Convert.ToDouble(0); }

            txtTienMat.Text = Convert.ToString(TienVon - TienCam + TienLai + TienDaThanhLy + TienChuoc);
        }
        public void LoadChiTieu()
        {
            double TienLai;
            double TienLoi;
            double ChiTieu;
            double DoanhThu;

            try { TienLai = Convert.ToDouble(ThongKeDAO.Instance.DongLai()); }
            catch { TienLai = Convert.ToDouble(0); }

            try { TienLoi = Convert.ToDouble(ThongKeDAO.Instance.TienLoi()); }
            catch { TienLoi = Convert.ToDouble(0); }

            try { ChiTieu = Convert.ToDouble(ThongKeDAO.Instance.ChiTieu()); }
            catch { ChiTieu = Convert.ToDouble(0); }

            DoanhThu = (double)(TienLai + TienLoi) / ChiTieu;
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

        

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DateTime ngaydau = dtpNgayDau.Value;
            DateTime ngaycuoi = dtpNgayCuoi.Value;
            double TienLai=0;
            double TienLoi=0;
            try
            {
                txtDongLai.Text = ThongKeDAO.Instance.TKDongLai(ngaydau, ngaycuoi);
            }
            catch
            {
                txtDongLai.Text = Convert.ToString(0);
            }
            try
            {
                TienLai = Convert.ToDouble(ThongKeDAO.Instance.TKDongLai(ngaydau, ngaycuoi));
                TienLoi = Convert.ToDouble(ThongKeDAO.Instance.TKTienLoi(ngaydau, ngaycuoi));
                txtTienLoi.Text = Convert.ToString(TienLoi + TienLai);
            }
            catch
            {
                txtTienLoi.Text = Convert.ToString(0);
            }
            try
            {
                txtDaThanhLy.Text = ThongKeDAO.Instance.TKSPDaThanhLy(ngaydau, ngaycuoi);
                txtTienDaThanhLy.Text = ThongKeDAO.Instance.TKTienDaThanhLy(ngaydau, ngaycuoi);
            }
            catch
            {
                txtDaThanhLy.Text = Convert.ToString(0);
                txtTienDaThanhLy.Text = Convert.ToString(0);
            }
            try
            {
                txtThanhLy.Text = ThongKeDAO.Instance.TKSPThanhLy(ngaydau, ngaycuoi);
                txtTienThanhLy.Text = ThongKeDAO.Instance.TKTienSPThanhLy(ngaydau, ngaycuoi);
            }
            catch
            {
                txtThanhLy.Text = Convert.ToString(0);
                txtTienThanhLy.Text = Convert.ToString(0);
            }
            try
            {
                txtQuaHan.Text = ThongKeDAO.Instance.TKSPQuaHan(ngaydau, ngaycuoi);
                txtTienQuaHan.Text = ThongKeDAO.Instance.TKTienSPQuaHan(ngaydau, ngaycuoi);
            }
            catch
            {
                txtQuaHan.Text = Convert.ToString(0);
                txtTienQuaHan.Text = Convert.ToString(0);
            }
            try
            {
                txtChuoc.Text = ThongKeDAO.Instance.TKSPDaChuoc(ngaydau, ngaycuoi);
                txtTienChuoc.Text = ThongKeDAO.Instance.TKTienSPDaChuoc(ngaydau, ngaycuoi);
            }
            catch
            {
                txtChuoc.Text = Convert.ToString(0);
                txtTienChuoc.Text = Convert.ToString(0);
            }
            try
            {
                txtCam.Text = ThongKeDAO.Instance.TKSPCam(ngaydau, ngaycuoi);
                txtTienCam.Text = ThongKeDAO.Instance.TKTienSPCam(ngaydau, ngaycuoi);
            }
            catch
            {
                txtCam.Text = Convert.ToString(0);
                txtTienCam.Text = Convert.ToString(0);
            }
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            LoadThongKe();
        }

        private void cbQuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nam = Convert.ToString(DateTime.Now.Year);
            string timein ;
            string timeout;
            if (cbQuy.SelectedIndex == 0)
            {
                timein = "1/1/" + nam;
                timeout = "3/31/" + nam;
            }
            else if (cbQuy.SelectedIndex == 1)
            {
                timein = "4/1/" + nam;
                timeout = "6/30/" + nam;
            }
            else if (cbQuy.SelectedIndex == 2)
            {
                timein = "7/1/" + nam;
                timeout = "9/30/" + nam;
            }
            else
            {
                timein = "10/1/" + nam;
                timeout = "12/31/" + nam;
            }
            DateTime ngaydau = (DateTime)Convert.ToDateTime(timein);
            DateTime ngaycuoi = (DateTime)Convert.ToDateTime(timeout);
            try 
            {
                txtDongLai.Text = ThongKeDAO.Instance.TKDongLai(ngaydau, ngaycuoi);
            }
            catch
            {
                txtDongLai.Text = Convert.ToString(0);
            }
            try
            {
                double TienLai = Convert.ToDouble(ThongKeDAO.Instance.TKDongLai(ngaydau, ngaycuoi));
                double TienLoi = Convert.ToDouble(ThongKeDAO.Instance.TKTienLoi(ngaydau, ngaycuoi));
                txtTienLoi.Text = Convert.ToString(TienLoi + TienLai);
            }
            catch
            {
                txtTienLoi.Text = Convert.ToString(0);
            }
            try
            {   
                txtDaThanhLy.Text = ThongKeDAO.Instance.TKSPDaThanhLy(ngaydau, ngaycuoi);
                txtTienDaThanhLy.Text = ThongKeDAO.Instance.TKTienDaThanhLy(ngaydau, ngaycuoi);
            }
            catch
            {
                txtDaThanhLy.Text = Convert.ToString(0);
                txtTienDaThanhLy.Text = Convert.ToString(0);
            }
            try
            {
                txtThanhLy.Text = ThongKeDAO.Instance.TKSPThanhLy(ngaydau, ngaycuoi);
                txtTienThanhLy.Text = ThongKeDAO.Instance.TKTienSPThanhLy(ngaydau, ngaycuoi);
            }
            catch
            {
                txtThanhLy.Text = Convert.ToString(0);
                txtTienThanhLy.Text = Convert.ToString(0);
            }
            try
            {   
                txtQuaHan.Text = ThongKeDAO.Instance.TKSPQuaHan(ngaydau, ngaycuoi);
                txtTienQuaHan.Text = ThongKeDAO.Instance.TKTienSPQuaHan(ngaydau, ngaycuoi);
            }
            catch
            {
                txtQuaHan.Text = Convert.ToString(0);
                txtTienQuaHan.Text = Convert.ToString(0);
            }
            try
            {
                txtChuoc.Text = ThongKeDAO.Instance.TKSPDaChuoc(ngaydau, ngaycuoi);
                txtTienChuoc.Text = ThongKeDAO.Instance.TKTienSPDaChuoc(ngaydau, ngaycuoi);
            }
            catch
            {
                txtChuoc.Text = Convert.ToString(0);
                txtTienChuoc.Text = Convert.ToString(0);
            }
            try
            {
                txtCam.Text = ThongKeDAO.Instance.TKSPCam(ngaydau, ngaycuoi);
                txtTienCam.Text = ThongKeDAO.Instance.TKTienSPCam(ngaydau, ngaycuoi);
            }
            catch
            {
                txtCam.Text = Convert.ToString(0);
                txtTienCam.Text = Convert.ToString(0);
            }
        }

        private void cboThang_SelectedValueChanged(object sender, EventArgs e)
        {
            //LoadChiTieuThang();
        }
    }
}
