using System.Text.Json.Serialization;

namespace GuiaBar.API.Models.Request
{
    /// <summary>
    /// GetRoute-Request-
    /// </summary>
    public class GetRouteRequest
    {

        /// <summary>
        /// UserId
        /// </summary>
        [JsonPropertyName("userId")]
        public long UserId { get; set; }
        
        /// <summary>
        /// PubName
        /// </summary>
        [JsonPropertyName("pubName")]
        public string PubName { get; set; }

    }
}