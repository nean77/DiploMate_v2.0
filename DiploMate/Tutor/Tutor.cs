using DiploMate.Objects;

namespace DiploMate.Tutor;

public class Tutor
{
    public Guid Guid { get; }
    public Name FirstName { get; } 
    public Name LastName { get; } 
    public Email Email { get; }
    public string PhoneNumber { get; }
    public string Degree { get; }

    public Tutor(Guid guid, Name firstName, Name lastName, Email email)
    {
        Guid = guid;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public Tutor(Guid guid, Name firstName, Name lastName, Email email, string phoneNumber, string degree) : this(guid, 
        firstName, lastName, email)
    {
        PhoneNumber = phoneNumber;
        Degree = degree;
    }
}