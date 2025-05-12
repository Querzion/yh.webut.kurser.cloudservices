using System.ComponentModel.DataAnnotations;

namespace ServerApi.Models;

public class ProductRequest
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    [Required]
    public string Name { get; set; } = null!;
    
    [Required]
    public decimal Price { get; set; }
}