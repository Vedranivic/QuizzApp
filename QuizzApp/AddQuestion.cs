using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Firebase.Auth;

namespace QuizzApp
{
    public partial class AddQuestion : Form
    {
        IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
        {
            AuthSecret = "sF6f915ERoGUk1uJFehGeAGVZL3jlMJUoT8HqZLl",
            BasePath = "https://quizapp-ferit.firebaseio.com/"
        };
        IFirebaseClient client;
        public AddQuestion()
        {
            InitializeComponent();
        }

        private async void btAddQ_click(object sender, EventArgs e)
        {
            if (cbCategory.Text == "" || tbQuestion.Text == ""
               || tbA.Text == "" || tbB.Text == "" || tbC.Text == "" || tbD.Text == "")
            {
                MessageBox.Show("Please enter value for all fields", "Incomplete question");
            }            
            else
            {
                if (rbA.Checked || rbB.Checked || rbC.Checked || rbD.Checked)
                {
                    client = new FireSharp.FirebaseClient(config);
                    Question q = new Question();
                    q.id = client.Push("Questions", q).Result.Name;
                    q.category = cbCategory.Text;
                    q.text = tbQuestion.Text;
                    q.a.text = tbA.Text; q.a.correct = rbA.Checked;
                    q.b.text = tbB.Text; q.b.correct = rbB.Checked;
                    q.c.text = tbC.Text; q.c.correct = rbC.Checked;
                    q.d.text = tbD.Text; q.d.correct = rbD.Checked;
                    q.appeared = 0; q.correctly = 0; q.incorrectly = 0;
                    SetResponse response = await client.SetTaskAsync("Questions/" + q.id, q);
                    if (response.ResultAs<Question>() != null)
                    {
                        cbCategory.Text = ""; tbQuestion.Text = "";
                        tbA.Text = ""; tbB.Text = ""; tbC.Text = ""; tbD.Text = "";
                        rbA.Checked = false; rbB.Checked = false; rbC.Checked = false; rbD.Checked = false;
                        MessageBox.Show("Question added successfully");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add question");
                    }
                }
                else MessageBox.Show("Choose the correct answer", "Incomplete question");
            }
        }
    }
}
