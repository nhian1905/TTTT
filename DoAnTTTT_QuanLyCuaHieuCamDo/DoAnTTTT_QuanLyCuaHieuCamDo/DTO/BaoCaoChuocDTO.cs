using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DoAnTTTT_QuanLyCuaHieuCamDo.DTO
{
    public class BaoCaoChuocDTO
    {
        private int maPhieuChuoc;
        private int maHoaDonCam;
        private string tenKH;
        private int sDT;
        private int cMND;
        private DateTime ngayChuoc;
        private float tongTien;

        public int MaPhieuChuoc { get => maPhieuChuoc; set => maPhieuChuoc = value; }
        public int MaHoaDonCam { get => maHoaDonCam; set => maHoaDonCam = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public int SDT { get => sDT; set => sDT = value; }
        public int CMND { get => cMND; set => cMND = value; }
        public DateTime NgayChuoc { get => ngayChuoc; set => ngayChuoc = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }
        

        public BaoCaoChuocDTO(int MaPhieuChuoc,int MaHoaDonCam, string TenKH, int SDT, int CMND, DateTime NgayChuoc, float TongTien)
        {
            this.MaPhieuChuoc = MaPhieuChuoc;
            this.MaHoaDonCam = MaHoaDonCam;
            this.TenKH = TenKH;
            this.SDT = SDT;
            this.CMND = CMND;
            this.NgayChuoc = NgayChuoc;
            this.TongTien = TongTien;
        }

        public BaoCaoChuocDTO(DataRow row)
        {
            this.MaPhieuChuoc = (int)row["MaPhieuChuoc"];
            this.MaHoaDonCam = (int)row["MaHoaDonCam"];
            this.TenKH = row["TenKH"].ToString();
            this.SDT = (int)row["SDT"];
            this.CMND = (int)row["CMND"];
            this.NgayChuoc = (DateTime)row["NgayChuoc"];
            this.TongTien = (float)Convert.ToDouble(row["TongTien"]);
        }
    }
}
