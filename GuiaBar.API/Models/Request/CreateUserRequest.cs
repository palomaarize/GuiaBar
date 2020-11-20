using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GuiaBar.API.Models.Request
{
    [DataContract]
    public class CreateUserRequest
    {
        [JsonPropertyName("username")]
        public string UserName;


        [JsonPropertyName("password")]
        public string Password;
        

        [JsonPropertyName("email")]
        public string Email;
    }
}