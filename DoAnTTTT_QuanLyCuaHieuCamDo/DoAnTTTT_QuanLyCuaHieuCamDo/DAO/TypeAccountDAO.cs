using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.DAO
{
    public class TypeAccountDAO
    {
        private static TypeAccountDAO instance;

        public static TypeAccountDAO Instance
        {
            get { if (instance == null) instance = new TypeAccountDAO(); return instance; }
            private set => instance = value;
        }

        private TypeAccountDAO() { }

        public List<TypeAccountDTO> LoadListAccount()
        {
            List<TypeAccountDTO> ListTypeAcc = new List<TypeAccountDTO>();
            string query = "select * from Quyen";
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                TypeAccountDTO loai = new TypeAccountDTO(item);
                ListTypeAcc.Add(loai);

            }
            return ListTypeAcc;
        }
    }
}
