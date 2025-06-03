using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DotNetEnv;
using System.ComponentModel;

namespace QuestionnaireForm
{
    /// <summary>
    /// Formulaire principal pour l'affichage, la création, la modification et la suppression des questionnaires d'un utilisateur.
    /// </summary>
    public partial class listeQuestionnaireForm : Form
    {
        private string username;
        private int id_user;
        private DBConnection db;
        private List<Questionnaire> liste_questionnaires;

        /// <summary>
        /// Initialise le formulaire de gestion des questionnaires pour un utilisateur donné.
        /// </summary>
        /// <param name="db">Connexion à la base de données</param>
        /// <param name="username">Nom d'utilisateur</param>
        /// <param name="id_user">Identifiant utilisateur</param>
        public listeQuestionnaireForm(DBConnection db, string username, int id_user)
        {
            InitializeComponent();
            DotNetEnv.Env.Load();
            this.db = db;
            this.username = username;
            this.id_user = id_user;
            liste_questionnaires = GetQuestionnairesForUser();
            UpdateQuestionnaireGrid();
            dataGrid_listeQuestionnaire.ContextMenuStrip = contextMenuStrip1;
            // Sélectionne la ligne entière lors d'un clic
            dataGrid_listeQuestionnaire.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid_listeQuestionnaire.MultiSelect = false;
        }

        /// <summary>
        /// Récupère la liste des questionnaires créés par l'utilisateur courant.
        /// </summary>
        /// <returns>Liste des questionnaires</returns>
        private List<Questionnaire> GetQuestionnairesForUser()
        {
            var questionnaires = new List<Questionnaire>();
            if (db.IsConnect())
            {
                try
                {
                    MySqlCommand connectionRequest = new MySqlCommand(
                        "SELECT q.id, q.nom, t.nom AS theme_nom, " +
                        "COUNT(DISTINCT qs.id_question) AS nombre_de_questions FROM questionnaire q " +
                        "LEFT JOIN theme t ON q.theme = t.id_theme " +
                        "LEFT JOIN questions qs ON q.id = qs.id_questionnaire " +
                        "WHERE q.created_by = @user_id " +
                        "GROUP BY q.id, q.nom, theme_nom",
                        db.Connection
                    );
                    connectionRequest.Parameters.AddWithValue("@user_id", id_user);
                    using (MySqlDataReader reader = connectionRequest.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int questionnaireId = Convert.ToInt32(reader["id"]);
                            string questionnaireName = reader["nom"].ToString();
                            string themeName = reader["theme_nom"].ToString();
                            int questionCount = Convert.ToInt32(reader["nombre_de_questions"]);
                            questionnaires.Add(new Questionnaire(
                                questionnaireId,
                                questionnaireName,
                                themeName,
                                new List<Question>(),
                                questionCount
                            ));
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de la récupération des questionnaires: {ex.Message}");
                }
                finally
                {
                    db.Close();
                }
            }
            else
            {
                Console.WriteLine("Erreur de connexion à la base de données.");
            }
            return questionnaires;
        }

        /// <summary>
        /// Met à jour l'affichage de la liste des questionnaires dans le DataGridView.
        /// </summary>
        private void UpdateQuestionnaireGrid()
        {
            dataGrid_listeQuestionnaire.DataSource = null;
            var dataSource = liste_questionnaires
                .OrderBy(q => q.getTitle())
                .Select(q => new
                {
                    Titre = q.getTitle(),
                    Theme = q.getTheme(),
                    Questions = q.nombreDeQuestions()
                })
                .ToList();
            dataGrid_listeQuestionnaire.DataSource = dataSource;
        }

        /// <summary>
        /// Ouvre le formulaire de création d'un nouveau questionnaire.
        /// </summary>
        private void createAQuestionnaire_btn_Click(object sender, EventArgs e)
        {
            db.Close();
            proprietyQuestionnaire proprietyForm = new proprietyQuestionnaire(db, liste_questionnaires, id_user);
            proprietyForm.FormClosed += (s, args) => { RefreshQuestionnaireList(); };
            proprietyForm.ShowDialog();
        }

        /// <summary>
        /// Rafraîchit la liste des questionnaires et met à jour l'affichage.
        /// </summary>
        private void RefreshQuestionnaireList()
        {
            liste_questionnaires = GetQuestionnairesForUser();
            UpdateQuestionnaireGrid();
        }

        /// <summary>
        /// Gère l'ouverture du menu contextuel sur la liste des questionnaires.
        /// </summary>
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGrid_listeQuestionnaire.SelectedRows.Count == 0)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Ouvre le formulaire de modification du questionnaire sélectionné.
        /// </summary>
        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGrid_listeQuestionnaire.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGrid_listeQuestionnaire.SelectedRows[0].Index;
                db.Close();
                proprietyQuestionnaire proprietyForm = new proprietyQuestionnaire(db, liste_questionnaires, id_user, selectedIndex);
                proprietyForm.FormClosed += (s, args) => { RefreshQuestionnaireList(); };
                proprietyForm.ShowDialog();
            }
        }

        /// <summary>
        /// Supprime le questionnaire sélectionné après confirmation utilisateur.
        /// </summary>
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
                    DeleteQuestionnaire(selectedQuestionnaire);
                    RefreshQuestionnaireList();
                }
            }
        }

        /// <summary>
        /// Supprime un questionnaire de la base de données.
        /// </summary>
        /// <param name="questionnaire">Questionnaire à supprimer</param>
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