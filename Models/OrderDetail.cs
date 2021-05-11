using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderDetail
    {
        [Key]
        [Column(Order = 1)]
        public int IDOrder { get; set; }
        [Key]
        [Column(Order = 2)]
        public string IDMon { get; set; }
        [Required]
        public int Gia { get; set; }
        public int SoLuong { get; set; }

        public virtual OrderM Order { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
