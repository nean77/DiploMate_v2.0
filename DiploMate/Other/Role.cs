using System.ComponentModel.DataAnnotations;

namespace DiploMate.Other;

public enum Role
{
    Tutor = 1,
    Student = 2,
    [Display(Name="Office employee")]Office_employee = 3,
    Admin = 4
}