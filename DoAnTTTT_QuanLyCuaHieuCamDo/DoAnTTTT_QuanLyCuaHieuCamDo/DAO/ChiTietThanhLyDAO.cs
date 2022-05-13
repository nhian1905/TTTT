using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;
namespace DoAnTTTT_QuanLyCuaHieuCamDo.DAO
{
    public class ChiTietThanhLyDAO
    {
        private static ChiTietThanhLyDAO instance;

        public static ChiTietThanhLyDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChiTietThanhLyDAO();
                return instance;
            }
            private set => instance = value;
        }

        private ChiTietThanhLyDAO() { }

        public List<ChiTietThanhLyDTO> LoadListCTThanhLy(int MaThanhLy)
        {
            List<ChiTietThanhLyDTO> LoadList = new List<ChiTietThanhLyDTO>();
            string query = "select  a.MaSP,a.TenSP,a.GiaThanhLy,a.MoTa,a.MauSac,a.HienTrang, a.NhangHieu from SanPham a  , ChiTiet_ThanhLy c, ThanhLy d where   a.MaSP = c.MaSP and c.MaThanhLy = d.MaThanhLy and c.MaThanhLy  = " + MaThanhLy;
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                ChiTietThanhLyDTO SP = new ChiTietThanhLyDTO(item);
                LoadList.Add(SP);
            }
            return LoadList;
        }

        public bool InsertSPtoBillThanhLy(int MaThanhLy, string MaSP)
        {
            string query = string.Format("insert ChiTiet_ThanhLy(MaThanhLy,MaSP) values(N'{0}',N'{1}')", MaThanhLy, MaSP);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

        public bool DeletetoBillThanhLy(int MaThanhLy, string MaSP)
        {
            string query = string.Format("delete ChiTiet_ThanhLy where MaThanhLy = N'{0}' and MaSP =N'{1}'", MaThanhLy, MaSP);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

        public bool UpdateSPTL(string MaSP)
        {
            string query = string.Format("update SanPham set DaThanhLy = 1,ThanhLy=0 where MaSP = N'{0}'", MaSP);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }

        public bool UpdateXoaSPTL(string MaSP)
        {
            string query = string.Format("update SanPham set DaThanhLy = 0 where MaSP = N'{0}'", MaSP);
            int kq = CSDL.Instance.ExecuteNonQuery(query);
            return kq > 0;
        }
    }
}
