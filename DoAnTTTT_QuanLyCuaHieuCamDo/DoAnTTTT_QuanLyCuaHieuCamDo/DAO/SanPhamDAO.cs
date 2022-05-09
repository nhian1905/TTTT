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
            string query = "select a.MaSP,b.TenLoai,a.TenSP,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang,a.NhangHieu,a.QuaHan,a.DaChuoc,a.ThanhLy,a.DaThanhLy from SanPham a , LoaiSP b where a.MaLoai = b.MaLoai";
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

        public List<SanPhamDTO> TimKiem(string name)
        {
            List<SanPhamDTO> ListSP = new List<SanPhamDTO>();
            string query = string.Format("select a.MaSP,b.TenLoai,a.TenSP,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang,a.NhangHieu,a.QuaHan,a.DaChuoc,a.ThanhLy,a.DaThanhLy from SanPham a , LoaiSP b where a.MaLoai = b.MaLoai and a.TenSP LIKE  N'%{0}%' ", name );

            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                SanPhamDTO tk = new SanPhamDTO(item);
                ListSP.Add(tk);
            }
            return ListSP;
        }

        public List<SanPhamDTO> TimKiemThanhLy(bool ThanhLy)
        {
            List<SanPhamDTO> ListSP = new List<SanPhamDTO>();
            string query = string.Format("select a.MaSP,b.TenLoai,a.TenSP,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang,a.NhangHieu,a.QuaHan,a.DaChuoc,a.ThanhLy,a.DaThanhLy from SanPham a , LoaiSP b where a.MaLoai = b.MaLoai and a.ThanhLy = 1 ", ThanhLy);
            
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                SanPhamDTO tk = new SanPhamDTO(item);
                ListSP.Add(tk);
            }
            return ListSP;
        }

        public List<SanPhamDTO> TimKiemDaThanhLy(bool DaThanhLy)
        {
            List<SanPhamDTO> ListSP = new List<SanPhamDTO>();
            string query = string.Format("select a.MaSP,b.TenLoai,a.TenSP,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang,a.NhangHieu,a.QuaHan,a.DaChuoc,a.ThanhLy,a.DaThanhLy from SanPham a , LoaiSP b where a.MaLoai = b.MaLoai and a.DaThanhLy = 1 ", DaThanhLy);

            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                SanPhamDTO tk = new SanPhamDTO(item);
                ListSP.Add(tk);
            }
            return ListSP;
        }

        public List<SanPhamDTO> TimKiemQuaHan(bool QuaHan)
        {
            List<SanPhamDTO> ListSP = new List<SanPhamDTO>();
            string query = string.Format("select a.MaSP,b.TenLoai,a.TenSP,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang,a.NhangHieu,a.QuaHan,a.DaChuoc,a.ThanhLy,a.DaThanhLy from SanPham a , LoaiSP b where a.MaLoai = b.MaLoai and a.QuaHan = 1 ", QuaHan);

            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                SanPhamDTO tk = new SanPhamDTO(item);
                ListSP.Add(tk);
            }
            return ListSP;
        }

        public List<SanPhamDTO> TimKiemDaChuoc(bool DaChuoc)
        {
            List<SanPhamDTO> ListSP = new List<SanPhamDTO>();
            string query = string.Format("select a.MaSP,b.TenLoai,a.TenSP,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang,a.NhangHieu,a.QuaHan,a.DaChuoc,a.ThanhLy,a.DaThanhLy from SanPham a , LoaiSP b where a.MaLoai = b.MaLoai and a.DaChuoc = 1 ", DaChuoc);

            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                SanPhamDTO tk = new SanPhamDTO(item);
                ListSP.Add(tk);
            }
            return ListSP;
        }

        public List<SanPhamDTO> TimKiemThanhLyVaDaThanhLy(bool ThanhLy, bool DaThanhLy)
        {
            List<SanPhamDTO> ListSP = new List<SanPhamDTO>();
            string query = string.Format("select a.MaSP,b.TenLoai,a.TenSP,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang,a.NhangHieu,a.QuaHan,a.DaChuoc,a.ThanhLy,a.DaThanhLy from SanPham a , LoaiSP b where a.MaLoai = b.MaLoai and a.ThanhLy = 1 and a.DaThanhLy = 1", ThanhLy,DaThanhLy);

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
