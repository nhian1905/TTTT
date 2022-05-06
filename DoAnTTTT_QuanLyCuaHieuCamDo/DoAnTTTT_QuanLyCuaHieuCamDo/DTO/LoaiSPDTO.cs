using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.DTO
{
    public class LoaiSPDTO
    {
        private int maLoai;
        private string tenLoai;
        private int laiXuat;

        public int MaLoai { get => maLoai; set => maLoai = value; }
        public string TenLoai { get => tenLoai; set => tenLoai = value; }
        public int LaiXuat { get => laiXuat; set => laiXuat = value; }

        public LoaiSPDTO(int MaLoai, string TenLoai, int LaiXuat)
        {
            this.MaLoai = MaLoai;
            this.TenLoai = TenLoai;
            this.LaiXuat = LaiXuat;
        }

        public LoaiSPDTO(DataRow row)
        {
            this.MaLoai = (int)row["MaLoai"];
            this.TenLoai = row["TenLoai"].ToString();
            this.LaiXuat = (int)row["LaiXuat"];
        }
    }
}
