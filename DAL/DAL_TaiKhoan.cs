//using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Models;

namespace DAL
{
    public class DAL_TaiKhoan
    {
        public List<DTO.DTO_TaiKhoan> DanhSachTK()
        {
            using (QLCPdbcontext context = new QLCPdbcontext())
            {
                var list = context.TaiKhoans.Select(tk => new DTO_TaiKhoan
                {
                    IDTaiKhoan = tk.IDTaiKhoan,
                    password = tk.password,
                    TenNhanVien = tk.TenNhanVien,
                    LoaiTaiKhoan = tk.LoaiTaiKhoan
                }) ;
                return list.ToList();
            }
        }
        public bool ThemTaiKhoan(string idtaikhoan, string passWord, string tennhanvien, string loaitaikhoan)
        {
            TaiKhoan tk = new TaiKhoan();
            tk.IDTaiKhoan = idtaikhoan;
            tk.password = passWord;
            tk.TenNhanVien = tennhanvien;
            tk.LoaiTaiKhoan = loaitaikhoan;
            try
            {
                using (QLCPdbcontext context = new QLCPdbcontext())
                {
                    context.TaiKhoans.Add(tk);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool XoaTaiKhoan(string idtaikhoan, string passWord, string tennhanvien, string loaitaikhoan)
        {
            TaiKhoan tk = new TaiKhoan();
            tk.IDTaiKhoan = idtaikhoan;
            tk.password = passWord;
            tk.TenNhanVien = tennhanvien;
            tk.LoaiTaiKhoan = loaitaikhoan;
            try
            {
                using (QLCPdbcontext context = new QLCPdbcontext())
                {
                    //TaiKhoan tk = new TaiKhoan();
                    tk = context.TaiKhoans.Where(x => x.IDTaiKhoan == idtaikhoan).FirstOrDefault();
                    context.TaiKhoans.Remove(tk);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdateTaiKhoan(string idtaikhoan, string passWord, string tennhanvien, string loaitaikhoan)
        { 
            try
            {
                using (QLCPdbcontext context = new QLCPdbcontext())
                {
                    TaiKhoan tk_found = context.TaiKhoans.Single(p => p.IDTaiKhoan == idtaikhoan);
                    if (tk_found != null)
                    {
                        tk_found.IDTaiKhoan = idtaikhoan;
                        tk_found.password = passWord;
                        tk_found.TenNhanVien = tennhanvien;
                        tk_found.LoaiTaiKhoan = loaitaikhoan;

                        context.SaveChanges();
                        return true;
                    }
                    context.SaveChanges();
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
        
}

