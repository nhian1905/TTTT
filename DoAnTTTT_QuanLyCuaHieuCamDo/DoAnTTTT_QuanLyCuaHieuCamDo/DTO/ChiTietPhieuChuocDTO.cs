using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DoAnTTTT_QuanLyCuaHieuCamDo.DTO
{
    public class ChiTietPhieuChuocDTO
    {
        private int maPhieuChuoc;
        private string maSP;
        private string tenSP;
        private float giaThanhLy;
        private int laiXuat;
        private float tienLai;
        private string moTa;
        private string mauSac;
        private string hienTrang;
        private string nhanHieu;
        private float tongTien;

        public int MaPhieuChuoc { get => maPhieuChuoc; set => maPhieuChuoc = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public float GiaThanhLy { get => giaThanhLy; set => giaThanhLy = value; }

        public int LaiXuat { get => laiXuat; set => laiXuat = value; }
        public float TienLai { get => tienLai; set => tienLai = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public string MauSac { get => mauSac; set => mauSac = value; }
        public string HienTrang { get => hienTrang; set => hienTrang = value; }
        public string NhanHieu { get => nhanHieu; set => nhanHieu = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }
       

        public ChiTietPhieuChuocDTO(int MaPhieuChuoc, string MaSP, string TenSP, float GiaThanhLy,int LaiXuat,float TienLai, string MoTa, string MauSac, string HienTrang, string NhangHieu, float TongTien)
        {
            this.MaPhieuChuoc = MaPhieuChuoc;
            this.MaSP = MaSP;
            this.TenSP = TenSP;
            this.GiaThanhLy = GiaThanhLy;
            this.LaiXuat = LaiXuat;
            this.TienLai = TienLai;
            this.MoTa = MoTa;
            this.MauSac = MauSac;
            this.HienTrang = HienTrang;
            this.NhanHieu = NhangHieu;
            this.TongTien = TongTien;
        }

        public ChiTietPhieuChuocDTO(DataRow row)
        {
            this.MaPhieuChuoc = (int)row["MaPhieuChuoc"];
            this.MaSP = row["MaSP"].ToString();
            this.TenSP = row["TenSP"].ToString();
            this.GiaThanhLy = (float)Convert.ToDouble(row["GiaThanhLy"]);
            this.LaiXuat = (int)row["LaiXuat"];
            this.TienLai = (float)Convert.ToDouble(row["TienLai"]);
            this.MoTa = row["MoTa"].ToString();
            this.MauSac = row["MauSac"].ToString();
            this.HienTrang = row["HienTrang"].ToString();
            this.NhanHieu = row["NhangHieu"].ToString();
            this.TongTien = (float)Convert.ToDouble(row["TongTien"]);
        }
    }
}
