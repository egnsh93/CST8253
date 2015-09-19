using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PartTimeStudent
/// </summary>
public class PartTimeStudent : Student
{
    public const int MAX_NUM_COURSES = 2;


    public PartTimeStudent(string name)
        : base(name)
    {
    }

    public override void addCourse(Course course)
    {

        if (courses.Count == MAX_NUM_COURSES)
        {
            throw new Exception("Your selection exceeds the maximum number of courses: " + MAX_NUM_COURSES);
        }
        else
        {
            courses.Add(course);
        }
    }
    public override string ToString()
    {
        return string.Format("Part-Time Student");
    }
}