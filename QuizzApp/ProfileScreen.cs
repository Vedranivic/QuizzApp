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
    public partial class ProfileScreen : Screen
    {
        public ProfileScreen()
        {
            InitializeComponent();
        }

        public async override void Screen_Load(object sender, EventArgs e)
        {
            label9.Text = "Profile";
            Profile currentProfile = Home.currentProfile;

            //displaying Basic Stats - games played, average score & rank
            FirebaseResponse response = await Home.client.GetTaskAsync("Profiles");
            Dictionary<string, Profile> model = JsonConvert.DeserializeObject<Dictionary<string, Profile>>(response.Body);
            ScriptSource scriptSourceObj = Home.pyEngine.CreateScriptSourceFromFile("C:\\Users\\vedra\\Source\\Repos\\QuizzApp\\QuizzApp\\Scripts\\ProfileStats.py");
            scriptSourceObj.Execute(Home.pyScope);
            dynamic displayBasicStats = Home.pyScope.GetVariable("displayBasicStats");
            displayBasicStats(this.ParentForm, currentProfile, model);
        }

    }
}
