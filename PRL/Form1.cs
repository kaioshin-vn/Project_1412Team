using B_BUS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_PRL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCustom1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                buttonCustom1.Text = "";
            }

            var selectedID = "1"; // ID của mục bạn muốn chọn
            comboBox1.SelectedValue = selectedID;
     
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonCustom1.Text = comboBox1.SelectedValue.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PhongSer phongSer = new PhongSer();
            var dataPhong = phongSer.GetAllPhong().Select(a =>
            {
                return new
                {
                    id = a.Id,
                    ten = a.LoaiPhong,
                };
            }).ToList();

            // Thiết lập dữ liệu cho ComboBox
            comboBox1.DisplayMember = "Name"; // Trường hiển thị
            comboBox1.ValueMember = "ID";     // Trường giá trị
            comboBox1.DataSource = dataPhong;

        }

        private void buttonCustom2_Click(object sender, EventArgs e)
        {
            buttonCustom1.Text =  comboBox1.SelectedValue.ToString();
        }
    }
}
