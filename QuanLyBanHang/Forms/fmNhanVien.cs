using ClosedXML.Excel;
using QuanLyBanHang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BC = BCrypt.Net.BCrypt;


namespace QuanLyBanHang.Forms
{
    public partial class fmNhanVien : Form
    {
        public fmNhanVien()
        {
            InitializeComponent();
        }

        QLBHDbContext context = new QLBHDbContext();
        bool xuLyThem = false;
        bool dangTimKiem = false;
        int id;


        private void BatTatChucNang(bool giaTri)
        {

            btnLuu.Enabled = giaTri;
            btnHuybo.Enabled = giaTri;
            txthovaten.Enabled = giaTri;
            txtdienthoai.Enabled = giaTri;
            txtdiachi.Enabled = giaTri;
            cobquyenhan.Enabled = giaTri;
            txtmatkhau.Enabled = giaTri;
            txtTenDN.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnTimkiem.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;

        }






        private void fmNhanVien_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            dataGridView.AutoGenerateColumns = false;

            List<NhanVien> nv = new List<NhanVien>();
            nv = context.NhanViens.ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = nv;

            txthovaten.DataBindings.Clear();
            txthovaten.DataBindings.Add("Text", bindingSource, "HoVaTen", false, DataSourceUpdateMode.Never);
            txtdienthoai.DataBindings.Clear();
            txtdienthoai.DataBindings.Add("Text", bindingSource, "DienThoai", false, DataSourceUpdateMode.Never);
            txtdiachi.DataBindings.Clear();
            txtdiachi.DataBindings.Add("Text", bindingSource, "DiaChi", false, DataSourceUpdateMode.Never);
            txtTenDN.DataBindings.Clear();
            txtTenDN.DataBindings.Add("Text", bindingSource, "TenDangNhap", false, DataSourceUpdateMode.Never);
            txtmatkhau.DataBindings.Clear();
            txtmatkhau.DataBindings.Add("Text", bindingSource, "MatKhau", false, DataSourceUpdateMode.Never);
            cobquyenhan.DataBindings.Clear();
            cobquyenhan.DataBindings.Add("SelectedIndex", bindingSource, "QuyenHan", false, DataSourceUpdateMode.Never);

            dataGridView.DataSource = bindingSource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txthovaten.Clear();
            txtdienthoai.Clear();
            txtdiachi.Clear();
            txtTenDN.Clear();
            txtmatkhau.Clear();
            cobquyenhan.SelectedIndex = -1;
            txthovaten.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["colID"].Value.ToString());

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa nhân viên " + txthovaten.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["colID"].Value.ToString());
                NhanVien? nv = context.NhanViens.Find(id);
                if (nv != null)
                {
                    context.NhanViens.Remove(nv);
                }
                context.SaveChanges();
                fmNhanVien_Load(sender, e);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sdt = txtdienthoai.Text.Trim();

            if (string.IsNullOrWhiteSpace(txthovaten.Text))
                MessageBox.Show("Vui lòng nhập họ và tên nhân viên?");
            else if (string.IsNullOrWhiteSpace(txtTenDN.Text))
                MessageBox.Show("Vui lòng nhập tên đăng nhập nhân viên");
            else if (string.IsNullOrWhiteSpace(cobquyenhan.Text))
                MessageBox.Show("Vui lòng chọn quyền hạn nhân viên");
            else if (
                sdt.Length != 10 || !sdt.StartsWith("0") || !sdt.All(char.IsDigit))
            {
                MessageBox.Show("Vui lòng nhập lại số diện thọai nhân viên?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdienthoai.Focus();
            }


            else
            {
                if (xuLyThem)
                {
                    if (string.IsNullOrWhiteSpace(txtmatkhau.Text))
                        MessageBox.Show("Vui lòng nhập mật khẩu nhân viên");
                    else
                    {
                        NhanVien nv = new NhanVien();
                        nv.HoVaTen = txthovaten.Text;
                        nv.DienThoai = sdt;
                        nv.DiaChi = txtdiachi.Text;
                        nv.TenDangNhap = txtTenDN.Text;
                        nv.MatKhau = BC.HashPassword(txtmatkhau.Text);
                        nv.QuyenHan = cobquyenhan.SelectedIndex == 0 ? true : false;

                        context.NhanViens.Add(nv);
                        context.SaveChanges();
                    }
                }
                else
                {
                    NhanVien? nv = context.NhanViens.Find(id);
                    if (nv != null)
                    {
                        nv.HoVaTen = txthovaten.Text;
                        nv.DienThoai = sdt;
                        nv.DiaChi = txtdiachi.Text;
                        nv.TenDangNhap = txtTenDN.Text;
                        nv.MatKhau = txtmatkhau.Text;
                        nv.QuyenHan = cobquyenhan.SelectedIndex == 0 ? true : false;
                        context.Update(nv);

                        if (string.IsNullOrWhiteSpace(txtmatkhau.Text))
                            context.Entry(nv).Property(x => x.MatKhau).IsModified = false;// Giữ nguyên mật khẩu cũ
                        else
                            nv.MatKhau = BC.HashPassword(txtmatkhau.Text);// Cập nhật mật khẩu mới

                        context.SaveChanges();
                    }
                }
                fmNhanVien_Load(sender, e);
            }

        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            dangTimKiem = false;
            btnTimkiem.Text = "Tìm Kiếm";
            fmNhanVien_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            // TRƯỜNG HỢP 1: BẤM LẦN ĐẦU (ĐỂ BẬT CHẾ ĐỘ NHẬP LIỆU)
            if (dangTimKiem == false)
            {
                dangTimKiem = true; // Đánh dấu là đang trong chế độ tìm

                // 1. Bật các ô nhập liệu lên 
                BatTatChucNang(true);
                txtdiachi.Enabled = false;

                txtmatkhau.Enabled = false;
                txtTenDN.Enabled = false;
                cobquyenhan.Enabled = false;
                btnTimkiem.Enabled = true;


                // 2. Nhưng KHÔNG cho bấm nút Lưu (để tránh lưu nhầm khi đang tìm)
                btnLuu.Enabled = false;

                // 3. Xóa trắng các ô để chuẩn bị nhập từ khóa mới
                txthovaten.Clear();
                txtdienthoai.Clear();
                txtdiachi.Clear();
                txtTenDN.Clear();
                txtmatkhau.Clear();
                cobquyenhan.SelectedIndex = -1;
                txthovaten.Focus();

                // 4. Đổi tên nút để người dùng biết bấm phát nữa là chạy
                btnTimkiem.Text = "Tìm ngay";
                MessageBox.Show("Hãy nhập thông tin cần tìm rồi bấm nút 'Tìm ngay' lần nữa!");
            }
            // TRƯỜNG HỢP 2: BẤM LẦN 2 (THỰC HIỆN TÌM KIẾM)
            else
            {
                // Code tìm kiếm giống bài trước
                var query = context.NhanViens.AsQueryable();

                // Lọc theo Tên (nếu có nhập)
                if (!string.IsNullOrWhiteSpace(txthovaten.Text))
                    query = query.Where(x => x.HoVaTen.Contains(txthovaten.Text));

                if (!string.IsNullOrWhiteSpace(txtdienthoai.Text))
                    query = query.Where(x => x.DienThoai.Contains(txtdienthoai.Text));
                // Lọc theo Loại (nếu có chọn)

                //// Lọc theo Loại (nếu có chọn)
                //if (cobquyenhan.SelectedIndex != -1)
                //{
                //    // Logic giống hệt nút Lưu của bạn:
                //    // Nếu chọn dòng đầu tiên (Index 0) -> Là Quản trị (True)
                //    // Nếu chọn dòng thứ hai (Index 1) -> Là Nhân viên (False)
                //    bool quyenHanCanTim = (cobquyenhan.SelectedIndex == 0);

                //    // So sánh trực tiếp với True/False
                //    query = query.Where(x => x.QuyenHan == quyenHanCanTim);
                //}
                // Đổ dữ liệu ra bảng
                var ketQua = query.Select(r => new NhanVien
                {
                    ID = r.ID,
                    //NhanVienID = r.ID,
                    HoVaTen = r.HoVaTen,
                    DienThoai = r.DienThoai,
                    DiaChi = r.DiaChi,
                    TenDangNhap = r.TenDangNhap,
                    MatKhau = r.MatKhau,
                    QuyenHan = r.QuyenHan,

                }).ToList();

                if (ketQua.Count > 0)
                {
                    dataGridView.DataSource = ketQua;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!");
                }

                // (Tùy chọn) Nếu muốn tìm xong thì quay về trạng thái bình thường ngay thì mở dòng dưới:
                // dangTimKiem = false; btnTimKiem.Text = "Tìm kiếm";
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra xem có phải đang vẽ cột "QuyenHan" không
            // (Bạn nhớ kiểm tra xem trong Designer cột đó DataPropertyName là "QuyenHan" chưa nhé)
            if (dataGridView.Columns[e.ColumnIndex].DataPropertyName == "QuyenHan")
            {
                if (e.Value != null)
                {
                    // Lấy giá trị True/False ra
                    // Lưu ý: Nếu DB lưu bit thì nó là bool, nếu lưu int thì sửa thành (int)e.Value
                    if (e.Value is bool)
                    {
                        bool quyen = (bool)e.Value;
                        // Nếu True -> Quản trị, False -> Nhân viên
                        e.Value = quyen ? "Quản lý" : "Nhân viên";
                        e.FormattingApplied = true; // Báo cho máy biết là "Tao đã sửa xong rồi"
                    }
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
                                NhanVien nv = new NhanVien();
                                nv.HoVaTen = r["HoVaTen"].ToString();
                                nv.DienThoai = r["DienThoai"].ToString();
                                nv.DiaChi = r["DiaChi"].ToString();
                                nv.TenDangNhap = r["TenDangNhap"].ToString();
                                nv.MatKhau = r["MatKhau"].ToString();
                                nv.QuyenHan = r["QuyenHan"].ToString().ToLower() == "quản lý" ? true : false;
                                context.NhanViens.Add(nv);
                            }
                            context.SaveChanges();
                            MessageBox.Show("Đã nhập dữ liệu thành công" + table.Rows.Count + "dòng", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fmNhanVien_Load(sender, e);
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

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu ra tập tin Excel";
            saveFileDialog.Filter = "Tập tin Excel |*.xls;*.xlsx";
            saveFileDialog.FileName = "Nhanvien_" + DateTime.Now.ToString("yyyyMMdd_HHmmss").Replace("-", "_") + ".xlsx";


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[7]
                    {
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("HoVaTen", typeof (string)),
                        new DataColumn("DienThoai", typeof (string)),
                        new DataColumn("DiaChi", typeof (string)),
                        new DataColumn("TenDangNhap", typeof (string)),
                        new DataColumn("MatKhau", typeof (string)),
                        new DataColumn("QuyenHan", typeof (string)),
                    });

                    var NhanVien = context.NhanViens.ToList();
                    if (NhanVien != null)
                    {
                        foreach (var p in NhanVien)
                            table.Rows.Add(p.ID, p.HoVaTen, p.DienThoai, p.DiaChi, p.TenDangNhap, p.MatKhau, p.QuyenHan);
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "NhanVien");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);

                        MessageBox.Show("Đã xuất dữ liệu thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
    


}
