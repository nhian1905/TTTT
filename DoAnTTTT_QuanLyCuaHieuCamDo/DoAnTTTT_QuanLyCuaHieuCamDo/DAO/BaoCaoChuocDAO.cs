using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.DAO
{
    public class BaoCaoChuocDAO
    {
        private static BaoCaoChuocDAO instance;

        public static BaoCaoChuocDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BaoCaoChuocDAO();
                return instance;
            }
            private set => instance = value;
        }

        private BaoCaoChuocDAO() { }

        public List<BaoCaoChuocDTO> LoadListBaoCaoChuoc()
        {
            List<BaoCaoChuocDTO> LoadList = new List<BaoCaoChuocDTO>();
            string query = "select  a.MaPhieuChuoc,f.MaHoaDonCam,b.TenKH,b.SDT,b.CMND,a.NgayChuoc,d.MaSP,e.TenLoai,d.TenSP,d.DinhGia,d.MoTa,d.NhangHieu,d.MauSac,d.HienTrang,c.TienLai,c.TongTien from PhieuChuoc a, KhachHang b, ChiTiet_PhieuChuoc c ,SanPham d, LoaiSP e,HoaDonCam f where a.MaHoaDonCam = f.MaHoaDonCam and f.MaKH = b.MaKH and c.MaSP = d.MaSP and d.MaLoai = e.MaLoai and a.MaPhieuChuoc = c.MaPhieuChuoc";
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                BaoCaoChuocDTO SP = new BaoCaoChuocDTO(item);
                LoadList.Add(SP);
            }
            return LoadList;
        }
        public List<BaoCaoChuocDTO> LoadListBaoCaoChuocTheoNgay(DateTime NgayDau,DateTime NgayCuoi)
        {
            List<BaoCaoChuocDTO> LoadList = new List<BaoCaoChuocDTO>();
            string query = string.Format("select  a.MaPhieuChuoc,f.MaHoaDonCam,b.TenKH,b.SDT,b.CMND,a.NgayChuoc,d.MaSP,e.TenLoai,d.TenSP,d.DinhGia,d.MoTa,d.NhangHieu,d.MauSac,d.HienTrang,c.TienLai,c.TongTien from PhieuChuoc a, KhachHang b, ChiTiet_PhieuChuoc c ,SanPham d, LoaiSP e,HoaDonCam f where a.MaHoaDonCam = f.MaHoaDonCam and f.MaKH = b.MaKH and c.MaSP = d.MaSP and d.MaLoai = e.MaLoai and a.MaPhieuChuoc = c.MaPhieuChuoc and a.NgayChuoc >=N'{0}' and a.NgayChuoc <=N'{1}'",NgayDau,NgayCuoi);
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                BaoCaoChuocDTO SP = new BaoCaoChuocDTO(item);
                LoadList.Add(SP);
            }
            return LoadList;
        }

        public List<PhieuChuocDTO> LoadListHDChuocTheoNgay(DateTime NgayDau, DateTime NgayCuoi)
        {
            List<PhieuChuocDTO> LoadList = new List<PhieuChuocDTO>();
            string query = string.Format(" exec USP_TimHoaDonChuocByDate '{0}' , '{1}' ", NgayDau, NgayCuoi);
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                PhieuChuocDTO SP = new PhieuChuocDTO(item);
                LoadList.Add(SP);
            }
            return LoadList;
        }
    }
}
