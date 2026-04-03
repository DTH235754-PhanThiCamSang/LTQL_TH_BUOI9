namespace QuanLyBanHang.Forms
{
    partial class fmKhachHang
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
            label1 = new Label();
            btnThem = new Button();
            txthovaten = new TextBox();
            groupBox1 = new GroupBox();
            txtdiachi = new TextBox();
            txtdienthoai = new TextBox();
            btnLuu = new Button();
            label3 = new Label();
            btnXoa = new Button();
            btnTimkiem = new Button();
            label2 = new Label();
            btnSua = new Button();
            btnNhap = new Button();
            btnThoat = new Button();
            btnHuybo = new Button();
            btnXuat = new Button();
            dataGridView = new DataGridView();
            cotID = new DataGridViewTextBoxColumn();
            HoVaTen = new DataGridViewTextBoxColumn();
            DienThoai = new DataGridViewTextBoxColumn();
            Diachi = new DataGridViewTextBoxColumn();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
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
            btnThem.Location = new Point(634, 19);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 1;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // txthovaten
            // 
            txthovaten.Location = new Point(108, 45);
            txthovaten.Name = "txthovaten";
            txthovaten.Size = new Size(188, 27);
            txthovaten.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtdiachi);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtdienthoai);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(txthovaten);
            groupBox1.Controls.Add(btnTimkiem);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnNhap);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(btnHuybo);
            groupBox1.Controls.Add(btnXuat);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(957, 142);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin khách hàng";
            // 
            // txtdiachi
            // 
            txtdiachi.Location = new Point(108, 94);
            txtdiachi.Name = "txtdiachi";
            txtdiachi.Size = new Size(496, 27);
            txtdiachi.TabIndex = 2;
            // 
            // txtdienthoai
            // 
            txtdienthoai.Location = new Point(416, 48);
            txtdienthoai.Name = "txtdienthoai";
            txtdienthoai.Size = new Size(188, 27);
            txtdienthoai.TabIndex = 2;
            // 
            // btnLuu
            // 
            btnLuu.ForeColor = Color.Blue;
            btnLuu.Location = new Point(732, 19);
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
            label3.Location = new Point(329, 51);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 0;
            label3.Text = "Điện thoại:";
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(634, 92);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 1;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnTimkiem
            // 
            btnTimkiem.Location = new Point(842, 19);
            btnTimkiem.Name = "btnTimkiem";
            btnTimkiem.Size = new Size(94, 29);
            btnTimkiem.TabIndex = 1;
            btnTimkiem.Text = "Tìm kiếm";
            btnTimkiem.UseVisualStyleBackColor = true;
            btnTimkiem.Click += btnTimkiem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 92);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 0;
            label2.Text = "Địa chỉ:";
            // 
            // btnSua
            // 
            btnSua.Location = new Point(634, 57);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnNhap
            // 
            btnNhap.Location = new Point(842, 57);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(94, 29);
            btnNhap.TabIndex = 1;
            btnNhap.Text = "Nhập...";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(732, 92);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 1;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnHuybo
            // 
            btnHuybo.Location = new Point(732, 57);
            btnHuybo.Name = "btnHuybo";
            btnHuybo.Size = new Size(94, 29);
            btnHuybo.TabIndex = 1;
            btnHuybo.Text = "Hủy bỏ";
            btnHuybo.UseVisualStyleBackColor = true;
            btnHuybo.Click += btnHuybo_Click;
            // 
            // btnXuat
            // 
            btnXuat.Location = new Point(842, 92);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(94, 29);
            btnXuat.TabIndex = 1;
            btnXuat.Text = "Xuất...";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { cotID, HoVaTen, DienThoai, Diachi });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 23);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(944, 492);
            dataGridView.TabIndex = 4;
            // 
            // cotID
            // 
            cotID.DataPropertyName = "ID";
            cotID.HeaderText = "ID";
            cotID.MinimumWidth = 6;
            cotID.Name = "cotID";
            // 
            // HoVaTen
            // 
            HoVaTen.DataPropertyName = "HoVaTen";
            HoVaTen.HeaderText = "Họ và tên";
            HoVaTen.MinimumWidth = 6;
            HoVaTen.Name = "HoVaTen";
            // 
            // DienThoai
            // 
            DienThoai.DataPropertyName = "DienThoai";
            DienThoai.HeaderText = "Điện thoại";
            DienThoai.MinimumWidth = 6;
            DienThoai.Name = "DienThoai";
            // 
            // Diachi
            // 
            Diachi.DataPropertyName = "Diachi";
            Diachi.HeaderText = "Địa chỉ";
            Diachi.MinimumWidth = 6;
            Diachi.Name = "Diachi";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView);
            groupBox2.Location = new Point(19, 172);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(950, 518);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dabh sách khách hàng";
            // 
            // fmKhachHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(976, 702);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "fmKhachHang";
            Text = "fmKhachHang";
            Load += fmKhachHang_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button btnThem;
        private TextBox txthovaten;
        private GroupBox groupBox1;
        private DataGridView dataGridView;
        private Label label2;
        private TextBox txtdiachi;
        private Label label3;
        private TextBox txtdienthoai;
        private Button btnLuu;
        private Button btnSua;
        private Button btnHuybo;
        private Button btnXoa;
        private Button btnThoat;
        private Button btnTimkiem;
        private Button btnNhap;
        private Button btnXuat;
        private GroupBox groupBox2;
        private DataGridViewTextBoxColumn cotID;
        private DataGridViewTextBoxColumn HoVaTen;
        private DataGridViewTextBoxColumn DienThoai;
        private DataGridViewTextBoxColumn Diachi;
    }
}