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
using System.Text;
using System.Threading.Tasks;
using EganShane_Lab5.course;

namespace EganShane_Lab5.student
{
    class FullTimeStudent : Student
    {
        public const int MaxWeeklyHours = 8;

        public FullTimeStudent(string name) : base(name) {}

        public override int AddCourse(Course course)
        {
            // If the student already exists
            if (this.courses.Any(c => c.Code == course.Code))
                return -1;
            
            // If the student's total weekly hours exceeds their max weekly hours
            if ((course.WeeklyHours + this.TotalWeeklyHours()) > MaxWeeklyHours)
                    return 0;

            // Otherwise add the course to the student
            this.courses.Add(course);
            return 1;
        }

        public override string ToString()
        {
            return base.Name + " (Full-time Student) has enrolled in the following courses and has tuition payable $" + base.FeePayable();
        }
    }
}
