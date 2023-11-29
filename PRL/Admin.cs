using B_BUS.Services;
using DAL.DBContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;

namespace PRL
{
    public partial class Admin : Form
    {
        private readonly NhanVienSer Tho_nvService = new NhanVienSer();
        private readonly MyDbContext _dbcontext;
        private Guid iWhenClick;
        public Admin(NhanVien staff, Login login)
        {
            FormLogin = login;
            user = staff;
            InitializeComponent();
            _dbcontext = new MyDbContext();
            
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
            LoadDataNV();
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

        private void NV_Btn_Them_Click(object sender, EventArgs e)
        {
            var nv = new NhanVien();
            nv.Ten = NV_Text_HoTen.Text;
            nv.DiaChi = NV_Txt_DiaChi.Text;
            nv.SoDienThoai = NV_Txt_Sdt.Text;
            nv.GioiTinh = NV_Combo_GioiTinh.SelectedItem.ToString();
            nv.ChucVu = NV_combo_ChucVu.SelectedItem.ToString();
            var option = MessageBox.Show("Xác nhận có muốn thêm!", "Thông báo!", MessageBoxButtons.YesNoCancel);
            if (option == DialogResult.Yes)
            {
                Tho_nvService.AddNhanVien(nv);
                MessageBox.Show("Thêm thành công!", "Thông báo!");
                LoadDataNV();
            }
            MessageBox.Show("Thêm thất bại!", "Thông báo!");
        }
        private void LoadDataNV()
        {
            int stt = 1;
            NV_GridView.ColumnCount = 9;
            NV_GridView.Columns[0].Name = "STT";
            NV_GridView.Columns[1].Name = "ID";
            NV_GridView.Columns[2].Name = "Họ Tên";
            NV_GridView.Columns[3].Name = "Địa Chỉ";
            NV_GridView.Columns[4].Name = "SDT";
            NV_GridView.Columns[5].Name = "Giới Tính";
            NV_GridView.Columns[6].Name = "Chức Vụ";
            NV_GridView.Columns[7].Name = "Ngày Sinh";
            NV_GridView.Columns[8].Name = "Password";
            NV_GridView.Columns[1].Visible = true;
            NV_GridView.Columns[8].Visible = true;
            
            foreach (var item in Tho_nvService.GetAllNhanVien(null))
            {
                NV_GridView.Rows.Add(stt++, item.IdNhanVien, item.Ten,item.DiaChi,item.SoDienThoai, item.ChucVu,item.ChucVu, item.NgaySinh,item.MatKhau);
            }
            NV_GridView.Rows.Clear();
        }

        private void NV_Txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            string search = NV_Txt_TimKiem.Text;
            Tho_nvService.GetAllNhanVien(search);
            LoadDataNV();
        }

        private void NV_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 && e.RowIndex > NV_GridView.Rows.Count)
            {
                return;
            }
            int rowIndex = e.RowIndex;
            iWhenClick = Guid.Parse(NV_GridView.Rows[rowIndex].Cells[1].Value.ToString());
            var clone = Tho_nvService.GetAllNhanVien(null).FirstOrDefault(x => x.IdNhanVien == iWhenClick);
            NV_Text_HoTen.TextButton = clone.Ten;
            NV_Txt_DiaChi.TextButton = clone.DiaChi;
            NV_Sdt.Text = clone.SoDienThoai;
            NV_Combo_GioiTinh.Text = clone.GioiTinh.ToString();
            NV_combo_ChucVu.Text = clone.ChucVu.ToString();
            NV_DateTime_NgaySinh.Text = clone.NgaySinh.ToString();

        }

        //private void ListCombobox()
        //{
        //    List<string> lstChucVu = new List<string>() {"Bác Sĩ", "Y Tá"};
        //    NV_combo_ChucVu.DataSource = lstChucVu;
        //}
        private void NV_Btn_Sua_Click(object sender, EventArgs e)
        {
            var nv = new NhanVien();
            nv.IdNhanVien = iWhenClick;
            nv.Ten = NV_Text_HoTen.Text;
            nv.DiaChi = NV_Txt_DiaChi.Text;
            nv.SoDienThoai = NV_Txt_Sdt.Text;
            nv.GioiTinh = NV_Combo_GioiTinh.SelectedItem.ToString();
            nv.ChucVu = NV_combo_ChucVu.SelectedItem.ToString();
            var option = MessageBox.Show("Xác nhận có muốn sửa!", "Thông báo!", MessageBoxButtons.YesNoCancel);
            if (option == DialogResult.Yes)
            {
                Tho_nvService.UpdateNhanVien(nv);
                MessageBox.Show("Sửa thành công!","Thông báo!");
                LoadDataNV();
            }
            MessageBox.Show("Sửa thất bại!", "Thông báo!");
        }
    }
}
