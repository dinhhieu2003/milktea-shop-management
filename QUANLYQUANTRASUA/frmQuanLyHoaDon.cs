using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace QUANLYQUANTRASUA
{
    public partial class frmQuanLyHoaDon : Form
    {
        // Tạo các db
        DBChiTietHoaDon dbChiTietHoaDon;
        DBHoaDon dbHoaDon;
        DBNhanVien dbNhanVien;
        DBKhachHang dbKhachHang;
        // Tạo các bảng
        DataTable dtHoaDon = null;
        DataTable dtNhanVien = null;
        DataTable dtKhachHang = null;
        DataTable dtLocHoaDon = null;
        DataTable dtLocChiTietHoaDon = null;
 
        public frmQuanLyHoaDon()
        {
            InitializeComponent();
            dbChiTietHoaDon = new DBChiTietHoaDon();
            dbHoaDon = new DBHoaDon();
            dbChiTietHoaDon = new DBChiTietHoaDon();
            dbNhanVien = new DBNhanVien();
            dbKhachHang = new DBKhachHang();
        }

        private void LoadDataTimKiemHoaDon()
        {
            try
            {
                /* Vận chuyển dữ liệu vào DataTable */

                // dtHoaDon
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                dtHoaDon = dbHoaDon.LayThongTinViewHoaDon().Tables[0];

                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                dtNhanVien = dbNhanVien.LayThongTinNhanVien().Tables[0];

                dtKhachHang = new DataTable();
                dtKhachHang.Clear();
                dtKhachHang = dbKhachHang.LayThongTinKhachHang().Tables[0];

                /*Đưa vào combobox*/
                //Mã nhân viên
                tabTimKiemHoaDon_cbxMaNV.DataSource = dtNhanVien;
                tabTimKiemHoaDon_cbxMaNV.DisplayMember = "MaNV";
                tabTimKiemHoaDon_cbxMaNV.ValueMember = "MaNV";

                // Mã khách hàng
                tabTimKiemHoaDon_cbxMaKH.DataSource = dtKhachHang;
                tabTimKiemHoaDon_cbxMaKH.DisplayMember = "MaKH";
                tabTimKiemHoaDon_cbxMaKH.ValueMember = "MaKH";

                /* Vận chuyển dữ liệu vào Datagridview */
                tabTimKiemHoaDon_dgvHoaDon.DataSource = dtHoaDon;
                tabTimKiemHoaDon_txtTongSoBanGhi.Text =
                    tabTimKiemHoaDon_dgvHoaDon.RowCount.ToString();
                tabTimKiemHoaDon_txtTongSoTien.Text =
                    dbHoaDon.TinhTongDanhSachHoaDon
                        (null, null, new DateTime(1, 1, 1)).ToString("0.########");

                /*Không cho thao tác trên các thanh nhập thông tin tìm kiếm*/
                tabTimKiemHoaDon_cbxMaNV.Enabled = false;
                tabTimKiemHoaDon_cbxMaKH.Enabled = false;
                tabTimKiemHoaDon_dtpNgayHoaDon.Enabled = false;
             
            }
            catch (SqlException q)
            {
                MessageBox.Show(q.Message);

            }
        }

        private void frmQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            LoadDataTimKiemHoaDon();
            LoadDataCTHD();
        }

        private void tabTimKiemHoaDon_chkNgayHoaDon_CheckedChanged(object sender, EventArgs e)
        {
            if (tabTimKiemHoaDon_chkNgayHoaDon.Checked == true)
            {
                tabTimKiemHoaDon_dtpNgayHoaDon.Enabled = true;
            }
            else
            {
               tabTimKiemHoaDon_dtpNgayHoaDon.Enabled = false;
            }
        }

        private void tabTimKiemHoaDon_chkMaNV_CheckedChanged(object sender, EventArgs e)
        {
            if(tabTimKiemHoaDon_chkMaNV.Checked == true)
            {
                tabTimKiemHoaDon_cbxMaNV.Enabled = true;
            }
            else
            {
                tabTimKiemHoaDon_cbxMaNV.Enabled = false;
            }
        }

        private void tabTimKiemHoaDon_chkMaKH_CheckedChanged(object sender, EventArgs e)
        {
            if(tabTimKiemHoaDon_chkMaKH.Checked == true)
            {
                tabTimKiemHoaDon_cbxMaKH.Enabled = true;
            }
            else
            {
                tabTimKiemHoaDon_cbxMaKH.Enabled = false;
            }
        }

        private void tabTimKiemHoaDon_btnLoc_Click(object sender, EventArgs e)
        {
            string MaNV = null, MaKH = null;
            DateTime NgayHoaDon = new DateTime(1,1,1);
            if (tabTimKiemHoaDon_chkMaNV.Checked == true)
            {
                MaNV = tabTimKiemHoaDon_cbxMaNV.Text.ToString();
            }
            if (tabTimKiemHoaDon_chkMaKH.Checked == true)
            {
                MaKH = tabTimKiemHoaDon_cbxMaKH.Text.ToString();
            }
            if (tabTimKiemHoaDon_chkNgayHoaDon.Checked == true)
            {
                NgayHoaDon = tabTimKiemHoaDon_dtpNgayHoaDon.Value.Date;
            }
            dtLocHoaDon = new DataTable();
            dtLocHoaDon.Clear();
            dtLocHoaDon =
                dbHoaDon.TimKiemThongTinHoaDon(MaNV, MaKH, NgayHoaDon).Tables[0];

            tabTimKiemHoaDon_dgvHoaDon.DataSource = dtLocHoaDon;
            tabTimKiemHoaDon_txtTongSoBanGhi.Text = tabTimKiemHoaDon_dgvHoaDon.RowCount.ToString();
            tabTimKiemHoaDon_txtTongSoTien.Text =
               dbHoaDon.TinhTongDanhSachHoaDon(MaNV, MaKH, NgayHoaDon).ToString("0.########");
        }

        private void tabTimKiemHoaDon_btnReload_Click(object sender, EventArgs e)
        {
            LoadDataTimKiemHoaDon();
        }

        private void tabTimKiemHoaDon_btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void LoadDataCTHD()
        {
            tabChiTietHoaDon_cbxMaHoaDon.DataSource = dtHoaDon;
            tabChiTietHoaDon_cbxMaHoaDon.DisplayMember = "MaHoaDon";
            tabChiTietHoaDon_cbxMaHoaDon.ValueMember = "MaHoaDon";
        }

        private void tabChiTietHoaDon_btnLoc_Click(object sender, EventArgs e)
        {
            string MaHoaDon = this.tabChiTietHoaDon_cbxMaHoaDon.Text.ToString();
            dtLocChiTietHoaDon = new DataTable();
            dtLocChiTietHoaDon.Clear();
            dtLocChiTietHoaDon =
                dbChiTietHoaDon.TimKiemThongTinCTHD(MaHoaDon).Tables[0];
            dgvChiTietHoaDon.DataSource = dtLocChiTietHoaDon;
            tabChiTietHoaDon_txtTongSoBanGhi.Text = 
                dgvChiTietHoaDon.RowCount.ToString();
            tabChiTietHoaDon_txtTongSoTien.Text =
                dbChiTietHoaDon.LayTongSoTienCTHD(MaHoaDon).ToString();

        }
    }
}
