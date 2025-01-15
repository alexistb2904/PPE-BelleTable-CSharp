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
            dataGridView1 = new DataGridView();
            label_questionnaire = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 78);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.RowTemplate.Height = 41;
            dataGridView1.Size = new Size(776, 360);
            dataGridView1.TabIndex = 0;
            // 
            // label_questionnaire
            // 
            label_questionnaire.AutoSize = true;
            label_questionnaire.Location = new Point(12, 43);
            label_questionnaire.Name = "label_questionnaire";
            label_questionnaire.Size = new Size(311, 32);
            label_questionnaire.TabIndex = 1;
            label_questionnaire.Text = "Liste des questionnaire crée";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 5F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(557, 29);
            button1.Name = "button1";
            button1.Size = new Size(231, 46);
            button1.TabIndex = 2;
            button1.Text = "Créer un nouveau questionnaire";
            button1.UseVisualStyleBackColor = true;
            // 
            // listeQuestionnaireForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label_questionnaire);
            Controls.Add(dataGridView1);
            Name = "listeQuestionnaireForm";
            Text = "Questionnaire - Liste";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label_questionnaire;
        private Button button1;
    }
}