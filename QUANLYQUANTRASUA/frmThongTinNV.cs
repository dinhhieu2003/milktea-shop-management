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
    public partial class frmThongTinNV : Form
    {
        DBNhanVien dbNhanVien;
        DBChucVu dbChucVu;
        // Tạo các bảng của các db này
        DataTable dtNhanVien = null;
        DataTable dtChucVu = null;
        DataTable dtLocNhanVien = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;
        public frmThongTinNV()
        {
            InitializeComponent();
            dbNhanVien = new DBNhanVien();
            dbChucVu = new DBChucVu();
        }

        private void LoadDataChinhSua()
        {
            try
            {
                /* Vận chuyển dữ liệu vào DataTable */

                // dtNhanVien
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                dtNhanVien = dbNhanVien.LayThongTinViewNhanVien().Tables[0];

                dtChucVu = new DataTable();
                dtChucVu.Clear();
                dtChucVu = dbChucVu.LayThongTinChucVu().Tables[0];

                /*Đưa vào combobox*/
                //Tên chức vụ
                tabChinhSua_cbxTenChucVu.DataSource = dtChucVu;
                tabChinhSua_cbxTenChucVu.DisplayMember = "TenChucVu";
                tabChinhSua_cbxTenChucVu.ValueMember = "MaChucVu";


                /* Vận chuyển dữ liệu vào Datagridview */
                tabChinhSua_dgvNhanVien.DataSource = dtNhanVien;

                // Xóa trống các đối tượng trong groupbox
                this.tabChinhSua_txtMaNV.ResetText();
                this.tabChinhSua_txtHoTen.ResetText();
                this.tabChinhSua_txtSDT.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy 
                this.tabChinhSua_btnLuu.Enabled = false;
                this.tabChinhSua_btnHuyBo.Enabled = false;
                this.grBoxThongTinNV.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
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

        private void frmThongTinNV_Load(object sender, EventArgs e)
        {
            LoadDataChinhSua();
            LoadDataTimKiem();
        }

        private void tabChinhSua_btnReload_Click(object sender, EventArgs e)
        {
            LoadDataChinhSua();
        }

        private void tabChinhSua_btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Them = true;
            // Xóa trống các đối tượng trong groupbox
            this.tabChinhSua_txtMaNV.ResetText();
            this.tabChinhSua_txtMaNV.Enabled = false;
            
            this.tabChinhSua_txtHoTen.ResetText();
            this.tabChinhSua_txtSDT.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy 
            this.tabChinhSua_btnLuu.Enabled = true;
            this.tabChinhSua_btnHuyBo.Enabled = true;
            this.grBoxThongTinNV.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            this.tabChinhSua_btnThem.Enabled = false;
            this.tabChinhSua_btnChinhSua.Enabled = false;
            this.tabChinhSua_btnXoa.Enabled = false;
            this.tabChinhSua_btnTroVe.Enabled = false;
        }

        private void tabChinhSua_btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong groupbox
            this.tabChinhSua_txtMaNV.ResetText();
            this.tabChinhSua_txtHoTen.ResetText();
            this.tabChinhSua_txtSDT.ResetText();
            // Không cho thao tác trên các nút Lưu / Hủy 
            this.tabChinhSua_btnLuu.Enabled = false;
            this.tabChinhSua_btnHuyBo.Enabled = false;
            this.grBoxThongTinNV.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            this.tabChinhSua_btnThem.Enabled = true;
            this.tabChinhSua_btnChinhSua.Enabled = true;
            this.tabChinhSua_btnXoa.Enabled = true;
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
                    bool f = dbNhanVien.ThemNhanVien(ref err,
                    this.tabChinhSua_cbxTenChucVu.SelectedValue.ToString(),
                    this.tabChinhSua_txtHoTen.Text.ToString(),
                    this.tabChinhSua_dtpNgaySinh.Value.Date,
                    this.tabChinhSua_cbxGioiTinh.Text.ToString(),
                    this.tabChinhSua_dtpNgayVaoLam.Value.Date,
                    this.tabChinhSua_txtSDT.Text.ToString(),
                    this.tabChinhSua_cbxTinhTrang.Text.ToString());
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
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            else // Sua du lieu
            {
                try
                {

                    bool f = dbNhanVien.CapNhatNhanVien(ref err,
                    this.tabChinhSua_txtMaNV.Text.ToString(),
                    this.tabChinhSua_cbxTenChucVu.SelectedValue.ToString(),
                    this.tabChinhSua_txtHoTen.Text.ToString(),
                    this.tabChinhSua_dtpNgaySinh.Value.Date,
                    this.tabChinhSua_cbxGioiTinh.Text.ToString(),
                    this.tabChinhSua_dtpNgayVaoLam.Value.Date,
                    this.tabChinhSua_txtSDT.Text.ToString(),
                    this.tabChinhSua_cbxTinhTrang.Text.ToString());
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
                catch (SqlException)
                {
                    MessageBox.Show("Không cập nhật được. Lỗi rồi!");
                }
            }
        }

        private void tabChinhSua_btnChinhSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            // Cho phép thao tác trên groupbox 
            this.grBoxThongTinNV.Enabled = true;
            // Thứ tự dòng hiện hành 
            int r = tabChinhSua_dgvNhanVien.CurrentCell.RowIndex;
            // Chuyển thông tin lên Khung thông tin 
            this.tabChinhSua_txtMaNV.Text =
                tabChinhSua_dgvNhanVien.Rows[r].Cells[0].Value.ToString();
            this.tabChinhSua_cbxTenChucVu.Text =
                tabChinhSua_dgvNhanVien.Rows[r].Cells[1].Value.ToString();
            this.tabChinhSua_txtHoTen.Text =
                tabChinhSua_dgvNhanVien.Rows[r].Cells[2].Value.ToString();
            this.tabChinhSua_dtpNgaySinh.Value =
                Convert.ToDateTime(tabChinhSua_dgvNhanVien.Rows[r].Cells[3].Value.ToString());

            this.tabChinhSua_cbxGioiTinh.Text =
                this.tabChinhSua_dgvNhanVien.Rows[r].Cells[4].Value.ToString();

            this.tabChinhSua_dtpNgayVaoLam.Value =
                Convert.ToDateTime(tabChinhSua_dgvNhanVien.Rows[r].Cells[5].Value.ToString());
            this.tabChinhSua_txtSDT.Text =
                 this.tabChinhSua_dgvNhanVien.Rows[r].Cells[6].Value.ToString();
            this.tabChinhSua_cbxTinhTrang.SelectedItem =
                this.tabChinhSua_dgvNhanVien.Rows[r].Cells[7].Value.ToString();
            // Cho thao tác trên các nút Lưu / Hủy / group 
            this.tabChinhSua_btnLuu.Enabled = true;
            this.tabChinhSua_btnHuyBo.Enabled = true;
            this.grBoxThongTinNV.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.tabChinhSua_btnThem.Enabled = false;
            this.tabChinhSua_btnChinhSua.Enabled = false;
            this.tabChinhSua_btnXoa.Enabled = false;
            this.tabChinhSua_btnTroVe.Enabled = false;
        }

        private void tabChinhSua_dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = tabChinhSua_dgvNhanVien.CurrentCell.RowIndex;
            // Chuyển thông tin lên Khung thông tin 
            this.tabChinhSua_txtMaNV.Text =
                tabChinhSua_dgvNhanVien.Rows[r].Cells[0].Value.ToString();
            this.tabChinhSua_cbxTenChucVu.Text =
                tabChinhSua_dgvNhanVien.Rows[r].Cells[1].Value.ToString();
            this.tabChinhSua_txtHoTen.Text =
                tabChinhSua_dgvNhanVien.Rows[r].Cells[2].Value.ToString();
            this.tabChinhSua_dtpNgaySinh.Value =
                Convert.ToDateTime(tabChinhSua_dgvNhanVien.Rows[r].Cells[3].Value.ToString());

            this.tabChinhSua_cbxGioiTinh.Text =
                this.tabChinhSua_dgvNhanVien.Rows[r].Cells[4].Value.ToString();

            this.tabChinhSua_dtpNgayVaoLam.Value =
                Convert.ToDateTime(tabChinhSua_dgvNhanVien.Rows[r].Cells[5].Value.ToString());
            this.tabChinhSua_txtSDT.Text =
                 this.tabChinhSua_dgvNhanVien.Rows[r].Cells[6].Value.ToString();
            this.tabChinhSua_cbxTinhTrang.SelectedItem =
                this.tabChinhSua_dgvNhanVien.Rows[r].Cells[7].Value.ToString();
        }

        private void tabChinhSua_btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành 
                int r = tabChinhSua_dgvNhanVien.CurrentCell.RowIndex;
                // Lấy MaNV của record hiện hành 
                string strMaNV =
                tabChinhSua_dgvNhanVien.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL 
                // Hiện thông báo xác nhận việc xóa mẫu tin 
                // Khai báo biến traloi 
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp 
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không? 
                string err = "";
                if (traloi == DialogResult.Yes)
                {

                    // Thực hiện câu lệnh SQL 
                    bool f = dbNhanVien.XoaNhanVien(ref err, strMaNV);
                    if (f)
                    {
                        // Cập nhật lại DataGridView 
                        LoadDataChinhSua();
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

        private void tabChinhSua_btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadDataTimKiem()
        {
            tabTimKiem_txtHoTen.Enabled = false;
            tabTimKiem_txtMaNV.Enabled = false;
            tabTimKiem_cbxChucVu.Enabled = false;

            tabTimKiem_cbxChucVu.DataSource = dtChucVu;
            tabTimKiem_cbxChucVu.DisplayMember = "TenChucVu";
            tabTimKiem_cbxChucVu.ValueMember = "TenChucVu";

            tabTimKiem_dgvNhanVien.DataSource = dtNhanVien;

            tabTimKiem_txtTongSoBanGhi.Text = tabTimKiem_dgvNhanVien.RowCount.ToString();
        }

        private void tabTimKiem_chkMaNV_CheckedChanged(object sender, EventArgs e)
        {
            if(tabTimKiem_chkMaNV.Checked == true)
            {
                tabTimKiem_txtMaNV.Enabled = true;
            }
            else
            {
                tabTimKiem_txtMaNV.Enabled = false;
            }
        }

        private void tabTimKiem_chkHoTen_CheckedChanged(object sender, EventArgs e)
        {
            if (tabTimKiem_chkHoTen.Checked == true)
            {
                tabTimKiem_txtHoTen.Enabled = true;
            }
            else
            {
                tabTimKiem_txtHoTen.Enabled = false;
            }
        }

        private void tabTimKiem_chkChucVu_CheckedChanged(object sender, EventArgs e)
        {
            if (tabTimKiem_chkChucVu.Checked == true)
            {
                tabTimKiem_cbxChucVu.Enabled = true;
            }
            else
            {
                tabTimKiem_cbxChucVu.Enabled = false;
            }
        }

        private void tabTimKiem_btnLoc_Click(object sender, EventArgs e)
        {
            string MaNV = null, HoTen = null, TenChucVu = null ;
            if (tabTimKiem_chkMaNV.Checked == true)
            {
                MaNV = tabTimKiem_txtMaNV.Text.ToString();
            }
            if(tabTimKiem_chkChucVu.Checked == true)
            {
                TenChucVu = tabTimKiem_cbxChucVu.Text.ToString();
            }    
            if(tabTimKiem_chkHoTen.Checked == true) 
            {
                HoTen = tabTimKiem_txtHoTen.Text.ToString();
            }
            dtLocNhanVien = new DataTable();
            dtLocNhanVien.Clear();
            dtLocNhanVien = 
                dbNhanVien.TimKiemThongTinNhanVien(MaNV, HoTen, TenChucVu).Tables[0];
           
            tabTimKiem_dgvNhanVien.DataSource = dtLocNhanVien;
            tabTimKiem_txtTongSoBanGhi.Text = tabTimKiem_dgvNhanVien.RowCount.ToString();
        }

        private void tabTimKiem_btnReload_Click(object sender, EventArgs e)
        {
            tabTimKiem_dgvNhanVien.DataSource = dtNhanVien;
            tabTimKiem_txtTongSoBanGhi.Text = tabTimKiem_dgvNhanVien.RowCount.ToString();
        }
    }
}
