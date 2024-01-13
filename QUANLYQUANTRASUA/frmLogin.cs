using BUS;
using DAL;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.ActiveControl = panel;
            
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if(txtUser.Text.Length == 0)
            {
                txtUser.Text = "Tên đăng nhập";
                txtUser.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if(txtUser.Text == "Tên đăng nhập")
            {
                txtUser.ResetText();
                txtUser.Focus();
                txtUser.ForeColor = SystemColors.WindowText;
            }    
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if(txtPassword.Text.Length == 0)
            {
                txtPassword.Text = "Mật khẩu";
                txtPassword.ForeColor= SystemColors.GrayText;
            }    
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if(txtPassword.Text == "Mật khẩu")
            {
                txtPassword.ResetText();
                txtPassword.Focus();
                txtPassword.ForeColor = SystemColors.WindowText;
            }    
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult trloi = MessageBox.Show("Bạn có chắc muốn thoát không ?",
                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(trloi == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
            DBCurrentLogin_Singleton currentLogin =
                DBCurrentLogin_Singleton.GetCurrentLoginInfo();
            currentLogin.UserName = txtUser.Text;
            currentLogin.Password = txtPassword.Text;
            DAO db = new DAO(currentLogin.UserName, currentLogin.Password);
            string err = "";
            if(db.checkConnect(ref err) == false)
            {
                MessageBox.Show(err, "Sai thông tin đăng nhập" ,
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                frmThongTinNguoiDangNhap frm = new frmThongTinNguoiDangNhap();
                frm.ShowDialog();
            }
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if(chkHienMatKhau.Checked == true)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }    
        }
    }
}
