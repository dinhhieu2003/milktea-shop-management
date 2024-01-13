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
    public partial class frmQuanLy : Form
    {
        public frmQuanLy()
        {
            InitializeComponent();
        }
        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            panelQLCaLamSubmenu.Visible= false;
            panelQLDoanhThuSubMenu.Visible= false;
            panelQLKhachHangSubMenu.Visible= false;
            panelQLNVSubMenu.Visible= false;
           
        }

        private void hideSubMenu()
        {
            if(panelQLCaLamSubmenu.Visible == true)
            {
                panelQLCaLamSubmenu.Visible = false;
            }
            if(panelQLDoanhThuSubMenu.Visible == true)
                panelQLDoanhThuSubMenu.Visible = false;
            if(panelQLKhachHangSubMenu.Visible == true)
                panelQLKhachHangSubMenu.Visible = false;
            if(panelQLNVSubMenu.Visible == true)
                panelQLNVSubMenu.Visible = false;
        
        }

        private void showSubMenu(Panel subMenu)
        {
            if(subMenu.Visible== false) 
            {
                hideSubMenu();
                subMenu.Visible= true;
            }
            else
            {
                subMenu.Visible= false;
            }
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            showSubMenu(panelQLNVSubMenu);
        }

        private void btnInfoNV_Click(object sender, EventArgs e)
        {
            this.lblTiTle.Text = "THÔNG TIN NHÂN VIÊN";
            openChildForm(new frmThongTinNV());
            hideSubMenu();
        }

        private void btnQLLuong_Click(object sender, EventArgs e)
        {
            this.lblTiTle.Text = "QUẢN LÝ LƯƠNG";
            openChildForm(new frmQuanLyLuong());
            hideSubMenu();
        }

        private void btnQLChucVu_Click(object sender, EventArgs e)
        {
            this.lblTiTle.Text = "QUẢN LÝ CHỨC VỤ";
            openChildForm(new frmQuanLyChucVu());
            hideSubMenu();
        }

        private void btnQLDoanhThu_Click(object sender, EventArgs e)
        {
            showSubMenu(panelQLDoanhThuSubMenu);
        }

        private void btnBieuDoDoanhThu_Click(object sender, EventArgs e)
        {
            this.lblTiTle.Text = "TÍNH TOÁN DOANH THU";
            openChildForm(new frmTinhToanDoanhThu());
            hideSubMenu();
        }

        private void btnThongTinHoaDon_Click(object sender, EventArgs e)
        {
            this.lblTiTle.Text = "THÔNG TIN HÓA ĐƠN";
            openChildForm(new frmQuanLyHoaDon());
            hideSubMenu();
        }

        private void btnQLPhieuMua_Click(object sender, EventArgs e)
        {
            this.lblTiTle.Text = "QUẢN LÝ PHIẾU MUA";
            openChildForm(new frmQuanLyPhieuMua());
            hideSubMenu();
        }

        private void btnSPBanChay_Click(object sender, EventArgs e)
        {
            this.lblTiTle.Text = "DANH MỤC SẢN PHẨM BÁN CHẠY";
            openChildForm(new frmDanhMucSanPhamBanChay());
            hideSubMenu();
        }

        private void btnQLKhachHang_Click(object sender, EventArgs e)
        {
            showSubMenu(panelQLKhachHangSubMenu);
        }

        private void btnInfoKhachHang_Click(object sender, EventArgs e)
        {
            this.lblTiTle.Text = "THÔNG TIN CÁ NHÂN KHÁCH HÀNG";
            openChildForm(new frmQuanLyThongTinKhachHang());
            hideSubMenu();
        }


        private void btnQuanLyCaLam_Click(object sender, EventArgs e)
        {
            showSubMenu(panelQLCaLamSubmenu);
        }

        private void btnQuanLyCaLamSubBtn_Click(object sender, EventArgs e)
        {
            this.lblTiTle.Text = "QUẢN LÝ CA LÀM";
            openChildForm(new frmQuanLyCaLam());
            hideSubMenu();
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            this.lblTiTle.Text = "PHÂN CÔNG";
            openChildForm(new frmPhanCong());
            hideSubMenu();
        }

        private void btnQLKho_Click(object sender, EventArgs e)
        {
            this.lblTiTle.Text = "QUẢN LÝ KHO";
            openChildForm(new frmQuanLyKho());
            hideSubMenu();
        }

        private void btnQLThucDon_Click(object sender, EventArgs e)
        {
            this.lblTiTle.Text = "QUẢN LÝ THỰC ĐƠN";
            openChildForm(new frmQuanLyThucDon());
            hideSubMenu();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {
            this.lblTiTle.Text = "TRANG CHÍNH";
            openChildForm(new frmHome());
        }

        private void btnQLDangNhap_Click(object sender, EventArgs e)
        {
            this.lblTiTle.Text = "QUẢN LÝ ĐĂNG NHẬP";
            openChildForm(new frmQLDangNhap());
            hideSubMenu();
        }
    }
}
