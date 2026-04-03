using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using QuanLyBanHang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;


namespace QuanLyBanHang.Forms
{
    public partial class fmSanPham : Form
    {
        QLBHDbContext context = new();  // Khởi tạo biến ngữ cảnh CSDL
        bool xuLyThem = false;  // Kiểm tra có nhấn vào nút Thêm hay không?
        bool dangTimKiem = false;
        int id;  // Lấy mã sản phẩm (dùng cho Sửa và Xóa)
        string imagesFolder = Path.Combine(Application.StartupPath, "Images");
        //string imagesFolder = Application.StartupPath.Replace("bin\\Debug\\net5.0-windows", "Images");
        public fmSanPham()
        {
            InitializeComponent();
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuybo.Enabled = giaTri;
            cobHSX.Enabled = giaTri;
            cobPL.Enabled = giaTri;
            txtTSP.Enabled = giaTri;
            numSL.Enabled = giaTri;
            numDG.Enabled = giaTri;
            txtMT.Enabled = giaTri;
            picHinhAnh.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnDoiAnh.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnTimKiem.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
        }
        public void LayLoaiSanPhamVaoComboBox()
        {
            cobPL.DataSource = context.LoaiSanPhams.ToList();
            cobPL.ValueMember = "ID";
            cobPL.DisplayMember = "TenLoai";
        }
        public void LayHangSanXuatVaoComboBox()
        {
            cobHSX.DataSource = context.HangSanXuat.ToList();
            cobHSX.ValueMember = "ID";
            cobHSX.DisplayMember = "TenHangSanXuat";
        }


        private void fmSanPham_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LayLoaiSanPhamVaoComboBox();
            LayHangSanXuatVaoComboBox();
            dataGridView1.AutoGenerateColumns = false;
            List<DanhSachSanPham> sp = new List<DanhSachSanPham>();
            sp = context.SanPhams.Select(r => new DanhSachSanPham
            {
                ID = r.ID,
                LoaiSanPhamID = r.LoaiSanPhamID,
                TenLoai = r.LoaiSanPhams.TenLoai,
                HangSanXuatID = r.HangSanXuatID,
                TenHangSanXuat = r.HangSanXuat.TenHangSanXuat,
                TenSanPham = r.TenSanPham,
                SoLuong = r.SoLuong,
                DonGia = r.DonGia,
                HinhAnh = r.HinhAnh
            }).ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = sp;

            cobPL.DataBindings.Clear();
            cobPL.DataBindings.Add("SelectedValue", bindingSource, "LoaiSanPhamID", false, DataSourceUpdateMode.Never);

            cobHSX.DataBindings.Clear();
            cobHSX.DataBindings.Add("SelectedValue", bindingSource, "HangSanXuatID", false, DataSourceUpdateMode.Never);

            txtTSP.DataBindings.Clear();
            txtTSP.DataBindings.Add("Text", bindingSource, "TenSanPham", false, DataSourceUpdateMode.Never);

            txtMT.DataBindings.Clear();
            txtMT.DataBindings.Add("Text", bindingSource, "MoTa", false, DataSourceUpdateMode.Never);
            numSL.DataBindings.Clear();
            numSL.DataBindings.Add("Value", bindingSource, "SoLuong", false, DataSourceUpdateMode.Never);
            numDG.DataBindings.Clear();
            numDG.DataBindings.Add("Value", bindingSource, "DonGia", false, DataSourceUpdateMode.Never);
            picHinhAnh.DataBindings.Clear();
            Binding hinhAnh = new Binding("ImageLocation", bindingSource, "HinhAnh");
            hinhAnh.Format += (s, e) =>
            {
                e.Value = Path.Combine(imagesFolder, e.Value?.ToString() ?? "no-image.png");
            };
            picHinhAnh.DataBindings.Add(hinhAnh);
            dataGridView1.DataSource = bindingSource;
        }


        private void dataGridView1_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {

            // Kiểm tra đúng cột hình ảnh và giá trị ô không được rỗng
            if (dataGridView1.Columns[e.ColumnIndex].Name == "HinhAnh" && e.Value != null && !string.IsNullOrWhiteSpace(e.Value.ToString()))
            {
                string path = Path.Combine(imagesFolder, e.Value?.ToString() ?? "no-image.png");

                // CHỈ LOAD ẢNH NẾU FILE CÓ TỒN TẠI TRÊN Ổ CỨNG
                if (File.Exists(path))
                {
                    try
                    {
                        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                        Image image = Image.FromStream(stream);
                        e.Value = new Bitmap(image, 24, 24); // Resize nhỏ để hiện trên bảng
                    }
                    catch { /* Bỏ qua nếu ảnh bị lỗi định dạng */ }
                }
                else
                {
                    // Nếu không có file, có thể hiện một icon mặc định hoặc để trống
                    e.Value = null;
                }
            }
            //if (dataGridView1.Columns[e.ColumnIndex].Name == "HinhAnh")
            //{
            //    Image image = Image.FromFile(Path.Combine(imagesFolder, e.Value.ToString()));
            //    image = new Bitmap(image, 24, 24);
            //    e.Value = image;

            //}
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            cobPL.Text = "";
            cobHSX.Text = "";
            txtTSP.Clear();
            txtMT.Clear();
            numSL.Value = 0;
            numDG.Value = 0;
            picHinhAnh.Image = null;

        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colID"].Value.ToString());
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cobPL.Text))
                MessageBox.Show("Vui lòng chọn lại sản phẩm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(cobHSX.Text))
                MessageBox.Show("Vui lòng chọn hãng sản xuất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(txtTSP.Text))
                MessageBox.Show("Vui lòng nhập tên sản phẩm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numSL.Value <= 0)
                MessageBox.Show("Sồ lượng phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numDG.Value <= 0)
                MessageBox.Show("Đơn giá sản phẩm phải lớ hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (xuLyThem)
                {
                    SanPham? sp = new SanPham();

                    //TenSanPham = txtTSP.Text;
                    //hsx.TenHangSanXuat = txtTenHangSanXuat.Text;
                    //context.HangSanXuat.Add(hsx);
                    //context.SaveChanges();
                    sp.TenSanPham = txtTSP.Text;
                    sp.LoaiSanPhamID = Convert.ToInt32(cobPL.SelectedValue);
                    sp.HangSanXuatID = Convert.ToInt32(cobHSX.SelectedValue);
                    sp.SoLuong = (int)numSL.Value;
                    sp.DonGia = (int)numDG.Value;
                    sp.MoTa = txtMT.Text;
                    sp.HinhAnh = "no-image.png";
                    context.SanPhams.Add(sp);
                    context.SaveChanges();

                    //    LoaiSanPhamID = Convert.ToInt32(cobPL.SelectedValue),
                    //    HangSanXuatID = Convert.ToInt32(cobHSX.SelectedValue),
                    //    SoLuong = (int)numSL.Value,
                    //    DonGia = (int)numDG.Value,
                    //    MoTa = txtMT.Text,
                    //    HinhAnh = "no-image.png" // Mặc định khi thêm mới
                    //};
                    //context.SanPhams.Add(sp);
                    //context.SaveChanges();

                }
                else
                {
                    SanPham? sp = context.SanPhams.Find(id);
                    if (sp != null)
                    {
                        //  sp.TenSanPham = txtTSP.Text;
                        //sp.LoaiSanPhamID = Convert.ToInt32(cobPL.SelectedValue);
                        //sp.HangSanXuatID = Convert.ToInt32(cobHSX.SelectedValue);
                        //sp.SoLuong = (int)numSL.Value;
                        //sp.DonGia = (int)numDG.Value;
                        //sp.MoTa = txtMT.Text;
                        sp.TenSanPham = txtTSP.Text;
                        sp.LoaiSanPhamID = Convert.ToInt32(cobPL.SelectedValue);
                        sp.HangSanXuatID = Convert.ToInt32(cobHSX.SelectedValue);
                        sp.SoLuong = (int)numSL.Value;
                        sp.DonGia = (int)numDG.Value;
                        sp.MoTa = txtMT.Text;
                        // sp.HinhAnh = "no-image.png";

                        context.SanPhams.Update(sp);
                        context.SaveChanges();

                    }

                }

                fmSanPham_Load(sender, e);
            }

        }





        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa sản phẩm" + txtTSP.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    // Lấy ID của từng dòng trong danh sách đang chọn
                    id = Convert.ToInt32(row.Cells["colID"].Value);

                    // Tìm và xóa trong Database
                    SanPham? sp = context.SanPhams.Find(id);
                    if (sp != null)
                    {
                        context.SanPhams.Remove(sp);
                    }
                }
                //id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colID"].Value.ToString());
                //SanPham? sp = context.SanPhams.Find(id);
                //if (sp != null)
                //{
                //    context.SanPhams.Remove(sp);
                //}
                context.SaveChanges();
                fmSanPham_Load(sender, e);

            }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            // Reset lại cờ tìm kiếm
            dangTimKiem = false;
            btnTimKiem.Text = "Tìm kiếm"; // Trả lại tên cũ cho nút
            fmSanPham_Load(sender, e);
        }

        private void btnDoiAnh_Click(object sender, EventArgs e)
        {


            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Cập nhật hình ảnh sản phẩm";
            openFileDialog.Filter = "Tập tin hình ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                string ext = Path.GetExtension(openFileDialog.FileName);
                string fileSavePath = Path.Combine(imagesFolder, fileName.GenerateSlug() + ext);
                // Kiểm tra nếu thư mục imagesFolder chưa tồn tại thì tạo mới
                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }
                File.Copy(openFileDialog.FileName, fileSavePath, true);

                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colID"].Value.ToString());
                SanPham? sp = context.SanPhams.Find(id);
                if (sp != null)
                {
                    sp.HinhAnh = fileName.GenerateSlug() + ext;
                    context.SanPhams.Update(sp);
                }
                context.SaveChanges();
                fmSanPham_Load(sender, e);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoay_Click(object sender, EventArgs e)
        {

            XuLyXoayVaLuu(RotateFlipType.Rotate90FlipNone);
        }
        private void XuLyXoayVaLuu(RotateFlipType kieuXoay)
        {
            if (picHinhAnh.Image == null || dataGridView1.CurrentRow == null) return;

            try
            {
                // 1. TẠO ẢNH SẠCH (Cắt đứt liên hệ với file cũ)
                // Dùng new Bitmap để copy ảnh ra vùng nhớ mới
                using (Bitmap bmpSach = new Bitmap(picHinhAnh.Image))
                {
                    // 2. XOAY ẢNH TRÊN RAM
                    bmpSach.RotateFlip(kieuXoay);

                    // 3. HIỂN THỊ LẠI NGAY (Để người dùng thấy xoay liền)
                    // Phải clone ra một bản để hiển thị, còn bản bmpSach dùng để lưu
                    Image anhHienThi = (Image)bmpSach.Clone();
                    if (picHinhAnh.Image != null) picHinhAnh.Image.Dispose(); // Xóa ảnh cũ
                    picHinhAnh.Image = anhHienThi;

                    // 4. LƯU XUỐNG Ổ CỨNG (Dùng kỹ thuật MemoryStream như StackOverflow khuyên)
                    int idSanPham = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colID"].Value);
                    var sp = context.SanPhams.Find(idSanPham);

                    if (sp != null)
                    {
                        // Tạo thư mục
                        string folderBanSao = Path.Combine(Application.StartupPath, "Images", "BanSaoAnh");
                        if (!Directory.Exists(folderBanSao)) Directory.CreateDirectory(folderBanSao);

                        // Tạo tên file
                        string tenGoc = Path.GetFileNameWithoutExtension(sp.HinhAnh ?? "img");
                        string tenFileMoi = $"SP_{sp.ID}_{DateTime.Now.Ticks}.png";
                        string duongDanFull = Path.Combine(folderBanSao, tenFileMoi);

                        // --- KỸ THUẬT QUAN TRỌNG: Lưu vào RAM trước ---
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bmpSach.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // Lưu dạng PNG vào RAM
                            File.WriteAllBytes(duongDanFull, ms.ToArray()); // Ghi từ RAM xuống đĩa
                        }

                        // 5. Cập nhật Database
                        sp.HinhAnh = Path.Combine("BanSaoAnh", tenFileMoi);
                        context.SanPhams.Update(sp);
                        context.SaveChanges();

                        // Cập nhật bảng
                        if (dataGridView1.Columns.Contains("HinhAnh"))
                        {
                            dataGridView1.CurrentRow.Cells["HinhAnh"].Value = sp.HinhAnh;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // TRƯỜNG HỢP 1: BẤM LẦN ĐẦU (ĐỂ BẬT CHẾ ĐỘ NHẬP LIỆU)
            if (dangTimKiem == false)
            {
                dangTimKiem = true; // Đánh dấu là đang trong chế độ tìm

                // 1. Bật các ô nhập liệu lên (Dùng hàm BatTatChucNang có sẵn của bạn)
                BatTatChucNang(true);
                numSL.Enabled = false;
                numDG.Enabled = false;
                txtMT.Enabled = false;
                btnTimKiem.Enabled = true;


                // 2. Nhưng KHÔNG cho bấm nút Lưu (để tránh lưu nhầm khi đang tìm)
                btnLuu.Enabled = false;

                // 3. Xóa trắng các ô để chuẩn bị nhập từ khóa mới
                txtTSP.Clear();
                txtMT.Clear();
                cobPL.SelectedIndex = -1; // Bỏ chọn combobox
                cobHSX.SelectedIndex = -1;
                numSL.Value = 0;
                numDG.Value = 0;

                // 4. Đổi tên nút để người dùng biết bấm phát nữa là chạy
                btnTimKiem.Text = "Tìm ngay";
                MessageBox.Show("Hãy nhập thông tin cần tìm rồi bấm nút 'Tìm ngay' lần nữa!");
            }
            // TRƯỜNG HỢP 2: BẤM LẦN 2 (THỰC HIỆN TÌM KIẾM)
            else
            {
                // Code tìm kiếm giống bài trước
                var query = context.SanPhams.AsQueryable();

                // Lọc theo Tên (nếu có nhập)
                if (!string.IsNullOrWhiteSpace(txtTSP.Text))
                    query = query.Where(x => x.TenSanPham.Contains(txtTSP.Text));

                // Lọc theo Loại (nếu có chọn)
                if (cobPL.SelectedIndex != -1 && int.TryParse(cobPL.SelectedValue.ToString(), out int idLoai))
                    query = query.Where(x => x.LoaiSanPhamID == idLoai);

                // Lọc theo Hãng (nếu có chọn)
                if (cobHSX.SelectedIndex != -1 && int.TryParse(cobHSX.SelectedValue.ToString(), out int idHang))
                    query = query.Where(x => x.HangSanXuatID == idHang);

                // Đổ dữ liệu ra bảng
                var ketQua = query.Select(r => new DanhSachSanPham
                {
                    ID = r.ID,
                    LoaiSanPhamID = r.LoaiSanPhamID,
                    TenLoai = r.LoaiSanPhams.TenLoai,
                    HangSanXuatID = r.HangSanXuatID,
                    TenHangSanXuat = r.HangSanXuat.TenHangSanXuat,
                    TenSanPham = r.TenSanPham,
                    SoLuong = r.SoLuong,
                    DonGia = r.DonGia,
                    HinhAnh = r.HinhAnh
                }).ToList();

                if (ketQua.Count > 0)
                {
                    dataGridView1.DataSource = ketQua;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!");
                }

                // (Tùy chọn) Nếu muốn tìm xong thì quay về trạng thái bình thường ngay thì mở dòng dưới:
                // dangTimKiem = false; btnTimKiem.Text = "Tìm kiếm";
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
                                SanPham sp = new SanPham();
                                sp.LoaiSanPhamID = Convert.ToInt32(r["LoaiSanPhamID"]);
                                sp.HangSanXuatID = Convert.ToInt32(r["HangSanXuatID"]);
                                sp.TenSanPham = r["TenSanPham"].ToString();
                                sp.SoLuong = Convert.ToInt32(r["SoLuong"]);
                                sp.DonGia = Convert.ToInt32(r["DonGia"]);

                                // Nếu file Excel không có cột HinhAnh hoặc trống thì để mặc định
                                if (table.Columns.Contains("HinhAnh") && r["HinhAnh"] != DBNull.Value)
                                    sp.HinhAnh = r["HinhAnh"].ToString();
                                else
                                    sp.HinhAnh = "no-image.png";
                                context.SanPhams.Add(sp);
                            }
                            context.SaveChanges();
                            MessageBox.Show("Đã nhập dữ liệu thành công" + table.Rows.Count + "dòng", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fmSanPham_Load(sender, e);
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
            saveFileDialog.FileName = "SanPham_" + DateTime.Now.ToString("yyyyMMdd_HHmmss").Replace("-", "_") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[7]
                    {
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("LoaiSanPhamID", typeof(int)),
                        new DataColumn("HangSanXuatID", typeof(int)),
                        new DataColumn("TenSanPham", typeof (string)),
                        new DataColumn("SoLuong", typeof(int)),
                        new DataColumn("DonGia", typeof(int)),
                        new DataColumn("HinhAnh", typeof(string))
                    });

                    var SanPhams = context.SanPhams.ToList();
                    if (SanPhams != null)
                    {
                        foreach (var p in SanPhams)
                            table.Rows.Add(p.ID, p.LoaiSanPhamID, p.HangSanXuatID, p.TenSanPham, p.SoLuong, p.DonGia, p.HinhAnh);
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "SanPham");
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






