using System.Text.Json;
using WCEapp.Interfaces;
using WCEapp.Models;

namespace WCEapp.Services;

public class SchoolRegistry
{
    public List<Course> Courses { get; } = new();
    public List<Student> Students { get; } = new();
    public List<Teacher> Staff { get; } = new();

    public void AddCourse(Course course) => Courses.Add(course);
    public void AddStudent(Student student) => Students.Add(student);
    public void AddStaff(Teacher person) => Staff.Add(person);
    public void ListCourses() => PrintAll("Courses", Courses);
    public void ListStudents() => PrintAll("Students", Students);
    public void ListStaff() => PrintAll("Staff", Staff);

    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

    public void SaveCourses(string filePath)
    {
        var data = Courses.Select(course => new CourseData
        {
            Type = course is ClassroomCourse ? "Classroom" : "Distance",
            CourseNumber = course.CourseNumber,
            Title = course.Title,
            DurationWeeks = course.DurationWeeks,
            StartDate = course.StartDate,
            EndDate = course.EndDate,
            Staff = course.Staff
        }).ToList();

        string json = JsonSerializer.Serialize(data, JsonOptions);
        File.WriteAllText(filePath, json);

        Console.WriteLine($"\nSaved {data.Count} courses to {filePath}");
    }

    public void LoadCourses(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"\nNo saved courses found ({filePath}).");
            return;
        }
        try
        {
            string json = File.ReadAllText(filePath);
            var data = JsonSerializer.Deserialize<List<CourseData>>(json) ?? new();

            Courses.Clear();
            foreach (var d in data)
            {
                Course course = d.Type == "Classroom"
                    ? new ClassroomCourse(d.CourseNumber, d.Title, d.DurationWeeks, d.StartDate, d.EndDate, d.Staff)
                    : new DistanceCourse(d.CourseNumber, d.Title, d.DurationWeeks, d.StartDate, d.EndDate, d.Staff);

                Courses.Add(course);
            }

            Console.WriteLine($"\nLoaded {Courses.Count} courses from {filePath}");
        }
        catch (JsonException)
        {

            Console.WriteLine($"\nCould not read {filePath} – the file is not valid JSON.");
        }
    }


    private void PrintAll(string title, IEnumerable<IPresentable> items)
    {
        Console.WriteLine($"\n--- {title} ---");

        if (!items.Any())
        {
            Console.WriteLine($"No {title.ToLower()} registered.");
            return;
        }

        foreach (var item in items)
        {
            Console.WriteLine(item.Present());
        }
    }
}