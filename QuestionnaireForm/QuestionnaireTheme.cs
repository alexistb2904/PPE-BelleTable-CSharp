using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireForm
{
    internal class QuestionnaireTheme
    {
        public string name;
        public int id;

        public QuestionnaireTheme(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
    }
}
