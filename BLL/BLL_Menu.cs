using DAL;
using DTO;
//using Models;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class BLL_Menu
    {
        DAL_Menu dal_Menu = new DAL_Menu();
        public List<DTO_Menu> DanhSachMenu()
        {
            var list = dal_Menu.DanhSachMenu();
            foreach (var i in list)
            {
                i.IDDanhMuc = dal_Menu.Layten(i.IDDanhMuc);
            }
            return list;
        }
        public bool ThemMenu(string idmon, string tenmon, int gia, string iddanhmuc)
        {
            if (dal_Menu.ThemMenu(idmon, tenmon, gia, iddanhmuc)) return true;
            return false;
        }
        public bool XoaMenu(string idmon, string tenmon, int gia, string iddanhmuc)
        {
            if (dal_Menu.XoaMenu(idmon, tenmon, gia, iddanhmuc)) return true;
            return false;
        }
        public bool UpdateMenu(string idmon, string tenmon, int gia, string iddanhmuc)
        {
            if (dal_Menu.UpdateMenu(idmon, tenmon, gia, iddanhmuc)) return true;
            return false;
        }
        public string Layten(string id)
        {
            return dal_Menu.Layten(id);
        }
        public List<DTO_Menu> GetTenMon(string danhmuc)
        {
            var list = dal_Menu.DanhSachMenu();
            List<DTO_Menu> res = new List<DTO_Menu>();
            foreach (var item in dal_Menu.DanhSachMenu())
            {
                if (Layten(item.IDDanhMuc).Equals(danhmuc))
                    res.Add(item);
            }
            return res;
        }
    }
}
