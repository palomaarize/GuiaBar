using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GuiaBar.API.Models.Request
{
    [DataContract]
    public class LoginRequest
    {
        /// <summary>
        /// UserName
        /// </summary>
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        /// <summary>
        /// UserPassword
        /// </summary>
        [JsonPropertyName("password")]
        public string Password { get; set; }

    }
}