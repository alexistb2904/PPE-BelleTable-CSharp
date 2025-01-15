namespace QuestionnaireForm
{
    partial class proprietyQuestionnaire
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
            name_label = new Label();
            name_txtBox = new TextBox();
            theme_label = new Label();
            comboBox_theme = new ComboBox();
            newTheme_btn = new Button();
            newTheme_block = new FlowLayoutPanel();
            newTheme_label = new Label();
            txtBox_newTheme = new TextBox();
            btn_createTheme = new Button();
            btn_validQuestionnaire = new Button();
            newTheme_block.SuspendLayout();
            SuspendLayout();
            // 
            // name_label
            // 
            name_label.AutoSize = true;
            name_label.Location = new Point(12, 9);
            name_label.Name = "name_label";
            name_label.Size = new Size(126, 15);
            name_label.TabIndex = 0;
            name_label.Text = "Nom du questionnaire";
            // 
            // name_txtBox
            // 
            name_txtBox.Location = new Point(12, 27);
            name_txtBox.Name = "name_txtBox";
            name_txtBox.Size = new Size(336, 23);
            name_txtBox.TabIndex = 1;
            // 
            // theme_label
            // 
            theme_label.AutoSize = true;
            theme_label.Location = new Point(12, 65);
            theme_label.Name = "theme_label";
            theme_label.Size = new Size(137, 15);
            theme_label.TabIndex = 2;
            theme_label.Text = "Theme de Questionnaire";
            // 
            // comboBox_theme
            // 
            comboBox_theme.FormattingEnabled = true;
            comboBox_theme.Location = new Point(12, 83);
            comboBox_theme.Name = "comboBox_theme";
            comboBox_theme.Size = new Size(336, 23);
            comboBox_theme.TabIndex = 3;
            // 
            // newTheme_btn
            // 
            newTheme_btn.Location = new Point(189, 61);
            newTheme_btn.Name = "newTheme_btn";
            newTheme_btn.Size = new Size(159, 23);
            newTheme_btn.TabIndex = 4;
            newTheme_btn.Text = "Créer un nouveau Theme";
            newTheme_btn.UseVisualStyleBackColor = true;
            newTheme_btn.Click += newTheme_btn_Click;
            // 
            // newTheme_block
            // 
            newTheme_block.Controls.Add(newTheme_label);
            newTheme_block.Controls.Add(txtBox_newTheme);
            newTheme_block.Controls.Add(btn_createTheme);
            newTheme_block.FlowDirection = FlowDirection.TopDown;
            newTheme_block.Location = new Point(12, 112);
            newTheme_block.Name = "newTheme_block";
            newTheme_block.Size = new Size(336, 76);
            newTheme_block.TabIndex = 5;
            newTheme_block.Visible = false;
            // 
            // newTheme_label
            // 
            newTheme_label.AutoSize = true;
            newTheme_label.Location = new Point(3, 0);
            newTheme_label.Name = "newTheme_label";
            newTheme_label.Size = new Size(95, 15);
            newTheme_label.TabIndex = 0;
            newTheme_label.Text = "Nouveau Theme";
            // 
            // txtBox_newTheme
            // 
            txtBox_newTheme.Location = new Point(3, 18);
            txtBox_newTheme.Name = "txtBox_newTheme";
            txtBox_newTheme.Size = new Size(333, 23);
            txtBox_newTheme.TabIndex = 1;
            // 
            // btn_createTheme
            // 
            btn_createTheme.Location = new Point(3, 47);
            btn_createTheme.Name = "btn_createTheme";
            btn_createTheme.Size = new Size(333, 23);
            btn_createTheme.TabIndex = 2;
            btn_createTheme.Text = "Créer";
            btn_createTheme.UseVisualStyleBackColor = true;
            btn_createTheme.Click += btn_createTheme_Click;
            // 
            // btn_validQuestionnaire
            // 
            btn_validQuestionnaire.Location = new Point(12, 197);
            btn_validQuestionnaire.Name = "btn_validQuestionnaire";
            btn_validQuestionnaire.Size = new Size(336, 23);
            btn_validQuestionnaire.TabIndex = 6;
            btn_validQuestionnaire.Text = "Valider";
            btn_validQuestionnaire.UseVisualStyleBackColor = false;
            btn_validQuestionnaire.Click += btn_validQuestionnaire_Click;
            // 
            // proprietyQuestionnaire
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(375, 232);
            Controls.Add(btn_validQuestionnaire);
            Controls.Add(newTheme_block);
            Controls.Add(newTheme_btn);
            Controls.Add(comboBox_theme);
            Controls.Add(theme_label);
            Controls.Add(name_txtBox);
            Controls.Add(name_label);
            Name = "proprietyQuestionnaire";
            Text = "Propriété Questionnaire";
            newTheme_block.ResumeLayout(false);
            newTheme_block.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label name_label;
        private TextBox name_txtBox;
        private Label theme_label;
        private ComboBox comboBox_theme;
        private Button newTheme_btn;
        private FlowLayoutPanel newTheme_block;
        private Label newTheme_label;
        private TextBox txtBox_newTheme;
        private Button btn_createTheme;
        private Button btn_validQuestionnaire;
    }
}