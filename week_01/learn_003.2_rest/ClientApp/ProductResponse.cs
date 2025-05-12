using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClientApp;

public class ProductResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;
    
    [Required]
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;
    
    [Required]
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
}