using Microsoft.AspNetCore.Mvc;

namespace DiploMate.DAL.Models;

public class LoginDto
{
    private string _email = String.Empty;
    public string Email
    {
        get => _email;
        set
        {
            Email = value.ToUpper();
        } 
    }
    public string Password { get; set; }
}