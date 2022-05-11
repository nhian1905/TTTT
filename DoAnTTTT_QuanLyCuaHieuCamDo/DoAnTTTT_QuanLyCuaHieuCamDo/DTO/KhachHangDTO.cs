using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.DTO
{
    public class KhachHangDTO
    {
        public KhachHangDTO(int MaKH, string TenKH, int SDT, int CMND ,DateTime NamSinh, string DiaChi, DateTime NgayCapCMND, string HinhAnh)
        {
            this.MaKH = MaKH;
            this.TenKH = TenKH;
            this.SDT = SDT;
            this.CMND = CMND;
            this.NamSinh = NamSinh;
            this.DiaChi = DiaChi;
            this.NgayCapCMND = NgayCapCMND;
            this.HinhAnh = HinhAnh;
        }

        public KhachHangDTO(DataRow row)
        {
            this.MaKH = (int)row["MaKH"];
            this.TenKH = row["TenKH"].ToString();
            this.SDT = (int)row["SDT"];
            this.CMND = (int)row["CMND"];
            this.NamSinh = (DateTime)row["NamSinh"];
            this.DiaChi = row["DiaChi"].ToString();
            this.NgayCapCMND = (DateTime)row["NgayCapCMND"];
            this.HinhAnh = row["HinhAnh"].ToString();
        }




        private int maKH;
        private string tenKH;
        private int sDT;
        private int cMND;
        private DateTime namSinh;
        private string diaChi;
        private DateTime ngayCapCMND;
        private string hinhAnh;

        public int MaKH { get { return maKH; } set { maKH = value; } }
        public string TenKH { get { return tenKH; } set { tenKH = value; } }
        public int SDT { get { return sDT; } set { sDT = value; } }
        public int CMND { get { return cMND; } set { cMND = value; } }
        public DateTime NamSinh { get { return namSinh; } set { namSinh = value; } }
        public string DiaChi { get { return diaChi; } set { diaChi = value; } }
        public DateTime NgayCapCMND { get { return ngayCapCMND; } set { ngayCapCMND = value; } }
        public string HinhAnh { get { return hinhAnh; } set { hinhAnh = value; } }
    }
}
