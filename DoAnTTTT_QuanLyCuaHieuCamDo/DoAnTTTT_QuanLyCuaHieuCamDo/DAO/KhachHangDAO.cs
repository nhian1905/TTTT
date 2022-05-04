using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;
using System.Data.SqlClient;
using System.Data;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangDAO();
                return instance;
            }
            private set => instance = value;
        }

        private KhachHangDAO() { }

        public List<KhachHangDTO> LoadListKH()
        {
            List<KhachHangDTO> LoadList = new List<KhachHangDTO>();
            string query = "select * from KhachHang";
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                KhachHangDTO Cus = new KhachHangDTO(item);
                LoadList.Add(Cus);
            }
            return LoadList;
        }
    }
}
