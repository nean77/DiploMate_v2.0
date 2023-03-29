using DiploMate.Objects;
using DiploMate.Other;

namespace DiploMate.User;

public class RegisterUser
{
    public Name FirstName { get; set; }
    public Name LastName { get; set; } 
    public Email Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; } 
    public Role Role { get; set; }
}

