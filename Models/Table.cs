using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Table
    {
        [Key]
        [StringLength(10)]
        public string IDBAN { get; set; }
        public string TenBan { get; set;  }
        [DefaultValue(1)]
        public string KhuVuc { get; set; }

        [DefaultValue(2)]
        public int SoLuongChoNgoi { get; set; }

        public virtual ICollection<OrderM> Orders { get; set; }
    }
}
