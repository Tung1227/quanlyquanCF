using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class QLCPdbcontext : DbContext
    {
        public QLCPdbcontext() : base("qlcpconnectionstring")
        {

        }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<Catalogue> Catalogues { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<OrderM> OrderMs { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
