using DAL;
using DTO;
//using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_OrderM
    {
        DAL_OrderM dAL_OrderM = new DAL_OrderM();
        public List<DTO_OrderM> DanhSachOrder()
        {
            var list = dAL_OrderM.DanhSachOrder();
            return list;
        }
        public void XoaOrder(int idorder)
        {
            dAL_OrderM.XoaOrder(idorder);
        }
    }
}
