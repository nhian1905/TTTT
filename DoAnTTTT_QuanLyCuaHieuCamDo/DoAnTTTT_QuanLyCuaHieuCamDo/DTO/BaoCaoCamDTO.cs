using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.DTO
{
    public class BaoCaoCamDTO
    {
        private int maHoaDonCam;
        private string tenKH;
        private DateTime ngayLap;
        private DateTime ngayHetHan;
        private string maSP;
        private string tenLoai;
        private string tenSP;
        private double dinhGia;
        private string moTa;
        private string mauSac;
        private string hienTrang;
        public int MaHoaDonCam { get => maHoaDonCam; set => maHoaDonCam = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public DateTime NgayHetHan { get => ngayHetHan; set => ngayHetHan = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public string TenLoai { get => tenLoai; set => tenLoai = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public double DinhGia { get => dinhGia; set => dinhGia = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public string MauSac { get => mauSac; set => mauSac = value; }
        public string HienTrang { get => hienTrang; set => hienTrang = value; }

        public BaoCaoCamDTO(int MaHoaDonCam, string TenKH, DateTime NgayLap, DateTime NgayHetHan, string MaSP, string TenLoai, string TenSP, double DinhGia, string MoTa, string MauSac, string HienTrang)
        {
            this.MaHoaDonCam = MaHoaDonCam;
            this.TenKH = TenKH;
            this.NgayLap = NgayLap;
            this.NgayHetHan = NgayHetHan;
            this.MaSP = MaSP;
            this.TenLoai = TenLoai;
            this.TenSP = TenSP;
            this.DinhGia = DinhGia;
            this.MoTa = MoTa;
            this.MauSac = MauSac;
            this.HienTrang = HienTrang;
        }
        public BaoCaoCamDTO(DataRow row)
        {
            this.MaHoaDonCam = (int)row["MaHoaDonCam"];
            this.TenKH = row["TenKH"].ToString();
            this.NgayLap = (DateTime)row["NgayLap"];
            this.NgayHetHan = (DateTime)row["NgayHetHan"];
            this.MaSP = row["MaSP"].ToString();
            this.TenLoai = row["TenLoai"].ToString();
            this.TenSP = row["TenSP"].ToString();
            this.DinhGia = (float)Convert.ToDouble(row["DinhGia"]);
            this.MoTa = row["MoTa"].ToString();
            this.MauSac = row["MauSac"].ToString();
            this.HienTrang = row["HienTrang"].ToString();
        }
    }
    
}
