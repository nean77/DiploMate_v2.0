namespace DiploMate.DAL;

public record Thesis
{
    internal Guid Id { get; set; } = Guid.NewGuid();
    internal string Title { get; set; } = string.Empty;
    internal string? Description { get; set; }
    internal DateTime StartDate { get; set; }
    internal DateTime? ApproximateEndDate { get; set; }
    internal DateTime? EndDate { get; set; }
    internal int? ApproximatePagesCount { get; set; }
    internal string? Hyperlink { get; set; }
    internal DateTime CreateDateTime { get; set; }
    internal Guid CreatedBy { get; set; }
    internal DateTime ModifiedDateTime { get; set; }
    internal Guid ModifiedBy { get; set; }
    
    internal Guid StudentId { get; set; }
    internal Guid TutorId { get; set; }
    internal virtual Student Student { get; set; }
    internal virtual Tutor Tutor { get; set; }
    internal virtual List<ThesisState> States { get; set; }
}