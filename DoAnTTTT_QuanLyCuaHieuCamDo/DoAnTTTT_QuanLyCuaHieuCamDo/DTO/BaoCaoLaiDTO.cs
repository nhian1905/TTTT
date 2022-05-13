using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.DTO
{
    public class BaoCaoLaiDTO
    {
        private int maPhieuLai;
        private int maHoaDonCam;
        private string tenKH;
        private int sDT;
        private int cMND;
        private DateTime ngayDongLai;
        private float thanhTien;

        public int MaPhieuLai { get => maPhieuLai; set => maPhieuLai = value; }
        public int MaHoaDonCam { get => maHoaDonCam; set => maHoaDonCam = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public int SDT { get => sDT; set => sDT = value; }
        public int CMND { get => cMND; set => cMND = value; }
        public DateTime NgayDongLai { get => ngayDongLai; set => ngayDongLai = value; }
        public float ThanhTien { get => thanhTien; set => thanhTien = value; }
        

        public BaoCaoLaiDTO(int MaPhieuLai,int MaHoaDonCam, string TenKH, int SDT , int CMND , DateTime NgayDongLai, float ThanhTien)
        {
            this.MaPhieuLai = MaPhieuLai;
            this.MaHoaDonCam = MaHoaDonCam;
            this.TenKH = TenKH;
            this.SDT = SDT;
            this.CMND = CMND;
            this.NgayDongLai = NgayDongLai;
            this.ThanhTien = ThanhTien;
        }

        public BaoCaoLaiDTO(DataRow row)
        {
            this.MaPhieuLai = (int)row["MaPhieuLai"];
            this.MaHoaDonCam = (int)row["MaHoaDonCam"];
            this.TenKH = row["TenKH"].ToString();
            this.SDT = (int)row["SDT"];
            this.CMND = (int)row["CMND"];
            this.NgayDongLai = (DateTime)row["NgayDongLai"];
            this.ThanhTien = (float)Convert.ToDouble(row["ThanhTien"]);
        }
    }
}
