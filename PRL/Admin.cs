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
            Content.Controls.Clear();
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

        private void cyberRichTextBox2_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void cyberGroupBox2_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void name_clinic_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Click(object sender, EventArgs e)
        {

        }

        private void QL_DV_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_KH.Visible = true;
            Content.Controls.Add(Panel_DV);
        }

        private void buttonCustom6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuRange1_RangeChanged(object sender, EventArgs e)
        {
            DV_Label_PhanTram.Text = $"{100 - bunifuRange1.RangeMin} %";
        }

        private void buttonCustom7_Click(object sender, EventArgs e)
        {
            thunderGroupBox1.Visible = false;
            DV_Btn_OK.Visible = true;
            bunifuRange1.Visible = true;
            DV_Label_PhanTram.Visible = true;
        }

        private void buttonCustom9_Click(object sender, EventArgs e)
        {
            DV_Btn_OK.Visible = false;
            bunifuRange1.Visible = false;
            DV_Label_PhanTram.Visible = false;
            thunderGroupBox1.Visible = true;
        }

        private void buttonCustom5_Click(object sender, EventArgs e)
        {
            DV_Btn_OK.Visible = false;
            bunifuRange1.Visible = false;
            DV_Label_PhanTram.Visible = false;
            thunderGroupBox1.Visible = true;
            for (int i = 0; i < 1500; i += 40)
            {
                var a = new Label();

                a.Text = i.ToString();
                a.AutoSize = (true);
                Size = (new global::System.Drawing.Size(58, 20));
                a.Location = (new global::System.Drawing.Point(50 + i, 318));
                //new Point()
                a.BackColor = Color.CornflowerBlue;
                //  a.Text = ("       ");
                DV_Panel_HienThiDV.Controls.Add(a);
                buttonCustom5.Text = a.Text;
            }



        }

        private void bigLabel14_Click(object sender, EventArgs e)
        {

        }

        private void buttonCustom12_Click(object sender, EventArgs e)
        {

        }

        private void buttonCustom12_Click_1(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_L.Visible = true;
            Content.Controls.Add(Panel_L);
        }

        private void bigLabel12_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_NV.Visible = true;
            Content.Controls.Add(Panel_NV);
        }

        private void ThongKe_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_ThongKe.Visible = true;
            Content.Controls.Add(Panel_ThongKe);
        }

        private void QL_ThanhToan_Click(object sender, EventArgs e)
        {
            //Content.Controls.Clear();
            //Panel_TT.Visible = true;
            //Content.Controls.Add(Panel_TT);
        }

        private void poisonDataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
