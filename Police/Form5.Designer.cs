namespace Police
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.gunaShadowPanel1 = new Guna.UI.WinForms.GunaShadowPanel();
            this.gunaGradientButton1 = new Guna.UI.WinForms.GunaGradientButton();
            this.gunaPictureBox2 = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.User = new Guna.UI.WinForms.GunaTextBox();
            this.pwd = new Guna.UI.WinForms.GunaTextBox();
            this.gunaShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaShadowPanel1
            // 
            this.gunaShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaShadowPanel1.BaseColor = System.Drawing.Color.CornflowerBlue;
            this.gunaShadowPanel1.Controls.Add(this.gunaGradientButton1);
            this.gunaShadowPanel1.Controls.Add(this.gunaPictureBox2);
            this.gunaShadowPanel1.Controls.Add(this.gunaPictureBox1);
            this.gunaShadowPanel1.Controls.Add(this.User);
            this.gunaShadowPanel1.Controls.Add(this.pwd);
            this.gunaShadowPanel1.EdgeWidth = 2;
            this.gunaShadowPanel1.Location = new System.Drawing.Point(387, 126);
            this.gunaShadowPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gunaShadowPanel1.Name = "gunaShadowPanel1";
            this.gunaShadowPanel1.Radius = 20;
            this.gunaShadowPanel1.ShadowColor = System.Drawing.Color.DarkBlue;
            this.gunaShadowPanel1.ShadowShift = 30;
            this.gunaShadowPanel1.Size = new System.Drawing.Size(797, 626);
            this.gunaShadowPanel1.TabIndex = 0;
            this.gunaShadowPanel1.UseTransfarantBackground = true;
            this.gunaShadowPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.gunaShadowPanel1_Paint);
            // 
            // gunaGradientButton1
            // 
            this.gunaGradientButton1.AnimationHoverSpeed = 0.07F;
            this.gunaGradientButton1.AnimationSpeed = 0.03F;
            this.gunaGradientButton1.BaseColor1 = System.Drawing.Color.DarkBlue;
            this.gunaGradientButton1.BaseColor2 = System.Drawing.Color.Indigo;
            this.gunaGradientButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaGradientButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaGradientButton1.Font = new System.Drawing.Font("Segoe UI Emoji", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGradientButton1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.gunaGradientButton1.Image = null;
            this.gunaGradientButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaGradientButton1.Location = new System.Drawing.Point(248, 412);
            this.gunaGradientButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gunaGradientButton1.Name = "gunaGradientButton1";
            this.gunaGradientButton1.OnHoverBaseColor1 = System.Drawing.Color.Indigo;
            this.gunaGradientButton1.OnHoverBaseColor2 = System.Drawing.Color.Blue;
            this.gunaGradientButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.OnHoverForeColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.OnHoverImage = null;
            this.gunaGradientButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.Size = new System.Drawing.Size(227, 52);
            this.gunaGradientButton1.TabIndex = 5;
            this.gunaGradientButton1.Text = "Login";
            this.gunaGradientButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaGradientButton1.Click += new System.EventHandler(this.gunaGradientButton1_Click);
            // 
            // gunaPictureBox2
            // 
            this.gunaPictureBox2.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox2.Image")));
            this.gunaPictureBox2.Location = new System.Drawing.Point(180, 325);
            this.gunaPictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gunaPictureBox2.Name = "gunaPictureBox2";
            this.gunaPictureBox2.Size = new System.Drawing.Size(37, 33);
            this.gunaPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaPictureBox2.TabIndex = 4;
            this.gunaPictureBox2.TabStop = false;
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox1.Image")));
            this.gunaPictureBox1.Location = new System.Drawing.Point(180, 246);
            this.gunaPictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(37, 33);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaPictureBox1.TabIndex = 3;
            this.gunaPictureBox1.TabStop = false;
            // 
            // User
            // 
            this.User.BackColor = System.Drawing.Color.Transparent;
            this.User.BaseColor = System.Drawing.Color.White;
            this.User.BorderColor = System.Drawing.Color.MidnightBlue;
            this.User.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.User.FocusedBaseColor = System.Drawing.Color.White;
            this.User.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.User.FocusedForeColor = System.Drawing.Color.Black;
            this.User.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User.Location = new System.Drawing.Point(225, 242);
            this.User.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.User.Name = "User";
            this.User.PasswordChar = '\0';
            this.User.Radius = 10;
            this.User.SelectedText = "";
            this.User.Size = new System.Drawing.Size(295, 39);
            this.User.TabIndex = 2;
            // 
            // pwd
            // 
            this.pwd.BackColor = System.Drawing.Color.Transparent;
            this.pwd.BaseColor = System.Drawing.Color.White;
            this.pwd.BorderColor = System.Drawing.Color.MidnightBlue;
            this.pwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pwd.FocusedBaseColor = System.Drawing.Color.White;
            this.pwd.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.pwd.FocusedForeColor = System.Drawing.Color.Black;
            this.pwd.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwd.Location = new System.Drawing.Point(225, 325);
            this.pwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pwd.Name = "pwd";
            this.pwd.PasswordChar = '●';
            this.pwd.Radius = 10;
            this.pwd.SelectedText = "";
            this.pwd.Size = new System.Drawing.Size(295, 39);
            this.pwd.TabIndex = 1;
            this.pwd.UseSystemPasswordChar = true;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1707, 890);
            this.Controls.Add(this.gunaShadowPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.gunaShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaShadowPanel gunaShadowPanel1;
        private Guna.UI.WinForms.GunaTextBox pwd;
        private Guna.UI.WinForms.GunaTextBox User;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox2;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private Guna.UI.WinForms.GunaGradientButton gunaGradientButton1;
    }
}