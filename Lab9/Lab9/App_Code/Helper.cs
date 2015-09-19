using System.Collections;

/// <summary>
/// Summary description for Helper
/// </summary>
public class Helper
{
    public static ArrayList GetCourses()
    {
        ArrayList courses = new ArrayList();

        Course course = new Course("CST8282", "Introduction to Database Systems");
        course.WeeklyHours = 4;
        course.MaxEnrollment = 3;
        course.Fee = 300.0;
        courses.Add(course);

        course = new Course("CST8253", "Web Programming II");
        course.WeeklyHours = 2;
        course.MaxEnrollment = 4;
        course.Fee = 250.0;
        courses.Add(course);

        course = new Course("CST8256", "Web Programming Language I");
        course.WeeklyHours = 5;
        course.MaxEnrollment = 4;
        course.Fee = 350.0;
        courses.Add(course);

        course = new Course("CST8255", "Web Imaging and Animations");
        course.WeeklyHours = 2;
        course.MaxEnrollment = 3;
        course.Fee = 300.0;
        courses.Add(course);

        course = new Course("CST8254", "Network Operating System");
        course.WeeklyHours = 1;
        course.MaxEnrollment = 3;
        course.Fee = 200.0;
        courses.Add(course);

        course = new Course("CST2200", "Data Warehouse Design");
        course.WeeklyHours = 3;
        course.MaxEnrollment = 3;
        course.Fee = 250.0;
        courses.Add(course);

        course = new Course("CST2240", "Advance Database topics");
        course.WeeklyHours = 1;
        course.MaxEnrollment = 3;
        course.Fee = 500.0;
        courses.Add(course);

        return courses;
    }
}