namespace QuestionnaireForm
{
    partial class proprietyQuestionForm
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
            label_reponses = new Label();
            radioBtn_Vrai = new RadioButton();
            radioBtn_Faux = new RadioButton();
            flowPanel_VF = new FlowLayoutPanel();
            flowPanel_Types = new FlowLayoutPanel();
            comboBox_type = new ComboBox();
            flow_multipleChoices = new FlowLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            rich_txtBox_1 = new RichTextBox();
            rich_txtBox_2 = new RichTextBox();
            rich_txtBox_3 = new RichTextBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            checkBox_1 = new CheckBox();
            checkBox_2 = new CheckBox();
            checkBox_3 = new CheckBox();
            btn_valid = new Button();
            flowPanel_VF.SuspendLayout();
            flowPanel_Types.SuspendLayout();
            flow_multipleChoices.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // label_question_name
            // 
            label_question_name.AutoSize = true;
            label_question_name.Location = new Point(6, 4);
            label_question_name.Margin = new Padding(2, 0, 2, 0);
            label_question_name.Name = "label_question_name";
            label_question_name.Size = new Size(119, 15);
            label_question_name.TabIndex = 0;
            label_question_name.Text = "Quel est la question ?";
            // 
            // txtbox_question_name
            // 
            txtbox_question_name.Location = new Point(8, 21);
            txtbox_question_name.Margin = new Padding(2, 1, 2, 1);
            txtbox_question_name.Multiline = true;
            txtbox_question_name.Name = "txtbox_question_name";
            txtbox_question_name.Size = new Size(420, 39);
            txtbox_question_name.TabIndex = 1;
            // 
            // label_type
            // 
            label_type.AutoSize = true;
            label_type.Location = new Point(6, 59);
            label_type.Margin = new Padding(2, 0, 2, 0);
            label_type.Name = "label_type";
            label_type.Size = new Size(97, 15);
            label_type.TabIndex = 2;
            label_type.Text = "Type de question";
            // 
            // label_reponses
            // 
            label_reponses.AutoSize = true;
            label_reponses.Location = new Point(6, 105);
            label_reponses.Margin = new Padding(2, 0, 2, 0);
            label_reponses.Name = "label_reponses";
            label_reponses.Size = new Size(52, 15);
            label_reponses.TabIndex = 5;
            label_reponses.Text = "Réponse";
            // 
            // radioBtn_Vrai
            // 
            radioBtn_Vrai.AutoSize = true;
            radioBtn_Vrai.Location = new Point(2, 1);
            radioBtn_Vrai.Margin = new Padding(2, 1, 2, 1);
            radioBtn_Vrai.Name = "radioBtn_Vrai";
            radioBtn_Vrai.Size = new Size(45, 19);
            radioBtn_Vrai.TabIndex = 6;
            radioBtn_Vrai.TabStop = true;
            radioBtn_Vrai.Text = "Vrai";
            radioBtn_Vrai.TextAlign = ContentAlignment.TopLeft;
            radioBtn_Vrai.UseVisualStyleBackColor = true;
            // 
            // radioBtn_Faux
            // 
            radioBtn_Faux.AutoSize = true;
            radioBtn_Faux.Location = new Point(51, 1);
            radioBtn_Faux.Margin = new Padding(2, 1, 2, 1);
            radioBtn_Faux.Name = "radioBtn_Faux";
            radioBtn_Faux.Size = new Size(49, 19);
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
            flowPanel_VF.Location = new Point(6, 121);
            flowPanel_VF.Margin = new Padding(2, 1, 2, 1);
            flowPanel_VF.Name = "flowPanel_VF";
            flowPanel_VF.Size = new Size(110, 22);
            flowPanel_VF.TabIndex = 8;
            // 
            // flowPanel_Types
            // 
            flowPanel_Types.Controls.Add(comboBox_type);
            flowPanel_Types.Location = new Point(6, 76);
            flowPanel_Types.Margin = new Padding(2, 1, 2, 1);
            flowPanel_Types.Name = "flowPanel_Types";
            flowPanel_Types.Size = new Size(418, 27);
            flowPanel_Types.TabIndex = 9;
            // 
            // comboBox_type
            // 
            comboBox_type.FormattingEnabled = true;
            comboBox_type.Location = new Point(2, 1);
            comboBox_type.Margin = new Padding(2, 1, 2, 1);
            comboBox_type.Name = "comboBox_type";
            comboBox_type.Size = new Size(418, 23);
            comboBox_type.TabIndex = 0;
            comboBox_type.SelectedIndexChanged += comboBox_type_SelectedIndexChanged;
            // 
            // flow_multipleChoices
            // 
            flow_multipleChoices.Controls.Add(flowLayoutPanel1);
            flow_multipleChoices.Controls.Add(flowLayoutPanel2);
            flow_multipleChoices.Location = new Point(6, 145);
            flow_multipleChoices.Margin = new Padding(2, 1, 2, 1);
            flow_multipleChoices.Name = "flow_multipleChoices";
            flow_multipleChoices.Size = new Size(418, 131);
            flow_multipleChoices.TabIndex = 10;
            flow_multipleChoices.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(rich_txtBox_1);
            flowLayoutPanel1.Controls.Add(rich_txtBox_2);
            flowLayoutPanel1.Controls.Add(rich_txtBox_3);
            flowLayoutPanel1.Location = new Point(2, 1);
            flowLayoutPanel1.Margin = new Padding(2, 1, 2, 1);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(415, 81);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // rich_txtBox_1
            // 
            rich_txtBox_1.Location = new Point(2, 1);
            rich_txtBox_1.Margin = new Padding(2, 1, 2, 1);
            rich_txtBox_1.Name = "rich_txtBox_1";
            rich_txtBox_1.Size = new Size(132, 78);
            rich_txtBox_1.TabIndex = 0;
            rich_txtBox_1.Text = "";
            // 
            // rich_txtBox_2
            // 
            rich_txtBox_2.Location = new Point(138, 1);
            rich_txtBox_2.Margin = new Padding(2, 1, 2, 1);
            rich_txtBox_2.Name = "rich_txtBox_2";
            rich_txtBox_2.Size = new Size(144, 78);
            rich_txtBox_2.TabIndex = 1;
            rich_txtBox_2.Text = "";
            // 
            // rich_txtBox_3
            // 
            rich_txtBox_3.Location = new Point(286, 1);
            rich_txtBox_3.Margin = new Padding(2, 1, 2, 1);
            rich_txtBox_3.Name = "rich_txtBox_3";
            rich_txtBox_3.Size = new Size(126, 78);
            rich_txtBox_3.TabIndex = 2;
            rich_txtBox_3.Text = "";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(checkBox_1);
            flowLayoutPanel2.Controls.Add(checkBox_2);
            flowLayoutPanel2.Controls.Add(checkBox_3);
            flowLayoutPanel2.Location = new Point(2, 84);
            flowLayoutPanel2.Margin = new Padding(2, 1, 2, 1);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(415, 40);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // checkBox_1
            // 
            checkBox_1.CheckAlign = ContentAlignment.TopCenter;
            checkBox_1.Location = new Point(2, 1);
            checkBox_1.Margin = new Padding(2, 1, 2, 1);
            checkBox_1.Name = "checkBox_1";
            checkBox_1.Size = new Size(138, 39);
            checkBox_1.TabIndex = 0;
            checkBox_1.Text = "Réponse 1";
            checkBox_1.TextAlign = ContentAlignment.MiddleCenter;
            checkBox_1.UseVisualStyleBackColor = true;
            // 
            // checkBox_2
            // 
            checkBox_2.CheckAlign = ContentAlignment.TopCenter;
            checkBox_2.Location = new Point(144, 1);
            checkBox_2.Margin = new Padding(2, 1, 2, 1);
            checkBox_2.Name = "checkBox_2";
            checkBox_2.Size = new Size(138, 39);
            checkBox_2.TabIndex = 1;
            checkBox_2.Text = "Réponse 2";
            checkBox_2.TextAlign = ContentAlignment.MiddleCenter;
            checkBox_2.UseVisualStyleBackColor = true;
            // 
            // checkBox_3
            // 
            checkBox_3.CheckAlign = ContentAlignment.TopCenter;
            checkBox_3.Location = new Point(286, 1);
            checkBox_3.Margin = new Padding(2, 1, 2, 1);
            checkBox_3.Name = "checkBox_3";
            checkBox_3.Size = new Size(126, 39);
            checkBox_3.TabIndex = 2;
            checkBox_3.Text = "Réponse 3";
            checkBox_3.TextAlign = ContentAlignment.MiddleCenter;
            checkBox_3.UseVisualStyleBackColor = true;
            // 
            // btn_valid
            // 
            btn_valid.Location = new Point(6, 284);
            btn_valid.Margin = new Padding(2, 1, 2, 1);
            btn_valid.Name = "btn_valid";
            btn_valid.Size = new Size(418, 22);
            btn_valid.TabIndex = 11;
            btn_valid.Text = "Valider";
            btn_valid.UseVisualStyleBackColor = true;
            btn_valid.Click += btn_valid_Click;
            // 
            // proprietyQuestionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 309);
            Controls.Add(btn_valid);
            Controls.Add(flow_multipleChoices);
            Controls.Add(flowPanel_Types);
            Controls.Add(flowPanel_VF);
            Controls.Add(label_reponses);
            Controls.Add(label_type);
            Controls.Add(txtbox_question_name);
            Controls.Add(label_question_name);
            Margin = new Padding(2, 1, 2, 1);
            Name = "proprietyQuestionForm";
            Text = "Questionnaire - Propriété de question";
            flowPanel_VF.ResumeLayout(false);
            flowPanel_VF.PerformLayout();
            flowPanel_Types.ResumeLayout(false);
            flow_multipleChoices.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_question_name;
        private TextBox txtbox_question_name;
        private Label label_type;
        private Label label_reponses;
        private RadioButton radioBtn_Vrai;
        private RadioButton radioBtn_Faux;
        private FlowLayoutPanel flowPanel_VF;
        private FlowLayoutPanel flowPanel_Types;
        private ComboBox comboBox_type;
        private FlowLayoutPanel flow_multipleChoices;
        private FlowLayoutPanel flowLayoutPanel1;
        private RichTextBox rich_txtBox_1;
        private RichTextBox rich_txtBox_2;
        private RichTextBox rich_txtBox_3;
        private FlowLayoutPanel flowLayoutPanel2;
        private CheckBox checkBox_1;
        private CheckBox checkBox_2;
        private CheckBox checkBox_3;
        private Button btn_valid;
    }
}