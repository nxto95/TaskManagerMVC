namespace BLL.Dtos;

public class UserResponseDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;
}


