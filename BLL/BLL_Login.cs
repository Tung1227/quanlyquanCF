using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class BLL_Login
    {
        DAL_Login TaiKhoan = new DAL_Login();

        public int login(string tk, string mk)
        {
            var list = TaiKhoan.GetTaiKhoans(tk);
            if(list == null)
            {
                MessageBox.Show("Tài khoản không tồn tại!");
                return 0;
            }
            else
            {
                if (list.password.Equals(mk) == false)
                {
                    MessageBox.Show("Sai mật khẩu!");
                    return 0;
                }
                else
                {
                    if (list.LoaiTaiKhoan.Equals("Admin") == true)
                        return 1;
                    else return 2;

                }
            }    
      
        }
    }
}
