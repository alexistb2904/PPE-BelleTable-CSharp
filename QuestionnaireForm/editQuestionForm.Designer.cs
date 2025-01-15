namespace QuestionnaireForm
{
    partial class editQuestionForm
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
            label_question_name = new Label();
            txtbox_question_name = new TextBox();
            label_type = new Label();
            radioBtn_VF = new RadioButton();
            radioBtn_Value = new RadioButton();
            label_reponses = new Label();
            radioBtn_Vrai = new RadioButton();
            radioBtn_Faux = new RadioButton();
            flowPanel_VF = new FlowLayoutPanel();
            flowPanel_Types = new FlowLayoutPanel();
            flowPanel_VF.SuspendLayout();
            flowPanel_Types.SuspendLayout();
            SuspendLayout();
            // 
            // label_question_name
            // 
            label_question_name.AutoSize = true;
            label_question_name.Location = new Point(12, 9);
            label_question_name.Name = "label_question_name";
            label_question_name.Size = new Size(246, 32);
            label_question_name.TabIndex = 0;
            label_question_name.Text = "Quel est la question ?";
            // 
            // txtbox_question_name
            // 
            txtbox_question_name.Location = new Point(12, 44);
            txtbox_question_name.Multiline = true;
            txtbox_question_name.Name = "txtbox_question_name";
            txtbox_question_name.Size = new Size(776, 78);
            txtbox_question_name.TabIndex = 1;
            // 
            // label_type
            // 
            label_type.AutoSize = true;
            label_type.Location = new Point(12, 125);
            label_type.Name = "label_type";
            label_type.Size = new Size(199, 32);
            label_type.TabIndex = 2;
            label_type.Text = "Type de question";
            // 
            // radioBtn_VF
            // 
            radioBtn_VF.AutoSize = true;
            radioBtn_VF.Location = new Point(3, 3);
            radioBtn_VF.Name = "radioBtn_VF";
            radioBtn_VF.Size = new Size(142, 36);
            radioBtn_VF.TabIndex = 3;
            radioBtn_VF.TabStop = true;
            radioBtn_VF.Text = "Vrai/Faux";
            radioBtn_VF.UseVisualStyleBackColor = true;
            // 
            // radioBtn_Value
            // 
            radioBtn_Value.AutoSize = true;
            radioBtn_Value.Location = new Point(151, 3);
            radioBtn_Value.Name = "radioBtn_Value";
            radioBtn_Value.Size = new Size(210, 36);
            radioBtn_Value.TabIndex = 4;
            radioBtn_Value.TabStop = true;
            radioBtn_Value.Text = "Liste de Valeurs";
            radioBtn_Value.UseVisualStyleBackColor = true;
            // 
            // label_reponses
            // 
            label_reponses.AutoSize = true;
            label_reponses.Location = new Point(12, 223);
            label_reponses.Name = "label_reponses";
            label_reponses.Size = new Size(105, 32);
            label_reponses.TabIndex = 5;
            label_reponses.Text = "Réponse";
            // 
            // radioBtn_Vrai
            // 
            radioBtn_Vrai.AutoSize = true;
            radioBtn_Vrai.Location = new Point(3, 3);
            radioBtn_Vrai.Name = "radioBtn_Vrai";
            radioBtn_Vrai.Size = new Size(85, 36);
            radioBtn_Vrai.TabIndex = 6;
            radioBtn_Vrai.TabStop = true;
            radioBtn_Vrai.Text = "Vrai";
            radioBtn_Vrai.TextAlign = ContentAlignment.TopLeft;
            radioBtn_Vrai.UseVisualStyleBackColor = true;
            // 
            // radioBtn_Faux
            // 
            radioBtn_Faux.AutoSize = true;
            radioBtn_Faux.Location = new Point(94, 3);
            radioBtn_Faux.Name = "radioBtn_Faux";
            radioBtn_Faux.Size = new Size(93, 36);
            radioBtn_Faux.TabIndex = 7;
            radioBtn_Faux.TabStop = true;
            radioBtn_Faux.Text = "Faux";
            radioBtn_Faux.TextAlign = ContentAlignment.TopLeft;
            radioBtn_Faux.UseVisualStyleBackColor = true;
            // 
            // flowPanel_VF
            // 
            flowPanel_VF.Controls.Add(radioBtn_Vrai);
            flowPanel_VF.Controls.Add(radioBtn_Faux);
            flowPanel_VF.Location = new Point(12, 258);
            flowPanel_VF.Name = "flowPanel_VF";
            flowPanel_VF.Size = new Size(204, 46);
            flowPanel_VF.TabIndex = 8;
            // 
            // flowPanel_Types
            // 
            flowPanel_Types.Controls.Add(radioBtn_VF);
            flowPanel_Types.Controls.Add(radioBtn_Value);
            flowPanel_Types.Location = new Point(12, 162);
            flowPanel_Types.Name = "flowPanel_Types";
            flowPanel_Types.Size = new Size(776, 58);
            flowPanel_Types.TabIndex = 9;
            // 
            // editQuestionForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flowPanel_Types);
            Controls.Add(flowPanel_VF);
            Controls.Add(label_reponses);
            Controls.Add(label_type);
            Controls.Add(txtbox_question_name);
            Controls.Add(label_question_name);
            Name = "editQuestionForm";
            Text = "Questionnaire - Édition de question";
            flowPanel_VF.ResumeLayout(false);
            flowPanel_VF.PerformLayout();
            flowPanel_Types.ResumeLayout(false);
            flowPanel_Types.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_question_name;
        private TextBox txtbox_question_name;
        private Label label_type;
        private RadioButton radioBtn_VF;
        private RadioButton radioBtn_Value;
        private Label label_reponses;
        private RadioButton radioBtn_Vrai;
        private RadioButton radioBtn_Faux;
        private FlowLayoutPanel flowPanel_VF;
        private FlowLayoutPanel flowPanel_Types;
    }
}