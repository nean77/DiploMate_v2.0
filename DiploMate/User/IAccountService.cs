namespace DiploMate.User;

public interface IAccountService
{
    Task RegisterUser(RegisterUser registerUser);
    string GenerateJwt(Login login);
}