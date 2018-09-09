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
using Newtonsoft.Json;
using IronPython.Hosting;
using IronPython.Runtime; 
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using System.Diagnostics;

namespace QuizzApp
{
    public partial class Home : Form
    {
        public static ScriptEngine pyEngine = Python.CreateEngine();
        public static ScriptScope pyScope = pyEngine.CreateScope();

        //Firebase database config
        IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
        {
            AuthSecret = "sF6f915ERoGUk1uJFehGeAGVZL3jlMJUoT8HqZLl",
            BasePath = "https://quizapp-ferit.firebaseio.com/"
        };
        public static IFirebaseClient client;

        //Current Profile
        public static Profile currentProfile;
        //Current Settings (and default value)
        public static Setting currentSettings = new Setting(5, "Classic", "All");


        public Home()
        {
            InitializeComponent();
        }

        private void HomeOnStart(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            switchToSignin();
            
            //not signed in:
            if (currentProfile == null)
            {
                btPlay.Enabled = false;
                btSettings.Enabled = false;
                btProfile.Enabled = false;
                btHome.Enabled = false;
            }
        }

        //Tab changes:
        private void switchToSignin()
        {
            homescreen.Controls.Clear();
            homescreen.Controls.Add(new SigninScreen());
        }
        private void switchToSettings()
        {
            homescreen.Controls.Clear();
            homescreen.Controls.Add(new SettingScreen());
        }

        private void switchToProfile()
        {
            homescreen.Controls.Clear();
            homescreen.Controls.Add(new ProfileScreen());
            homescreen.Controls[0].Controls["btSignout"].Click += new System.EventHandler(this.SignOut);
        }

        private void switchToHome()
        {
            homescreen.Controls.Clear();
            homescreen.Controls.Add(new StartScreen());
        }

        private void AddQuestion(object sender, EventArgs e)
        {
            AddQuestion addQuestion = new AddQuestion();
            addQuestion.ShowDialog();
        }

        private void StartQuiz(object sender, EventArgs e)
        {
            if (currentProfile != null)
            {
                Play quiz = new Play();
                quiz.ShowDialog();
                switchToHome();
            }
            else
            {
                MessageBox.Show("Please sign in first", "Not signed in");
            }
        }

        private void ShowProfile(object sender, EventArgs e)
        {
            if (currentProfile != null)
            {
                switchToProfile();                              
            }
            else
            {
                MessageBox.Show("Please sign in first", "Not signed in");
            }
        }

        private void EditSettings(object sender, EventArgs e)
        {
            if (currentProfile != null)
            {
                switchToSettings();             
            }
            else
            {
                MessageBox.Show("Please sign in first", "Not signed in");
            }
        }

        private void SignOut(object sender, EventArgs e)
        {
            currentProfile = null;
            btPlay.Enabled = false;
            btSettings.Enabled = false;
            btProfile.Enabled = false;
            btHome.Enabled = false;
            switchToSignin();           
        }

        private void goHome(object sender, EventArgs e)
        {
            switchToHome();
        }

    }
}
