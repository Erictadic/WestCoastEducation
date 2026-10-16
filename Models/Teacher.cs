namespace WCEapp.Models;

public class Teacher : Person
{
    public string KnowledgeArea { get; set; }
    public List<Course> ResponsibleCourses { get; set; }

    public Teacher(string firstName, string lastName, string phoneNumber,
                   string personalNumber, Address address, string knowledgeArea)
        : base(firstName, lastName, phoneNumber, personalNumber, address)
    {
        KnowledgeArea = knowledgeArea;
        ResponsibleCourses = new List<Course>();
    }
    public override string Role => "Teacher";

    public override string Present()
    {
        return base.Present() + $", Kowledge area: {KnowledgeArea}";
    }
    public void AddCourse(Course course)
    {
        if (ResponsibleCourses.Contains(course))
        {
            Console.WriteLine("The course already exists, add a new one instead!");
        }
        else
        {
            ResponsibleCourses.Add(course);
        }
    }
    public void ListCourses()
    {
        if (ResponsibleCourses.Count == 0)
        {
            Console.WriteLine("Teacher has no current classes");
            return;
        }

        foreach (var course in ResponsibleCourses)
        {
            Console.WriteLine(course.Present());
        }
    }
}