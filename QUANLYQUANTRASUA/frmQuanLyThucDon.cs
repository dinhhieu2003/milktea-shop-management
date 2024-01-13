using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYQUANTRASUA
{
    public partial class frmQuanLyThucDon : Form
    {
        DBMatHang dbMatHang;
        DBLoaiMatHang dbLoaiMatHang;
        DataTable dtMatHang = null;
        DataTable dtLoaiMatHang = null;
        string g_MaLoaiMH;
        bool Them;
        public frmQuanLyThucDon()
        {
            InitializeComponent();
            dbMatHang = new DBMatHang();
            dbLoaiMatHang = new DBLoaiMatHang();
        }

        private void LoadData()
        {
            dtLoaiMatHang = new DataTable();
            dtLoaiMatHang.Clear();
            dtLoaiMatHang = dbLoaiMatHang.LayThongTinLoaiMatHang().Tables[0];
            cbxMaLoaiMH.DataSource = dtLoaiMatHang;
            cbxMaLoaiMH.DisplayMember = "TenLoaiHang";
            cbxMaLoaiMH.ValueMember = "MaLoaiMH";

            dtMatHang = new DataTable();
            dtMatHang.Clear();
            dtMatHang = dbMatHang.LayThongTinViewMatHang().Tables[0];

            dgvMenu.DataSource = dtMatHang;

            txtMaMH.ResetText();
            txtTenMH.ResetText();
            txtGiaTien.ResetText();
            grBoxThongTinMatHang.Enabled = false;

            btnChinhSua.Enabled = true;
            btnThem.Enabled = true;
            btnReload.Enabled = true;
            btnTroVe.Enabled = true;
        }

        private void frmQuanLyThucDon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            txtMaMH.ResetText();
            txtMaMH.Enabled = true;
            txtTenMH.ResetText();
            txtGiaTien.ResetText();
            grBoxThongTinMatHang.Enabled = true;

            btnChinhSua.Enabled = false;
            btnReload.Enabled = false;
            btnTroVe.Enabled = false;
            btnThem.Enabled = false;

            btnHuyBo.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            txtMaMH.ResetText();
            txtMaMH.Enabled = true;
            txtTenMH.ResetText();
            txtGiaTien.ResetText();
            grBoxThongTinMatHang.Enabled = false;

            btnChinhSua.Enabled = true;
            btnReload.Enabled = true;
            btnTroVe.Enabled = true;
            btnThem.Enabled = true;

            btnHuyBo.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            Them = false;
            int r = dgvMenu.CurrentCell.RowIndex;
            txtMaMH.Text = dgvMenu.Rows[r].Cells[0].Value.ToString();
            txtTenMH.Text = dgvMenu.Rows[r].Cells[2].Value.ToString();
            txtGiaTien.Text = dgvMenu.Rows[r].Cells[3].Value.ToString();

            string tenLoaiMatHang =
                dgvMenu.Rows[r].Cells[1].Value.ToString();

            // Tìm giá trị tương ứng trong ComboBox
            int index = cbxMaLoaiMH.FindStringExact(tenLoaiMatHang);
            if (index != -1)
            {
                cbxMaLoaiMH.SelectedIndex = index;
                g_MaLoaiMH = cbxMaLoaiMH.SelectedValue.ToString();
            }

            grBoxThongTinMatHang.Enabled = true;
            txtMaMH.Enabled = false;

            btnChinhSua.Enabled = false;
            btnReload.Enabled = false;
            btnTroVe.Enabled = false;
            btnThem.Enabled = false;

            btnHuyBo.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvMenu.CurrentCell.RowIndex;
            txtMaMH.Text = dgvMenu.Rows[r].Cells[0].Value.ToString();
            txtTenMH.Text = dgvMenu.Rows[r].Cells[2].Value.ToString();
            txtGiaTien.Text = dgvMenu.Rows[r].Cells[3].Value.ToString();

            string tenLoaiMatHang =
                dgvMenu.Rows[r].Cells[1].Value.ToString();

            // Tìm giá trị tương ứng trong ComboBox
            int index = cbxMaLoaiMH.FindStringExact(tenLoaiMatHang);
            if (index != -1)
            {
                cbxMaLoaiMH.SelectedIndex = index;
                g_MaLoaiMH = cbxMaLoaiMH.SelectedValue.ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string err = "";
            if (Them)
            {
                try
                {
                    // Lệnh Insert InTo 
                    bool f = dbMatHang.ThemMatHang(ref err,
                    txtMaMH.Text.ToString(), cbxMaLoaiMH.SelectedValue.ToString(),
                    txtTenMH.Text.ToString(), 
                    float.Parse(txtGiaTien.Text.ToString()));
                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Đã thêm thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm chưa hoàn tất!\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException q)
                {
                    MessageBox.Show("Không thể thêm được. Lỗi rồi!" + "\nLỗi: " + q.Message);
                }
            }
            else
            {
                try
                {
                    bool f = dbMatHang.SuaMatHang(ref err,
                    txtMaMH.Text.ToString(), cbxMaLoaiMH.SelectedValue.ToString(),
                    txtTenMH.Text.ToString(),
                    float.Parse(txtGiaTien.Text.ToString()));
                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Đã cập nhật xong!");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật không hoàn tất!\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException q)
                {
                    MessageBox.Show("Không thể cập nhật được. Lỗi rồi! Lỗi: " + q.Message);
                }
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
