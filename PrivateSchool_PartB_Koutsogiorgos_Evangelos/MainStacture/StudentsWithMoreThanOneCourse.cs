using System;
using System.Collections.Generic;


namespace MainStacture
{
    public class StudentsWithMoreThanOneCourse
    {
        //Fields==============================================================================================================
        private string firstName;
        private string lastName;
        private int numberOfCourses;

        //Constructors===================================================================================================================
        public StudentsWithMoreThanOneCourse() { }

        public StudentsWithMoreThanOneCourse(string firstName, string lastName, int numberOfCourses)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.numberOfCourses = numberOfCourses;
        }

        //Methods==============================================================================================================
        public void ListOfStudentsOutput(List<StudentsWithMoreThanOneCourse> studentsWithMoreThanOneCourse)
        {
            int counter = 1;
            int longestFirstName = 1;
            int longestLastName = 1;
            int differenceAtFirstNameLength;
            int differenceAtLastNameLength;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("\tList of students with more than one course");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            for (int i = 0; i < studentsWithMoreThanOneCourse.Count; i++) //Find the longest first name of list students
            {
                if (studentsWithMoreThanOneCourse[i].firstName.Length > longestFirstName)
                {
                    longestFirstName = studentsWithMoreThanOneCourse[i].firstName.Length;
                }

                if (studentsWithMoreThanOneCourse[i].lastName.Length > longestLastName) //Find the longest last name of list students
                {
                    longestLastName = studentsWithMoreThanOneCourse[i].lastName.Length;
                }
            }

            //Headings
            Console.ForegroundColor = ConsoleColor.Yellow;
            if ((longestFirstName - "First name".Length) > 0) //Output Headings
            {
                Console.Write("\t" + "      " + "First name" + new string(' ', longestFirstName - "First name".Length) + "  ");
            }
            else
            {
                Console.Write("\t" + "      " + "First name" + "  ");
            }

            if ((longestLastName - "Last name".Length) > 0) //Output Headings
            {
                Console.WriteLine("Last name" + new string(' ', longestLastName - "Last name".Length) + "  " + "Number of courses");
            }
            else
            {
                Console.WriteLine("Last name" + "  " + "Number of courses");
            }
            Console.ForegroundColor = ConsoleColor.White;

            //Output all fields alligned
            foreach (var item in studentsWithMoreThanOneCourse)
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
                if (differenceAtLastNameLength > 0 && ((longestLastName - "Last name".Length) > 0)) //Last Name and the other fields
                {
                    Console.WriteLine(item.lastName + new string(' ', differenceAtLastNameLength) + "  " + item.numberOfCourses);
                }
                else if ((longestLastName - "Last name".Length) < 0)
                {
                    Console.WriteLine(item.lastName + new string(' ', differenceAtLastNameLength + ("Last name".Length - longestLastName)) + "  " + item.numberOfCourses);
                }
                else
                {
                    Console.WriteLine(item.lastName + "  " + item.numberOfCourses);
                }
                counter++;
            }
        }
    }
}
