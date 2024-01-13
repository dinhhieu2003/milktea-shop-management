namespace QUANLYQUANTRASUA
{
    partial class frmDanhMucSanPhamBanChay
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxThang = new System.Windows.Forms.ComboBox();
            this.cbxNam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDanhSachSPBanChay = new System.Windows.Forms.DataGridView();
            this.btnXem = new System.Windows.Forms.Button();
            this.TenMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoaiMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongBanDuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSPBanChay)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 60;
            this.label1.Text = "Chọn tháng:";
            // 
            // cbxThang
            // 
            this.cbxThang.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxThang.FormattingEnabled = true;
            this.cbxThang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbxThang.Location = new System.Drawing.Point(108, 36);
            this.cbxThang.Name = "cbxThang";
            this.cbxThang.Size = new System.Drawing.Size(121, 23);
            this.cbxThang.TabIndex = 61;
            // 
            // cbxNam
            // 
            this.cbxNam.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxNam.FormattingEnabled = true;
            this.cbxNam.Items.AddRange(new object[] {
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023"});
            this.cbxNam.Location = new System.Drawing.Point(404, 36);
            this.cbxNam.Name = "cbxNam";
            this.cbxNam.Size = new System.Drawing.Size(121, 23);
            this.cbxNam.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(308, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 62;
            this.label2.Text = "Chọn năm:";
            // 
            // dgvDanhSachSPBanChay
            // 
            this.dgvDanhSachSPBanChay.AllowUserToAddRows = false;
            this.dgvDanhSachSPBanChay.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(118)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSachSPBanChay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhSachSPBanChay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachSPBanChay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenMH,
            this.TenLoaiMH,
            this.SoLuongBanDuoc,
            this.Month,
            this.Year});
            this.dgvDanhSachSPBanChay.Location = new System.Drawing.Point(12, 136);
            this.dgvDanhSachSPBanChay.Name = "dgvDanhSachSPBanChay";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDanhSachSPBanChay.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSachSPBanChay.Size = new System.Drawing.Size(713, 283);
            this.dgvDanhSachSPBanChay.TabIndex = 64;
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(170)))), ((int)(((byte)(242)))));
            this.btnXem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(92)))), ((int)(((byte)(101)))));
            this.btnXem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.Location = new System.Drawing.Point(12, 84);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(93, 31);
            this.btnXem.TabIndex = 71;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = false;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // TenMH
            // 
            this.TenMH.DataPropertyName = "TenHang";
            this.TenMH.HeaderText = "Tên mặt hàng";
            this.TenMH.Name = "TenMH";
            this.TenMH.Width = 150;
            // 
            // TenLoaiMH
            // 
            this.TenLoaiMH.DataPropertyName = "TenLoaiHang";
            this.TenLoaiMH.HeaderText = "Tên loại mặt hàng";
            this.TenLoaiMH.Name = "TenLoaiMH";
            this.TenLoaiMH.Width = 170;
            // 
            // SoLuongBanDuoc
            // 
            this.SoLuongBanDuoc.DataPropertyName = "SoLuong";
            this.SoLuongBanDuoc.HeaderText = "Số lượng bán được";
            this.SoLuongBanDuoc.Name = "SoLuongBanDuoc";
            this.SoLuongBanDuoc.Width = 150;
            // 
            // Month
            // 
            this.Month.DataPropertyName = "Thang";
            this.Month.HeaderText = "Tháng";
            this.Month.Name = "Month";
            // 
            // Year
            // 
            this.Year.DataPropertyName = "Nam";
            this.Year.HeaderText = "Năm";
            this.Year.Name = "Year";
            // 
            // frmDanhMucSanPhamBanChay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(836, 500);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dgvDanhSachSPBanChay);
            this.Controls.Add(this.cbxNam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxThang);
            this.Controls.Add(this.label1);
            this.Name = "frmDanhMucSanPhamBanChay";
            this.Text = "frmDanhMucSanPhamBanChay";
            this.Load += new System.EventHandler(this.frmDanhMucSanPhamBanChay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSPBanChay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxThang;
        private System.Windows.Forms.ComboBox cbxNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDanhSachSPBanChay;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongBanDuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
    }
}