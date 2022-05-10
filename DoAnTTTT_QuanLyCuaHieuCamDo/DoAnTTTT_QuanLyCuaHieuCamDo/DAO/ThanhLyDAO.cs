using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;
namespace DoAnTTTT_QuanLyCuaHieuCamDo.DAO
{
    public class ThanhLyDAO
    {
        private static ThanhLyDAO instance;

        public static ThanhLyDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThanhLyDAO();
                return instance;
            }
            private set => instance = value;
        }

        private ThanhLyDAO() { }

        public List<ThanhLyDTO> LoadListThanhLy()
        {
            List<ThanhLyDTO> LoadList = new List<ThanhLyDTO>();
            string query = "select a.MaThanhLy , b.TenKH , a.NgayLap ,a.TongTienThanhLy from ThanhLy a , KhachHang b where a.MaKH = b.MaKH";
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                ThanhLyDTO TL = new ThanhLyDTO(item);
                LoadList.Add(TL);
            }
            return LoadList;
        }

        public bool InsertThanhLy(int MaKH, DateTime NgayLap, float TongTienThanhLy)
        {
            string query = string.Format("insert ThanhLy( MaKH ,NgayLap ,TongTienThanhLy) values (N'{0}',N'{1}',N'{2}')", MaKH, NgayLap, TongTienThanhLy);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }
        public bool UpdateThanhLy(int MaThanhLy, int MaKH, DateTime NgayLap, float TongTienThanhLy)
        {
            string query = string.Format("update ThanhLy set MaKH=N'{0}'  ,NgayLap=N'{1}' ,TongTienThanhLy=N'{3}' where MaThanhLy=N'{4}'", MaKH, NgayLap, TongTienThanhLy, MaThanhLy);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

        public bool DeleteThanhLy(int MaThanhLy)
        {
            string query = string.Format("Delete ThanhLy where MaThanhLy =N'{0}'", MaThanhLy);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

        public bool UpdateTongTien(int MaThanhLy)
        {
            string query = string.Format("exec USP_UpdateTongTienThanHLy {0}", MaThanhLy);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }
    }
}
