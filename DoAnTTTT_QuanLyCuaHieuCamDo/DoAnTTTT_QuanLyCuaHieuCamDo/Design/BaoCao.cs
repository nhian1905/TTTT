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
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.Design
{
    public partial class BaoCao : Form
    {
        public BaoCao()
        {
            InitializeComponent();
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {
            LoadHoaDonCam();
            LoadPhieuChuoc();
            LoadThanhLy();
            LoadHoaDonCamPL();
        }

        void LoadHoaDonCam()
        {
            LVHDC.Items.Clear();
            List<HoaDonCamDTO> list = HoaDonCamDAO.Instance.LoadListHoaDonCam();
            foreach (HoaDonCamDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaHoaDonCam.ToString());
                lvitem.SubItems.Add(item.TenKH.ToString());
                lvitem.SubItems.Add(item.NgayLap.ToString());
                lvitem.SubItems.Add(item.NgayHetHan.ToString());
                lvitem.SubItems.Add(item.TongTienCam.ToString());
                LVHDC.Items.Add(lvitem);
            }
        }

        void LoadCTHoaDonCam(int MaHDC)
        {
            LVCTHDC.Items.Clear();
            List<ChiTietHoaDonCamDTO> list = ChiTietHoaDonCamDAO.Instance.LoadListCTHDC(MaHDC);
            foreach (ChiTietHoaDonCamDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaHoaDonCam.ToString());
                lvitem.SubItems.Add(item.MaSP.ToString());
                lvitem.SubItems.Add(item.TenLoai.ToString());
                lvitem.SubItems.Add(item.TenSP.ToString());
                lvitem.SubItems.Add(item.DinhGia.ToString());
                lvitem.SubItems.Add(item.MoTa.ToString());
                lvitem.SubItems.Add(item.MauSac.ToString());
                lvitem.SubItems.Add(item.HienTrang.ToString());
                lvitem.SubItems.Add(item.NhanHieu.ToString());
                LVCTHDC.Items.Add(lvitem);
            }
        }
        /// <summary>
        /// ////////// PHIEU CHUOC
        /// </summary>
        void LoadPhieuChuoc()
        {
            LvPhieuChuoc.Items.Clear();
            List<PhieuChuocDTO> list = PhieuChuocDAO.Instance.LoadListPhieuChuoc();
            foreach (PhieuChuocDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaPhieuChuoc.ToString());
                lvitem.SubItems.Add(item.MaHoaDonCam.ToString());
                lvitem.SubItems.Add(item.NgayChuoc.ToString());
                lvitem.SubItems.Add(item.TongTien.ToString());
                LvPhieuChuoc.Items.Add(lvitem);
            }
        }

        void LoadCTPhieuChuoc(int MaPhieuChuoc)
        {
            LvCTPhieuChuoc.Items.Clear();
            List<ChiTietPhieuChuocDTO> list = ChiTietPhieuChuocDAO.Instance.LoadListCTPhieuChuocByPC(MaPhieuChuoc);
            foreach (ChiTietPhieuChuocDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaSP.ToString());
                //lvitem.SubItems.Add(item.MaSP.ToString());
                lvitem.SubItems.Add(item.TenSP.ToString());
                lvitem.SubItems.Add(item.DinhGia.ToString());
                lvitem.SubItems.Add(item.LaiXuat.ToString());
                lvitem.SubItems.Add(item.TienLai.ToString());
                lvitem.SubItems.Add(item.MauSac.ToString());
                lvitem.SubItems.Add(item.NhanHieu.ToString());
                lvitem.SubItems.Add(item.MoTa.ToString());
                lvitem.SubItems.Add(item.HienTrang.ToString());
                lvitem.SubItems.Add(item.TongTien.ToString());
                LvCTPhieuChuoc.Items.Add(lvitem);
            }
        }


        /// <summary>
        /// ///// THANH LY
        /// </summary>
        void LoadThanhLy()
        {
            LVThanhLy.Items.Clear();
            List<ThanhLyDTO> list = ThanhLyDAO.Instance.LoadListThanhLy();
            foreach (ThanhLyDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaThanhLy.ToString());
                lvitem.SubItems.Add(item.TenKH.ToString());
                lvitem.SubItems.Add(item.NgayLap.ToString());
                lvitem.SubItems.Add(item.TongTienThanhLy.ToString());
                LVThanhLy.Items.Add(lvitem);
            }
        }
        void LoadCTThanhLy(int MaThanhLy)
        {
            LVCTThanhLy.Items.Clear();
            List<ChiTietThanhLyDTO> list = ChiTietThanhLyDAO.Instance.LoadListCTThanhLy(MaThanhLy);
            foreach (ChiTietThanhLyDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaSP.ToString());
                lvitem.SubItems.Add(item.TenSP.ToString());
                lvitem.SubItems.Add(item.GiaThanhLy.ToString());
                lvitem.SubItems.Add(item.MauSac.ToString());
                lvitem.SubItems.Add(item.NhanHieu.ToString());
                lvitem.SubItems.Add(item.MoTa.ToString());
                lvitem.SubItems.Add(item.HienTrang.ToString());
                LVCTThanhLy.Items.Add(lvitem);
            }
        }
        /// <summary>
        /// Phieu Lai
        /// </summary>
        void LoadHoaDonCamPL()
        {
            LVPhieuCam.Items.Clear();
            List<HoaDonCamDTO> list = HoaDonCamDAO.Instance.LoadListHoaDonCam();
            foreach (HoaDonCamDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaHoaDonCam.ToString());
                lvitem.SubItems.Add(item.TenKH.ToString());
                lvitem.SubItems.Add(item.NgayLap.ToString());
                lvitem.SubItems.Add(item.NgayHetHan.ToString());
                lvitem.SubItems.Add(item.TongTienCam.ToString());
                LVPhieuCam.Items.Add(lvitem);
            }
        }

        void LoadPhieuLai(int MaHoaDonCam)
        {
            LVPhieuLai.Items.Clear();
            List<PhieuLaiDTO> list = PhieuLaiDAO.Instance.LoadListPhieuLai(MaHoaDonCam);
            foreach (PhieuLaiDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.MaPhieuLai.ToString());
                lvitem.SubItems.Add(item.TenKH.ToString());
                lvitem.SubItems.Add(item.NgayDongLai.ToString());
                lvitem.SubItems.Add(item.TongTien.ToString());
                LVPhieuLai.Items.Add(lvitem);
            }
        }


        private void LVHDC_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection lvv = this.LVHDC.SelectedItems;
            int id = 0;
            foreach (ListViewItem item in lvv)
            {
                id += Int32.Parse(item.SubItems[0].Text);
            }
            txtMaHDC.Text = id.ToString();
            int MaHoaDonCam = int.Parse(txtMaHDC.Text);
            LoadCTHoaDonCam(MaHoaDonCam);
        }

        private void LvPhieuChuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection lv = this.LvPhieuChuoc.SelectedItems;
            int maphieuchuoc = 0;
            foreach (ListViewItem item in lv)
            {
                maphieuchuoc += Int32.Parse(item.SubItems[0].Text);
            }
            txtMaPhieuChuoc.Text = maphieuchuoc.ToString();
            int MaPhieuChuoc = int.Parse(txtMaPhieuChuoc.Text);
            LoadCTPhieuChuoc(MaPhieuChuoc);
        }

        private void LVThanhLy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection lv = this.LVThanhLy.SelectedItems;
            int mathanhly = 0;
            foreach (ListViewItem item in lv)
            {
                mathanhly += Int32.Parse(item.SubItems[0].Text);
            }
            txtMaThanhLy.Text = mathanhly.ToString();
            int MaThanhLy = (int)Convert.ToInt32(txtMaThanhLy.Text);
            LoadCTThanhLy(MaThanhLy);
        }

        private void LVPhieuCam_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection lv = this.LVPhieuCam.SelectedItems;
            int mahoadoncam = 0;
            foreach (ListViewItem item in lv)
            {
                mahoadoncam += Int32.Parse(item.SubItems[0].Text);
            }
            txtMaHDC.Text = mahoadoncam.ToString();
            int MaHDC = (int)Convert.ToInt32(txtMaHDC.Text);
            LoadPhieuLai(MaHDC);
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            string filePath = "";
            // tạo SaveFileDialog để lưu file excel
            SaveFileDialog dialog = new SaveFileDialog();

            // chỉ lọc ra các file có định dạng Excel
            dialog.Filter = "Excel Workbook|*.xls";

            // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePath = dialog.FileName;
            }

            // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                return;
            }

            try
            {
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                using (ExcelPackage p = new ExcelPackage())
                {
                    // đặt tên người tạo file
                    p.Workbook.Properties.Author = "NhiAn";

                    // đặt tiêu đề cho file
                    p.Workbook.Properties.Title = "Báo cáo";

                    //Tạo một sheet để làm việc trên đó
                    p.Workbook.Worksheets.Add("NhiAn");

                    // lấy sheet vừa add ra để thao tác
                    ExcelWorksheet ws = p.Workbook.Worksheets[0];

                    // đặt tên cho sheet
                    ws.Name = "NhiAn";
                    // fontsize mặc định cho cả sheet
                    ws.Cells.Style.Font.Size = 13;
                    // font family mặc định cho cả sheet
                    ws.Cells.Style.Font.Name = "Calibri";

                    // Tạo danh sách các column header
                    string[] arrColumnHeader = {
                                                "Mã hóa đơn",
                                                "Tên khách hàng",
                                                "Ngày cầm",
                                                "Ngày hết hạn",
                                                "Mã sản phẩm",
                                                "Tên loại",
                                                "Tên sản phẩm",
                                                "Định giá",
                                                "Mô tả",
                                                "Màu sắc",
                                                "Hiện trạng"
                };

                    // lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader = arrColumnHeader.Count();

                    // merge các column lại từ column 1 đến số column header
                    // gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                    ws.Cells[1, 1].Value = "Thống kê thông tin cầm đồ";
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    // in đậm
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    // căn giữa
                    ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    int colIndex = 1;
                    int rowIndex = 2;

                    //tạo các header từ column header đã tạo từ bên trên
                    foreach (var item in arrColumnHeader)
                    {
                        var cell = ws.Cells[rowIndex, colIndex];

                        //set màu thành gray
                        var fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                        //căn chỉnh các border
                        var border = cell.Style.Border;
                        border.Bottom.Style =
                            border.Top.Style =
                            border.Left.Style =
                            border.Right.Style = ExcelBorderStyle.Thin;

                        //gán giá trị
                        cell.Value = item;

                        colIndex++;
                    }

                    // lấy ra danh sách UserInfo từ ItemSource của DataGrid
                    List<BaoCaoCamDTO> ListBBC = BaoCaoCamDAO.Instance.LoadListBaoCaoCam();
                    double? tongtien = 0;
                    // với mỗi item trong danh sách sẽ ghi trên 1 dòng
                    foreach (var item in ListBBC)
                    {
                        // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                        colIndex = 1;

                        // rowIndex tương ứng từng dòng dữ liệu
                        rowIndex++;

                        //gán giá trị cho từng cell                      
                        ws.Cells[rowIndex, colIndex++].Value = item.MaHoaDonCam;
                        ws.Cells[rowIndex, colIndex++].Value = item.TenKH;
                        ws.Cells[rowIndex, colIndex++].Value = item.NgayLap.ToShortDateString();
                        ws.Cells[rowIndex, colIndex++].Value = item.NgayHetHan.ToShortDateString();
                        ws.Cells[rowIndex, colIndex++].Value = item.MaSP;
                        ws.Cells[rowIndex, colIndex++].Value = item.TenLoai;
                        ws.Cells[rowIndex, colIndex++].Value = item.TenSP;
                        ws.Cells[rowIndex, colIndex++].Value = item.DinhGia;
                        ws.Cells[rowIndex, colIndex++].Value = item.MoTa;
                        ws.Cells[rowIndex, colIndex++].Value = item.MauSac; 
                        ws.Cells[rowIndex, colIndex++].Value = item.HienTrang;
                        tongtien = tongtien + item.DinhGia;
                        // lưu ý phải .ToShortDateString để dữ liệu khi in ra Excel là ngày như ta vẫn thấy.Nếu không sẽ ra tổng số :v


                    }
                    ws.Cells[rowIndex + 1, 8, rowIndex + 1, countColHeader].Merge = true;
                    ws.Cells[rowIndex + 1, 8].Value = "Tổng tiền cầm: " + tongtien;
                    //Lưu file lại
                    Byte[] bin = p.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                }
                MessageBox.Show("Xuất excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi luôn, mà chưa biết lỗi gì");
            }
        }
    }
}
