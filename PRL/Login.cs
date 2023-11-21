using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRL
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        bool EyeStatus = true;
        bool RememberStatus = false;

        private void Visible_Pass_Click(object sender, EventArgs e)
        {

            if (EyeStatus)
            {
                Visible_Pass.Image = Properties.Resources.icons8_closed_eye_35;
                EyeStatus = false;
                Password.PasswordChar = '\0';
            }
            else
            {
                Visible_Pass.Image = Properties.Resources.icons8_eye_open_35;
                EyeStatus = true;
                Password.PasswordChar = '☢';
            }
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            if (Password.Text == "")
            {
                errorProvider1.SetError(Password, "Không được bỏ trống mật khẩu!!!");
                Btn_Login.Enabled = false;
                Btn_Login.BackColor = Color.Gainsboro;

            }
            else
            {
                Btn_Login.Enabled = true;
                Btn_Login.BackColor = Color.Cyan;
                errorProvider1.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(PhoneNumber.Text, "^0[0-9]{9}$"))
            {
                errorProvider1.SetError(PhoneNumber, "Nhập đúng định dạng số điện thoại bro ơi !");
                Btn_Login.Enabled = false;
                Btn_Login.BackColor = Color.Gainsboro;

            }
            else
            {
                Btn_Login.Enabled = true;
                Btn_Login.BackColor = Color.Cyan;
                errorProvider1.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Btn_Login_Click(object sender, EventArgs e)
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

        }

        private void Login_Load(object sender, EventArgs e)
        {
            Btn_Login.Enabled = false;
            using (var fs = new FileStream("remember_account.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                var data = new StreamReader(fs).ReadLine();
                if (data != null)
                {
                    var processData = data.Split('|');
                    if (processData[2] == "true")
                    {
                        var st = new Staff();
                        var form = new Admin(st, this);
                        form.Show();
                        RememberStatus = true;
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
            Btn_Login.Text = "Gửi yêu cầu";
            Password.PasswordChar = '0';
            Visible_Pass.Visible = false;
            checkBox1.Visible = false;
            Forget_Pass.Visible = false;
        }
    }
}
