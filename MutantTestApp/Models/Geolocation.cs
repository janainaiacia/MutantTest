using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MutantTestApp.Models
{
    public class Geolocation
    {
        public Geolocation()
        {
        }

        public int Id { get; set; }

        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("lng")]
        public string Lng { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
