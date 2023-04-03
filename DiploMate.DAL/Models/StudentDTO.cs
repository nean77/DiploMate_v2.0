namespace DiploMate.DAL.Repositories;

public record StudentDto(Guid StudenId, string FirstName, string LastName, string Email, string? PhoneNumber, string UserName, string StudentIdxNo,Guid UserId);