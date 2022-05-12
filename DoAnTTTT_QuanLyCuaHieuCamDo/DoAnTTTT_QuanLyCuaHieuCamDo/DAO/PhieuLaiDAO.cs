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

        public List<PhieuLaiDTO> LoadListPhieuLai()
        {
            List<PhieuLaiDTO> LoadList = new List<PhieuLaiDTO>();
            string query = "select MaPhieuLai ,NgayDongLai ,TongTien from PhieuLai";
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                PhieuLaiDTO HDL = new PhieuLaiDTO(item);
                LoadList.Add(HDL);
            }
            return LoadList;
        }

        public bool InsertPhieuLai( DateTime NgayDongLai, float TongTien)
        {
            string query = string.Format("insert PhieuLai(NgayDongLai ,TongTien) values (N'{0}',N'{1}'')",NgayDongLai, TongTien);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }
    }
}
