using A_DAL.Models;
using A_DAL.Repositories;
using B_BUS.IServices;
using B_BUS.Services;
using DAL.DBContext;
using DAL.Enums;
using DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using PRL.Tool;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Speech.Synthesis;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace PRL
{
    public partial class NhanVien : Form
    {
        Label currentSelectedMethod;
        Label previousSelectedMethod;
        KhachHangService phong_khachhangsv;
        NhanVienSer Tho_nvService;
        private Guid iWhenClick;
        public NhanVien(DAL.Models.NhanVien staff, Login login)
        {
            FormLogin = login;
            user = staff;
            InitializeComponent();
        }

        public NhanVien()
        {
            var nvSer = new NhanVienSer();
            user = nvSer.FindNhanVien(Guid.Parse("b35cdbf2-0dc4-49bf-5d13-08dbf3f00bdd"));
            FormLogin = new Login();
            InitializeComponent();
        }

        /// Thuộc tính thêm vào <summary>
        /// Thuộc tính thêm vào
        /// </summary>
        DAL.Models.NhanVien? user = null;
        Login? FormLogin = null;
        DAL.Models.NhanVien? NhanVienDuocChon = null;
        HoaDon? HoaDonDuocChon = null;
        HoaDon? TT_HoaDonDuocChon = null;
        DichVu? DichVuDuocChon = null;
        Admin? AdminDuocChon = null;
        PhieuKham? PhieuKhamDuocChon = null;
        Luong? LuongDuocChon = null;
        ThongKe? ThongKeDuocChon = null;
        Phong? PhongDuocChon = null;
        KhachHang? KhachHangDuocChon = null;
        DAL.Models.NhanVien? L_NVDuocChon;
        Luong? L_LuongDuocChon;
        ///

        private void Admin_Load(object sender, EventArgs e)
        {
            // Panel_DV.Visible = falsea
            Content.Controls.Clear();
            Panel_ManHinhCho.Visible = true;
            Content.Controls.Add(Panel_ManHinhCho);
            LoiChao.Text = "Xin chào " + user.Ten + " chúc một ngày làm việc vui vẻ!" + $"                  Hà Nội {DateTime.Now.ToString("dd/MM/yyyy")}";

        }

        int timeChange = 0;
        void changeColor(Label lb)
        {
            if (timeChange >= 1)
            {
                previousSelectedMethod = currentSelectedMethod;
                previousSelectedMethod.ForeColor = Color.Black;
            }
            if (timeChange == 0)
            {
                timeChange++;
            }

            currentSelectedMethod = lb;
            currentSelectedMethod.ForeColor = Color.Crimson;
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_ManHinhCho.Visible = true;
            Content.Controls.Add(Panel_ManHinhCho);
            if (currentSelectedMethod != null)
            {
                currentSelectedMethod.ForeColor = Color.Black;
            }
        }
        private void QL_KH_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_KH.Visible = true;
            Content.Controls.Add(Panel_KH);
            PHONG_LoadDataKH();
            changeColor(QL_KH);
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

        private void NV_Btn_XemLuong_Click(object sender, EventArgs e)
        {

            if (L_NVDuocChon == null)
            {
                MessageBox.Show("Chưa chọn nhân viên để xem lương !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            Content.Controls.Clear();
            Panel_L.Visible = true;
            Content.Controls.Add(Panel_L);
            L_LoadLuong();
        }
        private void QL_ThanhToan_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_TT.Visible = true;
            Content.Controls.Add(Panel_TT);
            Giap_LoadDataGrThanhToan();
            TT_Btn_An.Visible = false;
            TT_Btn_ThanhToan.Visible = false;
            TT_Btn_Sua.Visible = false;
        }
        private void QL_TaiKhoan_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_TK.Visible = true;
            Content.Controls.Add(Panel_TK);
            ShowThongTin();
        }

        private void ThongBao_Click(object sender, EventArgs e)
        {
            var taoThangLuongMoi = false;
            var lSer = new LuongSer();
            Guid idLuongThangHienTai = Guid.NewGuid();
            var luongThangHienTai = lSer.GetAllLuong().FirstOrDefault(a => a.IdNhanVien == user.IdNhanVien && a.ThoiGian.Value.ToString("MM/yyyy") == DateTime.Now.ToString("MM/yyyy"));
            if (luongThangHienTai == null)
            {
                taoThangLuongMoi = true;
                var luongNV = new Luong();
                luongNV.IdNhanVien = user.IdNhanVien;
                luongNV.SoCong = 0;
                luongNV.TrangThai = false;
                luongNV.Thuong = 0;
                luongNV.ThoiGian = DateTime.Now;
                lSer.AddLuong(luongNV);
                idLuongThangHienTai = luongNV.IdLuong;
            }
            if (!taoThangLuongMoi)
            {
                idLuongThangHienTai = luongThangHienTai.IdLuong;
            }

            var chamCong = new ChamCongService();
            var nv = chamCong.FindById(user.IdNhanVien);
            var tgCham = DateTime.Now;

            if (tgCham.Hour >= 22 || tgCham.Hour < 8)
            {
                MessageBox.Show("Chưa đến giờ chấm công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            if (nv.TrangThaiCham == false)
            {
                var kq = MessageBox.Show("Xác nhận chấm công vào ", "Chấm công", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == kq)
                {
                    nv.TrangThaiCham = true;
                    nv.ThoiGianBatDau = tgCham;
                    MessageBox.Show("Chấm công vào thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chamCong.Update(nv);
                }
                else
                {
                    MessageBox.Show("Chấm công nhanh lên nếu không làm không công cho công ty bây giờ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                if (nv.ThoiGianBatDau.Value.ToString("dd") != tgCham.ToString("dd"))
                {
                    nv.TrangThaiCham = false;
                    chamCong.Update(nv);
                    MessageBox.Show("Hãy chấm công lại do bạn chưa chấm công ra vào lần trước!");
                    return;
                }
                if (tgCham.Hour - nv.ThoiGianBatDau.Value.Hour <= 10)
                {
                    if (tgCham.Hour - nv.ThoiGianBatDau.Value.Hour < 10)
                    {
                        var phutPhaiLam = Math.Abs(59 - (tgCham.Minute - nv.ThoiGianBatDau.Value.Minute));
                        var gioPhaiLam = 9 - (tgCham.Hour - nv.ThoiGianBatDau.Value.Hour);


                        MessageBox.Show($"Chưa làm đủ giờ , bạn cần bị bóc lột {gioPhaiLam.ToString()} giờ {phutPhaiLam.ToString()} phút  nữa (T_T) !", "Tin buồn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (tgCham.Hour - nv.ThoiGianBatDau.Value.Hour == 10)
                    {
                        if (59 - (tgCham.Minute - nv.ThoiGianBatDau.Value.Minute) > 0)
                        {
                            var phutPhaiLam = Math.Abs(59 - (tgCham.Minute - nv.ThoiGianBatDau.Value.Minute));
                            MessageBox.Show($"Chưa làm đủ giờ , bạn cần bị bóc lột {phutPhaiLam.ToString()} phút nữa !", "Tin buồn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        var luongThangHT = lSer.FindLuong(idLuongThangHienTai);
                        luongThangHienTai.SoCong += 1;
                        var hsLuong = 300000;
                        if (user.ChucVu == LoaiNhanVien.BacSi)
                        {
                            hsLuong = 500000;
                        }
                        var kq = MessageBox.Show("Xác nhận chấm công ra ", "Chấm công", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult.Yes == kq)
                        {
                            lSer.UpdateLuong(luongThangHT);
                            MessageBox.Show($"Chấm công ra thành công!Cộng {hsLuong.ToString("0,000")} vào tài khoản ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            nv.TrangThaiCham = false;
                            chamCong.Update(nv);
                        }
                        else
                        {
                            MessageBox.Show("Lí do gì khiến bạn không chấm công ra ? (^-^) ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                }
                if (DateTime.Now.Hour - nv.ThoiGianBatDau.Value.Hour > 10)
                {
                    var luongThangHT = lSer.FindLuong(idLuongThangHienTai);
                    luongThangHienTai.SoCong += 1;
                    var hsLuong = 300000;
                    if (user.ChucVu == LoaiNhanVien.BacSi)
                    {
                        hsLuong = 500000;
                    }
                    var kq = MessageBox.Show("Xác nhận chấm công ra ", "Chấm công", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == kq)
                    {
                        lSer.UpdateLuong(luongThangHT);
                        MessageBox.Show($"Chấm công ra thành công!Cộng {hsLuong.ToString("0,000")} vào tài khoản ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        nv.TrangThaiCham = false;
                        chamCong.Update(nv);
                    }
                    else
                    {
                        MessageBox.Show("Lí do gì khiến bạn không chấm công ra ? (^-^) ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
        }

        private void QL_TroGiup_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy bắn 50k vào tài khoản 0978040960 MB Bank để được hỗ trợ bạn nhé !!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }







        bool Giap_CheckTrong(string str)
        {
            return str == "";
        }
        bool Giap_CheckGia(string str)
        {
            return Regex.IsMatch(str, @"^\d+$");
        }





        public void PHONG_LoadDataKH()
        {
            phong_khachhangsv = new KhachHangService();
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
            foreach (var item in phong_khachhangsv.GetAllKhachHang().Where(a => a.HienThi == true))
            {
                var gioiTinh = "Nam";
                if (item.GioiTinh == false)
                {
                    gioiTinh = "Nữ";
                }

                KH_GridView.Rows.Add(stt++, item.Ten, item.DiaChi, item.SoDienThoai, gioiTinh, item.NgaySinh.Value.ToString("dd/MM/yyyy"), item.IdKhachHang);
            }
        }


        public void Giap_LoadLSKham()
        {
            var kh = KhachHangDuocChon;
            if (kh != null)
            {
                var phieuKhamSer = new PhieuKhamSer();
                var lsKhamSer = new LichSuKhamService();
                var dvSer = new DichVuRepository();
                var TTcaKhamSer = new TrangThaiNhanVienService();
                var result = phieuKhamSer.GetAllPhieuKham().Where(a => a.IdKhachHang == kh.IdKhachHang && a.HienThi == true &&  a.TrangThai == true).Join(lsKhamSer.GetAllLichSuKham(), n => n.IdPhieuKham, m => m.IdPhieuKham, (p, q) =>
                {
                    return new
                    {
                        idDichVu = p.IdDichVu,
                        KetLuan = q.KetQua,
                        GhiChu = q.GhiChu,
                        NgayKham = p.ngayKham
                    };
                }).Join(dvSer.GetAllDichVu(), t => t.idDichVu, u => u.IdDichVu, (c, d) =>
                {
                    return new
                    {
                        DichVu = d.Ten,
                        KetLuan = c.KetLuan,
                        GhiChu = c.GhiChu,
                        NgayKham = c.NgayKham,
                    };
                }).ToList();
                var kq = "";
                foreach (var item in result)
                {
                    kq += $"\nNgày khám : {item.NgayKham.ToString("dd/MM/yyyy")}\nDịch vụ:{item.DichVu}\nKết quả : {item.KetLuan}\nGhi chú :Trống\n--------------------------------";
                }

                KH_RichTxt_LSKham.Text = kq;

            }
        }

        private void KH_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            phong_khachhangsv = new KhachHangService();
            if (e.RowIndex < 0 || e.RowIndex > KH_GridView.Rows.Count)
            {
                return;
            }

            int index = e.RowIndex;
            var selectedKH = KH_GridView.Rows[index];
            if (selectedKH.Cells[6].Value == null)
            {
                return;
            }
            KhachHangDuocChon = phong_khachhangsv.GetAllKhachHang().FirstOrDefault(a => a.IdKhachHang == Guid.Parse(selectedKH.Cells[6].Value.ToString()));
            KH_Txt_HoTen.TextButton = KhachHangDuocChon.Ten;
            KH_Txt_DiaChi.TextButton = KhachHangDuocChon.DiaChi;
            KH_Txt_Sdt.TextButton = KhachHangDuocChon.SoDienThoai;
            var gioiTinh = "Nam";
            if (KhachHangDuocChon.GioiTinh == false)
            {
                gioiTinh = "Nữ";
            }
            KH_Combo_GioiTinh.Text = gioiTinh;
            KH_DateTime_NgaySinh.Value = KhachHangDuocChon.NgaySinh.Value;
            Giap_LoadLSKham();
        }
        private void KH_Btn_Them_Click(object sender, EventArgs e)
        {
            phong_khachhangsv = new KhachHangService();
            var kh = new KhachHang();
            kh.Ten = KH_Txt_HoTen.TextButton;
            kh.DiaChi = KH_Txt_DiaChi.TextButton;
            kh.SoDienThoai = KH_Txt_Sdt.TextButton;
            var gioiTinh = true;
            if (KH_Combo_GioiTinh.Text == "Nữ")
            {
                gioiTinh = false;
            }
            kh.GioiTinh = gioiTinh;
            kh.NgaySinh = KH_DateTime_NgaySinh.Value;
            kh.HienThi = true;
            if (Giap_CheckTrong(KH_Txt_HoTen.TextButton) || Giap_CheckTrong(KH_Txt_DiaChi.TextButton) || Giap_CheckTrong(KH_Txt_Sdt.TextButton))
            {
                MessageBox.Show($"Không được bỏ trống các ô thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!Regex.IsMatch(KH_Txt_Sdt.TextButton, "^0[0-9]{9}$"))
            {
                MessageBox.Show($"Nhập đúng định dạng số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (phong_khachhangsv.GetTatCaKhachHang().Any(a => a.SoDienThoai == KH_Txt_Sdt.TextButton))
            {
                MessageBox.Show($"Số điện thoại đã tồn tại,hãy thêm số điện thoại khác !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var option = MessageBox.Show("Xác nhận có muốn thêm!", "Thông báo!", MessageBoxButtons.YesNoCancel);
                if (option == DialogResult.Yes)
                {
                    phong_khachhangsv.AddKhachHang(kh);
                    MessageBox.Show("Thêm thành công!", "Thông báo!");
                    PHONG_LoadDataKH();

                }
            }

        }

        void TaoTrangThaiNV(DAL.Models.NhanVien nv)
        {
            for (int i = 0; i < 7; i++)
            {
                var ttNVSer = new TTNhanVienSer();
                var TtNV = new TrangThaiNhanVien();
                TtNV.IdNhanVien = nv.IdNhanVien;
                TtNV.Ngay = DateTime.Now.AddDays(i);
                ttNVSer.AddTTNhanVien(TtNV);
            }
        }

        private void KH_Btn_Sua_Click(object sender, EventArgs e)
        {
            phong_khachhangsv = new KhachHangService();
            if (KhachHangDuocChon == null)
            {
                MessageBox.Show($"Chưa chọn khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var kh = phong_khachhangsv.FindKhachHang(KhachHangDuocChon.IdKhachHang);
            if (kh != null)
            {
                kh.Ten = KH_Txt_HoTen.TextButton;
                kh.DiaChi = KH_Txt_DiaChi.TextButton;
                kh.SoDienThoai = KH_Txt_Sdt.TextButton;
                var gioiTinh = false;
                if (KH_Combo_GioiTinh.Text == "Nam")
                {
                    gioiTinh = true;
                }
                kh.GioiTinh = gioiTinh;
                kh.NgaySinh = KH_DateTime_NgaySinh.Value;
                if (Giap_CheckTrong(KH_Txt_HoTen.TextButton) || Giap_CheckTrong(KH_Txt_DiaChi.TextButton) || Giap_CheckTrong(KH_Txt_Sdt.TextButton))
                {
                    MessageBox.Show($"Không được bỏ trống các ô thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!Regex.IsMatch(KH_Txt_Sdt.TextButton, "^0[0-9]{9}$"))
                {
                    MessageBox.Show($"Nhập đúng định dạng số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (phong_khachhangsv.GetTatCaKhachHang().Any(a => a.SoDienThoai == KH_Txt_Sdt.TextButton && kh.IdKhachHang != a.IdKhachHang))
                {
                    MessageBox.Show($"Số điện thoại đã tồn tại,hãy thêm số điện thoại khác !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var option = MessageBox.Show("Xác nhận có muốn sửa!", "Thông báo!", MessageBoxButtons.YesNoCancel);
                    if (option == DialogResult.Yes)
                    {
                        phong_khachhangsv.UpdateKhachHang(kh);
                        MessageBox.Show($"Đã sửa thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PHONG_LoadDataKH();
                    }
                }
            }
            else
            {
                MessageBox.Show($"Chưa chọn khách hàng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void KH_Btn_An_Click(object sender, EventArgs e)
        {
            phong_khachhangsv = new KhachHangService();
            if (KhachHangDuocChon == null)
            {
                MessageBox.Show($"Chưa chọn khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var kh = phong_khachhangsv.FindKhachHang(KhachHangDuocChon.IdKhachHang);
            if (kh != null)
            {
                kh.HienThi = false;
                var option = MessageBox.Show("Xác nhận có muốn ẩn!", "Thông báo!", MessageBoxButtons.YesNoCancel);
                if (option == DialogResult.Yes)
                {
                    phong_khachhangsv.UpdateKhachHang(kh);
                    MessageBox.Show($"Đã ẩn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PHONG_LoadDataKH();
                }
            }
            else
            {
                MessageBox.Show($"Chưa chọn khách hàng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }





        public void TinhToanLai()
        {

        }

        private void ThongKe_GrView_ChiTieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ThongKe_Btn_Loc_Click(object sender, EventArgs e)
        {

        }




        private void KH_Txt_TimKiem_Click(object sender, EventArgs e)
        {
            KH_Txt_TimKiem.Text = "";
        }

        private void KH_Btn_TimKiem_Click(object sender, EventArgs e)
        {
            phong_khachhangsv = new KhachHangService();
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
            KH_GridView.Rows.Clear();

            foreach (var item in phong_khachhangsv.GetAllKhachHang(KH_Txt_TimKiem.Text).Where(a => a.HienThi == true))
            {
                var gioiTinh = "Nam";
                if (item.GioiTinh == false)
                {
                    gioiTinh = "Nữ";
                }

                KH_GridView.Rows.Add(stt++, item.Ten, item.DiaChi, item.SoDienThoai, gioiTinh, item.NgaySinh.Value.ToString("dd/MM/yyyy"), item.IdKhachHang);
            }
        }


        void Giap_LoadDataGrThanhToan()
        {
            var thongKeSer = new ThongKeService();
            var hoaDonSer = new HoaDonService();
            var hoaDonCtSer = new HoaDonChiTietService();
            var dichVuSer = new DichVuService();
            var phieuKhamSer = new PhieuKhamSer();
            var khSer = new KhachHangService();
            var nvSer = new NhanVienSer();
            var luongSer = new LuongSer();
            var count = 1;

            var kqDaThanhToan1 = hoaDonSer.GetAllHoaDon().Join(hoaDonCtSer.GetAllHDCT().Where(a => a.TrangThai == true), n => n.IdHoaDon, m => m.IdHoaDon, (q, p) =>
            {
                return new
                {
                    idHD = q.IdHoaDon,
                    idNv = q.IdNhanVien,
                    PhuPhi = q.PhuPhi,
                    idPK = p.IdPhieuKham,
                    ThoiGian = q.ThoiGian,
                    idGiamGia = q.idGiamGia,
                };
            }).Join(phieuKhamSer.GetAllPhieuKham(), n => n.idPK, m => m.IdPhieuKham, (q, p) =>
            {
                return new
                {
                    idHD = q.idHD,
                    idNv = q.idNv,
                    PhuPhi = q.PhuPhi,
                    ThoiGian = q.ThoiGian,
                    idGiamGia = q.idGiamGia,
                    idKH = p.IdKhachHang,
                    idPK = p.IdPhieuKham,
                    idDichVu = p.IdDichVu,
                };
            }).Join(dichVuSer.GetAllDichVu(), n => n.idDichVu, m => m.IdDichVu, (q, p) =>
            {
                return new
                {
                    TenDv = p.Ten,
                    GiaDV = p.Gia,
                    idDichVu = p.IdDichVu,
                    idHD = q.idHD,
                    idPhieuKham = q.idPK,
                    idKH = q.idKH,
                    idnvThanhToan = q.idNv,
                    PhuPhi = q.PhuPhi,
                    ngayTT = q.ThoiGian,
                    idGiamGia = q.idGiamGia,

                };
            }).Join(khSer.GetAllKhachHang(), n => n.idKH, m => m.IdKhachHang, (q, p) =>
            {
                return new
                {
                    idHD = q.idHD,
                    idKH = q.idKH,
                    GiaDV = q.GiaDV,
                    TenDv = q.TenDv,
                    idnvThanhToan = q.idnvThanhToan,
                    ngayTT = q.ngayTT,
                    PhuPhi = q.PhuPhi,
                    TenKhachHang = p.Ten,
                    idGiamGia = q.idGiamGia,

                };
            }).Join(nvSer.GetAllNhanVien(), n => n.idnvThanhToan, m => m.IdNhanVien, (q, p) =>
            new
            {
                idHD = q.idHD,
                TenKhachHang = q.TenKhachHang,
                TenDv = q.TenDv,
                GiaDV = q.GiaDV,
                PhuPhi = q.PhuPhi,
                TenNhanVien = p.Ten,
                idGiamGia = q.idGiamGia,
                ngayTT = q.ngayTT.Value.ToString("dd/MM/yyyy"),
            }).ToList();



            var kqDaThanhToanGrouped = kqDaThanhToan1.GroupBy(a =>
            {
                return new
                {
                    a.idHD,
                    a.PhuPhi,
                    a.idGiamGia
                };
            });

            TT_GrView_DaTT.Rows.Clear();

            foreach (var b in kqDaThanhToanGrouped)
            {
                double tongGia = 0;
                var TenDv = new List<string>();
                foreach (var item in b)
                {
                    var Giadv = item.GiaDV;
                    if (b.Key.idGiamGia != null)
                    {
                        var giamGiaSer = new GiamGiaSer();
                        var TTgiamGia = giamGiaSer.FindGiamGia(Convert.ToInt32(b.Key.idGiamGia));
                        if (TTgiamGia != null)
                        {
                            Giadv = Convert.ToDouble((Giadv / TTgiamGia.PhanTramGiamGia) * 100);
                        }
                    }
                    tongGia += Giadv;

                    TenDv.Add(item.TenDv);
                }
                TT_GrView_DaTT.Rows.Add(count++, b.Key.idHD, b.FirstOrDefault().TenKhachHang, string.Join(",", TenDv), tongGia.ToString("0,000"), b.Key.PhuPhi, b.FirstOrDefault().TenNhanVien, b.FirstOrDefault().ngayTT, b.Key.idGiamGia);
            }




            TT_GrView_DaTT.ColumnCount = 10;
            TT_GrView_DaTT.Columns[0].Name = "STT";
            TT_GrView_DaTT.Columns[1].Name = "Mã hóa đơn";
            TT_GrView_DaTT.Columns[2].Name = "Người Thanh Toán";
            TT_GrView_DaTT.Columns[3].Name = "Dịch vụ sử dụng";
            TT_GrView_DaTT.Columns[4].Visible = false;
            TT_GrView_DaTT.Columns[5].Visible = false;
            TT_GrView_DaTT.Columns[6].Name = "Nhân viên Xác Nhận";
            TT_GrView_DaTT.Columns[7].Name = "Ghi chú";
            TT_GrView_DaTT.Columns[8].Name = "Ngày thanh toán";
            TT_GrView_DaTT.Columns[9].Visible = false;


            var kqChuaThanhToan1 = hoaDonSer.GetAllHoaDon().Join(hoaDonCtSer.GetAllHDCT().Where(a => a.TrangThai == false && a.HienThi == true ), n => n.IdHoaDon, m => m.IdHoaDon, (q, p) =>
            {
                return new
                {
                    idHD = q.IdHoaDon,
                    idPK = p.IdPhieuKham,
                };
            }).Join(phieuKhamSer.GetAllPhieuKham(), n => n.idPK, m => m.IdPhieuKham, (q, p) =>
            {
                return new
                {
                    idHD = q.idHD,
                    idKH = p.IdKhachHang,
                    idPK = p.IdPhieuKham,
                    idDichVu = p.IdDichVu,
                };
            }).Join(dichVuSer.GetAllDichVu(), n => n.idDichVu, m => m.IdDichVu, (q, p) =>
            {
                return new
                {
                    TenDv = p.Ten,
                    GiaDV = p.Gia,
                    idDichVu = p.IdDichVu,
                    idHD = q.idHD,
                    idPhieuKham = q.idPK,
                    idKH = q.idKH,
                };
            }).Join(khSer.GetAllKhachHang(), n => n.idKH, m => m.IdKhachHang, (q, p) =>
            {
                return new
                {
                    idHD = q.idHD,
                    idKH = q.idKH,
                    GiaDV = q.GiaDV,
                    TenDv = q.TenDv,
                    TenKhachHang = p.Ten,
                };
            }).ToList();


            var kqChuaThanhToanGrouped = kqChuaThanhToan1.GroupBy(a =>
                 new
                 {
                     a.idHD,
                 }
            );
            var kqChuaThanhToan = kqChuaThanhToanGrouped.Select(b => new
            {
                STT = count++,
                idHD = b.Key.idHD,
                TenKh = b.ToList()[0].TenKhachHang,
                TenDv = string.Join(",", b.Select(a => a.TenDv)),
                GiaDV = b.ToList().Sum(a => a.GiaDV).ToString("0,000") + "VNĐ"
            });


            if (kqChuaThanhToan.Count() == 0)
            {
                TT_GrView_ChuaTT.ColumnCount = 5;
                TT_GrView_ChuaTT.Columns[0].Name = "STT";
                TT_GrView_ChuaTT.Columns[1].Name = "Mã hóa đơn";
                TT_GrView_ChuaTT.Columns[2].Name = "Người Thanh Toán";
                TT_GrView_ChuaTT.Columns[3].Name = "Dịch vụ sử dụng";
                TT_GrView_ChuaTT.Columns[4].Name = "Tổng giá trị hóa đơn";
            }
            else
            {
                TT_GrView_ChuaTT.DataSource = kqChuaThanhToan;
                TT_GrView_ChuaTT.Columns[0].Name = "STT";
                TT_GrView_ChuaTT.Columns[1].Name = "Mã hóa đơn";
                TT_GrView_ChuaTT.Columns[2].Name = "Người Thanh Toán";
                TT_GrView_ChuaTT.Columns[3].Name = "Tên dịch vụ";
                TT_GrView_ChuaTT.Columns[4].Name = "Tổng giá trị hóa đơn";
            }



        }

        private void TT_GrView_ChuaTT_Click(object sender, EventArgs e)
        {

        }

        private void TT_GrView_ChuaTT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > TT_GrView_ChuaTT.Rows.Count)
            {
                return;
            }
            if (TT_GrView_ChuaTT.Rows[e.RowIndex].Cells[1].Value == null)
            {
                return;
            }
            var hdSer = new HoaDonService();
            var hdDuocChon = hdSer.FindHoaDon(Guid.Parse(TT_GrView_ChuaTT.Rows[e.RowIndex].Cells[1].Value.ToString()));
            if (hdDuocChon != null)
            {
                TT_Btn_Sua.Visible = false;
                TT_Btn_An.Visible = true;
                TT_Btn_ThanhToan.Visible = true;
                Giap_LoadThongTinChuaTT(hdDuocChon);
                TT_HoaDonDuocChon = hdDuocChon;
            }
            TT_txt_ChiPhiKhac.Text = "";
            TT_txt_GhiChu.Text = "";
            TT_txt_ThoiGianTT.Text = DateTime.Now.ToString("dd/MM/yyyy");
            TT_Txt_NVThanhToan.Text = user.Ten;
        }

        private void TT_GrView_DaTT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > TT_GrView_DaTT.Rows.Count)
            {
                return;
            }
            if (TT_GrView_DaTT.Rows[e.RowIndex].Cells[1].Value == null)
            {
                return;
            }
            var hdSer = new HoaDonService();
            var hdDuocChon = hdSer.FindHoaDon(Guid.Parse(TT_GrView_DaTT.Rows[e.RowIndex].Cells[1].Value.ToString()));
            if (hdDuocChon != null)
            {
                TT_Btn_Sua.Visible = true;
                TT_Btn_An.Visible = true;
                TT_Btn_ThanhToan.Visible = false;
                Giap_LoadThongTinTT(hdDuocChon);
                TT_HoaDonDuocChon = hdDuocChon;
            }
        }

        void Giap_LoadThongTinTT(HoaDon hdDuocChon)
        {
            var thongKeSer = new ThongKeService();
            var hoaDonSer = new HoaDonService();
            var hoaDonCtSer = new HoaDonChiTietService();
            var dichVuSer = new DichVuService();
            var phieuKhamSer = new PhieuKhamSer();
            var khSer = new KhachHangService();
            var nvSer = new NhanVienSer();
            var luongSer = new LuongSer();
            var count = 1;

            var kqDaThanhToan1 = hoaDonSer.GetAllHoaDon().Where(a => a.IdHoaDon == hdDuocChon.IdHoaDon).Join(hoaDonCtSer.GetAllHDCT(), n => n.IdHoaDon, m => m.IdHoaDon, (q, p) =>
            {
                return new
                {
                    idHD = q.IdHoaDon,
                    idNv = q.IdNhanVien,
                    PhuPhi = q.PhuPhi,
                    idPK = p.IdPhieuKham,
                    ThoiGian = q.ThoiGian,
                };
            }).Join(phieuKhamSer.GetAllPhieuKham(), n => n.idPK, m => m.IdPhieuKham, (q, p) =>
            {
                return new
                {
                    idHD = q.idHD,
                    idNv = q.idNv,
                    PhuPhi = q.PhuPhi,
                    ThoiGian = q.ThoiGian,
                    idKH = p.IdKhachHang,
                    idPK = p.IdPhieuKham,
                    idDichVu = p.IdDichVu,
                };
            }).Join(dichVuSer.GetAllDichVu(), n => n.idDichVu, m => m.IdDichVu, (q, p) =>
            {
                return new
                {
                    TenDv = p.Ten,
                    GiaDV = p.Gia,
                    idDichVu = p.IdDichVu,
                    idHD = q.idHD,
                    idPhieuKham = q.idPK,
                    idKH = q.idKH,
                    idnvThanhToan = q.idNv,
                    PhuPhi = q.PhuPhi,
                    ngayTT = q.ThoiGian
                };
            }).Join(khSer.GetAllKhachHang(), n => n.idKH, m => m.IdKhachHang, (q, p) =>
            {
                return new
                {
                    idHD = q.idHD,
                    idKH = q.idKH,
                    GiaDV = q.GiaDV,
                    TenDv = q.TenDv,
                    idnvThanhToan = q.idnvThanhToan,
                    ngayTT = q.ngayTT,
                    PhuPhi = q.PhuPhi,
                    TenKhachHang = p.Ten,
                };
            }).Join(nvSer.GetAllNhanVien(), n => n.idnvThanhToan, m => m.IdNhanVien, (q, p) =>
            new
            {
                idHD = q.idHD,
                TenKhachHang = q.TenKhachHang,
                TenDv = q.TenDv,
                GiaDV = q.GiaDV,
                PhuPhi = q.PhuPhi,
                TenNhanVien = p.Ten,
                ngayTT = q.ngayTT.Value.ToString("dd/MM/yyyy"),
            }).ToList();



            var kqDaThanhToanGrouped = kqDaThanhToan1.GroupBy(a =>
            {
                return new
                {
                    a.idHD,
                    a.PhuPhi,
                };
            });


            var stringText = "";
            var TongTienDV = 0;
            foreach (var item in kqDaThanhToanGrouped)
            {
                TT_Txt_MaHD.Text = item.Key.idHD.ToString();
                TT_txt_ChiPhiKhac.Text = $"{Convert.ToDouble(item.Key.PhuPhi).ToString("0,000")} VNĐ";
                TT_txt_GhiChu.Text = item.Key.idHD.ToString();
                TT_Txt_TenKH.Text = item.FirstOrDefault().TenKhachHang;
                TT_Txt_NVThanhToan.Text = item.FirstOrDefault().TenNhanVien;
                TT_txt_ThoiGianTT.Text = item.FirstOrDefault().ngayTT;
                TongTienDV = Convert.ToInt32(item.Sum(a => a.GiaDV).ToString());
                stringText = String.Join($"-{item.OrderByDescending(a => a.GiaDV).FirstOrDefault().GiaDV.ToString()}\n", item.OrderByDescending(b => b.GiaDV).Select(a => $"{a.TenDv}"));
            }
            TT_txt_TongTien.Text = TongTienDV.ToString("0,000") + "VNĐ";
            TT_Label_DVSD.Text = "Dịch vụ sử dụng :\n" + stringText;
        }


        void Giap_LoadThongTinChuaTT(HoaDon hdDuocChon)
        {
            var thongKeSer = new ThongKeService();
            var hoaDonSer = new HoaDonService();
            var hoaDonCtSer = new HoaDonChiTietService();
            var dichVuSer = new DichVuService();
            var phieuKhamSer = new PhieuKhamSer();
            var khSer = new KhachHangService();
            var nvSer = new NhanVienSer();

            var kqDaThanhToan1 = hoaDonSer.GetAllHoaDon().Where(a => a.IdHoaDon == hdDuocChon.IdHoaDon).Join(hoaDonCtSer.GetAllHDCT(), n => n.IdHoaDon, m => m.IdHoaDon, (q, p) =>
            {
                return new
                {
                    idHD = q.IdHoaDon,
                    idNv = q.IdNhanVien,
                    idPK = p.IdPhieuKham,
                    idGiamGia = q.idGiamGia
                };
            }).Join(phieuKhamSer.GetAllPhieuKham(), n => n.idPK, m => m.IdPhieuKham, (q, p) =>
            {
                return new
                {
                    idHD = q.idHD,
                    idNv = q.idNv,
                    idKH = p.IdKhachHang,
                    idPK = p.IdPhieuKham,
                    idDichVu = p.IdDichVu,
                    idGiamGia = q.idGiamGia

                };
            }).Join(dichVuSer.GetAllDichVu(), n => n.idDichVu, m => m.IdDichVu, (q, p) =>
            {
                return new
                {
                    TenDv = p.Ten,
                    GiaDV = p.Gia,
                    idDichVu = p.IdDichVu,
                    idHD = q.idHD,
                    idPhieuKham = q.idPK,
                    idKH = q.idKH,
                    idGiamGia = q.idGiamGia

                };
            }).Join(khSer.GetAllKhachHang(), n => n.idKH, m => m.IdKhachHang, (q, p) =>
            {

                return new
                {
                    idHD = q.idHD,
                    idKH = q.idKH,
                    GiaDV = q.GiaDV,
                    TenDv = q.TenDv,
                    TenKhachHang = p.Ten,
                    idGiamGia = q.idGiamGia

                };
            }).ToList();



            var kqDaThanhToanGrouped = kqDaThanhToan1.GroupBy(a =>
            {
                return new
                {
                    a.idHD,
                    a.idGiamGia
                };
            });


            var stringText = "";
            double TongTienDV = 0;
            foreach (var item in kqDaThanhToanGrouped)
            {
                foreach (var item1 in item)
                {
                    var Giadv = item1.GiaDV;
                    if (item.Key.idGiamGia != null)
                    {
                        var giamGiaSer = new GiamGiaSer();
                        var TTgiamGia = giamGiaSer.FindGiamGia(Convert.ToInt32(item.Key.idGiamGia));
                        if (TTgiamGia != null)
                        {
                            Giadv = Convert.ToDouble((Giadv / TTgiamGia.PhanTramGiamGia) * 100);
                        }
                        TongTienDV += Giadv;
                        stringText = String.Join($"-{Giadv.ToString("0,000")} VNĐ\n", item1.TenDv);
                    }
                }
                TT_Txt_MaHD.Text = item.Key.idHD.ToString();
                TT_Txt_TenKH.Text = item.FirstOrDefault().TenKhachHang;
            }
            TT_txt_TongTien.Text = TongTienDV.ToString("0,000") + "VNĐ";
            TT_Label_DVSD.Text = "Dịch vụ sử dụng :\n" + stringText;
        }

        private void TT_Btn_Sua_Click(object sender, EventArgs e)
        {
            if (TT_HoaDonDuocChon == null)
            {
                MessageBox.Show($"Chưa chọn hóa đơn để sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var hdSer = new HoaDonService();
                if (!Giap_CheckGia(TT_txt_ChiPhiKhac.Text))
                {
                    MessageBox.Show($"Hãy nhập số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var hd = hdSer.FindHoaDon(TT_HoaDonDuocChon.IdHoaDon);
                    hd.PhuPhi = Convert.ToDouble(TT_Label_ChiPhiKhac.Text);
                    hdSer.UpdateHoaDon(hd);
                    MessageBox.Show($"Đã cập nhật thông tin hóa đơn thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Giap_LoadDataGrThanhToan();
                }

            }
        }

        private void TT_Btn_An_Click(object sender, EventArgs e)
        {
            if (TT_HoaDonDuocChon == null)
            {
                MessageBox.Show($"Chưa chọn hóa đơn để ẩn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show($"Bạn chắc chắn muốn ẩn hóa đơn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    var hdctSer = new HoaDonChiTietService();
                    var hdct = hdctSer.GetAllHDCT().FirstOrDefault(a => a.IdHoaDon == TT_HoaDonDuocChon.IdHoaDon);
                    hdctSer.UpdateHDCT(hdct);
                    MessageBox.Show($"Đã ẩn hóa đơn thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Giap_LoadDataGrThanhToan();

                }
                else
                {

                }
            }
        }

 


        private void LK_Btn_ThemLichKham_Click(object sender, EventArgs e)
        {
            LK_Panel.Controls.Clear();
            LK_Panel.Controls.Add(LK_Grbox_ThemLichKham);
            spaceSeparatorHorizontal1.Location = new Point(LK_Btn_ThemLichKham.Location.X, spaceSeparatorHorizontal1.Location.Y);
            spaceSeparatorHorizontal1.Size = new Size(LK_Btn_ThemLichKham.Width + 1, spaceSeparatorHorizontal1.Height);
            Giap_LK_LoadComboKhachHangBacSiDichVuNgayPhong();
            LK_TPK_Combo_KhachHang.Enabled = true;
        }





        private void QL_LichKham_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_L.Visible = true;
            Content.Controls.Add(Panel_L);
            L_LoadLuong();
            changeColor(QL_LichKham);
        }


        private void LK_XLK_Checkbox_Load(object sender, EventArgs e)
        {
        }


        void Giap_LK_LoadComboKhachHangBacSiDichVuNgayPhong()
        {
            var khachHangSer = new KhachHangService();
            var bacSiSer = new NhanVienSer();
            var yTaSer = new NhanVienSer();
            var dichVuSer = new DichVuService();
            var ttPhongSer = new TrangThaiPhongSerVice();
            var phongSer = new PhongSer();

            var dataComboKh = khachHangSer.GetAllKhachHang().Select(a =>
            {
                return new
                {
                    id = a.IdKhachHang,
                    ten = a.Ten
                };
            }).ToList();


            var dataBacSi = bacSiSer.GetAllNhanVien().Where(b => b.ChucVu == LoaiNhanVien.BacSi).Select(a =>
            {
                return new
                {
                    id = a.IdNhanVien,
                    ten = a.Ten
                };
            }).ToList();

            var dataYta = yTaSer.GetAllNhanVien().Where(b => b.ChucVu == LoaiNhanVien.YTa).Select(a =>
            {
                return new
                {
                    id = a.IdNhanVien,
                    ten = a.Ten
                };
            }).ToList();

            var dataDichVu = dichVuSer.GetAllDichVu().Select(a =>
            {
                return new
                {
                    ten = a.Ten,
                    id = a.IdDichVu,
                };
            }).ToList();

            var phong = phongSer.GetAllPhong().FirstOrDefault(a => a.LoaiPhong == LoaiPhong.P406);

            var dataNgay = ttPhongSer.GetAllTrangThaiPhong().Where(a => DateTime.Parse(a.Ngay.ToString("MM/dd/yyyy")) >= DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) && a.IdPhong == phong.Id).Select(a =>
            {
                return new
                {
                    ngay = a.Ngay.ToString("MM/dd/yyyy"),
                };
            }).ToList();
            var dataPhong = phongSer.GetAllPhong().Select(a =>
            {
                return new
                {
                    id = a.Id,
                    ten = a.LoaiPhong,
                };
            }).ToList();



            LK_TPK_Combo_Phong.DataSource = dataPhong;
            LK_TPK_Combo_DichVu.DataSource = dataDichVu;
            LK_TPK_Combo_Ngay.DataSource = dataNgay;
            LK_TPK_Combo_KhachHang.DataSource = dataComboKh;
            LK_TPK_ComBo_BacSi.DataSource = dataBacSi;
            LK_TPK_Combo_YTa.DataSource = dataYta;

            LK_TPK_Combo_KhachHang.DisplayMember = "ten";
            LK_TPK_Combo_KhachHang.ValueMember = "id";

            LK_TPK_ComBo_BacSi.DisplayMember = "ten";
            LK_TPK_ComBo_BacSi.ValueMember = "id";

            LK_TPK_Combo_YTa.DisplayMember = "ten";
            LK_TPK_Combo_YTa.ValueMember = "id";

            LK_TPK_Combo_Ngay.DisplayMember = "ngay";
            LK_TPK_Combo_Ngay.ValueMember = "ngay";


            LK_TPK_Combo_DichVu.DisplayMember = "ten";
            LK_TPK_Combo_DichVu.ValueMember = "id";

            LK_TPK_Combo_Phong.DisplayMember = "ten";
            LK_TPK_Combo_Phong.ValueMember = "id";

        }


        int firtTime_TPK_ca = 0;
        void Giap_LoadComboCa()
        {
            if (firtTime_TPK_ca < 4)
            {
                firtTime_TPK_ca++;
            }
            if (firtTime_TPK_ca <= 2)
            {
                return;
            }
            var ttNVSer = new TTNhanVienSer();
            var ttPhongSer = new TTPhongSer();

            DateTime ngayDuocChon;

            ngayDuocChon = DateTime.Parse(LK_TPK_Combo_Ngay.SelectedValue.ToString());

            if (!LK_TPK_Combo_Gio.Enabled)
            {
                return;
            }
            var TTYta = ttNVSer.GetTTNhanVien().FirstOrDefault(a => a.Ngay.ToString("MM/dd/yyyy") == ngayDuocChon.ToString("MM/dd/yyyy") && a.IdNhanVien == Guid.Parse(LK_TPK_Combo_YTa.SelectedValue.ToString()));

            List<int> lstcaTrongYTa = new List<int>();
            if (TTYta != null)
            {
                int countYTa = 1;
                foreach (var t in TTYta.TrangThai.Split("|"))
                {
                    if (t == "false")
                    {
                        lstcaTrongYTa.Add(countYTa);
                    }
                    countYTa++;
                }
            }


            var TTBSi = ttNVSer.GetTTNhanVien().FirstOrDefault(a => a.Ngay.ToString("MM/dd/yyyy") == ngayDuocChon.ToString("MM/dd/yyyy") && a.IdNhanVien == Guid.Parse(LK_TPK_ComBo_BacSi.SelectedValue.ToString()));
            List<int> lstcaTrongBSi = new List<int>();
            if (TTBSi != null)
            {
                int countBSi = 1;
                foreach (var t in TTBSi.TrangThai.Split("|"))
                {
                    if (t == "false")
                    {
                        lstcaTrongBSi.Add(countBSi);
                    }
                    countBSi++;
                }
            }

            var TTPhong = ttPhongSer.GetTTPhong().FirstOrDefault(a => a.Ngay.ToString("MM/dd/yyyy") == ngayDuocChon.ToString("MM/dd/yyyy") && a.IdPhong == Guid.Parse(LK_TPK_Combo_Phong.SelectedValue.ToString()));
            List<int> lstcaPhongTrong = new List<int>();
            if (TTPhong != null)
            {
                int countPhong = 1;
                foreach (var t in TTPhong.TrangThai.Split("|"))
                {
                    if (t == "false")
                    {
                        lstcaPhongTrong.Add(countPhong);
                    }
                    countPhong++;
                }
            }

            var lstCaTrong = new List<int>();
            lstCaTrong = lstcaTrongYTa.Intersect(lstcaTrongBSi).Intersect(lstcaPhongTrong).ToList();


            if (ngayDuocChon.ToString("MM/dd/yyyy") == DateTime.Now.ToString("MM/dd/yyyy"))
            {
                var gioTrongNgay = Convert.ToInt32(DateTime.Now.ToString("hh"));
                if (DateTime.Now.ToString("tt") == "AM")
                {
                    if (gioTrongNgay >= 8)
                    {
                        var obj = lstCaTrong.Any(a => a == 1);
                        if (obj)
                        {
                            lstCaTrong.Remove(1);
                        }
                    }
                    if (gioTrongNgay >= 9)
                    {
                        var obj = lstCaTrong.Any(a => a == 2);
                        if (obj)
                        {
                            lstCaTrong.Remove(2);
                        }
                    }
                    if (gioTrongNgay >= 10)
                    {
                        var obj = lstCaTrong.Any(a => a == 3);
                        if (obj)
                        {
                            lstCaTrong.Remove(3);
                        }
                    }
                    if (gioTrongNgay >= 11)
                    {
                        var obj = lstCaTrong.Any(a => a == 4);
                        if (obj)
                        {
                            lstCaTrong.Remove(4);
                        }
                    }
                }
                if (DateTime.Now.ToString("tt") == "PM")
                {
                    lstCaTrong.Remove(1);
                    lstCaTrong.Remove(2);
                    lstCaTrong.Remove(3);
                    lstCaTrong.Remove(4);
                    if (gioTrongNgay >= 2)
                    {
                        var obj = lstCaTrong.Any(a => a == 5);
                        if (obj)
                        {
                            lstCaTrong.Remove(5);
                        }
                    }
                    if (gioTrongNgay >= 3)
                    {
                        var obj = lstCaTrong.Any(a => a == 6);
                        if (obj)
                        {
                            lstCaTrong.Remove(6);
                        }
                    }
                    if (gioTrongNgay >= 4)
                    {
                        var obj = lstCaTrong.Any(a => a == 7);
                        if (obj)
                        {
                            lstCaTrong.Remove(7);
                        }
                    }
                    if (gioTrongNgay >= 5)
                    {
                        var obj = lstCaTrong.Any(a => a == 8);
                        if (obj)
                        {
                            lstCaTrong.Remove(8);
                        }
                    }
                }
            }

            LK_TPK_Combo_Gio.DataSource = lstCaTrong;


        }

        private void buttonCustom2_Click(object sender, EventArgs e)
        {
            if (KhachHangDuocChon == null)
            {
                MessageBox.Show("Chưa chọn khách hàng !", "Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var khSer = new KhachHangService();
            var kh = khSer.FindKhachHang(KhachHangDuocChon.IdKhachHang);

            Content.Controls.Clear();
            Panel_LK.Visible = true;
            Content.Controls.Add(Panel_LK);
            var ttNhanVienSer = new TTNhanVienSer();
            var ttPhongSer = new TTPhongSer();
            var nvSer = new NhanVienSer();
            var phongSer = new PhongSer();
            if (DateTime.Parse(ttPhongSer.GetTTPhong().OrderByDescending(a => a.Ngay).FirstOrDefault().Ngay.AddDays(7).ToString("MM/dd/yyyy")) < DateTime.Parse(DateTime.Now.AddDays(7).ToString("MM/dd/yyyy")))
            {
                foreach (var item in nvSer.GetAllNhanVien())
                {
                    var TtNV = new TrangThaiNhanVien();
                    TtNV.IdNhanVien = item.IdNhanVien;
                    TtNV.Ngay = DateTime.Now.AddDays(7);
                    ttNhanVienSer.AddTTNhanVien(TtNV);
                }
                foreach (var item in phongSer.GetAllPhong())
                {
                    var ttPhong = new TrangThaiPhong();
                    ttPhong.IdPhong = item.Id;
                    ttPhong.Ngay = DateTime.Now.AddDays(7);
                    ttPhongSer.AddTTPhong(ttPhong);
                }
            }


            LK_Panel.Controls.Clear();
            LK_Panel.Controls.Add(LK_Grbox_ThemLichKham);
            spaceSeparatorHorizontal1.Location = new Point(LK_Btn_ThemLichKham.Location.X, spaceSeparatorHorizontal1.Location.Y);
            spaceSeparatorHorizontal1.Size = new Size(LK_Btn_ThemLichKham.Width + 1, spaceSeparatorHorizontal1.Height);
            Giap_LK_LoadComboKhachHangBacSiDichVuNgayPhong();
            LK_TPK_Combo_KhachHang.SelectedValue = kh.IdKhachHang;
            LK_TPK_Combo_KhachHang.Enabled = false;



        }

        void Giap_CheckCaHopLe()
        {
            if (LK_TPK_ComBo_BacSi.Text == "" || LK_TPK_Combo_DichVu.Text == "" || LK_TPK_Combo_KhachHang.Text == "" || LK_TPK_Combo_Phong.Text == "" || LK_TPK_Combo_YTa.Text == "" || LK_TPK_Combo_Ngay.Text == "")
            {
                LK_TPK_Combo_Gio.Enabled = false;
            }
            else
            {
                LK_TPK_Combo_Gio.Enabled = true;
                Giap_LoadComboCa();
            }
        }


        /// var Lịch khám
        DAL.Models.NhanVien LK_BSDuocChon = null;
        DAL.Models.NhanVien LK_YTaDuocChon = null;
        KhachHang LK_KhDuocChon = null;
        Phong LK_PhongDuocChon = null;
        DichVu LK_DVDuocChon = null;
        TrangThaiNhanVien LK_NgayDuocChon = null;
        ///

        int firtTime_TPK_KH = 0;
        private void LK_TPK_Combo_KhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (firtTime_TPK_KH < 4)
            {
                firtTime_TPK_KH++;
            }
            if (firtTime_TPK_KH <= 2)
            {
                return;
            }


            var idKh = LK_TPK_Combo_KhachHang.SelectedValue.ToString();

            var kh = new KhachHangService().GetAllKhachHang().FirstOrDefault(a => a.IdKhachHang == Guid.Parse(idKh));
            if (kh != null)
            {
                LK_KhDuocChon = kh;
                LK_TPK_RichText.Text = "Thông tin\n\n" + $"Họ tên : {kh.Ten}\n\n\nĐịa Chỉ : {kh.DiaChi}\n\n\nSố điện thoại : {kh.SoDienThoai}" +
                    $"\n\n\nNgày sinh {kh.NgaySinh.Value.ToString("dd/MM/yyyy")}";
            }
        }


        int firtTime_TPK_BS = 0;
        private void LK_TPK_ComBo_BacSi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (firtTime_TPK_BS < 4)
            {
                firtTime_TPK_BS++;
            }
            if (firtTime_TPK_BS <= 2)
            {
                return;
            }
            var kh = new NhanVienSer().GetAllNhanVien().FirstOrDefault(a => a.IdNhanVien == Guid.Parse(LK_TPK_ComBo_BacSi.SelectedValue.ToString()));
            if (kh != null)
            {
                LK_BSDuocChon = kh;
                LK_TPK_RichText.Text = "Thông tin\n\n\n" + $"Bác sĩ : {kh.Ten}\n\n\nĐịa Chỉ : {kh.DiaChi}\n\n\nSố điện thoại : {kh.SoDienThoai}" +
                    $"\n\n\nNgày sinh {kh.NgaySinh.Value.ToString("dd/MM/yyyy")}\n\n\nGiới thiệu : {kh.Mota}";

            }
            Giap_LoadComboCa();
        }
        int firtTime_TPK_YT = 0;
        private void LK_TPK_Combo_YTa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (firtTime_TPK_YT < 4)
            {
                firtTime_TPK_YT++;
            }
            if (firtTime_TPK_YT <= 2)
            {
                return;
            }
            var kh = new NhanVienSer().GetAllNhanVien().FirstOrDefault(a => a.IdNhanVien == Guid.Parse(LK_TPK_Combo_YTa.SelectedValue.ToString()));
            if (kh != null)
            {
                LK_YTaDuocChon = kh;
                LK_TPK_RichText.Text = "Thông tin\n\n\n" + $"Y tá : {kh.Ten}\n\n\nĐịa Chỉ : {kh.DiaChi}\n\n\nSố điện thoại : {kh.SoDienThoai}" +
                    $"\n\n\nNgày sinh {kh.NgaySinh.Value.ToString("dd/MM/yyyy")}\n\n\nGiới thiệu : {kh.Mota}";
            }
            Giap_LoadComboCa();

        }


        int firtTime_TPK_Dv = 0;
        private void LK_TPK_Combo_DichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (firtTime_TPK_Dv < 4)
            {
                firtTime_TPK_Dv++;
            }
            if (firtTime_TPK_Dv <= 2)
            {
                return;
            }
            if (LK_TPK_Combo_KhachHang.SelectedValue == null)
            {
                return;
            }
            var kh = new DichVuService().GetAllDichVu().FirstOrDefault(a => a.IdDichVu == Guid.Parse(LK_TPK_Combo_DichVu.SelectedValue.ToString()));
            if (kh != null)
            {
                LK_DVDuocChon = kh;
                LK_TPK_RichText.Text = "Thông tin\n\n\n" + $"Dịch vụ : {kh.Ten}\n\n\nGiá : {kh.Gia.ToString("0,000")} VNĐ\n\n\nMô tả: {kh.MoTa}";
            }


        }
        int firttimeTPK_Combo_Gio = 0;
        private void LK_TPK_Combo_Gio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void LoadThongTinTPK()
        {
            string gioKham;
            if (LK_TPK_Combo_Gio.Text == "1")
            {
                gioKham = "8:00 AM";
            }
            else if (LK_TPK_Combo_Gio.Text == "2")
            {
                gioKham = "9:00 AM";
            }
            else if (LK_TPK_Combo_Gio.Text == "3")
            {
                gioKham = "10:00 AM";
            }
            else if (LK_TPK_Combo_Gio.Text == "4")
            {
                gioKham = "11:00 AM";
            }
            else if (LK_TPK_Combo_Gio.Text == "5")
            {
                gioKham = "2:00 AM";
            }
            else if (LK_TPK_Combo_Gio.Text == "6")
            {
                gioKham = "3:00 PM";
            }
            else if (LK_TPK_Combo_Gio.Text == "7")
            {
                gioKham = "4:00 PM";
            }
            else if (LK_TPK_Combo_Gio.Text == "8")
            {
                gioKham = "5:00 PM";
            }
            else
            {
                gioKham = "Chưa chọn";
            }
            LK_TPK_RichText.Text = "Thông tin\n\n" + $"Khách hàng : {LK_TPK_Combo_KhachHang.Text}\n\nBác sĩ : {LK_TPK_ComBo_BacSi.Text}\n\nY tá : {LK_TPK_Combo_YTa.Text}\n\n" +
    $"Dịch vụ : {LK_TPK_Combo_DichVu.Text}\n\nPhòng : {LK_TPK_Combo_Phong.Text}\n\nNgày khám {LK_TPK_Combo_Ngay.Text}\n\nGiờ : {gioKham}\n\n\n\nHãy nhớ đừng quên lịch khám nhé ^_^";
        }

        bool khamThem = false;
        bool ClickAddPK = false;
        private void buttonCustom4_Click(object sender, EventArgs e)
        {

            ClickAddPK = true;
            Giap_AddPhieuKham();

        }



        int firtTime = 0;
        private void LK_TPK_Combo_Ngay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (firtTime < 4)
            {
                firtTime++;
            }
            if (firtTime <= 2)
            {
                return;
            }
            Giap_CheckCaHopLe();
            LoadThongTinTPK();
        }
        int firtTime_TPK_Phong = 0;
        private void LK_TPK_Combo_Phong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (firtTime_TPK_Phong < 4)
            {
                firtTime_TPK_Phong++;
            }
            if (firtTime_TPK_Phong <= 2)
            {
                return;
            }
            Giap_CheckCaHopLe();
            LoadThongTinTPK();
            Giap_LoadComboCa();
        }

        List<Guid> lstIdPhieuKham = new List<Guid>();
        void Giap_AddPhieuKham()
        {
            if (LK_TPK_Combo_Gio.Text == "")
            {
                MessageBox.Show($"Hãy chọn đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!ClickAddPK)
                {
                    return;
                }

                if (DialogResult.Yes == MessageBox.Show($"Bạn chắc chắn muốn thêm phiếu khám này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {

                    var phieuKhamSer = new PhieuKhamSer();
                    var pk = new PhieuKham();
                    pk.IdPhieuKham = Guid.NewGuid();
                    pk.IdBacSi = Guid.Parse(LK_TPK_ComBo_BacSi.SelectedValue.ToString());
                    pk.IdDichVu = Guid.Parse(LK_TPK_Combo_DichVu.SelectedValue.ToString());
                    pk.IdYTa = Guid.Parse(LK_TPK_Combo_YTa.SelectedValue.ToString());
                    pk.IdPhong = Guid.Parse(LK_TPK_Combo_Phong.SelectedValue.ToString());
                    pk.IdKhachHang = Guid.Parse(LK_TPK_Combo_KhachHang.SelectedValue.ToString());
                    //var idNgay = Convert.ToInt32(LK_TPK_Combo_Ngay.SelectedValue.ToString());
                    pk.ngayKham = DateTime.Parse(LK_TPK_Combo_Ngay.SelectedValue.ToString());
                    pk.HienThi = true;
                    pk.TrangThai = false;
                    var caKham = Convert.ToInt32(LK_TPK_Combo_Gio.Text);
                    pk.CaKham = caKham;

                    phieuKhamSer.AddPhieuKham(pk);

                    var TTNhanVienSer = new TTNhanVienSer();
                    DateTime ngayDuocChon;
                    ngayDuocChon = pk.ngayKham;

                    var ttBs = TTNhanVienSer.GetTTNhanVien().FirstOrDefault(a => a.IdNhanVien == pk.IdBacSi && a.Ngay.ToString("MM/dd/yyyy") == ngayDuocChon.ToString("MM/dd/yyyy"));

                    var arrTTBs = ttBs.TrangThai.Split("|");
                    arrTTBs[caKham - 1] = "true";
                    var ttBsMoi = String.Join("|", arrTTBs);
                    ttBs.TrangThai = ttBsMoi;
                    TTNhanVienSer.UpdateTTNhanVien(ttBs);

                    var ttYta = TTNhanVienSer.GetTTNhanVien().FirstOrDefault(a => a.IdNhanVien == pk.IdYTa && a.Ngay.ToString("MM/dd/yyyy") == ngayDuocChon.ToString("MM/dd/yyyy"));
                    var arrTTYTa = ttYta.TrangThai.Split("|");
                    arrTTYTa[caKham - 1] = "true";
                    var ttYTaMoi = String.Join("|", arrTTYTa);
                    ttYta.TrangThai = ttYTaMoi;
                    TTNhanVienSer.UpdateTTNhanVien(ttYta);


                    var TTPhongSer = new TTPhongSer();
                    var TTPhong = TTPhongSer.GetTTPhong().FirstOrDefault(a => a.IdPhong == pk.IdPhong && a.Ngay.ToString("MM/dd/yyyy") == ngayDuocChon.ToString("MM/dd/yyyy"));
                    var arrTTPhong = TTPhong.TrangThai.Split("|");
                    arrTTPhong[caKham - 1] = "true";
                    var ttPhongMoi = String.Join("|", arrTTPhong);
                    TTPhong.TrangThai = ttPhongMoi;
                    TTPhongSer.UpdateTTPhong(TTPhong);
                    Giap_LoadComboCa();

                    var lsKhamSer = new LichSuKhamService();
                    var lsKham = new LichSuKham();
                    lsKham.IdPhieuKham = pk.IdPhieuKham;
                    lsKham.GhiChu = "Wow bạn đã phát hiện 1 kiểu dữ liệu bị thừa :>";
                    lsKham.KetQua = "";
                    lsKhamSer.AddlichSuKham(lsKham);
                    lstIdPhieuKham.Add(pk.IdPhieuKham);

                    if (DialogResult.Yes == MessageBox.Show($"Đã thêm phiếu khám thành công ! Khách hàng có muốn dùng thêm dịch vụ khác không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        ClickAddPK = false;
                        khamThem = true;
                        lstIdPhieuKham.Add(pk.IdPhieuKham);
                        LK_TPK_Combo_KhachHang.Enabled = false;
                        Giap_AddPhieuKham();
                    }
                    else
                    {
                        khamThem = false;
                        LK_TPK_Combo_KhachHang.Enabled = true;
                        var hdSer = new HoaDonService();
                        var hd = new HoaDon();
                        hd.IdHoaDon = Guid.NewGuid();
                        hd.IdNhanVien = null;
                        hd.PhuPhi = 0;
                     //   hd.GhiChu = "";
                        hd.ThoiGian = null;
                        hd.idGiamGia = null;
                        var ggSer = new GiamGiaSer();
                        var gg = ggSer.GetGiamGiaGanNhat();
                        if (gg != null && gg.TrangThai == true)
                        {
                            hd.idGiamGia = gg.id;
                        }
                        hdSer.AddHoaDon(hd);
                        foreach (var item in lstIdPhieuKham)
                        {
                            var hdCt = new HoaDonChiTiet();
                            var hdCtSer = new HoaDonChiTietService();
                            hdCt.IdHoaDon = hd.IdHoaDon;
                            hdCt.IdPhieuKham = item;
                            hdCt.TrangThai = false;
                            hdCtSer.AddHDCT(hdCt);

                        }
                        MessageBox.Show("Ok hãy tiếp tục đặt lịch cho các khách hàng thân yêu đi nào!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        lstIdPhieuKham.Clear();

                    }
                }
            }
        }



        void Giap_LoadComboSHPK()
        {
            var khachHangSer = new KhachHangService();
            var bacSiSer = new NhanVienSer();
            var yTaSer = new NhanVienSer();
            var dichVuSer = new DichVuService();
            var ttPhongSer = new TrangThaiPhongSerVice();
            var phongSer = new PhongSer();

            var dataComboKh = khachHangSer.GetAllKhachHang().Select(a =>
            {
                return new
                {
                    id = a.IdKhachHang,
                    ten = a.Ten
                };
            }).ToList();


            var dataBacSi = bacSiSer.GetAllNhanVien().Where(b => b.ChucVu == LoaiNhanVien.BacSi).Select(a =>
            {
                return new
                {
                    id = a.IdNhanVien,
                    ten = a.Ten
                };
            }).ToList();

            var dataYta = yTaSer.GetAllNhanVien().Where(b => b.ChucVu == LoaiNhanVien.YTa).Select(a =>
            {
                return new
                {
                    id = a.IdNhanVien,
                    ten = a.Ten
                };
            }).ToList();

            var dataDichVu = dichVuSer.GetAllDichVu().Select(a =>
            {
                return new
                {
                    ten = a.Ten,
                    id = a.IdDichVu,
                };
            }).ToList();

            var phong = phongSer.GetAllPhong().FirstOrDefault(a => a.LoaiPhong == LoaiPhong.P406);

            var dataNgay = ttPhongSer.GetAllTrangThaiPhong().Where(a => DateTime.Parse(a.Ngay.ToString("MM/dd/yyyy")) >= DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) && a.IdPhong == phong.Id).Select(a =>
            {
                return new
                {
                    ngay = a.Ngay.ToString("MM/dd/yyyy"),
                };
            }).ToList();
            var dataPhong = phongSer.GetAllPhong().Select(a =>
            {
                return new
                {
                    id = a.Id,
                    ten = a.LoaiPhong,
                };
            }).ToList();


            SHPK_Combo_Kh.DataSource = dataComboKh;
            SHPK_Combo_BacSi.DataSource = dataBacSi;
            SHPK_Combo_Yta.DataSource = dataYta;

            SHPK_Combo_Kh.DisplayMember = "ten";
            SHPK_Combo_Kh.ValueMember = "id";

            SHPK_Combo_BacSi.DisplayMember = "ten";
            SHPK_Combo_BacSi.ValueMember = "id";

            SHPK_Combo_Yta.DisplayMember = "ten";
            SHPK_Combo_Yta.ValueMember = "id";


            SHPK_Combo_DV.DataSource = dataDichVu;
            SHPK_Combo_Ngay.DataSource = dataNgay;
            SHPK_Combo_Phong.DataSource = dataPhong;

            SHPK_Combo_DV.DisplayMember = "ten";
            SHPK_Combo_DV.ValueMember = "id";

            SHPK_Combo_Ngay.DisplayMember = "ngay";
            SHPK_Combo_Ngay.ValueMember = "ngay";

            SHPK_Combo_Phong.DisplayMember = "ten";
            SHPK_Combo_Phong.ValueMember = "id";
        }

        void SHPK_LoadGRrView(bool trangThaiKham, string txtSearch, DateTime? minTime, DateTime? maxTime)
        {
            var lichKhamSer = new PhieuKhamSer();
            var nhanVienSer = new NhanVienSer();
            var dichVuSer = new DichVuService();
            var khachHangSer = new KhachHangService();
            var phongSer = new PhongSer();
            var ttNhanVienSer = new TTNhanVienSer();
            var count = 1;

            var kqLichKham = lichKhamSer.GetAllPhieuKham().Where(s => s.TrangThai == trangThaiKham).Join(nhanVienSer.GetAllNhanVien(), a => a.IdBacSi, b => b.IdNhanVien, (c, d) =>
            {
                return new
                {
                    idPhieuKham = c.IdPhieuKham,
                    TenBacSi = d.Ten,
                    idYTa = c.IdYTa,
                    idKhachHang = c.IdKhachHang,
                    idDichVu = c.IdDichVu,
                    CaKham = c.CaKham,
                    idPhong = c.IdPhong,
                    ngayKham = c.ngayKham
                };
            }).Join(dichVuSer.GetAllDichVu(), a => a.idDichVu, b => b.IdDichVu, (c, d) =>
            {
                return new
                {
                    idPhieuKham = c.idPhieuKham,
                    TenBacSi = c.TenBacSi,
                    idYTa = c.idYTa,
                    idKhachHang = c.idKhachHang,
                    CaKham = c.CaKham,
                    idPhong = c.idPhong,
                    ngayKham = c.ngayKham,
                    tenDV = d.Ten,
                };
            }).Join(khachHangSer.GetAllKhachHang(), a => a.idKhachHang, b => b.IdKhachHang, (c, d) =>
            {
                return new
                {
                    idPhieuKham = c.idPhieuKham,
                    TenBacSi = c.TenBacSi,
                    idYTa = c.idYTa,
                    idPhong = c.idPhong,
                    ngayKham = c.ngayKham,
                    tenDV = c.tenDV,
                    CaKham = c.CaKham,
                    TenKH = d.Ten,
                };
            }).Join(nhanVienSer.GetAllNhanVien(), a => a.idYTa, b => b.IdNhanVien, (c, d) =>
            {
                return new
                {
                    idPhieuKham = c.idPhieuKham,
                    TenBacSi = c.TenBacSi,
                    idPhong = c.idPhong,
                    ngayKham = c.ngayKham,
                    tenDV = c.tenDV,
                    CaKham = c.CaKham,
                    TenKH = c.TenKH,
                    TenYta = d.Ten
                };
            }).Join(phongSer.GetAllPhong(), a => a.idPhong, b => b.Id, (c, d) =>
            {
                return new
                {
                    STT = count++,
                    idPhieuKham = c.idPhieuKham,
                    TenKH = c.TenKH,
                    TenBacSi = c.TenBacSi,
                    tenDV = c.tenDV,
                    ngayKham = c.ngayKham,
                };
            }).ToList();

            if (txtSearch != null && txtSearch != "")
            {
                kqLichKham = kqLichKham.Where(a => a.TenKH.ToLower().Contains(txtSearch.ToLower())).ToList();
            }
            if (minTime != null && maxTime != null)
            {
                kqLichKham = kqLichKham.Where(a => a.ngayKham >= minTime && a.ngayKham <= maxTime).ToList();
            }



            if (kqLichKham.Count() == 0)
            {
                SHPK_GrView.DataSource = null;
                SHPK_GrView.ColumnCount = 6;
                SHPK_GrView.Columns[0].HeaderText = "STT";
                SHPK_GrView.Columns[1].HeaderText = "Mã phiếu khám";
                SHPK_GrView.Columns[2].HeaderText = "Tên khách hàng";
                SHPK_GrView.Columns[3].HeaderText = "Tên bác sĩ";
                SHPK_GrView.Columns[4].HeaderText = "Tên dịch vụ";
                SHPK_GrView.Columns[5].Visible = false;
            }
            else
            {
                SHPK_GrView.Columns.Clear();
                SHPK_GrView.DataSource = kqLichKham;
                SHPK_GrView.Columns[0].HeaderText = "STT";
                SHPK_GrView.Columns[1].HeaderText = "Mã phiếu khám";
                SHPK_GrView.Columns[2].HeaderText = "Tên khách hàng";
                SHPK_GrView.Columns[3].HeaderText = "Tên dịch vụ";
                SHPK_GrView.Columns[4].HeaderText = "Tên bác sĩ";
                SHPK_GrView.Columns[5].Visible = false;
            }
        }


        private void SHPK_Btn_TimKiem_Click(object sender, EventArgs e)
        {
            SHPK_LoadGRrView(false, SHPK_Txt_TimKiem.Text, SHPK_Date_Min.Value, SHPK_Date_Max.Value);
        }

        void SHPK_LoadCa()
        {
            var TTNhanVienSer = new TTNhanVienSer();
            DateTime ngayDuocChon;
            if (PhieuKhamDuocChon == null)
            {
                return;
            }
            ngayDuocChon = DateTime.Parse(SHPK_Combo_Ngay.SelectedValue.ToString());

            var TTYta = TTNhanVienSer.GetTTNhanVien().FirstOrDefault(a => a.Ngay.ToString("MM/dd/yyyy") == ngayDuocChon.ToString("MM/dd/yyyy") && a.IdNhanVien == Guid.Parse(SHPK_Combo_Yta.SelectedValue.ToString()));

            List<int> lstcaTrongYTa = new List<int>();
            if (TTYta != null)
            {
                int countYTa = 1;
                foreach (var t in TTYta.TrangThai.Split("|"))
                {
                    if (t == "false")
                    {
                        lstcaTrongYTa.Add(countYTa);
                    }
                    countYTa++;
                }
            }


            var TTBSi = TTNhanVienSer.GetTTNhanVien().FirstOrDefault(a => a.Ngay.ToString("MM/dd/yyyy") == ngayDuocChon.ToString("MM/dd/yyyy") && a.IdNhanVien == Guid.Parse(SHPK_Combo_BacSi.SelectedValue.ToString()));
            List<int> lstcaTrongBSi = new List<int>();
            if (TTBSi != null)
            {
                int countBSi = 1;
                foreach (var t in TTBSi.TrangThai.Split("|"))
                {
                    if (t == "false")
                    {
                        lstcaTrongBSi.Add(countBSi);
                    }
                    countBSi++;
                }
            }
            var ttPhongSer = new TTPhongSer();

            var TTPhong = ttPhongSer.GetTTPhong().FirstOrDefault(a => a.Ngay.ToString("MM/dd/yyyy") == ngayDuocChon.ToString("MM/dd/yyyy") && a.IdPhong == Guid.Parse(SHPK_Combo_Phong.SelectedValue.ToString()));
            List<int> lstcaPhongTrong = new List<int>();
            if (TTPhong != null)
            {
                int countPhong = 1;
                foreach (var t in TTPhong.TrangThai.Split("|"))
                {
                    if (t == "false")
                    {
                        lstcaPhongTrong.Add(countPhong);
                    }
                    countPhong++;
                }
            }


            var lstCaTrong = new List<int>();
            lstCaTrong = lstcaTrongYTa.Intersect(lstcaTrongBSi).Intersect(lstcaPhongTrong).ToList();
            lstCaTrong.Add(PhieuKhamDuocChon.CaKham);

            if (ngayDuocChon.ToString("MM/dd/yyyy") == DateTime.Now.ToString("MM/dd/yyyy"))
            {
                var gioTrongNgay = Convert.ToInt32(DateTime.Now.ToString("hh"));
                if (DateTime.Now.ToString("tt") == "AM")
                {
                    if (gioTrongNgay >= 8)
                    {
                        var obj = lstCaTrong.Any(a => a == 1);
                        if (obj)
                        {
                            lstCaTrong.Remove(1);
                        }
                    }
                    if (gioTrongNgay >= 9)
                    {
                        var obj = lstCaTrong.Any(a => a == 2);
                        if (obj)
                        {
                            lstCaTrong.Remove(2);
                        }
                    }
                    if (gioTrongNgay >= 10)
                    {
                        var obj = lstCaTrong.Any(a => a == 3);
                        if (obj)
                        {
                            lstCaTrong.Remove(3);
                        }
                    }
                    if (gioTrongNgay >= 11)
                    {
                        var obj = lstCaTrong.Any(a => a == 4);
                        if (obj)
                        {
                            lstCaTrong.Remove(4);
                        }
                    }
                }
                if (DateTime.Now.ToString("tt") == "PM")
                {
                    lstCaTrong.Remove(1);
                    lstCaTrong.Remove(2);
                    lstCaTrong.Remove(3);
                    lstCaTrong.Remove(4);
                    if (gioTrongNgay >= 2)
                    {
                        var obj = lstCaTrong.Any(a => a == 5);
                        if (obj)
                        {
                            lstCaTrong.Remove(5);
                        }
                    }
                    if (gioTrongNgay >= 3)
                    {
                        var obj = lstCaTrong.Any(a => a == 6);
                        if (obj)
                        {
                            lstCaTrong.Remove(6);
                        }
                    }
                    if (gioTrongNgay >= 4)
                    {
                        var obj = lstCaTrong.Any(a => a == 7);
                        if (obj)
                        {
                            lstCaTrong.Remove(7);
                        }
                    }
                    if (gioTrongNgay >= 5)
                    {
                        var obj = lstCaTrong.Any(a => a == 8);
                        if (obj)
                        {
                            lstCaTrong.Remove(8);
                        }
                    }
                }
            }
            lstCaTrong.Sort();
            SHPK_Combo_Ca.DataSource = lstCaTrong;

        }

        private void SHPK_Btn_Loc_Click(object sender, EventArgs e)
        {
            SHPK_LoadGRrView(false, SHPK_Txt_TimKiem.Text, SHPK_Date_Min.Value, SHPK_Date_Max.Value);
        }

        private void SHPK_GrView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > SHPK_GrView.Rows.Count)
            {
                return;
            }
            int rowIndex = e.RowIndex;
            if (SHPK_GrView.Rows[rowIndex].Cells[1].Value == null)
            {
                return;
            }
            var ttNVSer = new TTNhanVienSer();
            var ttPhongSer = new TTPhongSer();
            var PkSer = new PhieuKhamSer();
            PhieuKhamDuocChon = PkSer.FindPhieuKham(Guid.Parse(SHPK_GrView.Rows[rowIndex].Cells[1].Value.ToString()));

            SHPK_Combo_Kh.Enabled = false;

            SHPK_Combo_BacSi.SelectedValue = PhieuKhamDuocChon.IdBacSi;
            SHPK_Combo_Yta.SelectedValue = PhieuKhamDuocChon.IdYTa;
            SHPK_Combo_DV.SelectedValue = PhieuKhamDuocChon.IdDichVu;
            SHPK_Combo_Kh.SelectedValue = PhieuKhamDuocChon.IdKhachHang;
            SHPK_Combo_Phong.SelectedValue = PhieuKhamDuocChon.IdPhong;
            SHPK_Combo_Ngay.SelectedValue = PhieuKhamDuocChon.ngayKham.ToString("MM/dd/yyyy");

            SHPK_LoadCa();
            SHPK_Combo_Ca.SelectedItem = PhieuKhamDuocChon.CaKham;
        }


        private void SHPK_Btn_Sua_Click(object sender, EventArgs e)
        {
            var phieuKhamSer = new PhieuKhamSer();
            if (PhieuKhamDuocChon == null)
            {
                MessageBox.Show($"Chưa chọn phiếu khám", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var result = MessageBox.Show("Xác nhận sửa phiếu khám?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    //update mới
                    UpDateCa();

                    PhieuKhamDuocChon.IdBacSi = Guid.Parse(SHPK_Combo_BacSi.SelectedValue.ToString());
                    PhieuKhamDuocChon.IdYTa = Guid.Parse(SHPK_Combo_Yta.SelectedValue.ToString());
                    PhieuKhamDuocChon.IdDichVu = Guid.Parse(SHPK_Combo_DV.SelectedValue.ToString());
                    PhieuKhamDuocChon.IdKhachHang = Guid.Parse(SHPK_Combo_Kh.SelectedValue.ToString());
                    PhieuKhamDuocChon.IdPhong = Guid.Parse(SHPK_Combo_Phong.SelectedValue.ToString());
                    PhieuKhamDuocChon.ngayKham = DateTime.Parse(SHPK_Combo_Ngay.SelectedValue.ToString());
                    PhieuKhamDuocChon.CaKham = int.Parse(SHPK_Combo_Ca.SelectedValue.ToString());


                    var TTNhanVienSer = new TTNhanVienSer();
                    DateTime ngayDuocChon;
                    ngayDuocChon = PhieuKhamDuocChon.ngayKham;



                    var TTPhongSer = new TTPhongSer();
                    var caKham = PhieuKhamDuocChon.CaKham;
                    var ttBs = TTNhanVienSer.GetTTNhanVien().FirstOrDefault(a => a.IdNhanVien == PhieuKhamDuocChon.IdBacSi && a.Ngay.ToString("MM/dd/yyyy") == ngayDuocChon.ToString("MM/dd/yyyy"));

                    var arrTTBs = ttBs.TrangThai.Split("|");
                    arrTTBs[caKham - 1] = "true";
                    var ttBsMoi = String.Join("|", arrTTBs);
                    ttBs.TrangThai = ttBsMoi;
                    TTNhanVienSer.UpdateTTNhanVien(ttBs);

                    var ttYta = TTNhanVienSer.GetTTNhanVien().FirstOrDefault(a => a.IdNhanVien == PhieuKhamDuocChon.IdYTa && a.Ngay.ToString("MM/dd/yyyy") == ngayDuocChon.ToString("MM/dd/yyyy"));
                    var arrTTYTa = ttYta.TrangThai.Split("|");
                    arrTTYTa[caKham - 1] = "true";
                    var ttYTaMoi = String.Join("|", arrTTYTa);
                    ttYta.TrangThai = ttYTaMoi;
                    TTNhanVienSer.UpdateTTNhanVien(ttYta);


                    var TTPhong = TTPhongSer.GetTTPhong().FirstOrDefault(a => a.IdPhong == PhieuKhamDuocChon.IdPhong && a.Ngay.ToString("MM/dd/yyyy") == ngayDuocChon.ToString("MM/dd/yyyy"));
                    var arrTTPhong = TTPhong.TrangThai.Split("|");
                    arrTTPhong[caKham - 1] = "true";
                    var ttPhongMoi = String.Join("|", arrTTPhong);
                    TTPhong.TrangThai = ttPhongMoi;
                    TTPhongSer.UpdateTTPhong(TTPhong);


                    SHPK_LoadCa();
                    phieuKhamSer.UpdatePhieuKham(PhieuKhamDuocChon);
                    SHPK_LoadGRrView(false, "", null, null);

                    MessageBox.Show($"Sửa thông tin phiếu khám thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        void UpDateCa()
        {
            var idbs = PhieuKhamDuocChon.IdBacSi;
            var idyta = PhieuKhamDuocChon.IdYTa;
            var ngayGoc = PhieuKhamDuocChon.ngayKham;
            var idphong = PhieuKhamDuocChon.IdPhong;
            var caKhamGoc = PhieuKhamDuocChon.CaKham;


            var TTNhanVienSer = new TTNhanVienSer();
            var TTPhongSer = new TTPhongSer();
            //update mới
            var caKham = caKhamGoc;
            var ttBs = TTNhanVienSer.GetTTNhanVien().FirstOrDefault(a => a.IdNhanVien == idbs && a.Ngay.ToString("MM/dd/yyyy") == ngayGoc.ToString("MM/dd/yyyy"));

            var arrTTBs = ttBs.TrangThai.Split("|");
            arrTTBs[caKham - 1] = "false";
            var ttBsMoi = String.Join("|", arrTTBs);
            ttBs.TrangThai = ttBsMoi;
            TTNhanVienSer.UpdateTTNhanVien(ttBs);

            var ttYta = TTNhanVienSer.GetTTNhanVien().FirstOrDefault(a => a.IdNhanVien == idyta && a.Ngay.ToString("MM/dd/yyyy") == ngayGoc.ToString("MM/dd/yyyy"));
            var arrTTYTa = ttYta.TrangThai.Split("|");
            arrTTYTa[caKham - 1] = "false";
            var ttYTaMoi = String.Join("|", arrTTYTa);
            ttYta.TrangThai = ttYTaMoi;
            TTNhanVienSer.UpdateTTNhanVien(ttYta);


            var TTPhong = TTPhongSer.GetTTPhong().FirstOrDefault(a => a.IdPhong == idphong && a.Ngay.ToString("MM/dd/yyyy") == ngayGoc.ToString("MM/dd/yyyy"));
            var arrTTPhong = TTPhong.TrangThai.Split("|");
            arrTTPhong[caKham - 1] = "false";
            var ttPhongMoi = String.Join("|", arrTTPhong);
            TTPhong.TrangThai = ttPhongMoi;
            TTPhongSer.UpdateTTPhong(TTPhong);

        }

        private void SHPK_Btn_An_Click(object sender, EventArgs e)
        {
            var phieuKhamSer = new PhieuKhamSer();
            if (PhieuKhamDuocChon == null)
            {
                MessageBox.Show($"Chưa chọn phiếu khám", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var result = MessageBox.Show("Xác nhận hủy phiếu khám?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    UpDateCa();

                    var PkSer = new PhieuKhamSer();
                    PhieuKhamDuocChon.HienThi = false;
                    PkSer.UpdatePhieuKham(PhieuKhamDuocChon);
                    MessageBox.Show($"Hủy phiếu khám thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SHPK_LoadGRrView(false, "", null, null);

                }
            }
        }

        void L_LoadLuong()
        {
            var nvSer = new NhanVienSer();
            var luongSer = new LuongSer();

            var resultSearch = nvSer.GetAllNhanVien().Where(a => a.IdNhanVien == user.IdNhanVien).Join(luongSer.GetAllLuong().Where(v => v.ThoiGian.Value.ToString("MM/yyyy") == DateTime.Now.ToString("MM/yyyy")), a => a.IdNhanVien,
                b => b.IdNhanVien, (c, d) =>
                {
                    return new
                    {
                        idLuong = d.IdLuong,
                        Ten = c.Ten,
                        SoCong = d.SoCong,
                        Thuong = d.Thuong,
                        TrangThai = d.TrangThai,
                        VaiTro = c.ChucVu,
                    };
                });
            var result = resultSearch.FirstOrDefault();
            if (result != null)
            {
                L_LuongDuocChon = luongSer.FindLuong(result.idLuong);

                L_Txt_Ten.Text = result.Ten;
                L_Txt_SoCong.Text = result.SoCong.ToString();
                L_Txt_TG.Text = $"Lương tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";
                L_Txt_thuong.Text = $"{Convert.ToDouble(result.Thuong).ToString("0,000")} VNĐ";
                //thuế

                double heSoLuong = 300000;
                if (result.VaiTro == LoaiNhanVien.BacSi)
                {
                    heSoLuong = 500000;
                }
                var luong = Convert.ToDouble(heSoLuong * result.SoCong + result.Thuong);

                var tienThue = Thue(luong);


                L_Txt_Tongluong.Text = $"{luong.ToString("0,000")} VNĐ";
            }
            else
            {
                L_Txt_TG.Text = "Bạn chưa thực hiện chấm công tháng này!";
                L_Txt_Ten.Text = "";
                L_Txt_SoCong.Text = "0";
               // L_txt_Thue.Text = "0 VNĐ";
                L_Txt_Tongluong.Text = "0 VNĐ";
                //L_Btn_Sua.Visible = false;
                //L_Btn_XacNhan.Visible = false;
                //L_Btn_OKSua.Visible = false;
            }

        }

        double Thue(double luong)
        {
            var phanLuongTinhThue = luong - 11000000;
            double tienThue = 0;

            if (phanLuongTinhThue > 18000000)
            {
                tienThue += (phanLuongTinhThue - 18000000) / 20;
                phanLuongTinhThue = 18000000;
            }
            if (phanLuongTinhThue > 10000000)
            {
                tienThue += (phanLuongTinhThue - 10000000) / 100 * 15;
                phanLuongTinhThue = 10000000;
            }
            if (phanLuongTinhThue > 5000000)
            {
                tienThue += (phanLuongTinhThue - 5000000) / 10;
                phanLuongTinhThue = 5000000;
            }
            if (phanLuongTinhThue > 0)
            {
                tienThue += phanLuongTinhThue / 100 * 5;

            }
            return tienThue;
        }












        private void NV_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LK_TPK_Combo_Gio_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void LK_TPK_Combo_Gio_TextChanged(object sender, EventArgs e)
        {
            LoadThongTinTPK();

        }
        int ft_BS = 0;
        private void SHPK_Combo_BacSi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ft_BS < 4)
            {
                ft_BS++;
            }
            if (ft_BS <= 2)
            {
                return;
            }
            SHPK_LoadCa();
        }


        private void SHPK_Combo_Kh_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  SHPK_LoadCa();

        }

        int ft_YTa = 0;
        private void SHPK_Combo_Yta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ft_YTa < 4)
            {
                ft_YTa++;
            }
            if (ft_YTa <= 2)
            {
                return;
            }
            SHPK_LoadCa();
        }

        private void SHPK_Combo_DV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int ft_ngay = 0;
        private void SHPK_Combo_Ngay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ft_ngay < 4)
            {
                ft_ngay++;
            }
            if (ft_ngay <= 2)
            {
                return;
            }
            SHPK_LoadCa();
        }

        int ft_phong = 0;
        private void SHPK_Combo_Phong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ft_phong < 4)
            {
                ft_phong++;
            }
            if (ft_phong <= 2)
            {
                return;
            }
            SHPK_LoadCa();
        }

        private void SHPK_Combo_Ca_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SHPK_LoadCa();
        }

        private void Panel_TK_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TKhoan_Btn_Update_Click(object sender, EventArgs e)
        {
            TK_combo.Enabled = true;
            TK_Sep.Visible = true;
            TK_txt_Ten.Enabled = true;
            TK_Sep.Size = new Size(TK_txt_Ten.Width, TK_Sep.Height);
            TKhoan_txt_DiaChi.Enabled = true;
            TKhoan_txt_pwd.Enabled = true;
            TKhoan_txt_SDT.Enabled = true;
            TKhoan_Btn_ok.Visible = true;
        }

        private void TKhoan_Btn_ok_Click(object sender, EventArgs e)
        {
            var nvSer = new NhanVienSer();
            var nv = nvSer.FindNhanVien(user.IdNhanVien);
            if (nv != null)
            {
                if (Giap_CheckTrong(TK_txt_Ten.Text) || Giap_CheckTrong(TKhoan_txt_DiaChi.Text) || Giap_CheckTrong(TKhoan_txt_SDT.Text) || Giap_CheckTrong(TKhoan_txt_pwd.Text))
                {
                    MessageBox.Show($"Không được bỏ trống các ô thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!Regex.IsMatch(TKhoan_txt_SDT.Text, "^0[0-9]{9}$"))
                {
                    MessageBox.Show($"Nhập đúng định dạng số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (nvSer.GetTatCaVien().Any(a => a.SoDienThoai == TKhoan_txt_SDT.Text && nv.IdNhanVien != a.IdNhanVien))
                {
                    MessageBox.Show($"Số điện thoại đã tồn tại,hãy thêm số điện thoại khác !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var option = MessageBox.Show("Xác nhận có muốn sửa!", "Thông báo!", MessageBoxButtons.YesNoCancel);
                    if (option == DialogResult.Yes)
                    {
                        nv.Ten = TK_txt_Ten.Text;
                        nv.DiaChi = TKhoan_txt_DiaChi.Text;
                        nv.MatKhau = TKhoan_txt_pwd.Text;
                        nv.SoDienThoai = TKhoan_txt_SDT.Text;
                        var gioiTinh = true;
                        if (TK_combo.Text == "Nữ")
                        {
                            gioiTinh = false;
                        }
                        nv.GioiTinh = gioiTinh;
                        nvSer.UpdateNhanVien(nv);
                        MessageBox.Show($"Đã sửa thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TK_combo.Enabled = false;
                        TK_Sep.Visible = false;
                        TK_txt_Ten.Enabled = false;
                        TKhoan_txt_DiaChi.Enabled = false;
                        TKhoan_txt_pwd.Enabled = false;
                        TKhoan_txt_SDT.Enabled = false;
                        TKhoan_Btn_ok.Visible = false;
                    }

                }
            }
        }

        private void ShowThongTin()
        {
            var nvSer = new NhanVienSer();
            var a = nvSer.FindNhanVien(user.IdNhanVien);

            string gt = "Nữ";
            if (a.GioiTinh == true)
            {
                gt = "Nam";
            }

            var ChucVu = "Bác Sĩ";
            if (a.ChucVu == LoaiNhanVien.YTa)
            {
                ChucVu = "Y Tá";
            }

            TK_combo.Text = gt;

            TKhoan_lbl_ChucVu.Text = ChucVu;
            TKhoan_txt_SDT.Text = a.SoDienThoai != null ? user.SoDienThoai.ToString() : "null";
            TKhoan_txt_DiaChi.Text = a.DiaChi != null ? user.DiaChi.ToString() : "null";
            TKhoan_txt_pwd.Text = a.MatKhau != null ? user.MatKhau.ToString() : "null";
            TK_txt_Ten.Text = a.Ten;


        }

        private void QL_DangXuat_Click(object sender, EventArgs e)
        {
            var option = MessageBox.Show("Xác nhận có muốn đăng xuất không!", "Thông báo!", MessageBoxButtons.YesNoCancel);
            if (option == DialogResult.Yes)
            {
                this.Close();
                FormLogin.RememberStatus = false;
                FormLogin.Visible = true;
                FormLogin.Show();
                using (var fs = new FileStream("remember_account.txt", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    var stringInfo = $"{user.SoDienThoai}|{user.MatKhau}|false";
                    var bf = new BinaryFormatter();
                    bf.Serialize(fs, stringInfo);
                }

            }
        }

        private void QL_Thoat_Click(object sender, EventArgs e)
        {
            var option = MessageBox.Show("Xác nhận có muốn thoát không!", "Thông báo!", MessageBoxButtons.YesNoCancel);
            if (option == DialogResult.Yes)
            {
                this.Close();
                FormLogin.Close();
            }
        }



        private void ThongKe_Txt_TongDoanhThu_Click(object sender, EventArgs e)
        {

        }

        private void Nav_Option_Paint(object sender, PaintEventArgs e)
        {

        }

        private void QL_KQ_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_KQ.Visible = true;
            Content.Controls.Add(Panel_KQ);
            LoadCaKhamBS();
            changeColor(QL_KQ);
        }

        void LoadCaKhamBS()
        {
            KQ_Panel_DSCK.Controls.Clear();
            var pkSer = new PhieuKhamSer();
            IEnumerable<PhieuKham> lstPk;
            if (user.ChucVu == LoaiNhanVien.BacSi)
            {
                 lstPk = pkSer.GetAllPhieuKham().OrderByDescending(a => a.ngayKham).Reverse().Where(a => a.IdBacSi == user.IdNhanVien  && a.TrangThai == false && DateTime.Parse(a.ngayKham.ToString("MM/dd/yyyy")) >= DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")));
            }
            else
            {
                 lstPk = pkSer.GetAllPhieuKham().OrderByDescending(a => a.ngayKham).Reverse().Where(a => a.IdYTa == user.IdNhanVien && a.TrangThai == false && DateTime.Parse(a.ngayKham.ToString("MM/dd/yyyy")) >= DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")));

            }
            var countGrBoxY = 0;

            foreach (var item in lstPk)
            {
                var tenKH = new KhachHangService().FindKhachHang(item.IdKhachHang).Ten;
                var tenYTa = new NhanVienSer().FindNhanVien(Guid.Parse(item.IdYTa.ToString())).Ten;
                var tenDv = new DichVuService().GetAllDichVu().FirstOrDefault(a => a.IdDichVu == item.IdDichVu).Ten;
                var ca = item.CaKham.ToString();
                var phong = new PhongSer().GetAllPhong().FirstOrDefault(a => a.Id == item.IdPhong).LoaiPhong.ToString();
                var ngay = item.ngayKham.ToString("dd/MM/yyyy");
                var tenBS = new NhanVienSer().FindNhanVien(Guid.Parse(item.IdBacSi.ToString())).Ten;

                var thunderGroupBox1 = new ThunderGroupBox();
                var KQ_panel1_1 = new System.Windows.Forms.Panel();
                var KQ_Panel2_1 = new System.Windows.Forms.Panel();
                var KQ_Panel2_RichText1 = new RichTextBoxEdit();


                var KQ_panel1_TraKQ_1 = new ButtonCustom();
                KQ_panel1_TraKQ_1.BackColor = Color.Pink;
                KQ_panel1_TraKQ_1.BackgroundColor = Color.Pink;
                KQ_panel1_TraKQ_1.BorderColor = Color.White;
                KQ_panel1_TraKQ_1.BorderRadius = 20;
                KQ_panel1_TraKQ_1.BorderSize = 2;
                KQ_panel1_TraKQ_1.FlatAppearance.BorderSize = 0;
                KQ_panel1_TraKQ_1.FlatStyle = FlatStyle.Flat;
                KQ_panel1_TraKQ_1.ForeColor = Color.Crimson;
                KQ_panel1_TraKQ_1.IDSelected = item.IdPhieuKham.ToString();
                KQ_panel1_TraKQ_1.Location = new Point(785, 140);
                KQ_panel1_TraKQ_1.Name = "KQ_panel1_TraKQ_1";
                KQ_panel1_TraKQ_1.Size = new Size(188, 50);
                KQ_panel1_TraKQ_1.panel1 = KQ_panel1_1;
                KQ_panel1_TraKQ_1.panel2 = KQ_Panel2_1;
                KQ_panel1_TraKQ_1.thunderGroup = thunderGroupBox1;
                KQ_panel1_TraKQ_1.TabIndex = 1;
                KQ_panel1_TraKQ_1.Text = "Trả kết quả";
                KQ_panel1_TraKQ_1.TextColor = Color.Crimson;
                KQ_panel1_TraKQ_1.UseVisualStyleBackColor = false;
                KQ_panel1_TraKQ_1.Click += KQ_panel1_TraKQ_1_Click;


                var KQ_panel1_ThongTin_1 = new Label();
                KQ_panel1_ThongTin_1.AutoSize = true;
                KQ_panel1_ThongTin_1.Location = new Point(26, 19);
                KQ_panel1_ThongTin_1.Name = "KQ_panel1_ThongTin_1";
                KQ_panel1_ThongTin_1.Size = new Size(120, 300);
                KQ_panel1_ThongTin_1.TabIndex = 0;
                KQ_panel1_ThongTin_1.Text = $"Khách hàng : {tenKH}\n\nDịch vụ : {tenDv}\n\nBác sĩ : {tenBS}\n\nY tá : {tenYTa}\n\nPhòng : {phong}\n\nCa : {ca}";

                KQ_panel1_1.Controls.Add(KQ_panel1_TraKQ_1);
                KQ_panel1_1.Controls.Add(KQ_panel1_ThongTin_1);
                KQ_panel1_1.Location = new Point(13, 38);
                KQ_panel1_1.Name = "KQ_panel1_1";
                KQ_panel1_1.Size = new Size(999, 330);
                KQ_panel1_1.TabIndex = 0;


                var KQ_Panel2_Huy1 = new ButtonCustom();
                KQ_Panel2_Huy1.BackColor = Color.Red;
                KQ_Panel2_Huy1.BackgroundColor = Color.Red;
                KQ_Panel2_Huy1.BorderColor = Color.White;
                KQ_Panel2_Huy1.BorderRadius = 20;
                KQ_Panel2_Huy1.BorderSize = 3;
                KQ_Panel2_Huy1.FlatAppearance.BorderSize = 0;
                KQ_Panel2_Huy1.FlatStyle = FlatStyle.Flat;
                KQ_Panel2_Huy1.ForeColor = Color.White;
                KQ_Panel2_Huy1.IDSelected = null;
                KQ_Panel2_Huy1.Location = new Point(779, 191);
                KQ_Panel2_Huy1.Name = "KQ_Panel2_Huy1";
                KQ_Panel2_Huy1.Size = new Size(193, 55);
                KQ_Panel2_Huy1.panel1 = KQ_panel1_1;
                KQ_Panel2_Huy1.panel2 = KQ_Panel2_1;
                KQ_Panel2_Huy1.thunderGroup = thunderGroupBox1;
                KQ_Panel2_Huy1.TabIndex = 2;
                KQ_Panel2_Huy1.Text = "Hủy";
                KQ_Panel2_Huy1.TextColor = Color.White;
                KQ_Panel2_Huy1.UseVisualStyleBackColor = false;
                KQ_Panel2_Huy1.Click += KQ_Panel2_Huy1_Click;


                var KQ_Panel2_XacNhan1 = new ButtonCustom();
                KQ_Panel2_XacNhan1.BackColor = Color.DarkOrange;
                KQ_Panel2_XacNhan1.BackgroundColor = Color.DarkOrange;
                KQ_Panel2_XacNhan1.BorderColor = Color.White;
                KQ_Panel2_XacNhan1.BorderRadius = 20;
                KQ_Panel2_XacNhan1.BorderSize = 3;
                KQ_Panel2_XacNhan1.FlatAppearance.BorderSize = 0;
                KQ_Panel2_XacNhan1.FlatStyle = FlatStyle.Flat;
                KQ_Panel2_XacNhan1.ForeColor = Color.White;
                KQ_Panel2_XacNhan1.IDSelected = item.IdPhieuKham.ToString();
                KQ_Panel2_XacNhan1.Location = new Point(781, 90);
                KQ_Panel2_XacNhan1.Name = "KQ_Panel2_XacNhan1";
                KQ_Panel2_XacNhan1.Size = new Size(188, 56);
                KQ_Panel2_XacNhan1.TabIndex = 1;
                KQ_Panel2_XacNhan1.richText = KQ_Panel2_RichText1;
                KQ_Panel2_XacNhan1.Text = "Xác nhận trả";
                KQ_Panel2_XacNhan1.TextColor = Color.White;
                KQ_Panel2_XacNhan1.UseVisualStyleBackColor = false;
                KQ_Panel2_XacNhan1.Click += KQ_Panel2_XacNhan1_Click;


                KQ_Panel2_RichText1.AutoWordSelection = false;
                KQ_Panel2_RichText1.BackColor = Color.Transparent;
                KQ_Panel2_RichText1.BaseColor = Color.Transparent;
                KQ_Panel2_RichText1.BorderColor = Color.FromArgb(180, 180, 180);
                KQ_Panel2_RichText1.EdgeColor = Color.White;
                KQ_Panel2_RichText1.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
                KQ_Panel2_RichText1.ForeColor = Color.DimGray;
                KQ_Panel2_RichText1.Location = new Point(20, 17);
                KQ_Panel2_RichText1.Name = "KQ_Panel2_RichText1";
                KQ_Panel2_RichText1.ReadOnly = false;
                KQ_Panel2_RichText1.Size = new Size(725, 289);
                KQ_Panel2_RichText1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                KQ_Panel2_RichText1.TabIndex = 0;
                KQ_Panel2_RichText1.Text = "";
                KQ_Panel2_RichText1.TextBackColor = Color.White;
                KQ_Panel2_RichText1.TextBorderStyle = BorderStyle.None;
                KQ_Panel2_RichText1.TextFont = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
                KQ_Panel2_RichText1.WordWrap = true;

                KQ_Panel2_1.Controls.Add(KQ_Panel2_Huy1);
                KQ_Panel2_1.Controls.Add(KQ_Panel2_XacNhan1);
                KQ_Panel2_1.Controls.Add(KQ_Panel2_RichText1);
                KQ_Panel2_1.Location = new Point(27, 43);
                KQ_Panel2_1.Name = "KQ_Panel2_1";
                KQ_Panel2_1.Size = new Size(979, 319);
                KQ_Panel2_1.TabIndex = 0;




                thunderGroupBox1.BackColor = Color.Transparent;
                thunderGroupBox1.BodyColorA = Color.FromArgb(192, 255, 192);
                thunderGroupBox1.BodyColorB = Color.Snow;
                thunderGroupBox1.BodyColorC = Color.DeepSkyBlue;
                thunderGroupBox1.BodyColorD = Color.FromArgb(192, 255, 255);
                thunderGroupBox1.Controls.Add(KQ_panel1_1);
                thunderGroupBox1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
                thunderGroupBox1.ForeColor = Color.Black;
                thunderGroupBox1.Location = new Point(17, 23 + countGrBoxY);
                thunderGroupBox1.Name = "thunderGroupBox1";
                thunderGroupBox1.Size = new Size(1031, 385);
                thunderGroupBox1.Text = $"{ngay}";

                KQ_Panel_DSCK.Controls.Add(thunderGroupBox1);


                countGrBoxY += 485;

            }
        }
        private void KQ_panel1_TraKQ_1_Click(object sender, EventArgs e)
        {
            var btn = sender as ButtonCustom;
            btn.thunderGroup.Controls.Clear();
            btn.thunderGroup.Controls.Add(btn.panel2);


        }

        private void KQ_Panel2_XacNhan1_Click(object sender, EventArgs e)
        {
            var btn = sender as ButtonCustom;
            var hdctSer = new HoaDonChiTietService();
            var pkSer = new PhieuKhamSer();
            var lsKhamSer = new LichSuKhamService();

            var pk = pkSer.FindPhieuKham(Guid.Parse(btn.IDSelected));
            var hdct = hdctSer.FindHoaPhieuKham(Guid.Parse(btn.IDSelected));
            hdct.HienThi = true;
            pk.TrangThai = true;
            pkSer.UpdatePhieuKham(pk);
            hdctSer.UpdateHDCT(hdct);
            var lsKham = lsKhamSer.FindLichSuKham(Guid.Parse(btn.IDSelected));
            lsKham.KetQua = btn.richText.Text;
            lsKhamSer.UpdatelichSuKham(lsKham);
            var kh = new KhachHangService().FindKhachHang(pk.IdKhachHang);
            var dv = new DichVuService().GetAllDichVu().FirstOrDefault(a => a.IdDichVu == pk.IdDichVu);
            MessageBox.Show("Đã trả kết quả cho khách hàng thành công , vào thư mục KQ để xem !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            using (var fs = new FileStream($@"C:\\KQ\\{kh.Ten}___{btn.IDSelected}Result.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                var stream = new StreamWriter(fs);
                stream.WriteLine($"1412 SUGERRY\r\n\r\nPHÒNG KHÁM NHA KHOA 1412\r\n\r\nCỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆTNAM\r\n\r\nĐộc lập - Tự do - Hạnh phúc\r\n\r\n \r\n\r\n\r\nHà Nội, ngày {DateTime.Now.Day.ToString()} tháng {DateTime.Now.Month.ToString()} năm {DateTime.Now.Year.ToString()}\r\n\r\n  \r\n\r\nTHÔNG BÁO\r\n\r\nVề việc trả kết quả và tư vấn sau khám tại phòng khám 1412 của nhân viên {user.Ten}\r\n\r\n \r\n\r\nKính gửi : {kh.Ten}\r\n\r\n \r\n\r\nPhòng khám 1412 xin thông báo trả kết quả và tư vấn sau " +
                $"khi sử dụng dịch vụ {dv.Ten} như sau:\r\n\r\nThời gian: Ngày {pk.ngayKham.ToString("dd/MM/yyyy")}\r\n\nTại ca khám : {pk.CaKham}\r\n\nĐịa điểm : Tại Phòng 406 Tòa nhà P cơ sở Kiều Mai\r\n\nKết quả : {lsKham.KetQua} \r\n\r\nTrân trọng thông báo!");
                stream.Flush();
            }
            pk.TrangThai = true;
            pkSer.UpdatePhieuKham(pk);
            LoadCaKhamBS();
        }

        private void KQ_Panel2_Huy1_Click(object sender, EventArgs e)
        {
            var btn = sender as ButtonCustom;
            btn.thunderGroup.Controls.Clear();
            btn.thunderGroup.Controls.Add(btn.panel1);
        }

        private void bigLabel12_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Content.Controls.Add(Panel_ManHinhCho);
        }
    }
}


