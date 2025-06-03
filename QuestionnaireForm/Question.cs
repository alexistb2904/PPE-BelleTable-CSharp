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
    /// <summary>
    /// Représente une question d'un questionnaire, avec gestion des choix, réponses, type et pondération.
    /// La pondération des choix est transmise via la propriété publique Tag (int[]), utilisée lors de l'insertion ou la mise à jour.
    /// </summary>
    public class Question
    {
        // Identifiant du questionnaire auquel appartient la question
        private int id_questionnaire { get; set; }
        // Identifiant unique de la question
        private int id { get; set; }
        // Identifiant du créateur de la question
        private int idCreator { get; set; }
        // Texte de la question
        private string Text { get; set; }
        // Tableau des bonnes réponses
        private string[] Answers { get; set; }
        // Type numérique de la question
        private int Type { get; set; }
        // Type de la question sous forme de texte (nom du type)
        private string StringType { get; set; }
        // Tableau de tous les choix proposés pour la question
        private string[] Choices { get; set; }

        /// <summary>
        /// Propriété publique utilisée pour stocker temporairement la pondération des choix (int[] points).
        /// Chaque élément correspond au nombre de points attribués à un choix.
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// Constructeur par défaut. Initialise les champs à des valeurs neutres.
        /// </summary>
        public Question()
        {
            Text = "";
            Answers = new string[0];
            Type = 0;
            Choices = new string[0];
        }

        /// <summary>
        /// Constructeur principal.
        /// </summary>
        /// <param name="id">Identifiant de la question</param>
        /// <param name="id_questionnaire">Identifiant du questionnaire</param>
        /// <param name="creatorId">Identifiant du créateur</param>
        /// <param name="text">Texte de la question</param>
        /// <param name="type">Type de la question (numérique)</param>
        /// <param name="answers">Tableau des bonnes réponses</param>
        /// <param name="choices">Tableau des choix proposés</param>
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

        /// <summary>
        /// Vérifie si une réponse donnée est correcte.
        /// </summary>
        public bool CheckAnswer(string answer)
        {
            return Answers.Contains(answer);
        }

        /// <summary>
        /// Retourne le tableau des bonnes réponses.
        /// </summary>
        public string[] GetAnswers()
        {
            return Answers;
        }

        /// <summary>
        /// Retourne le texte de la question.
        /// </summary>
        public string GetText()
        {
            return Text;
        }

        /// <summary>
        /// Retourne l'identifiant du créateur.
        /// </summary>
        public int GetIdCreator()
        {
            return idCreator;
        }

        /// <summary>
        /// Retourne l'identifiant de la question.
        /// </summary>
        public int GetId()
        {
            return id;
        }

        /// <summary>
        /// Récupère le nom du type de la question depuis la base de données.
        /// </summary>
        public string GetType(DBConnection db)
        {
            if (db.IsConnect())
            {
                Console.WriteLine("Connected to database");
                MySqlCommand connectionRequest = new MySqlCommand(
                    "SELECT nom FROM types WHERE id_type = @type",
                    db.Connection
                );
                connectionRequest.Parameters.AddWithValue("@type", Type);

                using (var reader = connectionRequest.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        StringType = reader.GetString(0);
                    }
                    reader.Close();
                }
                return StringType;
            }
            else
            {
                return "Erreur de connexion à la base de données.";
            }
        }

        /// <summary>
        /// Retourne le nom du type de la question (déjà chargé).
        /// </summary>
        public string GetStringType()
        {
            return StringType;
        }

        /// <summary>
        /// Retourne le tableau des choix proposés.
        /// </summary>
        public string[] GetChoices()
        {
            return Choices;
        }

        /// <summary>
        /// Définit les bonnes réponses.
        /// </summary>
        public void SetAnswers(string[] answers)
        {
            Answers = answers;
        }

        /// <summary>
        /// Définit le texte de la question.
        /// </summary>
        public void SetText(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Définit le type de la question et met à jour le nom du type.
        /// </summary>
        public void SetType(int type, DBConnection db)
        {
            Type = type;
            GetType(db);
        }

        /// <summary>
        /// Définit les choix proposés.
        /// </summary>
        public void SetChoices(string[] choices)
        {
            Choices = choices;
        }

        /// <summary>
        /// Définit l'identifiant du questionnaire.
        /// </summary>
        public void SetQuestionnaireId(int id_questionnaire)
        {
            this.id_questionnaire = id_questionnaire;
        }

        /// <summary>
        /// Définit l'identifiant du créateur.
        /// </summary>
        public void setIdCreator(int idCreator)
        {
            this.idCreator = idCreator;
        }

        /// <summary>
        /// Met à jour la question et ses choix dans la base de données.
        /// Si des réponses utilisateur existent, les choix sont mis à jour sans suppression.
        /// La pondération de chaque choix est récupérée via Tag (int[]), sinon 1 pour bonne réponse, 0 sinon.
        /// </summary>
        public bool updateQuestion(DBConnection db)
        {
            try
            {
                if (db.IsConnect())
                {
                    // 1. Vérifier si des réponses utilisateur existent pour cette question
                    bool hasUserResponses = false;
                    using (var checkRequest = new MySqlCommand(
                        "SELECT COUNT(*) FROM reponses_utilisateur WHERE id_question = @id_question",
                        db.Connection))
                    {
                        checkRequest.Parameters.AddWithValue("@id_question", id);
                        int count = Convert.ToInt32(checkRequest.ExecuteScalar());
                        hasUserResponses = count > 0;
                    }

                    // 2. Mettre à jour la question
                    using (var updateQuestionRequest = new MySqlCommand(
                        "UPDATE questions SET question = @question, type = @type WHERE id_question = @id_question",
                        db.Connection))
                    {
                        updateQuestionRequest.Parameters.AddWithValue("@question", Text);
                        updateQuestionRequest.Parameters.AddWithValue("@type", Type);
                        updateQuestionRequest.Parameters.AddWithValue("@id_question", id);
                        updateQuestionRequest.ExecuteNonQuery();
                    }

                    // 3. Si des réponses utilisateur existent, traiter différemment
                    if (hasUserResponses)
                    {
                        // Option 1 : Mettre à jour les choix existants sans les supprimer
                        // Récupérer les choix actuels
                        Dictionary<int, string> existingChoices = new Dictionary<int, string>();
                        Dictionary<int, bool> existingAnswers = new Dictionary<int, bool>();

                        using (var getChoicesRequest = new MySqlCommand(
                            "SELECT id, texte, est_reponse FROM choix WHERE id_question = @id_question",
                            db.Connection))
                        {
                            getChoicesRequest.Parameters.AddWithValue("@id_question", id);
                            using (var reader = getChoicesRequest.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int choiceId = reader.GetInt32("id");
                                    string text = reader.GetString("texte");
                                    bool isAnswer = reader.GetBoolean("est_reponse");
                                    existingChoices.Add(choiceId, text);
                                    existingAnswers.Add(choiceId, isAnswer);
                                }
                            }
                        }

                        // Mettre à jour les choix existants et ajouter les nouveaux
                        int i = 0;
                        // Récupération de la pondération depuis Tag (int[])
                        int[] points = Tag as int[];
                        foreach (var choiceId in existingChoices.Keys.ToList())
                        {
                            if (i < Choices.Length)
                            {
                                // Mettre à jour le choix existant
                                bool isAnswer = Answers.Contains(Choices[i]);
                                // Si la pondération n'est pas fournie, 1 pour bonne réponse, 0 sinon
                                int point = (points != null && i < points.Length) ? points[i] : (isAnswer ? 1 : 0);

                                using (var updateChoiceRequest = new MySqlCommand(
                                    "UPDATE choix SET texte = @texte, est_reponse = @est_reponse, points = @points " +
                                    "WHERE id = @id", db.Connection))
                                {
                                    updateChoiceRequest.Parameters.AddWithValue("@texte", Choices[i]);
                                    updateChoiceRequest.Parameters.AddWithValue("@est_reponse", isAnswer);
                                    updateChoiceRequest.Parameters.AddWithValue("@points", point);
                                    updateChoiceRequest.Parameters.AddWithValue("@id", choiceId);
                                    updateChoiceRequest.ExecuteNonQuery();
                                }
                            }
                            i++;
                        }

                        // Ajouter les choix supplémentaires si nécessaire
                        for (; i < Choices.Length; i++)
                        {
                            bool isAnswer = Answers.Contains(Choices[i]);
                            int point = (points != null && i < points.Length) ? points[i] : (isAnswer ? 1 : 0);

                            using (var insertChoiceRequest = new MySqlCommand(
                                "INSERT INTO choix (id_question, texte, est_reponse, points) " +
                                "VALUES (@id_question, @texte, @est_reponse, @points)", db.Connection))
                            {
                                insertChoiceRequest.Parameters.AddWithValue("@id_question", id);
                                insertChoiceRequest.Parameters.AddWithValue("@texte", Choices[i]);
                                insertChoiceRequest.Parameters.AddWithValue("@est_reponse", isAnswer);
                                insertChoiceRequest.Parameters.AddWithValue("@points", point);
                                insertChoiceRequest.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        // Si aucune réponse utilisateur n'existe, on peut supprimer et recréer les choix
                        // 3.1 Supprimer les anciens choix
                        using (var deleteChoicesRequest = new MySqlCommand(
                            "DELETE FROM choix WHERE id_question = @id_question",
                            db.Connection))
                        {
                            deleteChoicesRequest.Parameters.AddWithValue("@id_question", id);
                            deleteChoicesRequest.ExecuteNonQuery();
                        }

                        // 3.2 Insérer les nouveaux choix
                        int[] points = Tag as int[];
                        int i = 0;
                        foreach (string choice in Choices)
                        {
                            bool isAnswer = Answers.Contains(choice);
                            int point = (points != null && i < points.Length) ? points[i] : (isAnswer ? 1 : 0);

                            using (var insertChoiceRequest = new MySqlCommand(
                                "INSERT INTO choix (id_question, texte, est_reponse, points) " +
                                "VALUES (@id_question, @texte, @est_reponse, @points)", db.Connection))
                            {
                                insertChoiceRequest.Parameters.AddWithValue("@id_question", id);
                                insertChoiceRequest.Parameters.AddWithValue("@texte", choice);
                                insertChoiceRequest.Parameters.AddWithValue("@est_reponse", isAnswer);
                                insertChoiceRequest.Parameters.AddWithValue("@points", point);
                                insertChoiceRequest.ExecuteNonQuery();
                            }
                            i++;
                        }
                    }

                    MessageBox.Show("Question mise à jour avec succès");
                    return true;
                }
                else
                {
                    Console.WriteLine("Erreur de connexion à la base de données.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la mise à jour de la question: {ex.Message}");
                MessageBox.Show($"Erreur lors de la mise à jour de la question: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Insère la question et ses choix dans la base de données.
        /// La pondération de chaque choix est récupérée via Tag (int[]), sinon 1 pour bonne réponse, 0 sinon.
        /// </summary>
        public bool insertQuestion(DBConnection db)
        {
            try
            {
                if (db.IsConnect())
                {
                    if (Answers == null || Answers.Length == 0)
                    {
                        throw new Exception("Les réponses ne peuvent pas être nulles ou vides.");
                    }

                    if (Choices == null || Choices.Length == 0)
                    {
                        throw new Exception("Les choix ne peuvent pas être nuls ou vides.");
                    }

                    // 1. Insérer la question
                    int questionId;
                    using (var insertQuestionRequest = new MySqlCommand(
                        "INSERT INTO questions (question, type, id_questionnaire, id_creator) " +
                        "VALUES (@question, @type, @id_questionnaire, @id_creator); " +
                        "SELECT LAST_INSERT_ID();", db.Connection))
                    {
                        insertQuestionRequest.Parameters.AddWithValue("@question", Text);
                        insertQuestionRequest.Parameters.AddWithValue("@type", Type);
                        insertQuestionRequest.Parameters.AddWithValue("@id_questionnaire", id_questionnaire);
                        insertQuestionRequest.Parameters.AddWithValue("@id_creator", idCreator);

                        questionId = Convert.ToInt32(insertQuestionRequest.ExecuteScalar());
                        this.id = questionId;
                    }

                    // 2. Insérer les choix avec leurs valeurs de réponse et pondération
                    int[] points = Tag as int[];
                    int i = 0;
                    foreach (string choice in Choices)
                    {
                        bool isAnswer = Answers.Contains(choice);
                        // Si la pondération n'est pas fournie, 1 pour bonne réponse, 0 sinon
                        int point = (points != null && i < points.Length) ? points[i] : (isAnswer ? 1 : 0);

                        using (var insertChoiceRequest = new MySqlCommand(
                            "INSERT INTO choix (id_question, texte, est_reponse, points) " +
                            "VALUES (@id_question, @texte, @est_reponse, @points)", db.Connection))
                        {
                            insertChoiceRequest.Parameters.AddWithValue("@id_question", questionId);
                            insertChoiceRequest.Parameters.AddWithValue("@texte", choice);
                            insertChoiceRequest.Parameters.AddWithValue("@est_reponse", isAnswer);
                            insertChoiceRequest.Parameters.AddWithValue("@points", point);
                            insertChoiceRequest.ExecuteNonQuery();
                        }
                        i++;
                    }

                    MessageBox.Show("Question ajoutée avec succès");
                    return true;
                }
                else
                {
                    Console.WriteLine("Erreur de connexion à la base de données.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'ajout de la question: {ex.Message}");
                MessageBox.Show($"Erreur lors de l'ajout de la question: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Supprime la question de la base de données.
        /// </summary>
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
