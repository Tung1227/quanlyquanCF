using System;

namespace DTO
{
    public class DTO_OrderM
    {

        public int IDOrder { get; set; }
        public String IDBan { get; set; }
        public String IDTaiKhoan { get; set; }

        public DateTime NgayMo { get; set; }

        public DateTime NgayDong { get; set; }

        public bool TinhTrangThanhToan { get; set; }
    }
}
