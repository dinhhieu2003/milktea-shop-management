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
    public partial class frmXuatKho : Form
    {
        DBNguyenVatLieu dbNguyenVatLieu;
        DBKho dbKho;
        DataTable dtNguyenVatLieu = null;

        string maNVL, maKho;
        int soLuongXuat;
        public frmXuatKho()
        {
            InitializeComponent();
            dbNguyenVatLieu = new DBNguyenVatLieu();
            dbKho = new DBKho();
        }

        public string MaNVL { get => maNVL; set => maNVL = value; }
        public string MaKho { get => maKho; set => maKho = value; }
        public int SoLuongXuat { get => soLuongXuat; set => soLuongXuat = value; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MaNVL = comboBox1.SelectedValue.ToString();
            SoLuongXuat = (int)numericUpDown1.Value;
            MaKho = dbKho.LayMaKhoTuNgayThang(dateTimePicker1.Value.Date);
            this.Close();
        }

        private void frmXuatKho_Load(object sender, EventArgs e)
        {
            dtNguyenVatLieu = new DataTable();
            dtNguyenVatLieu.Clear();
            dtNguyenVatLieu = dbNguyenVatLieu.LayThongTinNguyenVatLieu().Tables[0];
            comboBox1.DataSource = dtNguyenVatLieu;
            comboBox1.DisplayMember = "TenNVL";
            comboBox1.ValueMember = "MaNVL";
        }
    }
}
