using WCEapp.Interfaces;

namespace WCEapp.Models;

public abstract class Course : IPresentable
{
    public string CourseNumber { get; set; }
    public string Title { get; set; }
    public int DurationWeeks { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Staff {get; set; }

    public List<Student> Students { get; set; }

    public Course(string courseNumber, string title, int durationWeeks, DateTime startDate, DateTime endDate, string staff)
    {
        CourseNumber = courseNumber;
        Title = title;
        DurationWeeks = durationWeeks;
        StartDate = startDate;
        EndDate = endDate;
        Students = new List<Student>();
        Staff = staff;
    }

    public void AddStudent(Student student)
    {
        if (Students.Contains(student))
        {
            Console.WriteLine("The student is already in this course.");
        }
        else
        {
            Students.Add(student);
        }
    }

    public void ListStudents()
    {


        if (Students.Count == 0)
        {
            Console.WriteLine("No Students Enrolled");
            return;
        }

        foreach (var student in Students)
        {
            Console.WriteLine(student.Present());
        }
    }

    public virtual string CourseType => "Course";
    public virtual string Present()
    {
        return $"{CourseNumber} {Title}, {DurationWeeks} weeks, " +
        $"{StartDate:yyyy-MM-dd} to {EndDate:yyyy-MM-dd}, teacher: {Staff} ({CourseType})";
    }
}
