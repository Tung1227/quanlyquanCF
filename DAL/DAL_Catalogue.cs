using DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Catalogue
    {
        public List<DTO_Catalogue> LayDanhSachDanhMuc()
        {
            try
            {
                using (var context = new QLCPdbcontext())
                {
                    var list = (from p in context.Catalogues
                                select new DTO_Catalogue
                                {
                                    IDDanhMuc = p.IDDanhMuc,
                                    TenDanhMuc = p.TenDanhMuc
                                }).ToList();
                    return list;

                }
                
            }
            catch(Exception ex)
            {
                return new List<DTO_Catalogue>();
            }
        }
    }
}
