using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DoAnTTTT_QuanLyCuaHieuCamDo.DTO
{
    public class ChiTietThanhLyDTO
    {
        private string maSP;
        private string tenSP;
        private float giaThanhLy;
        private string moTa;
        private string mauSac;
        private string hienTrang;
        private string nhanHieu;

        public string MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public float GiaThanhLy { get => giaThanhLy; set => giaThanhLy = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public string MauSac { get => mauSac; set => mauSac = value; }
        public string HienTrang { get => hienTrang; set => hienTrang = value; }
        public string NhanHieu { get => nhanHieu; set => nhanHieu = value; }


        public ChiTietThanhLyDTO(string MaSP, string TenSP, float GiaThanhLy, string MoTa, string MauSac, string HienTrang, string NhangHieu)
        {
            this.MaSP = MaSP;
            this.TenSP = TenSP;
            this.GiaThanhLy = GiaThanhLy;
            this.MoTa = MoTa;
            this.MauSac = MauSac;
            this.HienTrang = HienTrang;
            this.NhanHieu = NhangHieu;
        }

        public ChiTietThanhLyDTO(DataRow row)
        {
            this.MaSP = row["MaSP"].ToString();
            this.TenSP = row["TenSP"].ToString();
            this.GiaThanhLy = (float)Convert.ToDouble(row["GiaThanhLy"]);
            this.MoTa = row["MoTa"].ToString();
            this.MauSac = row["MauSac"].ToString();
            this.HienTrang = row["HienTrang"].ToString();
            this.NhanHieu = row["NhangHieu"].ToString();
        }
    }
}
