namespace WCEapp.Models;

public class DistanceCourse : Course
{
    public DistanceCourse(string courseNumber, string title, int durationWeeks,
                          DateTime startDate, DateTime endDate, string staff)
        : base(courseNumber, title, durationWeeks, startDate, endDate, staff)
    {
    }

    public override string CourseType => "Distance course";
}