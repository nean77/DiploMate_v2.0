namespace DiploMate.DAL;

public record Tutor
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Degree { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}