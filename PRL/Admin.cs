﻿using DAL.Models;
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
        NhanVien user  ;
        Login FormLogin;
        bool DV_Status_Btn_OKThem = false;
        ///


        private void Admin_Load(object sender, EventArgs e)
        {
           // Panel_DV.Visible = false;
            Content.Controls.Clear();
            Panel_ManHinhCho.Visible = true;
            Content.Controls.Add(Panel_ManHinhCho);
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
         //   Panel_DV.Visible = false;
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
            DV_Label_PhanTram.Text = $"{100 - DV_.RangeMin} %";
        }

        private void buttonCustom7_Click(object sender, EventArgs e)
        {
            thunderGroupBox1.Visible = false;
            DV_Btn_OKGiamGia.Visible = true;
            DV_.Visible = true;
            DV_Label_PhanTram.Visible = true;
        }

        private void buttonCustom9_Click(object sender, EventArgs e)
        {
            DV_Btn_OKGiamGia.Visible = false;
            DV_.Visible = false;
            DV_Label_PhanTram.Visible = false;
            thunderGroupBox1.Visible = true;
        }

        private void buttonCustom5_Click(object sender, EventArgs e)
        {
            DV_Btn_OKGiamGia.Visible = false;
            DV_.Visible = false;
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
            //checkedListBox1.
        }

        private void ThanhToan_Click(object sender, EventArgs e)
        {

        }
        private void QL_ThanhToan_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_TT.Visible = true;
            Content.Controls.Add(Panel_TT);
        }
        private void poisonDataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bigLabel20_Click(object sender, EventArgs e)
        {

        }

        private void Panel_TK_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
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

        private void label3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy bắn 50k vào tài khoản 0978040960 MB Bank để được hỗ trợ bạn nhé !!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void TT_Label_ThoiGian_Click(object sender, EventArgs e)
        {

        }

        private void txtGiaTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void Nav_Option_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
