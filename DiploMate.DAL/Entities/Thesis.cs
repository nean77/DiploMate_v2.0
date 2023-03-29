namespace DiploMate.DAL;

public record Thesis
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? ApproximateEndDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? ApproximatePagesCount { get; set; }
    public string? Hyperlink { get; set; }
    public DateTime CreateDateTime { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime ModifiedDateTime { get; set; }
    public Guid ModifiedBy { get; set; }
    
    public Guid StudentId { get; set; }
    public Guid TutorId { get; set; }
    public virtual Student Student { get; set; }
    public virtual Tutor Tutor { get; set; }
    public virtual List<ThesisState> States { get; set; }
}