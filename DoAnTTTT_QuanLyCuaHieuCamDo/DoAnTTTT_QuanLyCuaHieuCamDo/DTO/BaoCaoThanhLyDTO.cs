using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DoAnTTTT_QuanLyCuaHieuCamDo.DTO
{
    class BaoCaoThanhLyDTO
    {
        private int maThanhLy;
        private int maHoaDonCam;
        private string tenKH;
        private int sDT;
        private int cMND;
        private DateTime ngayLap;
        private string maSP;
        private string tenLoai;
        private string tenSP;
        private double dinhGia;
        private string moTa;
        private string mauSac;
        private string hienTrang;
        private float tongTienThanhLy;

        public int MaThanhLy { get => maThanhLy; set => maThanhLy = value; }
        public int MaHoaDonCam { get => maHoaDonCam; set => maHoaDonCam = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public int SDT { get => sDT; set => sDT = value; }
        public int CMND { get => cMND; set => cMND = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public string TenLoai { get => tenLoai; set => tenLoai = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public double DinhGia { get => dinhGia; set => dinhGia = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public string MauSac { get => mauSac; set => mauSac = value; }
        public string HienTrang { get => hienTrang; set => hienTrang = value; }
        public float TongTienThanhLy { get => tongTienThanhLy; set => tongTienThanhLy = value; }

        public BaoCaoThanhLyDTO(int MaThanhLY,int MaHoaDonCam, string TenKH, int SDT, int CMND, DateTime NgayLap, string MaSP, string TenLoai, string TenSP, double DinhGia, string MoTa, string MauSac, string HienTrang,float TongTienThanhLy)
        {
            this.MaThanhLy = MaThanhLy;
            this.MaHoaDonCam = MaHoaDonCam;
            this.TenKH = TenKH;
            this.SDT = SDT;
            this.CMND = CMND;
            this.NgayLap = NgayLap;
            this.MaSP = MaSP;
            this.TenLoai = TenLoai;
            this.TenSP = TenSP;
            this.DinhGia = DinhGia;
            this.MoTa = MoTa;
            this.MauSac = MauSac;
            this.HienTrang = HienTrang;
            this.TongTienThanhLy = TongTienThanhLy;
        }

        public BaoCaoThanhLyDTO(DataRow row)
        {
            this.MaHoaDonCam = (int)row["MaHoaDonCam"];
            this.TenKH = row["TenKH"].ToString();
            this.SDT = (int)row["SDT"];
            this.CMND = (int)row["CMND"];
            this.NgayLap = (DateTime)row["NgayLap"];
            this.MaSP = row["MaSP"].ToString();
            this.TenLoai = row["TenLoai"].ToString();
            this.TenSP = row["TenSP"].ToString();
            this.DinhGia = (float)Convert.ToDouble(row["DinhGia"]);
            this.MoTa = row["MoTa"].ToString();
            this.MauSac = row["MauSac"].ToString();
            this.HienTrang = row["HienTrang"].ToString();
            this.TongTienThanhLy = (float)Convert.ToDouble(row["TongTienThanhLy"]);
        }
    }
}
