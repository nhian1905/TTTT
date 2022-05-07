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
    }
}
