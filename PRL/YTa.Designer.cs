namespace C_PRL
{
    partial class YTa
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
            Nav_Option = new Panel();
            KetQuaKham = new Label();
            QL_LichKham = new Label();
            QL_Luong = new Label();
            QL_DV = new Label();
            ThanhToan = new Label();
            QL_NV = new Label();
            Navigation = new Panel();
            label3 = new Label();
            label2 = new Label();
            buttonCustom1 = new PRL.Tool.ButtonCustom();
            ThongBao = new Label();
            LoiChao = new Label();
            Panel_ = new Panel();
            label4 = new Label();
            name_clinic.SuspendLayout();
            Nav_Option.SuspendLayout();
            Navigation.SuspendLayout();
            SuspendLayout();
            // 
            // name_clinic
            // 
            name_clinic.BackColor = Color.LavenderBlush;
            name_clinic.BorderStyle = BorderStyle.FixedSingle;
            name_clinic.Controls.Add(label1);
            name_clinic.Location = new Point(0, 0);
            name_clinic.Margin = new Padding(3, 2, 3, 2);
            name_clinic.Name = "name_clinic";
            name_clinic.Size = new Size(249, 49);
            name_clinic.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Harlow Solid Italic", 19.8000011F, FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(46, 13);
            label1.Name = "label1";
            label1.Size = new Size(151, 34);
            label1.TabIndex = 0;
            label1.Text = "1412 Sugery";
            // 
            // Nav_Option
            // 
            Nav_Option.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            Nav_Option.BackColor = Color.FromArgb(128, 255, 230);
            Nav_Option.BorderStyle = BorderStyle.FixedSingle;
            Nav_Option.Controls.Add(label4);
            Nav_Option.Controls.Add(KetQuaKham);
            Nav_Option.Controls.Add(QL_LichKham);
            Nav_Option.Controls.Add(QL_Luong);
            Nav_Option.Controls.Add(QL_DV);
            Nav_Option.Controls.Add(ThanhToan);
            Nav_Option.Controls.Add(QL_NV);
            Nav_Option.Location = new Point(0, 50);
            Nav_Option.Margin = new Padding(3, 2, 3, 2);
            Nav_Option.Name = "Nav_Option";
            Nav_Option.Size = new Size(249, 699);
            Nav_Option.TabIndex = 2;
            // 
            // KetQuaKham
            // 
            KetQuaKham.AutoSize = true;
            KetQuaKham.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            KetQuaKham.Image = Properties.Resources.icons8_customer_43;
            KetQuaKham.ImageAlign = ContentAlignment.MiddleLeft;
            KetQuaKham.Location = new Point(24, 356);
            KetQuaKham.Name = "KetQuaKham";
            KetQuaKham.Size = new Size(218, 27);
            KetQuaKham.TabIndex = 8;
            KetQuaKham.Text = "     Trả kết quả khám";
            KetQuaKham.Click += ThongKe_Click;
            // 
            // QL_LichKham
            // 
            QL_LichKham.AutoSize = true;
            QL_LichKham.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            QL_LichKham.Image = Properties.Resources.icons8_document_42;
            QL_LichKham.ImageAlign = ContentAlignment.MiddleLeft;
            QL_LichKham.Location = new Point(38, 80);
            QL_LichKham.Name = "QL_LichKham";
            QL_LichKham.Size = new Size(180, 27);
            QL_LichKham.TabIndex = 7;
            QL_LichKham.Text = "     QL Lịch Khám";
            // 
            // QL_Luong
            // 
            QL_Luong.AutoSize = true;
            QL_Luong.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            QL_Luong.Image = Properties.Resources.icons8_salary_80;
            QL_Luong.ImageAlign = ContentAlignment.MiddleLeft;
            QL_Luong.Location = new Point(46, 217);
            QL_Luong.Name = "QL_Luong";
            QL_Luong.Size = new Size(149, 27);
            QL_Luong.TabIndex = 4;
            QL_Luong.Text = "     QL Lương ";
            // 
            // QL_DV
            // 
            QL_DV.AutoSize = true;
            QL_DV.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            QL_DV.Image = Properties.Resources.icons8_service_341;
            QL_DV.ImageAlign = ContentAlignment.MiddleLeft;
            QL_DV.Location = new Point(46, 149);
            QL_DV.Name = "QL_DV";
            QL_DV.Size = new Size(160, 27);
            QL_DV.TabIndex = 3;
            QL_DV.Text = "     QL Dịch Vụ";
            // 
            // ThanhToan
            // 
            ThanhToan.AutoSize = true;
            ThanhToan.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            ThanhToan.Image = Properties.Resources.icons8_bill_64;
            ThanhToan.ImageAlign = ContentAlignment.MiddleLeft;
            ThanhToan.Location = new Point(38, 286);
            ThanhToan.Name = "ThanhToan";
            ThanhToan.Size = new Size(184, 27);
            ThanhToan.TabIndex = 2;
            ThanhToan.Text = "        Thanh Toán";
            // 
            // QL_NV
            // 
            QL_NV.AutoSize = true;
            QL_NV.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            QL_NV.Image = Properties.Resources.icons8_crowd_34;
            QL_NV.ImageAlign = ContentAlignment.MiddleLeft;
            QL_NV.Location = new Point(38, 13);
            QL_NV.Name = "QL_NV";
            QL_NV.Size = new Size(196, 27);
            QL_NV.TabIndex = 0;
            QL_NV.Text = "     QL Khách Hàng";
            // 
            // Navigation
            // 
            Navigation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Navigation.BackColor = Color.FromArgb(128, 255, 230);
            Navigation.BorderStyle = BorderStyle.FixedSingle;
            Navigation.Controls.Add(label3);
            Navigation.Controls.Add(label2);
            Navigation.Controls.Add(buttonCustom1);
            Navigation.Controls.Add(ThongBao);
            Navigation.Controls.Add(LoiChao);
            Navigation.Location = new Point(248, 0);
            Navigation.Margin = new Padding(3, 2, 3, 2);
            Navigation.Name = "Navigation";
            Navigation.Size = new Size(1121, 49);
            Navigation.TabIndex = 3;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Tomato;
            label3.Location = new Point(1835, 18);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 4;
            label3.Text = "Trợ Giúp";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Tomato;
            label2.Location = new Point(1727, 18);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 3;
            label2.Text = "Tài khoản";
            // 
            // buttonCustom1
            // 
            buttonCustom1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCustom1.BackColor = Color.LawnGreen;
            buttonCustom1.BackgroundColor = Color.LawnGreen;
            buttonCustom1.BorderColor = Color.PaleVioletRed;
            buttonCustom1.BorderRadius = 0;
            buttonCustom1.BorderSize = 2;
            buttonCustom1.FlatAppearance.BorderSize = 0;
            buttonCustom1.FlatStyle = FlatStyle.Flat;
            buttonCustom1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCustom1.ForeColor = Color.LightCoral;
            buttonCustom1.Location = new Point(2045, 11);
            buttonCustom1.Margin = new Padding(3, 2, 3, 2);
            buttonCustom1.Name = "buttonCustom1";
            buttonCustom1.Size = new Size(126, 0);
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
            ThongBao.Location = new Point(1933, 17);
            ThongBao.Name = "ThongBao";
            ThongBao.Size = new Size(83, 20);
            ThongBao.TabIndex = 1;
            ThongBao.Text = "Thông Báo";
            // 
            // LoiChao
            // 
            LoiChao.AutoSize = true;
            LoiChao.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            LoiChao.ForeColor = Color.Crimson;
            LoiChao.Location = new Point(231, 16);
            LoiChao.Name = "LoiChao";
            LoiChao.Size = new Size(140, 23);
            LoiChao.TabIndex = 0;
            LoiChao.Text = "Xin chào đại ca !";
            // 
            // Panel_
            // 
            Panel_.BackColor = Color.PapayaWhip;
            Panel_.Location = new Point(248, 50);
            Panel_.Margin = new Padding(3, 2, 3, 2);
            Panel_.Name = "Panel_";
            Panel_.Size = new Size(1121, 701);
            Panel_.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Image = Properties.Resources.icons8_eye_open_35;
            label4.ImageAlign = ContentAlignment.MiddleLeft;
            label4.Location = new Point(38, 420);
            label4.Name = "label4";
            label4.Size = new Size(167, 27);
            label4.TabIndex = 9;
            label4.Text = "     QL Đánh giá";
            // 
            // YTa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(Panel_);
            Controls.Add(Navigation);
            Controls.Add(Nav_Option);
            Controls.Add(name_clinic);
            Name = "YTa";
            Text = "YTa";
            Load += YTa_Load;
            name_clinic.ResumeLayout(false);
            name_clinic.PerformLayout();
            Nav_Option.ResumeLayout(false);
            Nav_Option.PerformLayout();
            Navigation.ResumeLayout(false);
            Navigation.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel name_clinic;
        private Label label1;
        private Panel Nav_Option;
        private Label KetQuaKham;
        private Label QL_LichKham;
        private Label QL_Luong;
        private Label QL_DV;
        private Label ThanhToan;
        private Label QL_NV;
        private Panel Navigation;
        private Label label3;
        private Label label2;
        private PRL.Tool.ButtonCustom buttonCustom1;
        private Label ThongBao;
        private Label LoiChao;
        private Panel Panel_;
        private Label label4;
    }
}