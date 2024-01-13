namespace QUANLYQUANTRASUA
{
    partial class frmTinhToanDoanhThu
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
            this.btnTinhToan = new System.Windows.Forms.Button();
            this.cbxNam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxThang = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTinhToan = new System.Windows.Forms.Label();
            this.txtTinhToan = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnTinhToan
            // 
            this.btnTinhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(170)))), ((int)(((byte)(242)))));
            this.btnTinhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTinhToan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(92)))), ((int)(((byte)(101)))));
            this.btnTinhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTinhToan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinhToan.ForeColor = System.Drawing.Color.White;
            this.btnTinhToan.Location = new System.Drawing.Point(12, 63);
            this.btnTinhToan.Name = "btnTinhToan";
            this.btnTinhToan.Size = new System.Drawing.Size(93, 31);
            this.btnTinhToan.TabIndex = 76;
            this.btnTinhToan.Text = "Tính";
            this.btnTinhToan.UseVisualStyleBackColor = false;
            this.btnTinhToan.Click += new System.EventHandler(this.btnTinhToan_Click);
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
            this.cbxNam.Location = new System.Drawing.Point(404, 15);
            this.cbxNam.Name = "cbxNam";
            this.cbxNam.Size = new System.Drawing.Size(121, 23);
            this.cbxNam.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(308, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 74;
            this.label2.Text = "Chọn năm:";
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
            this.cbxThang.Location = new System.Drawing.Point(108, 15);
            this.cbxThang.Name = "cbxThang";
            this.cbxThang.Size = new System.Drawing.Size(121, 23);
            this.cbxThang.TabIndex = 73;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 72;
            this.label1.Text = "Chọn tháng:";
            // 
            // lblTinhToan
            // 
            this.lblTinhToan.AutoSize = true;
            this.lblTinhToan.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTinhToan.Location = new System.Drawing.Point(185, 70);
            this.lblTinhToan.Name = "lblTinhToan";
            this.lblTinhToan.Size = new System.Drawing.Size(33, 19);
            this.lblTinhToan.TabIndex = 77;
            this.lblTinhToan.Text = "LỖ:";
            // 
            // txtTinhToan
            // 
            this.txtTinhToan.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTinhToan.Location = new System.Drawing.Point(235, 66);
            this.txtTinhToan.Name = "txtTinhToan";
            this.txtTinhToan.Size = new System.Drawing.Size(100, 26);
            this.txtTinhToan.TabIndex = 78;
            // 
            // frmTinhToanDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 146);
            this.Controls.Add(this.txtTinhToan);
            this.Controls.Add(this.lblTinhToan);
            this.Controls.Add(this.btnTinhToan);
            this.Controls.Add(this.cbxNam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxThang);
            this.Controls.Add(this.label1);
            this.Name = "frmTinhToanDoanhThu";
            this.Text = "frmTinhToanDoanhThu";
            this.Load += new System.EventHandler(this.frmTinhToanDoanhThu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTinhToan;
        private System.Windows.Forms.ComboBox cbxNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxThang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTinhToan;
        private System.Windows.Forms.TextBox txtTinhToan;
    }
}