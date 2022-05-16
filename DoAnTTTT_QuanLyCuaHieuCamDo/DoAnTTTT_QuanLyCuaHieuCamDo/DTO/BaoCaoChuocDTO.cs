using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DoAnTTTT_QuanLyCuaHieuCamDo.DTO
{
    public class BaoCaoChuocDTO
    {
        private int maPhieuChuoc;
        private int maHoaDonCam;
        private string tenKH;
        private int sDT;
        private int cMND;
        private DateTime ngayChuoc;
        private string maSP;
        private string tenLoai;
        private string tenSP;
        private double dinhGia;
        private string moTa;
        private string nhangHieu;
        private string mauSac;
        private string hienTrang;
        private double tienLai;
        private double tongTien;

        public int MaPhieuChuoc { get => maPhieuChuoc; set => maPhieuChuoc = value; }
        public int MaHoaDonCam { get => maHoaDonCam; set => maHoaDonCam = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public int SDT { get => sDT; set => sDT = value; }
        public int CMND { get => cMND; set => cMND = value; }
        public DateTime NgayChuoc { get => ngayChuoc; set => ngayChuoc = value; }
        public double TienLai { get => tienLai; set => tienLai = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public string TenLoai { get => tenLoai; set => tenLoai = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public double DinhGia { get => dinhGia; set => dinhGia = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public string NhangHieu { get => nhangHieu; set => nhangHieu = value; }
        public string MauSac { get => mauSac; set => mauSac = value; }
        public string HienTrang { get => hienTrang; set => hienTrang = value; }


        public BaoCaoChuocDTO(int MaPhieuChuoc,int MaHoaDonCam, string TenKH, int SDT, int CMND, DateTime NgayChuoc, double TongTien)
        {
            this.MaPhieuChuoc = MaPhieuChuoc;
            this.MaHoaDonCam = MaHoaDonCam;
            this.TenKH = TenKH;
            this.SDT = SDT;
            this.CMND = CMND;
            this.NgayChuoc = NgayChuoc;
            this.MaSP = MaSP;
            this.TenLoai = TenLoai;
            this.TenSP = TenSP;
            this.DinhGia = DinhGia;
            this.MoTa = MoTa;
            this.NhangHieu = NhangHieu;
            this.MauSac = MauSac;
            this.HienTrang = HienTrang;
            this.TienLai = TienLai;
            this.TongTien = TongTien;
        }

        public BaoCaoChuocDTO(DataRow row)
        {
            this.MaPhieuChuoc = (int)row["MaPhieuChuoc"];
            this.MaHoaDonCam = (int)row["MaHoaDonCam"];
            this.TenKH = row["TenKH"].ToString();
            this.SDT = (int)row["SDT"];
            this.CMND = (int)row["CMND"];
            this.NgayChuoc = (DateTime)row["NgayChuoc"];
            this.MaSP = row["MaSP"].ToString();
            this.TenLoai = row["TenLoai"].ToString();
            this.TenSP = row["TenSP"].ToString();
            this.DinhGia = (float)Convert.ToDouble(row["DinhGia"]);
            this.MoTa = row["MoTa"].ToString();
            this.NhangHieu = row["NhangHieu"].ToString();
            this.MauSac = row["MauSac"].ToString();
            this.HienTrang = row["HienTrang"].ToString();
            this.TienLai = (float)Convert.ToDouble(row["TienLai"]);
            this.TongTien = (float)Convert.ToDouble(row["TongTien"]);
        }
    }
}
