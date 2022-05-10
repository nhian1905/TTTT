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
    }
}
