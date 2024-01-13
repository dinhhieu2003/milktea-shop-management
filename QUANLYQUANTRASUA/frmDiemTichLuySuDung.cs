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
    public partial class frmDiemTichLuySuDung : Form
    {
        private float diemSuDung = 0;
        public frmDiemTichLuySuDung()
        {
            InitializeComponent();
        }

        public float DiemSuDung { get => diemSuDung; set => diemSuDung = value; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDiemTichLuySuDung_Load(object sender, EventArgs e)
        {

        }

        private void txtDiemSuDung_TextChanged(object sender, EventArgs e)
        {
            diemSuDung = float.Parse(txtDiemSuDung.Text.ToString());
        }
    }
}
