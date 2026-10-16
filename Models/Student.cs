namespace WCEapp.Models;

public class Student : Person
{
    public DateTime EnrollmentDate { get; set; }
    public Student(string firstName, string lastName, string phoneNumber,
               string personalNumber, Address address, DateTime enrollmentDate)
    : base(firstName, lastName, phoneNumber, personalNumber, address)
    {
        EnrollmentDate = enrollmentDate;
    }
    public override string Role => "Student";
    public override string Present()
    {
        return base.Present() + $", enrolled {EnrollmentDate:yyyy-MM-dd}";
    }
}