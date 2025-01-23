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
            name_label.Location = new Point(22, 19);
            name_label.Margin = new Padding(6, 0, 6, 0);
            name_label.Name = "name_label";
            name_label.Size = new Size(255, 32);
            name_label.TabIndex = 0;
            name_label.Text = "Nom du questionnaire";
            // 
            // name_txtBox
            // 
            name_txtBox.Location = new Point(22, 58);
            name_txtBox.Margin = new Padding(6);
            name_txtBox.Name = "name_txtBox";
            name_txtBox.Size = new Size(621, 39);
            name_txtBox.TabIndex = 1;
            // 
            // theme_label
            // 
            theme_label.AutoSize = true;
            theme_label.Location = new Point(22, 139);
            theme_label.Margin = new Padding(6, 0, 6, 0);
            theme_label.Name = "theme_label";
            theme_label.Size = new Size(279, 32);
            theme_label.TabIndex = 2;
            theme_label.Text = "Theme de Questionnaire";
            // 
            // comboBox_theme
            // 
            comboBox_theme.FormattingEnabled = true;
            comboBox_theme.Location = new Point(22, 177);
            comboBox_theme.Margin = new Padding(6);
            comboBox_theme.Name = "comboBox_theme";
            comboBox_theme.Size = new Size(621, 40);
            comboBox_theme.TabIndex = 3;
            // 
            // newTheme_btn
            // 
            newTheme_btn.Location = new Point(351, 130);
            newTheme_btn.Margin = new Padding(6);
            newTheme_btn.Name = "newTheme_btn";
            newTheme_btn.Size = new Size(295, 49);
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
            newTheme_block.Location = new Point(22, 239);
            newTheme_block.Margin = new Padding(6);
            newTheme_block.Name = "newTheme_block";
            newTheme_block.Size = new Size(624, 162);
            newTheme_block.TabIndex = 5;
            newTheme_block.Visible = false;
            // 
            // newTheme_label
            // 
            newTheme_label.AutoSize = true;
            newTheme_label.Location = new Point(6, 0);
            newTheme_label.Margin = new Padding(6, 0, 6, 0);
            newTheme_label.Name = "newTheme_label";
            newTheme_label.Size = new Size(192, 32);
            newTheme_label.TabIndex = 0;
            newTheme_label.Text = "Nouveau Theme";
            // 
            // txtBox_newTheme
            // 
            txtBox_newTheme.Location = new Point(6, 38);
            txtBox_newTheme.Margin = new Padding(6);
            txtBox_newTheme.Name = "txtBox_newTheme";
            txtBox_newTheme.Size = new Size(615, 39);
            txtBox_newTheme.TabIndex = 1;
            // 
            // btn_createTheme
            // 
            btn_createTheme.Location = new Point(6, 89);
            btn_createTheme.Margin = new Padding(6);
            btn_createTheme.Name = "btn_createTheme";
            btn_createTheme.Size = new Size(618, 49);
            btn_createTheme.TabIndex = 2;
            btn_createTheme.Text = "Créer";
            btn_createTheme.UseVisualStyleBackColor = true;
            btn_createTheme.Click += btn_createTheme_Click;
            // 
            // btn_validQuestionnaire
            // 
            btn_validQuestionnaire.Location = new Point(22, 420);
            btn_validQuestionnaire.Margin = new Padding(6);
            btn_validQuestionnaire.Name = "btn_validQuestionnaire";
            btn_validQuestionnaire.Size = new Size(624, 49);
            btn_validQuestionnaire.TabIndex = 6;
            btn_validQuestionnaire.Text = "Valider";
            btn_validQuestionnaire.UseVisualStyleBackColor = false;
            btn_validQuestionnaire.Click += btn_validQuestionnaire_Click;
            // 
            // label_listQuestions
            // 
            label_listQuestions.AutoSize = true;
            label_listQuestions.Location = new Point(685, 19);
            label_listQuestions.Name = "label_listQuestions";
            label_listQuestions.Size = new Size(216, 32);
            label_listQuestions.TabIndex = 7;
            label_listQuestions.Text = "Liste des questions";
            // 
            // dataGrid_listeQuestions
            // 
            dataGrid_listeQuestions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_listeQuestions.Location = new Point(685, 58);
            dataGrid_listeQuestions.Name = "dataGrid_listeQuestions";
            dataGrid_listeQuestions.RowHeadersWidth = 82;
            dataGrid_listeQuestions.RowTemplate.Height = 41;
            dataGrid_listeQuestions.Size = new Size(639, 343);
            dataGrid_listeQuestions.TabIndex = 8;
            // 
            // btn_createQuestion
            // 
            btn_createQuestion.Location = new Point(685, 423);
            btn_createQuestion.Name = "btn_createQuestion";
            btn_createQuestion.Size = new Size(639, 46);
            btn_createQuestion.TabIndex = 9;
            btn_createQuestion.Text = "Créer une question";
            btn_createQuestion.UseVisualStyleBackColor = true;
            btn_createQuestion.Click += btn_createQuestion_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(32, 32);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { modifierToolStripMenuItem, supprimerToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(301, 124);
            contextMenuStrip1.Text = "Édition";
            // 
            // modifierToolStripMenuItem
            // 
            modifierToolStripMenuItem.Name = "modifierToolStripMenuItem";
            modifierToolStripMenuItem.Size = new Size(300, 38);
            modifierToolStripMenuItem.Text = "Modifier";
            // 
            // supprimerToolStripMenuItem
            // 
            supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            supprimerToolStripMenuItem.Size = new Size(300, 38);
            supprimerToolStripMenuItem.Text = "Supprimer";
            // 
            // proprietyQuestionnaire
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1360, 495);
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
            Margin = new Padding(6);
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