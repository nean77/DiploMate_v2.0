namespace DiploMate.DAL;

public record AuthenticationSettings
{
    public string JwtKey { get; set; }
    public int JwtExpireDays { get; set; }
    public string JwtIssuer { get; set; }
}