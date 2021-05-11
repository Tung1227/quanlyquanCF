using DAL;
using DTO;
//using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class BLL_TaiKhoan
    {
        DAL_TaiKhoan taiKhoanDAL = new DAL_TaiKhoan();
        public bool ThemTaiKhoan(string idtaikhoan, string passWord, string tennhanvien, string loaitaikhoan)
        {
            if (taiKhoanDAL.ThemTaiKhoan(idtaikhoan, passWord, tennhanvien, loaitaikhoan)) return true;
            return false;
        }
        public bool XoaTaiKhoan(string idtaikhoan, string passWord, string tennhanvien, string loaitaikhoan)
        {
            if (taiKhoanDAL.XoaTaiKhoan(idtaikhoan, passWord, tennhanvien, loaitaikhoan)) return true;
            return false;
        }
        public bool UpdateTaiKhoan(string idtaikhoan, string passWord, string tennhanvien, string loaitaikhoan)
        {
            if (taiKhoanDAL.UpdateTaiKhoan(idtaikhoan, passWord, tennhanvien, loaitaikhoan)) return true;
            return false;
        }
        public List<DTO_TaiKhoan> DanhSachTaiKhoan()
        {
            var list = taiKhoanDAL.DanhSachTK();
            return list;
        }
    }
}
