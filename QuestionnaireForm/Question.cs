using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuestionnaireForm
{
    internal class Question
    {
        private string Text { get; set; }
        private string Answer { get; set; }

        private int Type { get; set; }
        private string[] Choices { get; set; }

        public Question(string text, int type, string answer, string[] choices)
        {
            Text = text;
            Type = type;
            Answer = answer;
            Choices = choices;
        }

        public bool CheckAnswer(string answer)
        {
            return answer == Answer;
        }

        public string GetAnswer()
        {
            return Answer;
        }

        public string GetText()
        {
            return Text;
        }

        public string GetType(DBConnection db)
        {
            if (db.IsConnect())
            {
                Console.WriteLine("Connected to database");
                MySqlCommand connectionRequest = new MySqlCommand(
                    "SELECT nom.type FROM Question INNER JOIN type ON type = id_type",
                    db.Connection
                );

                MySqlDataReader reader = connectionRequest.ExecuteReader();

                while (reader.Read())
                {
                    return reader.GetString(0);
                }
                return "Erreur de lecture de la base de données.";
            } else
            {
                return "Erreur de connexion à la base de données.";
            }
        }

        public string[] GetChoices()
        {
            return Choices;
        }
    }
}
