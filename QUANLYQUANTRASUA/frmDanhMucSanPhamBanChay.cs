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
    public partial class frmDanhMucSanPhamBanChay : Form
    {
        DBChiTietHoaDon dbChiTietHoaDon;
        DataTable dtDanhMucSanPhamBanChay;
        DataTable dtLocSanPhamBanChay;
        public frmDanhMucSanPhamBanChay()
        {
            InitializeComponent();
            dbChiTietHoaDon = new DBChiTietHoaDon();
        }

        private void frmDanhMucSanPhamBanChay_Load(object sender, EventArgs e)
        {
            dtDanhMucSanPhamBanChay = new DataTable();
            dtDanhMucSanPhamBanChay.Clear();
            dtDanhMucSanPhamBanChay = dbChiTietHoaDon.LayViewDanhMucSanPhamBanChay().Tables[0];

            dgvDanhSachSPBanChay.DataSource = dtDanhMucSanPhamBanChay;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {

            string Thang = null, Nam = null;
            Thang = cbxThang.Text.ToString();
            Nam = cbxNam.Text.ToString();


            dtLocSanPhamBanChay = new DataTable();
            dtLocSanPhamBanChay.Clear();
            dtLocSanPhamBanChay =
                dbChiTietHoaDon.TimKiemSanPhamBanChay(Thang, Nam).Tables[0];

            dgvDanhSachSPBanChay.DataSource = dtLocSanPhamBanChay;
        }
    }
}
