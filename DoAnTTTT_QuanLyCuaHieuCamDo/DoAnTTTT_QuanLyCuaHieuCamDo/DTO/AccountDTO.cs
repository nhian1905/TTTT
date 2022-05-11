using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.DTO
{
    public class AccountDTO
    {
        private string username;
        private string password;
        private string name_Quyen;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Name_Quyen { get => name_Quyen; set => name_Quyen = value; }

        public AccountDTO( string UsersName, string Password, string Name_Quyen)
        {
            this.username = UsersName;
            this.password = Password;
            this.Name_Quyen = Name_Quyen;
        }

        public AccountDTO(DataRow row)
        {
            this.username = row["UsersName"].ToString();
            this.password = row["Password"].ToString();
            this.Name_Quyen = row["Name_Quyen"].ToString();
        }
    }
}
