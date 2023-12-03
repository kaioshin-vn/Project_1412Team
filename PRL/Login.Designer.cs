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
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Login_pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // PhoneNumber
            // 
            PhoneNumber.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PhoneNumber.Location = new Point(312, 354);
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.PlaceholderText = "Số điện thoại";
            PhoneNumber.Size = new Size(402, 27);
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
            Password.PasswordChar = '☢';
            Password.PlaceholderText = "Mật khẩu";
            Password.Size = new Size(402, 27);
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
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(963, 656);
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
    }
}