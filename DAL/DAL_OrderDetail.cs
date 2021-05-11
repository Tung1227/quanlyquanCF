using DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_OrderDetail
    {
        public List<DTO_OrderDetail> DanhSachLichSu()
        {
            using (QLCPdbcontext context = new QLCPdbcontext())
            {
                var list = context.OrderDetails.Select(tk => new DTO_OrderDetail
                {
                    IDOrder = tk.IDOrder,
                    IDMon = tk.IDMon,
                    Gia = tk.Gia,
                    SoLuong = tk.SoLuong
                }) ;
                return list.ToList();
            }
        }
        public bool XoaOrderDetail(int idorder, string IdMon)
        {
            try
            {
                using (QLCPdbcontext context = new QLCPdbcontext())
                {
                    OrderDetail oddt = new OrderDetail();
                    oddt = context.OrderDetails.Where(x => x.IDOrder == idorder && x.IDMon.Equals(IdMon)).FirstOrDefault();
                    context.OrderDetails.Remove(oddt);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
