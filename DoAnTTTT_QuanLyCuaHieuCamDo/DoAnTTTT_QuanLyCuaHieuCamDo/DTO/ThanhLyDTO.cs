using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DoAnTTTT_QuanLyCuaHieuCamDo.DTO
{
    public class ThanhLyDTO
    {
        private int maThanhLy;
        private string tenKH;
        private DateTime ngayLap;
        private double tongTienThanhLy;

        public int MaThanhLy { get => maThanhLy; set => maThanhLy = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public double TongTienThanhLy { get => tongTienThanhLy; set => tongTienThanhLy = value; }

        public ThanhLyDTO(int MaThanhLy, string TenKH, DateTime NgayLap, double TongTienThanhLy)
        {
            this.MaThanhLy = MaThanhLy;
            this.TenKH = TenKH;
            this.NgayLap = NgayLap;
            this.TongTienThanhLy = TongTienThanhLy;
        }

        public ThanhLyDTO(DataRow row)
        {
            this.MaThanhLy = (int)row["MaThanhLy"];
            this.TenKH = row["TenKH"].ToString();
            this.NgayLap = (DateTime)row["NgayLap"];
            this.TongTienThanhLy = (float)Convert.ToDouble(row["TongTienThanhLy"]);
        }
    }
}
