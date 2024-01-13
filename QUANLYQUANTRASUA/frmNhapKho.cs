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
    public partial class frmNhapKho : Form
    {
        private string maNVL;
        private int soLuong;
        private string hsd;

        public string MaNVL { get => maNVL; set => maNVL = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string HSD { get => hsd; set => hsd = value; }

        DBNguyenVatLieu dbNguyenVatLieu;
        DataTable dtNguyenVatLieu;
        public frmNhapKho()
        {
            InitializeComponent();
            dbNguyenVatLieu = new DBNguyenVatLieu();
        }

        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            dtNguyenVatLieu = new DataTable();
            dtNguyenVatLieu.Clear();
            dtNguyenVatLieu = dbNguyenVatLieu.LayThongTinNguyenVatLieu().Tables[0];
            comboBox1.DataSource = dtNguyenVatLieu;
            comboBox1.DisplayMember = "TenNVL";
            comboBox1.ValueMember = "MaNVL";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MaNVL = comboBox1.SelectedValue.ToString();
            SoLuong = (int)numericUpDown1.Value;
            HSD = dtpHSD.Value.ToString("yyyy-MM-dd");
            this.Close();
        }
    }
}
