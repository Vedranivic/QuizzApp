using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace QuizzApp
{
    public class Game : Setting
    {
        [JsonProperty("Questions")]
        public List<Question> Questions;
        [JsonProperty("Result")]
        public Result Result;

        public Game() {
            this.MaxQuestions = Home.currentSettings.MaxQuestions;
            this.GameType = Home.currentSettings.GameType;
            this.Category = Home.currentSettings.Category;
            this.Questions = null;
            this.Result = new Result(0,this.MaxQuestions);
        }

        public void setQuestions(Dictionary<string, Question> model)
        {
            List<Question> allQuestions = new List<Question>();

            foreach (KeyValuePair<string, Question> data in model)
            {
                if (this.Category.Equals("All"))
                {
                    allQuestions.Add(data.Value);
                }
                else
                {
                    if (data.Value.category.Equals(this.Category))
                    {
                        allQuestions.Add(data.Value);
                    }
                }
            }

            this.Questions = new List<Question>();
            for (int i = 0; i < this.MaxQuestions; i++)
            {
                Random rand = new Random();
                int j = rand.Next(0, allQuestions.Count);
                this.Questions.Add(allQuestions[j]);
                allQuestions.RemoveAt(j);
            }
        }

        public async void updateQuestionStats()
        {
            foreach (Question q in this.Questions)
            {
                SetResponse response = await Home.client.SetTaskAsync("Questions/" + q.id, q);
            }
        }

    }
}
