using System.Collections;

/// <summary>
/// Summary description for Student
/// </summary>
public abstract class Student
{
    private string name;

    protected ArrayList courses;

    protected Student(string name)
    {
        this.name = name;
        courses = new ArrayList();
    }

    public string Name
    {
        get { return name; }
    }

    public ArrayList getEnrolledCourses()
    {
        return courses;
    }

    public int totalWeeklyHours()
    {
        int totalHours = 0;
        foreach (Course course in courses)
        {
            totalHours += course.WeeklyHours;
        }
        return totalHours;
    }

    public virtual double feePayable()
    {
        double totalFee = 0.0;
        foreach (Course course in courses)
        {
            totalFee += course.Fee;
        }
        return totalFee;
    }

    public abstract void addCourse(Course course);
}