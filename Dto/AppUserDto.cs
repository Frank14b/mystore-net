using System.ComponentModel.DataAnnotations;

namespace Store.Dto;

public class RegisterDto
{
    [Required]
    [MinLength(3)]
    public required string UserName { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [MinLength(AppConstants.PasswordMinLength)]
    [RegularExpression(AppConstants.PasswordRegularExp)]
    public required string Password { get; set; }
}