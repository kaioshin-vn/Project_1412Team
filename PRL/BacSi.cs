using B_BUS.Services;
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
    public partial class BacSi : Form
    {
        private TimekeepingService _timekeepsv;
        public BacSi(NhanVien staff, Login login)
        {
            FormLogin = login;
            user = staff;
            InitializeComponent();
            _timekeepsv = new TimekeepingService();
        }

        public BacSi()
        {
            InitializeComponent();
        }

        NhanVien user;
        Login FormLogin;

        private void Admin_Load(object sender, EventArgs e)
        {
            Content.Controls.Clear();
        }


        private void label3_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_NV.Visible = true;
            Content.Controls.Add(Panel_NV);

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



        private void Import_Click(object sender, EventArgs e)
        {
            //List<TimeKeeping> = new List<TimeKeeping>();
        }

        private void QL_Luong_Click(object sender, EventArgs e)
        {
            Content.Controls.Clear();
            Panel_ChamCong.Visible = true;
            Content.Controls.Add(Panel_ChamCong);
        }
    }
}
