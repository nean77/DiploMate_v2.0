namespace DiploMate.DAL;

public record User
{
    internal Guid Id { get; set; } = Guid.NewGuid();
    internal string FirstName { get; set; } = string.Empty;
    internal string LastName { get; set; } = string.Empty;
    internal string Email { get; set; } = string.Empty;
    internal string NormalizedEmail { get; set; } = string.Empty;
    internal string PasswordHash { get; set; } = string.Empty;
    internal string PasswordSalt { get; set; } = string.Empty;
    internal string? PhoneNumber { get; set; } = string.Empty;
    internal string? PasswordResetToken { get; set; } = string.Empty;
    internal DateTime? ResetTokenExpires { get; set; } = DateTime.MinValue;
    
    internal int RoleId { get; set; }
    internal virtual Role Role { get; set; }
}