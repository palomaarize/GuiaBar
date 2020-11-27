using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GuiaBar.API.Models.Request
{
    /// <summary>
    /// CreateEvaluation-Request-
    /// </summary>
    [DataContract]
    
    public class CreateEvaluationRequest
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

    /// <summary>
    /// UserRating
    /// </summary>
    [JsonPropertyName("evaluation")]
    public decimal Evaluation { get; set; }
    }
}