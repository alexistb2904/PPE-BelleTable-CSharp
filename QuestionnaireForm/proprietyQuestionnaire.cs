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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuestionnaireForm
{
    public partial class proprietyQuestionnaire : Form
    {
        private List<Questionnaire> listeDeQuestionnaire;
        private Questionnaire questionnaire;
        private int index;
        private DBConnection db = new DBConnection();
        private List<QuestionnaireTheme> ListeThemes = new List<QuestionnaireTheme>();
        private string nomQuestionnaire;
        private string themeQuestionnaire;
        private int created_by;
        public proprietyQuestionnaire(DBConnection db, List<Questionnaire> listeDeQuestionnaire, int creator, int indexTemp = -1)
        {
            InitializeComponent();
            this.listeDeQuestionnaire = listeDeQuestionnaire;
            index = indexTemp;
            this.db = db;
            created_by = creator;
            if (index != -1)
            {
                questionnaire = listeDeQuestionnaire[index];
                nomQuestionnaire = listeDeQuestionnaire[index].getTitle();
                themeQuestionnaire = listeDeQuestionnaire[index].getTheme();
            }
            else
            {
                questionnaire = new Questionnaire();
                nomQuestionnaire = "";
                themeQuestionnaire = "";
            }

            name_txtBox.Text = nomQuestionnaire;
            comboBox_theme.Text = themeQuestionnaire;

            getListOfTheme();
            foreach (QuestionnaireTheme theme in ListeThemes)
            {
                comboBox_theme.Items.Add(theme.name);
            }

            RefreshQuestionsList(true);

            dataGrid_listeQuestions.ContextMenuStrip = contextMenuStrip1;
        }

        private List<QuestionnaireTheme> getListOfTheme()
        {
            if (db.IsConnect())
            {
                try
                {
                    // Récupérer la liste des thèmes
                    MySqlCommand connectionRequest = new MySqlCommand(
                        "SELECT id_theme, nom FROM theme",
                        db.Connection
                    );

                    using (MySqlDataReader reader = connectionRequest.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int themeId = reader.GetInt32("id_theme");
                            string themeName = reader["nom"].ToString();

                            // Vérifier si le thème n'existe pas déjà dans la liste
                            if (!ListeThemes.Any(t => t.id == themeId))
                            {
                                ListeThemes.Add(new QuestionnaireTheme(themeName, themeId));
                            }
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de la récupération des themes: {ex.Message}");
                }
                return ListeThemes;
            }
            else
            {
                Console.WriteLine("Erreur de connexion à la base de données.");
                return null;
            }
        }

        private void newTheme_btn_Click(object sender, EventArgs e)
        {
            newTheme_block.Visible = true;
            txtBox_newTheme.Text = "";
            txtBox_newTheme.Focus();

        }

        private void btn_createTheme_Click(object sender, EventArgs e)
        {
            if (txtBox_newTheme.Text != "")
            {
                if (db.IsConnect())
                {
                    try
                    {
                        MySqlCommand insertRequest = new MySqlCommand("INSERT INTO theme (nom) VALUES (@nom)", db.Connection);
                        insertRequest.Parameters.AddWithValue("@nom", txtBox_newTheme.Text);
                        insertRequest.ExecuteNonQuery();
                        MessageBox.Show("Theme créé avec succès.");
                        newTheme_block.Visible = false;
                        comboBox_theme.Items.Clear();
                        ListeThemes.Clear();
                        getListOfTheme();
                        foreach (QuestionnaireTheme theme in ListeThemes)
                        {
                            if (comboBox_theme.Items.Contains(theme.name) == false)
                            {
                                comboBox_theme.Items.Add(theme.name);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erreur lors de la création du theme: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Erreur de connexion à la base de données.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nom de theme.");
            }
        }

        private void btn_validQuestionnaire_Click(object sender, EventArgs e)
        {
            if (name_txtBox.Text != "" && comboBox_theme.Text != "")
            {
                if (db.IsConnect())
                {
                    try
                    {
                        if (index != -1)
                        {
                            MySqlCommand updateRequest = new MySqlCommand("UPDATE questionnaire SET nom = @nom, theme = @theme WHERE id = @id", db.Connection);
                            updateRequest.Parameters.AddWithValue("@nom", name_txtBox.Text);
                            updateRequest.Parameters.AddWithValue("@theme", ListeThemes[comboBox_theme.SelectedIndex].id);
                            updateRequest.Parameters.AddWithValue("@id", listeDeQuestionnaire[index].getId());
                            updateRequest.ExecuteNonQuery();
                            MessageBox.Show("Questionnaire modifié avec succès.");
                        }
                        else
                        {
                            MySqlCommand insertRequest = new MySqlCommand("INSERT INTO questionnaire (nom, theme, created_by) VALUES (@nom, @theme, @created_by)", db.Connection);
                            insertRequest.Parameters.AddWithValue("@nom", name_txtBox.Text);
                            insertRequest.Parameters.AddWithValue("@theme", ListeThemes[comboBox_theme.SelectedIndex].id);
                            insertRequest.Parameters.AddWithValue("@created_by", created_by);
                            insertRequest.ExecuteNonQuery();
                            MessageBox.Show("Questionnaire créé avec succès.");
                        }
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erreur lors de la création du questionnaire: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Erreur de connexion à la base de données.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
            }
        }

        private void RefreshQuestionsList(bool firstTime = false)
{
    if (index != -1)
    {
        db.Close();
        if (db.IsConnect())
        {
            try
            {
                MySqlCommand connectionRequest = new MySqlCommand(
                    "SELECT q.id_question, q.question, q.type, " +
                    "GROUP_CONCAT(CASE WHEN c.est_reponse = 1 THEN c.texte END) AS reponses_texte, " +
                    "GROUP_CONCAT(c.texte) AS choix_texte, " + 
                    "GROUP_CONCAT(CASE WHEN c.est_reponse = 1 THEN c.id END) AS reponses_id, " +
                    "GROUP_CONCAT(c.id) AS choix_id, " +
                    "q.id_creator " +
                    "FROM questions q " +
                    "LEFT JOIN choix c ON q.id_question = c.id_question " +
                    "WHERE q.id_questionnaire = @id_questionnaire " +
                    "GROUP BY q.id_question",
                    db.Connection
                );
                connectionRequest.Parameters.AddWithValue("@id_questionnaire", questionnaire.getId());
                Console.WriteLine(questionnaire.getQuestions().Count);

                using (MySqlDataReader reader = connectionRequest.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string[] answersTexts = !string.IsNullOrEmpty(reader["reponses_texte"].ToString()) 
                            ? reader["reponses_texte"].ToString().Split(',') 
                            : new string[0];
                        
                        string[] choicesTexts = !string.IsNullOrEmpty(reader["choix_texte"].ToString()) 
                            ? reader["choix_texte"].ToString().Split(',') 
                            : new string[0];
                        
                        string[] answersIds = !string.IsNullOrEmpty(reader["reponses_id"].ToString()) 
                            ? reader["reponses_id"].ToString().Split(',') 
                            : new string[0];
                        
                        string[] choicesIds = !string.IsNullOrEmpty(reader["choix_id"].ToString()) 
                            ? reader["choix_id"].ToString().Split(',') 
                            : new string[0];
                        
                        int id_quest = reader.GetInt32("id_question");
                        Console.WriteLine("ID : " + id_quest);

                        if (firstTime)
                        {
                            Question question = new Question(
                                id_quest,
                                questionnaire.getId(),
                                created_by,
                                reader["question"].ToString(),
                                reader.GetInt32("type"),
                                answersTexts,
                                choicesTexts
                            );

                            questionnaire.addQuestion(question);
                        }
                        else
                        {
                            Question question = questionnaire.getQuestion(id_quest);
                            if (question != null)
                            {
                                question.SetText(reader["question"].ToString());
                                question.SetType(reader.GetInt32("type"), db);
                                question.SetAnswers(answersTexts);
                                question.SetChoices(choicesTexts);
                                question.setIdCreator(created_by);
                            }
                        }
                    }
                    reader.Close();
                }

                if (firstTime)
                {
                    for (int i = 0; i < questionnaire.getQuestions().Count; i++)
                    {
                        questionnaire.getQuestionByQuestionnaireIndex(i).GetType(db);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération des questions: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Erreur de connexion à la base de données.");
        }
        appendListeQuestionnaire(questionnaire.getQuestions());
    }
}


        private void appendListeQuestionnaire(List<Question> listeDeQuestion)
        {
            foreach (Question item in listeDeQuestion)
            {
                Console.WriteLine($"Question {item.GetId()}: {item.GetText()} - {item.GetStringType()}");
            }

            dataGrid_listeQuestions.DataSource = null;
            // Créer une liste de questionnaires pour l'affichage dans le DataGridView
            var dataSource = listeDeQuestion
            .Select(q => new
            {
                Question = q.GetText(),
                Type = q.GetStringType(),
            })
            .ToList();

            dataGrid_listeQuestions.DataSource = dataSource;

            Console.WriteLine(dataGrid_listeQuestions.Rows.Count);
        }

        private void btn_createQuestion_Click(object sender, EventArgs e)
        {
            db.Close();
            if (index != 1)
            {
                proprietyQuestionForm proprietyQuestionForm = new proprietyQuestionForm(db, created_by, listeDeQuestionnaire[index]);
                // Ajout d'un écouteur pour rafraîchir la liste des questionnaires après la fermeture de la fenêtre de propriétés
                proprietyQuestionForm.FormClosed += (s, args) => { RefreshQuestionsList(); };
                proprietyQuestionForm.ShowDialog();
            } else
            {
                MessageBox.Show("Veuillez enregistrer le questionnaire avant de créer une question.");
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGrid_listeQuestions.SelectedRows.Count == 0)
            {
                e.Cancel = true;
            }
        }

       private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
{
            if (dataGrid_listeQuestions.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGrid_listeQuestions.SelectedRows[0].Index;
                int questionId = questionnaire.getQuestions()[selectedIndex].GetId();
                db.Close();
                proprietyQuestionForm proprietyQuestionForm = new proprietyQuestionForm(db, created_by, listeDeQuestionnaire[index], questionId);
                // Ajout d'un écouteur pour rafraîchir la liste des questionnaires après la fermeture de la fenêtre de propriétés
                proprietyQuestionForm.FormClosed += (s, args) => { RefreshQuestionsList(); };
                proprietyQuestionForm.ShowDialog();
            }
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGrid_listeQuestions.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGrid_listeQuestions.SelectedRows[0].Index;
                Question selectedQuestion = listeDeQuestionnaire[index].getQuestion(selectedIndex);

                DialogResult result = MessageBox.Show(
                    "Êtes-vous sûr de vouloir supprimer ce questionnaire?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    // Supprimer le questionnaire de la base de données
                    selectedQuestion.deleteSelf(db);
                    Questionnaire questionnaire = listeDeQuestionnaire[index];
                    questionnaire.removeQuestion(selectedQuestion);

                    // Réactualiser la liste
                    RefreshQuestionsList();
                }
            }
        }
    }
}
