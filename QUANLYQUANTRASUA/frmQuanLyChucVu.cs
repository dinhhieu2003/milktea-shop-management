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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QUANLYQUANTRASUA
{
    public partial class frmQuanLyChucVu : Form
    {
        DBChucVu dbChucVu;
        // Tạo các bảng của các db này
        DataTable dtChucVu = null;
        DataTable dtTimChucVu = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu 
        bool Them;
        public frmQuanLyChucVu()
        {
            InitializeComponent();
            dbChucVu = new DBChucVu();
        }

        private void LoadDataChinhSua()
        {
            try
            {
                /* Vận chuyển dữ liệu vào DataTable */

                // dtChucVu
                dtChucVu = new DataTable();
                dtChucVu.Clear();
                dtChucVu = dbChucVu.LayThongTinViewChucVu().Tables[0];

                /* Vận chuyển dữ liệu vào Datagridview */
                tabChinhSua_dgvChucVu.DataSource = dtChucVu;

                // Xóa trống các đối tượng trong groupbox
                this.tabChinhSua_txtMaChucVu.ResetText();
                this.tabChinhSua_txtTenChucVu.ResetText();
                this.tabChinhSua_txtLuongMotGio.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy 
                this.tabChinhSua_btnLuu.Enabled = false;
                this.tabChinhSua_btnHuyBo.Enabled = false;
                this.grBoxThongTinChucVu.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Thoát 
                this.tabChinhSua_btnThem.Enabled = true;
                this.tabChinhSua_btnChinhSua.Enabled = true;
                this.tabChinhSua_btnTroVe.Enabled = true;
            }
            catch (SqlException q)
            {
                MessageBox.Show(q.Message);

            }
        }

        private void LoadDataTimKiem()
        {
            try
            {
                // Xóa trống các đối tượng trong groupbox
                this.tabTimKiem_txtTenChucVu.ResetText();
                // Load dữ liệu vào dgv
                tabTimKiem_dgvChucVu.DataSource = dtChucVu;
                tabTimKiem_txtTongSoBanGhi.Text = 
                    tabTimKiem_dgvChucVu.RowCount.ToString();
            }
            catch (SqlException q)
            {
                MessageBox.Show(q.Message);

            }
        }

        private void frmQuanLyChucVu_Load(object sender, EventArgs e)
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
            this.tabChinhSua_txtMaChucVu.ResetText();
            this.tabChinhSua_txtTenChucVu.ResetText();
            this.tabChinhSua_txtLuongMotGio.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy 
            this.tabChinhSua_btnLuu.Enabled = true;
            this.tabChinhSua_btnHuyBo.Enabled = true;
            this.grBoxThongTinChucVu.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Sửa / Thoát 
            this.tabChinhSua_btnThem.Enabled = false;
            this.tabChinhSua_btnChinhSua.Enabled = false;
            this.tabChinhSua_btnTroVe.Enabled = false;
        }

        private void tabChinhSua_btnLuu_Click(object sender, EventArgs e)
        {
            string err = "";
            if(Them)
            {
                try
                {
                    // Lệnh Insert InTo 
                    bool f = dbChucVu.ThemChucVu(ref err,
                    this.tabChinhSua_txtMaChucVu.Text.ToString(),
                    this.tabChinhSua_txtTenChucVu.Text.ToString(),
                    float.Parse(this.tabChinhSua_txtLuongMotGio.Text.ToString(),
                        CultureInfo.InvariantCulture.NumberFormat));
                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadDataChinhSua();
                        LoadDataTimKiem();
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
                    bool f = dbChucVu.CapNhatChucVu(ref err,
                    this.tabChinhSua_txtMaChucVu.Text.ToString(),
                    this.tabChinhSua_txtTenChucVu.Text.ToString(),
                    float.Parse(this.tabChinhSua_txtLuongMotGio.Text.ToString(),
                            CultureInfo.InvariantCulture.NumberFormat));
                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadDataChinhSua();
                        LoadDataTimKiem();
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

        private void tabTongHop_btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tabTimKiem_txtTenChucVu.Text))
            {
                MessageBox.Show("Hãy nhập vào ô Tên chức vụ trước khi bấm tìm kiếm");
            }    
            dtTimChucVu = new DataTable();
            dtTimChucVu.Clear();
            dtTimChucVu = dbChucVu.TimKiemThongTinChucVu(tabTimKiem_txtTenChucVu.Text.ToString()).Tables[0];
            tabTimKiem_dgvChucVu.DataSource = dtTimChucVu;
            tabTimKiem_txtTongSoBanGhi.Text = 
                tabTimKiem_dgvChucVu.RowCount.ToString();
        }

        private void tabTimKiem_Reload_Click(object sender, EventArgs e)
        {
            LoadDataTimKiem();
        }

        private void tabChinhSua_btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong groupbox
            this.tabChinhSua_txtMaChucVu.ResetText();
            this.tabChinhSua_txtTenChucVu.ResetText();
            this.tabChinhSua_txtLuongMotGio.ResetText();
            // Không cho thao tác trên các nút Lưu / Hủy 
            this.tabChinhSua_btnLuu.Enabled = false;
            this.tabChinhSua_btnHuyBo.Enabled = false;
            this.grBoxThongTinChucVu.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Thoát 
            this.tabChinhSua_btnThem.Enabled = true;
            this.tabChinhSua_btnChinhSua.Enabled = true;
            this.tabChinhSua_btnTroVe.Enabled = true;
        }

        private void tabChinhSua_btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabChinhSua_btnChinhSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            // Cho phép thao tác trên groupbox 
            this.grBoxThongTinChucVu.Enabled = true;
            // Thứ tự dòng hiện hành 
            int r = tabChinhSua_dgvChucVu.CurrentCell.RowIndex;
            // Chuyển thông tin lên Khung thông tin 
            this.tabChinhSua_txtMaChucVu.Text =
                tabChinhSua_dgvChucVu.Rows[r].Cells[0].Value.ToString();
            this.tabChinhSua_txtTenChucVu.Text =
                tabChinhSua_dgvChucVu.Rows[r].Cells[1].Value.ToString();
            this.tabChinhSua_txtLuongMotGio.Text =
                tabChinhSua_dgvChucVu.Rows[r].Cells[2].Value.ToString();
            // Cho thao tác trên các nút Lưu / Hủy / group 
            this.tabChinhSua_btnLuu.Enabled = true;
            this.tabChinhSua_btnHuyBo.Enabled = true;
            this.grBoxThongTinChucVu.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Thoát 
            this.tabChinhSua_btnThem.Enabled = false;
            this.tabChinhSua_btnChinhSua.Enabled = false;
            this.tabChinhSua_btnTroVe.Enabled = false;
        }

        private void tabChinhSua_dgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = tabChinhSua_dgvChucVu.CurrentCell.RowIndex;
            // Chuyển thông tin lên Khung thông tin 
            this.tabChinhSua_txtMaChucVu.Text =
                tabChinhSua_dgvChucVu.Rows[r].Cells[0].Value.ToString();
            this.tabChinhSua_txtTenChucVu.Text =
                tabChinhSua_dgvChucVu.Rows[r].Cells[1].Value.ToString();
            this.tabChinhSua_txtLuongMotGio.Text =
                tabChinhSua_dgvChucVu.Rows[r].Cells[2].Value.ToString();
        }
    }
}
