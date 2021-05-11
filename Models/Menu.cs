using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Menu
    {
        [Key]
        [StringLength(10)]
        public string IDMon { get; set; }
        [Required]
        public string TenMon { get; set; }
        [DefaultValue(20000)]
        public int Gia  { get; set; }
        public string IDDanhMuc { get; set; }

        public virtual Catalogue DanhMuc { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
