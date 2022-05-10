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
    }
}
