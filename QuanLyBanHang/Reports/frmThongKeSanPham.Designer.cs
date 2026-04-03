namespace QuanLyBanHang.Reports
{
    partial class frmThongKeSanPham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            groupBox1 = new GroupBox();
            btnLocKetQua = new Button();
            cboLoaiSanPham = new ComboBox();
            label2 = new Label();
            cboHangSanXuat = new ComboBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // reportViewer1
            // 
            reportViewer1.Location = new Point(0, 89);
            reportViewer1.Name = "reportViewer1";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(1296, 654);
            reportViewer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLocKetQua);
            groupBox1.Controls.Add(cboLoaiSanPham);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cboHangSanXuat);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(1, 0);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(1295, 83);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // btnLocKetQua
            // 
            btnLocKetQua.Location = new Point(1081, 30);
            btnLocKetQua.Margin = new Padding(3, 4, 3, 4);
            btnLocKetQua.Name = "btnLocKetQua";
            btnLocKetQua.Size = new Size(157, 31);
            btnLocKetQua.TabIndex = 2;
            btnLocKetQua.Text = "Lọc kết quả";
            btnLocKetQua.UseVisualStyleBackColor = true;
            btnLocKetQua.Click += btnLocKetQua_Click;
            // 
            // cboLoaiSanPham
            // 
            cboLoaiSanPham.FormattingEnabled = true;
            cboLoaiSanPham.Location = new Point(717, 32);
            cboLoaiSanPham.Margin = new Padding(3, 4, 3, 4);
            cboLoaiSanPham.Name = "cboLoaiSanPham";
            cboLoaiSanPham.Size = new Size(260, 28);
            cboLoaiSanPham.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(586, 35);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 0;
            label2.Text = "Loại sản phẩm";
            // 
            // cboHangSanXuat
            // 
            cboHangSanXuat.FormattingEnabled = true;
            cboHangSanXuat.Location = new Point(263, 27);
            cboHangSanXuat.Margin = new Padding(3, 4, 3, 4);
            cboHangSanXuat.Name = "cboHangSanXuat";
            cboHangSanXuat.Size = new Size(196, 28);
            cboHangSanXuat.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(102, 35);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 0;
            label1.Text = "Hãng sản xuất:";
            // 
            // frmThongKeSanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1297, 742);
            Controls.Add(groupBox1);
            Controls.Add(reportViewer1);
            Name = "frmThongKeSanPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thống kê sản phẩm";
            Load += frmThongKeSanPham_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private GroupBox groupBox1;
        private ComboBox cboHangSanXuat;
        private Label label1;
        private Button btnLocKetQua;
        private ComboBox cboLoaiSanPham;
        private Label label2;
    }
}