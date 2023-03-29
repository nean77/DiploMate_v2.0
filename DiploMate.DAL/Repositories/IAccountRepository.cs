using DiploMate.DAL.Models;

namespace DiploMate.DAL.Repositories;

public interface IAccountRepository
{
    Task RegisterUser(RegisterUserDto registerUser);
    string GenerateJwt(LoginDto loginDto);
}