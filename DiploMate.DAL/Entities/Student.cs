namespace DiploMate.DAL;

public record Student
{
    internal Guid Id { get; set; } = Guid.NewGuid();
    internal string UserName { get; set; } = string.Empty; // gdx...
    internal string StudentIdxNo { get; set; } = string.Empty; // index 
    
    internal Guid UserId { get; set; }
    internal virtual User User { get; set; }
}