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
            PhoneNumber = new TextBox();
            label1 = new Label();
            Lb_pass = new Label();
            Password = new TextBox();
            checkBox1 = new CheckBox();
            Visible_Pass = new Label();
            Forget_Pass = new Label();
            Btn_Login = new Tool.ButtonCustom();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // PhoneNumber
            // 
            PhoneNumber.Location = new Point(306, 168);
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.PlaceholderText = "Số điện thoại";
            PhoneNumber.Size = new Size(330, 27);
            PhoneNumber.TabIndex = 0;
            PhoneNumber.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.MediumBlue;
            label1.Location = new Point(155, 170);
            label1.Name = "label1";
            label1.Size = new Size(130, 25);
            label1.TabIndex = 1;
            label1.Text = "Số Điện Thoại";
            // 
            // Lb_pass
            // 
            Lb_pass.AutoSize = true;
            Lb_pass.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_pass.ForeColor = Color.MediumBlue;
            Lb_pass.Location = new Point(155, 220);
            Lb_pass.Name = "Lb_pass";
            Lb_pass.Size = new Size(93, 25);
            Lb_pass.TabIndex = 2;
            Lb_pass.Text = "Mật khẩu";
            // 
            // Password
            // 
            Password.Location = new Point(306, 221);
            Password.Name = "Password";
            Password.PasswordChar = '☢';
            Password.PlaceholderText = "Mật khẩu";
            Password.Size = new Size(330, 27);
            Password.TabIndex = 3;
            Password.TextChanged += Password_TextChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox1.Location = new Point(306, 282);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(142, 27);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "Nhớ mật khẩu";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Visible_Pass
            // 
            Visible_Pass.AutoSize = true;
            Visible_Pass.Image = Properties.Resources.icons8_eye_open_35;
            Visible_Pass.Location = new Point(652, 228);
            Visible_Pass.Name = "Visible_Pass";
            Visible_Pass.Size = new Size(85, 20);
            Visible_Pass.TabIndex = 5;
            Visible_Pass.Text = "                   ";
            Visible_Pass.Click += Visible_Pass_Click;
            // 
            // Forget_Pass
            // 
            Forget_Pass.AutoSize = true;
            Forget_Pass.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Forget_Pass.ForeColor = SystemColors.HotTrack;
            Forget_Pass.Location = new Point(372, 421);
            Forget_Pass.Name = "Forget_Pass";
            Forget_Pass.Size = new Size(137, 23);
            Forget_Pass.TabIndex = 6;
            Forget_Pass.Text = "Quên mật khẩu?";
            Forget_Pass.Click += Forget_Pass_Click;
            // 
            // Btn_Login
            // 
            Btn_Login.BackColor = Color.Gainsboro;
            Btn_Login.BackgroundColor = Color.Gainsboro;
            Btn_Login.BorderColor = Color.HotPink;
            Btn_Login.BorderRadius = 20;
            Btn_Login.BorderSize = 2;
            Btn_Login.FlatAppearance.BorderSize = 0;
            Btn_Login.FlatStyle = FlatStyle.Flat;
            Btn_Login.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Login.ForeColor = Color.Crimson;
            Btn_Login.Location = new Point(348, 346);
            Btn_Login.Name = "Btn_Login";
            Btn_Login.Size = new Size(188, 50);
            Btn_Login.TabIndex = 7;
            Btn_Login.Text = "Đăng Nhập";
            Btn_Login.TextColor = Color.Crimson;
            Btn_Login.UseVisualStyleBackColor = false;
            Btn_Login.Click += Btn_Login_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGreen;
            ClientSize = new Size(891, 529);
            Controls.Add(Btn_Login);
            Controls.Add(Forget_Pass);
            Controls.Add(Visible_Pass);
            Controls.Add(checkBox1);
            Controls.Add(Password);
            Controls.Add(Lb_pass);
            Controls.Add(label1);
            Controls.Add(PhoneNumber);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            VisibleChanged += Login_VisibleChanged;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox PhoneNumber;
        private Label label1;
        private Label Lb_pass;
        private TextBox Password;
        private CheckBox checkBox1;
        private Label Visible_Pass;
        private Label Forget_Pass;
        private Tool.ButtonCustom Btn_Login;
        private ErrorProvider errorProvider1;
    }
}