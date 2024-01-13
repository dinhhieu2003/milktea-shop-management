using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public partial class frmChonMaKH : Form
    {
        DBKhachHang dBKhachHang;
        DataTable dtKhachHang = null;
        private string maKH;

        public string MaKH { get => maKH; set => maKH = value; }

        public frmChonMaKH()
        {
            dBKhachHang = new DBKhachHang();
            InitializeComponent();
        }

        private void frmChonMaKH_Load(object sender, EventArgs e)
        {
            dtKhachHang = new DataTable();
            dtKhachHang.Clear();
            dtKhachHang = dBKhachHang.LayThongTinKhachHang().Tables[0];
            cbxMaKH.DataSource = dtKhachHang;
            cbxMaKH.DisplayMember = "MaKH";
            cbxMaKH.ValueMember = "MaKH";
        }

        private void cbxMaKH_SelectedValueChanged(object sender, EventArgs e)
        {
            MaKH = cbxMaKH.Text.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            MaKH = null;
        }
    }
}
