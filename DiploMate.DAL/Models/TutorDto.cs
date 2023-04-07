namespace DiploMate.DAL.Repositories;

public record TutorDto (Guid TutorId, string FirstName, string LastName, string Email, string? PhoneNumber, string? Degree);