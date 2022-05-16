using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DoAnTTTT_QuanLyCuaHieuCamDo.DTO
{
    public class HoaDonCamPCDTO
    {
        private int maHoaDonCam;
        private int tenKH;
        private DateTime ngayLap;
        private DateTime ngayHetHan;
        private double tongTienCam;

        public int MaHoaDonCam { get => maHoaDonCam; set => maHoaDonCam = value; }
        public int TenKH { get => tenKH; set => tenKH = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public DateTime NgayHetHan { get => ngayHetHan; set => ngayHetHan = value; }
        public double TongTienCam { get => tongTienCam; set => tongTienCam = value; }

        public HoaDonCamPCDTO(int MaHoaDonCam, int TenKH, DateTime NgayLap, DateTime NgayHetHan, double TongTienCam)
        {
            this.MaHoaDonCam = MaHoaDonCam;
            this.TenKH = TenKH;
            this.NgayLap = NgayLap;
            this.NgayHetHan = NgayHetHan;
            this.TongTienCam = TongTienCam;
        }

        public HoaDonCamPCDTO(DataRow row)
        {
            this.MaHoaDonCam = (int)row["MaHoaDonCam"];
            this.TenKH = (int)row["MaKH"];
            this.NgayLap = (DateTime)row["NgayLap"];
            this.NgayHetHan = (DateTime)row["NgayHetHan"];
            this.TongTienCam = (double)Convert.ToDouble(row["TongTienCam"]);
        }
    }
}
