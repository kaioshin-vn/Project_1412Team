using A_DAL.Repositories;
using B_BUS.Services;
using DAL.DBContext;
using DAL.Models;
using PRL.Tool;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;

namespace PRL
{
    public partial class Admin : Form
    {
        KhachHangService phong_khachhangsv = new KhachHangService();
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
            MyDbContext myDbContext = new MyDbContext();
            if (myDbContext.GiamGias.Any(a => a.TrangThai == true))
            {
                DV_Btn_DungGiamGia.Visible = true;
            }
            else
            {
                DV_Btn_DungGiamGia.Visible = false;
            }
            Giap_LoadDichVu();
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
            DV_Btn_OkThem.Visible = true;
            DV_Btn_OKSua.Visible = false;
        }

        private void DV_BtnSua1_Click(object sender, EventArgs e)
        {
            DV_Btn_OKGiamGia.Visible = false;
            DV_Range_GiamGia.Visible = false;
            DV_Label_PhanTram.Visible = false;
            DV_GrBox.Visible = true;
            DV_Btn_OKSua.Visible = true;
            DV_Btn_OkThem.Visible = false;
            var button = sender as ButtonCustom;
            if (button != null)
            {
                Giap_DV_XuLiButton_Click(button);
            }

        }

        private void DV_Btn_OKGiamGia_Click(object sender, EventArgs e)
        {
            MyDbContext db = new MyDbContext();
            var phanTramGiamGia = 100 - DV_Range_GiamGia.RangeMin;
            var giamGia = db.GiamGias.FirstOrDefault(a => a.id == 1);
            if (giamGia != null)
            {
                giamGia.PhanTramGiamGia = phanTramGiamGia;
                giamGia.TrangThai = true;
                db.GiamGias.Update(giamGia);
                db.SaveChanges();
            }
            DichVuRepository dichVuService = new DichVuRepository();
            var allDichVu = dichVuService.GetAllDichVu();
            foreach (var item in allDichVu)
            {
                item.Gia = Math.Round( item.Gia / 100 * (100 - phanTramGiamGia));
                db.Update(item);
                db.SaveChanges();
            }
            MessageBox.Show($"Đã giảm giá {phanTramGiamGia.ToString()}% cho mọi loại dịch vụ!  ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DV_Btn_DungGiamGia.Visible = true;
            DV_Btn_OKGiamGia.Visible = false;
            DV_Btn_GiamGia.Visible = false;
            DV_Range_GiamGia.Visible = false;
            DV_Label_PhanTram.Visible = false;
            Giap_LoadDichVu();

        }

        private void DV_Btn_OkThem_Click(object sender, EventArgs e)
        {
            var dichVu = new DichVu();
            var dvService = new DichVuService();
            dichVu.MoTa = DV_Txt_MoTa.Text;
            dichVu.Ten = DV_Txt_TenDichVu.Text;
            dichVu.HienThi = true;

            if (Giap_CheckTrong(DV_Txt_TenDichVu.Text) || Giap_CheckTrong(DV_Txt_MoTa.Text) || Giap_CheckTrong(DV_Txt_Gia.Text))
            {
                MessageBox.Show($"Không được bỏ trống các ô thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!Giap_CheckGia(DV_Txt_Gia.Text))
            {
                MessageBox.Show($"Chỉ được nhập giá", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (new DichVuRepository().GetAllDichVu().Any(a => a.Ten == DV_Txt_TenDichVu.Text))
            {
                MessageBox.Show($"Dịch vụ đã tồn tại,hãy thêm dịch vụ khác !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show($"Bạn chắc chắn muốn thêm dịch vụ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    dichVu.Gia = Convert.ToInt32(DV_Txt_Gia.Text);
                    dvService.AddDichVu(dichVu);
                    MessageBox.Show($"Đã thêm thành công dịch vụ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Giap_LoadDichVu();
                }
                else
                {
                    MessageBox.Show($"OK không thêm nữa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }



        }

        bool Giap_CheckTrong(string str)
        {
            return str == "";
        }
        bool Giap_CheckGia(string str)
        {
            return Regex.IsMatch(str, @"^\d+$");
        }

        private void DV_Btn_OKSua_Click(object sender, EventArgs e)
        {
            var dvService = new DichVuRepository();
            var dichVu = DichVuDuocChon;
            if (dichVu != null)
            {
                dichVu.MoTa = DV_Txt_MoTa.Text;
                dichVu.Ten = DV_Txt_TenDichVu.Text;
                if (Giap_CheckTrong(DV_Txt_TenDichVu.Text) || Giap_CheckTrong(DV_Txt_MoTa.Text) || Giap_CheckTrong(DV_Txt_Gia.Text))
                {
                    MessageBox.Show($"Không được bỏ trống các ô thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!Giap_CheckGia(DV_Txt_Gia.Text))
                {
                    MessageBox.Show($"Chỉ được nhập giá", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (new DichVuRepository().GetAllDichVu().Any(a => a.IdDichVu != dichVu.IdDichVu && a.Ten == DV_Txt_TenDichVu.Text))
                {
                    MessageBox.Show($"Dịch vụ đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show($"Bạn chắc chắn muốn sửa dịch vụ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        dichVu.Gia = Convert.ToInt32(DV_Txt_Gia.Text);
                        dvService.UpdateDichVu(dichVu);
                        MessageBox.Show($"Đã sửa thành công dịch vụ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Giap_LoadDichVu();
                    }
                    else
                    {
                        MessageBox.Show($"OK không sửa nữa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }


        }

        private void DV_BtnAn1_Click(object sender, EventArgs e)
        {
            var button = sender as ButtonCustom;
            if (button != null)
            {
                Giap_DV_XuLiButton_Click(button);
            }
            var dvService = new DichVuRepository();
            var dichVu = DichVuDuocChon;
            if (dichVu != null)
            {
                dichVu.HienThi = false;
            }

            if (DialogResult.Yes == MessageBox.Show($"Bạn chắc chắn muốn ẩn dịch vụ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (dichVu != null)
                {
                    dvService.UpdateDichVu(dichVu);
                    MessageBox.Show($"Đã ẩn thành công dịch vụ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Giap_LoadDichVu();
                }
            }
            else
            {
                MessageBox.Show($"OK không ẩn nữa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void Giap_DV_XuLiButton_Click(ButtonCustom button)
        {
            var dvService = new DichVuRepository();
            DichVuDuocChon = dvService.GetAllDichVu().FirstOrDefault(a => a.IdDichVu == Guid.Parse(button.IDSelected));

            if (DichVuDuocChon != null)
            {
                DV_Txt_Gia.Text = DichVuDuocChon.Gia.ToString();
                DV_Txt_MoTa.Text = DichVuDuocChon.MoTa;
                DV_Txt_TenDichVu.Text = DichVuDuocChon.Ten;
            }
        }


        void Giap_LoadDichVu()
        {
            DV_Panel_HienThiDV.Controls.Clear();
            var countYGrBox = 0;
            var countYBtnAn = 0;
            var countYBtnSua = 0;
            var countYMoTa = 0;
            var countYGia = 0;
            var countYTen = 0;
            var dvService = new DichVuRepository();
            foreach (var item in dvService.GetAllDichVu().Where(a => a.HienThi == true))
            {
                var DV_BtnAn1 = new ButtonCustom();
                DV_BtnAn1.BackColor = Color.MidnightBlue;
                DV_BtnAn1.BackgroundColor = Color.MidnightBlue;
                DV_BtnAn1.BorderColor = Color.DeepPink;
                DV_BtnAn1.BorderRadius = 20;
                DV_BtnAn1.BorderSize = 2;
                DV_BtnAn1.FlatAppearance.BorderSize = 0;
                DV_BtnAn1.FlatStyle = FlatStyle.Flat;
                DV_BtnAn1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
                DV_BtnAn1.ForeColor = Color.Red;
                DV_BtnAn1.Location = new Point(929, 167 + countYBtnAn);
                DV_BtnAn1.Name = "DV_BtnAn1";
                DV_BtnAn1.Size = new Size(154, 56);
                DV_BtnAn1.TabIndex = 4;
                DV_BtnAn1.Text = "Ẩn";
                DV_BtnAn1.TextColor = Color.Red;
                DV_BtnAn1.UseVisualStyleBackColor = false;
                DV_BtnAn1.IDSelected = item.IdDichVu.ToString();
                DV_BtnAn1.Click += DV_BtnAn1_Click;

                var DV_BtnSua1 = new ButtonCustom();
                DV_BtnSua1.BackColor = Color.Chartreuse;
                DV_BtnSua1.BackgroundColor = Color.Chartreuse;
                DV_BtnSua1.BorderColor = Color.Transparent;
                DV_BtnSua1.BorderRadius = 20;
                DV_BtnSua1.BorderSize = 4;
                DV_BtnSua1.FlatAppearance.BorderSize = 0;
                DV_BtnSua1.FlatStyle = FlatStyle.Flat;
                DV_BtnSua1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
                DV_BtnSua1.ForeColor = Color.LightYellow;
                DV_BtnSua1.Location = new Point(929, 74 + countYBtnSua);
                DV_BtnSua1.Name = "DV_BtnSua1";
                DV_BtnSua1.Size = new Size(154, 56);
                DV_BtnSua1.TabIndex = 3;
                DV_BtnSua1.Text = "Sửa";
                DV_BtnSua1.TextColor = Color.LightYellow;
                DV_BtnSua1.UseVisualStyleBackColor = false;
                DV_BtnSua1.IDSelected = item.IdDichVu.ToString();
                DV_BtnSua1.Click += DV_BtnSua1_Click;

                var DV_TxtMoTa1 = new CyberRichTextBox();
                DV_TxtMoTa1.Alpha = 20;
                DV_TxtMoTa1.BackColor = Color.Transparent;
                DV_TxtMoTa1.Background_WidthPen = 3F;
                DV_TxtMoTa1.BackgroundPen = true;
                DV_TxtMoTa1.ColorBackground = Color.FromArgb(255, 192, 192);
                DV_TxtMoTa1.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
                DV_TxtMoTa1.ColorLighting = Color.FromArgb(29, 200, 238);
                DV_TxtMoTa1.ColorPen_1 = Color.FromArgb(29, 200, 238);
                DV_TxtMoTa1.ColorPen_2 = Color.FromArgb(37, 52, 68);
                DV_TxtMoTa1.CyberRichTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
                DV_TxtMoTa1.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
                DV_TxtMoTa1.ForeColor = Color.FromArgb(245, 245, 245);
                DV_TxtMoTa1.Lighting = false;
                DV_TxtMoTa1.LinearGradientPen = false;
                DV_TxtMoTa1.Location = new Point(23, 89 + countYMoTa);
                DV_TxtMoTa1.Name = "DV_TxtMoTa1";
                DV_TxtMoTa1.PenWidth = 15;
                DV_TxtMoTa1.RGB = false;
                DV_TxtMoTa1.Rounding = true;
                DV_TxtMoTa1.RoundingInt = 60;
                DV_TxtMoTa1.Size = new Size(877, 136);
                DV_TxtMoTa1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                DV_TxtMoTa1.TabIndex = 2;
                DV_TxtMoTa1.Tag = "Cyber";
                DV_TxtMoTa1.TextButton = $"{item.MoTa}";
                DV_TxtMoTa1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                DV_TxtMoTa1.Timer_RGB = 300;

                var DV_LabelTenDichVu1 = new BigLabel();
                DV_LabelTenDichVu1.AutoSize = true;
                DV_LabelTenDichVu1.BackColor = Color.Transparent;
                DV_LabelTenDichVu1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
                DV_LabelTenDichVu1.ForeColor = Color.FromArgb(80, 80, 80);
                DV_LabelTenDichVu1.Location = new Point(20, 12 + countYTen);
                DV_LabelTenDichVu1.Name = "DV_LabelTenDichVu1";
                DV_LabelTenDichVu1.Size = new Size(135, 38);
                DV_LabelTenDichVu1.TabIndex = 0;
                DV_LabelTenDichVu1.Text = $"{item.Ten}";


                var DV_LabelGia1 = new BigLabel();
                DV_LabelGia1.AutoSize = true;
                DV_LabelGia1.BackColor = Color.Transparent;
                DV_LabelGia1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                DV_LabelGia1.ForeColor = Color.FromArgb(80, 80, 80);
                DV_LabelGia1.Location = new Point(23, 58 + countYGia);
                DV_LabelGia1.Name = "DV_LabelGia1";
                DV_LabelGia1.Size = new Size(171, 28);
                DV_LabelGia1.TabIndex = 1;
                DV_LabelGia1.Text = $"Giá : {item.Gia.ToString("0,000")} VNĐ";

                var DV_GrBoxDV1 = new HopeGroupBox();
                DV_GrBoxDV1.BorderColor = Color.FromArgb(220, 223, 230);
                DV_GrBoxDV1.Controls.Add(DV_BtnAn1);
                DV_GrBoxDV1.Controls.Add(DV_BtnSua1);
                DV_GrBoxDV1.Controls.Add(DV_TxtMoTa1);
                DV_GrBoxDV1.Controls.Add(DV_LabelTenDichVu1);
                DV_GrBoxDV1.Controls.Add(DV_LabelGia1);
                DV_GrBoxDV1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                DV_GrBoxDV1.ForeColor = Color.FromArgb(48, 49, 51);
                DV_GrBoxDV1.LineColor = Color.FromArgb(220, 223, 230);
                DV_GrBoxDV1.Location = new Point(3, 22 + countYGrBox);
                DV_GrBoxDV1.Name = "DV_GrBoxDV1";
                DV_GrBoxDV1.ShowText = false;
                DV_GrBoxDV1.Size = new Size(1108, 254);
                DV_GrBoxDV1.TabIndex = 2;
                DV_GrBoxDV1.TabStop = false;
                DV_GrBoxDV1.Text = "hopeGroupBox1";
                DV_GrBoxDV1.ThemeColor = Color.LightPink;



                //countYGia +=
                //countYBtnAn +=
                //countYBtnSua +=
                //countYGia +=
                //countYMoTa +=
                countYGrBox += 352;




                DV_Panel_HienThiDV.Controls.Add(DV_GrBoxDV1);
                var ThongKe11_ElispeGrView_ChiTieu = new Bunifu.Framework.UI.BunifuElipse(components);
                ThongKe_ElispeGrView_ChiTieu.ElipseRadius = 20;
                ThongKe11_ElispeGrView_ChiTieu.TargetControl = DV_GrBoxDV1;
            }
        }

        private void DV_Btn_DungGiamGia_Click(object sender, EventArgs e)
        {
            MyDbContext myDbContext = new MyDbContext();
            var obj = myDbContext.GiamGias.FirstOrDefault(a => a.id == 1);
            if (obj != null)
            {
                foreach (var item in myDbContext.DichVus.ToList())
                {
                    var phanTram = 100- obj.PhanTramGiamGia;
                    item.Gia =Math.Round( (item.Gia / Convert.ToDouble( phanTram) * 100));
                }
                obj.TrangThai = false;
                myDbContext.SaveChanges();
            }
            MessageBox.Show($"Đã dừng giảm giá", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DV_Btn_GiamGia.Visible = true;
            Giap_LoadDichVu();
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
        public void PHONG_LoadDataKH()
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
            foreach (var item in phong_khachhangsv.GetAllKhachHang(null))
            {
                KH_GridView.Rows.Add(stt++, item.Ten, item.DiaChi, item.SoDienThoai, item.GioiTinh, item.NgaySinh, item.IdKhachHang);
            }
        }
        private void KH_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 && e.RowIndex > KH_GridView.Rows.Count)
            {
                return;
            }
            int index = e.RowIndex;
            var selectedKH = KH_GridView.Rows[index];
            KH_Txt_HoTen.Text = selectedKH.Cells[1].Value.ToString();
            KH_Txt_DiaChi.Text = selectedKH.Cells[2].Value.ToString();
            KH_Txt_Sdt.Text = selectedKH.Cells[3].Value.ToString();
            KH_Combo_GioiTinh.Text = selectedKH.Cells[4].Value.ToString();
            KH_DateTime_NgaySinh.Text = selectedKH.Cells[5].Value.ToString();
            var kh = phong_khachhangsv.FindKhachHang(selectedKH.Cells[6].Value.ToString());
        }
        private void KH_Btn_Them_Click(object sender, EventArgs e)
        {
            var kh = new KhachHang();
            kh.Ten = KH_Txt_HoTen.Text;
            kh.DiaChi = KH_Txt_DiaChi.Text;
            kh.SoDienThoai = KH_Txt_Sdt.Text;
            kh.GioiTinh = KH_Combo_GioiTinh.SelectedItem.ToString();
            kh.NgaySinh = DateTime.Parse(KH_DateTime_NgaySinh.Text);
            var option = MessageBox.Show("Xác nhận có muốn thêm!", "Thông báo!", MessageBoxButtons.YesNoCancel);
            if (option == DialogResult.Yes)
            {
                phong_khachhangsv.AddKhachHang(kh);
                MessageBox.Show("Thêm thành công!", "Thông báo!");
                PHONG_LoadDataKH();
            }
            MessageBox.Show("Thêm thất bại!", "Thông báo!");
        }

        private void KH_Btn_Sua_Click(object sender, EventArgs e)
        {
            var kh = new KhachHang();
            kh.Ten = KH_Txt_HoTen.Text;
            kh.DiaChi = KH_Txt_DiaChi.Text;
            kh.SoDienThoai = KH_Txt_Sdt.Text;
            kh.GioiTinh = KH_Combo_GioiTinh.SelectedItem.ToString();
            kh.NgaySinh = DateTime.Parse(KH_DateTime_NgaySinh.Text);
            var option = MessageBox.Show("Xác nhận có muốn sửa!", "Thông báo!", MessageBoxButtons.YesNoCancel);
            if (option == DialogResult.Yes)
            {
                phong_khachhangsv.UpdateKhachHang(kh);
                MessageBox.Show("Sửa thành công!", "Thông báo!");
                PHONG_LoadDataKH();
            }
            MessageBox.Show("Sửa thất bại!", "Thông báo!");
        }

        private void KH_Btn_An_Click(object sender, EventArgs e)
        {

        }
    }
}
