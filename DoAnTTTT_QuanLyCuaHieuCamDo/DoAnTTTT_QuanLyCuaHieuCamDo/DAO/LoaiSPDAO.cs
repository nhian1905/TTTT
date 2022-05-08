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

        public List<LoaiSPDTO> LoadListLoaiSP()
        {
            List<LoaiSPDTO> LoadList = new List<LoaiSPDTO>();
            string query = "select * from LoaiSP";
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                LoaiSPDTO loaisp = new LoaiSPDTO(item);
                LoadList.Add(loaisp);
            }
            return LoadList;
        }

        public bool InsertLoaiSP( string TenLoai , float LaiXuat)
        {
            string query = string.Format("insert LoaiSP(  TenLoai , LaiXuat) values (N'{0}',N'{1}')", TenLoai,LaiXuat);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

        public bool UpdateLoaiSP(int MaLoai, string TenLoai, float LaiXuat)
        {
            string query = string.Format("update LoaiSP set TenLoai=N'{0}' , LaiXuat=N'{1}' where MaLoai=N'{2}'",  TenLoai, LaiXuat,MaLoai);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

        public bool DeleteLoaiSP(int MaLoai)
        {
            string query = string.Format("delete LoaiSP where MaSP = N'{0}'", MaLoai);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }
    }
}
