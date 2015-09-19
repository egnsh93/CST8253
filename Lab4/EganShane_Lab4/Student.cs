/*************************************************************************/
/**                                                                     **/
/**                                                                     **/
/**    Student Name                :  Shane Egan                        **/
/**    EMail Address               :  egan0049@algonquinlive.com        **/
/**    Student Number              :  040 695 345                       **/
/**    Course Number               :  CST 8253                          **/
/**    Lab Section Number          :  011                               **/
/**    Professor Name              :  Wei Gong                          **/
/**    Assignment Name/Number/Date :  Lab 4 - Classes (Feb 2 2015)     **/
/**    Optional Comments           :                                    **/
/**                                                                     **/
/**                                                                     **/
/*************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

namespace EganShane_Lab4
{
    public class Student
    {
        public const int MaxWeeklyHours = 8;
        private readonly string _name;
        private readonly List<Course> _courses;

        public Student(string name)
        {
            _name = name;
            _courses = new List<Course>();
        }

        public string Name
        {
            get { return _name; }
        }

        public void AddCourse(Course course)
        {
            _courses.Add(course);
        }

        public bool Exists(Course course)
        {
            return _courses.Any(c => c.Code == course.Code);
        }

        public bool HasValidHours(Course course)
        {
            return course.WeeklyHours + GetTotalWeeklyHours() <= MaxWeeklyHours;
        }

        public List<Course> GetEnrolledCourses()
        {
            return _courses;
        }

        public int GetTotalWeeklyHours()
        {
            return _courses.Sum(course => course.WeeklyHours);
        }

        public double GetTotalTuitionFee()
        {
            return _courses.Sum(course => course.Fee);
        }
    }
}