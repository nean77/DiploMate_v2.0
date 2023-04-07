namespace DiploMate.DAL.Repositories;

public class ThesisDto
{
    public Guid ThesisId { get;  }
    public Guid StudentId { get; }
    public Guid TutorId { get; }
    public StudentDto StudentDto { get; }
    public TutorDto TutorDto { get; }
    public string Title { get; }
    public string? Description { get; }
    public DateTime StartDate { get; }
    public DateTime? ApproximateEndDate { get; }
    public DateTime? EndDate { get; }
    public int? ApproximatePagesCount { get; }
    public string? Hyperlink { get; }
    public DateTime CreateDateTime { get; }
    public Guid CreatedBy { get; }
    public DateTime ModifiedDateTime { get; }
    public Guid ModifiedBy { get; }
    public IEnumerable<ThesisStateDto> ThesisStateDtos { get; }


    public ThesisDto(Guid thesisId, StudentDto studentDto, TutorDto tutorDto, string title, string? description,
        DateTime startDate, DateTime? approximateEndDate, DateTime? endDate, int? approximatePagesCount,
        string? hyperlink, DateTime createDateTime, Guid createdBy, DateTime modifiedDateTime, Guid modifiedBy,
        IEnumerable<ThesisStateDto> thesisStateDtos)
    {
        ThesisId = thesisId;
        StudentDto = studentDto;
        TutorDto = tutorDto;
        Title = title;
        Description = description;
        StartDate = startDate;
        ApproximateEndDate = approximateEndDate;
        EndDate = endDate;
        ApproximatePagesCount = approximatePagesCount;
        Hyperlink = hyperlink;
        CreateDateTime = createDateTime;
        CreatedBy = createdBy;
        ModifiedDateTime = modifiedDateTime;
        ModifiedBy = modifiedBy;
        ThesisStateDtos = thesisStateDtos;
    }
    public ThesisDto(Guid thesisId, Guid studentId, Guid tutorId, string title, string? description,
        DateTime startDate, DateTime? approximateEndDate, DateTime? endDate, int? approximatePagesCount,
        string? hyperlink, DateTime createDateTime, Guid createdBy, DateTime modifiedDateTime, Guid modifiedBy,
        IEnumerable<ThesisStateDto> thesisStateDtos)
    {
        ThesisId = thesisId;
        StudentId = studentId;
        TutorId = tutorId;
        Title = title;
        Description = description;
        StartDate = startDate;
        ApproximateEndDate = approximateEndDate;
        EndDate = endDate;
        ApproximatePagesCount = approximatePagesCount;
        Hyperlink = hyperlink;
        CreateDateTime = createDateTime;
        CreatedBy = createdBy;
        ModifiedDateTime = modifiedDateTime;
        ModifiedBy = modifiedBy;
        ThesisStateDtos = thesisStateDtos;
    }
}