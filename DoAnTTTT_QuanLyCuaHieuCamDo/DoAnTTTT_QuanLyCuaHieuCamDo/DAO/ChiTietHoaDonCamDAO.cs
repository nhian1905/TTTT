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
            string query = "select c.MaHoaDonCam, a.MaSP,b.TenLoai,a.ID_SP,a.TenSP,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang, a.NhangHieu from SanPham a , LoaiSP b , ChiTiet_HoaDonCam c, HoaDonCam d where a.MaLoai = b.MaLoai and a.MaSP = c.MaSP and c.MaHoaDonCam = d.MaHoaDonCam and c.MaHoaDonCam  = " + MaHoaDonCam;
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                ChiTietHoaDonCamDTO SP = new ChiTietHoaDonCamDTO(item);
                LoadList.Add(SP);
            }
            return LoadList;
        }

        /// <summary>
        ///  Load SP ben Chuoc SP
        /// </summary>
        /// <param name="MaHoaDonCam"></param>
        /// <returns></returns>
        public List<ChiTietHoaDonCamDTO> LoadListSP(int MaHoaDonCam)
        {
            List<ChiTietHoaDonCamDTO> LoadListSp = new List<ChiTietHoaDonCamDTO>();
            string query = "select c.MaHoaDonCam, a.MaSP,b.TenLoai,a.ID_SP,a.TenSP,a.DinhGia,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang, a.NhangHieu from SanPham a , LoaiSP b , ChiTiet_HoaDonCam c, HoaDonCam d where a.MaLoai = b.MaLoai and a.MaSP = c.MaSP and c.MaHoaDonCam = d.MaHoaDonCam and a.DaChuoc=0 and a.ThanhLy=0 and a.DaThanhLy=0 and a.QuaHan=0 and c.MaHoaDonCam  = " + MaHoaDonCam;
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                ChiTietHoaDonCamDTO SP = new ChiTietHoaDonCamDTO(item);
                LoadListSp.Add(SP);
            }
            return LoadListSp;
        }

        public bool InsertSPtoBillHDC(int MaHoaDonCam, string MaSP)
        {
            string query = string.Format("insert into ChiTiet_HoaDonCam(MaHoaDonCam,MaSP) values('{0}',N'{1}')", MaHoaDonCam, MaSP);
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
            string query = string.Format("delete ChiTiet_HoaDonCam where MaSP =N'{0}'", MaSP);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }
        public string SoLuong(int MaLoai)
        {
            string query = string.Format("select count(ID_SP) from SanPham where MaLoai=N'{0}'", MaLoai);
            string kq = Convert.ToString(CSDL.Instance.ExecuteScalar(query));
            return kq;
        }
    }
}
