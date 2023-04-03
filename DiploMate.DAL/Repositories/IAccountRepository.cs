using DiploMate.DAL.Models;

namespace DiploMate.DAL.Repositories;

public interface IAccountRepository
{
    Task<Guid> RegisterUser(RegisterUserDto registerUser, StudentDto studentDto = null);
    string GenerateJwt(LoginDto loginDto);
}