using DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_OrderM
    {
        public List<DTO_OrderM> DanhSachOrder()
        {
            using (QLCPdbcontext context = new QLCPdbcontext())
            {
                var list = context.OrderMs.Select(tk => new DTO_OrderM
                {
                    IDOrder = tk.IDOrder,
                    IDBan = tk.IDBan,
                    NgayMo = tk.NgayMo,
                    NgayDong = tk.NgayDong,
                    IDTaiKhoan = tk.IDTaiKhoan
                });
                return list.ToList();
            }
        }
        public bool XoaOrder(int idorder)
        {
            try
            {
                using (QLCPdbcontext context = new QLCPdbcontext())
                {
                    OrderM od = new OrderM();
                    od = context.OrderMs.Where(x => x.IDOrder == idorder).FirstOrDefault();
                    context.OrderMs.Remove(od);
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
