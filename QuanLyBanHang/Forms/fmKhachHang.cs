using ClosedXML.Excel;
using QuanLyBanHang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.Forms
{
    public partial class fmKhachHang : Form
    {
        public fmKhachHang()
        {
            InitializeComponent();
        }
        QLBHDbContext context = new QLBHDbContext();
        bool xuLyThem = false;
        int id;

        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuybo.Enabled = giaTri;
            txthovaten.Enabled = giaTri;
            txtdienthoai.Enabled = giaTri;
            txtdiachi.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
        }


        private void fmKhachHang_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            List<KhachHang> kh = new List<KhachHang>();
            kh = context.KhachHang.ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = kh;

            txthovaten.DataBindings.Clear();
            txthovaten.DataBindings.Add("Text", bindingSource, "HoVaTen", false, DataSourceUpdateMode.Never);
            txtdienthoai.DataBindings.Clear();
            txtdienthoai.DataBindings.Add("Text", bindingSource, "DienThoai", false, DataSourceUpdateMode.Never);
            txtdiachi.DataBindings.Clear();
            txtdiachi.DataBindings.Add("Text", bindingSource, "DiaChi", false, DataSourceUpdateMode.Never);

            dataGridView.DataSource = bindingSource;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            txthovaten.Clear();
            txtdienthoai.Clear();
            txtdiachi.Clear();
            txthovaten.Focus();
            BatTatChucNang(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["cotID"].Value);

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa khách hàng" + txthovaten.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["cotID"].Value);
                KhachHang? kh = context.KhachHang.Find(id);
                if (kh != null)
                {
                    context.KhachHang.Remove(kh);
                }
                context.SaveChanges();
                fmKhachHang_Load(sender, e);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sdt = txtdienthoai.Text.Trim();
            if (string.IsNullOrWhiteSpace(txthovaten.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên khách hàng?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txthovaten.Focus();
                return;
            }

            // - !sdt.All(char.IsDigit): Kiểm tra có chứa ký tự không phải số
            if (sdt.Length != 10 || !sdt.StartsWith("0") || !sdt.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải là 10 số, bắt đầu từ 0 và không chứa chữ cái!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdienthoai.Focus();
                return;
            }
            else
            {
                if (xuLyThem)
                {
                    KhachHang kh = new KhachHang();
                    kh.HoVaTen = txthovaten.Text;
                    kh.DienThoai = sdt;
                    kh.DiaChi = txtdiachi.Text;

                    context.KhachHang.Add(kh);

                    context.SaveChanges();
                }
                else
                {
                    KhachHang? kh = context.KhachHang.Find(id);
                    if (kh != null)
                    {
                        kh.HoVaTen = txthovaten.Text;
                        kh.DienThoai = sdt;
                        kh.DiaChi = txtdiachi.Text;
                        context.KhachHang.Update(kh);
                        context.SaveChanges();
                    }
                }
                fmKhachHang_Load(sender, e);

            }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            fmKhachHang_Load(sender, e);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            BatTatChucNang(true);
            btnLuu.Enabled = false;
            txtdiachi.Enabled = false;
            string timten = txthovaten.Text.Trim();
            string timsdt = txtdienthoai.Text.Trim();
            if (timten == "" && timsdt == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // 3. Thực hiện truy vấn tìm kiếm

            var ketQua = context.KhachHang
        .Where(kh =>
            (kh.HoVaTen != null && kh.HoVaTen.Contains(timten)) ||
            (kh.DienThoai != null && kh.DienThoai.Contains(timsdt))
        )
        .ToList();

            // 4. Hiển thị kết quả lên DataGridView
            // Tạo BindingSource mới để không ảnh hưởng đến luồng dữ liệu cũ hoặc dùng lại cái cũ tùy logic
            BindingSource bindingSourceSearch = new BindingSource();
            bindingSourceSearch.DataSource = ketQua;

            // Gán lại nguồn dữ liệu
            dataGridView.DataSource = bindingSourceSearch;

            // 5.  Xóa binding cũ của các textbox để tránh lỗi binding nếu danh sách thay đổi đột ngột
            txthovaten.DataBindings.Clear();
            txtdienthoai.DataBindings.Clear();
            txtdiachi.DataBindings.Clear();

            // Bind lại dữ liệu theo danh sách tìm được (để khi click vào dòng trong grid, textbox nhảy theo)
            txthovaten.DataBindings.Add("Text", bindingSourceSearch, "HoVaTen", false, DataSourceUpdateMode.Never);
            txtdienthoai.DataBindings.Add("Text", bindingSourceSearch, "DienThoai", false, DataSourceUpdateMode.Never);
            txtdiachi.DataBindings.Add("Text", bindingSourceSearch, "DiaChi", false, DataSourceUpdateMode.Never);
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

                                KhachHang kh = new KhachHang();
                                kh.HoVaTen = r["HoVaTen"].ToString();
                                kh.DienThoai = r["DienThoai"].ToString();
                                kh.DiaChi = r["DiaChi"].ToString();
                                context.KhachHang.Add(kh);
                            }
                            context.SaveChanges();
                            MessageBox.Show("Đã nhập dữ liệu thành công" + table.Rows.Count + "dòng", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fmKhachHang_Load(sender, e);
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
            saveFileDialog.FileName = "KhangHang_" + DateTime.Now.ToString("yyyyMMdd_HHmmss").Replace("-", "_") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[4]
                    {
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("HoVaTen", typeof(string)),
                        new DataColumn("DienThoai", typeof(string)),
                        new DataColumn("DiaChi", typeof(string))
                    
                     });

                    var KhachHang = context.KhachHang.ToList();
                    if (KhachHang != null)
                    {
                        foreach (var p in KhachHang)
                            table.Rows.Add(p.ID, p.HoVaTen, p.DienThoai, p.DiaChi);
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "KhachHang");
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

