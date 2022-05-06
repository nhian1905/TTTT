using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;
using System.Data;
namespace DoAnTTTT_QuanLyCuaHieuCamDo.DAO
{
    public class SanPhamDAO
    {
        private static SanPhamDAO instance;

        public static SanPhamDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new SanPhamDAO();
                return instance;
            }
            private set => instance = value;
        }

        private SanPhamDAO() { }

        public List<SanPhamDTO> LoadListSP()
        {
            List<SanPhamDTO> LoadList = new List<SanPhamDTO>();
            string query = "select * from SanPham";
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                SanPhamDTO SP = new SanPhamDTO(item);
                LoadList.Add(SP);
            }
            return LoadList;
        }
    }
}
