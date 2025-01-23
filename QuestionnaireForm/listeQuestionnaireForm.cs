using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DotNetEnv;
using System.ComponentModel;

namespace QuestionnaireForm
{
    public partial class listeQuestionnaireForm : Form
    {
        private string username;
        private int id_user;
        private DBConnection db;
        private List<Questionnaire> liste_questionnaires;

        public listeQuestionnaireForm(DBConnection db, string username, int id_user)
        {
            InitializeComponent();
            Env.Load();
            this.db = db;
            this.username = username;
            this.id_user = id_user;
            liste_questionnaires = getQuestionnaireForUsername(username);
            appendListeQuestionnaire(liste_questionnaires);

            dataGrid_listeQuestionnaire.ContextMenuStrip = contextMenuStrip1;
        }

        private List<Questionnaire> getQuestionnaireForUsername(string username)
        {
            Console.WriteLine("getQuestionnaireForUsername");
            List<Questionnaire> liste_questionnairesT = new List<Questionnaire>();

            if (db.IsConnect())
            {
                try
                {
                    MySqlCommand connectionRequest = new MySqlCommand(
                        "SELECT q.id AS questionnaire_id, q.nom AS questionnaire_nom, t.nom AS theme_nom, " +
                        "COUNT(qs.id_question) AS nombre_de_questions FROM questionnaire q " +
                        "LEFT JOIN theme t ON q.theme = t.id_theme " +
                        "LEFT JOIN questions qs ON q.id = qs.id_questionnaire " +
                        "LEFT JOIN users u ON q.created_by = u.id " +
                        "WHERE u.username = @username " +
                        "GROUP BY q.id, q.nom, t.nom",
                        db.Connection
                    );

                    connectionRequest.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = connectionRequest.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Console.WriteLine("Des questionnaires trouvés");
                        }
                        else
                        {
                            Console.WriteLine("Aucun questionnaire trouvé");
                        }

                        while (reader.Read())
                        {
                            Console.WriteLine($"id_questionnaire: {reader["questionnaire_id"]}");
                            Console.WriteLine($"nom: {reader["questionnaire_nom"]}");
                            Console.WriteLine($"theme: {reader["theme_nom"]}");
                            Console.WriteLine($"nb_questions: {reader["nombre_de_questions"]}");

                            Questionnaire questionnaire = new Questionnaire(
                                Convert.ToInt32(reader["questionnaire_id"]),
                                reader["questionnaire_nom"].ToString(),
                                reader["theme_nom"].ToString(),
                                new List<Question>(),
                                Convert.ToInt32(reader["nombre_de_questions"])
                            );
                            liste_questionnairesT.Add(questionnaire);
                        }
                        reader.Close();
                    }
                    db.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de la récupération des questionnaires: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Erreur de connexion à la base de données.");
            }
            return liste_questionnairesT;
        }

        private void appendListeQuestionnaire(List<Questionnaire> listeDeQuestionnaire)
        {
            foreach (var item in listeDeQuestionnaire)
            {
                Console.WriteLine($"Questionnaire: {item.getTitle()} - {item.getTheme()}");
            }

            dataGrid_listeQuestionnaire.DataSource = null;
            // Créer une liste de questionnaires pour l'affichage dans le DataGridView
            var dataSource = listeDeQuestionnaire
            .OrderBy(q => q.getTitle())
            .Select(q => new
            {
                Titre = q.getTitle(),
                Theme = q.getTheme(),
                Questions = q.nombreDeQuestions()
            })
            .ToList();

            dataGrid_listeQuestionnaire.DataSource = dataSource;

            Console.WriteLine(dataGrid_listeQuestionnaire.Rows.Count);
        }

        private void createAQuestionnaire_btn_Click(object sender, EventArgs e)
        {
            db.Close();
            proprietyQuestionnaire proprietyForm = new proprietyQuestionnaire(db, liste_questionnaires, id_user);
            // Ajout d'un écouteur pour rafraîchir la liste des questionnaires après la fermeture de la fenêtre de propriétés
            proprietyForm.FormClosed += (s, args) => { RefreshQuestionnaireList(); };
            proprietyForm.ShowDialog();
        }

        private void RefreshQuestionnaireList()
        {
            liste_questionnaires = getQuestionnaireForUsername(username);
            appendListeQuestionnaire(liste_questionnaires);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGrid_listeQuestionnaire.SelectedRows.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGrid_listeQuestionnaire.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGrid_listeQuestionnaire.SelectedRows[0].Index;
                db.Close();
                
                proprietyQuestionnaire proprietyForm = new proprietyQuestionnaire(db, liste_questionnaires, id_user, selectedIndex);
                // Ajout d'un écouteur pour rafraîchir la liste des questionnaires après la fermeture de la fenêtre de propriétés
                proprietyForm.FormClosed += (s, args) => { RefreshQuestionnaireList(); };
                proprietyForm.ShowDialog();
            }
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGrid_listeQuestionnaire.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGrid_listeQuestionnaire.SelectedRows[0].Index;
                Questionnaire selectedQuestionnaire = liste_questionnaires[selectedIndex];

                DialogResult result = MessageBox.Show(
                    "Êtes-vous sûr de vouloir supprimer ce questionnaire?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    // Supprimer le questionnaire de la base de données
                    DeleteQuestionnaire(selectedQuestionnaire);

                    // Réactualiser la liste
                    RefreshQuestionnaireList();
                }
            }
        }

        private void DeleteQuestionnaire(Questionnaire questionnaire)
        {
            if (db.IsConnect())
            {
                try
                {
                    MySqlCommand deleteRequest = new MySqlCommand(
                        "DELETE FROM questionnaire WHERE id = @id",
                        db.Connection
                    );

                    deleteRequest.Parameters.AddWithValue("@id", questionnaire.getId());
                    deleteRequest.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de la suppression du questionnaire: {ex.Message}");
                }
                db.Close();
            }
            else
            {
                Console.WriteLine("Erreur de connexion à la base de données.");
            }
        }
    }
}