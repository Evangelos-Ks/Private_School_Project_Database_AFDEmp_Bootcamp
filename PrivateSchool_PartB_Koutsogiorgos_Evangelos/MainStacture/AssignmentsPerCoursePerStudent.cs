using System;
using System.Collections.Generic;


namespace MainStacture
{
    public class AssignmentsPerCoursePerStudent
    {
        //Fields==============================================================================================================
        private string courseTitle;
        private string firstName;
        private string lastName;
        private string assignmentTitle;
        private string assignmentDescription;

        //Constructors===================================================================================================================
        public AssignmentsPerCoursePerStudent() { }

        public AssignmentsPerCoursePerStudent(string courseTitle, string firstName, string lastName, string assignmentTitle, string assignmentDescription)
        {
            this.courseTitle = courseTitle;
            this.firstName = firstName;
            this.lastName = lastName;
            this.assignmentTitle = assignmentTitle;
            this.assignmentDescription = assignmentDescription;
        }

        //Methods==============================================================================================================
        public void ListOfAssignmentsPerCoursePerStudentOutput(List<AssignmentsPerCoursePerStudent> assignmentsPerCoursePerStudents)
        {
            int counter = 1;
            int longestCourseTitle = 1;
            int longestFirstName = 1;
            int longestLastName = 1;
            int longestAssignmentTitle = 1;
            int differenceAtCourseTitleLength;
            int differenceAtFirstNameLength;
            int differenceAtLastNameLength;
            int differenceAtAssignmentTitleLength;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("\tList of assignments per course per student");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            for (int i = 0; i < assignmentsPerCoursePerStudents.Count; i++) //Find the longest title of course
            {
                if (assignmentsPerCoursePerStudents[i].courseTitle.Length > longestCourseTitle)
                {
                    longestCourseTitle = assignmentsPerCoursePerStudents[i].courseTitle.Length;
                }

                if (assignmentsPerCoursePerStudents[i].firstName.Length > longestFirstName) //Find the longest first name 
                {
                    longestFirstName = assignmentsPerCoursePerStudents[i].firstName.Length;
                }

                if (assignmentsPerCoursePerStudents[i].lastName.Length > longestLastName) //Find the longest last name 
                {
                    longestLastName = assignmentsPerCoursePerStudents[i].lastName.Length;
                }

                if (assignmentsPerCoursePerStudents[i].assignmentTitle.Length > longestAssignmentTitle) //Find the longest assignment title name 
                {
                    longestAssignmentTitle = assignmentsPerCoursePerStudents[i].assignmentTitle.Length;
                }
            }

            //Headings
            Console.ForegroundColor = ConsoleColor.Yellow;
            if ((longestCourseTitle - "Course title".Length) > 0) //Output Headings
            {
                Console.Write("\t" + "      " + "Course title" + new string(' ', longestCourseTitle - "Course title".Length) + "  ");
            }
            else
            {
                Console.Write("\t" + "      " + "Course title" + "  ");
            }

            if ((longestFirstName - "First name".Length) > 0) //Output Headings
            {
                Console.Write("First name" + new string(' ', longestFirstName - "First name".Length) + "  ");
            }
            else
            {
                Console.Write("First name" + "  ");
            }

            if ((longestLastName - "Last name".Length) > 0) //Output Headings
            {
                Console.Write("Last name" + new string(' ', longestLastName - "Last name".Length) + "  ");
            }
            else
            {
                Console.Write("Last name" + "  ");
            }

            if ((longestAssignmentTitle - "Assignment title".Length) > 0) //Output Headings
            {
                Console.WriteLine("Assignment title" + new string(' ', longestAssignmentTitle - "Assignment title".Length) + "  " + "Description");
            }
            else
            {
                Console.WriteLine("Assignment title" + "  " + "Description");
            }
            Console.ForegroundColor = ConsoleColor.White;

            //Output all fields alligned
            foreach (var item in assignmentsPerCoursePerStudents)
            {
                if (counter > 9) //Counter
                {
                    Console.Write("\t" + (counter) + ".   ");
                }
                else if (counter > 99)
                {
                    Console.Write("\t" + (counter) + ".  ");
                }
                else
                {
                    Console.Write("\t" + (counter) + ".    ");
                }

                differenceAtCourseTitleLength = longestCourseTitle - item.courseTitle.Length;
                if (differenceAtCourseTitleLength > 0 && ((longestCourseTitle - "Course title".Length) >= 0)) //Title
                {
                    Console.Write(item.courseTitle + new string(' ', differenceAtCourseTitleLength) + "  ");
                }
                else if ((longestCourseTitle - "Course title".Length) < 0)
                {
                    Console.Write(item.courseTitle + new string(' ', differenceAtCourseTitleLength + ("Course title".Length - longestCourseTitle)) + "  ");
                }
                else
                {
                    Console.Write(item.courseTitle + "  ");
                }

                differenceAtFirstNameLength = longestFirstName - item.firstName.Length;
                if (differenceAtFirstNameLength > 0 && ((longestFirstName - "First name".Length) >= 0)) //First Name 
                {
                    Console.Write(item.firstName + new string(' ', differenceAtFirstNameLength) + "  ");
                }
                else if ((longestFirstName - "First name".Length) < 0)
                {
                    Console.Write(item.firstName + new string(' ', differenceAtFirstNameLength + ("First name".Length - longestFirstName)) + "  ");
                }
                else
                {
                    Console.Write(item.firstName + "  ");
                }

                differenceAtLastNameLength = longestLastName - item.lastName.Length;
                if (differenceAtLastNameLength > 0 && ((longestLastName - "Last name".Length) >= 0)) //Last Name 
                {
                    Console.Write(item.lastName + new string(' ', differenceAtLastNameLength) + "  ");
                }
                else if ((longestLastName - "Last name".Length) < 0)
                {
                    Console.Write(item.lastName + new string(' ', differenceAtLastNameLength + ("Last name".Length - longestLastName)) + "  ");
                }
                else
                {
                    Console.Write(item.lastName + "  ");
                }

                differenceAtAssignmentTitleLength = longestAssignmentTitle - item.assignmentTitle.Length;
                if (differenceAtAssignmentTitleLength > 0 && ((longestAssignmentTitle - "Assignment title".Length) >= 0)) //Assignment title
                {
                    Console.WriteLine(item.assignmentTitle + new string(' ', differenceAtAssignmentTitleLength) + "  " + item.assignmentDescription);
                }
                else if ((longestAssignmentTitle - "Assignment title".Length) < 0)
                {
                    Console.WriteLine(item.assignmentTitle + new string(' ', differenceAtAssignmentTitleLength + ("Assignment title".Length - longestAssignmentTitle)) + "  " + item.assignmentDescription);
                }
                else
                {
                    Console.WriteLine(item.assignmentTitle + "  " + item.assignmentDescription);
                }
                counter++;
            }
        }

    }
}
