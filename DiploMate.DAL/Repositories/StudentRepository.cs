using DiploMate.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DiploMate.DAL.Repositories;

public class StudentRepository: IRepository<StudentDto>
{
    private readonly AppDbContext _ctx;

    public StudentRepository(AppDbContext ctx)
    {
        _ctx = ctx;
    }
    
    public async Task<StudentDto> GetAsync(Guid id)
    {
        var user =  await _ctx.Users.FirstOrDefaultAsync(x => x.Id == id);
        var student = await _ctx.Students.FirstOrDefaultAsync(x => x.UserId == user.Id);
        if (user is null || student is null)
        {
            return null;
        }
        return new StudentDto(student.Id, user.FirstName, user.LastName, user.Email, 
            user.PhoneNumber, student.UserName, student.StudentIdxNo, user.Id); 
    }

    public async Task<IEnumerable<StudentDto>> GetListAsync()
    {
        var students = await _ctx.Students.Include(u=>u.User).ToListAsync();
        var studentsDto = new List<StudentDto>();
        foreach (var student in students)
        {
            studentsDto.Add(new StudentDto(student.Id, student.User.FirstName, student.User.LastName, student.User.Email, 
                student.User.PhoneNumber, student.UserName, student.StudentIdxNo, student.User.Id));
        }

        return studentsDto;
    }

    public async Task<Guid> InsertAsync(StudentDto entity)
    {
        var accountRepository = new AccountRepository(_ctx, new PasswordHasher<User>(), new AuthenticationSettings());
        var registerUser = new RegisterUserDto()
        {
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Password = "EmptyUser",
            ConfirmPassword = "EmptyUser",
            RoleId = 2
        };

        await accountRepository.RegisterUser(registerUser, entity);
        
        return entity.StudenId;
    }

    public async Task<StudentDto> UpdateAsync(Guid id, StudentDto entity)
    {
        var student = await _ctx.Students
            .Include(u => u.User)
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (student is null) return entity;
        
        student.User.FirstName = entity.FirstName;
        student.User.LastName = entity.LastName;
        student.User.Email = entity.Email;
        student.User.NormalizedEmail = entity.Email.ToUpper();
        student.User.PhoneNumber = entity.PhoneNumber;
        student.StudentIdxNo = entity.StudentIdxNo;
        student.UserName = entity.UserName;

        _ctx.Entry(student).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        var student = await _ctx.Students
            .Include(u => u.User)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (student is not null)
        {
            _ctx.Entry(student).State = EntityState.Deleted;
            await _ctx.SaveChangesAsync();
        }
    }
}