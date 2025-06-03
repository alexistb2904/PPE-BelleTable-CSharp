namespace QuestionnaireForm
{
    partial class listeQuestionnaireForm
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
            dataGrid_listeQuestionnaire = new DataGridView();
            label_questionnaire = new Label();
            createAQuestionnaire_btn = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            modifierToolStripMenuItem = new ToolStripMenuItem();
            supprimerToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGrid_listeQuestionnaire).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGrid_listeQuestionnaire
            // 
            dataGrid_listeQuestionnaire.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGrid_listeQuestionnaire.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid_listeQuestionnaire.BackgroundColor = Color.WhiteSmoke;
            dataGrid_listeQuestionnaire.BorderStyle = BorderStyle.None;
            dataGrid_listeQuestionnaire.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 33, 33);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGrid_listeQuestionnaire.DefaultCellStyle = dataGridViewCellStyle1;
            dataGrid_listeQuestionnaire.Location = new Point(6, 42);
            dataGrid_listeQuestionnaire.Margin = new Padding(2, 1, 2, 1);
            dataGrid_listeQuestionnaire.Name = "dataGrid_listeQuestionnaire";
            dataGrid_listeQuestionnaire.RowHeadersVisible = false;
            dataGrid_listeQuestionnaire.RowHeadersWidth = 82;
            dataGrid_listeQuestionnaire.RowTemplate.Height = 41;
            dataGrid_listeQuestionnaire.Size = new Size(519, 209);
            dataGrid_listeQuestionnaire.TabIndex = 0;
            // 
            // label_questionnaire
            // 
            label_questionnaire.AutoSize = true;
            label_questionnaire.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label_questionnaire.Location = new Point(6, 20);
            label_questionnaire.Margin = new Padding(2, 0, 2, 0);
            label_questionnaire.Name = "label_questionnaire";
            label_questionnaire.Size = new Size(221, 21);
            label_questionnaire.TabIndex = 1;
            label_questionnaire.Text = "Liste des questionnaire crée";
            // 
            // createAQuestionnaire_btn
            // 
            createAQuestionnaire_btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            createAQuestionnaire_btn.BackColor = Color.FromArgb(33, 150, 243);
            createAQuestionnaire_btn.FlatAppearance.BorderSize = 0;
            createAQuestionnaire_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 136, 229);
            createAQuestionnaire_btn.FlatStyle = FlatStyle.Flat;
            createAQuestionnaire_btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            createAQuestionnaire_btn.ForeColor = Color.White;
            createAQuestionnaire_btn.Location = new Point(352, 10);
            createAQuestionnaire_btn.Margin = new Padding(2, 1, 2, 1);
            createAQuestionnaire_btn.Name = "createAQuestionnaire_btn";
            createAQuestionnaire_btn.Size = new Size(161, 26);
            createAQuestionnaire_btn.TabIndex = 2;
            createAQuestionnaire_btn.Text = "Créer un nouveau questionnaire";
            createAQuestionnaire_btn.UseVisualStyleBackColor = false;
            createAQuestionnaire_btn.Click += createAQuestionnaire_btn_Click;
            // 
            // contextMenuStrip1
            // 
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
            // listeQuestionnaireForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(536, 261);
            Controls.Add(createAQuestionnaire_btn);
            Controls.Add(label_questionnaire);
            Controls.Add(dataGrid_listeQuestionnaire);
            Margin = new Padding(2, 1, 2, 1);
            MinimumSize = new Size(500, 300);
            Name = "listeQuestionnaireForm";
            Text = "Questionnaire - Liste";
            ((System.ComponentModel.ISupportInitialize)dataGrid_listeQuestionnaire).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGrid_listeQuestionnaire;
        private Label label_questionnaire;
        private Button createAQuestionnaire_btn;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem modifierToolStripMenuItem;
        private ToolStripMenuItem supprimerToolStripMenuItem;
    }
}