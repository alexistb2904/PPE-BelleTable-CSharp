using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireForm
{
    public class Questionnaire
    {
        private int id { get; set; }
        private string Title { get; set; }
        private string Theme { get; set; }
        private List<Question> Questions { get; set; }

        private int nbQuestions { get; set; }

        public Questionnaire()
        {
            Title = "";
            Theme = "";
            Questions = new List<Question>();
            nbQuestions = 0;
        }

        public Questionnaire(int id, string title, string theme, List<Question> questions)
        {
            this.id = id;
            Title = title;
            Theme = theme;
            Questions = questions;
            nbQuestions = 0;
        }

        public Questionnaire(int id, string title, string theme, List<Question> questions, int nbQuestionsInit)
        {
            this.id = id;
            Title = title;
            Theme = theme;
            Questions = questions;
            nbQuestions = nbQuestionsInit;
        }

        public int nombreDeQuestions()
        {
            if (Questions?.Count > 0)
            {
                nbQuestions = Questions.Count;
                return nbQuestions;
            }
            else { 
            return nbQuestions; }
        }
        public Question getQuestionByQuestionnaireIndex(int index)
        {
            return Questions[index];
        }

        public Question getQuestion(int id)
        {
            foreach (Question question in Questions)
            {
                if (question.GetId() == id)
                {
                    return question;
                }
            }
            return null;
        }

        public List<Question> getQuestions()
        {
            return Questions;
        }

        public void addQuestion(Question question)
        {
            Questions.Add(question);
        }

        public void removeQuestion(Question question)
        {
            Questions.Remove(question);
        }

        public string getTheme()
        {
            return Theme;
        }

        public string getTitle()
        {
            return Title;
        }

        public int getId()
        {
            return id;
        }
    }
}
