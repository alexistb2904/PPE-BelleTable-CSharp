using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QuestionnaireForm
{
    public partial class proprietyQuestionForm : Form
    {
        private Questionnaire questionnaire;
        private int creator_id;
        private DBConnection db;
        private int index;
        private string TypeDeQuestion;
        private Question questions;
        private List<QuestionType> ListeType = new List<QuestionType>();
        public proprietyQuestionForm(DBConnection db, int creator_id, Questionnaire questionnaire, int index = -1)
        {
            InitializeComponent();
            this.db = db;
            this.creator_id = creator_id;
            this.questionnaire = questionnaire;
            this.index = index;
            GetTypes(db);
            foreach (QuestionType type in ListeType)
            {
                comboBox_type.Items.Add(type.name);
            }
            comboBox_type.SelectedIndex = 0;
            if (index != -1)
            {
                questions = questionnaire.getQuestion(index);
                txtbox_question_name.Text = questions.GetText();
                TypeDeQuestion = questions.GetType(db);
                comboBox_type.Text = TypeDeQuestion;
                if (TypeDeQuestion == "Vrai/Faux")
                {
                    flowPanel_VF.Visible = true;
                    flow_multipleChoices.Visible = false;

                    if (questions.GetAnswers()[0] == "Vrai")
                    {
                        radioBtn_Vrai.Checked = true;
                    }
                    else
                    {
                        radioBtn_Faux.Checked = true;
                    }
                }
                else
                {
                    flowPanel_VF.Visible = false;
                    flow_multipleChoices.Visible = true;
                    string[] choices = questions.GetChoices();
                    string[] answer = questions.GetAnswers();

                    for (global::System.Int32 i = 0; i < choices.Length; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                rich_txtBox_1.Text = choices[i];
                                if (questions.CheckAnswer(choices[i]))
                                {
                                    checkBox_1.Checked = true;
                                }
                                break;
                            case 1:
                                rich_txtBox_2.Text = choices[i];
                                if (questions.CheckAnswer(choices[i]))
                                {
                                    checkBox_2.Checked = true;
                                }
                                break;
                            case 2:
                                rich_txtBox_3.Text = choices[i];
                                if (questions.CheckAnswer(choices[i]))
                                {
                                    checkBox_3.Checked = true;
                                }
                                break;
                        }
                    }
                }
            }
            else
            {
                questions = new Question();
            }
        }

        public List<QuestionType> GetTypes(DBConnection db)
        {
            if (db.IsConnect())
            {
                try
                {
                    MySqlCommand connectionRequest = new MySqlCommand(
                        "SELECT id_type, nom FROM types",
                        db.Connection
                    );

                    using (MySqlDataReader reader = connectionRequest.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            if (ListeType.Contains(new QuestionType(reader.GetInt32(0), reader["nom"].ToString())) == false)
                            {
                                ListeType.Add(new QuestionType(reader.GetInt32(0), reader["nom"].ToString()));
                            }
                        }
                        reader.Close();

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de la récupération des types: {ex.Message}");
                }
                db.Close();
                return ListeType;
            }
            else
            {
                Console.WriteLine("Erreur de connexion à la base de données.");
                return null;
            }
        }

        public void ValidTheQuestion(DBConnection db)
        {
                try
                {

                    questions.SetText(txtbox_question_name.Text);
                    questions.SetType(ListeType[comboBox_type.SelectedIndex].id, db);
                    questions.SetQuestionnaireId(questionnaire.getId());
                    questions.setIdCreator(creator_id);
                    if (comboBox_type.Text == "Vrai/Faux")
                    {
                        string[] checkedBoxText = new string[1];
                        if (radioBtn_Vrai.Checked)
                        {
                            checkedBoxText[0] = "Vrai";
                        }
                        else
                        {
                            checkedBoxText[0] = "Faux";
                        }

                        string[] choices = new string[] { "Vrai", "Faux" };
                        questions.SetChoices(choices);
                        questions.SetAnswers(checkedBoxText);
                    }
                    else
                    {
                        string[] checkedBoxText = new string[3];
                        string[] choices = new string[3];
                        if (checkBox_1.Checked)
                        {
                            checkedBoxText[0] = rich_txtBox_1.Text;
                        }
                        if (checkBox_2.Checked)
                        {
                            checkedBoxText[1] = rich_txtBox_2.Text;
                        }
                        if (checkBox_3.Checked)
                        {
                            checkedBoxText[2] = rich_txtBox_3.Text;
                        }
                        choices[0] = rich_txtBox_1.Text;
                        choices[1] = rich_txtBox_2.Text;
                        choices[2] = rich_txtBox_3.Text;
                        questions.SetChoices(choices);
                        questions.SetAnswers(checkedBoxText);
                    }

                    if (index != -1)
                    {
                        questions.updateQuestion(db);
                    }
                    else
                    {
                        questionnaire.addQuestion(questions);
                        questions.insertQuestion(db);
                    }



                    db.Close();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la création");
                    Console.WriteLine($"Erreur lors de la création: {ex.Message}");
                }
        }

        public void comboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_type.Text == "Vrai/Faux")
            {
                flowPanel_VF.Visible = true;
                flow_multipleChoices.Visible = false;
            }
            else
            {
                flowPanel_VF.Visible = false;
                flow_multipleChoices.Visible = true;
            }
        }

        public void btn_valid_Click(object sender, EventArgs e)
        {
            ValidTheQuestion(db);
        }
    }
}
