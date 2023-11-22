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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            name_clinic = new Panel();
            label1 = new Label();
            Navigation = new Panel();
            label3 = new Label();
            label2 = new Label();
            buttonCustom1 = new ButtonCustom();
            ThongBao = new Label();
            LoiChao = new Label();
            Content = new Panel();
            bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            bunifuRange2 = new Bunifu.Framework.UI.BunifuRange();
            bunifuTrackbar1 = new Bunifu.Framework.UI.BunifuTrackbar();
            bunifuTileButton1 = new Bunifu.Framework.UI.BunifuTileButton();
            bunifuThinButton21 = new Bunifu.Framework.UI.BunifuThinButton2();
            bunifuRange1 = new Bunifu.Framework.UI.BunifuRange();
            Panel_KH = new Panel();
            QLKh_ff = new Label();
            Panel_NV = new Panel();
            label4 = new Label();
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
            Content.SuspendLayout();
            bunifuCards1.SuspendLayout();
            Panel_KH.SuspendLayout();
            Panel_NV.SuspendLayout();
            Nav_Option.SuspendLayout();
            SuspendLayout();
            // 
            // name_clinic
            // 
            name_clinic.BackColor = Color.LavenderBlush;
            name_clinic.BorderStyle = BorderStyle.FixedSingle;
            name_clinic.Controls.Add(label1);
            name_clinic.Location = new Point(-5, -8);
            name_clinic.Name = "name_clinic";
            name_clinic.Size = new Size(284, 65);
            name_clinic.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Harlow Solid Italic", 19.8000011F, FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(52, 17);
            label1.Name = "label1";
            label1.Size = new Size(189, 43);
            label1.TabIndex = 0;
            label1.Text = "1412 Sugery";
            label1.Click += label1_Click;
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
            Navigation.Location = new Point(276, -8);
            Navigation.Name = "Navigation";
            Navigation.Size = new Size(1430, 65);
            Navigation.TabIndex = 1;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Tomato;
            label3.Location = new Point(994, 24);
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
            label2.Location = new Point(870, 24);
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
            buttonCustom1.Location = new Point(1234, 15);
            buttonCustom1.Name = "buttonCustom1";
            buttonCustom1.Size = new Size(144, 41);
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
            ThongBao.Location = new Point(1106, 23);
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
            Content.BackColor = Color.LavenderBlush;
            Content.BorderStyle = BorderStyle.FixedSingle;
            Content.Controls.Add(bunifuCards1);
            Content.Controls.Add(bunifuRange1);
            Content.Location = new Point(276, 56);
            Content.Name = "Content";
            Content.Size = new Size(1395, 722);
            Content.TabIndex = 2;
            // 
            // bunifuCards1
            // 
            bunifuCards1.BackColor = Color.White;
            bunifuCards1.BorderRadius = 5;
            bunifuCards1.BottomSahddow = true;
            bunifuCards1.BottomShadow = true;
            bunifuCards1.color = Color.Tomato;
            bunifuCards1.Controls.Add(bunifuRange2);
            bunifuCards1.Controls.Add(bunifuTrackbar1);
            bunifuCards1.Controls.Add(bunifuTileButton1);
            bunifuCards1.Controls.Add(bunifuThinButton21);
            bunifuCards1.IndicatorColor = Color.Tomato;
            bunifuCards1.LeftSahddow = false;
            bunifuCards1.LeftShadow = false;
            bunifuCards1.Location = new Point(337, 129);
            bunifuCards1.Name = "bunifuCards1";
            bunifuCards1.RightSahddow = true;
            bunifuCards1.RightShadow = true;
            bunifuCards1.ShadowDepth = 20;
            bunifuCards1.Size = new Size(756, 496);
            bunifuCards1.TabIndex = 1;
            // 
            // bunifuRange2
            // 
            bunifuRange2.BackColor = Color.Transparent;
            bunifuRange2.BackgroudColor = Color.DarkGray;
            bunifuRange2.BorderRadius = 0;
            bunifuRange2.IndicatorColor = Color.SeaGreen;
            bunifuRange2.Location = new Point(53, 273);
            bunifuRange2.Margin = new Padding(4, 5, 4, 5);
            bunifuRange2.MaximumRange = 100;
            bunifuRange2.Name = "bunifuRange2";
            bunifuRange2.RangeMax = 48;
            bunifuRange2.RangeMin = 0;
            bunifuRange2.Size = new Size(691, 41);
            bunifuRange2.TabIndex = 4;
            // 
            // bunifuTrackbar1
            // 
            bunifuTrackbar1.BackColor = Color.Transparent;
            bunifuTrackbar1.BackgroudColor = Color.DarkGray;
            bunifuTrackbar1.BorderRadius = 0;
            bunifuTrackbar1.IndicatorColor = Color.SeaGreen;
            bunifuTrackbar1.Location = new Point(289, 17);
            bunifuTrackbar1.Margin = new Padding(4, 5, 4, 5);
            bunifuTrackbar1.MaximumValue = 100;
            bunifuTrackbar1.MinimumValue = 0;
            bunifuTrackbar1.Name = "bunifuTrackbar1";
            bunifuTrackbar1.Size = new Size(691, 41);
            bunifuTrackbar1.SliderRadius = 0;
            bunifuTrackbar1.TabIndex = 3;
            bunifuTrackbar1.Value = 0;
            // 
            // bunifuTileButton1
            // 
            bunifuTileButton1.BackColor = Color.SeaGreen;
            bunifuTileButton1.color = Color.SeaGreen;
            bunifuTileButton1.colorActive = Color.MediumSeaGreen;
            bunifuTileButton1.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            bunifuTileButton1.ForeColor = Color.White;
            bunifuTileButton1.Image = (Image)resources.GetObject("bunifuTileButton1.Image");
            bunifuTileButton1.ImagePosition = 20;
            bunifuTileButton1.ImageZoom = 50;
            bunifuTileButton1.LabelPosition = 41;
            bunifuTileButton1.LabelText = "Tile 1";
            bunifuTileButton1.Location = new Point(168, 205);
            bunifuTileButton1.Margin = new Padding(6);
            bunifuTileButton1.Name = "bunifuTileButton1";
            bunifuTileButton1.Size = new Size(339, 67);
            bunifuTileButton1.TabIndex = 2;
            // 
            // bunifuThinButton21
            // 
            bunifuThinButton21.ActiveBorderThickness = 1;
            bunifuThinButton21.ActiveCornerRadius = 20;
            bunifuThinButton21.ActiveFillColor = Color.SeaGreen;
            bunifuThinButton21.ActiveForecolor = Color.White;
            bunifuThinButton21.ActiveLineColor = Color.SeaGreen;
            bunifuThinButton21.BackColor = Color.White;
            bunifuThinButton21.BackgroundImage = (Image)resources.GetObject("bunifuThinButton21.BackgroundImage");
            bunifuThinButton21.ButtonText = "ThinButton";
            bunifuThinButton21.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            bunifuThinButton21.ForeColor = Color.SeaGreen;
            bunifuThinButton21.IdleBorderThickness = 1;
            bunifuThinButton21.IdleCornerRadius = 20;
            bunifuThinButton21.IdleFillColor = Color.White;
            bunifuThinButton21.IdleForecolor = Color.SeaGreen;
            bunifuThinButton21.IdleLineColor = Color.SeaGreen;
            bunifuThinButton21.Location = new Point(64, 133);
            bunifuThinButton21.Margin = new Padding(5);
            bunifuThinButton21.Name = "bunifuThinButton21";
            bunifuThinButton21.Size = new Size(226, 51);
            bunifuThinButton21.TabIndex = 1;
            bunifuThinButton21.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bunifuRange1
            // 
            bunifuRange1.BackColor = Color.Transparent;
            bunifuRange1.BackgroudColor = Color.DarkGray;
            bunifuRange1.BorderRadius = 0;
            bunifuRange1.IndicatorColor = Color.SeaGreen;
            bunifuRange1.Location = new Point(165, 214);
            bunifuRange1.Margin = new Padding(4, 5, 4, 5);
            bunifuRange1.MaximumRange = 100;
            bunifuRange1.Name = "bunifuRange1";
            bunifuRange1.RangeMax = 48;
            bunifuRange1.RangeMin = 0;
            bunifuRange1.Size = new Size(691, 41);
            bunifuRange1.TabIndex = 0;
            // 
            // Panel_KH
            // 
            Panel_KH.Controls.Add(QLKh_ff);
            Panel_KH.Location = new Point(35, 30);
            Panel_KH.Name = "Panel_KH";
            Panel_KH.Size = new Size(1345, 673);
            Panel_KH.TabIndex = 0;
            Panel_KH.Visible = false;
            // 
            // QLKh_ff
            // 
            QLKh_ff.AutoSize = true;
            QLKh_ff.Location = new Point(434, 182);
            QLKh_ff.Name = "QLKh_ff";
            QLKh_ff.Size = new Size(86, 20);
            QLKh_ff.TabIndex = 0;
            QLKh_ff.Text = "Khách hàng";
            // 
            // Panel_NV
            // 
            Panel_NV.Controls.Add(label4);
            Panel_NV.Location = new Point(35, 17);
            Panel_NV.Name = "Panel_NV";
            Panel_NV.Size = new Size(1332, 686);
            Panel_NV.TabIndex = 0;
            Panel_NV.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(575, 213);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 9;
            label4.Text = "Nhân viên";
            label4.Click += label4_Click;
            // 
            // Nav_Option
            // 
            Nav_Option.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            Nav_Option.BackColor = Color.FromArgb(128, 255, 230);
            Nav_Option.BorderStyle = BorderStyle.FixedSingle;
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
            Controls.Add(name_clinic);
            Controls.Add(Nav_Option);
            Controls.Add(Content);
            Controls.Add(Navigation);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Admin";
            Text = "1412_Team";
            Load += Admin_Load;
            VisibleChanged += Admin_VisibleChanged;
            name_clinic.ResumeLayout(false);
            name_clinic.PerformLayout();
            Navigation.ResumeLayout(false);
            Navigation.PerformLayout();
            Content.ResumeLayout(false);
            bunifuCards1.ResumeLayout(false);
            Panel_KH.ResumeLayout(false);
            Panel_KH.PerformLayout();
            Panel_NV.ResumeLayout(false);
            Panel_NV.PerformLayout();
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
        private Panel Panel_NV;
        private Label label4;
        private Panel Panel_KH;
        private Label QLKh_ff;
        private Bunifu.Framework.UI.BunifuRange bunifuRange1;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private Bunifu.Framework.UI.BunifuRange bunifuRange2;
        private Bunifu.Framework.UI.BunifuTrackbar bunifuTrackbar1;
        private Bunifu.Framework.UI.BunifuTileButton bunifuTileButton1;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton21;
    }
}