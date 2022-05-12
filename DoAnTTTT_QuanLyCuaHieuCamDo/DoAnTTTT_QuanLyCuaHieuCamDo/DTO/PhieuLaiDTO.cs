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
        private int maHoaDonCam;
        private DateTime ngayDongLai;
        private float tongTien;

        public int MaPhieuLai { get => maPhieuLai; set => maPhieuLai = value; }
        public int MaHoaDonCam { get => maHoaDonCam; set => maHoaDonCam = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }
        public DateTime NgayDongLai { get => ngayDongLai; set => ngayDongLai = value; }
        public PhieuLaiDTO(int MaPhieuLai, int MaHoaDonCam, DateTime NgayDongLai, float TongTien)
        {
            this.MaPhieuLai = MaPhieuLai;
            this.MaHoaDonCam = MaHoaDonCam;        
            this.NgayDongLai = NgayDongLai;
            this.TongTien = TongTien;

        }
        public PhieuLaiDTO(DataRow row)
        {
            this.MaPhieuLai = (int)row["MaPhieuLai"];
            this.NgayDongLai = (DateTime)row["NgayDongLai"];
            this.TongTien = (float)Convert.ToDouble(row["TongTien"]);
        }
    }
}
