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
    public partial class ChiTieu : Form
    {
        public ChiTieu()
        {
            InitializeComponent();
        }

        private void txtChiTieu_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ThongKeDAO.Instance.UpdateChiTieu(Convert.ToDouble(txtChiTieu.Text));
                MessageBox.Show("Cập nhật số tiền thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng nhập số tiền");
            }
        }

        private void ChiTieu_Load(object sender, EventArgs e)
        {
            txtChiTieu.Text = ThongKeDAO.Instance.ChiTieu();
        }
    }
}
