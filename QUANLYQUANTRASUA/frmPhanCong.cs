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
    public partial class frmPhanCong : Form
    {
        DBCaLam dbCaLam;
        DBNhanVien dbNhanVien;
        DBPhanCong dbPhanCong;
        DBLoaiCa dbLoaiCa;

        // DataTable
        DataTable dtCaLam, dtNhanVien, dtLocCaLam, dtPhanCong, dtLoaiCa;
        // Biến tham số cho các Procedure
        string g_MaNV, g_MaLoaiCa;
        DateTime g_NgayLam;
        public frmPhanCong()
        {
            InitializeComponent();
            dbCaLam = new DBCaLam();
            dbNhanVien = new DBNhanVien();
            dbPhanCong = new DBPhanCong();
            dbLoaiCa= new DBLoaiCa();
        }

        private void LoadDataDangKy()
        {
            try
            {
                /* Vận chuyển dữ liệu vào DataTable */

                // dtNhanVien
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                dtNhanVien = dbNhanVien.LayThongTinNhanVienDangLam().Tables[0];

                dtCaLam = new DataTable();
                dtCaLam.Clear();
                dtCaLam = dbCaLam.LayThongTinViewCaLam().Tables[0];

                /*Đưa vào combobox*/
                //Mã nhân viên
                tabDangKy_cbxMaNV.DataSource = dtNhanVien;
                tabDangKy_cbxMaNV.DisplayMember = "MaNV";
                tabDangKy_cbxMaNV.ValueMember = "MaNV";

                // Mã ca
                tabDangKy_cbxMaCa.DataSource = dtCaLam;
                tabDangKy_cbxMaCa.DisplayMember = "MaCa";
                tabDangKy_cbxMaCa.ValueMember = "MaCa";


                /* Vận chuyển dữ liệu vào Datagridview */
                dgvCaLam.DataSource = dtCaLam;

                
            }
            catch (SqlException q)
            {
                MessageBox.Show(q.Message);

            }
        }

        private void dgvCaLam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvCaLam.CurrentCell.RowIndex;
            tabDangKy_cbxMaCa.SelectedValue =
                dgvCaLam.Rows[r].Cells[0].Value.ToString();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabDangKy_btnXem_Click(object sender, EventArgs e)
        {
            DateTime ngayLam = tabDangKy_dtpNgayLam.Value.Date;
            dtLocCaLam = new DataTable();
            dtLocCaLam.Clear();
            dtLocCaLam = dbCaLam.TimKiemThongTinCaLam(null, ngayLam).Tables[0];
            dgvCaLam.DataSource = dtLocCaLam;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string err = "";
            try
            {
                // Lệnh Insert InTo 
                bool f = dbPhanCong.ThemPhanCong(ref err,
                this.tabDangKy_cbxMaNV.Text.ToString(),
                this.tabDangKy_cbxMaCa.Text.ToString());
                if (f)
                {
                    // Thông báo 
                    MessageBox.Show("Đăng ký thành công!");
                }
                else
                {
                    if(err == "Trùng khóa chính")
                    {
                        MessageBox.Show("Đăng ký thất bại !!\n Nhân viên này đã được đăng ký vào mã ca này rồi");
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký thất bại!\n\r" + "Lỗi:" + err);
                    }
                    
                }
            }
            catch (SqlException q)
            {
                MessageBox.Show("Không thể đăng ký. Lỗi: " + q.Message);
            }
        }

        private void LoadDataDiemDanh()
        {
            tabDiemDanh_cbxMaNV.Enabled = false;
            tabDiemDanh_cbxTenLoaiCa.Enabled = false;
            tabDiemDanh_dtpNgayLam.Enabled = false;

            tabDiemDanh_cbxMaNV.DataSource = dtNhanVien;
            tabDiemDanh_cbxMaNV.DisplayMember = "MaNV";
            tabDiemDanh_cbxMaNV.ValueMember = "MaNV";

            dtLoaiCa = new DataTable();
            dtLoaiCa.Clear();
            dtLoaiCa = dbLoaiCa.LayThongTinLoaiCa().Tables[0];
            tabDiemDanh_cbxTenLoaiCa.DataSource = dtLoaiCa;
            tabDiemDanh_cbxTenLoaiCa.DisplayMember = "TenLoaiCa";
            tabDiemDanh_cbxTenLoaiCa.ValueMember = "MaLoaiCa";

            dtPhanCong = new DataTable();
            dtPhanCong.Clear();
            dtPhanCong = dbPhanCong.LayThongTinViewPhanCong().Tables[0];
            dgvPhanCong.DataSource = dtPhanCong;


        }

        private void tabDiemDanh_chkMaNV_CheckedChanged(object sender, EventArgs e)
        {
            if (tabDiemDanh_chkMaNV.Checked == true)
            {
                tabDiemDanh_cbxMaNV.Enabled = true;
            }
            else
            {
                tabDiemDanh_cbxMaNV.Enabled = false;
            }
        }

        private void dgvPhanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành
            int r = dgvPhanCong.CurrentCell.RowIndex;

            g_MaNV = dgvPhanCong.Rows[r].Cells[0].Value.ToString();
            g_NgayLam = Convert.ToDateTime(dgvPhanCong.Rows[r].Cells[3].Value.ToString());

            // Lấy giá trị của TenLoaiCa
            string tenLoaiCa = 
                dgvPhanCong.Rows[r].Cells[2].Value.ToString();

            // Tìm giá trị tương ứng trong ComboBox
            int index = tabDiemDanh_cbxTenLoaiCa.FindStringExact(tenLoaiCa);
            if (index != -1)
            {
                tabDiemDanh_cbxTenLoaiCa.SelectedIndex = index;
                g_MaLoaiCa = tabDiemDanh_cbxTenLoaiCa.SelectedValue.ToString();
            }
        }

        private void tabDiemDanh_chkTenLoaiCa_CheckedChanged(object sender, EventArgs e)
        {
            if (tabDiemDanh_chkTenLoaiCa.Checked == true)
            {
                tabDiemDanh_cbxTenLoaiCa.Enabled = true;
            }
            else
            {
                tabDiemDanh_cbxTenLoaiCa.Enabled = false;
            }
        }

        private void tabDiemDanh_btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void tabDiemDanh_chkNgayLam_CheckedChanged(object sender, EventArgs e)
        {
            if (tabDiemDanh_chkNgayLam.Checked == true)
            {
                tabDiemDanh_dtpNgayLam.Enabled = true;
            }
            else
            {
                tabDiemDanh_dtpNgayLam.Enabled = false;
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string MaNV = null, TenLoaiCa = null;
            DateTime NgayLam = new DateTime(1, 1, 1);
            if (tabDiemDanh_chkMaNV.Checked == true)
            {
                MaNV = tabDiemDanh_cbxMaNV.Text.ToString();
            }
            if (tabDiemDanh_chkTenLoaiCa.Checked == true)
            {
                TenLoaiCa = tabDiemDanh_cbxTenLoaiCa.Text.ToString();
            }
            if (tabDiemDanh_chkNgayLam.Checked == true)
            {
                NgayLam = tabDiemDanh_dtpNgayLam.Value.Date;
            }
            dtPhanCong = dbPhanCong.TimKiemThongTinPhanCong(MaNV, TenLoaiCa, NgayLam).Tables[0];
            dgvPhanCong.DataSource = dtPhanCong;
        }

        private void tabDiemDanh_btnDiemDanh_Click(object sender, EventArgs e)
        {
            try
            {
                string err = "";
                bool f = dbPhanCong.DiemDanhPhanCong(ref err,
                g_MaNV, g_MaLoaiCa, g_NgayLam, 1);
                if (f)
                {
                    // Load lại dữ liệu trên DataGridView 
                    LoadDataDiemDanh();
                    // Thông báo 
                    MessageBox.Show("Điểm danh thành công!!");
                }
                else
                {
                    MessageBox.Show("Không hoàn tất được thao tác\n\r" + "Lỗi:" + err);
                }
            }
            catch (SqlException q)
            {
                MessageBox.Show("Có lỗi: " + q.Message);
            }
        }

        private void tabDiemDanh_btnHuyDiemDanh_Click(object sender, EventArgs e)
        {
            try
            {
                string err = "";
                bool f = dbPhanCong.DiemDanhPhanCong(ref err,
                g_MaNV, g_MaLoaiCa, g_NgayLam, 0);
                if (f)
                {
                    // Load lại dữ liệu trên DataGridView 
                    LoadDataDiemDanh();
                    // Thông báo 
                    MessageBox.Show("Hủy điểm danh thành công!!");
                }
                else
                {
                    MessageBox.Show("Không hoàn tất được thao tác\n\r" + "Lỗi:" + err);
                }
            }
            catch (SqlException q)
            {
                MessageBox.Show("Có lỗi: " + q.Message);
            }
        }

        private void frmPhanCong_Load(object sender, EventArgs e)
        {
            LoadDataDangKy();
            LoadDataDiemDanh();
        }
    }
}
