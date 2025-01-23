using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuestionnaireForm
{
    public class Question
    {
        private int id_questionnaire { get; set; }
        private int id { get; set; }
        private int idCreator { get; set; }
        private string Text { get; set; }
        private string[] Answers { get; set; }

        private int Type { get; set; }
        private string StringType { get; set; }
        private string[] Choices { get; set; }

        public Question()
        {
            Text = "";
            Answers = new string[0];
            Type = 0;
            Choices = new string[0];
        }

        public Question(int id, int id_questionnaire, int creatorId, string text, int type, string[] answers, string[] choices)
        {
            this.id = id;
            this.id_questionnaire = id_questionnaire;
            idCreator = creatorId;
            Text = text;
            Type = type;
            Answers = answers;
            Choices = choices;
        }

        public bool CheckAnswer(string answer)
        {
            return Answers.Contains(answer);
        }

        public string[] GetAnswers()
        {
            return Answers;
        }

        public string GetText()
        {
            return Text;
        }

        public int GetIdCreator()
        {
            return idCreator;
        }



        public string GetType(DBConnection db)
        {
            if (db.IsConnect())
            {
                Console.WriteLine("Connected to database");
                MySqlCommand connectionRequest = new MySqlCommand(
                    "SELECT nom FROM questions INNER JOIN types ON type = id_type",
                    db.Connection
                );

                using (var reader = connectionRequest.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        StringType = reader.GetString(0);
                        return StringType;
                    }
                }
                return "Erreur de lecture de la base de données.";
            }
            else
            {
                return "Erreur de connexion à la base de données.";
            }
        }

        public string GetStringType()
        {
            return StringType;
        }

        public string[] GetChoices()
        {
            return Choices;
        }

        public void SetAnswers(string[] answers)
        {
            Answers = answers;
        }

        public void SetText(string text)
        {
            Text = text;
        }

        public void SetType(int type, DBConnection db)
        {
            Type = type;
            GetType(db);
        }

        public void SetChoices(string[] choices)
        {
            Choices = choices;
        }

        public void SetQuestionnaireId(int id_questionnaire)
        {
            this.id_questionnaire = id_questionnaire;
        }

        public void setIdCreator(int idCreator)
        {
            this.idCreator = idCreator;
        }

        public bool updateQuestion(DBConnection db)
        {
            try
            {
                if (db.IsConnect())
                {
                    using (var updateRequest = new MySqlCommand("UPDATE questions SET question = @question, type = @type, reponse = @reponse, choix = @choix WHERE id_question = @id_question", db.Connection)) {
                        updateRequest.Parameters.AddWithValue("@question", Text);
                    updateRequest.Parameters.AddWithValue("@type", Type);
                    updateRequest.Parameters.AddWithValue("@reponse", string.Join(",", Answers));
                    updateRequest.Parameters.AddWithValue("@choix", string.Join(",", Choices));
                    updateRequest.Parameters.AddWithValue("@id_question", id);

                    updateRequest.ExecuteNonQuery();
                }
                    MessageBox.Show("Question mise à jour avec succès");
                    db.Close();
                    return true;
                }
                else
                {
                    Console.WriteLine("Erreur de connexion à la base de données.");
                    db.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la mise à jour de la question: {ex.Message}");
                return false;
            }
        }

        public bool insertQuestion(DBConnection db)
        {
            try
            {
                if (db.IsConnect())
                {
                    using (var insertRequest = new MySqlCommand("INSERT INTO questions (id_questionnaire, id_creator, question, type, reponses, choix) VALUES (@id_questionnaire, @id_creator, @question, @type, @reponses, @choix)", db.Connection))
                    {
                        insertRequest.Parameters.AddWithValue("@id_questionnaire", id_questionnaire);
                        insertRequest.Parameters.AddWithValue("@id_creator", idCreator);
                        insertRequest.Parameters.AddWithValue("@question", Text);
                        insertRequest.Parameters.AddWithValue("@type", Type);
                        insertRequest.Parameters.AddWithValue("@reponses", string.Join(",", Answers));
                        insertRequest.Parameters.AddWithValue("@choix", string.Join(",", Choices));
                        insertRequest.ExecuteNonQuery();
                    }
                    MessageBox.Show("Question ajoutée avec succès");
                    db.Close();
                    return true;
                }
                else
                {
                    Console.WriteLine("Erreur de connexion à la base de données.");
                    db.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'ajout de la question: {ex.Message}");
                return false;
            }
        }


        public bool deleteSelf(DBConnection db)
        {
            try
            {
                if (db.IsConnect())
                {
                    using (var deleteRequest = new MySqlCommand("DELETE FROM questions WHERE id_question = @id_question", db.Connection))
                    {
                        deleteRequest.Parameters.AddWithValue("@id_question", id);
                        deleteRequest.ExecuteNonQuery();
                    }
                    MessageBox.Show("Question supprimée avec succès");
                    db.Close();
                    return true;
                }
                else
                {
                    Console.WriteLine("Erreur de connexion à la base de données.");
                    db.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la suppression de la question: {ex.Message}");
                return false;
            }
        }
    }
}
