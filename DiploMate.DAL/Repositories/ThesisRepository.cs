using Microsoft.EntityFrameworkCore;

namespace DiploMate.DAL.Repositories;

public class ThesisRepository : IRepository<ThesisDto>
{
    private readonly AppDbContext _ctx;

    public ThesisRepository(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<ThesisDto> GetAsync(Guid id)
    {
        var thesis = await _ctx.Theses
            .Include(s => s.States)
            .Include(st=>st.Student).ThenInclude(s=>s.User)
            .Include(t=>t.Tutor).ThenInclude(t=>t.User)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (thesis is null)
        {
            return null;
        }
        var studentDto = new StudentDto(thesis.Student.Id, thesis.Student.User.FirstName, thesis.Student.User.LastName, 
            thesis.Student.User.Email, thesis.Student.User.PhoneNumber, thesis.Student.UserName, 
            thesis.Student.StudentIdxNo, thesis.Student.User.Id);

        var tutorDto = new TutorDto(thesis.Tutor.Id, thesis.Tutor.User.FirstName, thesis.Tutor.User.LastName,
            thesis.Tutor.User.Email, String.Empty, thesis.Tutor.Degree);
        
        
        return new ThesisDto(thesis.Id, studentDto, tutorDto, thesis.Title, thesis.Description, thesis.StartDate,
            thesis.ApproximateEndDate, thesis.EndDate, thesis.ApproximatePagesCount, thesis.Hyperlink,
            thesis.CreateDateTime, thesis.CreatedBy, thesis.ModifiedDateTime, thesis.ModifiedBy, 
            Enumerable.Empty<ThesisStateDto>());
    }

    public async Task<IEnumerable<ThesisDto>> GetListAsync()
    {
        var theses = await _ctx.Theses
            .Include(s => s.States)
            .Include(st=>st.Student).ThenInclude(s=>s.User)
            .Include(t=>t.Tutor).ThenInclude(t=>t.User)
            .ToListAsync();

        if (theses is null)
        {
            return null;
        }

        var thesesDto = new List<ThesisDto>();
        foreach (var thesis in theses)
        {
            var studentDto = new StudentDto(thesis.Student.Id, thesis.Student.User.FirstName, thesis.Student.User.LastName, 
                thesis.Student.User.Email, thesis.Student.User.PhoneNumber, thesis.Student.UserName, 
                thesis.Student.StudentIdxNo, thesis.Student.User.Id);

            var tutorDto = new TutorDto(thesis.Tutor.Id, thesis.Tutor.User.FirstName, thesis.Tutor.User.LastName,
                thesis.Tutor.User.Email, String.Empty, thesis.Tutor.Degree);

            thesesDto.Add(new ThesisDto(thesis.Id, studentDto, tutorDto, thesis.Title, thesis.Description, thesis.StartDate,
                thesis.ApproximateEndDate, thesis.EndDate, thesis.ApproximatePagesCount, thesis.Hyperlink,
                thesis.CreateDateTime, thesis.CreatedBy, thesis.ModifiedDateTime, thesis.ModifiedBy, 
                Enumerable.Empty<ThesisStateDto>()));
        }

        return thesesDto;
    }

    public async Task<Guid> InsertAsync(ThesisDto entity)
    {
        var thesis = new Thesis
        {
            Title = entity.Title,
            StudentId = entity.StudentId,
            TutorId = entity.TutorId,
            Description = entity.Description,
            StartDate = entity.StartDate,
            ApproximateEndDate = entity.ApproximateEndDate,
            EndDate = entity.EndDate,
            ApproximatePagesCount = entity.ApproximatePagesCount,
            Hyperlink = entity.Hyperlink,
            CreatedBy = entity.CreatedBy,
            CreateDateTime = entity.CreateDateTime,
            ModifiedBy = entity.ModifiedBy,
            ModifiedDateTime = entity.ModifiedDateTime
        };
        
        await _ctx.Theses.AddAsync(thesis);
        await _ctx.SaveChangesAsync();
        return thesis.Id;
    }

    public async Task<ThesisDto> UpdateAsync(Guid id, ThesisDto entity)
    {
        var thesis = await _ctx.Theses.FirstOrDefaultAsync(x => x.Id == id);
        if (thesis is null)
        {
            return null;
        }

        thesis.Title = entity.Title;
        thesis.StudentId = entity.StudentId;
        thesis.TutorId = entity.TutorId;
        thesis.Description = entity.Description;
        thesis.StartDate = entity.StartDate;
        thesis.ApproximateEndDate = entity.ApproximateEndDate;
        thesis.EndDate = entity.EndDate;
        thesis.ApproximatePagesCount = entity.ApproximatePagesCount;
        thesis.Hyperlink = entity.Hyperlink;
        thesis.ModifiedBy = entity.ModifiedBy;
        thesis.ModifiedDateTime = entity.ModifiedDateTime;
        
        
        _ctx.Entry(thesis).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        var thesis = await _ctx.Theses.FirstOrDefaultAsync(x => x.Id == id);
        if (thesis is null)
        {
            return;
        }

        _ctx.Remove(thesis);
        await _ctx.SaveChangesAsync();
    }
}