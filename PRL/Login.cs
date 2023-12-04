using B_BUS.Services;
using C_PRL;
using DAL.Enums;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Timer = System.Windows.Forms.Timer;

namespace PRL
{
    public partial class Login : Form
    {
        Guid idKhoiPhuc;

        int soLanNhapSai = 0;
        Timer timer;
        public Login()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 10000;
            timer.Tick += Timer_Tick;
        }

        bool EyeStatus = true;
        internal bool RememberStatus = false;

        private void Visible_Pass_Click(object sender, EventArgs e)
        {

            if (EyeStatus)
            {
                Visible_Pass.Image = C_PRL.Properties.Resources.icons8_closed_eye_35;
                EyeStatus = false;
                Password.PasswordChar = '\0';
            }
            else
            {
                Visible_Pass.Image = C_PRL.Properties.Resources.icons8_eye_open_35;
                EyeStatus = true;
                Password.PasswordChar = '❤';
            }

        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            if (Password.Text == "")
            {
                errorProvider1.SetError(Password, "Không được bỏ trống mật khẩu!!!");
                Login_Btn_DangNhap.Enabled = false;
                Login_Btn_DangNhap.BackColor = Color.Gainsboro;

            }
            else
            {
                Login_Btn_DangNhap.Enabled = true;
                Login_Btn_DangNhap.BackColor = Color.Cyan;
                errorProvider1.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(PhoneNumber.Text, "^0[0-9]{9}$"))
            {
                errorProvider1.SetError(PhoneNumber, "Nhập đúng định dạng số điện thoại bro ơi !");
                Login_Btn_DangNhap.Enabled = false;
                Login_Btn_DangNhap.BackColor = Color.Gainsboro;

            }
            else
            {
                Login_Btn_DangNhap.Enabled = true;
                Login_Btn_DangNhap.BackColor = Color.Cyan;
                errorProvider1.Clear();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Btn_DangNhap_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                using (var fs = new FileStream("remember_account.txt", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    var stringInfo = $"{PhoneNumber.Text}|{Password.Text}|true";
                    var bf = new BinaryFormatter();
                    bf.Serialize(fs, stringInfo);


                }
            }
            else
            {
                using (var fs = new FileStream("remember_account.txt", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    var stringInfo = $"{PhoneNumber.Text}|{Password.Text}|false";
                    var bf = new BinaryFormatter();
                    bf.Serialize(fs, stringInfo);
                }
            }
            GetLoaiNhanVien();
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            soLanNhapSai = 0;
            timer.Stop();
        }
        public void GetLoaiNhanVien()
        {
            if (soLanNhapSai >= 5)
            {
                MessageBox.Show("Bạn đã nhập sai quá số lần cho phép. Vui lòng thử lại sau 10 giây.", "Thông báo", MessageBoxButtons.OK);
                timer.Start();
                return;
            }
            var _nhanVienSer = new NhanVienSer();
            var checkTK = _nhanVienSer.GetAllNhanVien()
                .Where(p => p.SoDienThoai == PhoneNumber.Text && p.MatKhau == Password.Text)
                .FirstOrDefault();

            if (checkTK != null)
            {
                if (checkTK.ChucVu == LoaiNhanVien.Admin)
                {
                    this.Hide();
                    new Admin(checkTK, this).Show();
                    return;
                }
                else
                {
                    this.Hide();
                    new NhanVien(checkTK, this).Show();
                    return;
                }

            }
            MessageBox.Show("Tài Khoản hoặc mật khẩu không hợp lệ");
            soLanNhapSai++;
        }
        private void Login_Load(object sender, EventArgs e)
        {
            Login_Btn_DangNhap.Enabled = false;
            using (var fs = new FileStream("remember_account.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
               // return;
                var bf = new BinaryFormatter();
                var data = bf.Deserialize(fs).ToString();

                if (data != null)
                {
                    var processData = data.Split('|');
                    if (processData[2] == "true")
                    {
                        this.Hide();
                        var _nhanVienSer = new NhanVienSer();
                        var checkTK = _nhanVienSer.GetAllNhanVien()
                            .Where(p => p.SoDienThoai == processData[0] && p.MatKhau == processData[1] && p.HienThi == true)
                            .FirstOrDefault();
                        if (checkTK != null)
                        {
                            RememberStatus = true;
                            if (checkTK.ChucVu == LoaiNhanVien.Admin)
                            {
                                var form = new Admin(checkTK, this);
                                form.Show();
                            }
                            else
                            {
                                var form = new NhanVien(checkTK, this);
                                form.Show();
                            }
                            
                        }
                    }
                    else
                    {
                    }
                }

            }
        }

        private void Login_VisibleChanged(object sender, EventArgs e)
        {
            if (RememberStatus)
            {
                this.Visible = false;
            }
        }

        private void Forget_Pass_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void DN_btn_huy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = false;
        }

        private void DN_btn_XacNhan_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(DN_Sdt.Text, "^0[0-9]{9}$"))
            {
                MessageBox.Show("Nhập đúng định dạng số điện thoại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Regex.IsMatch(DN_Cc.Text, "^[0-9]{12}$"))
            {
                MessageBox.Show("Nhập đúng định dạng căn cước công dân của bạn !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var nvSer = new NhanVienSer();
            if (!nvSer.GetAllNhanVien().Any(a => a.SoDienThoai == DN_Sdt.Text))
            {
                MessageBox.Show("Số điện thoại không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var nv = nvSer.GetAllNhanVien().FirstOrDefault(a => a.SoDienThoai == DN_Sdt.Text);

            var reQuest = new ThongBao();
            reQuest.TinNhan = DN_Cc.Text;
            reQuest.TTChapNhan = TrangThaiXacNhan.Cho;
            reQuest.IdNguoiGui = nv.IdNhanVien;
            reQuest.TrangThai = false;
            var rqSer = new ThongBaoSer();
            rqSer.AddThongBao(reQuest);
            MessageBox.Show("Đã gửi yêu cầu đăng nhập , hãy chờ quản trị viên hệ thống xác nhận", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            idKhoiPhuc = reQuest.IdThongBao;
            panel1.Visible = false;
            panel2.Visible = true;
            timer1.Start();
        }

        int countCham = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            var tbSer = new ThongBaoSer();
            var xacNhan = tbSer.FindThongBao(idKhoiPhuc);
            if (xacNhan.TTChapNhan == TrangThaiXacNhan.Cho)
            {
                if (countCham == 0)
                {
                    DN_ChoXN.Text = "Đang chờ xác nhận";
                }
                else if (countCham == 1)
                {
                    DN_ChoXN.Text = "Đang chờ xác nhận.";
                }
                else if (countCham == 2)
                {
                    DN_ChoXN.Text = "Đang chờ xác nhận..";
                }
                else if (countCham == 3)
                {
                    DN_ChoXN.Text = "Đang chờ xác nhận...";
                    countCham = 0;
                    return;
                }
                countCham++;
                return;
            }
            else if (xacNhan.TTChapNhan == TrangThaiXacNhan.ChapNhan)
            {
                var nv = new NhanVienSer().FindNhanVien(xacNhan.IdNguoiGui);
                timer1.Stop();
                MessageBox.Show("Chúc mừng bạn đã được chấp nhận đăng nhập", "Tin vui", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel1.Visible = false;
                panel2.Visible = false;
                if (nv.ChucVu == LoaiNhanVien.Admin)
                {
                    this.Hide();
                    new Admin(nv, this).Show();
                }
                else
                {
                    this.Hide();
                    new NhanVien(nv, this).Show();
                }
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("Bạn đã bị từ chối (T_T) , chúc may mắn lần sau", "Tin buồn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel1.Visible = false;
                panel2.Visible = false;
            }
        }
    }
}
