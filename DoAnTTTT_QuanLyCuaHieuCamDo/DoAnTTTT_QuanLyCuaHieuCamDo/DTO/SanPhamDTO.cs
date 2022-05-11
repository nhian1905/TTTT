using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DoAnTTTT_QuanLyCuaHieuCamDo.DTO
{
    public class SanPhamDTO
    {
        private string maSP;
        private string tenLoai;
        private string tenSP;
        private float dinhGia;
        private float giaThanhLy;
        private string moTa;
        private string mauSac;
        private string hienTrang;
        private string nhanHieu;
        private bool quaHan;
        private bool daChuoc;
        private bool thanhLy;
        private bool daThanhLy;

        public string MaSP { get => maSP; set => maSP = value; }
        public string TenLoai { get => tenLoai; set => tenLoai = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public float DinhGia { get => dinhGia; set => dinhGia = value; }
        public float GiaThanhLy { get => giaThanhLy; set => giaThanhLy = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public string MauSac { get => mauSac; set => mauSac = value; }
        public string HienTrang { get => hienTrang; set => hienTrang = value; }
        public string NhanHieu { get => nhanHieu; set => nhanHieu = value; }
        public bool QuaHan { get => quaHan; set => quaHan = value; }
        public bool DaChuoc { get => daChuoc; set => daChuoc = value; }
        public bool ThanhLy { get => thanhLy; set => thanhLy = value; }
        public bool DaThanhLy { get => daThanhLy; set => daThanhLy = value; }
        

        public SanPhamDTO(string MaSP, string TenLoai, string TenSP, float DinhGia,float GiaThanhLy, string MoTa, string MauSac , string HienTrang, string NhangHieu , bool QuaHan , bool DaChuoc , bool ThanhLy,bool DaThanhLy)
        {
            this.MaSP = MaSP;
            this.TenLoai = TenLoai;
            this.TenSP = TenSP;
            this.DinhGia = DinhGia;
            this.GiaThanhLy = GiaThanhLy;
            this.MoTa = MoTa;
            this.MauSac = MauSac;
            this.HienTrang = HienTrang;
            this.NhanHieu = NhangHieu;
            this.QuaHan = QuaHan;
            this.DaChuoc = DaChuoc;
            this.ThanhLy = ThanhLy;
            this.DaThanhLy = DaThanhLy;
        }

        public SanPhamDTO(DataRow row)
        {
            this.MaSP = row["MaSP"].ToString();
            this.TenLoai = row["TenLoai"].ToString();
            this.TenSP = row["TenSP"].ToString();
            this.DinhGia = (float)Convert.ToDouble(row["DinhGia"]);
            this.GiaThanhLy = (float)Convert.ToDouble(row["GiaThanhLy"]);
            this.MoTa = row["MoTa"].ToString();
            this.MauSac = row["MauSac"].ToString();
            this.HienTrang = row["HienTrang"].ToString();
            this.NhanHieu = row["NhangHieu"].ToString();
            this.QuaHan = (bool)row["QuaHan"];
            this.DaChuoc = (bool)row["DaChuoc"];
            this.ThanhLy = (bool)row["ThanhLy"];
            this.DaThanhLy = (bool)row["DaThanhLy"];
        }
    }
}
