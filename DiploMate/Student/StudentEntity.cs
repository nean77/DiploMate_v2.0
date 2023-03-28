using DiploMate.User;

namespace DiploMate.Student;

public record StudentEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UserName { get; set; } = string.Empty; // gdx...
    public string StudentIdxNo { get; set; } = string.Empty; // index 
    
    public Guid UserEntityId { get; set; }
    public virtual UserEntity UserEntity { get; set; }
}