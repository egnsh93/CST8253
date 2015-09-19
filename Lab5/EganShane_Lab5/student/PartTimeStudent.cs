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

using System.Linq;
using EganShane_Lab5.course;

namespace EganShane_Lab5.student
{
    class PartTimeStudent : Student
    {
        public const int MaxNumCourses = 2;

        public PartTimeStudent(string name) : base(name) {}

        public override int AddCourse(Course course)
        {
            // If the student already exists
            if (this.courses.Any(c => c.Code == course.Code))
                return -1;

            // If the student exceeds their max number of courses
            if (this.courses.Count == MaxNumCourses)
                return 0;

            // Otherwise add the course to the student
            this.courses.Add(course);
            return 1;
        }

        public override string ToString()
        {
            return base.Name + " (Part-time Student) has enrolled in the following courses and has tuition payable $" + base.FeePayable();
        }
    }
}