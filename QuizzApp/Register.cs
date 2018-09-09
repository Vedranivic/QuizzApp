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

namespace QuizzApp
{
    public partial class Register : Form
    {
        IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
        {
            AuthSecret = "sF6f915ERoGUk1uJFehGeAGVZL3jlMJUoT8HqZLl",
            BasePath = "https://quizapp-ferit.firebaseio.com/"
        };

        IFirebaseClient client;

        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            //setting placeholders
            tbFirstName.ForeColor = Color.Gray;
            tbFirstName.Text = "First name";
            tbLastName.ForeColor = Color.Gray;
            tbLastName.Text = "Last name";
            tbEmail.ForeColor = Color.Gray;
            tbEmail.Text = "Email";
            tbPassword.ForeColor = Color.Gray;
            tbPassword.Text = "Password";
        }

        private void tbFirstName_MouseClick(object sender, MouseEventArgs e)
        {
            tbFirstName.ForeColor = Color.Black;
            tbFirstName.Clear();
        }

        private void tbLastName_MouseClick(object sender, MouseEventArgs e)
        {
            tbLastName.ForeColor = Color.Black;
            tbLastName.Clear();
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

        private async void btRegister_Click(object sender, EventArgs e)
        {
            if (validateFields())
            {
                try
                {
                    //create new profile
                    FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig("AIzaSyB54CvXfMb6UntjkjuIqbWAuwezBEHbTQc"));
                    var register = authProvider.CreateUserWithEmailAndPasswordAsync(tbEmail.Text, tbPassword.Text, tbFirstName.Text + " " + tbLastName.Text, false);
                    FirebaseAuthLink result = await Task.Run(() => register.Result);
                    User authUser = result.User;
                    Profile newProfile = new Profile(authUser.LocalId, authUser.FederatedId, tbFirstName.Text, tbLastName.Text, authUser.DisplayName, authUser.Email, false, authUser.PhotoUrl, authUser.PhoneNumber, tbPassword.Text);

                    //add profile to database
                    client = new FireSharp.FirebaseClient(config);
                    SetResponse response = await client.SetTaskAsync("Profiles/" + newProfile.Email.Replace('.','_'), newProfile);

                    if (response.ResultAs<User>() != null)
                    {
                        MessageBox.Show("You are free to sign in with your new account", "Successfully registered");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to register new user", "Registration failure");
                    }
                }
                catch(FirebaseAuthException error)
                {
                    MessageBox.Show(error.Message);
                }
                catch
                {
                    MessageBox.Show("The entered email address has already been registered. Use a new one.", "Existing email address!");
                }
            }
        }

        private Boolean validateFields()
        {
            bool inputOK = true;
            if (tbFirstName.Text == "" || tbLastName.Text == "" || tbEmail.Text == "" || tbPassword.Text == ""||
                tbFirstName.ForeColor == Color.Gray || tbLastName.ForeColor == Color.Gray || tbEmail.ForeColor == Color.Gray || tbPassword.ForeColor == Color.Gray)
            {
                MessageBox.Show("Please enter value for all fields","Invalid input");
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

    }
}
