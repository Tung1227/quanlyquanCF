using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Catalogue
    {
        DAL_Catalogue dAL_Catalogue = new DAL_Catalogue();
        public List<DTO_Catalogue> LayDanhSachDanhMuc()
        {
            return dAL_Catalogue.LayDanhSachDanhMuc();
        }

    }
}
