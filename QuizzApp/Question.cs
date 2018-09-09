using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp
{
    public class Question
    {
        [JsonProperty("id")]
        public String id;
        [JsonProperty("category")]
        public String category;
        [JsonProperty("text")]
        public String text;
        [JsonProperty("a")]
        public Answer a = new Answer();
        [JsonProperty("b")]
        public Answer b = new Answer();
        [JsonProperty("c")]
        public Answer c = new Answer();
        [JsonProperty("d")]
        public Answer d = new Answer();
        [JsonProperty("appeared")]
        public int appeared;
        [JsonProperty("correctly")]
        public int correctly;
        [JsonProperty("incorrectly")]
        public int incorrectly;

        public Question() { }

        public Question(string id, string category, string text, Answer a, Answer b, Answer c, Answer d)
        {
            this.id = id;
            this.category = category;
            this.text = text;
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.appeared = 0;
            this.correctly = 0;
            this.incorrectly = 0;
        }
    }
}
