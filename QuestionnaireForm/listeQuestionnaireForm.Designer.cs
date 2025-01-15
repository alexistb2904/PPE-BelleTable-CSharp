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
            dataGrid_listeQuestionnaire = new DataGridView();
            label_questionnaire = new Label();
            createAQuestionnaire_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGrid_listeQuestionnaire).BeginInit();
            SuspendLayout();
            // 
            // dataGrid_listeQuestionnaire
            // 
            dataGrid_listeQuestionnaire.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_listeQuestionnaire.Location = new Point(6, 37);
            dataGrid_listeQuestionnaire.Margin = new Padding(2, 1, 2, 1);
            dataGrid_listeQuestionnaire.Name = "dataGrid_listeQuestionnaire";
            dataGrid_listeQuestionnaire.RowHeadersWidth = 82;
            dataGrid_listeQuestionnaire.RowTemplate.Height = 41;
            dataGrid_listeQuestionnaire.Size = new Size(418, 169);
            dataGrid_listeQuestionnaire.TabIndex = 0;
            // 
            // label_questionnaire
            // 
            label_questionnaire.AutoSize = true;
            label_questionnaire.Location = new Point(6, 20);
            label_questionnaire.Margin = new Padding(2, 0, 2, 0);
            label_questionnaire.Name = "label_questionnaire";
            label_questionnaire.Size = new Size(152, 15);
            label_questionnaire.TabIndex = 1;
            label_questionnaire.Text = "Liste des questionnaire crée";
            // 
            // createAQuestionnaire_btn
            // 
            createAQuestionnaire_btn.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            createAQuestionnaire_btn.Location = new Point(300, 14);
            createAQuestionnaire_btn.Margin = new Padding(2, 1, 2, 1);
            createAQuestionnaire_btn.Name = "createAQuestionnaire_btn";
            createAQuestionnaire_btn.Size = new Size(124, 22);
            createAQuestionnaire_btn.TabIndex = 2;
            createAQuestionnaire_btn.Text = "Créer un nouveau questionnaire";
            createAQuestionnaire_btn.UseVisualStyleBackColor = true;
            createAQuestionnaire_btn.Click += createAQuestionnaire_btn_Click;
            // 
            // listeQuestionnaireForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 211);
            Controls.Add(createAQuestionnaire_btn);
            Controls.Add(label_questionnaire);
            Controls.Add(dataGrid_listeQuestionnaire);
            Margin = new Padding(2, 1, 2, 1);
            Name = "listeQuestionnaireForm";
            Text = "Questionnaire - Liste";
            ((System.ComponentModel.ISupportInitialize)dataGrid_listeQuestionnaire).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGrid_listeQuestionnaire;
        private Label label_questionnaire;
        private Button createAQuestionnaire_btn;
    }
}