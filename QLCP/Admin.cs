using BLL;
using DTO;
using System;
using System.Windows.Forms;

namespace QLCP
{
    public partial class Admin : Form
    {
        int idorder;
        string idban, idtaikhoan;
        DateTime ngaymo, ngaydong;
        bool tinhtrangthanhtoan;
        string idmon;
        int gia;
        int soluong;



        BLL_TaiKhoan bLL_TaiKhoan = new BLL_TaiKhoan();
        BLL_Menu bLL_Menu = new BLL_Menu();
        BLL_Catalogue bLL_Catalogue = new BLL_Catalogue();
        BLL_OrderDetail bLL_OrderDetail = new BLL_OrderDetail();
        BLL_OrderM bLL_OrderM = new BLL_OrderM();

        #region Load

        public Admin()
        {
            InitializeComponent();
            dtgvTaiKhoanAdmin.AutoGenerateColumns = false;
            dtgvTaiKhoanAdmin.DataSource = bLL_TaiKhoan.DanhSachTaiKhoan();

            dtgvMenuAdmin.AutoGenerateColumns = false;
            dtgvMenuAdmin.DataSource = bLL_Menu.DanhSachMenu();

            cbMenuTimKiemAdmin.DataSource = bLL_Catalogue.LayDanhSachDanhMuc();
            cbMenuTimKiemAdmin.DisplayMember = "TenDanhMuc";


            dtgvOrderDetail.AutoGenerateColumns = false;
            dtgvOrderDetail.DataSource = bLL_OrderDetail.DanhSachLichSu();

            dtgvOrder.AutoGenerateColumns = false;
            dtgvOrder.DataSource = bLL_OrderM.DanhSachOrder();

        }
        #endregion
        #region TKAdmin

        private void btnThemTKAdmin_Click(object sender, EventArgs e)
        {
            string idtaikhoan, passWord, tennhanvien, loaitaikhoan;
            idtaikhoan = txbTaiKhoanAdmin.Text;
            passWord = txbMatKhauAdmin.Text;
            tennhanvien = txbTenNhanVienAdmin.Text;
            loaitaikhoan = txbLoaiTaiKhoanAdmin.Text;
            if (bLL_TaiKhoan.ThemTaiKhoan(idtaikhoan, passWord, tennhanvien, loaitaikhoan)) Admin_Load(sender, e);
        }
        private void Admin_Load(object sender, EventArgs e)
        {
            dtgvTaiKhoanAdmin.AutoGenerateColumns = false;
            dtgvTaiKhoanAdmin.DataSource = bLL_TaiKhoan.DanhSachTaiKhoan();

            dtgvMenuAdmin.AutoGenerateColumns = false;
            dtgvMenuAdmin.DataSource = bLL_Menu.DanhSachMenu();
            dtgvOrder.AutoGenerateColumns = false;
            dtgvOrder.DataSource = bLL_OrderM.DanhSachOrder();
            dtgvOrderDetail.AutoGenerateColumns = false;
            dtgvOrderDetail.DataSource = bLL_OrderDetail.DanhSachLichSu();
        }

        private void btnSuaTKAdmin_Click(object sender, EventArgs e)
        {
            string idtaikhoan, passWord, tennhanvien, loaitaikhoan;
            idtaikhoan = txbTaiKhoanAdmin.Text;
            passWord = txbMatKhauAdmin.Text;
            tennhanvien = txbTenNhanVienAdmin.Text;
            loaitaikhoan = txbLoaiTaiKhoanAdmin.Text;
            if (bLL_TaiKhoan.UpdateTaiKhoan(idtaikhoan, passWord, tennhanvien, loaitaikhoan)) Admin_Load(sender, e);
        }

        private void btnXoaTKAdmin_Click(object sender, EventArgs e)
        {
            string idtaikhoan, passWord, tennhanvien, loaitaikhoan;
            idtaikhoan = txbTaiKhoanAdmin.Text;
            passWord = txbMatKhauAdmin.Text;
            tennhanvien = txbTenNhanVienAdmin.Text;
            loaitaikhoan = txbLoaiTaiKhoanAdmin.Text;
            if (bLL_TaiKhoan.XoaTaiKhoan(idtaikhoan, passWord, tennhanvien, loaitaikhoan)) Admin_Load(sender, e);
        }

        private void dtgvTaiKhoanAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var row = dtgvTaiKhoanAdmin.Rows[index];
            txbTaiKhoanAdmin.Text = (string)row.Cells[0].Value;
            txbMatKhauAdmin.Text = (string)row.Cells[1].Value;
            txbTenNhanVienAdmin.Text = (string)row.Cells[2].Value;
            txbLoaiTaiKhoanAdmin.Text = (string)row.Cells[3].Value;
        }
        #endregion
        #region MenuAdmin
        private void btnThemMenuAdmin_Click(object sender, EventArgs e)
        {
            string idmon, tenmon, iddanhmuc;
            int gia;
            idmon = txbIDMonMenuAdmin.Text;
            tenmon = txbTenMonAdmin.Text;
            gia = int.Parse(txbGiaAdmin.Text);
            iddanhmuc = txbIDDanhMucAdmin.Text;
            if (bLL_Menu.ThemMenu(idmon, tenmon, gia, iddanhmuc)) Admin_Load(sender, e);
        }

        private void btnXoaMenuAdmin_Click(object sender, EventArgs e)
        {
            string idmon, tenmon, iddanhmuc;
            int gia;
            idmon = txbIDMonMenuAdmin.Text;
            tenmon = txbTenMonAdmin.Text;
            gia = int.Parse(txbGiaAdmin.Text);
            iddanhmuc = txbIDDanhMucAdmin.Text;
            if (bLL_Menu.XoaMenu(idmon, tenmon, gia, iddanhmuc)) Admin_Load(sender, e);
        }

        private void btnSuaMenuAdmin_Click(object sender, EventArgs e)
        {
            string idmon, tenmon, iddanhmuc;
            int gia;
            idmon = txbIDMonMenuAdmin.Text;
            tenmon = txbTenMonAdmin.Text;
            gia = int.Parse(txbGiaAdmin.Text);
            iddanhmuc = txbIDDanhMucAdmin.Text;
            if (bLL_Menu.UpdateMenu(idmon, tenmon, gia, iddanhmuc)) Admin_Load(sender, e);
        }
        private void dtgvMenuAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index == -1)
                return;
            var row = dtgvMenuAdmin.Rows[index];
            txbIDMonMenuAdmin.Text = (string)row.Cells[0].Value;
            txbTenMonAdmin.Text = (string)row.Cells[1].Value;
            txbGiaAdmin.Text = row.Cells[2].Value + "";
            txbIDDanhMucAdmin.Text = (string)row.Cells[3].Value;

        }
        #endregion
        #region TimKiem

        private void cbMenuTimKiemAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tenmon = cbMenuTimKiemAdmin.SelectedItem as DTO_Catalogue;
            cbTenMonAdmin.DataSource = bLL_Menu.GetTenMon(tenmon.TenDanhMuc);
            cbTenMonAdmin.DisplayMember = "TenMon";

        }

        private void CbTenMonAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = cbTenMonAdmin.SelectedItem as DTO_Menu;
            string tenmon = selectedItem.TenMon;

            dtgvMenuAdmin.ClearSelection();
            foreach (DataGridViewRow row in dtgvMenuAdmin.Rows)
            {
                string cellValue = row.Cells[1].Value?.ToString();
                if (cellValue.Equals(tenmon))
                    row.Selected = true;
            }
        }
        #endregion
        private void btnChuyenAdmin_Click(object sender, EventArgs e)
        {
            NhanVien fnhanvien = new NhanVien();
            fnhanvien.ShowDialog();
        }



        private void dtgvOrderDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index == -1)
                return;
            var row = dtgvOrderDetail.Rows[index];
            idorder = (int)row.Cells[0].Value;
            idmon = (string)row.Cells[1].Value;
            gia = (int)row.Cells[2].Value;
            soluong = (int)row.Cells[3].Value;
        }
        private void btnXoaChiTietLichSu_Click(object sender, EventArgs e)
        {
            bLL_OrderDetail.XoaOrderDetail(idorder, idmon);
            Admin_Load(sender, e);
        }

        private void DtgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int index = e.RowIndex;
            if (index == -1)
                return;
            var row = dtgvOrder.Rows[index];
            idorder = (int)row.Cells[0].Value;
            idban = (string)row.Cells[1].Value;
            ngaymo = (DateTime)row.Cells[2].Value;
            ngaydong = (DateTime)row.Cells[3].Value;
            tinhtrangthanhtoan = (bool)row.Cells[4].Value;
            idtaikhoan = (string)row.Cells[5].Value;
        }

        private void btnXoaOrder_Click(object sender, EventArgs e)
        {
            bLL_OrderM.XoaOrder(idorder);
            Admin_Load(sender, e);
        }
    }
}
