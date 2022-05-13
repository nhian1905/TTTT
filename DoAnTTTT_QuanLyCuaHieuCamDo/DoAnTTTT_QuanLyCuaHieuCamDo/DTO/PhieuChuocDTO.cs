using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DoAnTTTT_QuanLyCuaHieuCamDo.DTO
{
    public class PhieuChuocDTO
    {
        private int maPhieuChuoc;
        private int maHoaDonCam;
        private DateTime ngayChuoc;
        private double tongTien;

        public int MaPhieuChuoc { get => maPhieuChuoc; set => maPhieuChuoc = value; }
        public int MaHoaDonCam { get => maHoaDonCam; set => maHoaDonCam = value; }
        public DateTime NgayChuoc { get => ngayChuoc; set => ngayChuoc = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }


        public PhieuChuocDTO(int MaPhieuChuoc, int MaHoaDonCam, DateTime NgayChuoc, float TongTien)
        {
            this.MaPhieuChuoc = MaPhieuChuoc;
            this.MaHoaDonCam = MaHoaDonCam;
            this.NgayChuoc = NgayChuoc;
            this.TongTien = TongTien;
        }

        public PhieuChuocDTO(DataRow row)
        {
            this.MaPhieuChuoc = (int)row["MaPhieuChuoc"];
            this.MaHoaDonCam = (int)row["MaHoaDonCam"];
            this.NgayChuoc = (DateTime)row["NgayChuoc"];
            this.TongTien = (float)Convert.ToDouble(row["TongTien"]);
        }
    }
}
