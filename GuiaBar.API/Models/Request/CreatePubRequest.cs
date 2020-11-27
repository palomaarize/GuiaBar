using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GuiaBar.API.Models.Request
{
    /// <summary>
    /// CreatePub-Request-
    /// </summary>
    [DataContract]
    public class CreatePubRequest
    {
    
    /// <summary>
    /// PubId
    /// </summary>
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// PubName
    /// </summary>
    [JsonPropertyName("name")]       
    public string Name { get; set; }

    /// <summary>
    /// PubDescription
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// PubAddress
    /// </summary>
    [JsonPropertyName("address")]
    public string Address { get; set; }

    /// <summary>
    /// PubContact
    /// </summary>    
    [JsonPropertyName("contact")]
    public string Contact { get; set; }

    /// <summary>
    /// AverageBarRatings
    /// </summary>
    [JsonPropertyName("evaluation")]
    public decimal Evaluation { get; set; }
    }
    
}