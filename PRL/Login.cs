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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(PhoneNumber.Text, "^0[0-9]{9}$"))
            {
                errorProvider1.SetError(PhoneNumber, "Nhập đúng định dạng số điện thoại bro ơi !");
                Btn_Login.Visible = false;
            }
            else
            {
                Btn_Login.Visible = true;
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
                        this.Visible = false;
                    }
                }

            }
        }

        private void Login_VisibleChanged(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
