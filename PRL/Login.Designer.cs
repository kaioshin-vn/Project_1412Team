namespace PRL
{
    partial class Login
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            PhoneNumber = new TextBox();
            Login_lbl_SDT = new Label();
            Lb_pass = new Label();
            Password = new TextBox();
            checkBox1 = new CheckBox();
            Visible_Pass = new Label();
            Forget_Pass = new Label();
            Login_Btn_DangNhap = new Tool.ButtonCustom();
            errorProvider1 = new ErrorProvider(components);
            Login_pictureBox1 = new PictureBox();
            Login_Title = new Label();
            Login_Btn_Thoat = new Tool.ButtonCustom();
            panel1 = new Panel();
            DN_btn_XacNhan = new Tool.ButtonCustom();
            DN_btn_huy = new ReaLTaiizor.Controls.DungeonLinkLabel();
            label2 = new Label();
            label1 = new Label();
            DN_Cc = new ReaLTaiizor.Controls.BigTextBox();
            DN_Sdt = new ReaLTaiizor.Controls.BigTextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            panel2 = new Panel();
            DN_ChoXN = new ReaLTaiizor.Controls.BigLabel();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Login_pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // PhoneNumber
            // 
            PhoneNumber.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PhoneNumber.Location = new Point(312, 354);
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.PlaceholderText = "Số điện thoại";
            PhoneNumber.Size = new Size(412, 27);
            PhoneNumber.TabIndex = 0;
            PhoneNumber.TextChanged += textBox1_TextChanged;
            // 
            // Login_lbl_SDT
            // 
            Login_lbl_SDT.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Login_lbl_SDT.AutoSize = true;
            Login_lbl_SDT.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            Login_lbl_SDT.ForeColor = Color.DarkSlateGray;
            Login_lbl_SDT.Location = new Point(161, 356);
            Login_lbl_SDT.Name = "Login_lbl_SDT";
            Login_lbl_SDT.Size = new Size(135, 25);
            Login_lbl_SDT.TabIndex = 1;
            Login_lbl_SDT.Text = "Số Điện Thoại ";
            // 
            // Lb_pass
            // 
            Lb_pass.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Lb_pass.AutoSize = true;
            Lb_pass.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_pass.ForeColor = Color.DarkSlateGray;
            Lb_pass.Location = new Point(161, 406);
            Lb_pass.Name = "Lb_pass";
            Lb_pass.Size = new Size(93, 25);
            Lb_pass.TabIndex = 2;
            Lb_pass.Text = "Mật khẩu";
            // 
            // Password
            // 
            Password.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Password.Location = new Point(312, 407);
            Password.Name = "Password";
            Password.PasswordChar = '❤';
            Password.PlaceholderText = "Mật khẩu";
            Password.Size = new Size(412, 27);
            Password.TabIndex = 3;
            Password.TextChanged += Password_TextChanged;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox1.Location = new Point(312, 459);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(142, 27);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "Nhớ mật khẩu";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // Visible_Pass
            // 
            Visible_Pass.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Visible_Pass.AutoSize = true;
            Visible_Pass.Image = C_PRL.Properties.Resources.icons8_eye_open_35;
            Visible_Pass.Location = new Point(730, 414);
            Visible_Pass.Name = "Visible_Pass";
            Visible_Pass.Size = new Size(85, 20);
            Visible_Pass.TabIndex = 5;
            Visible_Pass.Text = "                   ";
            Visible_Pass.Click += Visible_Pass_Click;
            // 
            // Forget_Pass
            // 
            Forget_Pass.Anchor = AnchorStyles.Top;
            Forget_Pass.AutoSize = true;
            Forget_Pass.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            Forget_Pass.ForeColor = SystemColors.HotTrack;
            Forget_Pass.Location = new Point(582, 459);
            Forget_Pass.Name = "Forget_Pass";
            Forget_Pass.Size = new Size(132, 23);
            Forget_Pass.TabIndex = 6;
            Forget_Pass.Text = "Quên mật khẩu?";
            Forget_Pass.Click += Forget_Pass_Click;
            // 
            // Login_Btn_DangNhap
            // 
            Login_Btn_DangNhap.Anchor = AnchorStyles.Top;
            Login_Btn_DangNhap.BackColor = Color.DeepSkyBlue;
            Login_Btn_DangNhap.BackgroundColor = Color.DeepSkyBlue;
            Login_Btn_DangNhap.BorderColor = Color.Silver;
            Login_Btn_DangNhap.BorderRadius = 20;
            Login_Btn_DangNhap.BorderSize = 2;
            Login_Btn_DangNhap.FlatAppearance.BorderSize = 0;
            Login_Btn_DangNhap.FlatStyle = FlatStyle.Flat;
            Login_Btn_DangNhap.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            Login_Btn_DangNhap.ForeColor = Color.DarkSlateGray;
            Login_Btn_DangNhap.IDSelected = null;
            Login_Btn_DangNhap.Location = new Point(312, 522);
            Login_Btn_DangNhap.Name = "Login_Btn_DangNhap";
            Login_Btn_DangNhap.Size = new Size(160, 50);
            Login_Btn_DangNhap.TabIndex = 7;
            Login_Btn_DangNhap.Text = "Đăng Nhập";
            Login_Btn_DangNhap.TextColor = Color.DarkSlateGray;
            Login_Btn_DangNhap.UseVisualStyleBackColor = false;
            Login_Btn_DangNhap.Click += Login_Btn_DangNhap_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // Login_pictureBox1
            // 
            Login_pictureBox1.BackColor = Color.FromArgb(255, 224, 192);
            Login_pictureBox1.Image = (Image)resources.GetObject("Login_pictureBox1.Image");
            Login_pictureBox1.Location = new Point(327, 12);
            Login_pictureBox1.Name = "Login_pictureBox1";
            Login_pictureBox1.Size = new Size(321, 250);
            Login_pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Login_pictureBox1.TabIndex = 8;
            Login_pictureBox1.TabStop = false;
            Login_pictureBox1.Click += pictureBox1_Click;
            // 
            // Login_Title
            // 
            Login_Title.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Login_Title.AutoSize = true;
            Login_Title.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            Login_Title.ForeColor = Color.FromArgb(0, 192, 0);
            Login_Title.Location = new Point(343, 265);
            Login_Title.Name = "Login_Title";
            Login_Title.Size = new Size(305, 38);
            Login_Title.TabIndex = 9;
            Login_Title.Text = "Đăng Nhập Hệ Thống";
            // 
            // Login_Btn_Thoat
            // 
            Login_Btn_Thoat.Anchor = AnchorStyles.Top;
            Login_Btn_Thoat.BackColor = Color.DeepSkyBlue;
            Login_Btn_Thoat.BackgroundColor = Color.DeepSkyBlue;
            Login_Btn_Thoat.BorderColor = Color.Silver;
            Login_Btn_Thoat.BorderRadius = 20;
            Login_Btn_Thoat.BorderSize = 2;
            Login_Btn_Thoat.FlatAppearance.BorderSize = 0;
            Login_Btn_Thoat.FlatStyle = FlatStyle.Flat;
            Login_Btn_Thoat.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            Login_Btn_Thoat.ForeColor = Color.DarkSlateGray;
            Login_Btn_Thoat.IDSelected = null;
            Login_Btn_Thoat.Location = new Point(554, 522);
            Login_Btn_Thoat.Name = "Login_Btn_Thoat";
            Login_Btn_Thoat.Size = new Size(160, 50);
            Login_Btn_Thoat.TabIndex = 10;
            Login_Btn_Thoat.Text = "Thoát";
            Login_Btn_Thoat.TextColor = Color.DarkSlateGray;
            Login_Btn_Thoat.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(DN_btn_XacNhan);
            panel1.Controls.Add(DN_btn_huy);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(DN_Cc);
            panel1.Controls.Add(DN_Sdt);
            panel1.Location = new Point(161, 316);
            panel1.Name = "panel1";
            panel1.Size = new Size(668, 263);
            panel1.TabIndex = 11;
            panel1.Visible = false;
            // 
            // DN_btn_XacNhan
            // 
            DN_btn_XacNhan.BackColor = Color.DeepSkyBlue;
            DN_btn_XacNhan.BackgroundColor = Color.DeepSkyBlue;
            DN_btn_XacNhan.BorderColor = Color.MediumSeaGreen;
            DN_btn_XacNhan.BorderRadius = 20;
            DN_btn_XacNhan.BorderSize = 2;
            DN_btn_XacNhan.FlatAppearance.BorderSize = 0;
            DN_btn_XacNhan.FlatStyle = FlatStyle.Flat;
            DN_btn_XacNhan.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            DN_btn_XacNhan.ForeColor = Color.White;
            DN_btn_XacNhan.IDSelected = null;
            DN_btn_XacNhan.Location = new Point(236, 192);
            DN_btn_XacNhan.Name = "DN_btn_XacNhan";
            DN_btn_XacNhan.Size = new Size(188, 50);
            DN_btn_XacNhan.TabIndex = 5;
            DN_btn_XacNhan.Text = "Xác nhận";
            DN_btn_XacNhan.TextColor = Color.White;
            DN_btn_XacNhan.UseVisualStyleBackColor = false;
            DN_btn_XacNhan.Click += DN_btn_XacNhan_Click;
            // 
            // DN_btn_huy
            // 
            DN_btn_huy.ActiveLinkColor = Color.Red;
            DN_btn_huy.AutoSize = true;
            DN_btn_huy.BackColor = Color.Transparent;
            DN_btn_huy.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Italic, GraphicsUnit.Point);
            DN_btn_huy.LinkBehavior = LinkBehavior.AlwaysUnderline;
            DN_btn_huy.LinkColor = Color.Red;
            DN_btn_huy.Location = new Point(480, 206);
            DN_btn_huy.Name = "DN_btn_huy";
            DN_btn_huy.Size = new Size(54, 31);
            DN_btn_huy.TabIndex = 4;
            DN_btn_huy.TabStop = true;
            DN_btn_huy.Text = "Hủy";
            DN_btn_huy.VisitedLinkColor = Color.FromArgb(240, 119, 70);
            DN_btn_huy.LinkClicked += DN_btn_huy_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = Color.MediumTurquoise;
            label2.Location = new Point(43, 132);
            label2.Name = "label2";
            label2.Size = new Size(146, 38);
            label2.TabIndex = 3;
            label2.Text = "Căn cước ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.MediumTurquoise;
            label1.Location = new Point(43, 47);
            label1.Name = "label1";
            label1.Size = new Size(192, 38);
            label1.TabIndex = 2;
            label1.Text = "Số điện thoại";
            // 
            // DN_Cc
            // 
            DN_Cc.BackColor = Color.Transparent;
            DN_Cc.Font = new Font("Tahoma", 11F, FontStyle.Regular, GraphicsUnit.Point);
            DN_Cc.ForeColor = Color.DimGray;
            DN_Cc.Image = null;
            DN_Cc.Location = new Point(259, 124);
            DN_Cc.MaxLength = 32767;
            DN_Cc.Multiline = false;
            DN_Cc.Name = "DN_Cc";
            DN_Cc.ReadOnly = false;
            DN_Cc.Size = new Size(321, 46);
            DN_Cc.TabIndex = 1;
            DN_Cc.TextAlignment = HorizontalAlignment.Left;
            DN_Cc.UseSystemPasswordChar = false;
            // 
            // DN_Sdt
            // 
            DN_Sdt.BackColor = Color.Transparent;
            DN_Sdt.Font = new Font("Tahoma", 11F, FontStyle.Regular, GraphicsUnit.Point);
            DN_Sdt.ForeColor = Color.DimGray;
            DN_Sdt.Image = null;
            DN_Sdt.Location = new Point(259, 39);
            DN_Sdt.MaxLength = 32767;
            DN_Sdt.Multiline = false;
            DN_Sdt.Name = "DN_Sdt";
            DN_Sdt.ReadOnly = false;
            DN_Sdt.Size = new Size(321, 46);
            DN_Sdt.TabIndex = 0;
            DN_Sdt.TextAlignment = HorizontalAlignment.Left;
            DN_Sdt.UseSystemPasswordChar = false;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // panel2
            // 
            panel2.Controls.Add(DN_ChoXN);
            panel2.Location = new Point(95, 316);
            panel2.Name = "panel2";
            panel2.Size = new Size(744, 274);
            panel2.TabIndex = 12;
            panel2.Visible = false;
            // 
            // DN_ChoXN
            // 
            DN_ChoXN.AutoSize = true;
            DN_ChoXN.BackColor = Color.Transparent;
            DN_ChoXN.Font = new Font("Segoe UI Semibold", 25.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            DN_ChoXN.ForeColor = Color.FromArgb(80, 80, 80);
            DN_ChoXN.Location = new Point(178, 98);
            DN_ChoXN.Name = "DN_ChoXN";
            DN_ChoXN.Size = new Size(422, 57);
            DN_ChoXN.TabIndex = 0;
            DN_ChoXN.Text = "Đang chờ xác nhận...";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(963, 656);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(Login_Btn_Thoat);
            Controls.Add(Login_Title);
            Controls.Add(Login_pictureBox1);
            Controls.Add(Login_Btn_DangNhap);
            Controls.Add(Forget_Pass);
            Controls.Add(Visible_Pass);
            Controls.Add(checkBox1);
            Controls.Add(Password);
            Controls.Add(Lb_pass);
            Controls.Add(Login_lbl_SDT);
            Controls.Add(PhoneNumber);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            VisibleChanged += Login_VisibleChanged;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Login_pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox PhoneNumber;
        private Label Login_lbl_SDT;
        private Label Lb_pass;
        private TextBox Password;
        private CheckBox checkBox1;
        private Label Visible_Pass;
        private Label Forget_Pass;
        private Tool.ButtonCustom Login_Btn_DangNhap;
        private ErrorProvider errorProvider1;
        private Label Login_Title;
        private PictureBox Login_pictureBox1;
        private Tool.ButtonCustom Login_Btn_Thoat;
        private Panel panel1;
        private ReaLTaiizor.Controls.BigTextBox DN_Sdt;
        private ReaLTaiizor.Controls.DungeonLinkLabel DN_btn_huy;
        private Label label2;
        private Label label1;
        private ReaLTaiizor.Controls.BigTextBox DN_Cc;
        private Tool.ButtonCustom DN_btn_XacNhan;
        private System.Windows.Forms.Timer timer1;
        private Panel panel2;
        private ReaLTaiizor.Controls.BigLabel DN_ChoXN;
    }
}