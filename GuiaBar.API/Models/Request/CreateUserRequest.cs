using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GuiaBar.API.Models.Request
{
    /// <summary>
    /// CreateUser-Request-
    /// </summary>
[DataContract]
public class CreateUserRequest
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
    
    /// <summary>
    /// UserEmail
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    /// <summary>
    /// UserAddress
    /// </summary>
    [JsonPropertyName("address")]
    public string Address { get; set; }
    }
}