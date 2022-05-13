using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;
namespace DoAnTTTT_QuanLyCuaHieuCamDo.DAO
{
    class ChiTietPhieuChuocDAO
    {
        private static ChiTietPhieuChuocDAO instance;

        public static ChiTietPhieuChuocDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChiTietPhieuChuocDAO();
                return instance;
            }
            private set => instance = value;
        }

        private ChiTietPhieuChuocDAO() { }

        public List<ChiTietPhieuChuocDTO> LoadListCTPhieuChuoc()
        {
            List<ChiTietPhieuChuocDTO> LoadList = new List<ChiTietPhieuChuocDTO>();
            string query = "select  a.MaSP,a.TenSP,a.DinhGia,b.LaiXuat, c.TienLai,a.MoTa,a.MauSac,a.HienTrang, a.NhangHieu, c.TongTien from SanPham a  , LoaiSP b, ChiTiet_PhieuChuoc c, PhieuChuoc d where   a.MaSP = c.MaSP and c.MaPhieuChuoc = d.MaPhieuChuoc and a.MaLoai = b.MaLoai ";
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                ChiTietPhieuChuocDTO SP = new ChiTietPhieuChuocDTO(item);
                LoadList.Add(SP);
            }
            return LoadList;
        }

        public List<ChiTietPhieuChuocDTO> LoadListCTPhieuChuocByPC(int MaPhieuChuoc)
        {
            List<ChiTietPhieuChuocDTO> LoadList = new List<ChiTietPhieuChuocDTO>();
            string query = "select  a.MaSP,a.TenSP,a.DinhGia,b.LaiXuat, c.TienLai,a.MoTa,a.MauSac,a.HienTrang, a.NhangHieu, c.TongTien from SanPham a  , LoaiSP b, ChiTiet_PhieuChuoc c, PhieuChuoc d where   a.MaSP = c.MaSP and c.MaPhieuChuoc = d.MaPhieuChuoc and a.MaLoai = b.MaLoai and c.MaPhieuChuoc =" +MaPhieuChuoc;
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                ChiTietPhieuChuocDTO SP = new ChiTietPhieuChuocDTO(item);
                LoadList.Add(SP);
            }
            return LoadList;
        }



        public bool InsertSPtoBillPhieuChuoc(int MaPhieuChuoc, string MaSP, float TienLai , float TongTien)
        {
            string query = string.Format("insert ChiTiet_PhieuChuoc(MaPhieuChuoc,MaSP,TienLai,TongTien) values(N'{0}',N'{1}',N'{2}',N'{3}')", MaPhieuChuoc, MaSP,TienLai,TongTien);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

        public bool DeletetoBillThanhLy( string MaSP)
        {
            string query = string.Format("delete ChiTiet_PhieuChuoc where MaSP = N'{0}'", MaSP);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }
        public bool UpdateSPDaChuoc(string MaSP)
        {
            string query = string.Format("update SanPham set DaChuoc= 1  where MaSP=N'{0}'", MaSP);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

        public bool UpdateXoaSPDaChuoc(string MaSP)
        {
            string query = string.Format("update SanPham set DaChuoc= 0  where MaSP=N'{0}'", MaSP);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }
    }
}
