namespace WCEapp.Models;

public class Administrator : CourseLeader
{
    public Administrator(string firstName, string lastName, string phoneNumber,
                   string personalNumber, Address address, string knowledgeArea, DateTime employmentDate)
                       : base(firstName, lastName, phoneNumber, personalNumber, address,
           knowledgeArea, employmentDate)
    {
    }

    public override string Role => "Administrator";
}