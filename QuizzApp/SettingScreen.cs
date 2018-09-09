using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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
    public partial class SettingScreen : Screen
    {
        public Setting newSettings;

        public SettingScreen()
        {
            InitializeComponent();
        }

        public override void Screen_Load(object sender, EventArgs e)
        {
            label9.Text = "Settings";
            tbMaxQ.Text = Home.currentSettings.MaxQuestions.ToString();
            cbGameType.SelectedIndex = cbGameType.FindStringExact(Home.currentSettings.GameType);
            setCategorySource();       
        }

        private async void setCategorySource()
        {
            FirebaseResponse response = await Home.client.GetTaskAsync("Questions");
            Dictionary<string, Question> model = JsonConvert.DeserializeObject<Dictionary<string, Question>>(response.Body);
            ScriptSource scriptSourceObj = Home.pyEngine.CreateScriptSourceFromFile("C:\\Users\\vedra\\Source\\Repos\\QuizzApp\\QuizzApp\\Scripts\\Settings.py");
            scriptSourceObj.Execute(Home.pyScope);
            dynamic displayCategories = Home.pyScope.GetVariable("displayCategories");
            displayCategories(this.ParentForm, model);
            dynamic Hint = Home.pyScope.GetVariable("Hint");
            Hint(this.ParentForm);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (tbMaxQ.Text != "" && cbGameType.Text != "")
                try
                {
                    this.newSettings = new Setting(int.Parse(tbMaxQ.Text), cbGameType.Text, cbCategory.Text);
                    Home.currentSettings = newSettings;
                    MessageBox.Show("Your settings have been saved", "Saved settings");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

    }
}
