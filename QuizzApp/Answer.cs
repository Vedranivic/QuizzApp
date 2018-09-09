using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp
{
    public class Answer
    {
        public String text;
        public Boolean correct;

        public Answer() { }

        public Answer(string text, bool correct)
        {
            this.text = text;
            this.correct = correct;
        }
    }
}
