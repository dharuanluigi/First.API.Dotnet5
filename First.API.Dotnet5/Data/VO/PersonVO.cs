using System.Text.Json.Serialization;

namespace First.API.Dotnet5.Data.VO
{
    public class PersonVO
    {
        [JsonPropertyName("code")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string FirstName { get; set; }

        [JsonPropertyName("Last_Name")]
        public string LastName { get; set; }

        [JsonIgnore]
        public string Address { get; set; }

        [JsonPropertyName("Gen")]
        public string Gender { get; set; }
    }
}