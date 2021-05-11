using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TaiKhoan
    {
        [Key]
        [StringLength(10)]
        [Required]
        public string IDTaiKhoan { get; set; }
        [StringLength(10)]
        [Required]
        public string password { get; set; }
        [StringLength(50)]
        [Required]
        public string TenNhanVien { get; set; }
        [DefaultValue('N')]
        public string LoaiTaiKhoan { get; set; }
        
        public virtual ICollection<OrderM> Orders { get; set; }
    }
}

