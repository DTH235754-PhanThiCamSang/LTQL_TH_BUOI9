using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.EntityFrameworkCore;
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
   
    public partial class frmInHoaDon : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        QLBHDataSet.DanhSachHoaDon_ChiTietDataTable danhSachHoaDon_ChiTietDataTable = new QLBHDataSet.DanhSachHoaDon_ChiTietDataTable();
        int id; // Mã hóa đơn
                // Kiểm tra xem có đang chạy trong môi trường Debug (lập trình) hay không
        string reportsFolder = Application.StartupPath;

public frmInHoaDon(int maHoaDon = 0)
        {
            InitializeComponent();
            id = maHoaDon;
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

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            var hoaDon = context.HoaDon.Include(r => r.KhachHang).Include(r => r.HoaDon_ChiTiet)
.Where(r => r.ID == id).SingleOrDefault();
            if (hoaDon != null)
            {
                var hoaDonChiTiet = context.HoaDon_ChiTiet.Where(r => r.HoaDonID == id).Select(r => new DanhSachHoaDon_ChiTiet
                {
                    ID = r.ID,
                    HoaDonID = r.HoaDonID,
                    SanPhamID = r.SanPhamID,
                    TenSanPham = r.SanPham.TenSanPham,
                    SoLuongBan = r.SoLuongBan,
                    DonGiaBan = r.DonGiaBan,
                    ThanhTien = Convert.ToInt32(r.SoLuongBan * r.DonGiaBan)
                }).ToList();
                danhSachHoaDon_ChiTietDataTable.Clear();
                foreach (var row in hoaDonChiTiet)
                {
                    danhSachHoaDon_ChiTietDataTable.AddDanhSachHoaDon_ChiTietRow(row.ID,
                    row.HoaDonID,
                    row.SanPhamID,
                    row.TenSanPham,
                    row.SoLuongBan,
                    row.DonGiaBan,
                    row.ThanhTien);
                }
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DanhSachHoaDon_ChiTiet";
                reportDataSource.Value = danhSachHoaDon_ChiTietDataTable;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource); reportViewer1.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptInHoaDon.rdlc");
                IList<ReportParameter> param = new List<ReportParameter>
{
                        new ReportParameter("NgayLap", string.Format("Ngày {0} Tháng {1} Năm {2}",
                        hoaDon.NgayLap.Day,
                        hoaDon.NgayLap.Month,
                        hoaDon.NgayLap.Year)),
                        new ReportParameter("NguoiBan_Ten", "CÔNG TY TNHH LAZY ANT"),
                        new ReportParameter("NguoiBan_DiaChi", "Mỹ Phước, TP. Long Xuyên, An Giang"),
                        new ReportParameter("NguoiBan_MaSoThue", "1602162070"),
                        new ReportParameter("NguoiMua_Ten", hoaDon.KhachHang.HoVaTen),
                        new ReportParameter("NguoiMua_DiaChi", hoaDon.KhachHang.DiaChi),
                        new ReportParameter("NguoiMua_MaSoThue", ""),
                        new ReportParameter("TongTien", hoaDon.HoaDon_ChiTiet.Sum(r => r.SoLuongBan * r.DonGiaBan).ToString("#,##0"))
                        };
                reportViewer1.LocalReport.SetParameters(param);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.RefreshReport();
            }
        }
    }
}
    