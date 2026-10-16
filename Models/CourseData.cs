using System.Dynamic;

namespace WCEapp.Models;

public class CourseData
{
    public string Type { get; set; } = "";
    public string CourseNumber { get; set; } = "";
    public string Title { get; set; } = "";
    public int DurationWeeks { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Staff {get; set; } = "";
}