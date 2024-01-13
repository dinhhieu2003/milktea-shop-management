namespace QUANLYQUANTRASUA
{
    partial class frmQuanLyCaLam
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabChinhSua = new System.Windows.Forms.TabPage();
            this.tabChinhSua_dgvCaLam = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabChinhSua_MaLoaiCa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grBoxThongTinCaLam = new System.Windows.Forms.GroupBox();
            this.tabChinhSua_btnHuyBo = new System.Windows.Forms.Button();
            this.tabChinhSua_dtpNgayLam = new System.Windows.Forms.DateTimePicker();
            this.tabChinhSua_cbxMaLoaiCa = new System.Windows.Forms.ComboBox();
            this.tabChinhSua_btnLuu = new System.Windows.Forms.Button();
            this.tabChinhSua_txtMaCa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabChinhSua_btnTroVe = new System.Windows.Forms.Button();
            this.tabChinhSua_btnThem = new System.Windows.Forms.Button();
            this.tabChinhSua_btnReload = new System.Windows.Forms.Button();
            this.tabTimKiem = new System.Windows.Forms.TabPage();
            this.tabTimKiem_dtpNgayLam = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tabTimKiem_chkNgayLam = new System.Windows.Forms.CheckBox();
            this.tabTimKiem_btnLoc = new System.Windows.Forms.Button();
            this.tabTimKiem_txtTongSoBanGhi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxMaLoaiCa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabTimKiem_chkMaLoaiCa = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabTimKiem_dgvCaLam = new System.Windows.Forms.DataGridView();
            this.tabTimKiem_MaCa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTimKiem_MaLoaiCa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTimKiem_NgayLam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabChinhSua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabChinhSua_dgvCaLam)).BeginInit();
            this.grBoxThongTinCaLam.SuspendLayout();
            this.tabTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabTimKiem_dgvCaLam)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(824, 589);
            this.tabControl1.TabIndex = 0;
            // 
            // tabChinhSua
            // 
            this.tabChinhSua.Controls.Add(this.tabChinhSua_dgvCaLam);
            this.tabChinhSua.Controls.Add(this.grBoxThongTinCaLam);
            this.tabChinhSua.Controls.Add(this.tabChinhSua_btnTroVe);
            this.tabChinhSua.Controls.Add(this.tabChinhSua_btnThem);
            this.tabChinhSua.Controls.Add(this.tabChinhSua_btnReload);
            this.tabChinhSua.Location = new System.Drawing.Point(4, 22);
            this.tabChinhSua.Name = "tabChinhSua";
            this.tabChinhSua.Padding = new System.Windows.Forms.Padding(3);
            this.tabChinhSua.Size = new System.Drawing.Size(816, 563);
            this.tabChinhSua.TabIndex = 0;
            this.tabChinhSua.Text = "Chỉnh sửa";
            this.tabChinhSua.UseVisualStyleBackColor = true;
            // 
            // tabChinhSua_dgvCaLam
            // 
            this.tabChinhSua_dgvCaLam.AllowUserToAddRows = false;
            this.tabChinhSua_dgvCaLam.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(118)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tabChinhSua_dgvCaLam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.tabChinhSua_dgvCaLam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabChinhSua_dgvCaLam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.tabChinhSua_MaLoaiCa,
            this.dataGridViewTextBoxColumn2});
            this.tabChinhSua_dgvCaLam.Location = new System.Drawing.Point(8, 154);
            this.tabChinhSua_dgvCaLam.Name = "tabChinhSua_dgvCaLam";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChinhSua_dgvCaLam.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.tabChinhSua_dgvCaLam.Size = new System.Drawing.Size(776, 231);
            this.tabChinhSua_dgvCaLam.TabIndex = 128;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MaCa";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã ca làm";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 250;
            // 
            // tabChinhSua_MaLoaiCa
            // 
            this.tabChinhSua_MaLoaiCa.DataPropertyName = "MaLoaiCa";
            this.tabChinhSua_MaLoaiCa.HeaderText = "Mã loại ca";
            this.tabChinhSua_MaLoaiCa.Name = "tabChinhSua_MaLoaiCa";
            this.tabChinhSua_MaLoaiCa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tabChinhSua_MaLoaiCa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tabChinhSua_MaLoaiCa.Width = 250;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NgayLam";
            this.dataGridViewTextBoxColumn2.HeaderText = "Ngày làm ";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 260;
            // 
            // grBoxThongTinCaLam
            // 
            this.grBoxThongTinCaLam.Controls.Add(this.tabChinhSua_btnHuyBo);
            this.grBoxThongTinCaLam.Controls.Add(this.tabChinhSua_dtpNgayLam);
            this.grBoxThongTinCaLam.Controls.Add(this.tabChinhSua_cbxMaLoaiCa);
            this.grBoxThongTinCaLam.Controls.Add(this.tabChinhSua_btnLuu);
            this.grBoxThongTinCaLam.Controls.Add(this.tabChinhSua_txtMaCa);
            this.grBoxThongTinCaLam.Controls.Add(this.label8);
            this.grBoxThongTinCaLam.Controls.Add(this.label11);
            this.grBoxThongTinCaLam.Controls.Add(this.label12);
            this.grBoxThongTinCaLam.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grBoxThongTinCaLam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.grBoxThongTinCaLam.Location = new System.Drawing.Point(8, 15);
            this.grBoxThongTinCaLam.Name = "grBoxThongTinCaLam";
            this.grBoxThongTinCaLam.Size = new System.Drawing.Size(776, 133);
            this.grBoxThongTinCaLam.TabIndex = 117;
            this.grBoxThongTinCaLam.TabStop = false;
            this.grBoxThongTinCaLam.Text = "Thông tin ca làm";
            // 
            // tabChinhSua_btnHuyBo
            // 
            this.tabChinhSua_btnHuyBo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(170)))), ((int)(((byte)(242)))));
            this.tabChinhSua_btnHuyBo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabChinhSua_btnHuyBo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(92)))), ((int)(((byte)(101)))));
            this.tabChinhSua_btnHuyBo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabChinhSua_btnHuyBo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChinhSua_btnHuyBo.ForeColor = System.Drawing.Color.White;
            this.tabChinhSua_btnHuyBo.Location = new System.Drawing.Point(677, 86);
            this.tabChinhSua_btnHuyBo.Name = "tabChinhSua_btnHuyBo";
            this.tabChinhSua_btnHuyBo.Size = new System.Drawing.Size(93, 31);
            this.tabChinhSua_btnHuyBo.TabIndex = 131;
            this.tabChinhSua_btnHuyBo.Text = "Hủy bỏ";
            this.tabChinhSua_btnHuyBo.UseVisualStyleBackColor = false;
            this.tabChinhSua_btnHuyBo.Click += new System.EventHandler(this.tabChinhSua_btnHuyBo_Click);
            // 
            // tabChinhSua_dtpNgayLam
            // 
            this.tabChinhSua_dtpNgayLam.CustomFormat = "dd/MM/yyyy";
            this.tabChinhSua_dtpNgayLam.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tabChinhSua_dtpNgayLam.Location = new System.Drawing.Point(548, 34);
            this.tabChinhSua_dtpNgayLam.Name = "tabChinhSua_dtpNgayLam";
            this.tabChinhSua_dtpNgayLam.Size = new System.Drawing.Size(222, 26);
            this.tabChinhSua_dtpNgayLam.TabIndex = 17;
            // 
            // tabChinhSua_cbxMaLoaiCa
            // 
            this.tabChinhSua_cbxMaLoaiCa.FormattingEnabled = true;
            this.tabChinhSua_cbxMaLoaiCa.Location = new System.Drawing.Point(120, 86);
            this.tabChinhSua_cbxMaLoaiCa.Name = "tabChinhSua_cbxMaLoaiCa";
            this.tabChinhSua_cbxMaLoaiCa.Size = new System.Drawing.Size(222, 27);
            this.tabChinhSua_cbxMaLoaiCa.TabIndex = 14;
            // 
            // tabChinhSua_btnLuu
            // 
            this.tabChinhSua_btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(170)))), ((int)(((byte)(242)))));
            this.tabChinhSua_btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabChinhSua_btnLuu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(92)))), ((int)(((byte)(101)))));
            this.tabChinhSua_btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabChinhSua_btnLuu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChinhSua_btnLuu.ForeColor = System.Drawing.Color.White;
            this.tabChinhSua_btnLuu.Location = new System.Drawing.Point(548, 86);
            this.tabChinhSua_btnLuu.Name = "tabChinhSua_btnLuu";
            this.tabChinhSua_btnLuu.Size = new System.Drawing.Size(93, 31);
            this.tabChinhSua_btnLuu.TabIndex = 114;
            this.tabChinhSua_btnLuu.Text = "Lưu";
            this.tabChinhSua_btnLuu.UseVisualStyleBackColor = false;
            this.tabChinhSua_btnLuu.Click += new System.EventHandler(this.tabChinhSua_btnLuu_Click);
            // 
            // tabChinhSua_txtMaCa
            // 
            this.tabChinhSua_txtMaCa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChinhSua_txtMaCa.Location = new System.Drawing.Point(120, 34);
            this.tabChinhSua_txtMaCa.Name = "tabChinhSua_txtMaCa";
            this.tabChinhSua_txtMaCa.Size = new System.Drawing.Size(222, 26);
            this.tabChinhSua_txtMaCa.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(441, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 19);
            this.label8.TabIndex = 5;
            this.label8.Text = "Ngày làm";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(10, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 19);
            this.label11.TabIndex = 1;
            this.label11.Text = "Mã loại ca";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(10, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 19);
            this.label12.TabIndex = 0;
            this.label12.Text = "Mã ca làm";
            // 
            // tabChinhSua_btnTroVe
            // 
            this.tabChinhSua_btnTroVe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(170)))), ((int)(((byte)(242)))));
            this.tabChinhSua_btnTroVe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabChinhSua_btnTroVe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(92)))), ((int)(((byte)(101)))));
            this.tabChinhSua_btnTroVe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabChinhSua_btnTroVe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChinhSua_btnTroVe.ForeColor = System.Drawing.Color.White;
            this.tabChinhSua_btnTroVe.Location = new System.Drawing.Point(691, 410);
            this.tabChinhSua_btnTroVe.Name = "tabChinhSua_btnTroVe";
            this.tabChinhSua_btnTroVe.Size = new System.Drawing.Size(93, 31);
            this.tabChinhSua_btnTroVe.TabIndex = 113;
            this.tabChinhSua_btnTroVe.Text = "Trở về";
            this.tabChinhSua_btnTroVe.UseVisualStyleBackColor = false;
            // 
            // tabChinhSua_btnThem
            // 
            this.tabChinhSua_btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(170)))), ((int)(((byte)(242)))));
            this.tabChinhSua_btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabChinhSua_btnThem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(92)))), ((int)(((byte)(101)))));
            this.tabChinhSua_btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabChinhSua_btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChinhSua_btnThem.ForeColor = System.Drawing.Color.White;
            this.tabChinhSua_btnThem.Location = new System.Drawing.Point(556, 410);
            this.tabChinhSua_btnThem.Name = "tabChinhSua_btnThem";
            this.tabChinhSua_btnThem.Size = new System.Drawing.Size(93, 31);
            this.tabChinhSua_btnThem.TabIndex = 115;
            this.tabChinhSua_btnThem.Text = "Thêm";
            this.tabChinhSua_btnThem.UseVisualStyleBackColor = false;
            this.tabChinhSua_btnThem.Click += new System.EventHandler(this.tabChinhSua_btnThem_Click);
            // 
            // tabChinhSua_btnReload
            // 
            this.tabChinhSua_btnReload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(170)))), ((int)(((byte)(242)))));
            this.tabChinhSua_btnReload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabChinhSua_btnReload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(92)))), ((int)(((byte)(101)))));
            this.tabChinhSua_btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabChinhSua_btnReload.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChinhSua_btnReload.ForeColor = System.Drawing.Color.White;
            this.tabChinhSua_btnReload.Location = new System.Drawing.Point(420, 410);
            this.tabChinhSua_btnReload.Name = "tabChinhSua_btnReload";
            this.tabChinhSua_btnReload.Size = new System.Drawing.Size(93, 31);
            this.tabChinhSua_btnReload.TabIndex = 116;
            this.tabChinhSua_btnReload.Text = "Reload";
            this.tabChinhSua_btnReload.UseVisualStyleBackColor = false;
            this.tabChinhSua_btnReload.Click += new System.EventHandler(this.tabChinhSua_btnReload_Click);
            // 
            // tabTimKiem
            // 
            this.tabTimKiem.Controls.Add(this.tabTimKiem_dtpNgayLam);
            this.tabTimKiem.Controls.Add(this.label2);
            this.tabTimKiem.Controls.Add(this.tabTimKiem_chkNgayLam);
            this.tabTimKiem.Controls.Add(this.tabTimKiem_btnLoc);
            this.tabTimKiem.Controls.Add(this.tabTimKiem_txtTongSoBanGhi);
            this.tabTimKiem.Controls.Add(this.label1);
            this.tabTimKiem.Controls.Add(this.cbxMaLoaiCa);
            this.tabTimKiem.Controls.Add(this.label3);
            this.tabTimKiem.Controls.Add(this.tabTimKiem_chkMaLoaiCa);
            this.tabTimKiem.Controls.Add(this.label6);
            this.tabTimKiem.Controls.Add(this.tabTimKiem_dgvCaLam);
            this.tabTimKiem.Location = new System.Drawing.Point(4, 22);
            this.tabTimKiem.Name = "tabTimKiem";
            this.tabTimKiem.Padding = new System.Windows.Forms.Padding(3);
            this.tabTimKiem.Size = new System.Drawing.Size(816, 563);
            this.tabTimKiem.TabIndex = 1;
            this.tabTimKiem.Text = "Tìm kiếm";
            this.tabTimKiem.UseVisualStyleBackColor = true;
            // 
            // tabTimKiem_dtpNgayLam
            // 
            this.tabTimKiem_dtpNgayLam.CustomFormat = "dd/MM/yyyy";
            this.tabTimKiem_dtpNgayLam.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTimKiem_dtpNgayLam.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tabTimKiem_dtpNgayLam.Location = new System.Drawing.Point(435, 48);
            this.tabTimKiem_dtpNgayLam.Name = "tabTimKiem_dtpNgayLam";
            this.tabTimKiem_dtpNgayLam.Size = new System.Drawing.Size(121, 23);
            this.tabTimKiem_dtpNgayLam.TabIndex = 137;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(308, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 136;
            this.label2.Text = "Ngày tháng năm:";
            // 
            // tabTimKiem_chkNgayLam
            // 
            this.tabTimKiem_chkNgayLam.AutoSize = true;
            this.tabTimKiem_chkNgayLam.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTimKiem_chkNgayLam.Location = new System.Drawing.Point(243, 10);
            this.tabTimKiem_chkNgayLam.Name = "tabTimKiem_chkNgayLam";
            this.tabTimKiem_chkNgayLam.Size = new System.Drawing.Size(136, 21);
            this.tabTimKiem_chkNgayLam.TabIndex = 135;
            this.tabTimKiem_chkNgayLam.Text = "Ngày tháng năm";
            this.tabTimKiem_chkNgayLam.UseVisualStyleBackColor = true;
            this.tabTimKiem_chkNgayLam.CheckedChanged += new System.EventHandler(this.tabTimKiem_chkNgayLam_CheckedChanged);
            // 
            // tabTimKiem_btnLoc
            // 
            this.tabTimKiem_btnLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(170)))), ((int)(((byte)(242)))));
            this.tabTimKiem_btnLoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabTimKiem_btnLoc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(92)))), ((int)(((byte)(101)))));
            this.tabTimKiem_btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabTimKiem_btnLoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTimKiem_btnLoc.ForeColor = System.Drawing.Color.White;
            this.tabTimKiem_btnLoc.Location = new System.Drawing.Point(17, 99);
            this.tabTimKiem_btnLoc.Name = "tabTimKiem_btnLoc";
            this.tabTimKiem_btnLoc.Size = new System.Drawing.Size(93, 31);
            this.tabTimKiem_btnLoc.TabIndex = 134;
            this.tabTimKiem_btnLoc.Text = "Lọc";
            this.tabTimKiem_btnLoc.UseVisualStyleBackColor = false;
            this.tabTimKiem_btnLoc.Click += new System.EventHandler(this.tabTimKiem_btnLoc_Click);
            // 
            // tabTimKiem_txtTongSoBanGhi
            // 
            this.tabTimKiem_txtTongSoBanGhi.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTimKiem_txtTongSoBanGhi.Location = new System.Drawing.Point(697, 99);
            this.tabTimKiem_txtTongSoBanGhi.Name = "tabTimKiem_txtTongSoBanGhi";
            this.tabTimKiem_txtTongSoBanGhi.Size = new System.Drawing.Size(100, 26);
            this.tabTimKiem_txtTongSoBanGhi.TabIndex = 133;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(566, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 19);
            this.label1.TabIndex = 132;
            this.label1.Text = "Tổng số bản ghi:";
            // 
            // cbxMaLoaiCa
            // 
            this.cbxMaLoaiCa.AccessibleDescription = "";
            this.cbxMaLoaiCa.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMaLoaiCa.FormattingEnabled = true;
            this.cbxMaLoaiCa.Location = new System.Drawing.Point(105, 50);
            this.cbxMaLoaiCa.Name = "cbxMaLoaiCa";
            this.cbxMaLoaiCa.Size = new System.Drawing.Size(151, 23);
            this.cbxMaLoaiCa.TabIndex = 131;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 130;
            this.label3.Text = "Mã loại ca:";
            // 
            // tabTimKiem_chkMaLoaiCa
            // 
            this.tabTimKiem_chkMaLoaiCa.AutoSize = true;
            this.tabTimKiem_chkMaLoaiCa.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTimKiem_chkMaLoaiCa.Location = new System.Drawing.Point(114, 11);
            this.tabTimKiem_chkMaLoaiCa.Name = "tabTimKiem_chkMaLoaiCa";
            this.tabTimKiem_chkMaLoaiCa.Size = new System.Drawing.Size(96, 21);
            this.tabTimKiem_chkMaLoaiCa.TabIndex = 129;
            this.tabTimKiem_chkMaLoaiCa.Text = "Mã loại ca";
            this.tabTimKiem_chkMaLoaiCa.UseVisualStyleBackColor = true;
            this.tabTimKiem_chkMaLoaiCa.CheckedChanged += new System.EventHandler(this.tabTimKiem_chkMaLoaiCa_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 128;
            this.label6.Text = "Lọc theo:";
            // 
            // tabTimKiem_dgvCaLam
            // 
            this.tabTimKiem_dgvCaLam.AllowUserToAddRows = false;
            this.tabTimKiem_dgvCaLam.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(118)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tabTimKiem_dgvCaLam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.tabTimKiem_dgvCaLam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabTimKiem_dgvCaLam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tabTimKiem_MaCa,
            this.tabTimKiem_MaLoaiCa,
            this.tabTimKiem_NgayLam});
            this.tabTimKiem_dgvCaLam.Location = new System.Drawing.Point(17, 148);
            this.tabTimKiem_dgvCaLam.Name = "tabTimKiem_dgvCaLam";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTimKiem_dgvCaLam.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.tabTimKiem_dgvCaLam.Size = new System.Drawing.Size(780, 345);
            this.tabTimKiem_dgvCaLam.TabIndex = 127;
            // 
            // tabTimKiem_MaCa
            // 
            this.tabTimKiem_MaCa.DataPropertyName = "MaCa";
            this.tabTimKiem_MaCa.HeaderText = "Mã ca làm";
            this.tabTimKiem_MaCa.Name = "tabTimKiem_MaCa";
            this.tabTimKiem_MaCa.Width = 250;
            // 
            // tabTimKiem_MaLoaiCa
            // 
            this.tabTimKiem_MaLoaiCa.DataPropertyName = "MaLoaiCa";
            this.tabTimKiem_MaLoaiCa.HeaderText = "Mã loại ca";
            this.tabTimKiem_MaLoaiCa.Name = "tabTimKiem_MaLoaiCa";
            this.tabTimKiem_MaLoaiCa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tabTimKiem_MaLoaiCa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tabTimKiem_MaLoaiCa.Width = 250;
            // 
            // tabTimKiem_NgayLam
            // 
            this.tabTimKiem_NgayLam.DataPropertyName = "NgayLam";
            this.tabTimKiem_NgayLam.HeaderText = "Ngày làm ";
            this.tabTimKiem_NgayLam.Name = "tabTimKiem_NgayLam";
            this.tabTimKiem_NgayLam.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tabTimKiem_NgayLam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tabTimKiem_NgayLam.Width = 260;
            // 
            // frmQuanLyCaLam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(824, 589);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmQuanLyCaLam";
            this.Text = "frmQuanLyCaLam";
            this.Load += new System.EventHandler(this.frmQuanLyCaLam_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabChinhSua.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabChinhSua_dgvCaLam)).EndInit();
            this.grBoxThongTinCaLam.ResumeLayout(false);
            this.grBoxThongTinCaLam.PerformLayout();
            this.tabTimKiem.ResumeLayout(false);
            this.tabTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabTimKiem_dgvCaLam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabChinhSua;
        private System.Windows.Forms.Button tabChinhSua_btnTroVe;
        private System.Windows.Forms.Button tabChinhSua_btnLuu;
        private System.Windows.Forms.Button tabChinhSua_btnReload;
        private System.Windows.Forms.TabPage tabTimKiem;
        private System.Windows.Forms.DateTimePicker tabTimKiem_dtpNgayLam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox tabTimKiem_chkNgayLam;
        private System.Windows.Forms.Button tabTimKiem_btnLoc;
        private System.Windows.Forms.TextBox tabTimKiem_txtTongSoBanGhi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxMaLoaiCa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox tabTimKiem_chkMaLoaiCa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView tabTimKiem_dgvCaLam;
        private System.Windows.Forms.GroupBox grBoxThongTinCaLam;
        private System.Windows.Forms.DateTimePicker tabChinhSua_dtpNgayLam;
        private System.Windows.Forms.ComboBox tabChinhSua_cbxMaLoaiCa;
        private System.Windows.Forms.TextBox tabChinhSua_txtMaCa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView tabChinhSua_dgvCaLam;
        private System.Windows.Forms.Button tabChinhSua_btnThem;
        private System.Windows.Forms.Button tabChinhSua_btnHuyBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabChinhSua_MaLoaiCa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabTimKiem_MaCa;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabTimKiem_MaLoaiCa;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabTimKiem_NgayLam;
    }
}