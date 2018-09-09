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
    public partial class SigninScreen : Screen
    {
        public SigninScreen()
        {
            InitializeComponent();
        }

        public override void Screen_Load(object sender, EventArgs e)
        {
            label9.Text = "Sign in";

            //Email & password placeholders
            tbEmail.ForeColor = Color.Gray;
            tbEmail.Text = "Email";
            tbPassword.ForeColor = Color.Gray;
            tbPassword.Text = "Password";
        }

        private async void SignIn(object sender, EventArgs e)
        {
            String email = tbEmail.Text;
            String password = tbPassword.Text;
            if (validateFields())
            {
                FirebaseResponse response = await Home.client.GetTaskAsync("Profiles/" + email.Replace('.', '_'));
                Profile profile = JsonConvert.DeserializeObject<Profile>(response.Body);
                try
                {
                    if (profile.Email.Equals(email) && profile.Password.Equals(password))
                    {
                        try
                        {
                            FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig("AIzaSyB54CvXfMb6UntjkjuIqbWAuwezBEHbTQc"));
                            var signIn = authProvider.SignInWithEmailAndPasswordAsync(email, password);
                            FirebaseAuthLink result = await Task.Run(
                                () => signIn.Result);
                            Home.currentProfile = profile;
                            if (profile.getNumberOfGames() != 0)
                            {
                                Home.currentSettings = new Setting(profile.Games.Last<Game>().MaxQuestions, profile.Games.Last<Game>().GameType, profile.Games.Last<Game>().Category);
                            }
                            else Home.currentSettings = new Setting(5, "Classic", "All");
                            removeSignin();

                            MessageBox.Show("Welcome " + Home.currentProfile.DisplayName, "Sign-in successful");
                        }
                        catch (FirebaseAuthException error)
                        {
                            MessageBox.Show(error.Message);
                        }
                    }
                    else MessageBox.Show("You entered a wrong password for this account", "Unable to sign in");
                }
                catch (NullReferenceException nre)
                {
                    MessageBox.Show("The user is not registered", "Unable to sign in");
                }
            }
        }

        private void removeSignin()
        {
            this.Parent.Parent.Controls["panel1"].Controls["btPlay"].Enabled = true;
            this.Parent.Parent.Controls["panel1"].Controls["btSettings"].Enabled = true;
            this.Parent.Parent.Controls["panel1"].Controls["btProfile"].Enabled = true;
            this.Parent.Parent.Controls["panel1"].Controls["btHome"].Enabled = true;
            this.Parent.Controls.Add(new StartScreen());
            this.Parent.Controls.Remove(this);
        }

        private void RegisterUser(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }

        private Boolean validateFields()
        {
            bool inputOK = true;
            if (tbEmail.Text == "" || tbPassword.Text == "" || tbEmail.ForeColor == Color.Gray || tbPassword.ForeColor == Color.Gray)
            {
                MessageBox.Show("Please enter value for all fields", "Invalid input");
                inputOK = false;
            }
            else
            {
                if (!IsValidEmail(tbEmail.Text))
                {
                    inputOK = false;
                    MessageBox.Show("Entered value for email address is not an email address", "Invalid input");
                }
                if (tbPassword.Text.Length < 8)
                {
                    inputOK = false;
                    MessageBox.Show("Password should be at least 8 characters long", "Invalid input");
                }
            }
            return inputOK;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void tbEmail_MouseClick(object sender, MouseEventArgs e)
        {
            tbEmail.ForeColor = Color.Black;
            tbEmail.Clear();
        }

        private void tbPassword_MouseClick(object sender, MouseEventArgs e)
        {
            tbPassword.ForeColor = Color.Black;
            tbPassword.Clear();
        }
    }
}
