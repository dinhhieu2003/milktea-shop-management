using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYQUANTRASUA
{
    public partial class frmQLDangNhap : Form
    {
        DBNhanVien dbNhanVien;
        DBDangNhap dbDangNhap;
        DBNhomNguoiDung dbNhomNguoiDung;
        // Bảng chứa dữ liệu
        DataTable dtNhanVien = null;
        DataTable dtDangNhap = null;
        DataTable dtNhomNguoiDung = null;

        bool Them;
        public frmQLDangNhap()
        {
            InitializeComponent();
            dbNhanVien = new DBNhanVien();
            dbDangNhap = new DBDangNhap();
            dbNhomNguoiDung = new DBNhomNguoiDung();
        }

        void LoadData()
        {
            dtNhanVien = new DataTable();
            dtNhanVien.Clear();
            dtNhanVien = dbNhanVien.LayThongTinNhanVienDangLam().Tables[0];
            cbxMaNV.DataSource = dtNhanVien;
            cbxMaNV.DisplayMember = "MaNV";
            cbxMaNV.ValueMember = "MaNV";

            dtNhomNguoiDung = new DataTable();
            dtNhomNguoiDung.Clear();
            dtNhomNguoiDung = dbNhomNguoiDung.LayThongTinNhomNguoiDung().Tables[0];
            cbxQuyenTaiKhoan.DataSource = dtNhomNguoiDung;
            cbxQuyenTaiKhoan.DisplayMember = "TenNhom";
            cbxQuyenTaiKhoan.ValueMember = "MaNhomNguoiDung";

            grBoxThongTinTaiKhoan.Enabled = false;

            dtDangNhap = new DataTable();
            dtDangNhap.Clear();
            dtDangNhap = dbDangNhap.LayThongTinViewDangNhap().Tables[0];
            dgvDangNhap.DataSource = dtDangNhap;

            this.btnThem.Enabled = true;
            this.btnChinhSua.Enabled = true;
            this.btnTroVe.Enabled = true;
        }

        private void frmQLDangNhap_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Them = true;
            // Xóa trống các đối tượng trong groupbox
            this.txtTenDangNhap.ResetText();
            this.txtMatKhau.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy 
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.grBoxThongTinTaiKhoan.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Sửa / Thoát 
            this.btnThem.Enabled = false;
            this.btnChinhSua.Enabled = false;
            this.btnTroVe.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Thêm dữ liệu 
            string err = "";
            if (Them)
            {
                try
                {
                    bool f = dbDangNhap.ThemTaiKhoan(ref err,
                    this.cbxMaNV.Text.ToString(), txtTenDangNhap.Text.ToString(),
                    this.txtMatKhau.Text.ToString(),
                    this.cbxQuyenTaiKhoan.SelectedValue.ToString());
                    if (f)
                    {
                        MessageBox.Show("Đã thêm tài khoản thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Thao tác không hoàn tất!\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException q)
                {
                    MessageBox.Show("Không thêm được. Lỗi: " + q.Message);
                }

                try
                {
                    bool f = dbDangNhap.GanQuyenTaiKhoan(ref err,
                    txtTenDangNhap.Text.ToString(),
                    this.cbxQuyenTaiKhoan.SelectedValue.ToString());
                    if (f)
                    {
                        MessageBox.Show("Đã gán quyền tài khoản thành công!");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Gán quyền không thành công!\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException q)
                {
                    MessageBox.Show("Không thể gán quyền. Lỗi: " + q.Message);
                }

            }
            else
            {
                try
                {
                    bool f = dbDangNhap.DoiMatKhau(ref err,
                    this.txtTenDangNhap.Text.ToString(),
                    this.txtMatKhau.Text.ToString());
                    if (f)
                    {
                        MessageBox.Show("Đã đổi mật khẩu thành công!");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Thao tác không hoàn tất!\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException q)
                {
                    MessageBox.Show("Không đổi được. Lỗi: " + q.Message);
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong groupbox
            this.txtTenDangNhap.ResetText();
            this.txtMatKhau.ResetText();
            // Không cho thao tác trên các nút Lưu / Hủy 
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            this.grBoxThongTinTaiKhoan.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            this.btnThem.Enabled = true;
            this.btnChinhSua.Enabled = true;
            this.btnTroVe.Enabled = true;
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            Them = false;
            int r = dgvDangNhap.CurrentCell.RowIndex;
            this.cbxMaNV.SelectedValue =
                dgvDangNhap.Rows[r].Cells[0].Value.ToString();
            this.txtTenDangNhap.Text =
                dgvDangNhap.Rows[r].Cells[1].Value.ToString();
            this.txtMatKhau.Text =
                dgvDangNhap.Rows[r].Cells[2].Value.ToString();
            // Cho thao tác trên các nút Lưu / Hủy 
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.grBoxThongTinTaiKhoan.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            // Không cho thao tác trên các thuộc tính khác trừ mật khẩu
            this.btnThem.Enabled = false;
            this.btnChinhSua.Enabled = false;
            this.btnTroVe.Enabled = false;
            this.txtTenDangNhap.Enabled = false;
            this.cbxMaNV.Enabled = false;
            this.cbxQuyenTaiKhoan.Enabled = false;
        }

        private void dgvDangNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvDangNhap.CurrentCell.RowIndex;
            this.cbxMaNV.SelectedValue =
                dgvDangNhap.Rows[r].Cells[0].Value.ToString();
            this.txtTenDangNhap.Text =
                dgvDangNhap.Rows[r].Cells[1].Value.ToString();
            this.txtMatKhau.Text =
                dgvDangNhap.Rows[r].Cells[2].Value.ToString();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
