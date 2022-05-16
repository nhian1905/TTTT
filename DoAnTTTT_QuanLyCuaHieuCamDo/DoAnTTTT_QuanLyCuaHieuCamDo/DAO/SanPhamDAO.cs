using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;
using System.Data;
namespace DoAnTTTT_QuanLyCuaHieuCamDo.DAO
{
    public class SanPhamDAO
    {
        private static SanPhamDAO instance;

        public static SanPhamDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new SanPhamDAO();
                return instance;
            }
            private set => instance = value;
        }

        private SanPhamDAO() { }

        public List<SanPhamDTO> LoadListSP()
        {
            List<SanPhamDTO> LoadList = new List<SanPhamDTO>();
            string query = "select a.MaSP,b.TenLoai,a.TenSP,b.LaiXuat,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang,a.NhangHieu,a.QuaHan,a.DaChuoc,a.ThanhLy,a.DaThanhLy from SanPham a , LoaiSP b where a.MaLoai = b.MaLoai";
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                SanPhamDTO SP = new SanPhamDTO(item);
                LoadList.Add(SP);
            }
            return LoadList;
        }

        public List<SanPhamDTO> LoadListSPThanhLy()
        {
            List<SanPhamDTO> LoadList = new List<SanPhamDTO>();
            string query = "select a.MaSP,b.TenLoai,a.TenSP,b.LaiXuat,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang,a.NhangHieu,a.QuaHan,a.DaChuoc,a.ThanhLy,a.DaThanhLy from SanPham a , LoaiSP b where a.MaLoai = b.MaLoai and a.ThanhLy = 1 and a.DaThanhLy = 0 and a.QuaHan = 0 and a.DaChuoc = 0";
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                SanPhamDTO SP = new SanPhamDTO(item);
                LoadList.Add(SP);
            }
            return LoadList;
        }
        public List<SanPhamDTO> LoadListSPDaThanhLy()
        {
            List<SanPhamDTO> LoadList = new List<SanPhamDTO>();
            string query = "select a.MaSP,b.TenLoai,a.TenSP,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang,a.NhangHieu,a.QuaHan,a.DaChuoc,a.ThanhLy,a.DaThanhLy from SanPham a , LoaiSP b where a.MaLoai = b.MaLoai and a.ThanhLy = 0 and a.DaThanhLy = 1 and a.QuaHan = 1 and a.DaChuoc = 0";
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                SanPhamDTO SP = new SanPhamDTO(item);
                LoadList.Add(SP);
            }
            return LoadList;
        }
        public List<SanPhamDTO> LoadListSPQuaHan()
        {
            List<SanPhamDTO> LoadList = new List<SanPhamDTO>();
            string query = "select a.MaSP,b.TenLoai,a.TenSP,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang,a.NhangHieu,a.QuaHan,a.DaChuoc,a.ThanhLy,a.DaThanhLy from SanPham a , LoaiSP b where a.MaLoai = b.MaLoai and a.ThanhLy = 0 and a.DaThanhLy = 0 and a.QuaHan = 1 and a.DaChuoc = 0";
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                SanPhamDTO SP = new SanPhamDTO(item);
                LoadList.Add(SP);
            }
            return LoadList;
        }
        public List<SanPhamDTO> LoadListSPDaChuoc()
        {
            List<SanPhamDTO> LoadList = new List<SanPhamDTO>();
            string query = "select a.MaSP,b.TenLoai,a.TenSP,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang,a.NhangHieu,a.QuaHan,a.DaChuoc,a.ThanhLy,a.DaThanhLy from SanPham a , LoaiSP b where a.MaLoai = b.MaLoai and a.ThanhLy = 0 and a.DaThanhLy = 0 and a.QuaHan = 0 and a.DaChuoc = 1";
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                SanPhamDTO SP = new SanPhamDTO(item);
                LoadList.Add(SP);
            }
            return LoadList;
        }


        public bool InsertSP(string MaSP, int MaLoai, string TenSP, float DinhGia, float GiaThanhLy, string MoTa, string MauSac, string HienTrang, string NhangHieu, bool QuaHan, bool DaChuoc, bool ThanhLy, bool DaThanhLy)
        {
            string query = string.Format("insert SanPham (MaSP,MaLoai , TenSP, DinhGia , GiaThanhLy , MoTa ,MauSac,HienTrang,NhangHieu,QuaHan,DaChuoc,ThanhLy,DaThanhLy) values (N'{0}' , N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}', N'{12}')", MaSP, MaLoai, TenSP, DinhGia, GiaThanhLy, MoTa, MauSac, HienTrang, NhangHieu, QuaHan, DaChuoc, ThanhLy, DaThanhLy);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

        public bool DeleteSP(string MaSP)
        {
            string query = string.Format("delete SanPham where MaSP = N'{0}'",MaSP);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

        public bool UpdateSP(string MaSP, int MaLoai, string TenSP, float DinhGia, float GiaThanhLy, string MoTa, string MauSac, string HienTrang, string NhangHieu)
        {
            string query = string.Format("update SanPham set MaLoai =N'{0}' , TenSP=N'{1}', DinhGia=N'{2}', GiaThanhLy=N'{3}' , MoTa=N'{4}' ,MauSac=N'{5}',HienTrang=N'{6}',NhangHieu=N'{7}' where MaSP=N'{8}'",  MaLoai, TenSP, DinhGia, GiaThanhLy, MoTa, MauSac, HienTrang, NhangHieu, MaSP);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

        public bool ThanhLySP(string MaSP,bool ThanhLy)
        {
            string query = string.Format("update SanPham set ThanhLy = N'{0}' where MaSP = N'{1}'", ThanhLy, MaSP);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

        public bool UpdateSPQuaHan(DateTime NgayHienTai)
        {
            string query = string.Format("exec USP_UpdateQuaHan '{0}'", NgayHienTai);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

        public List<SanPhamDTO> TimKiem(bool ThanhLy , bool QuaHan , bool DaChuoc , bool DaThanhLy)
        {
            List<SanPhamDTO> ListSP = new List<SanPhamDTO>();
            string query = string.Format("select a.MaSP,b.TenLoai,a.TenSP,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang,a.NhangHieu,a.QuaHan,a.DaChuoc,a.ThanhLy,a.DaThanhLy from SanPham a , LoaiSP b where a.MaLoai = b.MaLoai and a.ThanhLy LIKE 1 or a.DaThanhLy LIKE 1  or a.QuaHan like 1 or a.DaChuoc Like 1 ", ThanhLy,QuaHan,DaChuoc,DaThanhLy);
            
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                SanPhamDTO tk = new SanPhamDTO(item);
                ListSP.Add(tk);
            }
            return ListSP;
        }

    }
}
