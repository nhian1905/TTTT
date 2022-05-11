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

        public string UpdateTongTien(int MaPhieuChuoc)
        {
            string query = string.Format("exec USP_UpdateTienPhieuChuoc {0}", MaPhieuChuoc);
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }
    }
}
