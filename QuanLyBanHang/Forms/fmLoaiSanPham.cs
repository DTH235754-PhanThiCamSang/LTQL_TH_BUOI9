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

namespace QuanLyBanHang.Forms
{
    public partial class fmLoaiSanPham : Form
    {
        public fmLoaiSanPham()
        {
            InitializeComponent();
        }
        QLBHDbContext context = new QLBHDbContext(); //Khởi tạo biến ngữ cảnh CSDL
        bool xuLyThem = false; // kiểm tra có nhấn vao nút Thêm hay không?
        int id; // Lấy mã loại sản phẩm (dùng cho sửa và xóa)

        private void BatTatChucNang(bool giaTri)
        {
            txtTenLoai.Enabled = giaTri;
            btnLuu.Enabled = giaTri;
            btnHuybo.Enabled = giaTri;
            lable.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }
        private void fmLoaiSanPham_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);

            List<LoaiSanPham> lsp = new List<LoaiSanPham>();
            lsp = context.LoaiSanPhams.ToList();

            BindingSource bingdingSource = new BindingSource();
            bindingSource.DataSource = lsp;

            txtTenLoai.DataBindings.Clear();
            txtTenLoai.DataBindings.Add("Text", bindingSource, "TenLoai", false, DataSourceUpdateMode.Never);
            dataGridView.DataSource = bindingSource;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtTenLoai.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            //if (dr == DialogResult.Yes)
            //{
            //    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            //    {
            //        // Lấy ID của từng dòng trong danh sách đang chọn
            //        int id = Convert.ToInt32(row.Cells["ID"].Value);

            //        // Tìm và xóa trong Database
            //        var sp = context.SanPhams.Find(id);
            //        if (sp != null)
            //        {
            //            context.SanPhams.Remove(sp);
            //        }
            //    }

            //    // 3. Lưu thay đổi vào DB một lần duy nhất sau khi chạy xong vòng lặp
            //    context.SaveChanges();

            //    // Load lại dữ liệu lên bảng
            //    fmSanPham_Load(sender, e);



            if (MessageBox.Show("Xác nhận xóa loại sản phẩm", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    // Lấy ID của từng dòng trong danh sách đang chọn
                    id = Convert.ToInt32(row.Cells["ID"].Value);

                    // Tìm và xóa trong Database
                    LoaiSanPham? lsp = context.LoaiSanPhams.Find(id);
                    if (lsp != null)
                    {
                        context.LoaiSanPhams.Remove(lsp);
                    }
                }
                //id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                //LoaiSanPham? lsp = context.LoaiSanPhams.Find(id);
                //if (lsp != null)
                //{
                //    context.LoaiSanPhams.Remove(lsp);
                //}
                context.SaveChanges();

                fmLoaiSanPham_Load(sender, e);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
                MessageBox.Show("Vui lòng nhập tên loại sản phẩm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (xuLyThem)
                {
                    LoaiSanPham lsp = new LoaiSanPham();
                    lsp.TenLoai = txtTenLoai.Text;
                    context.LoaiSanPhams.Add(lsp);
                    context.SaveChanges();
                }
                else
                {
                    LoaiSanPham? lsp = context.LoaiSanPhams.Find(id);
                    if (lsp != null)
                    {
                        lsp.TenLoai = txtTenLoai.Text;
                        context.LoaiSanPhams.Update(lsp);
                        context.SaveChanges();
                    }
                }
                fmLoaiSanPham_Load(sender, e);

            }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            fmLoaiSanPham_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
                                LoaiSanPham lsp = new LoaiSanPham();
                                lsp.TenLoai = r["TenLoai"].ToString();
                                context.LoaiSanPhams.Add(lsp);
                            }
                            context.SaveChanges();
                            MessageBox.Show("Đã nhập dữ liệu thành công" + table.Rows.Count + "dòng", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fmLoaiSanPham_Load(sender, e);
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
            saveFileDialog.FileName = "LoaiSanPham_" + DateTime.Now.ToString("yyyyMMdd_HHmmss").Replace("-", "_") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[2]
                    {
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("TenLoai", typeof (string))
                    });

                    var loaiSanPhams = context.LoaiSanPhams.ToList();
                    if (loaiSanPhams != null)
                    {
                        foreach (var p in loaiSanPhams)
                            table.Rows.Add(p.ID, p.TenLoai);
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "LoaiSanPham");
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

