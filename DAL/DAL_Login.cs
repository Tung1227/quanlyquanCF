using DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Login
    {
        QLCPdbcontext context = new QLCPdbcontext();
        public DTO_TaiKhoan GetTaiKhoans(string id)
        {
            var list = context.TaiKhoans.Where(x => x.IDTaiKhoan.Equals(id)).Select(x => new DTO_TaiKhoan
            {
                IDTaiKhoan = x.IDTaiKhoan,
                password = x.password,
                TenNhanVien = x.TenNhanVien,
                LoaiTaiKhoan = x.LoaiTaiKhoan
            }).FirstOrDefault() ;
            return list;

        }
    }
}
