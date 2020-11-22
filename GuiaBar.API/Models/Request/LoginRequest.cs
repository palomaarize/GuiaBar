using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GuiaBar.API.Models.Request
{
    [DataContract]
    public class LoginRequest
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }


        [JsonPropertyName("password")]
        public string Password { get; set; }

    }
}