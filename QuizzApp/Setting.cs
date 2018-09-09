using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp
{
    public class Setting
    {
        public int MaxQuestions;
        public String GameType;
        public String Category;

        public Setting() { }

        public Setting(int maxQuestions, string gameType, string category)
        {
            MaxQuestions = maxQuestions;
            GameType = gameType;
            Category = category;
        }
    }
}
