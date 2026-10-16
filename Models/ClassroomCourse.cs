namespace WCEapp.Models;

public class ClassroomCourse : Course
{
    public ClassroomCourse(string courseNumber, string title, int durationWeeks,
                           DateTime startDate, DateTime endDate, string staff)
        : base(courseNumber, title, durationWeeks, startDate, endDate, staff)
    {
    }

    public override string CourseType => "Classroom course";
}