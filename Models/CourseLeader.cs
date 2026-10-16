namespace WCEapp.Models;

public class CourseLeader : Teacher
{
    public DateTime EmploymentDate { get; set; }

    public CourseLeader(string firstName, string lastName, string phoneNumber,
                        string personalNumber, Address address, string knowledgeArea, DateTime employmentDate)
            : base(firstName, lastName, phoneNumber, personalNumber, address, knowledgeArea)
    {
        EmploymentDate = employmentDate;
    }
    public override string Role => "CourseLeader";

    public override string Present()
    {
        return base.Present() + $", Date Of Employment: {EmploymentDate:yyyy-MM-dd}";
    }
}