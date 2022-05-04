using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace DoAnTTTT_QuanLyCuaHieuCamDo.DTO
{
    public class TypeAccountDTO
    {
        private int id;
        private string name;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public TypeAccountDTO(int ID_Quyen, string Name_Quyen)
        {
            this.id = ID_Quyen;
            this.name = Name_Quyen;
        }

        public TypeAccountDTO(DataRow row)
        {
            this.id = (int)row["ID_Quyen"];
            this.name = row["Name_Quyen"].ToString();
        }
    }
}
