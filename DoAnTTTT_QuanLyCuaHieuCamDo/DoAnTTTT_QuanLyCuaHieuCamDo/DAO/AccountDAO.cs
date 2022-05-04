using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set => instance = value;
        }

        private AccountDAO() { }
        public bool DangNhap(string taikhoan, string matkhau)
        {

            string query = "select * from TaiKhoan where UsersName = '" + taikhoan + "' and Password = '" + matkhau + "' ";
            DataTable result = CSDL.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

        public AccountDTO GetAcc(string UsersName)
        {
            DataTable dta = CSDL.Instance.ExecuteQuery("select a.UsersName,a.Password ,b.Name_Quyen from TaiKhoan a, Quyen b where a.ID_Quyen = b.ID_Quyen and UsersName = N'" + UsersName + "'");
            foreach (DataRow item in dta.Rows)
            {
                return new AccountDTO(item);

            }
            return null;
        }
    }
}
