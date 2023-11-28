using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRL
{
    public partial class Admin : Form
    {
        public Admin(NhanVien staff, Login login)
        {
            FormLogin = login;
            user = staff;
            InitializeComponent();
        }

        public Admin()
        {
            user = new NhanVien();
            FormLogin = new Login();
            InitializeComponent();
        }

        /// Thuộc tính thêm vào
        NhanVien? user = null;
        Login? FormLogin = null;
        BacSi? BacSiDuocChon;
        YTa? YTaDuocChon = null;
        NhanVien? NhanVienDuocChon = null;
        HoaDon? HoaDonDuocChon = null;
        DichVu? DichVuDuocChon = null;
        Admin? AdminDuocChon = null;
        PhieuKham? PhieuKhamDuocChon = null;
        Luong? LuongDuocChon = null;
        ThongKe? ThongKeDuocChon = null;
        Phong? PhongDuocChon = null;
        CaKham? CaKhamDuocChon = null;
        KhachHang? KhachHangDuocChon = null;
        ///


        private void Admin_Load(object sender, EventArgs e)
        {
            // Panel_DV.Visible = false;
            Content.Controls.Clear();
            Panel_ManHinhCho.Visible = true;
            Content.Controls.Add(Panel_ManHinhCho);
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void QL_LichKham_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_LK.Visible = true;
            Content.Controls.Add(Panel_LK);
        }

        private void QL_KH_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_KH.Visible = true;
            Content.Controls.Add(Panel_KH);

        }

        private void Admin_VisibleChanged(object sender, EventArgs e)
        {
            // FormLogin.Visible = false;
            //   Panel_DV.Visible = false;
        }


        private void NV_ChucVu_Click(object sender, EventArgs e)
        {

        }


        private void NV_Ten_Click(object sender, EventArgs e)
        {

        }

        private void QL_DV_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_KH.Visible = true;
            Content.Controls.Add(Panel_DV);
        }


        private void bunifuRange1_RangeChanged(object sender, EventArgs e)
        {
            DV_Label_PhanTram.Text = $"{100 - DV_Range_GiamGia.RangeMin} %";
        }


        private void NV_Btn_XemLuong_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_L.Visible = true;
            Content.Controls.Add(Panel_L);
        }


        private void ThongKe_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_ThongKe.Visible = true;
            Content.Controls.Add(Panel_ThongKe);
            //checkedListBox1.
        }


        private void QL_ThanhToan_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_TT.Visible = true;
            Content.Controls.Add(Panel_TT);
        }


        private void QL_TaiKhoan_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_TK.Visible = true;
            Content.Controls.Add(Panel_TK);
        }

        private void ThongBao_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Cho phép đăng nhập?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Ok tài khoản đã được cho phép đăng nhập!!");
            }
        }

        private void QL_TroGiup_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy bắn 50k vào tài khoản 0978040960 MB Bank để được hỗ trợ bạn nhé !!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        private void QL_NV_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_NV.Visible = true;
            Content.Controls.Add(Panel_NV);
        }

        private void DV_Btn_GiamGia_Click(object sender, EventArgs e)
        {
            DV_GrBox.Visible = false;
            DV_Btn_OKGiamGia.Visible = true;
            DV_Range_GiamGia.Visible = true;
            DV_Label_PhanTram.Visible = true;
        }

        private void DV_Btn_Them_Click(object sender, EventArgs e)
        {
            DV_Btn_OKGiamGia.Visible = false;
            DV_Range_GiamGia.Visible = false;
            DV_Label_PhanTram.Visible = false;
            DV_GrBox.Visible = true;
        }

        private void DV_BtnSua1_Click(object sender, EventArgs e)
        {
            DV_Btn_OKGiamGia.Visible = false;
            DV_Range_GiamGia.Visible = false;
            DV_Label_PhanTram.Visible = false;
            DV_GrBox.Visible = true;
        }
    }
}
