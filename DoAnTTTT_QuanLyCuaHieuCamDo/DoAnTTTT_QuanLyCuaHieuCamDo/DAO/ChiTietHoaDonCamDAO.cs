using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;
namespace DoAnTTTT_QuanLyCuaHieuCamDo.DAO
{
    public class ChiTietHoaDonCamDAO
    {
        private static ChiTietHoaDonCamDAO instance;

        public static ChiTietHoaDonCamDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChiTietHoaDonCamDAO();
                return instance;
            }
            private set => instance = value;
        }

        private ChiTietHoaDonCamDAO() { }

        public List<ChiTietHoaDonCamDTO> LoadListCTHDC(int MaHoaDonCam)
        {
            List<ChiTietHoaDonCamDTO> LoadList = new List<ChiTietHoaDonCamDTO>();
            string query = "select c.MaHoaDonCam, a.MaSP,b.TenLoai,a.TenSP,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang, a.NhangHieu from SanPham a , LoaiSP b , ChiTiet_HoaDonCam c, HoaDonCam d where a.MaLoai = b.MaLoai and a.MaSP = c.MaSP and c.MaHoaDonCam = d.MaHoaDonCam and c.MaHoaDonCam  = " +MaHoaDonCam;
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                ChiTietHoaDonCamDTO SP = new ChiTietHoaDonCamDTO(item);
                LoadList.Add(SP);
            }
            return LoadList;
        }

        
        public bool InsertSPtoBillHDC(int MaHoaDonCam, string MaSP)
        {
            string query = string.Format("insert ChiTiet_HoaDonCam(MaHoaDonCam,MaSP) values('{0}',N'{1}')", MaHoaDonCam,MaSP);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }
        public bool UpdateSPtoBillHDC(int MaHoaDonCam, string MaSP)
        {
            string query = string.Format("update ChiTiet_HoaDonCam set MaHoaDonCam =N'{0}' where MaSP =N'{1}'", MaHoaDonCam, MaSP);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

        public bool DeletetoBillHDC(string MaSP)
        {
            string query = string.Format("delete ChiTiet_HoaDonCam where MaSP =N'{0}'",  MaSP);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

    }
}
