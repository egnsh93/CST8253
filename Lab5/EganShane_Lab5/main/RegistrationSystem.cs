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
using EganShane_Lab5.student;

namespace EganShane_Lab5.main
{
    class RegistrationSystem
    {
        static void Main(string[] args)
        {
            // Instantiate a new List of type Course
            var courses = new List<Course>
            {
                // Add each course along with its properties to the Course List
                new Course("CST8282", "Introduction to Database Systems")
                {
                    WeeklyHours = 4,
                    MaxEnrollment = 3,
                    Fee = 300.0
                },
                new Course("CST8253", "Web Programming II")
                {
                    WeeklyHours = 2,
                    MaxEnrollment = 4,
                    Fee = 250.0
                },
                new Course("CST8256", "Web Programming Language I")
                {
                    WeeklyHours = 5,
                    MaxEnrollment = 4,
                    Fee = 350.0
                },
                new Course("CST8255", "Web Imaging and Animations")
                {
                    WeeklyHours = 2,
                    MaxEnrollment = 3,
                    Fee = 200.0
                }
            };

            var numStudents = 0;
            var students = new List<Student>();

            while (true)
            {
                // Prompt the user to enter a student name
                var studentName = "";
                do
                {
                    Console.Write("Enter student name: ");
                    studentName = Console.ReadLine();
                } while (studentName == "");

                // Prompt the user to enter a student type
                var studentType = "";

                do
                {
                    Console.Write("What type of student is " + studentName + " (full-time/part-time/co-op)? ");
                    studentType = Console.ReadLine();
                } while (studentType == "");

                Student student = null;

                // Create a new instance of the student type
                switch (studentType)
                {
                    case "full-time":
                    case "fulltime":
                        student = new FullTimeStudent(studentName);
                        break;
                    case "part-time":
                    case "parttime":
                        student = new PartTimeStudent(studentName);
                        break;
                    case "co-op":
                    case "coop":
                        student = new CoopStudent(studentName);
                        break;
                }

                students.Add(student);

                while (true)
                {
                    Console.WriteLine();

                    // Print out a selection menu for each course
                    foreach (var course in courses)
                    {
                        Console.WriteLine("Enter " + courses.IndexOf(course) + " to select " +
                                          courses.ElementAt(courses.IndexOf(course)).Title + " - " +
                                          course.GetNumberOfSpacesLeft() + " slots left");
                    }

                    // Print out optional menu items
                    if (numStudents > 0) Console.WriteLine("Enter 4 " + "to add a new student");
                    if (numStudents > 0) Console.WriteLine("Enter 5 " + "to view registration list");

                    numStudents++;

                    // Prompt the user to select a course
                    var courseIndex = 0;
                    do
                    {
                        Console.Write("\nEnter your selection: ");
                        courseIndex = GetValidInt(Console.ReadLine());
                    } while (courseIndex == -1);

                    // Break out of the loop to add a new student
                    if (courseIndex == 4)
                    {
                        break;
                    }

                    // Print out a list of student details
                    if (courseIndex == 5)
                    {
                        if (student != null) // Always check for null
                        {
                            // For each student print out their status and fee payable
                            foreach (var s in students)
                            {
                                Console.WriteLine("\n" + s.ToString() + "\n");

                                // Print each course the student is enrolled in
                                foreach (var c in s.GetEnrolledCourses())
                                {
                                    Console.WriteLine(c.ToString());
                                }
                            }
                        }

                        // Exit the program
                        Console.WriteLine("\nPress enter to exit...");
                        Console.Read();
                        Environment.Exit(0);
                    }

                    // If the selected course is not at maximum capacity
                    if (courses.ElementAt(courseIndex).IsAvailable() == false)
                    {
                        Console.WriteLine("\nThis course has reached maximum capacity, please try a different one");
                    }

                    else if (student != null)
                        switch (student.AddCourse(courses.ElementAt(courseIndex)))
                        {
                            // Does the student already exist?
                            case -1:
                                Console.WriteLine("Student already exists in this course");
                                break;

                            // Has the student exceeded their weekly hours
                            case 0:
                                Console.WriteLine("Adding this course will exceed the users weekly hours");
                                break;

                            // Green light
                            default:

                                // Add the student to the selected course and assign the course to the student
                                courses.ElementAt(courseIndex).AddStudent(student);
                                student.AddCourse(courses.ElementAt(courseIndex));

                                // Let the user know the student has been added
                                Console.WriteLine("\nStudent '" + student.Name + "' has been added to '" +
                                                  courses.ElementAt(courseIndex).Title + "'.");
                                Console.WriteLine();

                                // Display a list of courses the student is registered in
                                DisplayEnrolledCourses(student);
                                break;
                        }
                }
            }
            Console.Read();
        }

        public static void DisplayEnrolledCourses(Student student)
        {
            // Display a list of courses associated with the student
            Console.WriteLine("***************************************************");
            Console.WriteLine("Courses you are currently registered in:");
            Console.WriteLine("----------------------------------------");

            foreach (var course in student.GetEnrolledCourses())
            {
                Console.WriteLine(course.Title);
            }

            Console.WriteLine("\nYour total weekly hours are: " + student.TotalWeeklyHours());
            Console.WriteLine("Your tuition fee is: $" + student.FeePayable());
            Console.WriteLine("***************************************************");
        }

        public static int GetValidInt(String input)
        {
            int output;

            if (int.TryParse(input, out output)) return output;
            return -1;
        }
    }
}