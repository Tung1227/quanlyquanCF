using BLL;
using System;
using System.Windows.Forms;

namespace QLCP
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        #region Event

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            BLL_Login log = new BLL_Login();
            Admin fadmin = new Admin();
            string tk, mk;
            tk = txbTenDangNhap.Text;
            mk = txbMatKhau.Text;
            if (log.login(tk, mk) == 1)
            {
                this.Hide();
                fadmin.ShowDialog();

            }
            else if (log.login(tk, mk) == 2)
            {
                NhanVien fnhanvien = new NhanVien();
                this.Hide(); 
                fnhanvien.ShowDialog();

            }
            this.Dispose();

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát hay không", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        #endregion
    }
}
