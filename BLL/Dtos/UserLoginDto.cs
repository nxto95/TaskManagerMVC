using System.ComponentModel.DataAnnotations;

namespace BLL.Dtos;

public class UserLoginDto
{
    [Required(ErrorMessage = "Email required")]
    [EmailAddress(ErrorMessage = "Invalid email")]
    public string Email { get; set; } = string.Empty;


    [Required(ErrorMessage = "Password required")]
    [Length(minimumLength: 8, maximumLength: 255, ErrorMessage = "Password at least 8 chars")]
    public string Password { get; set; } = string.Empty;
}
