using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GuiaBar.API.Models.Request
{
    [DataContract]
    public class CreateUserRequest
    {
        
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        
        [JsonPropertyName("password")]
        public string Password { get; set; }
        

        [JsonPropertyName("email")]
        public string Email { get; set; }
        

        [JsonPropertyName("address")]
        public string Address { get; set; }
    }
}