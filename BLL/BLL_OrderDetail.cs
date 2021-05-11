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
    public class BLL_OrderDetail
    {
        DAL_OrderDetail dAL_OrderDetail = new DAL_OrderDetail();
        public List<DTO_OrderDetail> DanhSachLichSu()
        {
            var list = dAL_OrderDetail.DanhSachLichSu();
            return list;
        }
        public void XoaOrderDetail(int idorder,string IdMon)
        {
            dAL_OrderDetail.XoaOrderDetail(idorder,IdMon);
        }


    }
}
