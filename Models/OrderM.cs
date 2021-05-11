using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDOrder { get; set; }
        public String IDBan { get; set; }
        public String IDTaiKhoan { get; set; }
        
        public DateTime NgayMo { get; set; }
        
        public DateTime NgayDong { get; set; }
        [Required]
        public bool TinhTrangThanhToan { get; set; }

        public virtual Table Tables { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
