using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.DAO
{
    public class BaoCaoThanhLyDAO
    {
        private static BaoCaoThanhLyDAO instance;

        public static BaoCaoThanhLyDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BaoCaoThanhLyDAO();
                return instance;
            }
            private set => instance = value;
        }

        private BaoCaoThanhLyDAO() { }

        public List<BaoCaoThanhLyDTO> LoadListBaoCaoLai()
        {
            List<BaoCaoThanhLyDTO> LoadList = new List<BaoCaoThanhLyDTO>();
            string query = "select  a.MaThanhLy,b.TenKH,b.SDT,b.CMND,a.NgayLap,d.MaSP,e.TenLoai,d.TenSP,d.GiaThanhLy,d.MoTa,d.NhangHieu,d.MauSac,d.HienTrang from ThanhLy a,KhachHang b, ChiTiet_ThanhLy c ,SanPham d, LoaiSP e  where a.MaThanhLy = c.MaThanhLy and a.MaKH = b.MaKH and c.MaSP = d.MaSP and d.MaLoai = e.MaLoai";
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                BaoCaoThanhLyDTO SP = new BaoCaoThanhLyDTO(item);
                LoadList.Add(SP);
            }
            return LoadList;
        }
    }
}
