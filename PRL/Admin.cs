using A_DAL.Repositories;
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
            LoadData();
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


        public string text;
        public double number;
        public double total = 0;
        KhachHangRepository Tan_KhachHangRepository = new KhachHangRepository();
        DichVuRepository Tan_DichVuRepository = new DichVuRepository();
        PhieuKhamSer Tan_phieuKhamSer = new PhieuKhamSer();
        HoaDonService Tan_hoaDonService = new HoaDonService();
        HoaDonChiTietService Tan_HDchiTietService = new HoaDonChiTietService();
        DichVuService DichVuService = new DichVuService();
        void LoadData()
        {
            var count = 0;
            var data = Tan_HDchiTietService.GetAllHDCT().Join(Tan_phieuKhamSer.GetAllPhieuKham(),
            n => n.IdHoaDon, m => m.IdKhachHang, (p, q) => new
            {
                STT = ++count,
                TenKH = p.TrangThai,
                TenDichVu = q.Ten,
                Gia = q,
                //id = p.IdKhachHang,
            }).ToList();



            foreach (var item in data)
            {
                TT_poisonDataGridView3.Rows.Add(item.STT, item.TenKH, item.TenDichVu, item.Gia);
            }
            TT_poisonDataGridView3.DataSource = data;


            //TT_poisonDataGridView3.ColumnCount = 6;
            //TT_poisonDataGridView3.Columns[0].Name = "Email";
            //TT_poisonDataGridView3.Columns[1].Name = "Tên NV";
            //TT_poisonDataGridView3.Columns[2].Name = "Địa chỉ";
            //TT_poisonDataGridView3.Columns[3].Name = "Mật khẩu";
            //TT_poisonDataGridView3.Columns[4].Name = "Vai trò";
            //foreach (var item in Tan_KhachHangRepository.GetAllKhachHang())
            //{
            //    TT_poisonDataGridView3.Rows.Add(item.Ten);
            //}
        }

        private void TT_poisonDataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 || e.RowIndex < TT_poisonDataGridView3.Rows.Count)
            {
                var data = TT_poisonDataGridView3.Rows[e.RowIndex];
                TT_txt_TenKH.Text = data.Cells[1].Value.ToString();
                TT_Label_DVSD.Text = data.Cells[2].Value.ToString();
                TT_txt_GiaTien.Text = data.Cells[3].Value.ToString();
            }
            

        }

        private void TT_Btn_ThanhToan_Click(object sender, EventArgs e)
        {
            TT_txt_GhiChu.Text = text;
            TT_txt_ChiPhiKhac.Text = Convert.ToDouble(number).ToString();
            if (double.TryParse(TT_txt_GiaTien.Text, out double giaTien) && double.TryParse(TT_txt_ChiPhiKhac.Text, out double chiPhiKhac))
            {
                total = giaTien + chiPhiKhac;
                TT_txt_TongTien.Text = total.ToString();
            }
            TT_txt_ThoiGianTT.Text = DateTime.Now.ToString();




        }

        private void TT_Btn_Sua_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn sửa không", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var item = Tan_KhachHangRepository.GetAllKhachHang().FirstOrDefault(KhachHangDuocChon);
                if (item != null)
                {
                    var _hoaDon = new HoaDon();
                    _hoaDon.GhiChu = TT_txt_GhiChu.Text;
                    Tan_hoaDonService.UpdateHoaDon(_hoaDon);
                    MessageBox.Show("Sửa thành công");
                }
            }
            else MessageBox.Show("Sửa thất bại");
        }

        private void TT_Btn_An_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn ẩn không", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var _hoaDon = new HoaDon();
                _hoaDon.HienThi = false;
                Tan_hoaDonService.UpdateHoaDon(_hoaDon);
                MessageBox.Show("Ẩn thành công");
            }
            else MessageBox.Show("Ẩn thất bại");
        }
    }
}
