using DiploMate.User;

namespace DiploMate.Tutor;

public record TutorEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Degree { get; set; }

    public Guid UserEntityId { get; set; }
    public virtual UserEntity UserEntity { get; set; }
}