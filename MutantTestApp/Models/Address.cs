using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MutantTestApp.Models
{
    public class Address
    {
        public Address()
        {
        }

        public int Id { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("suite")]
        public string Suite { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }
        
        public int GeoId { get; set; }
        [JsonProperty("geo")]
        public Geo Geo { get; set; }

        //public ICollection<User> Users { get; set; }
    }
}
