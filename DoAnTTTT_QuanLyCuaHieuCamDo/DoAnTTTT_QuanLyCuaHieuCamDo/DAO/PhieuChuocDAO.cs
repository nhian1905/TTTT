using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;
namespace DoAnTTTT_QuanLyCuaHieuCamDo.DAO
{
    public class PhieuChuocDAO
    {
        private static PhieuChuocDAO instance;

        public static PhieuChuocDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhieuChuocDAO();
                return instance;
            }
            private set => instance = value;
        }

        private PhieuChuocDAO() { }

        public List<PhieuChuocDTO> LoadListHoaDonCam()
        {
            List<PhieuChuocDTO> LoadList = new List<PhieuChuocDTO>();
            string query = "select a.MaHoaDonCam ,b.MaKH, b.TenKH , a.NgayLap , a.NgayHetHan ,a.TongTienCam from HoaDonCam a , KhachHang b where a.MaKH = b.MaKH";
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                PhieuChuocDTO HDC = new PhieuChuocDTO(item);
                LoadList.Add(HDC);
            }
            return LoadList;
        }
        public bool InsertPhieuChuoc(int MaHoaDonCam, DateTime NgayChuoc, float TongTien)
        {
            string query = string.Format("insert PhieuChuoc( MaHoaDonCam ,NgayChuoc ,TongTien) values (N'{0}',N'{1}',N'{2}')", MaHoaDonCam, NgayChuoc, TongTien);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

        public string MaPC(int MaHoaDonCam, DateTime NgayChuoc)
        {
            string query = string.Format("select MaPhieuChuoc from PhieuChuoc where MaHoaDonCam =N'{0}'and NgayChuoc =N'{1}'", MaHoaDonCam, NgayChuoc);
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }
        public string MaKH(int MaHoaDonCam)
        {
            string query = string.Format("select MaKH from HoaDonCam where MaHoaDonCam =N'{0}'", MaHoaDonCam);
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }

        public string UpdateTongTien(int MaPhieuChuoc)
        {
            string query = string.Format("exec USP_UpdateTienPhieuChuoc {0}", MaPhieuChuoc);
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }
    }
}
