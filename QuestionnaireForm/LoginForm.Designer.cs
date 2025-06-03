namespace QuestionnaireForm
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button_signup = new Button();
            message_label = new Label();
            txtbox_username = new TextBox();
            txtbox_password = new TextBox();
            button_signin = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // button_signup
            // 
            button_signup.Anchor = AnchorStyles.None;
            button_signup.BackColor = Color.FromArgb(33, 150, 243);
            button_signup.FlatAppearance.BorderSize = 0;
            button_signup.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 136, 229);
            button_signup.FlatStyle = FlatStyle.Flat;
            button_signup.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button_signup.ForeColor = Color.White;
            button_signup.Location = new Point(10, 168);
            button_signup.Margin = new Padding(10);
            button_signup.Name = "button_signup";
            button_signup.Padding = new Padding(2);
            button_signup.Size = new Size(308, 38);
            button_signup.TabIndex = 0;
            button_signup.Text = "S'inscrire";
            button_signup.UseVisualStyleBackColor = false;
            button_signup.Click += button_signup_Click;
            // 
            // message_label
            // 
            message_label.Dock = DockStyle.Bottom;
            message_label.Location = new Point(50, 280);
            message_label.Margin = new Padding(2, 0, 2, 0);
            message_label.Name = "message_label";
            message_label.Size = new Size(328, 15);
            message_label.TabIndex = 1;
            message_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtbox_username
            // 
            txtbox_username.Anchor = AnchorStyles.None;
            txtbox_username.BackColor = Color.WhiteSmoke;
            txtbox_username.BorderStyle = BorderStyle.FixedSingle;
            txtbox_username.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtbox_username.ForeColor = Color.FromArgb(33, 33, 33);
            txtbox_username.Location = new Point(10, 40);
            txtbox_username.Margin = new Padding(10, 10, 10, 0);
            txtbox_username.Name = "txtbox_username";
            txtbox_username.PlaceholderText = "Nom d'utilisateur";
            txtbox_username.Size = new Size(308, 25);
            txtbox_username.TabIndex = 2;
            // 
            // txtbox_password
            // 
            txtbox_password.Anchor = AnchorStyles.None;
            txtbox_password.BackColor = Color.WhiteSmoke;
            txtbox_password.BorderStyle = BorderStyle.FixedSingle;
            txtbox_password.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtbox_password.ForeColor = Color.FromArgb(33, 33, 33);
            txtbox_password.Location = new Point(10, 75);
            txtbox_password.Margin = new Padding(10, 10, 10, 0);
            txtbox_password.Name = "txtbox_password";
            txtbox_password.PasswordChar = '*';
            txtbox_password.PlaceholderText = "Mot de passe";
            txtbox_password.RightToLeft = RightToLeft.No;
            txtbox_password.Size = new Size(308, 25);
            txtbox_password.TabIndex = 3;
            // 
            // button_signin
            // 
            button_signin.BackColor = Color.FromArgb(76, 175, 80);
            button_signin.FlatAppearance.BorderSize = 0;
            button_signin.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 142, 60);
            button_signin.FlatStyle = FlatStyle.Flat;
            button_signin.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button_signin.ForeColor = Color.White;
            button_signin.Location = new Point(10, 110);
            button_signin.Margin = new Padding(10);
            button_signin.Name = "button_signin";
            button_signin.Padding = new Padding(5);
            button_signin.Size = new Size(308, 38);
            button_signin.TabIndex = 4;
            button_signin.Text = "Se connecter";
            button_signin.UseVisualStyleBackColor = false;
            button_signin.Click += button_signin_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(txtbox_username);
            flowLayoutPanel1.Controls.Add(txtbox_password);
            flowLayoutPanel1.Controls.Add(button_signin);
            flowLayoutPanel1.Controls.Add(button_signup);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(50, 5);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(0, 30, 0, 0);
            flowLayoutPanel1.Size = new Size(328, 275);
            flowLayoutPanel1.TabIndex = 5;
            flowLayoutPanel1.WrapContents = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(428, 300);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(message_label);
            Margin = new Padding(2, 1, 2, 1);
            Name = "LoginForm";
            Padding = new Padding(50, 5, 50, 5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Questionnaire - Login";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button_signup;
        private Label message_label;
        private TextBox txtbox_username;
        private TextBox txtbox_password;
        private Button button_signin;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
