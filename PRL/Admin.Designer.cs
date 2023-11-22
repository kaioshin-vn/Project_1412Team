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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            name_clinic = new Panel();
            label1 = new Label();
            Navigation = new Panel();
            label3 = new Label();
            label2 = new Label();
            buttonCustom1 = new ButtonCustom();
            ThongBao = new Label();
            LoiChao = new Label();
            Panel_KH = new Panel();
            QLKh_ff = new Label();
            Panel_NV = new Panel();
            cyberRichTextBox1 = new ReaLTaiizor.Controls.CyberRichTextBox();
            buttonCustom4 = new ButtonCustom();
            buttonCustom3 = new ButtonCustom();
            buttonCustom2 = new ButtonCustom();
            NV_GridView = new ReaLTaiizor.Controls.PoisonDataGridView();
            cyberGroupBox1 = new ReaLTaiizor.Controls.CyberGroupBox();
            dungeonComboBox1 = new ReaLTaiizor.Controls.DungeonComboBox();
            dungeonHeaderLabel1 = new ReaLTaiizor.Controls.DungeonHeaderLabel();
            cyberRichTextBox5 = new ReaLTaiizor.Controls.CyberRichTextBox();
            cyberRichTextBox4 = new ReaLTaiizor.Controls.CyberRichTextBox();
            NV_Txt_Sdt = new ReaLTaiizor.Controls.CyberRichTextBox();
            NV_Txt_DiaChi = new ReaLTaiizor.Controls.CyberRichTextBox();
            NV_Text_HoTen = new ReaLTaiizor.Controls.CyberRichTextBox();
            NV_GioiTinh = new ReaLTaiizor.Controls.DungeonHeaderLabel();
            NV_ChucVu = new ReaLTaiizor.Controls.DungeonHeaderLabel();
            NV_Sdt = new ReaLTaiizor.Controls.DungeonHeaderLabel();
            NV_DiaChi = new ReaLTaiizor.Controls.DungeonHeaderLabel();
            NV_Ten = new ReaLTaiizor.Controls.DungeonHeaderLabel();
            Nav_Option = new Panel();
            ThongKe = new Label();
            QL_LichKham = new Label();
            QL_Luong = new Label();
            QL_DV = new Label();
            ThanhToan = new Label();
            QL_KH = new Label();
            QL_NV = new Label();
            Content = new Panel();
            Elipse_GridView = new Bunifu.Framework.UI.BunifuElipse(components);
            name_clinic.SuspendLayout();
            Navigation.SuspendLayout();
            Panel_KH.SuspendLayout();
            Panel_NV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NV_GridView).BeginInit();
            cyberGroupBox1.SuspendLayout();
            Nav_Option.SuspendLayout();
            Content.SuspendLayout();
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
            Panel_NV.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Panel_NV.Controls.Add(cyberRichTextBox1);
            Panel_NV.Controls.Add(buttonCustom4);
            Panel_NV.Controls.Add(buttonCustom3);
            Panel_NV.Controls.Add(buttonCustom2);
            Panel_NV.Controls.Add(NV_GridView);
            Panel_NV.Controls.Add(cyberGroupBox1);
            Panel_NV.Location = new Point(35, 17);
            Panel_NV.Name = "Panel_NV";
            Panel_NV.Size = new Size(1332, 686);
            Panel_NV.TabIndex = 0;
            // 
            // cyberRichTextBox1
            // 
            cyberRichTextBox1.Alpha = 20;
            cyberRichTextBox1.BackColor = Color.Transparent;
            cyberRichTextBox1.Background_WidthPen = 3F;
            cyberRichTextBox1.BackgroundPen = true;
            cyberRichTextBox1.ColorBackground = Color.White;
            cyberRichTextBox1.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            cyberRichTextBox1.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberRichTextBox1.ColorPen_1 = Color.FromArgb(29, 200, 238);
            cyberRichTextBox1.ColorPen_2 = Color.FromArgb(37, 52, 68);
            cyberRichTextBox1.CyberRichTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberRichTextBox1.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cyberRichTextBox1.ForeColor = Color.FromArgb(245, 245, 245);
            cyberRichTextBox1.Lighting = false;
            cyberRichTextBox1.LinearGradientPen = false;
            cyberRichTextBox1.Location = new Point(37, 490);
            cyberRichTextBox1.Name = "cyberRichTextBox1";
            cyberRichTextBox1.PenWidth = 15;
            cyberRichTextBox1.RGB = false;
            cyberRichTextBox1.Rounding = true;
            cyberRichTextBox1.RoundingInt = 60;
            cyberRichTextBox1.Size = new Size(691, 125);
            cyberRichTextBox1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberRichTextBox1.TabIndex = 15;
            cyberRichTextBox1.Tag = "Cyber";
            cyberRichTextBox1.TextButton = "";
            cyberRichTextBox1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberRichTextBox1.Timer_RGB = 300;
            // 
            // buttonCustom4
            // 
            buttonCustom4.BackColor = Color.MediumSlateBlue;
            buttonCustom4.BackgroundColor = Color.MediumSlateBlue;
            buttonCustom4.BorderColor = Color.PaleVioletRed;
            buttonCustom4.BorderRadius = 20;
            buttonCustom4.BorderSize = 2;
            buttonCustom4.FlatAppearance.BorderSize = 0;
            buttonCustom4.FlatStyle = FlatStyle.Flat;
            buttonCustom4.ForeColor = Color.White;
            buttonCustom4.Location = new Point(537, 621);
            buttonCustom4.Name = "buttonCustom4";
            buttonCustom4.Size = new Size(156, 50);
            buttonCustom4.TabIndex = 14;
            buttonCustom4.Text = "buttonCustom4";
            buttonCustom4.TextColor = Color.White;
            buttonCustom4.UseVisualStyleBackColor = false;
            // 
            // buttonCustom3
            // 
            buttonCustom3.BackColor = Color.MediumSlateBlue;
            buttonCustom3.BackgroundColor = Color.MediumSlateBlue;
            buttonCustom3.BorderColor = Color.PaleVioletRed;
            buttonCustom3.BorderRadius = 20;
            buttonCustom3.BorderSize = 2;
            buttonCustom3.FlatAppearance.BorderSize = 0;
            buttonCustom3.FlatStyle = FlatStyle.Flat;
            buttonCustom3.ForeColor = Color.White;
            buttonCustom3.Location = new Point(290, 621);
            buttonCustom3.Name = "buttonCustom3";
            buttonCustom3.Size = new Size(156, 50);
            buttonCustom3.TabIndex = 13;
            buttonCustom3.Text = "buttonCustom3";
            buttonCustom3.TextColor = Color.White;
            buttonCustom3.UseVisualStyleBackColor = false;
            // 
            // buttonCustom2
            // 
            buttonCustom2.BackColor = Color.MediumSlateBlue;
            buttonCustom2.BackgroundColor = Color.MediumSlateBlue;
            buttonCustom2.BorderColor = Color.PaleVioletRed;
            buttonCustom2.BorderRadius = 20;
            buttonCustom2.BorderSize = 2;
            buttonCustom2.FlatAppearance.BorderSize = 0;
            buttonCustom2.FlatStyle = FlatStyle.Flat;
            buttonCustom2.ForeColor = Color.White;
            buttonCustom2.Location = new Point(49, 621);
            buttonCustom2.Name = "buttonCustom2";
            buttonCustom2.Size = new Size(156, 50);
            buttonCustom2.TabIndex = 12;
            buttonCustom2.Text = "buttonCustom2";
            buttonCustom2.TextColor = Color.White;
            buttonCustom2.UseVisualStyleBackColor = false;
            // 
            // NV_GridView
            // 
            NV_GridView.AllowUserToResizeRows = false;
            NV_GridView.BackgroundColor = Color.Pink;
            NV_GridView.BorderStyle = BorderStyle.None;
            NV_GridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            NV_GridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            NV_GridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            NV_GridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            NV_GridView.DefaultCellStyle = dataGridViewCellStyle2;
            NV_GridView.EnableHeadersVisualStyles = false;
            NV_GridView.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            NV_GridView.GridColor = Color.FromArgb(255, 255, 255);
            NV_GridView.Location = new Point(37, 32);
            NV_GridView.Name = "NV_GridView";
            NV_GridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            NV_GridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            NV_GridView.RowHeadersWidth = 51;
            NV_GridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            NV_GridView.RowTemplate.Height = 29;
            NV_GridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            NV_GridView.Size = new Size(691, 445);
            NV_GridView.TabIndex = 11;
            // 
            // cyberGroupBox1
            // 
            cyberGroupBox1.Alpha = 20;
            cyberGroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cyberGroupBox1.BackColor = Color.Transparent;
            cyberGroupBox1.Background = true;
            cyberGroupBox1.Background_WidthPen = 3F;
            cyberGroupBox1.BackgroundPen = true;
            cyberGroupBox1.ColorBackground = Color.FromArgb(192, 255, 192);
            cyberGroupBox1.ColorBackground_1 = Color.FromArgb(128, 255, 255);
            cyberGroupBox1.ColorBackground_2 = Color.Fuchsia;
            cyberGroupBox1.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            cyberGroupBox1.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberGroupBox1.ColorPen_1 = Color.FromArgb(37, 52, 68);
            cyberGroupBox1.ColorPen_2 = Color.FromArgb(41, 63, 86);
            cyberGroupBox1.Controls.Add(dungeonComboBox1);
            cyberGroupBox1.Controls.Add(dungeonHeaderLabel1);
            cyberGroupBox1.Controls.Add(cyberRichTextBox5);
            cyberGroupBox1.Controls.Add(cyberRichTextBox4);
            cyberGroupBox1.Controls.Add(NV_Txt_Sdt);
            cyberGroupBox1.Controls.Add(NV_Txt_DiaChi);
            cyberGroupBox1.Controls.Add(NV_Text_HoTen);
            cyberGroupBox1.Controls.Add(NV_GioiTinh);
            cyberGroupBox1.Controls.Add(NV_ChucVu);
            cyberGroupBox1.Controls.Add(NV_Sdt);
            cyberGroupBox1.Controls.Add(NV_DiaChi);
            cyberGroupBox1.Controls.Add(NV_Ten);
            cyberGroupBox1.CyberGroupBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberGroupBox1.ForeColor = Color.FromArgb(245, 245, 245);
            cyberGroupBox1.Lighting = false;
            cyberGroupBox1.LinearGradient_Background = false;
            cyberGroupBox1.LinearGradientPen = false;
            cyberGroupBox1.Location = new Point(789, 3);
            cyberGroupBox1.Name = "cyberGroupBox1";
            cyberGroupBox1.PenWidth = 15;
            cyberGroupBox1.RGB = false;
            cyberGroupBox1.Rounding = true;
            cyberGroupBox1.RoundingInt = 60;
            cyberGroupBox1.Size = new Size(531, 680);
            cyberGroupBox1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberGroupBox1.TabIndex = 10;
            cyberGroupBox1.Tag = "Cyber";
            cyberGroupBox1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberGroupBox1.Timer_RGB = 300;
            // 
            // dungeonComboBox1
            // 
            dungeonComboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dungeonComboBox1.BackColor = Color.FromArgb(246, 246, 246);
            dungeonComboBox1.ColorA = Color.FromArgb(246, 132, 85);
            dungeonComboBox1.ColorB = Color.FromArgb(231, 108, 57);
            dungeonComboBox1.ColorC = Color.FromArgb(242, 241, 240);
            dungeonComboBox1.ColorD = Color.FromArgb(253, 252, 252);
            dungeonComboBox1.ColorE = Color.FromArgb(239, 237, 236);
            dungeonComboBox1.ColorF = Color.FromArgb(180, 180, 180);
            dungeonComboBox1.ColorG = Color.FromArgb(119, 119, 118);
            dungeonComboBox1.ColorH = Color.FromArgb(224, 222, 220);
            dungeonComboBox1.ColorI = Color.FromArgb(250, 249, 249);
            dungeonComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            dungeonComboBox1.DropDownHeight = 100;
            dungeonComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            dungeonComboBox1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dungeonComboBox1.ForeColor = Color.FromArgb(76, 76, 97);
            dungeonComboBox1.FormattingEnabled = true;
            dungeonComboBox1.HoverSelectionColor = Color.Empty;
            dungeonComboBox1.IntegralHeight = false;
            dungeonComboBox1.ItemHeight = 20;
            dungeonComboBox1.Location = new Point(214, 486);
            dungeonComboBox1.Name = "dungeonComboBox1";
            dungeonComboBox1.Size = new Size(287, 26);
            dungeonComboBox1.StartIndex = 0;
            dungeonComboBox1.TabIndex = 13;
            // 
            // dungeonHeaderLabel1
            // 
            dungeonHeaderLabel1.AutoSize = true;
            dungeonHeaderLabel1.BackColor = Color.Transparent;
            dungeonHeaderLabel1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            dungeonHeaderLabel1.ForeColor = Color.FromArgb(76, 76, 77);
            dungeonHeaderLabel1.Location = new Point(61, 545);
            dungeonHeaderLabel1.Name = "dungeonHeaderLabel1";
            dungeonHeaderLabel1.Size = new Size(111, 25);
            dungeonHeaderLabel1.TabIndex = 12;
            dungeonHeaderLabel1.Text = "Mật khẩu : ";
            // 
            // cyberRichTextBox5
            // 
            cyberRichTextBox5.Alpha = 20;
            cyberRichTextBox5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cyberRichTextBox5.BackColor = Color.Transparent;
            cyberRichTextBox5.Background_WidthPen = 3F;
            cyberRichTextBox5.BackgroundPen = true;
            cyberRichTextBox5.ColorBackground = Color.FromArgb(37, 72, 110);
            cyberRichTextBox5.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            cyberRichTextBox5.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberRichTextBox5.ColorPen_1 = Color.FromArgb(29, 200, 238);
            cyberRichTextBox5.ColorPen_2 = Color.FromArgb(37, 52, 68);
            cyberRichTextBox5.CyberRichTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberRichTextBox5.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cyberRichTextBox5.ForeColor = Color.FromArgb(245, 245, 245);
            cyberRichTextBox5.Lighting = false;
            cyberRichTextBox5.LinearGradientPen = false;
            cyberRichTextBox5.Location = new Point(214, 527);
            cyberRichTextBox5.Name = "cyberRichTextBox5";
            cyberRichTextBox5.PenWidth = 15;
            cyberRichTextBox5.RGB = false;
            cyberRichTextBox5.Rounding = true;
            cyberRichTextBox5.RoundingInt = 60;
            cyberRichTextBox5.Size = new Size(287, 57);
            cyberRichTextBox5.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberRichTextBox5.TabIndex = 10;
            cyberRichTextBox5.Tag = "Cyber";
            cyberRichTextBox5.TextButton = "";
            cyberRichTextBox5.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberRichTextBox5.Timer_RGB = 300;
            cyberRichTextBox5.Load += cyberRichTextBox5_Load;
            // 
            // cyberRichTextBox4
            // 
            cyberRichTextBox4.Alpha = 20;
            cyberRichTextBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cyberRichTextBox4.BackColor = Color.Transparent;
            cyberRichTextBox4.Background_WidthPen = 3F;
            cyberRichTextBox4.BackgroundPen = true;
            cyberRichTextBox4.ColorBackground = Color.FromArgb(37, 72, 110);
            cyberRichTextBox4.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            cyberRichTextBox4.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberRichTextBox4.ColorPen_1 = Color.FromArgb(29, 200, 238);
            cyberRichTextBox4.ColorPen_2 = Color.FromArgb(37, 52, 68);
            cyberRichTextBox4.CyberRichTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberRichTextBox4.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cyberRichTextBox4.ForeColor = Color.FromArgb(245, 245, 245);
            cyberRichTextBox4.Lighting = false;
            cyberRichTextBox4.LinearGradientPen = false;
            cyberRichTextBox4.Location = new Point(214, 408);
            cyberRichTextBox4.Name = "cyberRichTextBox4";
            cyberRichTextBox4.PenWidth = 15;
            cyberRichTextBox4.RGB = false;
            cyberRichTextBox4.Rounding = true;
            cyberRichTextBox4.RoundingInt = 60;
            cyberRichTextBox4.Size = new Size(287, 57);
            cyberRichTextBox4.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberRichTextBox4.TabIndex = 9;
            cyberRichTextBox4.Tag = "Cyber";
            cyberRichTextBox4.TextButton = "";
            cyberRichTextBox4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberRichTextBox4.Timer_RGB = 300;
            // 
            // NV_Txt_Sdt
            // 
            NV_Txt_Sdt.Alpha = 20;
            NV_Txt_Sdt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NV_Txt_Sdt.BackColor = Color.Transparent;
            NV_Txt_Sdt.Background_WidthPen = 3F;
            NV_Txt_Sdt.BackgroundPen = true;
            NV_Txt_Sdt.ColorBackground = Color.FromArgb(37, 72, 110);
            NV_Txt_Sdt.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            NV_Txt_Sdt.ColorLighting = Color.FromArgb(29, 200, 238);
            NV_Txt_Sdt.ColorPen_1 = Color.FromArgb(29, 200, 238);
            NV_Txt_Sdt.ColorPen_2 = Color.FromArgb(37, 52, 68);
            NV_Txt_Sdt.CyberRichTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            NV_Txt_Sdt.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            NV_Txt_Sdt.ForeColor = Color.FromArgb(245, 245, 245);
            NV_Txt_Sdt.Lighting = false;
            NV_Txt_Sdt.LinearGradientPen = false;
            NV_Txt_Sdt.Location = new Point(214, 345);
            NV_Txt_Sdt.Name = "NV_Txt_Sdt";
            NV_Txt_Sdt.PenWidth = 15;
            NV_Txt_Sdt.RGB = false;
            NV_Txt_Sdt.Rounding = true;
            NV_Txt_Sdt.RoundingInt = 60;
            NV_Txt_Sdt.Size = new Size(287, 57);
            NV_Txt_Sdt.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            NV_Txt_Sdt.TabIndex = 8;
            NV_Txt_Sdt.Tag = "Cyber";
            NV_Txt_Sdt.TextButton = "";
            NV_Txt_Sdt.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            NV_Txt_Sdt.Timer_RGB = 300;
            // 
            // NV_Txt_DiaChi
            // 
            NV_Txt_DiaChi.Alpha = 20;
            NV_Txt_DiaChi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NV_Txt_DiaChi.BackColor = Color.Transparent;
            NV_Txt_DiaChi.Background_WidthPen = 3F;
            NV_Txt_DiaChi.BackgroundPen = true;
            NV_Txt_DiaChi.ColorBackground = Color.FromArgb(37, 72, 110);
            NV_Txt_DiaChi.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            NV_Txt_DiaChi.ColorLighting = Color.FromArgb(29, 200, 238);
            NV_Txt_DiaChi.ColorPen_1 = Color.FromArgb(29, 200, 238);
            NV_Txt_DiaChi.ColorPen_2 = Color.FromArgb(37, 52, 68);
            NV_Txt_DiaChi.CyberRichTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            NV_Txt_DiaChi.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            NV_Txt_DiaChi.ForeColor = Color.FromArgb(245, 245, 245);
            NV_Txt_DiaChi.Lighting = false;
            NV_Txt_DiaChi.LinearGradientPen = false;
            NV_Txt_DiaChi.Location = new Point(214, 233);
            NV_Txt_DiaChi.Name = "NV_Txt_DiaChi";
            NV_Txt_DiaChi.PenWidth = 15;
            NV_Txt_DiaChi.RGB = false;
            NV_Txt_DiaChi.Rounding = true;
            NV_Txt_DiaChi.RoundingInt = 60;
            NV_Txt_DiaChi.Size = new Size(287, 104);
            NV_Txt_DiaChi.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            NV_Txt_DiaChi.TabIndex = 7;
            NV_Txt_DiaChi.Tag = "Cyber";
            NV_Txt_DiaChi.TextButton = "";
            NV_Txt_DiaChi.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            NV_Txt_DiaChi.Timer_RGB = 300;
            // 
            // NV_Text_HoTen
            // 
            NV_Text_HoTen.Alpha = 20;
            NV_Text_HoTen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NV_Text_HoTen.BackColor = Color.Transparent;
            NV_Text_HoTen.Background_WidthPen = 3F;
            NV_Text_HoTen.BackgroundPen = true;
            NV_Text_HoTen.ColorBackground = Color.FromArgb(37, 72, 110);
            NV_Text_HoTen.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            NV_Text_HoTen.ColorLighting = Color.FromArgb(29, 200, 238);
            NV_Text_HoTen.ColorPen_1 = Color.FromArgb(29, 200, 238);
            NV_Text_HoTen.ColorPen_2 = Color.FromArgb(37, 52, 68);
            NV_Text_HoTen.CyberRichTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            NV_Text_HoTen.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            NV_Text_HoTen.ForeColor = Color.FromArgb(245, 245, 245);
            NV_Text_HoTen.Lighting = false;
            NV_Text_HoTen.LinearGradientPen = false;
            NV_Text_HoTen.Location = new Point(214, 170);
            NV_Text_HoTen.Name = "NV_Text_HoTen";
            NV_Text_HoTen.PenWidth = 15;
            NV_Text_HoTen.RGB = false;
            NV_Text_HoTen.Rounding = true;
            NV_Text_HoTen.RoundingInt = 60;
            NV_Text_HoTen.Size = new Size(287, 57);
            NV_Text_HoTen.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            NV_Text_HoTen.TabIndex = 6;
            NV_Text_HoTen.Tag = "Cyber";
            NV_Text_HoTen.TextButton = "";
            NV_Text_HoTen.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            NV_Text_HoTen.Timer_RGB = 300;
            // 
            // NV_GioiTinh
            // 
            NV_GioiTinh.AutoSize = true;
            NV_GioiTinh.BackColor = Color.Transparent;
            NV_GioiTinh.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            NV_GioiTinh.ForeColor = Color.FromArgb(76, 76, 77);
            NV_GioiTinh.Location = new Point(57, 420);
            NV_GioiTinh.Name = "NV_GioiTinh";
            NV_GioiTinh.Size = new Size(98, 25);
            NV_GioiTinh.TabIndex = 4;
            NV_GioiTinh.Text = "Giới tính :";
            // 
            // NV_ChucVu
            // 
            NV_ChucVu.AutoSize = true;
            NV_ChucVu.BackColor = Color.Transparent;
            NV_ChucVu.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            NV_ChucVu.ForeColor = Color.FromArgb(76, 76, 77);
            NV_ChucVu.Location = new Point(61, 487);
            NV_ChucVu.Name = "NV_ChucVu";
            NV_ChucVu.Size = new Size(94, 25);
            NV_ChucVu.TabIndex = 3;
            NV_ChucVu.Text = "Chức vụ :";
            NV_ChucVu.Click += NV_ChucVu_Click;
            // 
            // NV_Sdt
            // 
            NV_Sdt.AutoSize = true;
            NV_Sdt.BackColor = Color.Transparent;
            NV_Sdt.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            NV_Sdt.ForeColor = Color.FromArgb(76, 76, 77);
            NV_Sdt.Location = new Point(57, 358);
            NV_Sdt.Name = "NV_Sdt";
            NV_Sdt.Size = new Size(139, 25);
            NV_Sdt.TabIndex = 2;
            NV_Sdt.Text = "Số điện thoại :";
            // 
            // NV_DiaChi
            // 
            NV_DiaChi.AutoSize = true;
            NV_DiaChi.BackColor = Color.Transparent;
            NV_DiaChi.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            NV_DiaChi.ForeColor = Color.FromArgb(76, 76, 77);
            NV_DiaChi.Location = new Point(58, 249);
            NV_DiaChi.Name = "NV_DiaChi";
            NV_DiaChi.Size = new Size(84, 25);
            NV_DiaChi.TabIndex = 1;
            NV_DiaChi.Text = "Địa Chỉ :";
            // 
            // NV_Ten
            // 
            NV_Ten.AutoSize = true;
            NV_Ten.BackColor = Color.Transparent;
            NV_Ten.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            NV_Ten.ForeColor = Color.FromArgb(76, 76, 77);
            NV_Ten.Location = new Point(58, 190);
            NV_Ten.Name = "NV_Ten";
            NV_Ten.Size = new Size(85, 25);
            NV_Ten.TabIndex = 0;
            NV_Ten.Text = "Họ Tên :";
            NV_Ten.Click += NV_Ten_Click;
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
            ThongKe.Image = C_PRL.Properties.Resources.icons8_analyst_64;
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
            QL_LichKham.Image = C_PRL.Properties.Resources.icons8_document_42;
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
            QL_Luong.Image = C_PRL.Properties.Resources.icons8_salary_80;
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
            QL_DV.Image = C_PRL.Properties.Resources.icons8_service_341;
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
            ThanhToan.Image = C_PRL.Properties.Resources.icons8_bill_64;
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
            QL_KH.Image = C_PRL.Properties.Resources.icons8_customer_43;
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
            QL_NV.Image = C_PRL.Properties.Resources.icons8_crowd_34;
            QL_NV.ImageAlign = ContentAlignment.MiddleLeft;
            QL_NV.Location = new Point(43, 17);
            QL_NV.Name = "QL_NV";
            QL_NV.Size = new Size(216, 32);
            QL_NV.TabIndex = 0;
            QL_NV.Text = "     QL Nhân viên";
            QL_NV.Click += label3_Click;
            // 
            // Content
            // 
            Content.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Content.BackColor = Color.LavenderBlush;
            Content.BorderStyle = BorderStyle.FixedSingle;
            Content.Controls.Add(Panel_NV);
            Content.Location = new Point(276, 56);
            Content.Name = "Content";
            Content.Size = new Size(1395, 722);
            Content.TabIndex = 2;
            // 
            // Elipse_GridView
            // 
            Elipse_GridView.ElipseRadius = 10;
            Elipse_GridView.TargetControl = NV_GridView;
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
            WindowState = FormWindowState.Maximized;
            Load += Admin_Load;
            VisibleChanged += Admin_VisibleChanged;
            name_clinic.ResumeLayout(false);
            name_clinic.PerformLayout();
            Navigation.ResumeLayout(false);
            Navigation.PerformLayout();
            Panel_KH.ResumeLayout(false);
            Panel_KH.PerformLayout();
            Panel_NV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NV_GridView).EndInit();
            cyberGroupBox1.ResumeLayout(false);
            cyberGroupBox1.PerformLayout();
            Nav_Option.ResumeLayout(false);
            Nav_Option.PerformLayout();
            Content.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel name_clinic;
        private Panel Navigation;
        private Label label1;
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
        private Panel Panel_KH;
        private Label QLKh_ff;
        private Panel Content;
        private ReaLTaiizor.Controls.PoisonDataGridView NV_GridView;
        private ReaLTaiizor.Controls.CyberGroupBox cyberGroupBox1;
        private ReaLTaiizor.Controls.DungeonHeaderLabel NV_GioiTinh;
        private ReaLTaiizor.Controls.DungeonHeaderLabel NV_ChucVu;
        private ReaLTaiizor.Controls.DungeonHeaderLabel NV_Sdt;
        private ReaLTaiizor.Controls.DungeonHeaderLabel NV_DiaChi;
        private ReaLTaiizor.Controls.DungeonHeaderLabel NV_Ten;
        private Bunifu.Framework.UI.BunifuElipse Elipse_GridView;
        private ReaLTaiizor.Controls.CyberRichTextBox NV_Text_HoTen;
        private ReaLTaiizor.Controls.CyberRichTextBox cyberRichTextBox4;
        private ReaLTaiizor.Controls.CyberRichTextBox NV_Txt_Sdt;
        private ReaLTaiizor.Controls.CyberRichTextBox NV_Txt_DiaChi;
        private ReaLTaiizor.Controls.CyberRichTextBox cyberRichTextBox5;
        private ButtonCustom buttonCustom4;
        private ButtonCustom buttonCustom3;
        private ButtonCustom buttonCustom2;
        private ReaLTaiizor.Controls.DungeonHeaderLabel dungeonHeaderLabel1;
        private ReaLTaiizor.Controls.DungeonComboBox dungeonComboBox1;
        private ReaLTaiizor.Controls.CyberRichTextBox cyberRichTextBox1;
    }
}