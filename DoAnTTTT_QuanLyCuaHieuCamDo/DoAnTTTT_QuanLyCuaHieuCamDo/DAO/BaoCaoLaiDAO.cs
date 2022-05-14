using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.DAO
{
    public class BaoCaoLaiDAO
    {
        private static BaoCaoLaiDAO instance;

        public static BaoCaoLaiDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BaoCaoLaiDAO();
                return instance;
            }
            private set => instance = value;
        }

        private BaoCaoLaiDAO() { }

        public List<BaoCaoLaiDTO> LoadListBaoCaoLai()
        {
            List<BaoCaoLaiDTO> LoadList = new List<BaoCaoLaiDTO>();
            string query = "select  c.MaPhieuLai,a.MaHoaDonCam,b.TenKH,b.SDT,b.CMND,c.NgayDongLai,c.ThanhTien from HoaDonCam a,KhachHang b, PhieuLai c  where c.MaHoaDonCam = a.MaHoaDonCam and b.MaKH = a.MaKH";
            DataTable dta = CSDL.Instance.ExecuteQuery(query);
            foreach (DataRow item in dta.Rows)
            {
                BaoCaoLaiDTO SP = new BaoCaoLaiDTO(item);
                LoadList.Add(SP);
            }
            return LoadList;
        }
    }
}
