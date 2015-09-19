using System.Collections;

/// <summary>
/// Summary description for Course
/// </summary>
public class Course
{
    public string Code { get; set; }
    public string Title { get; set; }
    public int WeeklyHours { get; set; }
    public double Fee { get; set; }
    public int MaxEnrollment { get; set; }

    private ArrayList students;

    public Course(string code, string title)
    {
        Code = code;
        Title = title;
        students = new ArrayList();
    }

    public void addStudent(Student student)
    {
        students.Add(student);
    }

    public override string ToString()
    {
        return Code + " " + Title + "  -  " + WeeklyHours.ToString() + (WeeklyHours==1 ? " hour":" hours") + " per week";
    }
}