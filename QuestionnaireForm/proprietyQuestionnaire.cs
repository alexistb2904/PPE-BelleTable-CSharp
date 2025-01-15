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
        private int index;
        private DBConnection db = new DBConnection();
        private List<QuestionnaireTheme> ListeThemes = new List<QuestionnaireTheme>();
        private string nomQuestionnaire;
        private string themeQuestionnaire;
        private int created_by;
        public proprietyQuestionnaire(DBConnection db, List<Questionnaire> listeDeQuestionnaire, int creator, int index = -1)
        {
            InitializeComponent();
            this.listeDeQuestionnaire = listeDeQuestionnaire;
            this.index = index;
            this.db = db;
            created_by = creator;
            if (index != -1)
            {
                nomQuestionnaire = listeDeQuestionnaire[index].getTitle();
                themeQuestionnaire = listeDeQuestionnaire[index].getTheme();
            }
            else
            {
                nomQuestionnaire = "";
                themeQuestionnaire = "";
            }

            getListOfTheme();
            foreach (QuestionnaireTheme theme in ListeThemes)
            {
                comboBox_theme.Items.Add(theme.name);
            }
        }

        private List<QuestionnaireTheme> getListOfTheme()
        {
            if (db.IsConnect())
            {
                try
                {
                    // Récupérer la liste des questionnaires créés par l'utilisateur
                    MySqlCommand connectionRequest = new MySqlCommand(
                        "SELECT id_theme as id, nom FROM theme",
                        db.Connection
                    );

                    using (MySqlDataReader reader = connectionRequest.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            if (ListeThemes.Contains(new QuestionnaireTheme(reader["nom"].ToString(), reader.GetInt32(0))) == false)
                            {
                                ListeThemes.Add(new QuestionnaireTheme(reader["nom"].ToString(), reader.GetInt32(0)));
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
    }
}
