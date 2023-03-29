namespace DiploMate.DAL;

public record User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string NormalizedEmail { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string PasswordSalt { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; } = string.Empty;
    public string? PasswordResetToken { get; set; } = string.Empty;
    public DateTime? ResetTokenExpires { get; set; } = DateTime.MinValue;
    
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }
}