using Newtonsoft.Json;

namespace SkriftDemo.Models.Animals {
    
    public class SkriftAnimal {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("lastSeen")]
        public string LastSeen { get; set; }

        [JsonProperty("twitter")]
        public string Twitter { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

    }

}