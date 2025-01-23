using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireForm
{
    public class QuestionType
    {
        public int id { get; set; }
        public string name { get; set; }

        public QuestionType(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
