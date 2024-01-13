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
    public partial class frmQuanLyCaLam : Form
    {
        //Khai báo các db cần dùng
        DBCaLam dbCaLam;
        DBLoaiCa dbLoaiCa;
        // Tạo các bảng của các db này
        DataTable dtCaLam = null;
        DataTable dtLoaiCa = null;
        DataTable dtLocCaLam = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;
        public frmQuanLyCaLam()
        {
            dbCaLam = new DBCaLam();
            dbLoaiCa = new DBLoaiCa();
            InitializeComponent();
        }

        private void loadDataChinhSua()
        {
            try
            {
                /* Vận chuyển dữ liệu vào DataTable */

                // dtCaLam
                dtCaLam = new DataTable();
                dtCaLam.Clear();
                dtCaLam = dbCaLam.LayThongTinViewCaLam().Tables[0];

                //dtLoaiCa
                dtLoaiCa = new DataTable();
                dtLoaiCa.Clear();
                dtLoaiCa = dbLoaiCa.LayThongTinLoaiCa().Tables[0];


                /* Đưa dữ liệu lên combobox */

                // combobox MaLoaiCa
                this.tabChinhSua_cbxMaLoaiCa.DataSource = dtLoaiCa;
                this.tabChinhSua_cbxMaLoaiCa.DisplayMember = "MaLoaiCa";
                this.tabChinhSua_cbxMaLoaiCa.ValueMember = "MaLoaiCa";

                /* Vận chuyển dữ liệu vào Datagridview */
                this.tabChinhSua_dgvCaLam.DataSource = dtCaLam;

                // Xóa trống các đối tượng trong groupbox
                this.tabChinhSua_txtMaCa.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy 
                this.tabChinhSua_btnLuu.Enabled = false;
                this.tabChinhSua_btnHuyBo.Enabled = false;
                this.grBoxThongTinCaLam.Enabled = false;
                // Cho thao tác trên các nút Thêm / Thoát 
                this.tabChinhSua_btnThem.Enabled = true;               
                this.tabChinhSua_btnTroVe.Enabled = true;
            }
            catch (SqlException q)
            {
                MessageBox.Show(q.Message);
                //MessageBox.Show("Không lấy được nội dung trong table CHITIETHOADON. Lỗi rồi!!!");
            }
        }

        private void frmQuanLyCaLam_Load(object sender, EventArgs e)
        {
            loadDataChinhSua();
            LoadDataTimKiem();
        }

        private void tabChinhSua_btnReload_Click(object sender, EventArgs e)
        {
            loadDataChinhSua();
        }

        private void tabChinhSua_btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Them = true;
            // Xóa trống các đối tượng trong groupbox
            this.tabChinhSua_txtMaCa.ResetText();
            this.tabChinhSua_txtMaCa.Enabled = false;
            // Cho thao tác trên các nút Lưu / Hủy 
            this.tabChinhSua_btnLuu.Enabled = true;
            this.tabChinhSua_btnHuyBo.Enabled = true;
            this.grBoxThongTinCaLam.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            this.tabChinhSua_btnThem.Enabled = false;
            this.tabChinhSua_btnTroVe.Enabled = false;
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
                    bool f = dbCaLam.ThemCaLam(ref err,
                    this.tabChinhSua_cbxMaLoaiCa.SelectedValue.ToString(),
                    this.tabChinhSua_dtpNgayLam.Value);
                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        loadDataChinhSua();
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
        }

        private void tabChinhSua_btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong groupbox
            this.tabChinhSua_txtMaCa.ResetText();
            // Không cho thao tác trên các nút Lưu / Hủy 
            this.tabChinhSua_btnLuu.Enabled = false;
            this.tabChinhSua_btnHuyBo.Enabled = false;
            this.grBoxThongTinCaLam.Enabled = false;
            // Cho thao tác trên các nút Thêm /Thoát 
            this.tabChinhSua_btnThem.Enabled = true;
            this.tabChinhSua_btnTroVe.Enabled = true;
        }

        private void LoadDataTimKiem()
        {
            dtCaLam = new DataTable();
            dtCaLam.Clear();
            dtCaLam = dbCaLam.LayThongTinViewCaLam().Tables[0];
            cbxMaLoaiCa.DataSource = dtLoaiCa;
            cbxMaLoaiCa.DisplayMember = "MaLoaiCa";
            cbxMaLoaiCa.ValueMember = "MaLoaiCa";
            cbxMaLoaiCa.Enabled = false;
            tabTimKiem_dtpNgayLam.Enabled = false;
            tabTimKiem_dgvCaLam.DataSource = dtCaLam;
        }

        private void tabTimKiem_btnLoc_Click(object sender, EventArgs e)
        {
            string MaLoaiCa = null;
            DateTime NgayLam = new DateTime(1, 1, 1);
            if (tabTimKiem_chkMaLoaiCa.Checked == true)
            {
                MaLoaiCa = cbxMaLoaiCa.Text.ToString();
            }
            if (tabTimKiem_chkNgayLam.Checked)
            {
                NgayLam = tabTimKiem_dtpNgayLam.Value.Date;
            }
            dtLocCaLam = new DataTable();
            dtLocCaLam.Clear();
            dtLocCaLam = dbCaLam.TimKiemThongTinCaLam(MaLoaiCa, NgayLam).Tables[0];
            tabTimKiem_dgvCaLam.DataSource = dtLocCaLam;
            tabTimKiem_txtTongSoBanGhi.Text =
                tabTimKiem_dgvCaLam.RowCount.ToString();
        }

        private void tabTimKiem_chkMaLoaiCa_CheckedChanged(object sender, EventArgs e)
        {
            if(tabTimKiem_chkMaLoaiCa.Checked)
            {
                cbxMaLoaiCa.Enabled = true;
            }
            else
            {
                cbxMaLoaiCa.Enabled = false;
            }
        }

        private void tabTimKiem_chkNgayLam_CheckedChanged(object sender, EventArgs e)
        {
            if(tabTimKiem_chkNgayLam.Checked)
            {
                tabTimKiem_dtpNgayLam.Enabled = true;
            }
            else
            {
                tabTimKiem_dtpNgayLam.Enabled = false;
            }
        }
    }
}
