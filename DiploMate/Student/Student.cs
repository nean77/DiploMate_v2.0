using DiploMate.Objects;

namespace DiploMate.Student;

public class Student
{
    public Guid Guid { get; }
    public Name FirstName { get; } 
    public Name LastName { get; } 
    public Email Email { get; } 
    public string UserName { get; }// gdx...
    public string StudentIdxNo { get; } // index 

    public Student(Guid guid, Name firstName, Name lastName, Email email, string userName, string studentIdxNo)
    {
        Guid = guid;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = userName;
        StudentIdxNo = studentIdxNo;
    }
}