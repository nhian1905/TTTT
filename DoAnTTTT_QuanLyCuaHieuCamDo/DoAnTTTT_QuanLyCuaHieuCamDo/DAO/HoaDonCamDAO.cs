using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;
namespace DoAnTTTT_QuanLyCuaHieuCamDo.DAO
{
    public class HoaDonCamDAO
    {
        private static HoaDonCamDAO instance;

        public static HoaDonCamDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new HoaDonCamDAO();
                return instance;
            }
            private set => instance = value;
        }

        private HoaDonCamDAO() { }

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

        public bool InsertHDC(int MaKH, DateTime NgayLap, DateTime NgayHetHan, float TongTienCam)
        {
            string query = string.Format("insert HoaDonCam( MaKH ,NgayLap,NgayHetHan ,TongTienCam) values (N'{0}',N'{1}',N'{2}',N'{3}')", MaKH, NgayLap, NgayHetHan, TongTienCam);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

        public bool UpdateHDC(int MaHoaDonCam, int MaKH, DateTime NgayLap, DateTime NgayHetHan, float TongTienCam)
        {
            string query = string.Format("update HoaDonCam set MaKH=N'{0}'  ,NgayLap=N'{1}',NgayHetHan=N'{2}' ,TongTienCam=N'{3}' where MaHoaDonCam=N'{4}'", MaKH, NgayLap, NgayHetHan, TongTienCam, MaHoaDonCam);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

        public bool DeleteHDC(int MaHoaDonCam)
        {
            string query = string.Format("Delete HoaDonCam where MaHoaDonCam =N'{0}'", MaHoaDonCam);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

        public bool UpdateTongTien(int MaHoaDonCam)
        {
            string query = string.Format("exec USP_UpdateTongTienHDC {0}", MaHoaDonCam);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }
    }
}
