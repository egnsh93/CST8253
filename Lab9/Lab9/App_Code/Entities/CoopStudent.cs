using System;

/// <summary>
/// Summary description for CoopStudent
/// </summary>
public class CoopStudent : Student
{
    public const double COOP_FEE = 500.0;
    public const int MAX_NUM_COURSES = 2;
    public const int MAX_WEEKLY_HOURS = 4;

    public CoopStudent(string name)
        : base(name)
    {
    }

    public override void addCourse(Course course)
    {
        if (courses.Count < MAX_NUM_COURSES)
        {
            if (totalWeeklyHours() + course.WeeklyHours <= MAX_WEEKLY_HOURS)
            {
                courses.Add(course);
            }
            else
            {
                throw new Exception("Your selection exceeds the maximum weekly hours: " + MAX_WEEKLY_HOURS);
            }
        }
        else
        {
            throw new Exception("Your selection exceeds the maximum number of courses: " + MAX_NUM_COURSES);
        }

    }

    public override double feePayable()
    {
        return base.feePayable() + COOP_FEE;
    }

    public override string ToString()
    {
        return string.Format("Co-op Student");
    }
}