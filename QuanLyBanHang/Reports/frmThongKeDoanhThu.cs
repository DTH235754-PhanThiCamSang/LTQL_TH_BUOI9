using Microsoft.Reporting.WinForms;
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
using static QuanLyBanHang.Reports.QLBHDataSet;

namespace QuanLyBanHang.Reports
{
    public partial class frmThongKeDoanhThu : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        QLBHDataSet.DanhSachSanPhamDataTable danhSachSanPhamDataTable = new QLBHDataSet.DanhSachSanPhamDataTable();
        QLBHDataSet.DanhSachHoaDonDataTable danhSachHoaDonDataTable = new QLBHDataSet.DanhSachHoaDonDataTable();
        // Kiểm tra xem có đang chạy trong môi trường Debug (lập trình) hay không
        string reportsFolder = Application.StartupPath;

public frmThongKeDoanhThu()
        {
            InitializeComponent();
            if (reportsFolder.Contains("bin\\Debug"))
            {
                // Nếu đang lập trình, lùi lại để vào thư mục Reports của dự án
                reportsFolder = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.Parent.FullName, "Reports");
            }
            else
            {
                // Nếu đã cài đặt (.msi), file .rdlc nằm trong thư mục Reports cạnh file .exe
                reportsFolder = Path.Combine(Application.StartupPath, "Reports");
            }
        }

        private void frmThongKeDoanhThucs_Load(object sender, EventArgs e)
        {
            // 1. Phải lấy từ context.HoaDon (không phải SanPhams)
            var danhSachHoaDon = context.HoaDon.Select(r => new DanhSachHoaDon
            {
                ID = r.ID,
                NhanVienID = r.NhanVienID,
                HoVaTenNhanVien = r.NhanVien.HoVaTen,
                KhachHangID = r.KhachHangID,
                HoVaTenKhachHang = r.KhachHang.HoVaTen,
                NgayLap = r.NgayLap,
                GhiChuHoaDon = r.GhiChuHoaDon,
                // Tính tổng tiền từ bảng chi tiết
                TongTienHoaDon = r.HoaDon_ChiTiet.Sum(ct => ct.SoLuongBan * ct.DonGiaBan)
            }).ToList();

            // 2. Clear bảng Hóa đơn (Hãy dùng đúng danhSachHoaDonDataTable đã tạo ở XSD)
            danhSachHoaDonDataTable.Clear();

            // 3. Đổ dữ liệu vào đúng bảng của nó
            foreach (var row in danhSachHoaDon)
            {
                danhSachHoaDonDataTable.AddDanhSachHoaDonRow(
                    row.ID,                 
                    row.NhanVienID,         
                    row.KhachHangID,        
                    row.NgayLap,            
                    row.TongTienHoaDon ?? 0,
                    row.GhiChuHoaDon ?? "", 
                    row.HoVaTenKhachHang,  
                    row.HoVaTenNhanVien
                );
            }
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DanhSachHoaDon";
            reportDataSource.Value = danhSachHoaDonDataTable;

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportViewer1.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptThongKeDoanhThu.rdlc");

            ReportParameter reportParameter = new ReportParameter("MoTaKetQuaHienThi", "(Tất cả thời gian)");
            reportViewer1.LocalReport.SetParameters(reportParameter);

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;

            reportViewer1.RefreshReport();
        }

        private void btnLocKetQua_Click(object sender, EventArgs e)
        {
            var danhSachHoaDon = context.HoaDon.Select(r => new DanhSachHoaDon
            {
                ID = r.ID,
                NhanVienID = r.NhanVienID,
                HoVaTenNhanVien = r.NhanVien.HoVaTen,
                KhachHangID = r.KhachHangID,
                HoVaTenKhachHang = r.KhachHang.HoVaTen,
                NgayLap = r.NgayLap,
                GhiChuHoaDon = r.GhiChuHoaDon,
                TongTienHoaDon = r.HoaDon_ChiTiet.Sum(r => r.SoLuongBan * r.DonGiaBan)
            });
            danhSachHoaDon = danhSachHoaDon.Where(r => r.NgayLap >= dtpTuNgay.Value && r.NgayLap <= dtpDenNgay.Value);

            danhSachHoaDonDataTable.Clear();
            foreach (var row in danhSachHoaDon)
            {
                danhSachHoaDonDataTable.AddDanhSachHoaDonRow(row.ID,

                    row.NhanVienID,
                    row.KhachHangID,
                    row.NgayLap,
                    row.TongTienHoaDon ?? 0,
                    row.GhiChuHoaDon ?? "",
                    row.HoVaTenKhachHang,
                    row.HoVaTenNhanVien);
            }
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DanhSachHoaDon";
            reportDataSource.Value = danhSachHoaDonDataTable;

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportViewer1.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptThongKeDoanhThu.rdlc");

            ReportParameter reportParameter = new ReportParameter("MoTaKetQuaHienThi", "Từ ngày " + dtpTuNgay.Text + " - Đến ngày: " + dtpDenNgay.Text);
            reportViewer1.LocalReport.SetParameters(reportParameter);

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;

            reportViewer1.RefreshReport();
        }

        private void btnHienThiKetQua_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThucs_Load(sender, e);
        }
    }

}
