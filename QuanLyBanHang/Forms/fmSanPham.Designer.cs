namespace QuanLyBanHang.Forms
{
    public partial class fmSanPham
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            label1 = new Label();
            groupBox1 = new GroupBox();
            btnXoay = new Button();
            btnDoiAnh = new Button();
            btnXuat = new Button();
            btnNhap = new Button();
            btnTimKiem = new Button();
            btnLuu = new Button();
            btnThoat = new Button();
            btnXoa = new Button();
            btnHuybo = new Button();
            btnSua = new Button();
            btnThem = new Button();
            cobHSX = new ComboBox();
            cobPL = new ComboBox();
            txtMT = new TextBox();
            txtTSP = new TextBox();
            picHinhAnh = new PictureBox();
            label6 = new Label();
            label4 = new Label();
            label2 = new Label();
            numDG = new NumericUpDown();
            numSL = new NumericUpDown();
            label5 = new Label();
            label3 = new Label();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            PhanLoai = new DataGridViewTextBoxColumn();
            TenHangSanPham = new DataGridViewTextBoxColumn();
            TenSanPham = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            DonGia = new DataGridViewTextBoxColumn();
            HinhAnh = new DataGridViewImageColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSL).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 152);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên sản phẩm(*):";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnXoay);
            groupBox1.Controls.Add(btnDoiAnh);
            groupBox1.Controls.Add(btnXuat);
            groupBox1.Controls.Add(btnNhap);
            groupBox1.Controls.Add(btnTimKiem);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnHuybo);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(cobHSX);
            groupBox1.Controls.Add(cobPL);
            groupBox1.Controls.Add(txtMT);
            groupBox1.Controls.Add(txtTSP);
            groupBox1.Controls.Add(picHinhAnh);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(numDG);
            groupBox1.Controls.Add(numSL);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(2, 4);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(1198, 295);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sản phẩm";
            // 
            // btnXoay
            // 
            btnXoay.Location = new Point(978, 104);
            btnXoay.Name = "btnXoay";
            btnXoay.Size = new Size(88, 45);
            btnXoay.TabIndex = 6;
            btnXoay.Text = "Xoay ảnh";
            btnXoay.UseVisualStyleBackColor = true;
            btnXoay.Click += btnXoay_Click;
            // 
            // btnDoiAnh
            // 
            btnDoiAnh.Location = new Point(978, 45);
            btnDoiAnh.Margin = new Padding(3, 4, 3, 4);
            btnDoiAnh.Name = "btnDoiAnh";
            btnDoiAnh.Size = new Size(88, 45);
            btnDoiAnh.TabIndex = 5;
            btnDoiAnh.Text = "Đổi ảnh";
            btnDoiAnh.UseVisualStyleBackColor = true;
            btnDoiAnh.Click += btnDoiAnh_Click;
            // 
            // btnXuat
            // 
            btnXuat.Location = new Point(921, 249);
            btnXuat.Margin = new Padding(3, 4, 3, 4);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(86, 31);
            btnXuat.TabIndex = 5;
            btnXuat.Text = "Xuất...";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // btnNhap
            // 
            btnNhap.Location = new Point(827, 249);
            btnNhap.Margin = new Padding(3, 4, 3, 4);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(86, 31);
            btnNhap.TabIndex = 5;
            btnNhap.Text = "Nhập...";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(725, 249);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(86, 31);
            btnTimKiem.TabIndex = 5;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(415, 249);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(86, 31);
            btnLuu.TabIndex = 5;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(621, 249);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(86, 31);
            btnThoat.TabIndex = 5;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(312, 249);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(86, 31);
            btnXoa.TabIndex = 5;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnHuybo
            // 
            btnHuybo.Location = new Point(519, 251);
            btnHuybo.Margin = new Padding(3, 4, 3, 4);
            btnHuybo.Name = "btnHuybo";
            btnHuybo.Size = new Size(86, 31);
            btnHuybo.TabIndex = 5;
            btnHuybo.Text = "Hủy bỏ";
            btnHuybo.UseVisualStyleBackColor = true;
            btnHuybo.Click += btnHuybo_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(208, 249);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(86, 31);
            btnSua.TabIndex = 5;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(115, 249);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(86, 31);
            btnThem.TabIndex = 5;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // cobHSX
            // 
            cobHSX.DropDownStyle = ComboBoxStyle.DropDownList;
            cobHSX.Enabled = false;
            cobHSX.FormattingEnabled = true;
            cobHSX.Items.AddRange(new object[] { "Apple", "SamSung", "Xiaomi" });
            cobHSX.Location = new Point(156, 100);
            cobHSX.Margin = new Padding(3, 4, 3, 4);
            cobHSX.Name = "cobHSX";
            cobHSX.Size = new Size(159, 28);
            cobHSX.TabIndex = 4;
            // 
            // cobPL
            // 
            cobPL.DropDownStyle = ComboBoxStyle.DropDownList;
            cobPL.Enabled = false;
            cobPL.FormattingEnabled = true;
            cobPL.Items.AddRange(new object[] { "Điện Thoại", "Tai Nghe", "Taplate", "IPad" });
            cobPL.Location = new Point(156, 52);
            cobPL.Margin = new Padding(3, 4, 3, 4);
            cobPL.Name = "cobPL";
            cobPL.Size = new Size(159, 28);
            cobPL.TabIndex = 4;
            // 
            // txtMT
            // 
            txtMT.Location = new Point(156, 200);
            txtMT.Margin = new Padding(3, 4, 3, 4);
            txtMT.Name = "txtMT";
            txtMT.Size = new Size(416, 27);
            txtMT.TabIndex = 3;
            // 
            // txtTSP
            // 
            txtTSP.Location = new Point(156, 152);
            txtTSP.Margin = new Padding(3, 4, 3, 4);
            txtTSP.Name = "txtTSP";
            txtTSP.Size = new Size(416, 27);
            txtTSP.TabIndex = 3;
            // 
            // picHinhAnh
            // 
            picHinhAnh.BackColor = Color.White;
            picHinhAnh.Location = new Point(760, 29);
            picHinhAnh.Margin = new Padding(3, 4, 3, 4);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(177, 201);
            picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            picHinhAnh.TabIndex = 2;
            picHinhAnh.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(350, 100);
            label6.Name = "label6";
            label6.Size = new Size(81, 20);
            label6.TabIndex = 0;
            label6.Text = "Đơn giá(*):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 104);
            label4.Name = "label4";
            label4.Size = new Size(122, 20);
            label4.TabIndex = 0;
            label4.Text = "Hãng sản xuất(*):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 201);
            label2.Name = "label2";
            label2.Size = new Size(119, 20);
            label2.TabIndex = 0;
            label2.Text = "Mô tả sản phẩm:";
            // 
            // numDG
            // 
            numDG.Location = new Point(435, 99);
            numDG.Margin = new Padding(3, 4, 3, 4);
            numDG.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numDG.Name = "numDG";
            numDG.Size = new Size(137, 27);
            numDG.TabIndex = 1;
            numDG.ThousandsSeparator = true;
            // 
            // numSL
            // 
            numSL.Location = new Point(435, 48);
            numSL.Margin = new Padding(3, 4, 3, 4);
            numSL.Name = "numSL";
            numSL.Size = new Size(137, 27);
            numSL.TabIndex = 1;
            numSL.ThousandsSeparator = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(350, 52);
            label5.Name = "label5";
            label5.Size = new Size(88, 20);
            label5.TabIndex = 0;
            label5.Text = "Số lượng(*):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 55);
            label3.Name = "label3";
            label3.Size = new Size(89, 20);
            label3.TabIndex = 0;
            label3.Text = "Phân loại(*):";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(4, 307);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(1196, 546);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách sản phẩm";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colID, PhanLoai, TenHangSanPham, TenSanPham, SoLuong, DonGia, HinhAnh });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 24);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1190, 518);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting_1;
            // 
            // colID
            // 
            colID.DataPropertyName = "ID";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colID.DefaultCellStyle = dataGridViewCellStyle1;
            colID.FillWeight = 37F;
            colID.HeaderText = "ID";
            colID.MinimumWidth = 6;
            colID.Name = "colID";
            colID.ReadOnly = true;
            // 
            // PhanLoai
            // 
            PhanLoai.DataPropertyName = "TenLoai";
            PhanLoai.FillWeight = 54.2780762F;
            PhanLoai.HeaderText = "Phân loại";
            PhanLoai.MinimumWidth = 6;
            PhanLoai.Name = "PhanLoai";
            PhanLoai.ReadOnly = true;
            // 
            // TenHangSanPham
            // 
            TenHangSanPham.DataPropertyName = "TenHangSanXuat";
            TenHangSanPham.FillWeight = 54.2780762F;
            TenHangSanPham.HeaderText = "Hãng Sản Xuất";
            TenHangSanPham.MinimumWidth = 6;
            TenHangSanPham.Name = "TenHangSanPham";
            TenHangSanPham.ReadOnly = true;
            // 
            // TenSanPham
            // 
            TenSanPham.DataPropertyName = "TenSanPham";
            TenSanPham.FillWeight = 70.2780762F;
            TenSanPham.HeaderText = "Sản Phẩm";
            TenSanPham.MinimumWidth = 6;
            TenSanPham.Name = "TenSanPham";
            TenSanPham.ReadOnly = true;
            // 
            // SoLuong
            // 
            SoLuong.DataPropertyName = "SoLuong";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            SoLuong.DefaultCellStyle = dataGridViewCellStyle2;
            SoLuong.FillWeight = 54.2780762F;
            SoLuong.HeaderText = "Số lượng";
            SoLuong.MinimumWidth = 6;
            SoLuong.Name = "SoLuong";
            SoLuong.ReadOnly = true;
            // 
            // DonGia
            // 
            DonGia.DataPropertyName = "DonGia";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            DonGia.DefaultCellStyle = dataGridViewCellStyle3;
            DonGia.FillWeight = 54.2780762F;
            DonGia.HeaderText = "Đơn giá";
            DonGia.MinimumWidth = 6;
            DonGia.Name = "DonGia";
            DonGia.ReadOnly = true;
            // 
            // HinhAnh
            // 
            HinhAnh.DataPropertyName = "HinhAnh";
            HinhAnh.FillWeight = 54.2780762F;
            HinhAnh.HeaderText = "Hình ảnh";
            HinhAnh.ImageLayout = DataGridViewImageCellLayout.Zoom;
            HinhAnh.MinimumWidth = 6;
            HinhAnh.Name = "HinhAnh";
            HinhAnh.ReadOnly = true;
            HinhAnh.Resizable = DataGridViewTriState.True;
            HinhAnh.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // fmSanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1201, 855);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "fmSanPham";
            Text = "SanPham";
            Load += fmSanPham_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDG).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSL).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;

        private ComboBox cobHSX;
        private ComboBox cobPL;
        private TextBox txtMT;
        private TextBox txtTSP;
        private PictureBox picHinhAnh;
        private Label label4;
        private Label label2;
        private NumericUpDown numSL;
        private Label label3;
        private Button btnDoiAnh;
        private Button btnXuat;
        private Button btnNhap;
        private Button btnTimKiem;
        private Button btnLuu;
        private Button btnThoat;
        private Button btnXoa;
        private Button btnHuybo;
        private Button btnSua;
        private Button btnThem;
        private Label label6;
        private NumericUpDown numDG;
        private Label label5;
        private Button btnXoay;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn PhanLoai;
        private DataGridViewTextBoxColumn TenHangSanPham;
        private DataGridViewTextBoxColumn TenSanPham;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn DonGia;
        private DataGridViewImageColumn HinhAnh;
    }
}