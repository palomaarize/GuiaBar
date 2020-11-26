using System.Text.Json.Serialization;

namespace GuiaBar.API.Models.Request
{
    public class GetRouteRequest
    {
        [JsonPropertyName("userAddress")]
        public string UserAddress { get; set; }
        

        [JsonPropertyName("pubAddress")]
        public string PubAddress { get; set; }
    }
}