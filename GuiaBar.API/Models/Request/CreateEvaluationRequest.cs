using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GuiaBar.API.Models.Request
{
    [DataContract]
    public class CreateEvaluationRequest
    {
    
    [JsonPropertyName("userId")]
    public long UserId { get; set; }

    [JsonPropertyName("pubId")]       
    public long PubId { get; set; }

    [JsonPropertyName("evaluation")]
    public decimal Evaluation { get; set; }
    }
}