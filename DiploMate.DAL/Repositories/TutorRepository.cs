using DiploMate.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DiploMate.DAL.Repositories;

public class TutorRepository: IRepository<TutorDto>
{
    private readonly AppDbContext _ctx;

    public TutorRepository(AppDbContext ctx)
    {
        _ctx = ctx;
    }
    
    public async Task<TutorDto> GetAsync(Guid id)
    {
        var user =  await _ctx.Users.FirstOrDefaultAsync(x => x.Id == id);
        var tutor = await _ctx.Tutors.FirstOrDefaultAsync(x => x.UserId == user.Id);
        if (user is null || tutor is null)
        {
            return null;
        }
        return new TutorDto(tutor.Id, user.FirstName, user.LastName, user.Email, 
            user.PhoneNumber, tutor.Degree); 
    }

    public async Task<IEnumerable<TutorDto>> GetListAsync()
    {
        var tutors = await _ctx.Tutors.Include(u=>u.User).ToListAsync();
        var tutorsDto = new List<TutorDto>();
        foreach (var tutor in tutors)
        {
            tutorsDto.Add(new TutorDto(tutor.Id, tutor.User.FirstName, tutor.User.LastName, tutor.User.Email, 
                tutor.User.PhoneNumber, tutor.Degree));
        }

        return tutorsDto;
    }

    public async Task<TutorDto> UpdateAsync(Guid id, TutorDto entity)
    {
        var tutor = await _ctx.Tutors
            .Include(u => u.User)
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (tutor is null) return entity;
        
        tutor.User.FirstName = entity.FirstName;
        tutor.User.LastName = entity.LastName;
        tutor.User.Email = entity.Email;
        tutor.User.NormalizedEmail = entity.Email.ToUpper();
        tutor.User.PhoneNumber = entity.PhoneNumber;
        tutor.Degree = entity.Degree;

        _ctx.Entry(tutor).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();

        return entity;
    }

    public Task<Guid> InsertAsync(TutorDto entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

}