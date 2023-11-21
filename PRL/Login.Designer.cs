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
            label2 = new Label();
            Password = new TextBox();
            checkBox1 = new CheckBox();
            Visible_Pass = new Label();
            Forget_Pass = new Label();
            Btn_Login = new Tool.ButtonCustom();
            errorProvider1 = new ErrorProvider(components);
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // PhoneNumber
            // 
            PhoneNumber.Location = new Point(246, 191);
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
            label1.Location = new Point(95, 193);
            label1.Name = "label1";
            label1.Size = new Size(130, 25);
            label1.TabIndex = 1;
            label1.Text = "Số Điện Thoại";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.MediumBlue;
            label2.Location = new Point(95, 243);
            label2.Name = "label2";
            label2.Size = new Size(93, 25);
            label2.TabIndex = 2;
            label2.Text = "Mật khẩu";
            // 
            // Password
            // 
            Password.Location = new Point(246, 244);
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
            checkBox1.Location = new Point(246, 305);
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
            Visible_Pass.Location = new Point(592, 251);
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
            Forget_Pass.Location = new Point(312, 444);
            Forget_Pass.Name = "Forget_Pass";
            Forget_Pass.Size = new Size(137, 23);
            Forget_Pass.TabIndex = 6;
            Forget_Pass.Text = "Quên mật khẩu?";
            // 
            // Btn_Login
            // 
            Btn_Login.BackColor = Color.Cyan;
            Btn_Login.BackgroundColor = Color.Cyan;
            Btn_Login.BorderColor = Color.HotPink;
            Btn_Login.BorderRadius = 20;
            Btn_Login.BorderSize = 2;
            Btn_Login.FlatAppearance.BorderSize = 0;
            Btn_Login.FlatStyle = FlatStyle.Flat;
            Btn_Login.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Login.ForeColor = Color.Crimson;
            Btn_Login.Location = new Point(288, 369);
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
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
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
            Controls.Add(label2);
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
        private Label label2;
        private TextBox Password;
        private CheckBox checkBox1;
        private Label Visible_Pass;
        private Label Forget_Pass;
        private Tool.ButtonCustom Btn_Login;
        private ErrorProvider errorProvider1;
        private OpenFileDialog openFileDialog1;
    }
}