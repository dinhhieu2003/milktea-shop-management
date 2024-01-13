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
    public partial class frmQuanLyLuong : Form
    {
        DBChiTietLuongNgay dbChiTietLuongNgay;
        DBChucVu dbChucVu;
        DBNhanVien dbNhanVien;
        DBCaLam dbCaLam;
        //DataTable
        DataTable dtChiTietLuongNgay, dtChucVu, dtNhanVien, dtCaLam,
            dtLocChiTietLuong, dtTongLuong;

        bool Them;
        public frmQuanLyLuong()
        {
            InitializeComponent();
            dbChiTietLuongNgay = new DBChiTietLuongNgay();
            dbChucVu = new DBChucVu();
            dbNhanVien = new DBNhanVien();
            dbCaLam = new DBCaLam();
        }

        public void LoadDataTimKiemChiTietLuong()
        {
            this.tabTimKiem_cbxMaNV.Enabled = false;
            this.tabTimKiem_cbxTenChucVu.Enabled = false;
            this.tabTimKiem_cbxMaCa.Enabled = false;

            this.tabTimKiem_cbxMaNV.DataSource = dtNhanVien;
            this.tabTimKiem_cbxMaNV.DisplayMember = "MaNV";
            this.tabTimKiem_cbxMaNV.ValueMember = "MaNV";

            this.tabTimKiem_cbxMaCa.DataSource = dtCaLam;
            this.tabTimKiem_cbxMaCa.DisplayMember = "MaCa";
            this.tabTimKiem_cbxMaCa.DisplayMember = "MaCa";

            this.tabTimKiem_cbxTenChucVu.DataSource = dtChucVu;
            this.tabTimKiem_cbxTenChucVu.DisplayMember = "TenChucVu";
            this.tabTimKiem_cbxTenChucVu.ValueMember = "TenChucVu";

            this.tabTimKiem_dgvChiTietLuong.DataSource = dtChiTietLuongNgay;

            this.tabTimKiem_txtTongSoBanGhi.Text = tabTimKiem_dgvChiTietLuong.RowCount.ToString();
        }

        private void tabTimKiem_btnReload_Click(object sender, EventArgs e)
        {
            LoadDataTimKiemChiTietLuong();
        }

        private void tabTimKiem_chkMaCa_CheckedChanged(object sender, EventArgs e)
        {
            if (tabTimKiem_chkMaCa.Checked)
            {
                tabTimKiem_cbxMaCa.Enabled = true;
            }
            else
            {
                tabTimKiem_cbxMaCa.Enabled = false;
            }
        }

        private void tabTimKiem_chkChucVu_CheckedChanged(object sender, EventArgs e)
        {
            if (tabTimKiem_chkChucVu.Checked)
            {
                tabTimKiem_cbxTenChucVu.Enabled = true;
            }
            else
            {
                tabTimKiem_cbxTenChucVu.Enabled = false;
            }
        }

        private void tabTimKiem_chkMaNV_CheckedChanged(object sender, EventArgs e)
        {
            if (tabTimKiem_chkMaNV.Checked)
            {
                tabTimKiem_cbxMaNV.Enabled = true;
            }
            else
            {
                tabTimKiem_cbxMaNV.Enabled = false;
            }
        }

        private void tabTimKiem_btnLoc_Click(object sender, EventArgs e)
        {
            string MaNV = null, MaCa = null, TenChucVu = null;
            if (tabTimKiem_chkMaNV.Checked == true)
            {
                MaNV = tabTimKiem_cbxMaNV.Text.ToString();
            }
            if (tabTimKiem_chkMaCa.Checked == true)
            {
                MaCa = tabTimKiem_cbxMaCa.Text.ToString();
            }
            if (tabTimKiem_chkChucVu.Checked == true)
            {
                TenChucVu = tabTimKiem_cbxTenChucVu.Text.ToString();
            }
            dtLocChiTietLuong = new DataTable();
            dtLocChiTietLuong.Clear();
            dtLocChiTietLuong =
                dbChiTietLuongNgay.TimKiemChiTietLuong(MaNV, MaCa, TenChucVu).Tables[0];

            tabTimKiem_dgvChiTietLuong.DataSource = dtLocChiTietLuong;
            tabTimKiem_txtTongSoBanGhi.Text = tabTimKiem_dgvChiTietLuong.RowCount.ToString();
        }

        private void LoadDataTongHopLuong()
        {
            this.tabTongHop_cbxMaNV.ResetText();
            this.tabTongHop_cbxMaNV.Enabled = true;
            this.tabTongHop_cbxMaNV.DataSource = dtNhanVien;
            this.tabTongHop_cbxMaNV.DisplayMember = "MaNV";
            this.tabTongHop_cbxMaNV.ValueMember = "MaNV";
        }

        private void tabTongHop_btnTimKiem_Click(object sender, EventArgs e)
        {
            string MaNV = null;
            MaNV = this.tabTongHop_cbxMaNV.Text.ToString();
            dtTongLuong = new DataTable();
            dtTongLuong.Clear();
            dtTongLuong = dbChiTietLuongNgay.TimKiemTongLuong(MaNV).Tables[0];

            this.tabTongHop_dgvTongHopLuong.DataSource = dtTongLuong;
        }

        public void LoadDataChinhSua()
        {
            try
            {
                /*Vận chuyển dữ liệu vào DataTable */

                dtChiTietLuongNgay = new DataTable();
                dtChiTietLuongNgay.Clear();
                dtChiTietLuongNgay = dbChiTietLuongNgay.LayThongTinViewChiTietLuongNgay().Tables[0];

                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                dtNhanVien = dbNhanVien.LayThongTinViewNhanVien().Tables[0];

                dtCaLam = new DataTable();
                dtCaLam.Clear();
                dtCaLam = dbCaLam.LayThongTinViewCaLam().Tables[0];

                dtChucVu = new DataTable();
                dtChucVu.Clear();
                dtChucVu = dbChucVu.LayThongTinChucVu().Tables[0];

                /*Đưa vào combobox*/
                //Mã nhân viên
                tabChinhSua_cbxMaNV.DataSource = dtNhanVien;
                tabChinhSua_cbxMaNV.DisplayMember = "MaNV";
                tabChinhSua_cbxMaNV.ValueMember = "MaNV";
                //Mã ca
                tabChinhSua_cbxMaCa.DataSource = dtCaLam;
                tabChinhSua_cbxMaCa.DisplayMember = "MaCa";
                tabChinhSua_cbxMaCa.ValueMember = "MaCa";
                //Chức vụ
                tabChinhSua_cbxTenChucVu.DataSource = dtChucVu;
                tabChinhSua_cbxTenChucVu.DisplayMember = "TenChucVu";
                tabChinhSua_cbxTenChucVu.ValueMember = "MaChucVu";


                //Vận chuyển dữ liệu lên DataGridView
                tabChinhSua_dgvChiTietLuong.DataSource = dtChiTietLuongNgay;

                //Xóa trống các đối tượng trong group box
                this.tabChinhSua_txtThanhTien.ResetText();
                this.tabChinhSua_cbxMaNV.ResetText();
                this.tabChinhSua_cbxMaCa.ResetText();
                this.tabChinhSua_cbxTenChucVu.ResetText();
                //Không cho thao tác trên các nút Lưu/Hủy
                this.tabChinhSua_btnLuu.Enabled = false;
                this.tabChinhSua_btnHuyBo.Enabled = false;
                this.grBoxThongTinChiTietLuong.Enabled = false;
                //Cho thao tác trên các nút Sửa/Xóa/Thoát
                this.tabChinhSua_btnChinhSua.Enabled = true;
                this.tabChinhSua_btnXoa.Enabled = true;
                this.tabChinhSua_btnTroVe.Enabled = true;
            }
            catch (SqlException q)
            {
                MessageBox.Show(q.Message);
            }
        }

        private void tabChinhSua_dgvChiTietLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Thứ tự dòng hiện hành
            int r = tabChinhSua_dgvChiTietLuong.CurrentCell.RowIndex;
            //Chuyển thông tin lên khung thông tin
            this.tabChinhSua_cbxMaNV.Text =
                tabChinhSua_dgvChiTietLuong.Rows[r].Cells[0].Value.ToString();
            this.tabChinhSua_cbxMaCa.Text =
                tabChinhSua_dgvChiTietLuong.Rows[r].Cells[1].Value.ToString();
            this.tabChinhSua_cbxTenChucVu.Text =
                tabChinhSua_dgvChiTietLuong.Rows[r].Cells[2].Value.ToString();
            this.tabChinhSua_dtpNgayLuong.Value =
                Convert.ToDateTime(tabChinhSua_dgvChiTietLuong.Rows[r].Cells[4].Value.ToString());
            this.tabChinhSua_txtThanhTien.Text =
                tabChinhSua_dgvChiTietLuong.Rows[r].Cells[5].Value.ToString();
            this.tabChinhSua_dtpKyLuong.Value =
                Convert.ToDateTime(tabChinhSua_dgvChiTietLuong.Rows[r].Cells[6].Value.ToString());
        }

        private void tabChinhSua_btnChinhSua_Click(object sender, EventArgs e)
        {
            //Kích hoạt biến sửa
            Them = false;
            //Cho phép thao tác groupbox
            this.grBoxThongTinChiTietLuong.Enabled = true;
            //Lấy thứ tự dòng hiện hành
            int r = tabChinhSua_dgvChiTietLuong.CurrentCell.RowIndex;
            //Chuyển thông tin lên khung thông tin
            this.tabChinhSua_cbxMaNV.Text =
                tabChinhSua_dgvChiTietLuong.Rows[r].Cells[0].Value.ToString();
            this.tabChinhSua_cbxMaCa.Text =
                tabChinhSua_dgvChiTietLuong.Rows[r].Cells[1].Value.ToString();
            this.tabChinhSua_cbxTenChucVu.Text =
                tabChinhSua_dgvChiTietLuong.Rows[r].Cells[2].Value.ToString();
            this.tabChinhSua_dtpNgayLuong.Value =
                Convert.ToDateTime(tabChinhSua_dgvChiTietLuong.Rows[r].Cells[4].Value.ToString());
            this.tabChinhSua_txtThanhTien.Text =
                tabChinhSua_dgvChiTietLuong.Rows[r].Cells[5].Value.ToString();
            this.tabChinhSua_dtpKyLuong.Value =
                Convert.ToDateTime(tabChinhSua_dgvChiTietLuong.Rows[r].Cells[6].Value.ToString());
            //Cho thao tác trên các nút Lưu/hủy
            this.tabChinhSua_btnLuu.Enabled = true;
            this.tabChinhSua_btnHuyBo.Enabled = true;
            //Không cho thao tác trên Thêm/Sửa/Xóa/Thoát
            this.tabChinhSua_btnChinhSua.Enabled = false;
            this.tabChinhSua_btnXoa.Enabled = false;
            this.tabChinhSua_btnTroVe.Enabled = false;
        }

        private void tabChinhSua_btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabChinhSua_btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = tabChinhSua_dgvChiTietLuong.CurrentCell.RowIndex;
                //lấy MaNV, MaCa của record hiện hành
                string strMaNV =
                    tabChinhSua_dgvChiTietLuong.Rows[r].Cells[0].Value.ToString();
                string strMaCa =
                    tabChinhSua_dgvChiTietLuong.Rows[r].Cells[1].Value.ToString();
                //Khai báo biến trả lời
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc chắn xóa mẫu tin?", "Trả lời",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                string err = "";
                if (traloi == DialogResult.Yes)
                {
                    //Thực hiện câu lệnh sql
                    bool f = dbChiTietLuongNgay.XoaChiTietLuong(ref err, strMaNV, strMaCa);
                    if (f)
                    {
                        //Cập nhật lại dgv
                        LoadDataChinhSua();
                        MessageBox.Show("Đã xóa xong!");
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được!!\n\r" + "lỗi: " + err);
                    }
                }
                else
                {

                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được, lỗi rồi!!!");
            }
        }

        private void tabChinhSua_btnLuu_Click(object sender, EventArgs e)
        {
            //Chỉ sửa được dữ liệu
            string err = "";
            if (Them == false)
            {
                try
                {
                    bool f = dbChiTietLuongNgay.CapNhatChiTietLuong(ref err,
                        this.tabChinhSua_cbxMaNV.SelectedValue.ToString(),
                        this.tabChinhSua_cbxMaCa.SelectedValue.ToString(),
                        this.tabChinhSua_cbxTenChucVu.SelectedValue.ToString(),
                        this.tabChinhSua_dtpNgayLuong.Value.Date,
                        float.Parse(this.tabChinhSua_txtThanhTien.Text.ToString(),
                            CultureInfo.InvariantCulture.NumberFormat),
                        this.tabChinhSua_dtpKyLuong.Value.Date);

                    if (f)
                    {
                        LoadDataChinhSua();
                        MessageBox.Show("Đã cập nhật xong!!!");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật không thành công!!\n\r" + "Lỗi: " + err);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không cập nhật được!");
                }
            }
        }

        private void tabChinhSua_btnHuyBo_Click(object sender, EventArgs e)
        {
            this.tabChinhSua_txtThanhTien.ResetText();
            this.tabChinhSua_cbxMaNV.ResetText();
            this.tabChinhSua_cbxMaCa.ResetText();
            this.tabChinhSua_cbxTenChucVu.ResetText();

            this.tabChinhSua_btnLuu.Enabled = false;
            this.tabChinhSua_btnHuyBo.Enabled = false;
            this.grBoxThongTinChiTietLuong.Enabled = false;

            this.tabChinhSua_btnChinhSua.Enabled = true;
            this.tabChinhSua_btnXoa.Enabled = true;
            this.tabChinhSua_btnTroVe.Enabled = true;
        }

        private void tabChinhSua_btnReload_Click(object sender, EventArgs e)
        {
            LoadDataChinhSua();
        }

        private void frmQuanLyLuong_Load(object sender, EventArgs e)
        {
            LoadDataChinhSua();
            LoadDataTongHopLuong();
            LoadDataTimKiemChiTietLuong();
            
        }
    }
}
