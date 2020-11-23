using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GuiaBar.API.Models.Request
{
    [DataContract]
    public class CreatePubRequest
    {

    [JsonPropertyName("name")]       
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }
    
    [JsonPropertyName("contact")]
    public string Contact { get; set; }

    [JsonPropertyName("evaluation")]
    public decimal Evaluation { get; set; }
    }
    
}