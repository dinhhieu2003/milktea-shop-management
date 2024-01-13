namespace QUANLYQUANTRASUA
{
    partial class frmQuanLyChucVu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabChinhSua = new System.Windows.Forms.TabPage();
            this.tabChinhSua_btnTroVe = new System.Windows.Forms.Button();
            this.tabChinhSua_btnThem = new System.Windows.Forms.Button();
            this.tabChinhSua_btnChinhSua = new System.Windows.Forms.Button();
            this.tabChinhSua_btnReload = new System.Windows.Forms.Button();
            this.tabChinhSua_dgvChucVu = new System.Windows.Forms.DataGridView();
            this.tabChinhSua_MaChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabChinhSua_TenChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabChinhSua_LuongMotGioLam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabChinhSua_SoLuongNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grBoxThongTinChucVu = new System.Windows.Forms.GroupBox();
            this.tabChinhSua_btnHuyBo = new System.Windows.Forms.Button();
            this.tabChinhSua_btnLuu = new System.Windows.Forms.Button();
            this.tabChinhSua_txtTenChucVu = new System.Windows.Forms.TextBox();
            this.tabChinhSua_txtLuongMotGio = new System.Windows.Forms.TextBox();
            this.tabChinhSua_txtMaChucVu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabTimKiem = new System.Windows.Forms.TabPage();
            this.tabTimKiem_Reload = new System.Windows.Forms.Button();
            this.tabTongHop_btnTimKiem = new System.Windows.Forms.Button();
            this.tabTimKiem_txtTenChucVu = new System.Windows.Forms.TextBox();
            this.tabTimKiem_txtTongSoBanGhi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabTimKiem_dgvChucVu = new System.Windows.Forms.DataGridView();
            this.MaChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LuongMotGioLam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabChinhSua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabChinhSua_dgvChucVu)).BeginInit();
            this.grBoxThongTinChucVu.SuspendLayout();
            this.tabTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabTimKiem_dgvChucVu)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabChinhSua);
            this.tabControl1.Controls.Add(this.tabTimKiem);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(809, 575);
            this.tabControl1.TabIndex = 0;
            // 
            // tabChinhSua
            // 
            this.tabChinhSua.Controls.Add(this.tabChinhSua_btnTroVe);
            this.tabChinhSua.Controls.Add(this.tabChinhSua_btnThem);
            this.tabChinhSua.Controls.Add(this.tabChinhSua_btnChinhSua);
            this.tabChinhSua.Controls.Add(this.tabChinhSua_btnReload);
            this.tabChinhSua.Controls.Add(this.tabChinhSua_dgvChucVu);
            this.tabChinhSua.Controls.Add(this.grBoxThongTinChucVu);
            this.tabChinhSua.Location = new System.Drawing.Point(4, 22);
            this.tabChinhSua.Name = "tabChinhSua";
            this.tabChinhSua.Padding = new System.Windows.Forms.Padding(3);
            this.tabChinhSua.Size = new System.Drawing.Size(801, 549);
            this.tabChinhSua.TabIndex = 0;
            this.tabChinhSua.Text = "Chỉnh sửa";
            this.tabChinhSua.UseVisualStyleBackColor = true;
            // 
            // tabChinhSua_btnTroVe
            // 
            this.tabChinhSua_btnTroVe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(170)))), ((int)(((byte)(242)))));
            this.tabChinhSua_btnTroVe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabChinhSua_btnTroVe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(92)))), ((int)(((byte)(101)))));
            this.tabChinhSua_btnTroVe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabChinhSua_btnTroVe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChinhSua_btnTroVe.ForeColor = System.Drawing.Color.White;
            this.tabChinhSua_btnTroVe.Location = new System.Drawing.Point(691, 484);
            this.tabChinhSua_btnTroVe.Name = "tabChinhSua_btnTroVe";
            this.tabChinhSua_btnTroVe.Size = new System.Drawing.Size(93, 31);
            this.tabChinhSua_btnTroVe.TabIndex = 120;
            this.tabChinhSua_btnTroVe.Text = "Trở về";
            this.tabChinhSua_btnTroVe.UseVisualStyleBackColor = false;
            this.tabChinhSua_btnTroVe.Click += new System.EventHandler(this.tabChinhSua_btnTroVe_Click);
            // 
            // tabChinhSua_btnThem
            // 
            this.tabChinhSua_btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(170)))), ((int)(((byte)(242)))));
            this.tabChinhSua_btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabChinhSua_btnThem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(92)))), ((int)(((byte)(101)))));
            this.tabChinhSua_btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabChinhSua_btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChinhSua_btnThem.ForeColor = System.Drawing.Color.White;
            this.tabChinhSua_btnThem.Location = new System.Drawing.Point(406, 484);
            this.tabChinhSua_btnThem.Name = "tabChinhSua_btnThem";
            this.tabChinhSua_btnThem.Size = new System.Drawing.Size(93, 31);
            this.tabChinhSua_btnThem.TabIndex = 122;
            this.tabChinhSua_btnThem.Text = "Thêm";
            this.tabChinhSua_btnThem.UseVisualStyleBackColor = false;
            this.tabChinhSua_btnThem.Click += new System.EventHandler(this.tabChinhSua_btnThem_Click);
            // 
            // tabChinhSua_btnChinhSua
            // 
            this.tabChinhSua_btnChinhSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(170)))), ((int)(((byte)(242)))));
            this.tabChinhSua_btnChinhSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabChinhSua_btnChinhSua.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(92)))), ((int)(((byte)(101)))));
            this.tabChinhSua_btnChinhSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabChinhSua_btnChinhSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChinhSua_btnChinhSua.ForeColor = System.Drawing.Color.White;
            this.tabChinhSua_btnChinhSua.Location = new System.Drawing.Point(546, 484);
            this.tabChinhSua_btnChinhSua.Name = "tabChinhSua_btnChinhSua";
            this.tabChinhSua_btnChinhSua.Size = new System.Drawing.Size(93, 31);
            this.tabChinhSua_btnChinhSua.TabIndex = 124;
            this.tabChinhSua_btnChinhSua.Text = "Chỉnh sửa";
            this.tabChinhSua_btnChinhSua.UseVisualStyleBackColor = false;
            this.tabChinhSua_btnChinhSua.Click += new System.EventHandler(this.tabChinhSua_btnChinhSua_Click);
            // 
            // tabChinhSua_btnReload
            // 
            this.tabChinhSua_btnReload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(170)))), ((int)(((byte)(242)))));
            this.tabChinhSua_btnReload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabChinhSua_btnReload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(92)))), ((int)(((byte)(101)))));
            this.tabChinhSua_btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabChinhSua_btnReload.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChinhSua_btnReload.ForeColor = System.Drawing.Color.White;
            this.tabChinhSua_btnReload.Location = new System.Drawing.Point(270, 484);
            this.tabChinhSua_btnReload.Name = "tabChinhSua_btnReload";
            this.tabChinhSua_btnReload.Size = new System.Drawing.Size(93, 31);
            this.tabChinhSua_btnReload.TabIndex = 125;
            this.tabChinhSua_btnReload.Text = "Reload";
            this.tabChinhSua_btnReload.UseVisualStyleBackColor = false;
            this.tabChinhSua_btnReload.Click += new System.EventHandler(this.tabChinhSua_btnReload_Click);
            // 
            // tabChinhSua_dgvChucVu
            // 
            this.tabChinhSua_dgvChucVu.AllowUserToAddRows = false;
            this.tabChinhSua_dgvChucVu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(118)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tabChinhSua_dgvChucVu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tabChinhSua_dgvChucVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabChinhSua_dgvChucVu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tabChinhSua_MaChucVu,
            this.tabChinhSua_TenChucVu,
            this.tabChinhSua_LuongMotGioLam,
            this.tabChinhSua_SoLuongNhanVien});
            this.tabChinhSua_dgvChucVu.Location = new System.Drawing.Point(8, 157);
            this.tabChinhSua_dgvChucVu.Name = "tabChinhSua_dgvChucVu";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tabChinhSua_dgvChucVu.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChinhSua_dgvChucVu.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.tabChinhSua_dgvChucVu.Size = new System.Drawing.Size(776, 311);
            this.tabChinhSua_dgvChucVu.TabIndex = 119;
            this.tabChinhSua_dgvChucVu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabChinhSua_dgvChucVu_CellClick);
            // 
            // tabChinhSua_MaChucVu
            // 
            this.tabChinhSua_MaChucVu.DataPropertyName = "MaChucVu";
            this.tabChinhSua_MaChucVu.HeaderText = "Mã chức vụ";
            this.tabChinhSua_MaChucVu.Name = "tabChinhSua_MaChucVu";
            this.tabChinhSua_MaChucVu.Width = 180;
            // 
            // tabChinhSua_TenChucVu
            // 
            this.tabChinhSua_TenChucVu.DataPropertyName = "TenChucVu";
            this.tabChinhSua_TenChucVu.HeaderText = "Tên chức vụ";
            this.tabChinhSua_TenChucVu.Name = "tabChinhSua_TenChucVu";
            this.tabChinhSua_TenChucVu.Width = 180;
            // 
            // tabChinhSua_LuongMotGioLam
            // 
            this.tabChinhSua_LuongMotGioLam.DataPropertyName = "LuongMotGioLam";
            this.tabChinhSua_LuongMotGioLam.HeaderText = "Lương một giờ làm";
            this.tabChinhSua_LuongMotGioLam.Name = "tabChinhSua_LuongMotGioLam";
            this.tabChinhSua_LuongMotGioLam.Width = 195;
            // 
            // tabChinhSua_SoLuongNhanVien
            // 
            this.tabChinhSua_SoLuongNhanVien.DataPropertyName = "SoLuongNhanVien";
            this.tabChinhSua_SoLuongNhanVien.HeaderText = "Số lượng nhân viên";
            this.tabChinhSua_SoLuongNhanVien.Name = "tabChinhSua_SoLuongNhanVien";
            this.tabChinhSua_SoLuongNhanVien.Width = 180;
            // 
            // grBoxThongTinChucVu
            // 
            this.grBoxThongTinChucVu.Controls.Add(this.tabChinhSua_btnHuyBo);
            this.grBoxThongTinChucVu.Controls.Add(this.tabChinhSua_btnLuu);
            this.grBoxThongTinChucVu.Controls.Add(this.tabChinhSua_txtTenChucVu);
            this.grBoxThongTinChucVu.Controls.Add(this.tabChinhSua_txtLuongMotGio);
            this.grBoxThongTinChucVu.Controls.Add(this.tabChinhSua_txtMaChucVu);
            this.grBoxThongTinChucVu.Controls.Add(this.label8);
            this.grBoxThongTinChucVu.Controls.Add(this.label11);
            this.grBoxThongTinChucVu.Controls.Add(this.label12);
            this.grBoxThongTinChucVu.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grBoxThongTinChucVu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.grBoxThongTinChucVu.Location = new System.Drawing.Point(8, 18);
            this.grBoxThongTinChucVu.Name = "grBoxThongTinChucVu";
            this.grBoxThongTinChucVu.Size = new System.Drawing.Size(776, 133);
            this.grBoxThongTinChucVu.TabIndex = 118;
            this.grBoxThongTinChucVu.TabStop = false;
            this.grBoxThongTinChucVu.Text = "Thông tin chức vụ";
            // 
            // tabChinhSua_btnHuyBo
            // 
            this.tabChinhSua_btnHuyBo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(170)))), ((int)(((byte)(242)))));
            this.tabChinhSua_btnHuyBo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabChinhSua_btnHuyBo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(92)))), ((int)(((byte)(101)))));
            this.tabChinhSua_btnHuyBo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabChinhSua_btnHuyBo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChinhSua_btnHuyBo.ForeColor = System.Drawing.Color.White;
            this.tabChinhSua_btnHuyBo.Location = new System.Drawing.Point(667, 84);
            this.tabChinhSua_btnHuyBo.Name = "tabChinhSua_btnHuyBo";
            this.tabChinhSua_btnHuyBo.Size = new System.Drawing.Size(93, 31);
            this.tabChinhSua_btnHuyBo.TabIndex = 131;
            this.tabChinhSua_btnHuyBo.Text = "Hủy bỏ";
            this.tabChinhSua_btnHuyBo.UseVisualStyleBackColor = false;
            this.tabChinhSua_btnHuyBo.Click += new System.EventHandler(this.tabChinhSua_btnHuyBo_Click);
            // 
            // tabChinhSua_btnLuu
            // 
            this.tabChinhSua_btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(170)))), ((int)(((byte)(242)))));
            this.tabChinhSua_btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabChinhSua_btnLuu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(92)))), ((int)(((byte)(101)))));
            this.tabChinhSua_btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabChinhSua_btnLuu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChinhSua_btnLuu.ForeColor = System.Drawing.Color.White;
            this.tabChinhSua_btnLuu.Location = new System.Drawing.Point(538, 84);
            this.tabChinhSua_btnLuu.Name = "tabChinhSua_btnLuu";
            this.tabChinhSua_btnLuu.Size = new System.Drawing.Size(93, 31);
            this.tabChinhSua_btnLuu.TabIndex = 121;
            this.tabChinhSua_btnLuu.Text = "Lưu";
            this.tabChinhSua_btnLuu.UseVisualStyleBackColor = false;
            this.tabChinhSua_btnLuu.Click += new System.EventHandler(this.tabChinhSua_btnLuu_Click);
            // 
            // tabChinhSua_txtTenChucVu
            // 
            this.tabChinhSua_txtTenChucVu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChinhSua_txtTenChucVu.Location = new System.Drawing.Point(120, 87);
            this.tabChinhSua_txtTenChucVu.Name = "tabChinhSua_txtTenChucVu";
            this.tabChinhSua_txtTenChucVu.Size = new System.Drawing.Size(222, 26);
            this.tabChinhSua_txtTenChucVu.TabIndex = 6;
            // 
            // tabChinhSua_txtLuongMotGio
            // 
            this.tabChinhSua_txtLuongMotGio.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChinhSua_txtLuongMotGio.Location = new System.Drawing.Point(538, 33);
            this.tabChinhSua_txtLuongMotGio.Name = "tabChinhSua_txtLuongMotGio";
            this.tabChinhSua_txtLuongMotGio.Size = new System.Drawing.Size(222, 26);
            this.tabChinhSua_txtLuongMotGio.TabIndex = 6;
            // 
            // tabChinhSua_txtMaChucVu
            // 
            this.tabChinhSua_txtMaChucVu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChinhSua_txtMaChucVu.Location = new System.Drawing.Point(120, 34);
            this.tabChinhSua_txtMaChucVu.Name = "tabChinhSua_txtMaChucVu";
            this.tabChinhSua_txtMaChucVu.Size = new System.Drawing.Size(222, 26);
            this.tabChinhSua_txtMaChucVu.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(396, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 19);
            this.label8.TabIndex = 5;
            this.label8.Text = "Lương một giờ làm";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(10, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 19);
            this.label11.TabIndex = 1;
            this.label11.Text = "Tên chức vụ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(10, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 19);
            this.label12.TabIndex = 0;
            this.label12.Text = "Mã chức vụ";
            // 
            // tabTimKiem
            // 
            this.tabTimKiem.Controls.Add(this.tabTimKiem_Reload);
            this.tabTimKiem.Controls.Add(this.tabTongHop_btnTimKiem);
            this.tabTimKiem.Controls.Add(this.tabTimKiem_txtTenChucVu);
            this.tabTimKiem.Controls.Add(this.tabTimKiem_txtTongSoBanGhi);
            this.tabTimKiem.Controls.Add(this.label3);
            this.tabTimKiem.Controls.Add(this.label4);
            this.tabTimKiem.Controls.Add(this.tabTimKiem_dgvChucVu);
            this.tabTimKiem.Location = new System.Drawing.Point(4, 22);
            this.tabTimKiem.Name = "tabTimKiem";
            this.tabTimKiem.Padding = new System.Windows.Forms.Padding(3);
            this.tabTimKiem.Size = new System.Drawing.Size(801, 549);
            this.tabTimKiem.TabIndex = 1;
            this.tabTimKiem.Text = "Tìm kiếm";
            this.tabTimKiem.UseVisualStyleBackColor = true;
            // 
            // tabTimKiem_Reload
            // 
            this.tabTimKiem_Reload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(170)))), ((int)(((byte)(242)))));
            this.tabTimKiem_Reload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabTimKiem_Reload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(92)))), ((int)(((byte)(101)))));
            this.tabTimKiem_Reload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabTimKiem_Reload.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTimKiem_Reload.ForeColor = System.Drawing.Color.White;
            this.tabTimKiem_Reload.Location = new System.Drawing.Point(416, 9);
            this.tabTimKiem_Reload.Name = "tabTimKiem_Reload";
            this.tabTimKiem_Reload.Size = new System.Drawing.Size(93, 32);
            this.tabTimKiem_Reload.TabIndex = 61;
            this.tabTimKiem_Reload.Text = "Reload";
            this.tabTimKiem_Reload.UseVisualStyleBackColor = false;
            this.tabTimKiem_Reload.Click += new System.EventHandler(this.tabTimKiem_Reload_Click);
            // 
            // tabTongHop_btnTimKiem
            // 
            this.tabTongHop_btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(170)))), ((int)(((byte)(242)))));
            this.tabTongHop_btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabTongHop_btnTimKiem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(92)))), ((int)(((byte)(101)))));
            this.tabTongHop_btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabTongHop_btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTongHop_btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.tabTongHop_btnTimKiem.Location = new System.Drawing.Point(289, 9);
            this.tabTongHop_btnTimKiem.Name = "tabTongHop_btnTimKiem";
            this.tabTongHop_btnTimKiem.Size = new System.Drawing.Size(93, 32);
            this.tabTongHop_btnTimKiem.TabIndex = 61;
            this.tabTongHop_btnTimKiem.Text = "Tìm kiếm";
            this.tabTongHop_btnTimKiem.UseVisualStyleBackColor = false;
            this.tabTongHop_btnTimKiem.Click += new System.EventHandler(this.tabTongHop_btnTimKiem_Click);
            // 
            // tabTimKiem_txtTenChucVu
            // 
            this.tabTimKiem_txtTenChucVu.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTimKiem_txtTenChucVu.Location = new System.Drawing.Point(119, 13);
            this.tabTimKiem_txtTenChucVu.Name = "tabTimKiem_txtTenChucVu";
            this.tabTimKiem_txtTenChucVu.Size = new System.Drawing.Size(141, 26);
            this.tabTimKiem_txtTenChucVu.TabIndex = 58;
            // 
            // tabTimKiem_txtTongSoBanGhi
            // 
            this.tabTimKiem_txtTongSoBanGhi.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTimKiem_txtTongSoBanGhi.Location = new System.Drawing.Point(626, 288);
            this.tabTimKiem_txtTongSoBanGhi.Name = "tabTimKiem_txtTongSoBanGhi";
            this.tabTimKiem_txtTongSoBanGhi.Size = new System.Drawing.Size(100, 26);
            this.tabTimKiem_txtTongSoBanGhi.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(495, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 19);
            this.label3.TabIndex = 54;
            this.label3.Text = "Tổng số bản ghi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 52;
            this.label4.Text = "Tên chức vụ:";
            // 
            // tabTimKiem_dgvChucVu
            // 
            this.tabTimKiem_dgvChucVu.AllowUserToAddRows = false;
            this.tabTimKiem_dgvChucVu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(118)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tabTimKiem_dgvChucVu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.tabTimKiem_dgvChucVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabTimKiem_dgvChucVu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaChucVu,
            this.TenChucVu,
            this.LuongMotGioLam,
            this.SoLuongNhanVien});
            this.tabTimKiem_dgvChucVu.Location = new System.Drawing.Point(6, 62);
            this.tabTimKiem_dgvChucVu.Name = "tabTimKiem_dgvChucVu";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTimKiem_dgvChucVu.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.tabTimKiem_dgvChucVu.Size = new System.Drawing.Size(720, 210);
            this.tabTimKiem_dgvChucVu.TabIndex = 47;
            // 
            // MaChucVu
            // 
            this.MaChucVu.DataPropertyName = "MaChucVu";
            this.MaChucVu.HeaderText = "Mã chức vụ";
            this.MaChucVu.Name = "MaChucVu";
            this.MaChucVu.Width = 170;
            // 
            // TenChucVu
            // 
            this.TenChucVu.DataPropertyName = "TenChucVu";
            this.TenChucVu.HeaderText = "Tên chức vụ";
            this.TenChucVu.Name = "TenChucVu";
            this.TenChucVu.Width = 170;
            // 
            // LuongMotGioLam
            // 
            this.LuongMotGioLam.DataPropertyName = "LuongMotGioLam";
            this.LuongMotGioLam.HeaderText = "Lương một giờ làm";
            this.LuongMotGioLam.Name = "LuongMotGioLam";
            this.LuongMotGioLam.Width = 170;
            // 
            // SoLuongNhanVien
            // 
            this.SoLuongNhanVien.DataPropertyName = "SoLuongNhanVien";
            this.SoLuongNhanVien.HeaderText = "Số lượng nhân viên";
            this.SoLuongNhanVien.Name = "SoLuongNhanVien";
            this.SoLuongNhanVien.Width = 170;
            // 
            // frmQuanLyChucVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(809, 575);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmQuanLyChucVu";
            this.Text = "frmQuanLyChucVu";
            this.Load += new System.EventHandler(this.frmQuanLyChucVu_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabChinhSua.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabChinhSua_dgvChucVu)).EndInit();
            this.grBoxThongTinChucVu.ResumeLayout(false);
            this.grBoxThongTinChucVu.PerformLayout();
            this.tabTimKiem.ResumeLayout(false);
            this.tabTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabTimKiem_dgvChucVu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabChinhSua;
        private System.Windows.Forms.TabPage tabTimKiem;
        private System.Windows.Forms.TextBox tabTimKiem_txtTongSoBanGhi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView tabTimKiem_dgvChucVu;
        private System.Windows.Forms.DataGridView tabChinhSua_dgvChucVu;
        private System.Windows.Forms.GroupBox grBoxThongTinChucVu;
        private System.Windows.Forms.TextBox tabChinhSua_txtTenChucVu;
        private System.Windows.Forms.TextBox tabChinhSua_txtLuongMotGio;
        private System.Windows.Forms.TextBox tabChinhSua_txtMaChucVu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabChinhSua_MaChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabChinhSua_TenChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabChinhSua_LuongMotGioLam;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabChinhSua_SoLuongNhanVien;
        private System.Windows.Forms.Button tabChinhSua_btnTroVe;
        private System.Windows.Forms.Button tabChinhSua_btnLuu;
        private System.Windows.Forms.Button tabChinhSua_btnThem;
        private System.Windows.Forms.Button tabChinhSua_btnChinhSua;
        private System.Windows.Forms.Button tabChinhSua_btnReload;
        private System.Windows.Forms.Button tabChinhSua_btnHuyBo;
        private System.Windows.Forms.TextBox tabTimKiem_txtTenChucVu;
        private System.Windows.Forms.Button tabTongHop_btnTimKiem;
        private System.Windows.Forms.Button tabTimKiem_Reload;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn LuongMotGioLam;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongNhanVien;
    }
}