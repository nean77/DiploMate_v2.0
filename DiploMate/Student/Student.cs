using DiploMate.Objects;

namespace DiploMate.Student;

public class Student
{
    public Guid Guid { get; private set; }
    public Name FirstName { get; private set; } 
    public Name LastName { get; private set; } 
    public Email Email { get; private set; } 
    public string UserName { get; private set; }// gdx...
    public string StudentIdxNo { get; private set; } // index 

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