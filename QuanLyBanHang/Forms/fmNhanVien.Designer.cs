namespace QuanLyBanHang.Forms
{
    partial class fmNhanVien
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
            groupBox2 = new GroupBox();
            dataGridView = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            HoVaTen = new DataGridViewTextBoxColumn();
            DienThoai = new DataGridViewTextBoxColumn();
            Diachi = new DataGridViewTextBoxColumn();
            TenDangNhap = new DataGridViewTextBoxColumn();
            MatKhau = new DataGridViewTextBoxColumn();
            QuyenHan = new DataGridViewTextBoxColumn();
            label1 = new Label();
            btnThem = new Button();
            txthovaten = new TextBox();
            txtdiachi = new TextBox();
            txtdienthoai = new TextBox();
            btnLuu = new Button();
            label3 = new Label();
            btnXoa = new Button();
            btnTimkiem = new Button();
            btnSua = new Button();
            btnNhap = new Button();
            btnHuybo = new Button();
            btnXuat = new Button();
            groupBox1 = new GroupBox();
            cobquyenhan = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            txtmatkhau = new TextBox();
            txtTenDN = new TextBox();
            label4 = new Label();
            label2 = new Label();
            btnThoat = new Button();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView);
            groupBox2.Location = new Point(20, 187);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(950, 503);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dabh sách nhân viên";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colID, HoVaTen, DienThoai, Diachi, TenDangNhap, MatKhau, QuyenHan });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 23);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(944, 477);
            dataGridView.TabIndex = 4;
            dataGridView.CellFormatting += dataGridView_CellFormatting;
            // 
            // colID
            // 
            colID.DataPropertyName = "ID";
            colID.FillWeight = 88F;
            colID.HeaderText = "ID";
            colID.MinimumWidth = 6;
            colID.Name = "colID";
            // 
            // HoVaTen
            // 
            HoVaTen.DataPropertyName = "HoVaTen";
            HoVaTen.FillWeight = 110F;
            HoVaTen.HeaderText = "Họ và tên";
            HoVaTen.MinimumWidth = 6;
            HoVaTen.Name = "HoVaTen";
            // 
            // DienThoai
            // 
            DienThoai.DataPropertyName = "DienThoai";
            DienThoai.FillWeight = 111F;
            DienThoai.HeaderText = "Điện thoại";
            DienThoai.MinimumWidth = 6;
            DienThoai.Name = "DienThoai";
            // 
            // Diachi
            // 
            Diachi.DataPropertyName = "Diachi";
            Diachi.FillWeight = 200F;
            Diachi.HeaderText = "Địa chỉ";
            Diachi.MinimumWidth = 6;
            Diachi.Name = "Diachi";
            // 
            // TenDangNhap
            // 
            TenDangNhap.DataPropertyName = "TenDangNhap";
            TenDangNhap.FillWeight = 151F;
            TenDangNhap.HeaderText = "Tên đăng nhập";
            TenDangNhap.MinimumWidth = 6;
            TenDangNhap.Name = "TenDangNhap";
            // 
            // MatKhau
            // 
            MatKhau.DataPropertyName = "MatKhau";
            MatKhau.FillWeight = 151F;
            MatKhau.HeaderText = "Mật khẩu";
            MatKhau.MinimumWidth = 6;
            MatKhau.Name = "MatKhau";
            // 
            // QuyenHan
            // 
            QuyenHan.DataPropertyName = "QuyenHan";
            QuyenHan.FillWeight = 90F;
            QuyenHan.HeaderText = "Quyền Hạn";
            QuyenHan.MinimumWidth = 6;
            QuyenHan.Name = "QuyenHan";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 48);
            label1.Name = "label1";
            label1.Size = new Size(92, 20);
            label1.TabIndex = 0;
            label1.Text = "Họ và tên(*):";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(638, 44);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 1;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // txthovaten
            // 
            txthovaten.Location = new Point(108, 48);
            txthovaten.Name = "txthovaten";
            txthovaten.Size = new Size(204, 27);
            txthovaten.TabIndex = 2;
            // 
            // txtdiachi
            // 
            txtdiachi.Location = new Point(108, 121);
            txtdiachi.Name = "txtdiachi";
            txtdiachi.Size = new Size(204, 27);
            txtdiachi.TabIndex = 2;
            // 
            // txtdienthoai
            // 
            txtdienthoai.Location = new Point(108, 78);
            txtdienthoai.Name = "txtdienthoai";
            txtdienthoai.Size = new Size(204, 27);
            txtdienthoai.TabIndex = 2;
            // 
            // btnLuu
            // 
            btnLuu.ForeColor = Color.Blue;
            btnLuu.Location = new Point(736, 44);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 1;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 85);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 0;
            label3.Text = "Điện thoại:";
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(638, 117);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 1;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnTimkiem
            // 
            btnTimkiem.Location = new Point(846, 44);
            btnTimkiem.Name = "btnTimkiem";
            btnTimkiem.Size = new Size(94, 29);
            btnTimkiem.TabIndex = 1;
            btnTimkiem.Text = "Tìm kiếm";
            btnTimkiem.UseVisualStyleBackColor = true;
            btnTimkiem.Click += btnTimkiem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(638, 82);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnNhap
            // 
            btnNhap.Location = new Point(846, 82);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(94, 29);
            btnNhap.TabIndex = 1;
            btnNhap.Text = "Nhập...";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // btnHuybo
            // 
            btnHuybo.Location = new Point(736, 82);
            btnHuybo.Name = "btnHuybo";
            btnHuybo.Size = new Size(94, 29);
            btnHuybo.TabIndex = 1;
            btnHuybo.Text = "Hủy bỏ";
            btnHuybo.UseVisualStyleBackColor = true;
            btnHuybo.Click += btnHuybo_Click;
            // 
            // btnXuat
            // 
            btnXuat.Location = new Point(846, 117);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(94, 29);
            btnXuat.TabIndex = 1;
            btnXuat.Text = "Xuất...";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cobquyenhan);
            groupBox1.Controls.Add(txtdiachi);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtdienthoai);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(txtmatkhau);
            groupBox1.Controls.Add(txtTenDN);
            groupBox1.Controls.Add(txthovaten);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnTimkiem);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnNhap);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(btnHuybo);
            groupBox1.Controls.Add(btnXuat);
            groupBox1.Location = new Point(13, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(957, 169);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin nhân viên";
            // 
            // cobquyenhan
            // 
            cobquyenhan.FormattingEnabled = true;
            cobquyenhan.Items.AddRange(new object[] { "Quản lý", "Nhân viên" });
            cobquyenhan.Location = new Point(461, 118);
            cobquyenhan.Name = "cobquyenhan";
            cobquyenhan.Size = new Size(151, 28);
            cobquyenhan.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(332, 48);
            label6.Name = "label6";
            label6.Size = new Size(126, 20);
            label6.TabIndex = 0;
            label6.Text = "Tên đăng nhập(*):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(332, 85);
            label5.Name = "label5";
            label5.Size = new Size(89, 20);
            label5.TabIndex = 0;
            label5.Text = "Mật khẩu(*):";
            // 
            // txtmatkhau
            // 
            txtmatkhau.Location = new Point(461, 85);
            txtmatkhau.Name = "txtmatkhau";
            txtmatkhau.Size = new Size(155, 27);
            txtmatkhau.TabIndex = 2;
            // 
            // txtTenDN
            // 
            txtTenDN.Location = new Point(461, 48);
            txtTenDN.Name = "txtTenDN";
            txtTenDN.Size = new Size(155, 27);
            txtTenDN.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(332, 121);
            label4.Name = "label4";
            label4.Size = new Size(98, 20);
            label4.TabIndex = 0;
            label4.Text = "Quyền hạn(*):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 121);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 0;
            label2.Text = "Địa chỉ:";
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(736, 117);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 1;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // fmNhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(981, 702);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "fmNhanVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhân Viên";
            Load += fmNhanVien_Load;
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private DataGridView dataGridView;
        private Label label1;
        private Button btnThem;
        private TextBox txthovaten;
        private TextBox txtdiachi;
        private TextBox txtdienthoai;
        private Button btnLuu;
        private Label label3;
        private Button btnXoa;
        private Button btnTimkiem;
        private Button btnSua;
        private Button btnNhap;
        private Button btnHuybo;
        private Button btnXuat;
        private GroupBox groupBox1;
//        private TextBox textBox3;
        private Label label6;
  //       private TextBox textBox2;
        private Label label5;
        private TextBox txtTenDN;
        private Label label4;
        private Label label2;
        private Button btnThoat;
        private ComboBox cobquyenhan;
        private TextBox txtmatkhau;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn HoVaTen;
        private DataGridViewTextBoxColumn DienThoai;
        private DataGridViewTextBoxColumn Diachi;
        private DataGridViewTextBoxColumn TenDangNhap;
        private DataGridViewTextBoxColumn MatKhau;
        private DataGridViewTextBoxColumn QuyenHan;
    }
}