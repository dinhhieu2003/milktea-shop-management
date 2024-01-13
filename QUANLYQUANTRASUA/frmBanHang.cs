using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYQUANTRASUA
{
    public partial class frmBanHang : Form
    {
        DBBan dbBan;
        DBMatHang dbMatHang;
        DBChiTietHoaDon dbChiTietHoaDon;
        DBHoaDon dbHoaDon;
        DBDangNhap dBDangNhap;
        // Bảng chứa dữ liệu
        DataTable dtBan = null;
        DataTable dtMatHang = null;
        DataTable dtChiTietHoaDon = null;
        string maKH;
        string userName = DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName;
        public frmBanHang()
        {
            InitializeComponent();
            dbBan = new DBBan();
            dbMatHang = new DBMatHang();
            dbChiTietHoaDon = new DBChiTietHoaDon();
            dbHoaDon = new DBHoaDon();
            dBDangNhap = new DBDangNhap();
        }

        private void LoadBan()
        {
            dtBan= new DataTable();
            dtBan.Clear();
            dtBan = dbBan.LayThongTinBan().Tables[0];
            foreach(DataRow ban in dtBan.Rows ) 
            {
                // Modify style for button represent a Table
                Button btnTable = new Button() {Width = 90, Height = 90};
                btnTable.Font = new Font("Cambria", 11, FontStyle.Bold);
                btnTable.ForeColor = Color.White;
                btnTable.Cursor = Cursors.Hand;
                btnTable.FlatStyle = FlatStyle.Flat;
                btnTable.FlatAppearance.BorderSize = 0;
                btnTable.Tag = ban;

                btnTable.Text = "Bàn số " + ban["SoBan"].ToString() + Environment.NewLine +
                    ban["TrangThai"].ToString();
                if (ban["TrangThai"].ToString() == "Trống")
                {
                    btnTable.BackColor = 
                        System.Drawing.Color.FromArgb(((int)(((byte)(0)))),
                        ((int)(((byte)(184)))), ((int)(((byte)(148)))));
                }
                else
                {
                    btnTable.BackColor =
                        System.Drawing.Color.FromArgb(((int)(((byte)(255)))),
                        ((int)(((byte)(118)))), ((int)(((byte)(117)))));
                }
                
                flpDanhSachBan.Controls.Add(btnTable);
                btnTable.Click += btnTable_Click;
            }
            Button btnMangDi = new Button() { Width = 90, Height = 90 };
            btnMangDi.Font = new Font("Cambria", 11, FontStyle.Bold);
            btnMangDi.ForeColor = Color.White;
            btnMangDi.Cursor = Cursors.Hand;
            btnMangDi.FlatStyle = FlatStyle.Flat;
            btnMangDi.FlatAppearance.BorderSize = 0;
            btnMangDi.BackColor =
                        System.Drawing.Color.FromArgb(((int)(((byte)(178)))),
                        ((int)(((byte)(190)))), ((int)(((byte)(195)))));
            btnMangDi.Text = "Mang đi";
            flpDanhSachBan.Controls.Add(btnMangDi);
            btnMangDi.Click += btnMangDi_Click;
        }

        private void btnMangDi_Click(object sender, EventArgs e)
        {
            lblBan.Text = "Mang đi";
            lblBan.ForeColor = Color.Red;
            dtChiTietHoaDon = new DataTable();
            dtChiTietHoaDon.Clear();
            dtChiTietHoaDon = dbChiTietHoaDon.LayCTHDKhachMangDiDangPhucVu().Tables[0];
            dgvChiTietHoaDon.DataSource = dtChiTietHoaDon;
            if(dgvChiTietHoaDon.RowCount == 0)
            {
                txtTongTien.Text = "0 VNĐ";
            }
            else
            {
                string maHoaDon = dbHoaDon.LayMaHoaDonCuaKhachMangDiDangPhucVu();
                float tongTien = dbChiTietHoaDon.LayTongSoTienCTHD(maHoaDon);
                txtTongTien.Text = tongTien.ToString() + " VNĐ";
            }
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DataRow ban = btn.Tag as DataRow;
            string MaBan = ban["MaBan"].ToString();
            string TrangThai = ban["TrangThai"].ToString();
            
            dtChiTietHoaDon = new DataTable();
            dtChiTietHoaDon.Clear();
            dtChiTietHoaDon = dbChiTietHoaDon.LayCTHDBanDangPhucVu(MaBan).Tables[0];
            dgvChiTietHoaDon.DataSource = dtChiTietHoaDon;
            dgvChiTietHoaDon.Tag = ban;

            lblBan.Text = "Bàn số: " + ban["SoBan"].ToString();
            lblBan.ForeColor = Color.Red;

            if(TrangThai != "Trống")
            {
                string maHoaDon = dtChiTietHoaDon.Rows[0][0].ToString();
                txtTongTien.Text = 
                    dbChiTietHoaDon.LayTongSoTienCTHD(maHoaDon).ToString() + 
                    " VNĐ";
            }
            else
            {
                txtTongTien.Text = "0 VNĐ";
            }
            
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            LoadBan();
            // Load dữ liệu vào combobox Tên món ăn
            dtMatHang = new DataTable();
            dtMatHang.Clear();
            dtMatHang = dbMatHang.LayThongTinMatHang().Tables[0];
            cbxDanhSachMatHang.DataSource = dtMatHang;
            cbxDanhSachMatHang.DisplayMember = "TenHang";
            cbxDanhSachMatHang.ValueMember = "MaMH";
        }

        private void KiemTraHoiVien()
        {
            DialogResult trLoi = MessageBox.Show
                    ("Khách hàng có phải hội viên không?", "Xác nhận hội viên",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (trLoi == DialogResult.Yes)
            {
                frmChonMaKH choiceForm = new frmChonMaKH();
                choiceForm.ShowDialog();
                maKH = choiceForm.MaKH;
            }
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            string maNV = dBDangNhap.LayMaNVDangNhap(userName);
            if (lblBan.Text != "Mang đi")
            {
                DataRow ban = dgvChiTietHoaDon.Tag as DataRow;
                string maBan = ban["MaBan"].ToString();
                string trangThai = dbBan.LayTrangThaiBan(maBan).ToString();

                if (trangThai != "Trống")
                {
                    string maHoaDon = dgvChiTietHoaDon.Rows[0].Cells[0].Value.ToString();
                    string maMH = cbxDanhSachMatHang.SelectedValue.ToString();
                    int soLuong = (int)nudSoLuong.Value;
                    string err = "";
                    try
                    {
                        // Lệnh Insert InTo 
                        bool f = dbChiTietHoaDon.ThemChiTietHoaDon(ref err,
                        maHoaDon, maMH, soLuong);
                        if (f)
                        {
                            // Load lại dữ liệu trên DataGridView 
                            dtChiTietHoaDon =
                                dbChiTietHoaDon.LayCTHDBanDangPhucVu(maBan).Tables[0];
                            dgvChiTietHoaDon.DataSource = dtChiTietHoaDon;
                            // Thông báo 
                            MessageBox.Show("Đã thêm món xong!");
                            txtTongTien.Text =
                                dbChiTietHoaDon.LayTongSoTienCTHD(maHoaDon).ToString() +
                                " VNĐ";
                        }
                        else
                        {
                            MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + err);
                        }
                    }
                    catch (SqlException q)
                    {
                        MessageBox.Show("Không thêm được. Lỗi rồi! Lỗi: " + q.Message);
                    }
                }
                else
                {
                    KiemTraHoiVien();
                    try
                    {
                        string err = "";
                        // Lệnh Insert InTo 
                        bool f = dbHoaDon.ThemHoaDon(ref err,
                        maNV, maKH, maBan);
                        if (f)
                        {
                            // Load lại dữ liệu trên DataGridView 
                            dtChiTietHoaDon =
                                dbChiTietHoaDon.LayCTHDBanDangPhucVu(maBan).Tables[0];
                            dgvChiTietHoaDon.DataSource = dtChiTietHoaDon;

                            try
                            {
                                string err2 = "";
                                string maHoaDon =
                                    dbHoaDon.LayMaHoaDonCuaBanDangPhucVu(maBan);
                                string maMH = cbxDanhSachMatHang.SelectedValue.ToString();
                                int soLuong = (int)nudSoLuong.Value;
                                // Lệnh Insert InTo 
                                bool f2 = dbChiTietHoaDon.ThemChiTietHoaDon(ref err2,
                                maHoaDon, maMH, soLuong);
                                if (f2)
                                {
                                    // Load lại dữ liệu trên DataGridView 
                                    dtChiTietHoaDon =
                                        dbChiTietHoaDon.LayCTHDBanDangPhucVu(maBan).Tables[0];
                                    dgvChiTietHoaDon.DataSource = dtChiTietHoaDon;
                                    // Thông báo 
                                    MessageBox.Show("Đã thêm món xong!");
                                    flpDanhSachBan.Controls.Clear();
                                    LoadBan();
                                    txtTongTien.Text =
                                        dbChiTietHoaDon.LayTongSoTienCTHD(maHoaDon).ToString() +
                                        " VNĐ";
                                }
                                else
                                {
                                    MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + err2);
                                }
                            }
                            catch (SqlException q2)
                            {
                                MessageBox.Show("Không thêm được. Lỗi rồi! Lỗi: " + q2.Message);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Chưa thể thêm một hóa đơn mới\n\r" + "Lỗi:" + err);
                        }
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Không thêm được. Lỗi rồi!");
                    }
                }
            }
            else
            {
                string maBan = null;
                KiemTraHoiVien();
                try
                {
                    string err = "";
                    // Lệnh Insert InTo 
                    bool f = dbHoaDon.ThemHoaDon(ref err,
                    maNV, maKH, maBan);
                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView
                        dtChiTietHoaDon =
                            dbChiTietHoaDon.LayCTHDKhachMangDiDangPhucVu().Tables[0];
                        dgvChiTietHoaDon.DataSource = dtChiTietHoaDon;

                        try
                        {
                            string err2 = "";
                            string maHoaDon =
                                dbHoaDon.LayMaHoaDonCuaKhachMangDiDangPhucVu();
                            string maMH = cbxDanhSachMatHang.SelectedValue.ToString();
                            int soLuong = (int)nudSoLuong.Value;
                            // Lệnh Insert InTo 
                            bool f2 = dbChiTietHoaDon.ThemChiTietHoaDon(ref err2,
                            maHoaDon, maMH, soLuong);
                            if (f2)
                            {
                                // Load lại dữ liệu trên DataGridView 
                                dtChiTietHoaDon =
                                    dbChiTietHoaDon.LayCTHDKhachMangDiDangPhucVu().Tables[0];
                                dgvChiTietHoaDon.DataSource = dtChiTietHoaDon;
                                // Thông báo 
                                MessageBox.Show("Đã thêm món xong!");
                                txtTongTien.Text =
                                    dbChiTietHoaDon.LayTongSoTienCTHD(maHoaDon).ToString() +
                                    " VNĐ";
                            }
                            else
                            {
                                MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + err2);
                            }
                        }
                        catch (SqlException q2)
                        {
                            MessageBox.Show("Không thêm được. Lỗi rồi! Lỗi: " + q2.Message);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Chưa thể thêm một hóa đơn mới\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string maBan;
            if(dgvChiTietHoaDon.RowCount > 0)
            {
                if(lblBan.Text == "Mang đi")
                {
                    maBan = null;
                }
                else
                {
                    maBan = dtChiTietHoaDon.Rows[0][1].ToString();
                }
                float DiemSuDung = 0;
                string maHoaDon = dtChiTietHoaDon.Rows[0][0].ToString();
                
                string maKH = dbHoaDon.LayMaKHTuHoaDon(maHoaDon);
                if (maKH != null)
                {
                    DialogResult trloi =
                    MessageBox.Show("Có muốn dùng điểm để thanh toán không?", "Xác nhận thanh toán",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (trloi == DialogResult.Yes)
                    {
                        frmDiemTichLuySuDung frm = new frmDiemTichLuySuDung();
                        frm.ShowDialog();
                        DiemSuDung = frm.DiemSuDung;
                    }
                }
                DateTime currentTime = DateTime.Now;
                try
                {
                    string err = "";
                    float tienThanhToan = dbChiTietHoaDon.LayTongSoTienCTHD(maHoaDon) -
                        1000 * DiemSuDung;
                    bool f = dbHoaDon.CapNhatHoaDon(ref err,
                    maHoaDon, maBan, currentTime, DiemSuDung);
                    if (f)
                    {
                        MessageBox.Show("Đã in thanh toán thành công!\n" +
                            "Số tiền thanh toán là: " + tienThanhToan.ToString());
                        flpDanhSachBan.Controls.Clear();
                        LoadBan();
                        dtChiTietHoaDon.Clear();
                        dgvChiTietHoaDon.DataSource = dtChiTietHoaDon;
                        txtTongTien.Text = "0 VNĐ";
                    }
                    else
                    {
                        MessageBox.Show("Chưa thể thanh toán vì gặp lỗi!\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException q)
                {
                    MessageBox.Show("Không thể thanh toán được. Lỗi rồi! Lỗi: " + q.Message);
                }
            }
            else
            {
                MessageBox.Show("Chưa có món nào nên không thể thanh toán");
            }
        }
    }
}
