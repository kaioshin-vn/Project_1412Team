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
                Password.PasswordChar = '☢';
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
                    var stream = new StreamWriter(fs);
                    stream.WriteLine($"{PhoneNumber.Text}|{Password.Text}|true");
                    stream.Flush();
                }
            }
            else
            {
                using (var fs = new FileStream("remember_account.txt", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    var stream = new StreamWriter(fs);
                    stream.WriteLine($"{PhoneNumber.Text}|{Password.Text}|false");
                    stream.Flush();
                }
            }
            GetLoaiNhanVien();
        }
       

        private void Timer_Tick(object sender, EventArgs e)
        {
            soLanNhapSai = 0;
            timer.Stop();
        }
        public LoaiNhanVien GetLoaiNhanVien()
        {
            if (soLanNhapSai >= 5)
            {
                MessageBox.Show("Bạn đã nhập sai quá số lần cho phép. Vui lòng thử lại sau 10 giây.", "Thông báo", MessageBoxButtons.OK);
                timer.Start();
                return LoaiNhanVien.Null;
            }
            var _nhanVienSer = new NhanVienSer();
            var checkTK = _nhanVienSer.GetAllNhanVien()
                .Where(p => p.SoDienThoai == PhoneNumber.Text && p.MatKhau == Password.Text)
                .FirstOrDefault();

            if (checkTK != null)
            {
                if (checkTK.ChucVu == LoaiNhanVien.BacSi)
                {
                    this.Hide();
                    new Admin(checkTK, this).Show();
                    return LoaiNhanVien.BacSi;
                }
                else if ((checkTK.ChucVu == LoaiNhanVien.YTa))
                {
                    this.Hide();
                    new YTa(checkTK, this).Show();
                    return LoaiNhanVien.YTa;
                }

            }
            MessageBox.Show("Tài Khoản hoặc mật khẩu không hợp lệ");
            soLanNhapSai++;

            return LoaiNhanVien.Null;

        }
        private void Login_Load(object sender, EventArgs e)
        {
            Login_Btn_DangNhap.Enabled = false;
            using (var fs = new FileStream("remember_account.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                var data = new StreamReader(fs).ReadLine();
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
                            var form = new Admin(checkTK, this);
                            form.Show();
                            RememberStatus = true;
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
            Lb_pass.Text = "Nhập họ tên ";
            Password.PlaceholderText = "Họ và tên";
            Login_Btn_DangNhap.Text = "Gửi yêu cầu";
            Password.PasswordChar = '0';
            Visible_Pass.Visible = false;
            checkBox1.Visible = false;
            Forget_Pass.Visible = false;
        }

        
    }
}
