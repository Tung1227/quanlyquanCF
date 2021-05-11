using BLL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLCP
{
    public partial class NhanVien : Form
    {
        readonly BLL_Menu bLL_Menu = new BLL_Menu();
        public NhanVien()
        {
            InitializeComponent();
            TaoBan();
        }
        #region Event click
        private void button2_Click(object sender, EventArgs e)
        {

        }


        //private void btnBan1_Click(object sender, EventArgs e)
        //{
        //    Color btnban1 = Color.FromArgb(0, 255, 255);
        //    btnBan1.BackColor = btnban1;
        //}

        //private void btnThanhToán_Click(object sender, EventArgs e)
        //{
        //    btnBan1.BackColor = SystemColors.ButtonFace;
        //    btnBan1.UseVisualStyleBackColor = true;
        //}


        //private void btnBan2_Click(object sender, EventArgs e)
        //{
        //    Color btnban2 = Color.FromArgb(0, 255, 255);
        //    btnBan2.BackColor = btnban2;
        //}
        #endregion
        private void NhanVien_Load(object sender, EventArgs e)
        {
            cbbMenu.DataSource = bLL_Menu.DanhSachMenu();
            cbbMenu.BindingContext = this.BindingContext;
            cbbMenu.DisplayMember = "TenMon";
            nmDoUongCount.Value = 1;
        }
        private void TaoBan()
        {
            for (int i = 1; i <= 20; i++)
            {
                Button ban = new Button
                {
                    Text = "Bàn" + i,
                    Enabled = true,
                    Visible = true,
                    AutoSize = true,
                    Size = new Size(90, 90),
                    BackColor = Color.White,
                    Image = imageList1.Images[2],
                    TextImageRelation = TextImageRelation.ImageBeforeText
                };
                ban.Click += Ban_Click;
                ban.LostFocus += Ban_LostFocus;
                flpBan.Controls.Add(ban);
            }
        }

        private void Ban_LostFocus(object sender, EventArgs e)
        {
            Button ban = sender as Button;
            if (ban.BackColor == Color.Aquamarine)
                ban.BackColor = Color.White;
        }

        private void Ban_Click(object sender, EventArgs e)
        {
            Button ban = sender as Button;
            if (ban.BackColor != Color.Red)
                ban.BackColor = Color.Aquamarine;
        }
    }
}
