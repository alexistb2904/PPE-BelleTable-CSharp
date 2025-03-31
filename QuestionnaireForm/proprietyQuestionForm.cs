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
        private Questionnaire questionnaire { get; set; }
        private int creator_id { get; set; }
        private DBConnection db;
        private int questionID { get; set; }
        private string TypeDeQuestion { get; set; }
        private Question questions { get; set; }
        private List<QuestionType> ListeType = new List<QuestionType>();
        public proprietyQuestionForm(DBConnection db, int creator_id, Questionnaire questionnaire, int questionIDGiven = -1)
        {
            InitializeComponent();
            this.db = db;
            this.creator_id = creator_id;
            this.questionnaire = questionnaire;
            questionID = questionIDGiven;
            GetTypes(db);
            foreach (QuestionType type in ListeType)
            {
                comboBox_type.Items.Add(type.name);
            }
            comboBox_type.SelectedIndex = 0;
            if (questionID != -1)
            {
                questions = questionnaire.getQuestion(questionID);
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
                    List<string> checkedBoxText = new List<string>();
                    List<string> choices = new List<string>();

                    if (!string.IsNullOrEmpty(rich_txtBox_1.Text))
                    {
                        choices.Add(rich_txtBox_1.Text);
                        if (checkBox_1.Checked)
                        {
                            checkedBoxText.Add(rich_txtBox_1.Text);
                        }
                    }

                    if (!string.IsNullOrEmpty(rich_txtBox_2.Text))
                    {
                        choices.Add(rich_txtBox_2.Text);
                        if (checkBox_2.Checked)
                        {
                            checkedBoxText.Add(rich_txtBox_2.Text);
                        }
                    }

                    if (!string.IsNullOrEmpty(rich_txtBox_3.Text))
                    {
                        choices.Add(rich_txtBox_3.Text);
                        if (checkBox_3.Checked)
                        {
                            checkedBoxText.Add(rich_txtBox_3.Text);
                        }
                    }

                    questions.SetChoices(choices.ToArray());
                    questions.SetAnswers(checkedBoxText.ToArray());
                }

                if (questionID != -1)
                {
                    questions.updateQuestion(db);
                }
                else
                {
                    questions.insertQuestion(db);
                    questionnaire.addQuestion(questions);
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
