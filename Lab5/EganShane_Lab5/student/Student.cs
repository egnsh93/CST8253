/*************************************************************************/
/**                                                                     **/
/**                                                                     **/
/**    Student Name                :  Shane Egan                        **/
/**    EMail Address               :  egan0049@algonquinlive.com        **/
/**    Student Number              :  040 695 345                       **/
/**    Course Number               :  CST 8253                          **/
/**    Lab Section Number          :  011                               **/
/**    Professor Name              :  Wei Gong                          **/
/**    Assignment Name/Number/Date :  Lab 5 - Inheritance (Feb 11 2015) **/
/**    Optional Comments           :                                    **/
/**                                                                     **/
/**                                                                     **/
/*************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using EganShane_Lab5.course;

namespace EganShane_Lab5.student
{
    public abstract class Student
    {
        protected List<Course> courses;
        public string Name { get; private set; }

        protected Student(string name)
        {
            this.Name = name;
            courses = new List<Course>();
        }

        public virtual double FeePayable()
        {
            return courses.Sum(course => course.Fee);
        }

        public int TotalWeeklyHours()
        {
            return courses.Sum(course => course.WeeklyHours);
        }

        public abstract int AddCourse(Course course);

        public List<Course> GetEnrolledCourses()
        {
            return courses;
        }
    }
}