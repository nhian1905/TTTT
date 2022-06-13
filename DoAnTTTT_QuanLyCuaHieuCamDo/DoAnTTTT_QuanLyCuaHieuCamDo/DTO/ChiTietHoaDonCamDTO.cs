using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DoAnTTTT_QuanLyCuaHieuCamDo.DTO
{
    public class ChiTietHoaDonCamDTO
    {
        private int maHoaDonCam;
        private string maSP;
        private string idSP;
        private string tenLoai;
        private string tenSP;
        private double dinhGia;
        private double giaThanhLy;
        private string moTa;
        private string mauSac;
        private string hienTrang;
        private string nhanHieu;

        public string IDSP { get => idSP; set => idSP = value; }
        public int MaHoaDonCam { get => maHoaDonCam; set => maHoaDonCam = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public string TenLoai { get => tenLoai; set => tenLoai = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public double DinhGia { get => dinhGia; set => dinhGia = value; }
        public double GiaThanhLy { get => giaThanhLy; set => giaThanhLy = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public string MauSac { get => mauSac; set => mauSac = value; }
        public string HienTrang { get => hienTrang; set => hienTrang = value; }
        public string NhanHieu { get => nhanHieu; set => nhanHieu = value; }


        public ChiTietHoaDonCamDTO(int MaHoaDonCam, string MaSP, string TenLoai,string IDSP, string TenSP, double DinhGia, double GiaThanhLy, string MoTa, string MauSac, string HienTrang, string NhangHieu)
        {
            this.MaHoaDonCam = MaHoaDonCam;
            this.MaSP = MaSP;
            this.TenLoai = TenLoai;
            this.IDSP = IDSP;
            this.TenSP = TenSP;
            this.DinhGia = DinhGia;
            this.GiaThanhLy = GiaThanhLy;
            this.MoTa = MoTa;
            this.MauSac = MauSac;
            this.HienTrang = HienTrang;
            this.NhanHieu = NhangHieu;
        }

        public ChiTietHoaDonCamDTO(DataRow row)
        {
            this.MaHoaDonCam = (int)row["MaHoaDonCam"];
            this.MaSP = row["MaSP"].ToString();
            this.TenLoai = row["TenLoai"].ToString();
            this.idSP = row["ID_SP"].ToString();
            this.TenSP = row["TenSP"].ToString();
            this.DinhGia = (double)Convert.ToDouble(row["DinhGia"]);
            this.GiaThanhLy = (double)Convert.ToDouble(row["GiaThanhLy"]);
            this.MoTa = row["MoTa"].ToString();
            this.MauSac = row["MauSac"].ToString();
            this.HienTrang = row["HienTrang"].ToString();
            this.NhanHieu = row["NhangHieu"].ToString();
        }
    }
}
