using DiploMate.Student;
using DiploMate.ThesisState;
using DiploMate.Tutor;

namespace DiploMate.Thesis;

public record ThesisEntity
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
    
    public Guid StudentEntityId { get; set; }
    public Guid TutorEntityId { get; set; }
    public virtual StudentEntity StudentEntity { get; set; }
    public virtual TutorEntity TutorEntity { get; set; }
    public virtual List<ThesisStateEntity> States { get; set; }
}