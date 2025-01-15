using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireForm
{
    public class Questionnaire
    {
        private string id { get; set; }
        private string Title { get; set; }
        private string Theme { get; set; }
        private List<Question> Questions { get; set; }


        public Questionnaire(string id, string title, string theme, List<Question> questions)
        {
            this.id = id;
            Title = title;
            Theme = theme;
            Questions = questions;
        }

        public int nombreDeQuestions()
        {
            return Questions?.Count ?? 0;
        }

        public Question getQuestion(int index)
        {
            return Questions[index];
        }

        public string getTheme()
        {
            return Theme;
        }

        public string getTitle()
        {
            return Title;
        }

        public string getId()
        {
            return id;
        }
    }
}
