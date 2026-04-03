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

namespace QuanLyBanHang.Reports
{
    public partial class frmThongKeSanPham : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        QLBHDataSet.DanhSachSanPhamDataTable danhSachSanPhamDataTable = new QLBHDataSet.DanhSachSanPhamDataTable();
        // Kiểm tra xem có đang chạy trong môi trường Debug (lập trình) hay không
        string reportsFolder = Application.StartupPath;
        
public frmThongKeSanPham()
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



        private void frmThongKeSanPham_Load(object sender, EventArgs e)
        {
            LayLoaiSanPhamVaoCombobox();
            LayHangSanXuatVaoCombobox();
            var danhSachSanPham = context.SanPhams.Select(r => new DanhSachSanPham
            {
                ID = r.ID,
                HangSanXuatID = r.HangSanXuatID,
                TenHangSanXuat = r.HangSanXuat.TenHangSanXuat,
                LoaiSanPhamID = r.LoaiSanPhamID,
                TenLoai = r.LoaiSanPhams.TenLoai,
                TenSanPham = r.TenSanPham,
                DonGia = r.DonGia,
                SoLuong = r.SoLuong,
                HinhAnh = r.HinhAnh,
                MoTa = r.MoTa
            }).ToList();
            danhSachSanPhamDataTable.Clear();
            foreach (var row in danhSachSanPham)
            {
                danhSachSanPhamDataTable.AddDanhSachSanPhamRow(row.ID,
                row.HangSanXuatID,
                row.TenHangSanXuat,
                row.LoaiSanPhamID,
                row.TenLoai,
                row.TenSanPham,
                row.DonGia,
                row.SoLuong,
                row.HinhAnh,
                row.MoTa);
            }
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DanhSachSanPham";
            reportDataSource.Value = danhSachSanPhamDataTable;

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportViewer1.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptThongKeSanPham.rdlc");

            ReportParameter reportParameter = new ReportParameter("MoTaKetQuaHienThi", "(Tất cả sản phẩm)");
            reportViewer1.LocalReport.SetParameters(reportParameter);


            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;

            reportViewer1.RefreshReport();
        }
        //bổ sung code buổi 8 
        public void LayLoaiSanPhamVaoCombobox()
        {
            var dsLoai = context.LoaiSanPhams.Select(l => new
            {
                l.ID,
                l.TenLoai

            }).ToList();
            cboLoaiSanPham.DataSource = dsLoai;
            cboLoaiSanPham.DisplayMember = "TenLoai"; //hiển thị
            cboLoaiSanPham.ValueMember = "ID"; // GIÁ TRỊ THỰC



        }
        public void LayHangSanXuatVaoCombobox()
        {
            var dsHSX = context.HangSanXuat.Select(h => new
            {
                h.ID,
                h.TenHangSanXuat
            }).ToList();
            cboHangSanXuat.DataSource = dsHSX;
            cboHangSanXuat.DisplayMember = "TenHangSanXuat";
            cboHangSanXuat.ValueMember = "ID";

        }
        private void cboHangSanXuat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLocKetQua_Click(object sender, EventArgs e)
        {
            if (cboHangSanXuat.Text == "" && cboLoaiSanPham.Text == "")
            {
                //trống cả 2 thì hiển thị tất cả
                frmThongKeSanPham_Load(sender, e);
            }
            else
            {
                var danhSachSanPham = context.SanPhams.Select(r=> new DanhSachSanPham
                {
                    ID = r.ID,
                    HangSanXuatID = r.HangSanXuatID,
                        TenHangSanXuat = r.HangSanXuat.TenHangSanXuat,
                        LoaiSanPhamID = r.LoaiSanPhamID,
                        TenLoai = r.LoaiSanPhams.TenLoai,
                        TenSanPham =r.TenSanPham,
                        DonGia = r.DonGia,
                        SoLuong = r.SoLuong,
                        HinhAnh = r.HinhAnh,
                        MoTa = r.MoTa

                });
                string hangSanXuat = null;
                string loaiSanPham = null;

                if (cboHangSanXuat.Text != "")

                {
                    int hangSanXuatID = Convert.ToInt32(cboHangSanXuat.SelectedValue.ToString());
                    hangSanXuat += "Hãng sản xuất:: " + cboHangSanXuat.Text;
                    danhSachSanPham = danhSachSanPham.Where(r => r.HangSanXuatID == hangSanXuatID);
                }
                if(cboLoaiSanPham.Text != "")
                {
                    int loaiSanPhamID = Convert.ToInt32(cboLoaiSanPham.SelectedValue.ToString());
                    loaiSanPham += "Phân loại: " + cboLoaiSanPham.Text;
                    danhSachSanPham = danhSachSanPham.Where(r => r.LoaiSanPhamID == loaiSanPhamID);
                }
                danhSachSanPhamDataTable.Clear();
                foreach (var row in danhSachSanPham)
                {
                    danhSachSanPhamDataTable.AddDanhSachSanPhamRow(row.ID,
                        row.HangSanXuatID,
                        row.TenHangSanXuat,
                        row.LoaiSanPhamID,
                        row.TenLoai,
                        row.TenSanPham,
                        row.DonGia,
                        row.SoLuong,
                        row.HinhAnh,
                        row.MoTa);
                }

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DanhSachSanPham";
                reportDataSource.Value = danhSachSanPhamDataTable;

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                reportViewer1.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptThongKeSanPham.rdlc");
                ReportParameter reportParameter = new ReportParameter("MoTaKetQuaHienThi", "(" + hangSanXuat + " - " + loaiSanPham + ")");
                reportViewer1.LocalReport.SetParameters(reportParameter);
               
                
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                
                reportViewer1.RefreshReport();
            }
        }
    }
}

        