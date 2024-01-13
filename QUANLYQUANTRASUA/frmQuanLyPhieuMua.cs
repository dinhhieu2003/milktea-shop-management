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
    public partial class frmQuanLyPhieuMua : Form
    {
        bool Them;
        // Dữ liệu
        DBPhieuMua dbPhieuMua;
        DBChiTietMua dbChiTietMua;
        DBNguyenVatLieu dbNguyenVatLieu;
        // Bảng dữ liệu
        DataTable dtPhieuMua, dtChiTietMua, dtNguyenVatLieu, dtLocChiTietMua;
        
        public frmQuanLyPhieuMua()
        {
            InitializeComponent();
            dbPhieuMua = new DBPhieuMua();
            dbChiTietMua = new DBChiTietMua();
            dbNguyenVatLieu = new DBNguyenVatLieu();
        }
        public void LoadDataTimKiemPhieuMua()
        {
            tabTimKiem_cbxMaPhieuMua.DataSource = dtPhieuMua;
            tabTimKiem_cbxMaPhieuMua.DisplayMember = "MaPhieuMua";
            tabTimKiem_cbxMaPhieuMua.ValueMember = "MaPhieuMua";

            tabTimKiem_cbxTenNVL.DataSource = dtNguyenVatLieu;
            tabTimKiem_cbxTenNVL.DisplayMember = "TenNVL";
            tabTimKiem_cbxTenNVL.ValueMember = "TenNVL";

            tabTimKiem_dgvChiTietMua.DataSource = dtChiTietMua;
            tabTimKiem_txtTongBanGhi.Text = 
                tabTimKiem_dgvChiTietMua.RowCount.ToString();
            tabTimKiem_txtTongTien.Text =
                dbChiTietMua.TinhTongDanhSachPhieuMua
                (null, null, new DateTime(1, 1, 1)).ToString("0.########");

            tabTimKiem_cbxMaPhieuMua.Enabled = false;
            tabTimKiem_cbxTenNVL.Enabled = false;
            tabTimKiem_dtpNgayThangNam.Enabled = false;
        }
        private void dgvChiTietPhieuMua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvChiTietPhieuMua.CurrentCell.RowIndex;
            this.tabChinhSua_cbxMaPhieuMua.Text =
                dgvChiTietPhieuMua.Rows[r].Cells[0].Value.ToString();
            this.tabChinhSua_cbxTenNVL.Text =
                dgvChiTietPhieuMua.Rows[r].Cells[2].Value.ToString();
            this.tabChinhSua_dtpNgayMua.Text =
                dgvChiTietPhieuMua.Rows[r].Cells[5].Value.ToString();
            this.tabChinhSua_dtpGioMua.Text =
                dgvChiTietPhieuMua.Rows[r].Cells[5].Value.ToString();
        }

        private void tabChinhSua_btnThem_Click(object sender, EventArgs e)
        {
            Them = true;

            grBoxThongTinChiTietPhieuMua.Enabled = true;
            this.tabChinhSua_btnLuu.Enabled = true;
            this.tabChinhSua_btnHuyBo.Enabled = true;

            this.tabChinhSua_dtpNgayMua.Enabled = false;
            this.tabChinhSua_dtpGioMua.Enabled = false;

            this.tabChinhSua_btnThem.Enabled = false;
            this.tabChinhSua_btnChinhSua.Enabled = false;
            this.tabChinhSua_btnXoa.Enabled = false;
            this.tabChinhSua_btnTroVe.Enabled = false;
        }

        private void tabChinhSua_btnChinhSua_Click(object sender, EventArgs e)
        {
            Them = false;

            this.grBoxThongTinChiTietPhieuMua.Enabled = true;

            int r = dgvChiTietPhieuMua.CurrentCell.RowIndex;
            this.tabChinhSua_cbxMaPhieuMua.Text =
                dgvChiTietPhieuMua.Rows[r].Cells[0].Value.ToString();
            this.tabChinhSua_cbxTenNVL.Text =
                dgvChiTietPhieuMua.Rows[r].Cells[2].Value.ToString();
            this.tabChinhSua_dtpNgayMua.Text =
                dgvChiTietPhieuMua.Rows[r].Cells[5].Value.ToString();
            this.tabChinhSua_dtpGioMua.Text =
                dgvChiTietPhieuMua.Rows[r].Cells[5].Value.ToString();

            this.tabChinhSua_btnLuu.Enabled = true;
            this.tabChinhSua_btnHuyBo.Enabled = true;

            this.tabChinhSua_btnThem.Enabled = false;
            this.tabChinhSua_btnChinhSua.Enabled = false;
            this.tabChinhSua_btnXoa.Enabled = false;
            this.tabChinhSua_btnTroVe.Enabled = false;
        }

        private void tabChinhSua_btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvChiTietPhieuMua.CurrentCell.RowIndex;

                string strMaPhieuMua =
                    dgvChiTietPhieuMua.Rows[r].Cells[0].Value.ToString();
                string strMaNVL =
                    dgvChiTietPhieuMua.Rows[r].Cells[1].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                string err = "";
                if (traloi == DialogResult.Yes)
                {

                    // Thực hiện câu lệnh SQL 
                    bool f = dbChiTietMua.XoaChiTietMua(ref err, strMaPhieuMua, strMaNVL);
                    if (f)
                    {
                        // Cập nhật lại DataGridView 
                        LoadDataChinhSuaChiTietMua();
                        // Thông báo 
                        MessageBox.Show("Đã xóa xong!");
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được!\n\r" + "Lỗi:" + err);
                    }
                }
                else
                {
                    // Thông báo 
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!!!");
            }
}

        private void tabChinhSua_btnReload_Click(object sender, EventArgs e)
        {
            LoadDataChinhSuaChiTietMua();
        }

        private void tabChinhSua_btnHuyBo_Click(object sender, EventArgs e)
        {
            this.tabChinhSua_btnLuu.Enabled = false;
            this.tabChinhSua_btnHuyBo.Enabled = false;
            this.grBoxThongTinChiTietPhieuMua.Enabled = false;

            this.tabChinhSua_btnThem.Enabled = true;
            this.tabChinhSua_btnChinhSua.Enabled = true;
            this.tabChinhSua_btnXoa.Enabled = true;
            this.tabChinhSua_btnTroVe.Enabled = true;
        }

        private void tabChinhSua_btnLuu_Click(object sender, EventArgs e)
        {
            int r = dgvChiTietPhieuMua.CurrentCell.RowIndex;
            string err = "";
            if (Them)
            {
                try
                {
                    // Lệnh Insert InTo 
                    bool f = dbChiTietMua.ThemChiTietMua(ref err,
                    this.tabChinhSua_cbxMaPhieuMua.SelectedValue.ToString(),
                    this.dgvChiTietPhieuMua.Rows[r].Cells[1].Value.ToString(),
                    (int)tabChinhSua_nudSoLuongMua.Value);
                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadDataChinhSuaChiTietMua();
                        // Thông báo 
                        MessageBox.Show("Đã thêm xong!");
                    }
                    else
                    {
                        MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            else // Sua du lieu
            {
                try
                {

                    bool f = dbChiTietMua.SuaChiTietMua(ref err, 
                    this.tabChinhSua_cbxMaPhieuMua.SelectedValue.ToString(),
                    this.dgvChiTietPhieuMua.Rows[r].Cells[1].Value.ToString(),
                    (int)tabChinhSua_nudSoLuongMua.Value);
                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadDataChinhSuaChiTietMua();
                        // Thông báo 
                        MessageBox.Show("Đã cập nhật xong!");
                    }
                    else
                    {
                        MessageBox.Show("Đã cập nhật chưa xong!\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không cập nhật được. Lỗi rồi!");
                }
            }
        }

        private void chkNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgay.Checked == true)
                tabTimKiem_dtpNgayThangNam.Enabled = true;
            else
                tabTimKiem_dtpNgayThangNam.Enabled = false;
        }

        private void chkMaPhieuMua_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMaPhieuMua.Checked == true)
                tabTimKiem_cbxMaPhieuMua.Enabled = true;
            else
                tabTimKiem_cbxMaPhieuMua.Enabled = false;
        }

        private void checkTenNVL_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTenNVL.Checked == true)
                tabTimKiem_cbxTenNVL.Enabled = true;
            else
                tabTimKiem_cbxTenNVL.Enabled = false;
        }

        private void tabChinhSua_btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabTimKiem_btnLoc_Click(object sender, EventArgs e)
        {
            string MaPhieuMua = null, TenNVL = null;
            DateTime NgayGioMua = new DateTime(1, 1, 1);
            if (chkMaPhieuMua.Checked == true)
            {
                MaPhieuMua = tabTimKiem_cbxMaPhieuMua.Text.ToString();
            }
            if (checkTenNVL.Checked == true)
            {
                TenNVL = tabTimKiem_cbxTenNVL.Text.ToString();
            }
            if (chkNgay.Checked == true)
            {
                NgayGioMua = tabTimKiem_dtpNgayThangNam.Value.Date;
            }

            dtLocChiTietMua = new DataTable();
            dtLocChiTietMua.Clear();
            dtLocChiTietMua =
                dbChiTietMua.TimKiemChiTietPhieuMua(MaPhieuMua, TenNVL, NgayGioMua).Tables[0];

            tabTimKiem_dgvChiTietMua.DataSource = dtLocChiTietMua;
            tabTimKiem_txtTongBanGhi.Text = tabTimKiem_dgvChiTietMua.RowCount.ToString();
            tabTimKiem_txtTongTien.Text =
                dbChiTietMua.TinhTongDanhSachPhieuMua
                    (MaPhieuMua,TenNVL,NgayGioMua).ToString("0.########");

        }

        public void LoadDataChinhSuaChiTietMua()
        {
            try
            {
                dtChiTietMua = new DataTable();
                dtChiTietMua.Clear();
                dtChiTietMua = dbChiTietMua.LayThongTinViewChiTietMua().Tables[0];

                dtNguyenVatLieu = new DataTable();
                dtNguyenVatLieu.Clear();
                dtNguyenVatLieu = dbNguyenVatLieu.LayThongTinNguyenVatLieu().Tables[0];

                dtPhieuMua = new DataTable();
                dtPhieuMua.Clear();
                dtPhieuMua = dbPhieuMua.LayThongTinPhieuMua().Tables[0];

                tabChinhSua_cbxMaPhieuMua.DataSource = dtPhieuMua;
                tabChinhSua_cbxMaPhieuMua.DisplayMember = "MaPhieuMua";
                tabChinhSua_cbxMaPhieuMua.ValueMember = "MaPhieuMua";

                tabChinhSua_cbxTenNVL.DataSource = dtNguyenVatLieu;
                tabChinhSua_cbxTenNVL.DisplayMember = "TenNVL";
                tabChinhSua_cbxTenNVL.ValueMember = "MaNVL";

                dgvChiTietPhieuMua.DataSource = dtChiTietMua;

                tabChinhSua_btnHuyBo.Enabled = false;
                tabChinhSua_btnLuu.Enabled = false;
                grBoxThongTinChiTietPhieuMua.Enabled = false;

                this.tabChinhSua_btnThem.Enabled = true;
                this.tabChinhSua_btnChinhSua.Enabled = true;
                this.tabChinhSua_btnXoa.Enabled = true;
                this.tabChinhSua_btnTroVe.Enabled = true;
            }
            catch (SqlException q)
            {
                MessageBox.Show(q.Message);
            }
        }
        private void frmQuanLyPhieuMua_Load(object sender, EventArgs e)
        {
            LoadDataChinhSuaChiTietMua();
            LoadDataTimKiemPhieuMua();
        }

        private void tabThemPhieuMua_btnThem_Click(object sender, EventArgs e)
        {
            DateTime NgayMua =
                tabThemPhieuMua_dtpNgayMua.Value.Date +
                    tabThemPhieuMua_dtpGioMua.Value.TimeOfDay;
            string err = "";
            try
            {
                // Lệnh Insert InTo 
                bool f = dbPhieuMua.ThemPhieuMua(ref err,
                NgayMua);
                if (f)
                {
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
                MessageBox.Show("Không thêm được. Lỗi rồi! Lỗi: " + q.Message);
            }
        }
    }
}
