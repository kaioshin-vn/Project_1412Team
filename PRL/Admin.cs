using B_BUS.Services;
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
        KhachHangService phong_khachhangsv = new KhachHangService();
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
        public void PHONG_LoadDataKH(List<KhachHang> data)
        {
            KH_GridView.Rows.Clear();
            int stt = 1;
            KH_GridView.ColumnCount = 7;
            KH_GridView.Columns[0].Name = "STT";
            KH_GridView.Columns[1].Name = "Họ tên";
            KH_GridView.Columns[2].Name = "Địa chỉ";
            KH_GridView.Columns[3].Name = "Số điện thoại";
            KH_GridView.Columns[4].Name = "Giới tính";
            KH_GridView.Columns[5].Name = "Ngày sinh";
            KH_GridView.Columns[6].Name = "Id";
            KH_GridView.Columns[6].Visible = false;
            foreach (var item in data)
            {
                KH_GridView.Rows.Add(stt++, item.Ten, item.DiaChi, item.SoDienThoai, item.GioiTinh, item.NgaySinh, item.IdKhachHang);
            }
        }
        private void KH_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var selectedKH = KH_GridView.Rows[index];
            KH_Txt_HoTen.Text = selectedKH.Cells[1].Value.ToString();
            KH_Txt_DiaChi.Text = selectedKH.Cells[2].Value.ToString();
            KH_Txt_Sdt.Text = selectedKH.Cells[3].Value.ToString();
            KH_Combo_GioiTinh.Text = selectedKH.Cells[4].Value.ToString();
            KH_DateTime_NgaySinh.Text = selectedKH.Cells[5].Value.ToString();
            var kh = phong_khachhangsv.FindKhachHang(selectedKH.Cells[6].Value.ToString());
        }
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

        private void KH_Btn_Them_Click(object sender, EventArgs e)
        {

        }

        private void KH_Btn_Sua_Click(object sender, EventArgs e)
        {

        }

        private void KH_Btn_An_Click(object sender, EventArgs e)
        {

        }
    }
}
