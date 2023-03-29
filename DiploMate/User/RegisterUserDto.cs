using DiploMate.Objects;

namespace DiploMate.User;

public record RegisterUserDto
{
    public Name FirstName { get; set; } = string.Empty;
    public Name LastName { get; set; } = string.Empty;
    public Email Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
    
    public int RoleId { get; set; } = 1;
}