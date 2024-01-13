using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYQUANTRASUA
{
    public partial class frmThongTinNguoiDangNhap : Form
    {
        string userName = DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName;
        DBDangNhap dbDangNhap;

        DataTable dtDangNhap = null;
        public frmThongTinNguoiDangNhap()
        {
            InitializeComponent();
            dbDangNhap = new DBDangNhap();
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            frmQuanLy frm = new frmQuanLy();
            frm.ShowDialog();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            frmBanHang frm = new frmBanHang();
            frm.ShowDialog();
        }

        private void frmThongTinNguoiDangNhap_Load(object sender, EventArgs e)
        {
            if(userName != "adminTS")
            {
                dtDangNhap = new DataTable();
                dtDangNhap.Clear();
                dtDangNhap =
                    dbDangNhap.LayThongTinNhanVienDangNhap(userName).Tables[0];
                txtMaNV.Text = dtDangNhap.Rows[0][0].ToString();
                txtTenChucVu.Text = dtDangNhap.Rows[0][1].ToString();
                txtHoTen.Text = dtDangNhap.Rows[0][2].ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(dtDangNhap.Rows[0][3].ToString());
                txtGioiTinh.Text = dtDangNhap.Rows[0][4].ToString();
                dtpNgayVaoLam.Value = Convert.ToDateTime(dtDangNhap.Rows[0][5].ToString());
                txtSDT.Text = dtDangNhap.Rows[0][6].ToString();
                txtTinhTrang.Text = dtDangNhap.Rows[0][7].ToString();
                lblTenNguoiDung.Text = txtHoTen.Text;
                lblTenNguoiDung.ForeColor = Color.Red;
            }
            else
            {
                lblTenNguoiDung.Text = "ADMIN";
                lblTenNguoiDung.ForeColor = Color.Red;
                groupBox1.Enabled = false;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
