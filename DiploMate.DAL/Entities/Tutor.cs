namespace DiploMate.DAL;

public record Tutor
{
    internal Guid Id { get; set; } = Guid.NewGuid();
    internal string? Degree { get; set; }

    internal Guid UserId { get; set; }
    internal virtual User User { get; set; }
}