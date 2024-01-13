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
    public partial class frmQuanLyThongTinKhachHang : Form
    {
        DBKhachHang dbKhachHang;
        DBLoaiKhachHang dbLoaiKH;
        // Bảng dữ liệu
        DataTable dtKhachHang = null;
        DataTable dtLoaiKH = null;
        DataTable dtLocKhachHang = null;

        bool Them;
        public frmQuanLyThongTinKhachHang()
        {
            InitializeComponent();
            dbKhachHang = new DBKhachHang();
            dbLoaiKH = new DBLoaiKhachHang();
        }

        private void LoadDataChinhSua()
        {
            try
            {
                /* Vận chuyển dữ liệu vào DataTable */

                // dtNhanVien
                dtKhachHang = new DataTable();
                dtKhachHang.Clear();
                dtKhachHang = dbKhachHang.LayThongTinViewKhachHang().Tables[0];

                dtLoaiKH = new DataTable();
                dtLoaiKH.Clear();
                dtLoaiKH = dbLoaiKH.LayThongTinLoaiKhachHang().Tables[0];

                /*Đưa vào combobox*/
                //Mã loại KH
                tabChinhSua_cbxMaLoaiKH.DataSource = dtLoaiKH;
                tabChinhSua_cbxMaLoaiKH.DisplayMember = "MaLoaiKH";
                tabChinhSua_cbxMaLoaiKH.ValueMember = "TenLoaiKH";

                /* Vận chuyển dữ liệu vào Datagridview */
                tabChinhSua_dgvKhachHang.DataSource = dtKhachHang;

                // Xóa trống các đối tượng trong groupbox
                this.tabChinhSua_txtMaKH.ResetText();
                this.tabChinhSua_txtTenKH.ResetText();
                this.tabChinhSua_txtDiaChi.ResetText();
                this.tabChinhSua_txtSDT.ResetText();
                this.tabChinhSua_txtDiemTichLuyHienTai.ResetText();
                this.tabChinhSua_txtTongDiemTichLuy.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy 
                this.tabChinhSua_btnLuu.Enabled = false;
                this.tabChinhSua_btnHuyBo.Enabled = false;
                this.grBoxThongTinKhachHang.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Thoát 
                this.tabChinhSua_btnThem.Enabled = true;
                this.tabChinhSua_btnChinhSua.Enabled = true;
                this.tabChinhSua_btnTroVe.Enabled = true;

                tabChinhSua_txtTongSoBanGhi.Text =
                    tabChinhSua_dgvKhachHang.RowCount.ToString();
            }
            catch (SqlException q)
            {
                MessageBox.Show(q.Message);

            }
        }

        private void frmQuanLyThongTinKhachHang_Load(object sender, EventArgs e)
        {
            LoadDataChinhSua();
            LoadDataTimKiem();
        }

        private void tabChinhSua_btnReload_Click(object sender, EventArgs e)
        {
            LoadDataChinhSua();
        }

        private void tabChinhSua_btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabChinhSua_btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Them = true;
            // Xóa trống các đối tượng trong groupbox
            this.tabChinhSua_txtMaKH.ResetText();
            this.tabChinhSua_txtMaKH.Enabled = false;
            this.tabChinhSua_txtTenKH.ResetText();
            this.tabChinhSua_txtDiaChi.ResetText();
            this.tabChinhSua_txtSDT.ResetText();
            this.tabChinhSua_txtDiemTichLuyHienTai.ResetText();
            this.tabChinhSua_txtTongDiemTichLuy.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy 
            this.tabChinhSua_btnLuu.Enabled = true;
            this.tabChinhSua_btnHuyBo.Enabled = true;
            this.grBoxThongTinKhachHang.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Sửa / Trở về 
            this.tabChinhSua_btnThem.Enabled = false;
            this.tabChinhSua_btnChinhSua.Enabled = false;
            this.tabChinhSua_btnTroVe.Enabled = false;
        }

        private void tabChinhSua_btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong groupbox
            this.tabChinhSua_txtMaKH.ResetText();
            this.tabChinhSua_txtTenKH.ResetText();
            this.tabChinhSua_txtDiaChi.ResetText();
            this.tabChinhSua_txtSDT.ResetText();
            this.tabChinhSua_txtDiemTichLuyHienTai.ResetText();
            this.tabChinhSua_txtTongDiemTichLuy.ResetText();
            // Không cho thao tác trên các nút Lưu / Hủy 
            this.tabChinhSua_btnLuu.Enabled = false;
            this.tabChinhSua_btnHuyBo.Enabled = false;
            this.grBoxThongTinKhachHang.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Thoát 
            this.tabChinhSua_btnThem.Enabled = true;
            this.tabChinhSua_btnChinhSua.Enabled = true;
            this.tabChinhSua_btnTroVe.Enabled = true;
        }

        private void tabChinhSua_btnLuu_Click(object sender, EventArgs e)
        {
            // Thêm dữ liệu 
            string err = "";
            if (Them)
            {
                try
                {
                    // Lệnh Insert InTo 
                    bool f = dbKhachHang.ThemKhachHang(ref err,
                    this.tabChinhSua_cbxMaLoaiKH.Text.ToString(),
                    this.tabChinhSua_txtTenKH.Text.ToString(),
                    this.tabChinhSua_txtDiaChi.Text.ToString(),
                    this.tabChinhSua_txtSDT.Text.ToString(),
                    float.Parse(this.tabChinhSua_txtDiemTichLuyHienTai.Text.ToString()),
                    float.Parse(this.tabChinhSua_txtTongDiemTichLuy.Text.ToString()));
                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadDataChinhSua();
                        // Thông báo 
                        MessageBox.Show("Đã thêm xong!");
                    }
                    else
                    {
                        MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException q)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!" + "\nLỗi: " + q.Message);
                }
            }
            else // Sua du lieu
            {
                try
                {

                    bool f = dbKhachHang.CapNhatKhachHang(ref err,
                    this.tabChinhSua_txtMaKH.Text.ToString(),
                    this.tabChinhSua_txtTenKH.Text.ToString(),
                    this.tabChinhSua_cbxMaLoaiKH.Text.ToString(),
                    this.tabChinhSua_txtDiaChi.Text.ToString(),
                    this.tabChinhSua_txtSDT.Text.ToString(),
                    float.Parse(this.tabChinhSua_txtDiemTichLuyHienTai.Text.ToString()),
                    float.Parse(this.tabChinhSua_txtTongDiemTichLuy.Text.ToString()));
                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadDataChinhSua();
                        // Thông báo 
                        MessageBox.Show("Đã cập nhật xong!");
                    }
                    else
                    {
                        MessageBox.Show("Đã cập nhật chưa xong!\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException q)
                {
                    MessageBox.Show("Không cập nhật được. Lỗi rồi! Lỗi: " + q.Message);
                }
            }
        }

        private void tabChinhSua_dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = tabChinhSua_dgvKhachHang.CurrentCell.RowIndex;
            // Chuyển thông tin lên Khung thông tin 
            this.tabChinhSua_txtMaKH.Text =
                tabChinhSua_dgvKhachHang.Rows[r].Cells[0].Value.ToString();
            this.tabChinhSua_cbxMaLoaiKH.SelectedValue =
                tabChinhSua_dgvKhachHang.Rows[r].Cells[1].Value.ToString();
            this.tabChinhSua_txtTenKH.Text =
                tabChinhSua_dgvKhachHang.Rows[r].Cells[2].Value.ToString();
            this.tabChinhSua_txtDiaChi.Text =
                tabChinhSua_dgvKhachHang.Rows[r].Cells[3].Value.ToString();
            this.tabChinhSua_txtSDT.Text =
                tabChinhSua_dgvKhachHang.Rows[r].Cells[4].Value.ToString();
            this.tabChinhSua_txtDiemTichLuyHienTai.Text =
                tabChinhSua_dgvKhachHang.Rows[r].Cells[5].Value.ToString();
            this.tabChinhSua_txtTongDiemTichLuy.Text =
                tabChinhSua_dgvKhachHang.Rows[r].Cells[6].Value.ToString();
        }

        private void tabChinhSua_btnChinhSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            // Cho phép thao tác trên groupbox 
            this.grBoxThongTinKhachHang.Enabled = true;
            // Thứ tự dòng hiện hành 
            int r = tabChinhSua_dgvKhachHang.CurrentCell.RowIndex;
            // Chuyển thông tin lên Khung thông tin 
            this.tabChinhSua_txtMaKH.Text =
                tabChinhSua_dgvKhachHang.Rows[r].Cells[0].Value.ToString();
            this.tabChinhSua_cbxMaLoaiKH.SelectedValue =
                tabChinhSua_dgvKhachHang.Rows[r].Cells[1].Value.ToString();
            this.tabChinhSua_txtTenKH.Text =
                tabChinhSua_dgvKhachHang.Rows[r].Cells[2].Value.ToString();
            this.tabChinhSua_txtDiaChi.Text =
                tabChinhSua_dgvKhachHang.Rows[r].Cells[3].Value.ToString();
            this.tabChinhSua_txtSDT.Text =
                tabChinhSua_dgvKhachHang.Rows[r].Cells[4].Value.ToString();
            this.tabChinhSua_txtDiemTichLuyHienTai.Text =
                tabChinhSua_dgvKhachHang.Rows[r].Cells[5].Value.ToString();
            this.tabChinhSua_txtTongDiemTichLuy.Text =
                tabChinhSua_dgvKhachHang.Rows[r].Cells[6].Value.ToString();
            // Cho thao tác trên các nút Lưu / Hủy / group 
            this.tabChinhSua_btnLuu.Enabled = true;
            this.tabChinhSua_btnHuyBo.Enabled = true;
            this.grBoxThongTinKhachHang.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Thoát 
            this.tabChinhSua_btnThem.Enabled = false;
            this.tabChinhSua_btnChinhSua.Enabled = false;
            this.tabChinhSua_btnTroVe.Enabled = false;
        }

        private void LoadDataTimKiem()
        {
            tabTimKiem_cbxMaKH.Enabled = false;
            tabTimKiem_cbxLoaiKH.Enabled = false;
            tabTimKiem_txtTenKH.Enabled = false;
            // Load dữ liệu vào combobox
            tabTimKiem_cbxMaKH.DataSource = dtKhachHang;
            tabTimKiem_cbxMaKH.DisplayMember = "MaKH";
            tabTimKiem_cbxMaKH.ValueMember = "MaKH";

            tabTimKiem_cbxLoaiKH.DataSource = dtLoaiKH;
            tabTimKiem_cbxLoaiKH.DisplayMember = "MaLoaiKH";
            tabTimKiem_cbxLoaiKH.ValueMember = "TenLoaiKH";

            tabTimKiem_dgvKhachHang.DataSource = dtKhachHang;
            tabTimKiem_txtTongSoBanGhi.Text =
                tabTimKiem_dgvKhachHang.RowCount.ToString();
        }

        private void tabTimKiem_chkMaKH_CheckedChanged(object sender, EventArgs e)
        {
            if (tabTimKiem_chkMaKH.Checked == true)
            {
                tabTimKiem_cbxMaKH.Enabled = true;
            }
            else
            {
                tabTimKiem_cbxMaKH.Enabled = false;
            }
        }

        private void tabTimKiem_chkTenKH_CheckedChanged(object sender, EventArgs e)
        {
            if (tabTimKiem_chkTenKH.Checked == true)
            {
                tabTimKiem_txtTenKH.Enabled = true;
            }
            else
            {
                tabTimKiem_txtTenKH.Enabled = false;
            }
        }

        private void tabTimKiem_chkLoaiKH_CheckedChanged(object sender, EventArgs e)
        {
            if (tabTimKiem_chkLoaiKH.Checked == true)
            {
                tabTimKiem_cbxLoaiKH.Enabled = true;
            }
            else
            {
                tabTimKiem_cbxLoaiKH.Enabled = false;
            }
        }

        private void tabTimKiem_btnLoc_Click(object sender, EventArgs e)
        {
            string maKH = null, tenKH = null, tenLoaiKH = null;
            if (tabTimKiem_chkMaKH.Checked == true)
            {
                maKH = tabTimKiem_cbxMaKH.Text.ToString();
            }
            if (tabTimKiem_chkTenKH.Checked == true)
            {
                tenKH = tabTimKiem_txtTenKH.Text.ToString();
            }
            if (tabTimKiem_chkLoaiKH.Checked == true)
            {
                tenLoaiKH = tabTimKiem_cbxLoaiKH.SelectedValue.ToString();
            }

            dtLocKhachHang = new DataTable();
            dtLocKhachHang.Clear();
            dtLocKhachHang = dbKhachHang.TimKiemThongTinKhachHang(maKH, tenKH,
                tenLoaiKH).Tables[0];
            tabTimKiem_dgvKhachHang.DataSource = dtLocKhachHang;
            tabTimKiem_txtTongSoBanGhi.Text =
                tabTimKiem_dgvKhachHang.RowCount.ToString();
        }

        private void tabTimKiem_btnReload_Click(object sender, EventArgs e)
        {
            LoadDataTimKiem();
        }
    }
}
