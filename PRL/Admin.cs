using A_DAL.Models;
using A_DAL.Repositories;
using B_BUS.IServices;
using B_BUS.Services;
using DAL.DBContext;
using DAL.Enums;
using DAL.Models;
using PRL.Tool;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class Admin : Form
    {
        Label currentSelectedMethod;
        Label previousSelectedMethod;
        KhachHangService phong_khachhangsv;
        NhanVienSer Tho_nvService;
        private Guid iWhenClick;
        public Admin(DAL.Models.NhanVien staff, Login login)
        {
            FormLogin = login;
            user = staff;
            InitializeComponent();
        }

        public Admin()
        {
            var nvSer = new NhanVienSer();
            user = nvSer.GetAllNhanVien().FirstOrDefault();
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
            // Panel_DV.Visible = false;
            Content.Controls.Clear();
            Panel_ManHinhCho.Visible = true;
            Content.Controls.Add(Panel_ManHinhCho);
            timer1.Start();
            LoiChao.Text = "Xin chào " + user.Ten + " chúc một ngày làm việc vui vẻ!" + $"                    Hà Nội {DateTime.Now.ToString("dd/MM/yyyy")}";
        }


        private void label1_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_ManHinhCho.Visible = true;
            Content.Controls.Add(Panel_ManHinhCho);
            if (currentSelectedMethod!= null)
            {
                currentSelectedMethod.ForeColor = Color.Black;
            }
        }


        private void QL_LichKham_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_LK.Visible = true;
            Content.Controls.Add(Panel_LK);
            Giap_LoadGrViewLK(false, "", DateTime.Now, DateTime.Now.AddDays(7));
            LK_XLK_DateTime_Max.Value = DateTime.Now.AddDays(6);
            var ttNhanVienSer = new TTNhanVienSer();
            var ttPhongSer = new TTPhongSer();
            var nvSer = new NhanVienSer();
            var phongSer = new PhongSer();
            var ttphongNgayCN = ttPhongSer.GetTTPhong().OrderByDescending(a => a.Ngay).FirstOrDefault();
            if (DateTime.Parse(ttphongNgayCN.Ngay.ToString("MM/dd/yyyy")) != DateTime.Parse(DateTime.Now.AddDays(7).ToString("MM/dd/yyyy")))
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
            changeColor(QL_LichKham);

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

        private void QL_DV_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_KH.Visible = true;
            Content.Controls.Add(Panel_DV);
            var myDbContext = new GiamGiaSer();
            var kq = myDbContext.GetGiamGiaGanNhat();
            if (kq != null)
            {
                if (kq.TrangThai == true)
                {
                    DV_Btn_DungGiamGia.Visible = true;
                    DV_Btn_GiamGia.Visible = false;
                }
                else
                {
                    DV_Btn_GiamGia.Visible = true;
                    DV_Btn_DungGiamGia.Visible = false;
                }
            }
            changeColor(QL_DV);
            Giap_LoadDichVu();
        }


        private void bunifuRange1_RangeChanged(object sender, EventArgs e)
        {
            DV_Label_PhanTram.Text = $"{100 - DV_Range_GiamGia.RangeMin} %";
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


        private void ThongKe_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_ThongKe.Visible = true;
            Content.Controls.Add(Panel_ThongKe);
            ThongKe_Label_ThongTinTK.Text = $"Thống Kê Tháng {DateTime.Now.Month} Năm {DateTime.Now.Year}";
            cmbDate();
            Giap_LoadThongKe();
            changeColor(QL_ThongKe);
        }

        void Giap_LoadThongKe()
        {
            var tongChiTieu = 0;
            var tongDoanhThu = 0;
            var thongKeSer = new ThongKeService();
            var hoaDonSer = new HoaDonService();
            var hoaDonCtSer = new HoaDonChiTietService();
            var dichVuSer = new DichVuService();
            var phieuKhamSer = new PhieuKhamSer();
            var khSer = new KhachHangService();
            var nvSer = new NhanVienSer();
            var luongSer = new LuongSer();
            var count = 1;

            var kqDaThanhToan1 = hoaDonSer.GetAllHoaDon().Where(a => a.ThoiGian != null).Where(a => a.ThoiGian.Value.Month.ToString() == ThongKe_Combo_LocThang.Text && a.ThoiGian.Value.Year.ToString() == ThongKe_Combo_LocNam.Text).Join(hoaDonCtSer.GetAllHDCT().Where(a => a.TrangThai == true), n => n.IdHoaDon, m => m.IdHoaDon, (q, p) =>
            {
                return new
                {
                    idHD = q.IdHoaDon,
                    idNv = q.IdNhanVien,
                    PhuPhi = q.PhuPhi,
                    idPK = p.IdPhieuKham,
                    ThoiGian = q.ThoiGian,
                    idGiamGia = q.idGiamGia,
                    GhiChu = q.GhiChu
                };
            }).Join(phieuKhamSer.GetAllPhieuKham(), n => n.idPK, m => m.IdPhieuKham, (q, p) =>
            {
                return new
                {
                    idHD = q.idHD,
                    idNv = q.idNv,
                    PhuPhi = q.PhuPhi,
                    ThoiGian = q.ThoiGian,
                    GhiChu = q.GhiChu,
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
                    GhiChu = q.GhiChu,
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
                    GhiChu = q.GhiChu,
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
                GhiChu = q.GhiChu,
                idGiamGia = q.idGiamGia,
                ngayTT = q.ngayTT.Value.ToString("dd/MM/yyyy"),
            }).ToList();



            var kqDaThanhToanGrouped = kqDaThanhToan1.GroupBy(a =>
            {
                return new
                {
                    a.idHD,
                    a.PhuPhi,
                    a.GhiChu,
                    a.idGiamGia
                };
            });

            ThongKe_GrView_DoanhThu.Rows.Clear();
            ThongKe_GrView_DoanhThu.ColumnCount = 10;
            ThongKe_GrView_DoanhThu.Columns[0].Name = "STT";
            ThongKe_GrView_DoanhThu.Columns[1].Name = "Mã hóa đơn";
            ThongKe_GrView_DoanhThu.Columns[2].Name = "Người Thanh Toán";
            ThongKe_GrView_DoanhThu.Columns[3].Name = "Dịch vụ sử dụng";
            ThongKe_GrView_DoanhThu.Columns[4].Visible = false;
            ThongKe_GrView_DoanhThu.Columns[5].Visible = false;
            ThongKe_GrView_DoanhThu.Columns[6].Name = "Nhân viên Xác Nhận";
            ThongKe_GrView_DoanhThu.Columns[7].Visible = false;
            ThongKe_GrView_DoanhThu.Columns[8].Name = "Ngày thanh toán";
            ThongKe_GrView_DoanhThu.Columns[9].Visible = false;

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
                tongDoanhThu += Convert.ToInt32(tongGia) + Convert.ToInt32(b.Key.PhuPhi);
                ThongKe_GrView_DoanhThu.Rows.Add(count++, b.Key.idHD, b.FirstOrDefault().TenKhachHang, string.Join(",", TenDv), tongGia.ToString("0,000"), b.Key.PhuPhi, b.FirstOrDefault().TenNhanVien, b.Key.GhiChu, b.FirstOrDefault().ngayTT, b.Key.idGiamGia);
            }




            //tongDoanhThu = Convert.ToInt32(kqDaThanhToanGrouped.Sum(a => a.));
            ThongKe_Txt_TongDoanhThu.Text = $"Tổng Thu : {tongDoanhThu.ToString("0,000 VNĐ")}";



            var countCT = 1;
            var kqChiTieu = luongSer.GetAllLuong().Where(t => t.TrangThai == true && t.ThoiGian.Value.Month.ToString() == ThongKe_Combo_LocThang.Text && t.ThoiGian.Value.Year.ToString() == ThongKe_Combo_LocNam.Text).Join(nvSer.GetAllNhanVien(), v => v.IdNhanVien, n => n.IdNhanVien, (i, k) =>
            {
                var luongNgayCong = 300000;
                if (k.ChucVu == LoaiNhanVien.BacSi)
                {
                    luongNgayCong = 500000;
                }
                var obj = new
                {
                    STT = countCT++,
                    TenNV = k.Ten,
                    soCong = i.SoCong,
                    LuongNV = i.SoCong * luongNgayCong + Convert.ToInt32(i.Thuong),
                    Thue = Thue(Convert.ToDouble(i.SoCong * luongNgayCong + Convert.ToInt32(i.Thuong))),
                    ThoiGian = i.ThoiGian.Value.ToString("MM/yyyy"),
                };
                return obj;
            }).ToList();

            if (kqChiTieu.Count() == 0)
            {
                ThongKe_GrView_ChiTieu.DataSource = null;
                ThongKe_GrView_ChiTieu.ColumnCount = 6;
                ThongKe_GrView_ChiTieu.Columns[0].Name = "STT";
                ThongKe_GrView_ChiTieu.Columns[1].Name = "Tên nhân viên";
                ThongKe_GrView_ChiTieu.Columns[2].Name = "Số công";
                ThongKe_GrView_ChiTieu.Columns[3].Name = "Tổng lương";
                ThongKe_GrView_ChiTieu.Columns[4].Name = "Thời điểm";
                ThongKe_GrView_ChiTieu.Columns[5].Name = "Thuế";
            }
            else
            {
                ThongKe_GrView_ChiTieu.Columns.Clear();
                ThongKe_GrView_ChiTieu.DataSource = kqChiTieu;
                ThongKe_GrView_ChiTieu.Columns[0].Name = "STT";
                ThongKe_GrView_ChiTieu.Columns[1].Name = "Tên nhân viên";
                ThongKe_GrView_ChiTieu.Columns[2].Name = "Số công";
                ThongKe_GrView_ChiTieu.Columns[3].Name = "Tổng lương";
                ThongKe_GrView_ChiTieu.Columns[4].Name = "Thời điểm";
                ThongKe_GrView_ChiTieu.Columns[5].Name = "Thuế";
            }




            tongChiTieu = Convert.ToInt32(kqChiTieu.Sum(a => a.LuongNV + Convert.ToInt32(a.Thue)));
            ThongKe_Txt_TongChiTieu.Text = $"Tổng Chi :{tongChiTieu.ToString("0,000 VNĐ")}";

            var lai = tongDoanhThu - tongChiTieu;
            if (lai >= 0)
            {
                ThongKe_Txt_Lai.Text = $"Lãi : {lai.ToString("0,000 VNĐ")}";
            }
            else
            {
                ThongKe_Txt_Lai.Text = $"Lỗ : {Math.Abs(lai).ToString("0,000 VNĐ")}";
            }

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
            changeColor(QL_ThanhToan);
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
            var tbSer = new ThongBaoSer();
            var lstTb = tbSer.GetListThongBaoChuaTH();
            if (lstTb.Count != 0)
            {
                foreach (var item in lstTb)
                {
                    var nv = new NhanVienSer().FindNhanVien(item.IdNguoiGui);

                    var result = MessageBox.Show($"Cho phép {nv.Ten} đăng nhập?\n--------------\nThông tin :\n" +
                        $"Số điện thoại : {nv.SoDienThoai}\nSố căn cước : {item.TinNhan}", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        item.TrangThai = true;
                        item.TTChapNhan = TrangThaiXacNhan.ChapNhan;
                        MessageBox.Show("Ok tài khoản đã được cho phép đăng nhập!!");
                        tbSer.UpdateThongBao(item);
                    }
                    else if (result == DialogResult.No)
                    {
                        item.TrangThai = true;
                        item.TTChapNhan = TrangThaiXacNhan.TuChoi;
                        MessageBox.Show("Tài khoản bị từ chối đăng nhập");
                        tbSer.UpdateThongBao(item);
                    }
                    else
                    {
                        MessageBox.Show("Suy nghĩ thêm đê");
                    }

                }
            }
            else
            {
                MessageBox.Show("Không có thông báo nào (^_^)", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            changeColor(QL_NV);
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
            if (DialogResult.Yes == MessageBox.Show($"Bạn chắc chắn muốn giảm giá dịch vụ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {

                var objgiamGia = new GiamGia();
                var phanTramGiamGia = 100 - DV_Range_GiamGia.RangeMin;
                if (phanTramGiamGia == 100)
                {
                    MessageBox.Show("Không thể free dịch vụ được , chúng ta là tư bản (T-T)");
                    return;
                }
                objgiamGia.PhanTramGiamGia = phanTramGiamGia;
                objgiamGia.TrangThai = true;
                var ggSer = new GiamGiaSer();
                ggSer.AddGiamGia(objgiamGia);


                MessageBox.Show($"Đã giảm giá {phanTramGiamGia.ToString()}% cho mọi loại dịch vụ!  ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DV_Btn_DungGiamGia.Visible = true;
                DV_Btn_OKGiamGia.Visible = false;
                DV_Btn_GiamGia.Visible = false;
                DV_Range_GiamGia.Visible = false;
                DV_Label_PhanTram.Visible = false;
                Giap_LoadDichVu();
            }

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
            else if (!Giap_CheckGia(DV_Txt_Gia.Text) || DV_Txt_Gia.Text == "0")
            {
                MessageBox.Show($"Chỉ được nhập giá", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (new DichVuRepository().GetTatCaDichVu().Any(a => a.Ten == DV_Txt_TenDichVu.Text))
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
                else if (!Giap_CheckGia(DV_Txt_Gia.Text) || DV_Txt_Gia.Text == "0")
                {
                    MessageBox.Show($"Chỉ được nhập giá", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (new DichVuRepository().GetTatCaDichVu().Any(a => a.IdDichVu != dichVu.IdDichVu && a.Ten == DV_Txt_TenDichVu.Text))
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
            var giamGia = new GiamGiaSer().GetGiamGiaGanNhat();
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
                var gia = item.Gia;
                if (giamGia != null && giamGia.TrangThai == true)
                {
                    gia = double.Parse(Math.Round(item.Gia / 100 * (100 - Convert.ToDouble(giamGia.PhanTramGiamGia))).ToString());
                }
                DV_LabelGia1.Text = $"Giá : {gia.ToString("0,000")} VNĐ";

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
                DV_GrBoxDV1.ThemeColor = Color.NavajoWhite;



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
            if (DialogResult.Yes == MessageBox.Show($"Bạn chắc chắn muốn dừng giảm giá?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                var giamGiaSer = new GiamGiaSer();
                var obj = giamGiaSer.GetGiamGiaGanNhat();
                obj.TrangThai = false;
                giamGiaSer.UpdateGiamGia(obj);
                MessageBox.Show($"Đã dừng giảm giá", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DV_Btn_DungGiamGia.Visible = false;
                DV_Btn_GiamGia.Visible = true;
                Giap_LoadDichVu();
            }

        }

        private void NV_Btn_Them_Click(object sender, EventArgs e)
        {
            Tho_nvService = new NhanVienSer();
            var nv = new DAL.Models.NhanVien();
            nv.Ten = NV_Text_HoTen.TextButton;
            nv.DiaChi = NV_Txt_DiaChi.TextButton;
            nv.SoDienThoai = NV_Txt_Sdt.TextButton;
            nv.MatKhau = NV_Txt_MatKhau.TextButton;
            var gioiTinh = false;
            if (NV_Combo_GioiTinh.Text == "Nam")
            {
                gioiTinh = true;
            }
            nv.GioiTinh = gioiTinh;
            var chucVu = LoaiNhanVien.BacSi;
            if (NV_combo_ChucVu.Text == "Y Tá")
            {
                chucVu = LoaiNhanVien.YTa;
            }
            nv.ChucVu = chucVu;
            nv.HienThi = true;
            nv.NgaySinh = NV_DateTime_NgaySinh.Value;
            nv.Mota = NV_RichTxt_MoTa.TextButton;
            if (Giap_CheckTrong(NV_Text_HoTen.TextButton) || Giap_CheckTrong(NV_Txt_DiaChi.TextButton) || Giap_CheckTrong(NV_Txt_Sdt.TextButton) || Giap_CheckTrong(NV_Txt_MatKhau.TextButton))
            {

                MessageBox.Show($"Không được bỏ trống các ô thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!Regex.IsMatch(NV_Txt_Sdt.TextButton, "^0[0-9]{9}$"))
            {
                MessageBox.Show($"Nhập đúng định dạng số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Tho_nvService.GetTatCaVien().Any(a => a.SoDienThoai == NV_Txt_Sdt.TextButton))
            {
                MessageBox.Show($"Số điện thoại đã tồn tại,hãy thêm số điện thoại khác !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var option = MessageBox.Show("Xác nhận có muốn thêm!", "Thông báo!", MessageBoxButtons.YesNoCancel);
                if (option == DialogResult.Yes)
                {
                    Tho_nvService.AddNhanVien(nv);
                    MessageBox.Show($"Đã thêm thành công nhân viên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataNV();
                    TaoTrangThaiNV(nv);
                    TaoChamCong(nv);
                }
            }
        }

        void TaoChamCong(DAL.Models.NhanVien nv)
        {
            var ccSer = new ChamCongService();
            var congMoi = new ChamCong();
            congMoi.IdNhanVien = nv.IdNhanVien;
            congMoi.ThoiGianBatDau = null;
            congMoi.ThoiGianKetThuc = null;
            congMoi.TrangThaiCham = false;
            ccSer.Create(congMoi);
        }
        private void LoadDataNV()
        {
            Tho_nvService = new NhanVienSer();
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
            NV_GridView.Columns[1].Visible = false;
            NV_GridView.Columns[8].Visible = false;


            NV_GridView.Rows.Clear();

            foreach (var item in Tho_nvService.GetAllNhanVien().Where(a => a.HienThi == true))
            {
                var ChucVu = "Bác Sĩ";
                if (item.ChucVu == LoaiNhanVien.YTa)
                {
                    ChucVu = "Y Tá";
                }
                var gioiTinh = "Nam";
                if (item.GioiTinh == false)
                {
                    gioiTinh = "Nữ";
                }
                NV_GridView.Rows.Add(stt++, item.IdNhanVien, item.Ten, item.DiaChi, item.SoDienThoai, gioiTinh, ChucVu, item.NgaySinh.Value.ToString("dd/MM/yyyy"), item.MatKhau);
            }


        }

        private void NV_Txt_TimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void NV_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > NV_GridView.Rows.Count)
            {
                return;
            }
            int rowIndex = e.RowIndex;
            if (NV_GridView.Rows[rowIndex].Cells[1].Value == null)
            {
                return;
            }
            Tho_nvService = new NhanVienSer();
            iWhenClick = Guid.Parse(NV_GridView.Rows[rowIndex].Cells[1].Value.ToString());

            var clone = Tho_nvService.GetAllNhanVien().FirstOrDefault(x => x.IdNhanVien == iWhenClick);
            NhanVienDuocChon = clone;
            L_NVDuocChon = clone;
            NV_Text_HoTen.TextButton = clone.Ten;
            NV_Txt_DiaChi.TextButton = clone.DiaChi;
            NV_Txt_Sdt.TextButton = clone.SoDienThoai;
            NV_Txt_MatKhau.TextButton = clone.MatKhau;
            NV_Combo_GioiTinh.Text = "Nữ";
            NV_RichTxt_MoTa.TextButton = clone.Mota;
            if (clone.GioiTinh == true)
            {
                NV_Combo_GioiTinh.Text = "Nam";
            }
            NV_combo_ChucVu.Text = "Bác Sĩ";
            if (clone.ChucVu == LoaiNhanVien.YTa)
            {
                NV_combo_ChucVu.Text = "Y Tá";
            }
            NV_DateTime_NgaySinh.Value = clone.NgaySinh.Value;

        }

        //private void ListCombobox()
        //{
        //    List<string> lstChucVu = new List<string>() {"Bác Sĩ", "Y Tá"};
        //    NV_combo_ChucVu.DataSource = lstChucVu;
        //}
        private void NV_Btn_Sua_Click(object sender, EventArgs e)
        {
            Tho_nvService = new NhanVienSer();
            if (NhanVienDuocChon == null)
            {
                MessageBox.Show($"Chưa chọn nhân viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var nv = Tho_nvService.FindNhanVien(NhanVienDuocChon.IdNhanVien);
            if (nv != null)
            {
                nv.IdNhanVien = iWhenClick;
                nv.Ten = NV_Text_HoTen.TextButton;
                nv.DiaChi = NV_Txt_DiaChi.TextButton;
                nv.SoDienThoai = NV_Txt_Sdt.TextButton;
                nv.MatKhau = NV_Txt_MatKhau.TextButton;
                var gioiTinh = false;
                if (NV_Combo_GioiTinh.Text == "Nam")
                {
                    gioiTinh = true;
                }
                nv.GioiTinh = gioiTinh;
                var chucVu = LoaiNhanVien.BacSi;
                if (NV_combo_ChucVu.Text == "Y Tá")
                {
                    chucVu = LoaiNhanVien.YTa;
                }
                nv.Mota = NV_RichTxt_MoTa.TextButton;
                nv.ChucVu = chucVu;
                nv.HienThi = true;
                nv.NgaySinh = NV_DateTime_NgaySinh.Value;
                if (Giap_CheckTrong(NV_Text_HoTen.TextButton) || Giap_CheckTrong(NV_Txt_DiaChi.TextButton) || Giap_CheckTrong(NV_Txt_Sdt.TextButton) || Giap_CheckTrong(NV_Txt_MatKhau.TextButton))
                {
                    MessageBox.Show($"Không được bỏ trống các ô thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!Regex.IsMatch(NV_Txt_Sdt.TextButton, "^0[0-9]{9}$"))
                {
                    MessageBox.Show($"Nhập đúng định dạng số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Tho_nvService.GetTatCaVien().Any(a => a.SoDienThoai == NV_Txt_Sdt.TextButton && nv.IdNhanVien != a.IdNhanVien))
                {
                    MessageBox.Show($"Số điện thoại đã tồn tại,hãy thêm số điện thoại khác !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var option = MessageBox.Show("Xác nhận có muốn sửa!", "Thông báo!", MessageBoxButtons.YesNoCancel);
                    if (option == DialogResult.Yes)
                    {
                        Tho_nvService.UpdateNhanVien(nv);
                        MessageBox.Show($"Đã sửa thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataNV();
                    }
                }
            }
            else
            {
                MessageBox.Show($"Chưa chọn nhân viên !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

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
                var result = phieuKhamSer.GetAllPhieuKham().Where(a => a.IdKhachHang == kh.IdKhachHang && a.HienThi == true).Join(lsKhamSer.GetAllLichSuKham(), n => n.IdPhieuKham, m => m.IdPhieuKham, (p, q) =>
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




        public void cmbDate()
        {
            ThongKe_Combo_LocNam.DataSource = new List<string>
            {
                "2018", "2019", "2020", "2021", "2022", "2023" , "2024"
            };
            ThongKe_Combo_LocNam.Text = DateTime.Now.Year.ToString();
            ThongKe_Combo_LocThang.DataSource = new List<string>
            {
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"
            };
            ThongKe_Combo_LocThang.Text = DateTime.Now.Month.ToString();
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

        private void NV_Btn_An_Click(object sender, EventArgs e)
        {
            Tho_nvService = new NhanVienSer();
            if (NhanVienDuocChon == null)
            {
                MessageBox.Show($"Chưa chọn khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var nv = Tho_nvService.FindNhanVien(NhanVienDuocChon.IdNhanVien);
            if (nv != null)
            {
                var option = MessageBox.Show("Xác nhận có muốn ẩn!", "Thông báo!", MessageBoxButtons.YesNoCancel);
                if (option == DialogResult.Yes)
                {
                    nv.HienThi = false;
                    Tho_nvService.UpdateNhanVien(nv);
                    MessageBox.Show($"Đã ẩn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataNV();
                }
            }
            else
            {
                MessageBox.Show($"Chưa chọn nhân viên !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void NV_Txt_TimKiem_Click(object sender, EventArgs e)
        {
            NV_Txt_TimKiem.Text = "";
        }

        private void NV_Btn_TimKiem_Click(object sender, EventArgs e)
        {
            Tho_nvService = new NhanVienSer();
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
            NV_GridView.Columns[1].Visible = false;
            NV_GridView.Columns[8].Visible = false;


            NV_GridView.Rows.Clear();

            foreach (var item in Tho_nvService.GetAllNhanVien().Where(a => a.HienThi == true && a.Ten.ToLower().Contains(NV_Txt_TimKiem.Text.ToLower())))
            {
                var ChucVu = "Bác Sĩ";
                if (item.ChucVu == LoaiNhanVien.BacSi)
                {
                    ChucVu = "Y Tá";
                }
                var gioiTinh = "Nam";
                if (item.GioiTinh == false)
                {
                    gioiTinh = "Nữ";
                }
                NV_GridView.Rows.Add(stt++, item.IdNhanVien, item.Ten, item.DiaChi, item.SoDienThoai, gioiTinh, ChucVu, item.NgaySinh.Value.ToString("dd/MM/yyyy"), item.MatKhau);
            }
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

        private void ThongKe_Btn_Loc_Click_1(object sender, EventArgs e)
        {
            Giap_LoadThongKe();
        }

        private void ThongKe_GrView_DoanhThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > ThongKe_GrView_DoanhThu.Rows.Count)
            {
                return;
            }
            if (ThongKe_GrView_DoanhThu.Rows[e.RowIndex].Cells[0].Value == null)
            {
                return;
            }
        }

        private void ThongKe_GrView_ChiTieu_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > ThongKe_GrView_DoanhThu.Rows.Count)
            {
                return;
            }
            if (ThongKe_GrView_DoanhThu.Rows.Count == 0)
            {
                return;
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
                    GhiChu = q.GhiChu
                };
            }).Join(phieuKhamSer.GetAllPhieuKham(), n => n.idPK, m => m.IdPhieuKham, (q, p) =>
            {
                return new
                {
                    idHD = q.idHD,
                    idNv = q.idNv,
                    PhuPhi = q.PhuPhi,
                    ThoiGian = q.ThoiGian,
                    GhiChu = q.GhiChu,
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
                    GhiChu = q.GhiChu,
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
                    GhiChu = q.GhiChu,
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
                GhiChu = q.GhiChu,
                idGiamGia = q.idGiamGia,
                ngayTT = q.ngayTT.Value.ToString("dd/MM/yyyy"),
            }).ToList();



            var kqDaThanhToanGrouped = kqDaThanhToan1.GroupBy(a =>
            {
                return new
                {
                    a.idHD,
                    a.PhuPhi,
                    a.GhiChu,
                    a.idGiamGia
                };
            });

            TT_GrView_DaTT.Rows.Clear();
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

                TT_GrView_DaTT.Rows.Add(count++, b.Key.idHD, b.FirstOrDefault().TenKhachHang, string.Join(",", TenDv), tongGia.ToString("0,000"), b.Key.PhuPhi, b.FirstOrDefault().TenNhanVien, b.Key.GhiChu, b.FirstOrDefault().ngayTT, b.Key.idGiamGia);
            }




          //  QL_DangXuat.Text = new hoa


            var kqChuaThanhToan1 = hoaDonSer.GetAllHoaDon().Join(hoaDonCtSer.GetAllHDCT().Where(a => a.TrangThai == false), n => n.IdHoaDon, m => m.IdHoaDon, (q, p) =>
            {
                return new
                {
                    idHD = q.IdHoaDon,
                    idPK = p.IdPhieuKham,
                    idGiamGia = q.idGiamGia,
                };
            }).Join(phieuKhamSer.GetAllPhieuKham(), n => n.idPK, m => m.IdPhieuKham, (q, p) =>
            {
                return new
                {
                    idHD = q.idHD,
                    idKH = p.IdKhachHang,
                    idPK = p.IdPhieuKham,
                    idGiamGia = q.idGiamGia,
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
                    idGiamGia = q.idGiamGia,
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
                    idGiamGia = q.idGiamGia,
                    TenKhachHang = p.Ten,
                };
            }).ToList();


            var kqChuaThanhToanGrouped = kqChuaThanhToan1.GroupBy(a =>
                 new
                 {
                     a.idHD,
                 }
            );
            var count1 = 1;
            var kqChuaThanhToan = kqChuaThanhToanGrouped.Select(b => new
            {
                STT = count1++,
                idHD = b.Key.idHD,
                TenKh = b.ToList()[0].TenKhachHang,
                TenDv = string.Join(",", b.Select(a => a.TenDv)),
                GiaDV = b.ToList().Sum(a => a.GiaDV).ToString("0,000") + "VNĐ"
            }).ToList();


            if (kqChuaThanhToan.Count() == 0)
            {
                TT_GrView_ChuaTT.DataSource = null;
                TT_GrView_ChuaTT.ColumnCount = 5;
                TT_GrView_ChuaTT.Columns[0].HeaderText = "STT";
                TT_GrView_ChuaTT.Columns[1].HeaderText = "Mã hóa đơn";
                TT_GrView_ChuaTT.Columns[2].HeaderText = "Người Thanh Toán";
                TT_GrView_ChuaTT.Columns[3].HeaderText = "Dịch vụ sử dụng";
                TT_GrView_ChuaTT.Columns[4].HeaderText = "Tổng giá trị hóa đơn";
            }
            else
            {
                TT_GrView_ChuaTT.Columns.Clear();
                TT_GrView_ChuaTT.DataSource = kqChuaThanhToan;
                TT_GrView_ChuaTT.Columns[0].HeaderText = "STT";
                TT_GrView_ChuaTT.Columns[1].HeaderText = "Mã hóa đơn";
                TT_GrView_ChuaTT.Columns[2].HeaderText = "Người Thanh Toán";
                TT_GrView_ChuaTT.Columns[3].HeaderText = "Dịch vụ sử dụng";
                TT_GrView_ChuaTT.Columns[4].HeaderText = "Tổng giá trị hóa đơn";

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
                    GhiChu = q.GhiChu
                };
            }).Join(phieuKhamSer.GetAllPhieuKham(), n => n.idPK, m => m.IdPhieuKham, (q, p) =>
            {
                return new
                {
                    idHD = q.idHD,
                    idNv = q.idNv,
                    PhuPhi = q.PhuPhi,
                    ThoiGian = q.ThoiGian,
                    GhiChu = q.GhiChu,
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
                    GhiChu = q.GhiChu,
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
                    GhiChu = q.GhiChu,
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
                GhiChu = q.GhiChu,
                ngayTT = q.ngayTT.Value.ToString("dd/MM/yyyy"),
            }).ToList();



            var kqDaThanhToanGrouped = kqDaThanhToan1.GroupBy(a =>
            {
                return new
                {
                    a.idHD,
                    a.PhuPhi,
                    a.GhiChu,
                };
            });


            var stringText = "";
            double TongTienDV = 0;
            foreach (var item in kqDaThanhToanGrouped)
            {
                TT_Txt_MaHD.Text = "Mã hóa đơn : " + item.Key.idHD.ToString().Substring(0, 15);
                TT_txt_ChiPhiKhac.Text = $"{Convert.ToDouble(item.Key.PhuPhi).ToString("0,000")} VNĐ";
                TT_txt_GhiChu.Text = item.Key.GhiChu.ToString();
                TT_Txt_TenKH.Text = item.FirstOrDefault().TenKhachHang;
                TT_Txt_NVThanhToan.Text = item.FirstOrDefault().TenNhanVien;
                TT_txt_ThoiGianTT.Text = item.FirstOrDefault().ngayTT;
                TongTienDV = Convert.ToDouble(item.Sum(a => a.GiaDV) + item.Key.PhuPhi);
                stringText = string.Join("\n", item.Select(a => $"{a.TenDv} - {a.GiaDV.ToString("0,000")} VNĐ"));

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
                    }
                    else
                    {
                        TongTienDV += Giadv;
                    }
                    stringText += $"{item1.TenDv} - {Giadv.ToString("0,000")} VNĐ\n";
                }
                TT_Txt_MaHD.Text = "Mã hóa đơn : " + item.Key.idHD.ToString().Substring(0, 15);
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
                    if (TT_txt_ChiPhiKhac.Text == "")
                    {

                    }
                    else
                    {
                        MessageBox.Show($"Hãy nhập số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

              
                    var hd = hdSer.FindHoaDon(TT_HoaDonDuocChon.IdHoaDon);
                    hd.PhuPhi = Convert.ToDouble(TT_txt_ChiPhiKhac.Text);
                    hd.GhiChu = TT_txt_GhiChu.Text;
                    hdSer.UpdateHoaDon(hd);
                    MessageBox.Show($"Đã cập nhật thông tin hóa đơn thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Giap_LoadDataGrThanhToan();
               

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
                    var hdSer = new HoaDonService();
                    var hd = hdSer.FindHoaDon(TT_HoaDonDuocChon.IdHoaDon);
                    hd.HienThi = false;
                    hdSer.UpdateHoaDon(hd);
                    MessageBox.Show($"Đã ẩn hóa đơn thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Giap_LoadDataGrThanhToan();

                }
                else
                {

                }
            }
        }

        private void TT_Btn_ThanhToan_Click(object sender, EventArgs e)
        {
            if (TT_HoaDonDuocChon == null)
            {
                MessageBox.Show($"Chưa chọn hóa đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //double PhuPhi;
                if (!Giap_CheckGia(TT_txt_ChiPhiKhac.Text))
                {
                    if (TT_txt_ChiPhiKhac.Text == "")
                    {
                        
                    }
                    else
                    {
                        MessageBox.Show($"Hãy nhập số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                }

                    if (DialogResult.Yes == MessageBox.Show($"Bạn chắc chắn muốn xác nhận thanh toán hóa đơn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        var hdSer = new HoaDonService();
                        var hd = hdSer.FindHoaDon(TT_HoaDonDuocChon.IdHoaDon);
                        if (TT_txt_ChiPhiKhac.Text.Trim() == "")
                        {
                            hd.PhuPhi = 0;
                        }
                        else
                        {
                            hd.PhuPhi = Convert.ToDouble(TT_txt_ChiPhiKhac.Text);
                        }
                        hd.GhiChu = TT_txt_GhiChu.Text;
                        hd.ThoiGian = DateTime.Now;
                        hd.IdNhanVien = user.IdNhanVien;

                        hdSer.UpdateHoaDon(hd);

                        var hdctSer = new HoaDonChiTietService();
                        var listHD = hdctSer.GetAllHDCT().Where(a => a.IdHoaDon == TT_HoaDonDuocChon.IdHoaDon).ToList();
                        foreach (var item in listHD)
                        {
                            item.TrangThai = true;
                            hdctSer.UpdateHDCT(item);
                        }
                        var kq = MessageBox.Show($"Khách hàng có muốn in hóa đơn không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (kq == DialogResult.Yes)
                        {
                            var listHdct = new HoaDonChiTietService().GetAllHDCT().Where(a => a.IdHoaDon == hd.IdHoaDon && a.TrangThai == true);
                            var pk = new PhieuKhamSer().FindPhieuKham(listHdct.FirstOrDefault().IdPhieuKham);
                            var kh = new KhachHangService().FindKhachHang(pk.IdKhachHang);
                            var listDichVu = listHdct.Join(new PhieuKhamSer().GetAllPhieuKham(), a => a.IdPhieuKham, b => b.IdPhieuKham, (c, d) =>
                            {
                                return new
                                {
                                    idDV = d.IdDichVu
                                };
                            }).Join(new DichVuService().GetAllDichVu(), a => a.idDV, b => b.IdDichVu, (c, d) =>
                            {
                                return new
                                {
                                    TenDv = d.Ten ,
                                    Gia = d.Gia ,
                                };
                            });

                            var stringDV = string.Join("\n", listDichVu.Select(a => $"{a.TenDv} - {a.Gia.ToString("0,000")} VNĐ"));
                            var giamgia = 100;
                            if (hd.idGiamGia != null)
                            {
                                giamgia = Convert.ToInt32(new GiamGiaSer().FindGiamGia(Convert.ToInt32(hd.idGiamGia)).PhanTramGiamGia);
                            }
                            var tongTien = Convert.ToDouble(listDichVu.Sum(a => a.Gia * giamgia) + hd.PhuPhi);
                            using (var fs = new FileStream($@"C:\\HoaDon\\{hd.ThoiGian.Value.ToString("dd-MM-yyyy")}--{hd.IdHoaDon}Result.txt", FileMode.OpenOrCreate, FileAccess.Write))
                            {
                                var stream = new StreamWriter(fs);
                                stream.WriteLine($"HÓA ĐƠN\r\n\r\nNgày: {hd.ThoiGian.Value.ToString("dd/MM/yyyy hh:mm")}\r\n\nSố hóa đơn: {hd.IdHoaDon}\r\n\n\r\nPhòng phám: 1412 Dental\r\n\nĐịa chỉ: 69 Nguyễn Phong Sắc , quận Cầu Giấy , Hà Nội\r\n\n" +
                                    $"Điện thoại: 0978040960\r\n\r\n\nThông tin khách hàng:\r\n\nHọ và tên: {kh.Ten}\r\n\nĐịa chỉ: {kh.DiaChi}\r\n\nĐiện thoại: {kh.SoDienThoai}\r\n\r\n\n" +
                                    $"Dịch vụ sử dụng : {stringDV} \r\n\nPhụ phí: {Convert.ToDouble(hd.PhuPhi).ToString("0,000")} VNĐ\r\n\nTổng cộng: {tongTien.ToString("0,000")} VNĐ\r\n\nNhân viên thanh toán: {new NhanVienSer().FindNhanVien(Guid.Parse(hd.IdNhanVien.ToString())).Ten}");
                                stream.Flush();
                            }
                        MessageBox.Show($"Xác nhận thanh toán và in hóa đơn thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    MessageBox.Show($"Xác nhận thanh toán thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Giap_LoadDataGrThanhToan();
                    
                }
            }

        }

        private void LK_Btn_XemLichKham_Click(object sender, EventArgs e)
        {
            LK_Panel.Controls.Clear();
            LK_Panel.Controls.Add(LK_GrBox_XemLichKham);
            spaceSeparatorHorizontal1.Location = new Point(LK_Btn_XemLichKham.Location.X, spaceSeparatorHorizontal1.Location.Y);
            spaceSeparatorHorizontal1.Size = new Size(LK_Btn_XemLichKham.Width + 1, spaceSeparatorHorizontal1.Height);
            Giap_LoadGrViewLK(true, "", null, null);
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

        private void LK_Btn_Sua_HuyLichKham_Click(object sender, EventArgs e)
        {
            LK_Panel.Controls.Clear();
            LK_Panel.Controls.Add(LK_GrBox_Sua_HuyLichKham);
            spaceSeparatorHorizontal1.Location = new Point(LK_Btn_Sua_HuyLichKham.Location.X, spaceSeparatorHorizontal1.Location.Y);
            spaceSeparatorHorizontal1.Size = new Size(LK_Btn_Sua_HuyLichKham.Width + 1, spaceSeparatorHorizontal1.Height);
            Giap_LoadComboSHPK();
            SHPK_LoadGRrView(false, "", null, null);
            SHPK_Date_Max.Value = DateTime.Now.AddDays(7);
        }

        void Giap_LoadGrViewLK(bool trangThaiKham, string txtSearch, DateTime? minTime, DateTime? maxTime)
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
                    tenDV = c.tenDV,
                    CaKham = c.CaKham,
                    ngayKham = c.ngayKham,
                    TenKH = d.Ten,
                };
            }).Join(nhanVienSer.GetAllNhanVien(), a => a.idYTa, b => b.IdNhanVien, (c, d) =>
            {
                return new
                {
                    idPhieuKham = c.idPhieuKham,
                    TenBacSi = c.TenBacSi,
                    idPhong = c.idPhong,
                    tenDV = c.tenDV,
                    CaKham = c.CaKham,
                    TenKH = c.TenKH,
                    ngayKham = c.ngayKham,
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
                    TenYta = c.TenYta,
                    tenDV = c.tenDV,
                    CaKham = c.CaKham,
                    LoaiPhong = d.LoaiPhong,
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





            if (kqLichKham.Count != 0)
            {
                LK_XLK_GrView.DataSource = null;
                LK_XLK_GrView.ColumnCount = 0;
                LK_XLK_GrView.DataSource = kqLichKham;
                LK_XLK_GrView.Columns[0].HeaderText = "STT";
                LK_XLK_GrView.Columns[1].HeaderText = "Mã phiếu khám";
                LK_XLK_GrView.Columns[2].HeaderText = "Tên khách hàng";
                LK_XLK_GrView.Columns[3].HeaderText = "Tên bác sĩ";
                LK_XLK_GrView.Columns[4].HeaderText = "Tên y tá";
                LK_XLK_GrView.Columns[5].HeaderText = "Tên dịch vụ";
                LK_XLK_GrView.Columns[6].HeaderText = "Ca khám";
                LK_XLK_GrView.Columns[7].HeaderText = "Tên phòng";
                LK_XLK_GrView.Columns[8].HeaderText = "Ngày ";
            }
            else
            {
                LK_XLK_GrView.DataSource = null;
                LK_XLK_GrView.ColumnCount = 9;
                LK_XLK_GrView.Columns[0].HeaderText = "STT";
                LK_XLK_GrView.Columns[1].HeaderText = "Mã phiếu khám";
                LK_XLK_GrView.Columns[2].HeaderText = "Tên khách hàng";
                LK_XLK_GrView.Columns[3].HeaderText = "Tên bác sĩ";
                LK_XLK_GrView.Columns[4].HeaderText = "Tên y tá";
                LK_XLK_GrView.Columns[5].HeaderText = "Tên dịch vụ";
                LK_XLK_GrView.Columns[6].HeaderText = "Ca khám";
                LK_XLK_GrView.Columns[7].HeaderText = "Tên phòng";
                LK_XLK_GrView.Columns[8].HeaderText = "Ngày ";
            }

        }




        private void LK_XLK_Checkbox_Load(object sender, EventArgs e)
        {
        }

        private void LK_XLK_Checkbox_Click(object sender, EventArgs e)
        {
            Giap_LoadGrViewLK(LK_XLK_Checkbox.Checked, LK_XLK_Txt_TimKiem.Text, LK_XLK_DateTime_Min.Value, LK_XLK_DateTime_Max.Value);
        }

        private void LK_XLK_Btn_TimKiem_Click(object sender, EventArgs e)
        {
            Giap_LoadGrViewLK(!LK_XLK_Checkbox.Checked, LK_XLK_Txt_TimKiem.Text, LK_XLK_DateTime_Min.Value, LK_XLK_DateTime_Max.Value);
        }

        private void LK_XLK_Btn_Loc_Click(object sender, EventArgs e)
        {
            Giap_LoadGrViewLK(!LK_XLK_Checkbox.Checked, LK_XLK_Txt_TimKiem.Text, LK_XLK_DateTime_Min.Value, LK_XLK_DateTime_Max.Value);
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
                        hd.HienThi = false;
                        hd.PhuPhi = 0;
                        hd.GhiChu = "";
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
                        MessageBox.Show("Ok hãy tiếp tục đặt lịch cho các khách hàng thân yêu đi nào!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            var resultSearch = nvSer.GetAllNhanVien().Where(a => a.IdNhanVien == L_NVDuocChon.IdNhanVien).Join(luongSer.GetAllLuong().Where(v => v.ThoiGian.Value.ToString("MM/yyyy") == DateTime.Now.ToString("MM/yyyy")), a => a.IdNhanVien,
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
                L_Btn_Sua.Visible = true;
                L_LuongDuocChon = luongSer.FindLuong(result.idLuong);
                if (result.TrangThai == false)
                {
                    L_Btn_XacNhan.Visible = true;
                }
                else
                {
                    L_Btn_XacNhan.Visible = false;
                }
                L_Txt_Ten.Text = result.Ten;
                L_Txt_SoCong.Text = result.SoCong.ToString();
                L_Txt_TG.Text = $"Thống kê tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";
                L_Txt_thuong.Text = $"{result.Thuong}";
                //thuế

                double heSoLuong = 300000;
                if (result.VaiTro == LoaiNhanVien.BacSi)
                {
                    heSoLuong = 500000;
                }
                var luong = Convert.ToDouble(heSoLuong * result.SoCong + result.Thuong);

                var tienThue = Thue(luong);


                L_Txt_Tongluong.Text = $"{luong.ToString("0,000")} VNĐ";
                L_txt_Thue.Text = $"{tienThue.ToString("0,000")} VNĐ";
            }
            else
            {
                L_Txt_TG.Text = "Nhân viên này chưa thực hiện chấm công tháng này!";
                L_Txt_Ten.Text = "";
                L_Txt_SoCong.Text = "0";
                L_txt_Thue.Text = "0 VNĐ";
                L_Txt_Tongluong.Text = "0 VNĐ";
                L_Btn_Sua.Visible = false;
                L_Btn_XacNhan.Visible = false;
                L_Btn_OKSua.Visible = false;
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

        private void L_Btn_XacNhan_Click(object sender, EventArgs e)
        {
            if (L_LuongDuocChon != null)
            {
                if (DialogResult.Yes == MessageBox.Show($"Bạn chắc chắn muốn xác nhận trả lương nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    var luongSer = new LuongSer();
                    L_LuongDuocChon.TrangThai = true;
                    luongSer.UpdateLuong(L_LuongDuocChon);
                    var nv = new NhanVienSer().FindNhanVien(L_LuongDuocChon.IdNhanVien);

                    var tkSer = new ThongKeService();
                    var tk = new ThongKe();
                    tk.IdLuong = L_LuongDuocChon.IdLuong;
                    tk.LoaiThongKe = false;
                    tk.GhiChu = $"Trả lương tháng {DateTime.Now.Month} năm {DateTime.Now.Year} nhân viên {nv.Ten}";
                    tkSer.AddThongKe(tk);
                    L_Btn_XacNhan.Visible = false;
                    MessageBox.Show("Thông tin đã được cập nhật (^-^)");
                }
            }
        }

        private void L_Btn_Sua_Click(object sender, EventArgs e)
        {
            L_Txt_SoCong.Enabled = true;
            L_Txt_thuong.Enabled = true;
            L_Btn_OKSua.Visible = true;

        }

        private void L_Txt_SoCong_TextChanged(object sender, EventArgs e)
        {
            if (L_LuongDuocChon != null)
            {
                var nv = new NhanVienSer().FindNhanVien(L_LuongDuocChon.IdNhanVien);
                var chucVu = nv.ChucVu;

                if (!Giap_CheckGia(L_Txt_SoCong.Text))
                {
                    MessageBox.Show("Chỉ được nhập số!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var heso = 300000;
                if (chucVu == LoaiNhanVien.BacSi)
                {
                    heso = 500000;
                }
                double thuong = 0;
                if (!Giap_CheckGia(L_Txt_thuong.Text))
                {
                    thuong = 0;
                }
                else
                {
                    thuong = Double.Parse(L_Txt_thuong.Text);
                }
                var luong = heso * Double.Parse(L_Txt_SoCong.Text.ToString()) + thuong;
                L_txt_Thue.Text = Thue(luong).ToString("0,000") + "VNĐ";
                L_Txt_Tongluong.Text = luong.ToString("0,000") + "VNĐ";
            }
        }

        private void L_Txt_thuong_TextChanged(object sender, EventArgs e)
        {
            if (L_LuongDuocChon != null)
            {
                var nv = new NhanVienSer().FindNhanVien(L_LuongDuocChon.IdNhanVien);
                var chucVu = nv.ChucVu;

                if (!Giap_CheckGia(L_Txt_thuong.Text))
                {
                    MessageBox.Show("Chỉ được nhập số!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var heso = 300000;
                if (chucVu == LoaiNhanVien.BacSi)
                {
                    heso = 500000;
                }
                double thuong = 0;
                if (!Giap_CheckGia(L_Txt_SoCong.Text))
                {
                    thuong = 0;
                }
                else
                {
                    thuong = Double.Parse(L_Txt_SoCong.Text);
                }
                var luong = heso * thuong + Convert.ToDouble(L_Txt_thuong.Text);
                L_txt_Thue.Text = Thue(luong).ToString("0,000") + "VNĐ";
                L_Txt_Tongluong.Text = luong.ToString("0,000") + "VNĐ";
            }
        }

        private void L_Btn_OKSua_Click(object sender, EventArgs e)
        {
            var luongSer = new LuongSer();
            if (L_LuongDuocChon != null)
            {
                if (!Giap_CheckGia(L_Txt_SoCong.Text) || L_Txt_SoCong.Text == "")
                {
                    MessageBox.Show("Chỉ được nhập số!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                double thuong = 0;
                if (!Giap_CheckGia(L_Txt_thuong.Text))
                {
                    if (L_Txt_thuong.Text == "")
                    {

                    }
                    else
                    {
                        MessageBox.Show("Chỉ được nhập số!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                thuong = Convert.ToDouble(L_Txt_thuong.Text);
                L_LuongDuocChon.SoCong = Convert.ToInt32(L_Txt_SoCong.Text);
                L_LuongDuocChon.Thuong = thuong;
                luongSer.UpdateLuong(L_LuongDuocChon);
                MessageBox.Show($"Đã sửa lương nhân viên thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                L_Txt_SoCong.Enabled = false;
                L_Txt_thuong.Enabled = false;
                L_Btn_OKSua.Visible = false;
            }
        }

        private void bigLabel12_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_NV.Visible = true;
            Content.Controls.Add(Panel_NV);
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
                    var stringInfo = $"{user.MatKhau}|{user.MatKhau}|false";
                    var bf = new BinaryFormatter();
                    bf.Serialize(fs, stringInfo);
                }

            }
        }

        private void QL_Thoat_Click(object sender, EventArgs e)
        {
            var option = MessageBox.Show("Xác nhận có muốn đăng xuất không!", "Thông báo!", MessageBoxButtons.YesNoCancel);
            if (option == DialogResult.Yes)
            {
                this.Close();
                FormLogin.Close();
            }
        }

        private void buttonCustom2_Click(object sender, EventArgs e)
        {
            if (KhachHangDuocChon == null)
            {
                MessageBox.Show("Chưa chọn khách hàng !");
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
            LK_Panel.Controls.Clear();
            LK_Panel.Controls.Add(LK_Grbox_ThemLichKham);
            spaceSeparatorHorizontal1.Location = new Point(LK_Btn_ThemLichKham.Location.X, spaceSeparatorHorizontal1.Location.Y);
            spaceSeparatorHorizontal1.Size = new Size(LK_Btn_ThemLichKham.Width + 1, spaceSeparatorHorizontal1.Height);
            Giap_LK_LoadComboKhachHangBacSiDichVuNgayPhong();
            LK_TPK_Combo_KhachHang.SelectedValue = kh.IdKhachHang;
            LK_TPK_Combo_KhachHang.Enabled = false;
            var ttphongNgayCN = ttPhongSer.GetTTPhong().OrderByDescending(a => a.Ngay).FirstOrDefault();
            if (DateTime.Parse(ttphongNgayCN.Ngay.ToString("MM/dd/yyyy")) != DateTime.Parse(DateTime.Now.AddDays(7).ToString("MM/dd/yyyy")))
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
            changeColor(QL_LichKham);



        }

        private void KH_RichTxt_LSKham_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var tbSer = new ThongBaoSer();
            QL_ThongBao.Text = "Thông báo" + $"({tbSer.GetListThongBaoChuaTH().Count})" ;
        }
    }
}


