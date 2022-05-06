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
    public class LoaiSPDAO
    {
        private static LoaiSPDAO instance;

        public static LoaiSPDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoaiSPDAO();
                return instance;
            }
            private set => instance = value;
        }

        private LoaiSPDAO() { }

        public List<LoaiSPDTO> LoadListKH()
        {
            List<LoaiSPDTO> LoadList = new List<LoaiSPDTO>();
            string query = "select * from KhachHang";
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                LoaiSPDTO loaisp = new LoaiSPDTO(item);
                LoadList.Add(loaisp);
            }
            return LoadList;
        }
    }
}
