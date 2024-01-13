using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace QUANLYQUANTRASUA
{
    public partial class frmTinhToanDoanhThu : Form
    {
        DBHoaDon dbHoaDon;
        public frmTinhToanDoanhThu()
        {
            InitializeComponent();
            dbHoaDon = new DBHoaDon();
        }

        private void btnTinhToan_Click(object sender, EventArgs e)
        {
            int Year = Int32.Parse(this.cbxNam.Text.ToString());
            int Month = Int32.Parse(this.cbxThang.Text.ToString());
            float doanhThu = dbHoaDon.TinhTongDoanhThu(Year, Month);
            if(doanhThu > 0)
            {
                lblTinhToan.Text = "LÃI:";
            }
            else
            {
                lblTinhToan.Text = "LỖ:";
            }
            txtTinhToan.Text = doanhThu.ToString();
        }

        private void frmTinhToanDoanhThu_Load(object sender, EventArgs e)
        {

        }
    }
}
