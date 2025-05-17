using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApi.Models;

public class SendVerificationCodeRequest
{
    [Required]
    public string Email { get; set; } = null!;
}