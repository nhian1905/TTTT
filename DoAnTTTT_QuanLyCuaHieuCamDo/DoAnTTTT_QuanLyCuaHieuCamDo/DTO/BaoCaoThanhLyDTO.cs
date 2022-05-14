using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DoAnTTTT_QuanLyCuaHieuCamDo.DTO
{
    public class BaoCaoThanhLyDTO
    {
        private int maThanhLy;
        private string tenKH;
        private int sDT;
        private int cMND;
        private DateTime ngayLap;
        private string maSP;
        private string tenLoai;
        private string tenSP;
        private double giaThanhLy;
        private string moTa;
        private string nhangHieu;
        private string mauSac;
        private string hienTrang;

        public int MaThanhLy { get => maThanhLy; set => maThanhLy = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public int SDT { get => sDT; set => sDT = value; }
        public int CMND { get => cMND; set => cMND = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public string TenLoai { get => tenLoai; set => tenLoai = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public double GiaThanhLy { get => giaThanhLy; set => giaThanhLy = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public string NhangHieu { get => nhangHieu; set => nhangHieu = value; }
        public string MauSac { get => mauSac; set => mauSac = value; }
        public string HienTrang { get => hienTrang; set => hienTrang = value; }
        public BaoCaoThanhLyDTO(int MaThanhLy,int MaHoaDonCam, string TenKH, int SDT, int CMND, DateTime NgayLap, string MaSP, string TenLoai, string TenSP, double DinhGia, string MoTa, string MauSac, string HienTrang,float TongTienThanhLy)
        {
            this.MaThanhLy = MaThanhLy;
            this.TenKH = TenKH;
            this.SDT = SDT;
            this.CMND = CMND;
            this.NgayLap = NgayLap;
            this.MaSP = MaSP;
            this.TenLoai = TenLoai;
            this.TenSP = TenSP;
            this.GiaThanhLy = GiaThanhLy;
            this.MoTa = MoTa;
            this.NhangHieu = NhangHieu;
            this.MauSac = MauSac;
            this.HienTrang = HienTrang;
        }

        public BaoCaoThanhLyDTO(DataRow row)
        {
            this.MaThanhLy = (int)row["MaThanhLy"];
            this.TenKH = row["TenKH"].ToString();
            this.SDT = (int)row["SDT"];
            this.CMND = (int)row["CMND"];
            this.NgayLap = (DateTime)row["NgayLap"];
            this.MaSP = row["MaSP"].ToString();
            this.TenLoai = row["TenLoai"].ToString();
            this.TenSP = row["TenSP"].ToString();
            this.GiaThanhLy = (float)Convert.ToDouble(row["GiaThanhLy"]);
            this.MoTa = row["MoTa"].ToString();
            this.NhangHieu = row["NhangHieu"].ToString();
            this.MauSac = row["MauSac"].ToString();
            this.HienTrang = row["HienTrang"].ToString();
        }
    }
}
