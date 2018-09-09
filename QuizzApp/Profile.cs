using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Newtonsoft.Json;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.Scripting.Hosting;

namespace QuizzApp
{
    public class Profile : User
    {
        [JsonProperty("AverageScore")]
        public float AverageScore;
        [JsonProperty("Password")]
        public string Password;
        [JsonProperty("Games")]
        public List<Game> Games;

        public Profile() { }

        public Profile(string localId, string federatedId, string firstName, string lastName, string displayName, string email, bool isEmailVerified, string photoUrl, string phoneNumber, string password)
        {
            this.LocalId = localId;
            this.FederatedId = federatedId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DisplayName = displayName;
            this.Email = email;
            this.IsEmailVerified = isEmailVerified;
            this.PhotoUrl = photoUrl;
            this.PhoneNumber = phoneNumber;
            this.AverageScore = 0;
            this.Password = password;
            this.Games = new List<Game>();
        }

        public int getNumberOfGames()
        {
            if (this.Games == null)
            {
                return 0;
            }
            else return this.Games.Count;
        }

        public async void finishGame(Game game)
        {
            //if Classic game -> update player stats; if Casual leave the stats unchanged
            if (game.GameType.Equals("Classic"))
            {
                if (this.Games == null)
                {
                    this.Games = new List<Game>();
                }
                ScriptSource scriptSourceObj = Home.pyEngine.CreateScriptSourceFromFile("C:\\Users\\vedra\\Source\\Repos\\QuizzApp\\QuizzApp\\Scripts\\AvgScore.py");
                scriptSourceObj.Execute(Home.pyScope);
                dynamic updatePlayerStats = Home.pyScope.GetVariable("updatePlayerStats");
                updatePlayerStats(this, game);

                SetResponse response = await Home.client.SetTaskAsync("Profiles/" + Home.currentProfile.Email.Replace('.', '_'), this);
            }
        }

    }
}
