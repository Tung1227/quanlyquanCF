using DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_Menu
    {
        public List<DTO_Menu> DanhSachMenu()
        {
            using (QLCPdbcontext context = new QLCPdbcontext())
            {
                var list = context.Menus.Select(tk => new DTO_Menu
                {
                    IDMon = tk.IDMon,
                    TenMon = tk.TenMon,
                    Gia = tk.Gia,
                    IDDanhMuc = tk.IDDanhMuc
                }) ;
                return list.ToList();
            }
        }
        public bool ThemMenu(string idmon, string tenmon, int gia, string iddanhmuc)
        {
            Menu mn = new Menu();
            mn.IDMon = idmon;
            mn.TenMon = tenmon;
            mn.Gia = gia;
            mn.IDDanhMuc = iddanhmuc;
            try
            {
                using (QLCPdbcontext context = new QLCPdbcontext())
                {
                    context.Menus.Add(mn);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool XoaMenu(string idmon, string tenmon, int gia, string iddanhmuc)
        {
            Menu mn = new Menu();
            mn.IDMon = idmon;
            mn.TenMon = tenmon;
            mn.Gia = gia;
            mn.IDDanhMuc = iddanhmuc;
            try
            {
                using (QLCPdbcontext context = new QLCPdbcontext())
                {

                    mn = context.Menus.Where(x => x.IDMon == idmon).FirstOrDefault();
                    context.Menus.Remove(mn);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdateMenu(string idmon, string tenmon, int gia, string iddanhmuc)
        {
            try
            {
                using (QLCPdbcontext context = new QLCPdbcontext())
                {
                    Menu tk_found = context.Menus.Single(p => p.IDMon == idmon);
                    if (tk_found != null)
                    {
                        tk_found.IDMon = idmon;
                        tk_found.TenMon = tenmon;
                        tk_found.Gia = gia;
                        tk_found.IDDanhMuc = iddanhmuc;

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
        public string Layten(string id)
        {
            using(QLCPdbcontext context = new QLCPdbcontext())
            {
                return context.Catalogues.Where(x => x.IDDanhMuc.Equals(id)).Select(x => x.TenDanhMuc).FirstOrDefault();
                
            }
        }
    }
}
