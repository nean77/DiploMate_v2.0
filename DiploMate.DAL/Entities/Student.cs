namespace DiploMate.DAL;

public record Student
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UserName { get; set; }// gdx...
    public string StudentIdxNo { get; set; } // index 
    
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}