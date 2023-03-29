namespace DiploMate.DAL.Entities;

public record Student
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UserName { get; set; } = string.Empty; // gdx...
    public string StudentIdxNo { get; set; } = string.Empty; // index 
    
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}