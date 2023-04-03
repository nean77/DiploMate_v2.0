using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DiploMate.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DiploMate.DAL.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly AppDbContext _ctx;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly AuthenticationSettings _authenticationSettings;

    public AccountRepository(AppDbContext ctx, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
    {
        _ctx = ctx;
        _passwordHasher = passwordHasher;
        _authenticationSettings = authenticationSettings;
    }


    public async Task<Guid> RegisterUser(RegisterUserDto registerUser, StudentDto studentDto = null)
    {
        await using var transaction = await _ctx.Database.BeginTransactionAsync();
        try
        {
            var newUser = new User()
            {
                FirstName = registerUser.FirstName,
                LastName = registerUser.LastName,
                Email = registerUser.Email,
                NormalizedEmail = registerUser.Email.ToUpper(),
                RoleId = registerUser.RoleId
            };
            var hashedPwd = _passwordHasher.HashPassword(newUser, registerUser.Password);
            newUser.PasswordHash = hashedPwd;

            _ctx.Users.Add(newUser);
            await _ctx.SaveChangesAsync();
            await AddAccount(newUser, studentDto);
            await transaction.CommitAsync();
            return newUser.Id;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception(ex.Message, ex);
        }
    }

    private async Task AddAccount(User newUser, StudentDto studentDto = null)
    {
        switch (newUser.RoleId)
        {
            case 1:
                _ctx.Tutors.Add(new Tutor() { UserId = newUser.Id });
                await _ctx.SaveChangesAsync();
                break;
            case 2:
                var student = new Student() { UserId = newUser.Id };
                if (studentDto is not null)
                {
                    student.UserName = studentDto.UserName;
                    student.StudentIdxNo = studentDto.StudentIdxNo;
                }
                _ctx.Students.Add(student);
                await _ctx.SaveChangesAsync();
                break;
        }
    }

    public string GenerateJwt(LoginDto loginDto)
    {
        var user = LoginVerification(loginDto);

        var claims = CreateClaims(user);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

        var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
            _authenticationSettings.JwtIssuer,
            claims,
            expires: expires,
            signingCredentials: cred);

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }

    private User LoginVerification(LoginDto loginDto)
    {
        var user = _ctx.Users
            .Include(u => u.Role)
            .FirstOrDefault(u => u.NormalizedEmail == loginDto.Email);

        if (user is null)
        {
            throw new Exception(); //new BadRequestException("Invalid username or password");
        }

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            throw new Exception(); // new BadRequestException("Invalid username or password");
        }

        return user;
    }

    private IList<Claim> CreateClaims(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
            new Claim(ClaimTypes.Email, user.Email)
        };
        return claims;
    }
}