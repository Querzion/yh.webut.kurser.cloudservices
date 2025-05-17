using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApi.Models;

public class VerifyVerificationCodeRequest
{
    [Required]
    public string Email { get; set; } = null!;
    
    [Required]
    public string Code { get; set; } = null!;
}