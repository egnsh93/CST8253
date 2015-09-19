using System;

/// <summary>
/// Summary description for FullTimeStudent
/// </summary>
public class FullTimeStudent : Student
{
    public const int MAX_WEEKLY_HOURS = 8;

    public FullTimeStudent(string name)
        : base(name)
    {
    }

    public override void addCourse(Course course)
    {

        if (course.WeeklyHours + totalWeeklyHours() > MAX_WEEKLY_HOURS)
        {
            throw new Exception("Your selection exceeds the maximum weekly hours: " + MAX_WEEKLY_HOURS);
        }
        else
        {
            courses.Add(course);
        }
    }

    public override string ToString()
    {
        return string.Format("Full-time Student");
    }
}