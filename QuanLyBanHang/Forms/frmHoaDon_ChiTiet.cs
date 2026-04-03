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

    public partial class frmHoaDon_ChiTiet : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        int id;
        BindingList<DanhSachHoaDon_ChiTiet> hoaDonChiTiet = new BindingList<DanhSachHoaDon_ChiTiet>();

        public frmHoaDon_ChiTiet(int maHoaDon = 0)
        {
            InitializeComponent();
            id = maHoaDon;
        }
        public void LayNhanVienVaoCombobox()
        {
            cboNhanVien.DataSource = context.NhanViens.ToList();
            cboNhanVien.ValueMember = "ID";
            cboNhanVien.DisplayMember = "HoVaTen";

        }

        public void LayKhachHangVaoCombobox()
        {
            cboKhachHang.DataSource = context.KhachHang.ToList();
            cboKhachHang.ValueMember = "ID";
            cboKhachHang.DisplayMember = "HoVaTen";
        }
        public void LaySanPhamVaoCombobox()
        {
            cboSanPham.DataSource = context.SanPhams.ToList();
            cboSanPham.ValueMember = "ID";
            cboSanPham.DisplayMember = "TenSanPham";
        }

        public void BatTatChucNang()
        {
            if (id == 0 && dataGridView.Rows.Count == 0)
            {
                //Xóa trang
                cboKhachHang.Text = "";
                cboNhanVien.Text = "";
                cboSanPham.Text = "";
                numSoLuongBan.Value = 1;
                numDonGiaBan.Value = 0;
            }

            // nút luu va xoa sang khi có sp
            btnLuuHoaDon.Enabled = dataGridView.Rows.Count > 0;
            btnXoa.Enabled = dataGridView.Rows.Count > 0;
        }

        private void frmHoaDon_ChiTiet_Load(object sender, EventArgs e)
        {
            LayNhanVienVaoCombobox();
            LayKhachHangVaoCombobox();
            LaySanPhamVaoCombobox();

            dataGridView.AutoGenerateColumns = false;
            if (id != 0) //đã tồn tại chi tiết
            {
                var hoaDon = context.HoaDon.Where(r => r.ID == id).SingleOrDefault();
                cboNhanVien.SelectedValue = hoaDon.NhanVienID;
                cboKhachHang.SelectedValue = hoaDon.KhachHangID;
                txtGhiChuHoaDon.Text = hoaDon.GhiChuHoaDon;

                var ct = context.HoaDon_ChiTiet.Where(r => r.HoaDonID == id).Select(r => new DanhSachHoaDon_ChiTiet
                {

                    ID = r.ID,
                    HoaDonID = r.HoaDonID,
                    SanPhamID = r.SanPhamID,
                    TenSanPham = r.SanPham.TenSanPham,
                    SoLuongBan = (short)r.SoLuongBan,// doi thanh int rồi ép kiểu  lại short
                    DonGiaBan = r.DonGiaBan,
                    ThanhTien = Convert.ToInt32(r.SoLuongBan * r.DonGiaBan)
                }).ToList();

                hoaDonChiTiet = new BindingList<DanhSachHoaDon_ChiTiet>(ct);
            }

            dataGridView.DataSource = hoaDonChiTiet;
            BatTatChucNang();


        }

        private void btnXacNhanBan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboSanPham.Text))

                MessageBox.Show("Vui lòng chọn sản phẩm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numSoLuongBan.Value <= 0)
                MessageBox.Show("Số lượng bán phảilớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numDonGiaBan.Value <= 0)
                MessageBox.Show(Text, "Đơn giá bán phải lớn hơn 0.", MessageBoxButtons.OK, MessageBoxIcon.Error);

            {
                int maSanPham = Convert.ToInt32(cboSanPham?.SelectedValue?.ToString());
                var chiTiet = hoaDonChiTiet.FirstOrDefault(x => x.SanPhamID == maSanPham);

                //neu đã tồn tại sản phẩm trong chi tiết thì cập nhật thông tin
                if (chiTiet != null)
                {
                    chiTiet.SoLuongBan = Convert.ToInt16(numSoLuongBan.Value);
                    chiTiet.DonGiaBan = Convert.ToInt32(numDonGiaBan.Value);
                    chiTiet.ThanhTien = Convert.ToInt32(numSoLuongBan.Value * numDonGiaBan.Value);
                    dataGridView.Refresh();
                }
                else //nếu chưa có sp thì thêm vào
                {
                    DanhSachHoaDon_ChiTiet ct = new DanhSachHoaDon_ChiTiet
                    {
                        ID = 0,
                        HoaDonID = id,
                        SanPhamID = maSanPham,
                        TenSanPham = cboSanPham.Text,
                        SoLuongBan = Convert.ToInt16(numSoLuongBan.Value),
                        DonGiaBan = Convert.ToInt32(numDonGiaBan.Value),
                        ThanhTien = Convert.ToInt32(numSoLuongBan.Value * numDonGiaBan.Value)

                    };
                    hoaDonChiTiet.Add(ct);
                }
                BatTatChucNang();
            }
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maSanPham = Convert.ToInt32(dataGridView.CurrentRow.Cells["SanPham"].Value.ToString());
            var chiTiet = hoaDonChiTiet.FirstOrDefault(x => x.SanPhamID == maSanPham);
            if (chiTiet != null)
            {
                hoaDonChiTiet.Remove(chiTiet);
            }
            BatTatChucNang();
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboNhanVien.Text))
                MessageBox.Show("Vui lòng chọn nhân viên lập hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(cboKhachHang.Text))
                MessageBox.Show("Vui lòng chọn khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (id != 0) // Đã tồn tại chi tiết thì cập nhật
                {
                    HoaDon hd = context.HoaDon.Find(id);
                    if (hd != null)
                    {
                        hd.NhanVienID = Convert.ToInt32(cboNhanVien.SelectedValue.ToString());
                        hd.KhachHangID = Convert.ToInt32(cboKhachHang.SelectedValue.ToString());
                        hd.GhiChuHoaDon = txtGhiChuHoaDon.Text;
                        context.HoaDon.Update(hd);// Xóa chi tiết cũ
                        var old = context.HoaDon_ChiTiet.Where(r => r.HoaDonID == id).ToList();
                        context.HoaDon_ChiTiet.RemoveRange(old);
                        // Thêm lại chi tiết mới
                        foreach (var item in hoaDonChiTiet.ToList())
                        {
                            HoaDon_ChiTiet ct = new HoaDon_ChiTiet();
                            ct.HoaDonID = id;
                            ct.SanPhamID = item.SanPhamID;
                            ct.SoLuongBan = item.SoLuongBan;
                            ct.DonGiaBan = item.DonGiaBan;
                            context.HoaDon_ChiTiet.Add(ct);
                        }
                        context.SaveChanges();
                    }
                }
                else // Thêm mới
                {
                    HoaDon hd = new HoaDon();
                    hd.NhanVienID = Convert.ToInt32(cboNhanVien.SelectedValue.ToString());
                    hd.KhachHangID = Convert.ToInt32(cboKhachHang.SelectedValue.ToString());
                    hd.NgayLap = DateTime.Now;
                    hd.GhiChuHoaDon = txtGhiChuHoaDon.Text;
                    context.HoaDon.Add(hd);
                    context.SaveChanges();
                    // Thêm chi tiết
                    foreach (var item in hoaDonChiTiet.ToList())
                    {
                        HoaDon_ChiTiet ct = new HoaDon_ChiTiet();
                        ct.HoaDonID = hd.ID;
                        ct.SanPhamID = item.SanPhamID;
                        ct.SoLuongBan = item.SoLuongBan;
                        ct.DonGiaBan = item.DonGiaBan;
                        context.HoaDon_ChiTiet.Add(ct);
                    }
                    context.SaveChanges();
                }
                MessageBox.Show("Đã lưu thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cboSanPham_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int maSanPham = Convert.ToInt32(cboSanPham.SelectedValue.ToString());
            var sanPham = context.SanPhams.Find(maSanPham);
            numDonGiaBan.Value = sanPham.DonGia;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem hóa đơn đã được lưu vào Database chưa
            if (id == 0)
            {
                MessageBox.Show("Vui lòng lưu hóa đơn trước khi in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở hộp thoại xem trước khi in (Print Preview)
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();

            // Gắn sự kiện "vẽ" nội dung hóa đơn vào máy in
            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(InHoaDon_PrintPage);

            previewDialog.Document = printDocument;
            previewDialog.ShowDialog();
        }

        // Tạo thêm hàm này ngay bên dưới để "vẽ" nội dung tờ hóa đơn
        private void InHoaDon_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font fontTitle = new Font("Arial", 20, FontStyle.Bold);
            Font fontRegular = new Font("Arial", 12, FontStyle.Regular);
            Font fontBold = new Font("Arial", 12, FontStyle.Bold);

            int y = 20; // Tọa độ Y (chiều dọc) để căn dòng in

            // 1. In Tiêu đề Cửa hàng
            graphics.DrawString("CỬA HÀNG ĐIỆN THOẠI", fontTitle, Brushes.Black, new PointF(250, y));
            y += 40;
            graphics.DrawString("HÓA ĐƠN BÁN HÀNG", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new PointF(280, y));
            y += 40;

            // 2. In Thông tin chung
            graphics.DrawString("Mã hóa đơn: " + id, fontRegular, Brushes.Black, new PointF(50, y));
            graphics.DrawString("Ngày lập: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontRegular, Brushes.Black, new PointF(450, y));
            y += 30;
            graphics.DrawString("Khách hàng: " + cboKhachHang.Text, fontRegular, Brushes.Black, new PointF(50, y));
            y += 30;
            graphics.DrawString("Nhân viên: " + cboNhanVien.Text, fontRegular, Brushes.Black, new PointF(50, y));
            y += 50;

            // 3. In Tiêu đề cột
            graphics.DrawString("STT", fontBold, Brushes.Black, new PointF(50, y));
            graphics.DrawString("Tên Sản Phẩm", fontBold, Brushes.Black, new PointF(120, y));
            graphics.DrawString("SL", fontBold, Brushes.Black, new PointF(400, y));
            graphics.DrawString("Đơn Giá", fontBold, Brushes.Black, new PointF(500, y));
            graphics.DrawString("Thành Tiền", fontBold, Brushes.Black, new PointF(650, y));
            y += 30;
            graphics.DrawLine(Pens.Black, 50, y, 780, y); // Kẻ đường gạch ngang
            y += 10;

            // 4. In danh sách sản phẩm
            int stt = 1;
            long tongTien = 0;
            foreach (var item in hoaDonChiTiet)
            {
                graphics.DrawString(stt.ToString(), fontRegular, Brushes.Black, new PointF(50, y));
                graphics.DrawString(item.TenSanPham, fontRegular, Brushes.Black, new PointF(120, y));
                graphics.DrawString(item.SoLuongBan.ToString(), fontRegular, Brushes.Black, new PointF(400, y));

                // Thêm .ToString("N0") để hiển thị dấu phẩy phân cách phần ngàn (vd: 6,890,000)
                graphics.DrawString(item.DonGiaBan.ToString("N0"), fontRegular, Brushes.Black, new PointF(500, y));
                graphics.DrawString(item.ThanhTien.ToString("N0"), fontRegular, Brushes.Black, new PointF(650, y));

                tongTien += item.ThanhTien;
                stt++;
                y += 30;
            }

            y += 10;
            graphics.DrawLine(Pens.Black, 50, y, 780, y); // Kẻ đường gạch ngang chốt danh sách
            y += 20;

            // 5. In Tổng tiền
            graphics.DrawString("Tổng Tiền:", fontBold, Brushes.Black, new PointF(500, y));
            // In số tiền màu đỏ cho nổi bật
            graphics.DrawString(tongTien.ToString("N0") + " VNĐ", fontBold, Brushes.Red, new PointF(650, y));
        
        }
    }
}

