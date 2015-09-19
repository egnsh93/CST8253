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
using EganShane_Lab5.student;

namespace EganShane_Lab5.course
{
    public class Course
    {
        protected List<Student> _students; 
        public string Code { get; set; }
        public string Title { get; set; }
        public int WeeklyHours { get; set; }
        public double Fee { get; set; }
        public int MaxEnrollment { get; set; }

        public Course(string code, string title)
        {
            Code = code;
            Title = title;
            _students = new List<Student>();
        }

        public bool IsAvailable()
        {
            return _students.Count < MaxEnrollment;
        }

        public int GetNumberOfSpacesLeft()
        {
            return MaxEnrollment - _students.Count;
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public override string ToString()
        {
            return Code + " - " + Title;
        }

    }
}