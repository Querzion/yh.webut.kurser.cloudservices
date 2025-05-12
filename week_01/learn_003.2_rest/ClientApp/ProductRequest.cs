using System.ComponentModel.DataAnnotations;

namespace ClientApp;

public class ProductRequest
{
    [Required]
    public string Name { get; set; } = null!;
    
    [Required]
    public decimal Price { get; set; }
}