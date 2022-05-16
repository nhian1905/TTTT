using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnTTTT_QuanLyCuaHieuCamDo.DAO;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.Design
{
    public partial class ChiTieuThang : Form
    {
        public ChiTieuThang()
        {
            InitializeComponent();
        }

        private void ChiTieuThang_Load(object sender, EventArgs e)
        {
            txtChiTieuThang.Text = ThongKeDAO.Instance.ChiTieuThang();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ThongKeDAO.Instance.UpdateChiTieuThang(Convert.ToDouble(txtChiTieuThang.Text));
                MessageBox.Show("Cập nhật số tiền thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng nhập số tiền");
            }
        }
    }
}
