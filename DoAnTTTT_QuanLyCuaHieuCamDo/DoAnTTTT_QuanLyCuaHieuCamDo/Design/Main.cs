using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DoAnTTTT_QuanLyCuaHieuCamDo.DAO;
using DoAnTTTT_QuanLyCuaHieuCamDo.DTO;
namespace DoAnTTTT_QuanLyCuaHieuCamDo
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            DateTime NgayHienTai = (DateTime)Convert.ToDateTime(DateTime.Now);
            SanPhamDAO.Instance.UpdateSPQuaHan(NgayHienTai);
        }

    }
}
