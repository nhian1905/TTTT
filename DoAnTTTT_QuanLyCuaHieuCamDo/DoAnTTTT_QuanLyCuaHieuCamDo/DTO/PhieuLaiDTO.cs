using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.DTO
{
    public class PhieuLaiDTO
    {
        private int maPhieuLai;
        //private int maHoaDonCam;
        private string tenKH;
        private DateTime ngayDongLai;
        private double tongTien;

        public int MaPhieuLai { get => maPhieuLai; set => maPhieuLai = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        //public int MaHoaDonCam { get => maHoaDonCam; set => maHoaDonCam = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
        public DateTime NgayDongLai { get => ngayDongLai; set => ngayDongLai = value; }
        

        public PhieuLaiDTO(int MaPhieuLai, string TenKH, DateTime NgayDongLai, float ThanhTien)
        {
            this.MaPhieuLai = MaPhieuLai;
            this.TenKH = TenKH;        
            this.NgayDongLai = NgayDongLai;
            this.TongTien = ThanhTien;

        }
        public PhieuLaiDTO(DataRow row)
        {
            this.MaPhieuLai = (int)row["MaPhieuLai"];
            this.TenKH = row["TenKH"].ToString();
            this.NgayDongLai = (DateTime)row["NgayDongLai"];
            this.TongTien = (float)Convert.ToDouble(row["ThanhTien"]);
        }
    }
}
