using DocumentFormat.OpenXml.EMMA;
using Microsoft.Extensions.Configuration;
using QuanLyBanHang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BC = BCrypt.Net.BCrypt;
using QuanLyBanHang.Forms;
using QuanLyBanHang.Reports;

namespace QuanLyBanHang.Forms
{
    public partial class frmMain : Form
    {
        QLBHDbContext context = new QLBHDbContext(); // Khởi tạo biến ngữ cảnh CSDL
        fmLoaiSanPham? loaiSanPham = null;
        fmHangSanXuat? hangSanXuat = null;
        fmSanPham? sanPham = null;
        fmKhachHang? khachHang = null;
        fmNhanVien? nhanVien = null;
        frmHoaDon? hoaDon = null;
        frmDangNhap? dangNhap = null;
        frmThongKeSanPham? tksp = null;
        frmThongKeDoanhThu? tkdt = null;
        string hoVaTenNhanVien = ""; //lấy tên người dùng hiển thị vào thanh status

        // 1. Khai báo các biến lưu trữ thông tin nhân viên ở đây
        int maNhanVien;
        string quyenHan;
        string tenNhanVien;
        public frmMain()
        {
            InitializeComponent();
            //this.maNhanVien = maNV;int maNV, string quyen, string tenNV
            //this.quyenHan = quyen;
            //this.tenNhanVien = tenNV;
        }


        private void mnuLoaiSanPham_Click(object sender, EventArgs e)
        {
            if (loaiSanPham == null || loaiSanPham.IsDisposed)
            {
                loaiSanPham = new fmLoaiSanPham();
                loaiSanPham.MdiParent = this;
                loaiSanPham.Show();
            }
            else
                loaiSanPham.Activate();
        }

        private void mnuHangSanXuat_Click(object sender, EventArgs e)
        {

            if (hangSanXuat == null || hangSanXuat.IsDisposed)
            {
                hangSanXuat = new fmHangSanXuat();
                hangSanXuat.MdiParent = this;
                hangSanXuat.Show();
            }
            else
                hangSanXuat.Activate();
        }

        private void mnuSanPham_Click(object sender, EventArgs e)
        {
            if (sanPham == null || sanPham.IsDisposed)
            {
                sanPham = new fmSanPham();
                sanPham.MdiParent = this;
                sanPham.Show();
            }
            else
                sanPham.Activate();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            if (khachHang == null || khachHang.IsDisposed)
            {
                khachHang = new fmKhachHang();
                khachHang.MdiParent = this;
                khachHang.Show();
            }
            else
                khachHang.Activate();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {

            if (nhanVien == null || nhanVien.IsDisposed)
            {
                nhanVien = new fmNhanVien();
                nhanVien.MdiParent = this;
                nhanVien.Show();
            }
            else
                nhanVien.Activate();
        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            if (hoaDon == null || hoaDon.IsDisposed)
            {
                hoaDon = new frmHoaDon();
                hoaDon.MdiParent = this;
                hoaDon.Show();
            }
            else
                hoaDon.Activate();
        }

        private void lblLienKet_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "exploere.exe";
            info.Arguments = "https;//fit.agu.edu.vn";
            Process.Start(info);
        }

        private void DangNhap()
        {
        LamLai:
            if (dangNhap == null || dangNhap.IsDisposed)
                dangNhap = new frmDangNhap();

            if (dangNhap.ShowDialog() == DialogResult.OK)
            {
                string tenDangNhap = dangNhap.txtTenDangNhap.Text;
                string matKhau = dangNhap.txtMatKhau.Text;

                if (tenDangNhap.Trim() == "")
                {
                    MessageBox.Show("Tên đăng nhập không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dangNhap.txtTenDangNhap.Focus();
                    goto LamLai;
                }
                else if (matKhau.Trim() == "")
                {
                    MessageBox.Show("Mật khẩu không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dangNhap.txtMatKhau.Focus();
                    goto LamLai;
                }
                else
                {
                    //ten dn có trùng trong csdl
                    //var nhanVien = context.NhanViens.Where(r => r.TenDangNhap == tenDangNhap).SingleOrDefault();
                    var nhanVien = context.NhanViens.Where(r => r.TenDangNhap == tenDangNhap).FirstOrDefault();// lấy ten dn đầu tìm thấy

                    if (nhanVien == null)
                    {
                        MessageBox.Show("Tên đăng nhập không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dangNhap.txtTenDangNhap.Focus();
                        goto LamLai;

                    }
                    else
                    {
                        if (BC.Verify(matKhau, nhanVien.MatKhau))

                        {
                            hoVaTenNhanVien = nhanVien.HoVaTen;
                            if (nhanVien.QuyenHan == true)
                                QuyenQuanLy();
                            else if (nhanVien.QuyenHan == false)
                                QuyenNhanVien();
                            else
                                ChuaDangNhap();

                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dangNhap.txtMatKhau.Focus();
                            goto LamLai;
                        }
                    }
                }
            }
        }



        public void ChuaDangNhap()
        {
            //sáng đăng nhập
            mnuDangNhap.Enabled = true;

            //mở tất cả
            mnuDangXuat.Enabled = false;
            mnuDoiMatKhau.Enabled = false;

            mnuLoaiSanPham.Enabled = false;
            mnuHangSanXuat.Enabled = false;
            mnuSanPham.Enabled = false;
            mnuKhachHang.Enabled = false;
            mnuNhanVien.Enabled = false;
            mnuHoaDon.Enabled = false;

            mnuThongKeSanPham.Enabled = false;
            mnuThongKeDoanhThu.Enabled = false;

            // hiển thị thông tin tren thanh trang thai
            lblTrangThai.Text = "Chưa đang nhập.";
        }

        public void QuyenQuanLy()
        {
            // Mờ đăng nhập
            mnuDangNhap.Enabled = false;
            // Mờ các chức năng quản lý không được phép
            // Sáng đăng xuất và các chức năng quản lý được phép
            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;
            mnuLoaiSanPham.Enabled = true;
            mnuHangSanXuat.Enabled = true;
            mnuSanPham.Enabled = true;
            mnuKhachHang.Enabled = true;
            mnuNhanVien.Enabled = true;
            mnuHoaDon.Enabled = true;
            mnuThongKeSanPham.Enabled = true;
            mnuThongKeDoanhThu.Enabled = true;
            // Hiển thị thông tin trên thanh trạng thái
            lblTrangThai.Text = "Quản lý: " + hoVaTenNhanVien;
        }
        public void QuyenNhanVien()
        {
            // Mờ đăng nhập
            mnuDangNhap.Enabled = false;
            // Mờ các chức năng nhân viên không được phép
            mnuLoaiSanPham.Enabled = false;
            mnuHangSanXuat.Enabled = false;
            mnuSanPham.Enabled = false;
            mnuNhanVien.Enabled = false;
            // Sáng đăng xuất và các chức năng nhân viên được phép
            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;
            mnuKhachHang.Enabled = true;
            mnuHoaDon.Enabled = true;
            mnuThongKeSanPham.Enabled = true;
            mnuThongKeDoanhThu.Enabled = true;
            // Hiển thị thông tin trên thanh trạng thái
            lblTrangThai.Text = "Nhân viên: " + hoVaTenNhanVien;
        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ChuaDangNhap();
            DangNhap();
            helpProvider1.HelpNamespace = "HuongDan.html";
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }
            ChuaDangNhap();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            //đóng toàn bộ chương trình
            Application.Exit();


        }

        private void mnuThongKeSanPham_Click(object sender, EventArgs e)
        {
            if (tksp == null || tksp.IsDisposed)
            {
                tksp = new frmThongKeSanPham();
                tksp.MdiParent = this;
                tksp.Show();
            }
            else
                tksp.Activate();
        }

        private void mnuThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            if (tkdt == null || tksp.IsDisposed)
            {
                tkdt = new frmThongKeDoanhThu();
                tkdt.MdiParent = this;
                tkdt.Show();
            }
            else
                tksp.Activate();
        }

        private void mnuHuongDanSuDung_Click(object sender, EventArgs e)
        {
            string helpPath = Path.Combine(Application.StartupPath, "Reports", "HuongDan.html");

            if (File.Exists(helpPath))
            {
                Help.ShowHelp(this, helpPath);
            }
            else
            {
                MessageBox.Show("Không tìm thấy tệp hướng dẫn tại: " + helpPath, "Lỗi");
            }
        }
    }
}
