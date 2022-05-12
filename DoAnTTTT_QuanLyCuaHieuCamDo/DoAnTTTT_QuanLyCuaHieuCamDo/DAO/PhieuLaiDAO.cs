using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.DAO
{
    public class PhieuLaiDAO
    {
        private static PhieuLaiDAO instance;

        public static PhieuLaiDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhieuLaiDAO();
                return instance;
            }
            private set => instance = value;
        }

        private PhieuLaiDAO() { }

        public List<HoaDonCamDTO> LoadListHoaDonCam()
        {
            List<HoaDonCamDTO> LoadList = new List<HoaDonCamDTO>();
            string query = "select a.MaHoaDonCam , b.TenKH , a.NgayLap , a.NgayHetHan ,a.TongTienCam from HoaDonCam a , KhachHang b where a.MaKH = b.MaKH";
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                HoaDonCamDTO HDC = new HoaDonCamDTO(item);
                LoadList.Add(HDC);
            }
            return LoadList;
        }

        public bool InsertPhieuLai( DateTime NgayDongLai, float TongTien)
        {
            string query = string.Format("insert PhieuLai(NgayDongLai ,TongTien) values (N'{0}',N'{1}'')",NgayDongLai, TongTien);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }
        public string MaKH(int MaHoaDonCam)
        {
            string query = string.Format("select MaKH from HoaDonCam where MaHoaDonCam =N'{0}'", MaHoaDonCam);
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }
        public string Ngay(int MaHoaDonCam,DateTime ngaydong)
        {
            string query = string.Format("SELECT DATEDIFF(day,HoaDonCam.NgayDongLai , N'{1}') from HoaDonCam where HoaDonCam.MaHoaDonCam=N'{0}' ", MaHoaDonCam,ngaydong);
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }
    }
}
