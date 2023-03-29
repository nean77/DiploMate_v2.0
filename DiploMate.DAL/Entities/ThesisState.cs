namespace DiploMate.DAL;

public record ThesisState
{
    internal Guid Id { get; set; } = Guid.NewGuid();
    internal byte? SprintNo { get; set; }
    internal DateTime MeetingDate { get; set; }
    internal byte? ThesisProgress { get; set; }
    internal bool? ProjectAccepted { get; set; }
    internal bool? ProjectFinished { get; set; }
    internal int? PagesCount { get; set; }
    internal bool? ThesisFinished { get; set; }
    internal DateTime CreateDateTime { get; set; }
    internal Guid CreatedBy { get; set; }
    internal DateTime ModifiedDateTime { get; set; }
    internal Guid ModifiedBy { get; set; }
    
    internal Guid ThesisId { get; set; }
    internal virtual Thesis Thesis { get; set; }
}
