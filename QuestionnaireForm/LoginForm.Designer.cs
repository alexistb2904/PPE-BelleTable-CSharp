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
            button1 = new Button();
            message_label = new Label();
            txtbox_username = new TextBox();
            txtbox_password = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Dock = DockStyle.Bottom;
            button1.Location = new Point(0, 361);
            button1.Name = "button1";
            button1.Size = new Size(800, 89);
            button1.TabIndex = 0;
            button1.Text = "Se connecter";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // message_label
            // 
            message_label.Dock = DockStyle.Bottom;
            message_label.Location = new Point(0, 329);
            message_label.Name = "message_label";
            message_label.Size = new Size(800, 32);
            message_label.TabIndex = 1;
            message_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtbox_username
            // 
            txtbox_username.Location = new Point(207, 85);
            txtbox_username.Name = "txtbox_username";
            txtbox_username.PlaceholderText = "Nom d'utilisateur";
            txtbox_username.Size = new Size(383, 39);
            txtbox_username.TabIndex = 2;
            // 
            // txtbox_password
            // 
            txtbox_password.Location = new Point(207, 205);
            txtbox_password.Name = "txtbox_password";
            txtbox_password.PasswordChar = '*';
            txtbox_password.PlaceholderText = "Mot de passe";
            txtbox_password.RightToLeft = RightToLeft.No;
            txtbox_password.Size = new Size(383, 39);
            txtbox_password.TabIndex = 3;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtbox_password);
            Controls.Add(txtbox_username);
            Controls.Add(message_label);
            Controls.Add(button1);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Questionnaire - Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label message_label;
        private TextBox txtbox_username;
        private TextBox txtbox_password;
    }
}
