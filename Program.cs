using WCEapp.Models;
using WCEapp.Services;

var registry = new SchoolRegistry();

registry.LoadCourses("courses.json");

bool running = true;

while (running)
{
    Console.WriteLine("------> WestCoastEducation <------");
    Console.WriteLine("1. List Courses");
    Console.WriteLine("2. List Students");
    Console.WriteLine("3. List Staff");
    Console.WriteLine("4. Add Courses");
    Console.WriteLine("5. Add Students");
    Console.WriteLine("6. Add Staff");
    Console.WriteLine("0. Exit");


    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            registry.ListCourses();
            break;

        case "2":
            registry.ListStudents();
            break;

        case "3":
            registry.ListStaff();
            break;
        case "4":
            {
                Console.Write("Course number: ");
                string courseNumber = Console.ReadLine() ?? "";

                Console.Write("Course title: ");
                string courseTitle = Console.ReadLine() ?? "";

                Console.Write("Duration (weeks): ");
                int durationWeeks = int.Parse(Console.ReadLine() ?? "");

                Console.Write("Start date (yyyy-mm-dd): ");
                DateTime startDate = DateTime.Parse(Console.ReadLine() ?? "");

                Console.Write("End date (yyyy-mm-dd): ");
                DateTime endDate = DateTime.Parse(Console.ReadLine() ?? "");

                Console.Write("Teacher name: ");
                string teacherName = Console.ReadLine() ?? "";

                Console.Write("Type (1 = Classroom, 2 = Distance): ");
                string courseType = Console.ReadLine() ?? "";

                Course course;

                if (courseType == "1")
                {
                    course = new ClassroomCourse(courseNumber, courseTitle, durationWeeks, startDate, endDate, teacherName);
                }
                else
                {
                    course = new DistanceCourse(courseNumber, courseTitle, durationWeeks, startDate, endDate, teacherName);
                }

                registry.AddCourse(course);
                Console.WriteLine("Course added!");

                break;
            }
        case "5":
            {
                Console.Write("First name: ");
                string firstName = Console.ReadLine() ?? "";

                Console.Write("Last name: ");
                string lastName = Console.ReadLine() ?? "";

                Console.Write("Phone number: ");
                string phoneNumber = Console.ReadLine() ?? "";

                Console.Write("Personal number (yymmdd-xxxx): ");
                string personalNumber = Console.ReadLine() ?? "";

                Console.Write("Street: ");
                string street = Console.ReadLine() ?? "";

                Console.Write("Postal code: ");
                string postalCode = Console.ReadLine() ?? "";

                Console.Write("City: ");
                string city = Console.ReadLine() ?? "";

                Address address = new Address(street, postalCode, city);

                Student student = new Student(firstName, lastName, phoneNumber,
                                              personalNumber, address, DateTime.Today);

                registry.AddStudent(student);
                Console.WriteLine("Student added!");

                break;
            }

        case "6":
            {
                Console.Write("First name: ");
                string firstName = Console.ReadLine() ?? "";

                Console.Write("Last name: ");
                string lastName = Console.ReadLine() ?? "";

                Console.Write("Phone number: ");
                string phoneNumber = Console.ReadLine() ?? "";

                Console.Write("Personal number (yymmdd-xxxx): ");
                string personalNumber = Console.ReadLine() ?? "";

                Console.Write("Street: ");
                string street = Console.ReadLine() ?? "";

                Console.Write("Postal code: ");
                string postalCode = Console.ReadLine() ?? "";

                Console.Write("City: ");
                string city = Console.ReadLine() ?? "";

                Console.Write("Knowledge area: ");
                string knowledgeArea = Console.ReadLine() ?? "";

                Console.Write("Role (1 = Teacher, 2 = Course leader, 3 = Administrator): ");
                string role = Console.ReadLine() ?? "";

                Address address = new Address(street, postalCode, city);

                Teacher person;

                if (role == "2" || role == "3")
                {
                    Console.Write("Employment date (yyyy-mm-dd): ");
                    DateTime employmentDate = DateTime.Parse(Console.ReadLine() ?? "");

                    if (role == "2")
                    {
                        person = new CourseLeader(firstName, lastName, phoneNumber, personalNumber,
                                                  address, knowledgeArea, employmentDate);
                    }
                    else
                    {
                        person = new Administrator(firstName, lastName, phoneNumber, personalNumber,
                                                   address, knowledgeArea, employmentDate);
                    }
                }
                else
                {
                    person = new Teacher(firstName, lastName, phoneNumber, personalNumber,
                                         address, knowledgeArea);
                }

                registry.AddStaff(person);
                Console.WriteLine($"{person.Role} added!");

                break;
            }
        case "0":
            registry.SaveCourses("courses.json");
            return;

        default:
            Console.WriteLine("Invalid choice, try again.");
            break;
    }
}