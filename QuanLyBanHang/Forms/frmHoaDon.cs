using ClosedXML.Excel;
using QuanLyBanHang.Data;
using QuanLyBanHang.Forms;
using QuanLyBanHang.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QuanLyBanHang.Forms
{
    public partial class frmHoaDon : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        int id;
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            dataGridView.AutoGenerateColumns = false;

            List<DanhSachHoaDon> hd = new List<DanhSachHoaDon>();
            hd = context.HoaDon.Select(r => new DanhSachHoaDon
            {
                ID = r.ID,
                NhanVienID = r.NhanVienID,
                HoVaTenNhanVien = r.NhanVien.HoVaTen,
                KhachHangID = r.KhachHangID,
                HoVaTenKhachHang = r.KhachHang.HoVaTen,
                NgayLap = r.NgayLap,
                GhiChuHoaDon = r.GhiChuHoaDon,
                TongTienHoaDon = r.HoaDon_ChiTiet.Sum(r => r.SoLuongBan * r.DonGiaBan),
                XemChiTiet = "Xem Chi Tiết"
            }).ToList();

            dataGridView.DataSource = hd;

        }

        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet())
            {
                chiTiet.ShowDialog();
                frmHoaDon_Load(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet(id))
            {
                chiTiet.ShowDialog();
                frmHoaDon_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa loại sản phẩm", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    // Lấy ID của từng dòng trong danh sách đang chọn
                    id = Convert.ToInt32(row.Cells["ID"].Value);

                    // Tìm và xóa trong Database
                    HoaDon? hd = context.HoaDon.Find(id);
                    if (hd != null)
                    {
                        context.HoaDon.Remove(hd);
                    }
                }

                context.SaveChanges();

                frmHoaDon_Load(sender, e);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có click vào đúng dòng dữ liệu (RowIndex >= 0) 
            // và click trúng cái cột có tên là "XemChiTiet" hay không
            if (e.RowIndex >= 0 && dataGridView.Columns[e.ColumnIndex].Name == "XemChiTiet")
            {
                // Lấy mã ID của cái hóa đơn ở dòng vừa click
                int idHoaDon = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["ID"].Value);

                // Mở Form Chi Tiết lên và nhét cái ID đó vào
                using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet(idHoaDon))
                {
                    chiTiet.ShowDialog();

                    // Load lại DataGridView sau khi xem/sửa xong và đóng Form
                    frmHoaDon_Load(sender, e);
                }
            }

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại nhập liệu
            string keyword = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên khách hàng hoặc nhân viên cần tìm:", "Tìm kiếm hóa đơn", "");

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                // Lọc dữ liệu từ Database dựa trên từ khóa
                var ketQua = context.HoaDon.Where(r => r.KhachHang.HoVaTen.Contains(keyword) ||
                                                      r.NhanVien.HoVaTen.Contains(keyword))
                                           .Select(r => new DanhSachHoaDon
                                           {
                                               ID = r.ID,
                                               NhanVienID = r.NhanVienID,
                                               HoVaTenNhanVien = r.NhanVien.HoVaTen,
                                               KhachHangID = r.KhachHangID,
                                               HoVaTenKhachHang = r.KhachHang.HoVaTen,
                                               NgayLap = r.NgayLap,
                                               GhiChuHoaDon = r.GhiChuHoaDon,
                                               TongTienHoaDon = r.HoaDon_ChiTiet.Sum(ct => ct.SoLuongBan * ct.DonGiaBan),
                                               XemChiTiet = "Xem Chi Tiết"
                                           }).ToList();

                // Hiển thị kết quả lên lưới
                dataGridView.DataSource = ketQua;

                if (ketQua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào khớp với: " + keyword, "Thông báo");
                    // Load lại toàn bộ nếu không tìm thấy (tùy chọn)
                    frmHoaDon_Load(sender, e);
                }
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            frmHoaDon_Load(sender, e);
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu Hóa đơn ra Excel";
            saveFileDialog.Filter = "Tập tin Excel (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "HoaDon_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        // --- SHEET 1: HÓA ĐƠN ---
                        DataTable tableHD = new DataTable();
                        tableHD.Columns.Add("ID", typeof(int));
                        tableHD.Columns.Add("Nhân Viên", typeof(string));
                        tableHD.Columns.Add("Khách Hàng", typeof(string));
                        tableHD.Columns.Add("Ngày Lập", typeof(DateTime));
                        tableHD.Columns.Add("Ghi Chú", typeof(string));

                        // Truy vấn Join để lấy tên
                        var dsHD = (from hd in context.HoaDon
                                    join nv in context.NhanViens on hd.NhanVienID equals nv.ID
                                    join kh in context.KhachHang on hd.KhachHangID equals kh.ID
                                    select new
                                    {
                                        hd.ID,
                                        TenNV = nv.HoVaTen, // Lấy cột HoVaTen từ bảng NhanVien
                                        TenKH = kh.HoVaTen, // Lấy cột HoVaTen từ bảng KhachHang
                                        hd.NgayLap,
                                        hd.GhiChuHoaDon
                                    }).ToList();

                        foreach (var h in dsHD)
                        {
                            tableHD.Rows.Add(h.ID, h.TenNV, h.TenKH, h.NgayLap, h.GhiChuHoaDon);
                        }
                        wb.Worksheets.Add(tableHD, "HoaDon");

                        // --- SHEET 2: CHI TIẾT HÓA ĐƠN ---
                        DataTable tableCT = new DataTable();
                        tableCT.Columns.Add("ID", typeof(int));
                        tableCT.Columns.Add("Mã Hóa Đơn", typeof(int));
                        tableCT.Columns.Add("Mã Sản Phẩm", typeof(int));
                        tableCT.Columns.Add("Số Lượng", typeof(int)); // DataTable để int
                        tableCT.Columns.Add("Đơn Giá", typeof(int));

                        var dsCT = context.HoaDon_ChiTiet.ToList();
                        foreach (var c in dsCT)
                        {
                            tableCT.Rows.Add(
                                c.ID,
                                c.HoaDonID,
                                c.SanPhamID,
                                c.SoLuongBan, // ÉP KIỂU TỪ SMALLINT SANG INT Ở ĐÂY
                                c.DonGiaBan
                            );
                        }
                        wb.Worksheets.Add(tableCT, "ChiTiet");

                        // Căn chỉnh độ rộng cột
                        foreach (var ws in wb.Worksheets) { ws.Columns().AdjustToContents(); }

                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Đã xuất dữ liệu 2 sheet thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Nhập dữ liệu từ tap tin Excel";
            openFileDialog.Filter = "Tập tin Excel |*.xls;*.xlsx";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    using (XLWorkbook workbook = new XLWorkbook(openFileDialog.FileName))
                    {
                        IXLWorksheet worksheet = workbook.Worksheet(1);
                        bool firstRow = true;
                        string readRange = "1:1";
                        foreach (IXLRow row in worksheet.RowsUsed())
                        {
                            //đọc dòng tiêu đề (dòng đầu)
                            if (firstRow)
                            {
                                readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                                foreach (IXLCell cell in row.Cells((readRange)))
                                    table.Columns.Add(cell.Value.ToString());
                                firstRow = false;
                            }
                            else // đọc các dòng nd (các dòng tiếp theo)
                            {
                                table.Rows.Add();
                                int cellIndex = 0;

                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    table.Rows[table.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                    cellIndex++;
                                }

                            }
                        }
                        if (table.Rows.Count > 0)
                        {
                            foreach (DataRow r in table.Rows)
                            {
                                HoaDon hd = new HoaDon();
                                hd.NhanVienID = Convert.ToInt32(r["NhanVienID"]);
                                hd.KhachHangID = Convert.ToInt32(r["KhachHangID"]);
                                hd.NgayLap = Convert.ToDateTime(r["NgayLap"]);
                                hd.GhiChuHoaDon = r["GhiChuHoaDon"].ToString();
                                context.HoaDon.Add(hd);
                            }
                            context.SaveChanges();
                            MessageBox.Show("Đã nhập dữ liệu thành công" + table.Rows.Count + "dòng", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmHoaDon_Load(sender, e);
                        }
                        if (firstRow)
                            MessageBox.Show("Tập tin Excel rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            using (frmInHoaDon inHoaDon = new frmInHoaDon(id))
            {
                inHoaDon.ShowDialog();
            }
        }
    }

}

