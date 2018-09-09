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
    public partial class Form1 : Form
    {
        IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
        {
            AuthSecret = "sF6f915ERoGUk1uJFehGeAGVZL3jlMJUoT8HqZLl",
            BasePath = "https://quizapp-ferit.firebaseio.com/"
        };

        IFirebaseClient client;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
               // MessageBox.Show("CONNECTED");
            }

           
        }

        private async void button5_ClickAsync(object sender, EventArgs e)
        {
            FirebaseAuth auth = new FirebaseAuth();
            FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig("AIzaSyB54CvXfMb6UntjkjuIqbWAuwezBEHbTQc"));
            FirebaseAuthLink link = new FirebaseAuthLink(authProvider, auth);
            //authProvider.CreateUserWithEmailAndPasswordAsync("vedranivic7@live.com", "12345678", "Vedran Ivic", false);
            try
            {
                
                FirebaseAuthLink result = await Task.Run(
                    () => authProvider.SignInWithEmailAndPasswordAsync(tbEmail.Text, tbPassword.Text).Result);
                MessageBox.Show("Signed in successfully. Welcome " + result.User.DisplayName);
            }
            catch(FirebaseAuthException error)
            {
                MessageBox.Show(error.Message);
            }
           
        }
    }
}
