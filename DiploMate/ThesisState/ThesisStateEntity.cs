using DiploMate.Student;
using DiploMate.Thesis;
using DiploMate.Tutor;

namespace DiploMate.ThesisState;

public class ThesisStateEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public byte? SprintNo { get; set; }
    public DateTime MeetingDate { get; set; }
    public byte? ThesisProgress { get; set; }
    public bool? ProjectAccepted { get; set; }
    public bool? ProjectFinished { get; set; }
    public int? PagesCount { get; set; }
    public bool? ThesisFinished { get; set; }
    public DateTime CreateDateTime { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime ModifiedDateTime { get; set; }
    public Guid ModifiedBy { get; set; }
    
    public Guid ThesisEntityId { get; set; }
    public virtual ThesisEntity ThesisEntity { get; set; }
}
