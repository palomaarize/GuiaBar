using System.Text.Json.Serialization;

namespace GuiaBar.API.Models.Request
{
    public class GetRouteRequest
    {
        [JsonPropertyName("userId")]
        public long UserId { get; set; }
        

        [JsonPropertyName("pubName")]
        public string PubName { get; set; }
    }
}