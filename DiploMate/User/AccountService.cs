using AutoMapper;
using DiploMate.DAL.Models;
using DiploMate.DAL.Repositories;

namespace DiploMate.User;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _repository;
    private readonly IMapper _mapper;

    public AccountService(IAccountRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task RegisterUser(RegisterUser registerUser)
    {
        var dto = _mapper.Map<RegisterUserDto>(registerUser);

        await _repository.RegisterUser(dto);
    }

    public string GenerateJwt(Login login)
    {
        var dto = _mapper.Map<LoginDto>(login);

        var token = _repository.GenerateJwt(dto);

        return token;
    }
}