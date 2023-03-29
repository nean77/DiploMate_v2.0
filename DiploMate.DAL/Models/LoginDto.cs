using Microsoft.AspNetCore.Mvc;

namespace DiploMate.DAL.Models;

public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}