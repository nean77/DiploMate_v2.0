﻿namespace DiploMate.User;

public record Login
{
    public string Email { get; set; }
    public string Password { get; set; }
}