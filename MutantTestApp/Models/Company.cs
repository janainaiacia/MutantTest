using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MutantTestApp.Models
{
    public class Company
    {
        public Company()
        {
        }

        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("catchPhrase")]
        public string CatchPhrase { get; set; }

        [JsonProperty("bs")]
        public string Bs { get; set; }

        //public ICollection<User> Users { get; set; }
    }
}
