using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizzApp
{
    public class Result
    {
        public int Correct;
        public int Total;

        public Result() { }

        public Result(int correct, int total)
        {
            this.Correct = correct;
            this.Total = total;
        }

        public float getScore()
        {
            return (float)this.Correct*100 / this.Total;
        }

    }
}
