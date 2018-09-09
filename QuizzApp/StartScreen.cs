using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Scripting.Hosting;
using FireSharp.Response;
using Newtonsoft.Json;

namespace QuizzApp
{
    public partial class StartScreen : Screen
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        public async override void Screen_Load(object sender, EventArgs e)
        {
            label9.Text = "Welcome";
            FirebaseResponse response = await Home.client.GetTaskAsync("Questions");
            Dictionary<string, Question> model = JsonConvert.DeserializeObject<Dictionary<string, Question>>(response.Body);
            ScriptSource scriptSourceObj = Home.pyEngine.CreateScriptSourceFromFile("C:\\Users\\vedra\\Source\\Repos\\QuizzApp\\QuizzApp\\Scripts\\QuestionStats.py");
            scriptSourceObj.Execute(Home.pyScope);
            dynamic displayQuestionStats = Home.pyScope.GetVariable("displayQuestionStats");
            displayQuestionStats(this.ParentForm,model);
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
