using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.DAO
{
    public class BaoCaoCamDAO
    {
        private static BaoCaoCamDAO instance;

        public static BaoCaoCamDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BaoCaoCamDAO();
                return instance;
            }
            private set => instance = value;
        }

        private BaoCaoCamDAO() { }

        public List<BaoCaoCamDTO> LoadListBaoCaoCam()
        {
            List<BaoCaoCamDTO> LoadList = new List<BaoCaoCamDTO>();
            string query = "select  e.MaHoaDonCam,d.TenKH,e.NgayLap,e.NgayHetHan,b.MaSP,c.TenLoai,b.TenSP,b.DinhGia,b.MoTa,b.MauSac,b.HienTrang from ChiTiet_HoaDonCam a,SanPham b, LoaiSP c, KhachHang d, HoaDonCam e where b.MaLoai = c.MaLoai and a.MaHoaDonCam = e.MaHoaDonCam and a.MaSP = b.MaSP and e.MaKH = d.MaKH";
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                BaoCaoCamDTO SP = new BaoCaoCamDTO(item);
                LoadList.Add(SP);
            }
            return LoadList;
        }
    }
}
