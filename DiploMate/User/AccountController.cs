using Microsoft.AspNetCore.Mvc;

namespace DiploMate.User;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody]RegisterUser registerUser)
    {
        await  _accountService.RegisterUser(registerUser);
        return Ok();
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody]Login login)
    {
        string token =  _accountService.GenerateJwt(login);
        return Ok(token);
    }
}