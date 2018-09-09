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
    public partial class Play : Form
    {
        private int questionNumber = 0;
        private Question currentQuestion;
        private bool questionAnswered;

        private Game game = new Game();
 
        public Play()
        {
            InitializeComponent();
        }

        private async void Play_load(object sender, EventArgs e)
        {
            FirebaseResponse response = await Home.client.GetTaskAsync("Questions");
            Dictionary<string, Question> model = JsonConvert.DeserializeObject<Dictionary<string, Question>>(response.Body);
            game.setQuestions(model);

            displayQuestion();
            questionAnswered = false; 

            lbMax.Text = game.Questions.Count.ToString();
            progressBar1.Maximum = game.Questions.Count;
        }

        private void displayQuestion()
        {
            currentQuestion = game.Questions[questionNumber];
            richTextBox1.Text = currentQuestion.text;
            lbA.Text = currentQuestion.a.text;
            lbB.Text = currentQuestion.b.text;
            lbC.Text = currentQuestion.c.text;
            lbD.Text = currentQuestion.d.text;
            questionNumber++;
            qNumber.Text = questionNumber.ToString() + ".";
            lbScore.Text = game.Result.Correct.ToString();
            currentQuestion.appeared++;
        }


        private void nextQuestion_click(object sender, EventArgs e)
        {
            if (!questionAnswered)
            {
                MessageBox.Show("Respond to the current question", "Wait!");
            }
            else
            {
                resetLabelColor();
                game.Questions[questionNumber - 1] = currentQuestion; //update previous question's statistics

                //load next question
                questionAnswered = false;
                if (questionNumber < game.MaxQuestions) //Game not finished
                {
                    displayQuestion();
                }
                else    //Game finished
                {
                    game.updateQuestionStats();
                    Home.currentProfile.finishGame(game);    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void lbA_Click(object sender, EventArgs e)
        {
            if (!questionAnswered)
            {
                if (currentQuestion.a.correct)
                {
                    game.Result.Correct++;
                    currentQuestion.correctly++;
                    progressBar1.Increment(1);
                    lbScore.Text = game.Result.Correct.ToString();
                    lbA.BackColor = Color.LightGreen;
                }
                else
                {
                    lbA.BackColor = Color.FromArgb(255, 173, 0);
                    currentQuestion.incorrectly++;
                }
                questionAnswered = true;
                showResults();
            }
        }

        private void lbB_Click(object sender, EventArgs e)
        {
            if (!questionAnswered)
            {
                if (currentQuestion.b.correct)
                {
                    game.Result.Correct++;
                    currentQuestion.correctly++;
                    progressBar1.Increment(1);
                    lbScore.Text = game.Result.Correct.ToString();
                    lbB.BackColor = Color.LightGreen;
                }
                else
                {
                    lbB.BackColor = Color.FromArgb(255, 173, 0);
                    currentQuestion.incorrectly++;
                }
                questionAnswered = true;
                showResults();
            }
        }

        private void lbC_Click(object sender, EventArgs e)
        {
            if (!questionAnswered)
            {
                if (currentQuestion.c.correct)
                {
                    game.Result.Correct++;
                    currentQuestion.correctly++;
                    progressBar1.Increment(1);
                    lbScore.Text = game.Result.Correct.ToString();
                    lbC.BackColor = Color.LightGreen;
                }
                else
                {
                    lbC.BackColor = Color.FromArgb(255, 173, 0);
                    currentQuestion.incorrectly++;
                }
                questionAnswered = true;
                showResults();
            }
        }

        private void lbD_Click(object sender, EventArgs e)
        {
            if (!questionAnswered)
            {
                if (currentQuestion.d.correct)
                {
                    game.Result.Correct++;
                    currentQuestion.correctly++;
                    progressBar1.Increment(1);
                    lbScore.Text = game.Result.Correct.ToString();
                    lbD.BackColor = Color.LightGreen;
                }
                else
                {
                    lbD.BackColor = Color.FromArgb(255, 173, 0);
                    currentQuestion.incorrectly++;
                }
                questionAnswered = true;
                showResults();
            }
        }

        private void showResults()
        {
            if (questionNumber.ToString() == lbMax.Text)
            {
                btNext.Text = "Finish";
                btQuit.Enabled = false;
                pResult.Show();
                progressBar1.Hide();
                lbScore.Hide();
                lbMax.Hide();
                lbCorrect.Text = game.Result.Correct.ToString();
                lbTotal.Text = questionNumber.ToString();
                lbResultScore.Visible = true;
                lbResultScore.Text = String.Format("{0:0.00}", game.Result.getScore()) + " %";
            }
        }

        private void resetLabelColor()
        {
            lbA.BackColor = Color.White;
            lbB.BackColor = Color.White;
            lbC.BackColor = Color.White;
            lbD.BackColor = Color.White;
        }

        private void quitQuiz_click(object sender, EventArgs e)
        {
            game.updateQuestionStats();
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
