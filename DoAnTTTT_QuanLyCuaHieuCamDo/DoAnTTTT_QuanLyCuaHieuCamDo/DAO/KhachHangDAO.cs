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

        public bool InsertCustomer(string TenKH, long SDT, long CMND, DateTime NamSinh, string DiaChi, DateTime NgayCapCMND, string HinhAnh)
        {
            string query = string.Format("insert KhachHang( TenKH ,SDT,CMND ,NamSinh,DiaChi,NgayCapCMND,HinhAnh) values (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}')", TenKH, SDT, CMND, NamSinh, DiaChi, NgayCapCMND, HinhAnh);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }
        public bool DeleteCustomer(int MaKH)
        {
            string query = string.Format("Delete KhachHang where MaKH = N'{0}'", MaKH);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

        public bool UpdateCustomer(int MaKH, string TenKH, long SDT, long CMND, DateTime NamSinh, string DiaChi, DateTime NgayCapCMND, string HinhAnh)
        {
            string query = string.Format("Update KhachHang set TenKH = N'{0}', SDT = N'{1}', CMND = N'{2}', NamSinh = N'{3}', DiaChi = N'{4}', NgayCapCMND = N'{5}', HinhAnh = N'{6}' where MaKH = N'{7}'", TenKH,SDT,CMND,NamSinh,DiaChi,NgayCapCMND,HinhAnh,MaKH);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }
    }
}
