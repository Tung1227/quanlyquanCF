using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Catalogue
    {
        [Key]
        [StringLength(10)]
        public string IDDanhMuc { get; set; }
        [StringLength(50)]
        public string TenDanhMuc { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
