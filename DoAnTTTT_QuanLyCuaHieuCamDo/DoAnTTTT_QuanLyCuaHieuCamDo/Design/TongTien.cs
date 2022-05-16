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
    public partial class TongTien : Form
    {
        public TongTien()
        {
            InitializeComponent();
        }

        private void TongTien_Load(object sender, EventArgs e)
        {
            txtTienVon.Text = ThongKeDAO.Instance.TienVon();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ThongKeDAO.Instance.UpdateTien(Convert.ToDouble(txtTienVon.Text));
                MessageBox.Show("Cập nhật số tiền thành công");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Vui lòng nhập số tiền");
            }
        }
    }
}
