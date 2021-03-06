using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DoAnTTTT_QuanLyCuaHieuCamDo.DTO
{
    public class HoaDonCamDTO
    {
        private int maHoaDonCam;
        private string tenKH;
        private DateTime ngayLap;
        private DateTime ngayHetHan;
        private DateTime ngayDongLai;
        private double tongTienCam;

        public int MaHoaDonCam { get => maHoaDonCam; set => maHoaDonCam = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public DateTime NgayHetHan { get => ngayHetHan; set => ngayHetHan = value; }
        public double TongTienCam { get => tongTienCam; set => tongTienCam = value; }
        public DateTime NgayDongLai { get => ngayDongLai; set => ngayDongLai = value; }


        public HoaDonCamDTO(int MaHoaDonCam, string TenKH, DateTime NgayLap, DateTime NgayHetHan, DateTime NgayDongLai, double TongTienCam)
        {
            this.MaHoaDonCam = MaHoaDonCam;
            this.TenKH = TenKH;
            this.NgayLap = NgayLap;
            this.NgayHetHan = NgayHetHan;
            this.NgayDongLai = NgayDongLai;
            this.TongTienCam = TongTienCam;
            
        }

        public HoaDonCamDTO(DataRow row)
        {
            this.MaHoaDonCam = (int)row["MaHoaDonCam"];
            this.TenKH = row["TenKH"].ToString();
            this.NgayLap = (DateTime)row["NgayLap"];
            this.NgayHetHan = (DateTime)row["NgayHetHan"];
            this.TongTienCam = (double)Convert.ToDouble(row["TongTienCam"]);
        }
    }
}
