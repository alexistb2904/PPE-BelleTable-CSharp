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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            label_listQuestions = new Label();
            dataGrid_listeQuestions = new DataGridView();
            btn_createQuestion = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            modifierToolStripMenuItem = new ToolStripMenuItem();
            supprimerToolStripMenuItem = new ToolStripMenuItem();
            newTheme_block.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid_listeQuestions).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // name_label
            // 
            name_label.AutoSize = true;
            name_label.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            name_label.Location = new Point(12, 9);
            name_label.Name = "name_label";
            name_label.Size = new Size(158, 19);
            name_label.TabIndex = 0;
            name_label.Text = "Nom du questionnaire";
            // 
            // name_txtBox
            // 
            name_txtBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            name_txtBox.Location = new Point(12, 27);
            name_txtBox.Name = "name_txtBox";
            name_txtBox.Size = new Size(336, 25);
            name_txtBox.TabIndex = 1;
            // 
            // theme_label
            // 
            theme_label.AutoSize = true;
            theme_label.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            theme_label.Location = new Point(12, 65);
            theme_label.Name = "theme_label";
            theme_label.Size = new Size(172, 19);
            theme_label.TabIndex = 2;
            theme_label.Text = "Theme de Questionnaire";
            // 
            // comboBox_theme
            // 
            comboBox_theme.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox_theme.FormattingEnabled = true;
            comboBox_theme.Location = new Point(12, 90);
            comboBox_theme.Name = "comboBox_theme";
            comboBox_theme.Size = new Size(336, 25);
            comboBox_theme.TabIndex = 3;
            // 
            // newTheme_btn
            // 
            newTheme_btn.BackColor = Color.FromArgb(33, 150, 243);
            newTheme_btn.FlatAppearance.BorderSize = 0;
            newTheme_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 136, 229);
            newTheme_btn.FlatStyle = FlatStyle.Flat;
            newTheme_btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            newTheme_btn.ForeColor = Color.White;
            newTheme_btn.Location = new Point(190, 58);
            newTheme_btn.Name = "newTheme_btn";
            newTheme_btn.Size = new Size(159, 26);
            newTheme_btn.TabIndex = 4;
            newTheme_btn.Text = "Créer un nouveau Theme";
            newTheme_btn.UseVisualStyleBackColor = false;
            newTheme_btn.Click += newTheme_btn_Click;
            // 
            // newTheme_block
            // 
            newTheme_block.Controls.Add(newTheme_label);
            newTheme_block.Controls.Add(txtBox_newTheme);
            newTheme_block.Controls.Add(btn_createTheme);
            newTheme_block.FlowDirection = FlowDirection.TopDown;
            newTheme_block.Location = new Point(12, 121);
            newTheme_block.Name = "newTheme_block";
            newTheme_block.Size = new Size(336, 98);
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
            txtBox_newTheme.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtBox_newTheme.Location = new Point(3, 18);
            txtBox_newTheme.Name = "txtBox_newTheme";
            txtBox_newTheme.Size = new Size(333, 25);
            txtBox_newTheme.TabIndex = 1;
            // 
            // btn_createTheme
            // 
            btn_createTheme.BackColor = Color.FromArgb(33, 150, 243);
            btn_createTheme.FlatAppearance.BorderSize = 0;
            btn_createTheme.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 136, 229);
            btn_createTheme.FlatStyle = FlatStyle.Flat;
            btn_createTheme.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btn_createTheme.ForeColor = Color.White;
            btn_createTheme.Location = new Point(3, 49);
            btn_createTheme.Name = "btn_createTheme";
            btn_createTheme.Size = new Size(333, 30);
            btn_createTheme.TabIndex = 2;
            btn_createTheme.Text = "Créer";
            btn_createTheme.UseVisualStyleBackColor = false;
            btn_createTheme.Click += btn_createTheme_Click;
            // 
            // btn_validQuestionnaire
            // 
            btn_validQuestionnaire.BackColor = Color.FromArgb(76, 175, 80);
            btn_validQuestionnaire.FlatAppearance.BorderSize = 0;
            btn_validQuestionnaire.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 142, 60);
            btn_validQuestionnaire.FlatStyle = FlatStyle.Flat;
            btn_validQuestionnaire.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btn_validQuestionnaire.ForeColor = Color.White;
            btn_validQuestionnaire.Location = new Point(12, 225);
            btn_validQuestionnaire.Name = "btn_validQuestionnaire";
            btn_validQuestionnaire.Size = new Size(336, 36);
            btn_validQuestionnaire.TabIndex = 6;
            btn_validQuestionnaire.Text = "Valider";
            btn_validQuestionnaire.UseVisualStyleBackColor = false;
            btn_validQuestionnaire.Click += btn_validQuestionnaire_Click;
            // 
            // label_listQuestions
            // 
            label_listQuestions.AutoSize = true;
            label_listQuestions.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label_listQuestions.Location = new Point(369, 9);
            label_listQuestions.Margin = new Padding(2, 0, 2, 0);
            label_listQuestions.Name = "label_listQuestions";
            label_listQuestions.Size = new Size(153, 21);
            label_listQuestions.TabIndex = 7;
            label_listQuestions.Text = "Liste des questions";
            // 
            // dataGrid_listeQuestions
            // 
            dataGrid_listeQuestions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGrid_listeQuestions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid_listeQuestions.BackgroundColor = Color.WhiteSmoke;
            dataGrid_listeQuestions.BorderStyle = BorderStyle.None;
            dataGrid_listeQuestions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 33, 33);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGrid_listeQuestions.DefaultCellStyle = dataGridViewCellStyle1;
            dataGrid_listeQuestions.Location = new Point(369, 31);
            dataGrid_listeQuestions.Margin = new Padding(2, 1, 2, 1);
            dataGrid_listeQuestions.Name = "dataGrid_listeQuestions";
            dataGrid_listeQuestions.RowHeadersVisible = false;
            dataGrid_listeQuestions.RowHeadersWidth = 82;
            dataGrid_listeQuestions.RowTemplate.Height = 41;
            dataGrid_listeQuestions.Size = new Size(418, 184);
            dataGrid_listeQuestions.TabIndex = 8;
            // 
            // btn_createQuestion
            // 
            btn_createQuestion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_createQuestion.BackColor = Color.FromArgb(255, 193, 7);
            btn_createQuestion.FlatAppearance.BorderSize = 0;
            btn_createQuestion.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 160, 0);
            btn_createQuestion.FlatStyle = FlatStyle.Flat;
            btn_createQuestion.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btn_createQuestion.ForeColor = Color.Black;
            btn_createQuestion.Location = new Point(369, 226);
            btn_createQuestion.Margin = new Padding(2, 1, 2, 1);
            btn_createQuestion.Name = "btn_createQuestion";
            btn_createQuestion.Size = new Size(418, 35);
            btn_createQuestion.TabIndex = 9;
            btn_createQuestion.Text = "Créer une question";
            btn_createQuestion.UseVisualStyleBackColor = false;
            btn_createQuestion.Click += btn_createQuestion_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(32, 32);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { modifierToolStripMenuItem, supprimerToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(130, 48);
            contextMenuStrip1.Text = "Édition";
            // 
            // modifierToolStripMenuItem
            // 
            modifierToolStripMenuItem.Name = "modifierToolStripMenuItem";
            modifierToolStripMenuItem.Size = new Size(129, 22);
            modifierToolStripMenuItem.Text = "Modifier";
            modifierToolStripMenuItem.Click += modifierToolStripMenuItem_Click;
            // 
            // supprimerToolStripMenuItem
            // 
            supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            supprimerToolStripMenuItem.Size = new Size(129, 22);
            supprimerToolStripMenuItem.Text = "Supprimer";
            supprimerToolStripMenuItem.Click += supprimerToolStripMenuItem_Click;
            // 
            // proprietyQuestionnaire
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(798, 288);
            Controls.Add(btn_createQuestion);
            Controls.Add(dataGrid_listeQuestions);
            Controls.Add(label_listQuestions);
            Controls.Add(btn_validQuestionnaire);
            Controls.Add(newTheme_block);
            Controls.Add(newTheme_btn);
            Controls.Add(comboBox_theme);
            Controls.Add(theme_label);
            Controls.Add(name_txtBox);
            Controls.Add(name_label);
            MinimumSize = new Size(800, 300);
            Name = "proprietyQuestionnaire";
            Text = "Propriété Questionnaire";
            newTheme_block.ResumeLayout(false);
            newTheme_block.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid_listeQuestions).EndInit();
            contextMenuStrip1.ResumeLayout(false);
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
        private Label label_listQuestions;
        private DataGridView dataGrid_listeQuestions;
        private Button btn_createQuestion;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem modifierToolStripMenuItem;
        private ToolStripMenuItem supprimerToolStripMenuItem;
    }
}