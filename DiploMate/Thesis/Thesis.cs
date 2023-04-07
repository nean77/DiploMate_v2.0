using AutoMapper;
using DiploMate.DAL;
using DiploMate.DAL.Repositories;

namespace DiploMate.Thesis;

public class Thesis
{
    public Guid Id { get; }
    public Guid StudentId { get; }
    public Guid TutorId { get; }
    public string Title { get; }
    public string Description { get; }
    public DateOnly StartDate { get; }
    public DateOnly ApproximateEndDate { get; }
    public DateOnly EndDate { get; }
    public int ApproximatePagesCount { get; }
    public string Hyperlink { get; }
    public DateTime CreateDateTime { get; }
    public Guid CreatedBy { get; }
    public DateTime ModifiedDateTime { get; }
    public Guid ModifiedBy { get; }
    
    public List<ThesisState> ThesisStates { get; }
    public Student.Student Student{ get; private set; }
    public Tutor.Tutor Tutor { get; private set; }

    public Thesis(Guid thesisId, Guid studentId, Guid tutorId, string title, string description,
        DateOnly startDate, DateOnly approximateEndDate, DateOnly endDate, int approximatePagesCount,
        string hyperlink, DateTime createDateTime, Guid createdBy, DateTime modifiedDateTime, Guid modifiedBy)
    {
        Id = thesisId;
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
    }

    public Thesis(Guid thesisId, Guid studentId, Guid tutorId, string title, string description,
        DateOnly startDate, DateOnly approximateEndDate, DateOnly endDate, int approximatePagesCount,
        string hyperlink, DateTime createDateTime, Guid createdBy, DateTime modifiedDateTime, Guid modifiedBy,
        IEnumerable<ThesisState> thesisStates) 
        : this(thesisId, studentId, tutorId, title, description, startDate, approximateEndDate, endDate, 
            approximatePagesCount, hyperlink, createDateTime, createdBy, modifiedDateTime, modifiedBy)
    {
        ThesisStates = thesisStates.ToList();
    }

    public Thesis(Guid thesisId, StudentDto studentDto, TutorDto tutorDto, string title, string description,
        DateOnly startDate, DateOnly approximateEndDate, DateOnly endDate, int approximatePagesCount,
        string hyperlink, DateTime createDateTime, Guid createdBy, DateTime modifiedDateTime, Guid modifiedBy)
    {
        Id = thesisId;
        StudentId = studentDto.StudenId;
        TutorId = tutorDto.TutorId;
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
        
        Student = new Student.Student(studentDto.StudenId,studentDto.FirstName,
            studentDto.LastName, studentDto.Email, studentDto.UserName,studentDto.StudentIdxNo);

        Tutor = new Tutor.Tutor(tutorDto.TutorId, tutorDto.FirstName, tutorDto.LastName, tutorDto.Email,
            tutorDto.PhoneNumber, tutorDto.Degree);
    }
    
    public Thesis(Guid thesisId, StudentDto studentDto, TutorDto tutorDto, string title, string description,
        DateOnly startDate, DateOnly approximateEndDate, DateOnly endDate, int approximatePagesCount,
        string hyperlink, DateTime createDateTime, Guid createdBy, DateTime modifiedDateTime, Guid modifiedBy,
        IEnumerable<ThesisState> thesisStates) 
        : this(thesisId, studentDto, tutorDto, title, description, startDate, approximateEndDate, endDate, 
            approximatePagesCount, hyperlink, createDateTime, createdBy, modifiedDateTime, modifiedBy)
    {
        ThesisStates = thesisStates.ToList();
    }
}