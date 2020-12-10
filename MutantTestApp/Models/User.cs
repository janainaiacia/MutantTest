using System;
using Newtonsoft.Json;

namespace MutantTestApp.Models
{
    public class User
    {
        public User()
        {
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string  Username { get; set; }

        public int AddressId { get; set; }
        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        public int CompanyId { get; set; }
        [JsonProperty("company")]
        public Company Company { get; set; }
    }
}
