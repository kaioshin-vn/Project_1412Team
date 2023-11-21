using PRL.Tool;

namespace PRL
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            name_clinic = new Panel();
            label1 = new Label();
            Navigation = new Panel();
            label3 = new Label();
            label2 = new Label();
            buttonCustom1 = new ButtonCustom();
            ThongBao = new Label();
            LoiChao = new Label();
            Content = new Panel();
            Nav_Option = new Panel();
            ThongKe = new Label();
            QL_LichKham = new Label();
            QL_Luong = new Label();
            QL_DV = new Label();
            ThanhToan = new Label();
            QL_KH = new Label();
            QL_NV = new Label();
            name_clinic.SuspendLayout();
            Navigation.SuspendLayout();
            Nav_Option.SuspendLayout();
            SuspendLayout();
            // 
            // name_clinic
            // 
            name_clinic.BackColor = Color.FromArgb(1, 210, 210);
            name_clinic.Controls.Add(label1);
            name_clinic.Location = new Point(-5, -8);
            name_clinic.Name = "name_clinic";
            name_clinic.Size = new Size(316, 65);
            name_clinic.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Harlow Solid Italic", 18F, FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkRed;
            label1.Location = new Point(52, 17);
            label1.Name = "label1";
            label1.Size = new Size(148, 38);
            label1.TabIndex = 0;
            label1.Text = "1412 Clinic";
            label1.Click += label1_Click;
            // 
            // Navigation
            // 
            Navigation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Navigation.BackColor = Color.FromArgb(128, 255, 230);
            Navigation.Controls.Add(label3);
            Navigation.Controls.Add(label2);
            Navigation.Controls.Add(buttonCustom1);
            Navigation.Controls.Add(ThongBao);
            Navigation.Controls.Add(LoiChao);
            Navigation.Location = new Point(279, -8);
            Navigation.Name = "Navigation";
            Navigation.Size = new Size(1427, 65);
            Navigation.TabIndex = 1;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Tomato;
            label3.Location = new Point(993, 24);
            label3.Name = "label3";
            label3.Size = new Size(84, 25);
            label3.TabIndex = 4;
            label3.Text = "Trợ Giúp";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Tomato;
            label2.Location = new Point(869, 24);
            label2.Name = "label2";
            label2.Size = new Size(89, 25);
            label2.TabIndex = 3;
            label2.Text = "Tài khoản";
            // 
            // buttonCustom1
            // 
            buttonCustom1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCustom1.BackColor = Color.LawnGreen;
            buttonCustom1.BackgroundColor = Color.LawnGreen;
            buttonCustom1.BorderColor = Color.PaleVioletRed;
            buttonCustom1.BorderRadius = 20;
            buttonCustom1.BorderSize = 2;
            buttonCustom1.FlatAppearance.BorderSize = 0;
            buttonCustom1.FlatStyle = FlatStyle.Flat;
            buttonCustom1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCustom1.ForeColor = Color.LightCoral;
            buttonCustom1.Location = new Point(1233, 15);
            buttonCustom1.Name = "buttonCustom1";
            buttonCustom1.Size = new Size(144, 43);
            buttonCustom1.TabIndex = 2;
            buttonCustom1.Text = "Đăng Xuất";
            buttonCustom1.TextColor = Color.LightCoral;
            buttonCustom1.UseVisualStyleBackColor = false;
            // 
            // ThongBao
            // 
            ThongBao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            ThongBao.AutoSize = true;
            ThongBao.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            ThongBao.ForeColor = Color.Tomato;
            ThongBao.Location = new Point(1105, 23);
            ThongBao.Name = "ThongBao";
            ThongBao.Size = new Size(101, 25);
            ThongBao.TabIndex = 1;
            ThongBao.Text = "Thông Báo";
            // 
            // LoiChao
            // 
            LoiChao.AutoSize = true;
            LoiChao.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            LoiChao.ForeColor = Color.Crimson;
            LoiChao.Location = new Point(264, 22);
            LoiChao.Name = "LoiChao";
            LoiChao.Size = new Size(179, 29);
            LoiChao.TabIndex = 0;
            LoiChao.Text = "Xin chào đại ca !";
            // 
            // Content
            // 
            Content.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Content.BackColor = Color.FromArgb(1, 210, 210);
            Content.Location = new Point(276, 56);
            Content.Name = "Content";
            Content.Size = new Size(1395, 722);
            Content.TabIndex = 2;
            // 
            // Nav_Option
            // 
            Nav_Option.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            Nav_Option.BackColor = Color.FromArgb(128, 255, 230);
            Nav_Option.Controls.Add(ThongKe);
            Nav_Option.Controls.Add(QL_LichKham);
            Nav_Option.Controls.Add(QL_Luong);
            Nav_Option.Controls.Add(QL_DV);
            Nav_Option.Controls.Add(ThanhToan);
            Nav_Option.Controls.Add(QL_KH);
            Nav_Option.Controls.Add(QL_NV);
            Nav_Option.Location = new Point(-5, 56);
            Nav_Option.Name = "Nav_Option";
            Nav_Option.Size = new Size(284, 745);
            Nav_Option.TabIndex = 1;
            // 
            // ThongKe
            // 
            ThongKe.AutoSize = true;
            ThongKe.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            ThongKe.Image = Properties.Resources.icons8_analyst_64;
            ThongKe.ImageAlign = ContentAlignment.MiddleLeft;
            ThongKe.Location = new Point(52, 449);
            ThongKe.Name = "ThongKe";
            ThongKe.Size = new Size(167, 32);
            ThongKe.TabIndex = 8;
            ThongKe.Text = "     Thống kê";
            // 
            // QL_LichKham
            // 
            QL_LichKham.AutoSize = true;
            QL_LichKham.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            QL_LichKham.Image = Properties.Resources.icons8_document_42;
            QL_LichKham.ImageAlign = ContentAlignment.MiddleLeft;
            QL_LichKham.Location = new Point(43, 189);
            QL_LichKham.Name = "QL_LichKham";
            QL_LichKham.Size = new Size(220, 32);
            QL_LichKham.TabIndex = 7;
            QL_LichKham.Text = "     QL Lịch Khám";
            QL_LichKham.Click += QL_LichKham_Click;
            // 
            // QL_Luong
            // 
            QL_Luong.AutoSize = true;
            QL_Luong.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            QL_Luong.Image = Properties.Resources.icons8_salary_80;
            QL_Luong.ImageAlign = ContentAlignment.MiddleLeft;
            QL_Luong.Location = new Point(52, 369);
            QL_Luong.Name = "QL_Luong";
            QL_Luong.Size = new Size(183, 32);
            QL_Luong.TabIndex = 4;
            QL_Luong.Text = "     QL Lương ";
            // 
            // QL_DV
            // 
            QL_DV.AutoSize = true;
            QL_DV.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            QL_DV.Image = Properties.Resources.icons8_service_341;
            QL_DV.ImageAlign = ContentAlignment.MiddleLeft;
            QL_DV.Location = new Point(51, 280);
            QL_DV.Name = "QL_DV";
            QL_DV.Size = new Size(196, 32);
            QL_DV.TabIndex = 3;
            QL_DV.Text = "     QL Dịch Vụ";
            // 
            // ThanhToan
            // 
            ThanhToan.AutoSize = true;
            ThanhToan.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            ThanhToan.Image = Properties.Resources.icons8_bill_64;
            ThanhToan.ImageAlign = ContentAlignment.MiddleLeft;
            ThanhToan.Location = new Point(43, 524);
            ThanhToan.Name = "ThanhToan";
            ThanhToan.Size = new Size(204, 32);
            ThanhToan.TabIndex = 2;
            ThanhToan.Text = "      Thanh Toán";
            // 
            // QL_KH
            // 
            QL_KH.AutoSize = true;
            QL_KH.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            QL_KH.Image = Properties.Resources.icons8_customer_43;
            QL_KH.ImageAlign = ContentAlignment.MiddleLeft;
            QL_KH.Location = new Point(43, 97);
            QL_KH.Name = "QL_KH";
            QL_KH.Size = new Size(237, 32);
            QL_KH.TabIndex = 1;
            QL_KH.Text = "     QL Khách Hàng";
            QL_KH.Click += QL_KH_Click;
            // 
            // QL_NV
            // 
            QL_NV.AutoSize = true;
            QL_NV.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            QL_NV.Image = Properties.Resources.icons8_crowd_34;
            QL_NV.ImageAlign = ContentAlignment.MiddleLeft;
            QL_NV.Location = new Point(43, 17);
            QL_NV.Name = "QL_NV";
            QL_NV.Size = new Size(216, 32);
            QL_NV.TabIndex = 0;
            QL_NV.Text = "     QL Nhân viên";
            QL_NV.Click += label3_Click;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1668, 771);
            Controls.Add(Nav_Option);
            Controls.Add(Content);
            Controls.Add(Navigation);
            Controls.Add(name_clinic);
            Name = "Admin";
            Text = "Admin";
            Load += Admin_Load;
            name_clinic.ResumeLayout(false);
            name_clinic.PerformLayout();
            Navigation.ResumeLayout(false);
            Navigation.PerformLayout();
            Nav_Option.ResumeLayout(false);
            Nav_Option.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel name_clinic;
        private Panel Navigation;
        private Label label1;
        private Panel Content;
        private Panel Nav_Option;
        private Label QL_KH;
        private Label QL_NV;
        private Label QL_DV;
        private Label QL_Luong;
        private Label QL_LichKham;
        private Label ThongKe;
        private Label ThanhToan;
        private ButtonCustom buttonCustom1;
        private Label ThongBao;
        private Label LoiChao;
        private Label label2;
        private Label label3;
    }
}