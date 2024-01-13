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
    public partial class frmQuanLyKho : Form
    {
        DBLuuTru dbLuuTru;
        DBNguyenVatLieu dbNVL;
        DBNhapKho dbNhapKho;
        DBXuatKho dbXuatKho;

        DataTable dtLuuTru = null;
        DataTable dtLocKhoLuuTru = null;
        DataTable dtNVL= null;
        DataTable dtNhapKho = null;
        DataTable dtLocNhapKho = null;
        DataTable dtXuatKho = null;
        DataTable dtLocXuatKho = null;
        public frmQuanLyKho()
        {
            InitializeComponent();
            dbLuuTru = new DBLuuTru();
            dbNVL = new DBNguyenVatLieu();
            dbNhapKho = new DBNhapKho();
            dbXuatKho = new DBXuatKho();
        }

        void LoadDataKhoLuuTru()
        {
            tabKhoLuuTru_dgvKhoLuuTru.Columns[2].DefaultCellStyle.Format =
                "dd/MM/yyyy";
            tabKhoLuuTru_dgvKhoLuuTru.Columns[5].DefaultCellStyle.Format =
                "dd/MM/yyyy";
            dtLuuTru = new DataTable();
            dtLuuTru.Clear();
            dtLuuTru = dbLuuTru.LayThongTinViewLuuTru().Tables[0];
            tabKhoLuuTru_dgvKhoLuuTru.DataSource = dtLuuTru;
            tabKhoLuuTru_txtTongSoBanGhi.Text =
                tabKhoLuuTru_dgvKhoLuuTru.RowCount.ToString();
            tabKhoLuuTru_dtpNgayThang.Enabled = false;
            tabKhoLuuTru_cbxTenNVL.Enabled = false;

            dtNVL = new DataTable();
            dtNVL.Clear();
            dtNVL = dbNVL.LayThongTinNguyenVatLieu().Tables[0];
            tabKhoLuuTru_cbxTenNVL.DataSource = dtNVL;
            tabKhoLuuTru_cbxTenNVL.DisplayMember = "TenNVL";
            tabKhoLuuTru_cbxTenNVL.ValueMember = "MaNVL";
        }

        private void frmQuanLyKho_Load(object sender, EventArgs e)
        {
            LoadDataKhoLuuTru();
            LoadDataLichSuNhapKho();
            LoadDataLichSuXuatKho();
        }

        private void tabKhoLuuTru_chkNgayThang_CheckedChanged(object sender, EventArgs e)
        {
            if(tabKhoLuuTru_chkNgayThang.Checked == true)
            {
                tabKhoLuuTru_dtpNgayThang.Enabled = true;
            }
            else
            {
                tabKhoLuuTru_dtpNgayThang.Enabled = false;
            }
        }

        private void tabKhoLuuTru_chkTenNguyenVatLieu_CheckedChanged(object sender, EventArgs e)
        {
            if(tabKhoLuuTru_chkTenNguyenVatLieu.Checked == true)
            {
                tabKhoLuuTru_cbxTenNVL.Enabled = true;
            }
            else
            {
                tabKhoLuuTru_cbxTenNVL.Enabled = false;
            }
        }

        private void tabKhoLuuTru_btnLoc_Click(object sender, EventArgs e)
        {
            string TenNVL = null;
            DateTime NgayThang = new DateTime(1, 1, 1);
            if (tabKhoLuuTru_chkTenNguyenVatLieu.Checked == true)
            {
                TenNVL = tabKhoLuuTru_cbxTenNVL.Text.ToString().Trim();
            }
            if (tabKhoLuuTru_chkNgayThang.Checked == true)
            {
                NgayThang = tabKhoLuuTru_dtpNgayThang.Value.Date;
            }
            dtLocKhoLuuTru = new DataTable();
            dtLocKhoLuuTru.Clear();
            dtLocKhoLuuTru = dbLuuTru.TimKiemThongTinKhoLuuTru(NgayThang, TenNVL).Tables[0];
            tabKhoLuuTru_dgvKhoLuuTru.DataSource = dtLocKhoLuuTru;
            tabKhoLuuTru_txtTongSoBanGhi.Text = 
                tabKhoLuuTru_dgvKhoLuuTru.RowCount.ToString();
        }

        private void tabKhoLuuTru_btnReload_Click(object sender, EventArgs e)
        {
            LoadDataKhoLuuTru();
        }

        private void tabKhoLuuTru_btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabKhoLuuTru_btnNhapKho_Click(object sender, EventArgs e)
        {
            frmNhapKho frm = new frmNhapKho();
            frm.ShowDialog();
            string MaNVL = frm.MaNVL;
            int SoLuong = frm.SoLuong;
            string HSD = frm.HSD;
            string err = "";
            try
            {
                bool f = dbNhapKho.ThaoTacNhapKho(ref err,
                MaNVL, SoLuong, DateTime.Now, DateTime.Now, HSD);
                if (f)
                {
                    // Load lại dữ liệu trên DataGridView 
                    LoadDataKhoLuuTru();
                    // Thông báo 
                    MessageBox.Show("Đã nhập xong!");
                }
                else
                {
                    MessageBox.Show("Thao tác không hoàn tất!\n\r" + "Lỗi: " + err);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể thao tác. Lỗi rồi!");
            }
        }

        private void tabKhoLuuTru_btnXuatKho_Click(object sender, EventArgs e)
        {
            frmXuatKho frm = new frmXuatKho();
            frm.ShowDialog();
            string MaNVL = frm.MaNVL.ToString();
            string MaKho = frm.MaKho.ToString();
            int SoLuongXuat = frm.SoLuongXuat;
            string err = "";
            try
            {
                bool f = dbXuatKho.ThaoTacXuatKho(ref err,
                MaNVL, MaKho, SoLuongXuat, DateTime.Now);
                if (f)
                {
                    // Load lại dữ liệu trên DataGridView 
                    LoadDataKhoLuuTru();
                    // Thông báo 
                    MessageBox.Show("Đã xuất kho thành công!");
                }
                else
                {
                    MessageBox.Show("Thao tác không hoàn tất!\n\r" + "Lỗi: " + err);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể thao tác. Lỗi rồi!");
            }
        }

        void LoadDataLichSuNhapKho()
        {
            tabNhapKho_dgvNhapKho.Columns[0].DefaultCellStyle.Format =
                "dd/MM/yyyy";
            tabNhapKho_dtpNgayNhapKho.Enabled = false;
            tabNhapKho_cbxTenNVL.Enabled = false;
            tabNhapKho_cbxTenNVL.DataSource = dtNVL;
            tabNhapKho_cbxTenNVL.DisplayMember = "TenNVL";
            tabNhapKho_cbxTenNVL.ValueMember = "MaNVL";

            dtNhapKho = new DataTable();
            dtNhapKho.Clear();
            dtNhapKho = dbNhapKho.LayThongTinViewNhapKho().Tables[0];
            tabNhapKho_dgvNhapKho.DataSource = dtNhapKho;
            tabNhapKho_txtTongSoBanGhi.Text =
                tabNhapKho_dgvNhapKho.RowCount.ToString();
            
        }

        private void tabNhapKho_chkNgayThang_CheckedChanged(object sender, EventArgs e)
        {
            if(tabNhapKho_chkNgayThang.Checked == true)
            {
                tabNhapKho_dtpNgayNhapKho.Enabled = true;
            }
            else
            {
                tabNhapKho_dtpNgayNhapKho.Enabled = false;
            }
        }

        private void tabNhapKho_chkTenNVL_CheckedChanged(object sender, EventArgs e)
        {
            if(tabNhapKho_chkTenNVL.Checked == true)
            {
                tabNhapKho_cbxTenNVL.Enabled = true;
            }
            else
            {
                tabNhapKho_cbxTenNVL.Enabled= false;
            }
        }

        private void tabNhapKho_btnLoc_Click(object sender, EventArgs e)
        {
            string TenNVL = null;
            DateTime NgayThang = new DateTime(1, 1, 1);
            if (tabNhapKho_chkTenNVL.Checked == true)
            {
                TenNVL = tabNhapKho_cbxTenNVL.Text.ToString().Trim();
            }
            if (tabNhapKho_chkNgayThang.Checked == true)
            {
                NgayThang = tabNhapKho_dtpNgayNhapKho.Value.Date;
            }
            dtLocNhapKho = new DataTable();
            dtLocNhapKho.Clear();
            dtLocNhapKho = dbNhapKho.TimKiemThongTinNhapKho(NgayThang, TenNVL).Tables[0];
            tabNhapKho_dgvNhapKho.DataSource = dtLocNhapKho;
            tabNhapKho_txtTongSoBanGhi.Text =
                tabNhapKho_dgvNhapKho.RowCount.ToString();
        }

        private void tabNhapKho_btnReload_Click(object sender, EventArgs e)
        {
            LoadDataLichSuNhapKho();
        }

        void LoadDataLichSuXuatKho()
        {
            tabXuatKho_dgvXuatKho.Columns[0].DefaultCellStyle.Format =
                "dd/MM/yyyy";
            tabXuatKho_dgvXuatKho.Columns[1].DefaultCellStyle.Format =
                "dd/MM/yyyy HH:mm:ss";
            tabXuatKho_dtpNgayXuatKho.Enabled = false;
            tabXuatKho_cbxTenNVL.Enabled = false;
            tabXuatKho_cbxTenNVL.DataSource = dtNVL;
            tabXuatKho_cbxTenNVL.DisplayMember = "TenNVL";
            tabXuatKho_cbxTenNVL.ValueMember = "MaNVL";
            dtXuatKho = new DataTable();
            dtXuatKho.Clear();
            dtXuatKho = dbXuatKho.LayThongTinViewXuatKho().Tables[0];
            tabXuatKho_dgvXuatKho.DataSource = dtXuatKho;
            tabXuatKho_txtTongSoBanGhi.Text =
                tabXuatKho_dgvXuatKho.RowCount.ToString();
        }

        private void tabXuatKho_chkNgayXuatKho_CheckedChanged(object sender, EventArgs e)
        {
            if(tabXuatKho_chkNgayXuatKho.Checked == true)
            {
                tabXuatKho_dtpNgayXuatKho.Enabled = true;
            }
            else
            {
                tabXuatKho_dtpNgayXuatKho.Enabled=false;
            }
        }

        private void tabXuatKho_chkTenNVL_CheckedChanged(object sender, EventArgs e)
        {
            if(tabXuatKho_chkTenNVL.Checked == true)
            {
                tabXuatKho_cbxTenNVL.Enabled = true;
            }
            else
            {
                tabXuatKho_cbxTenNVL.Enabled = false;
            }
        }

        private void tabXuatKho_btnLoc_Click(object sender, EventArgs e)
        {
            string TenNVL = null;
            DateTime NgayXuat = new DateTime(1, 1, 1);
            if (tabXuatKho_chkTenNVL.Checked == true)
            {
                TenNVL = tabNhapKho_cbxTenNVL.Text.ToString().Trim();
            }
            if (tabXuatKho_chkNgayXuatKho.Checked == true)
            {
                NgayXuat = tabXuatKho_dtpNgayXuatKho.Value.Date;
            }
            dtLocXuatKho = new DataTable();
            dtLocXuatKho.Clear();
            dtLocXuatKho = dbXuatKho.TimKiemThongTinXuatKho(NgayXuat, TenNVL).Tables[0];
            tabXuatKho_dgvXuatKho.DataSource = dtLocXuatKho;
            tabXuatKho_txtTongSoBanGhi.Text =
                tabXuatKho_dgvXuatKho.RowCount.ToString();
        }

        private void tabXuatKho_btnReload_Click(object sender, EventArgs e)
        {
            LoadDataLichSuXuatKho();
        }
    }
}
