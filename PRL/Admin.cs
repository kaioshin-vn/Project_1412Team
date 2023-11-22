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
        public Admin(Staff staff, Login login)
        {
            FormLogin = login;
            user = staff;
            InitializeComponent();
        }

        public Admin()
        {
            InitializeComponent();
        }

        Staff user;
        Login FormLogin;

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_NV.Visible = true;
            Content.Controls.Add(Panel_NV);

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void QL_LichKham_Click(object sender, EventArgs e)
        {

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
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void NV_ChucVu_Click(object sender, EventArgs e)
        {

        }

        private void NV_Pass_Click(object sender, EventArgs e)
        {

        }

        private void NV_Ten_Click(object sender, EventArgs e)
        {

        }

        private void cyberRichTextBox5_Load(object sender, EventArgs e)
        {

        }
    }
}
