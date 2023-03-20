
using Newtonsoft.Json;

namespace StudentInformation.Data.Models
{
    public class StudentModel
    {
        [JsonProperty("studentNumber")]
        public int StudentNumber { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set;}
        [JsonProperty("lastName")]
        public string LastName { get; set;}

    }
}
