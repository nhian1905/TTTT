using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.DAO
{
    public class ThongKeDAO
    {
        private static ThongKeDAO instance;

        public static ThongKeDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThongKeDAO();
                return instance;
            }
            private set => instance = value;
        }

        private ThongKeDAO() { }
        public string TienVon()
        {
            string query = string.Format("select TongTien from Tien where ID = 1");
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq ;
        }

        public bool UpdateTien(double Tien)
        {
            string query = string.Format("update Tien set TongTien=N'{0}' where ID =1",Tien);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }
        public string ChiTieuThang()
        {
            string query = string.Format("select DoanhThuThang from Tien where ID = 1");
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }

        public bool UpdateChiTieuThang(double Tien)
        {
            string query = string.Format("update Tien set DoanhThuThang=N'{0}' where ID =1", Tien);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }
        public string ChiTieu()
        {
            string query = string.Format("select TongDoanhThu from Tien where ID = 1");
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }
        
        public bool UpdateChiTieu(double Tien)
        {
            string query = string.Format("update Tien set TongDoanhThu=N'{0}' where ID =1", Tien);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

        //DongLai
        public string DongLai()
        {
            string query = string.Format("exec USP_DongLai");
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }
        //DaThanhLy
        public string SPDaThanhLy()
        {
            string query = string.Format("select COUNT(MaThanhLy) from ChiTiet_ThanhLy");
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }
        public string TienDaThanhLy()
        {
            string query = string.Format("select sum(a.GiaThanhLy) from ChiTiet_ThanhLy b,SanPham a where b.MaSP=a.MaSP");
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }
        //ThanhLy
        public string SPThanhLy()
        {
            string query = string.Format("select COUNT(MaSp) from SanPham where ThanhLy=1");
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }
        public string TienThanhLy()
        {
            string query = string.Format("select sum(a.GiaThanhLy) from SanPham a where a.ThanhLy=1");
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }
        //QuaHan
        public string SPTQuaHan()
        {
            string query = string.Format("select COUNT(MaSp) from SanPham where QuaHan=1");
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }
        public string TienQuaHan()
        {
            string query = string.Format("select sum(a.DinhGia) from SanPham a where a.QuaHan=1");
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }
        //DaChuoc
        public string SPTDaChuoc()
        {
            string query = string.Format("select COUNT(MaSp) from SanPham where DaChuoc=1");
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }
        public string TienDaChuoc()
        {
            string query = string.Format("select sum(a.DinhGia) from SanPham a where a.DaChuoc=1");
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }

        //Cam
        public string SPCam()
        {
            string query = string.Format("select COUNT(MaSp) from SanPham");
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }
        public string TienCam()
        {
            string query = string.Format("select sum(a.DinhGia) from SanPham a ");
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }

        //TienLoi
        public string TienLoi()
        {
            string query = string.Format("select SUM(a.GiaThanhLy-a.DinhGia) from ChiTiet_ThanhLy b,SanPham a where b.MaSP=a.MaSP");
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }
        //DoanhThuThang
        public string DoanhThuThang(int Thang)
        {
            string query = string.Format("exec USP_DoanhThuThang N'{0}'",Thang);
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }
    }
}
