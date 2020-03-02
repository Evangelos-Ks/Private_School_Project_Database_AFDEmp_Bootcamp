using System;
using System.Collections.Generic;



namespace MainStacture
{
    public class TrainersPerCourse
    {
        private string courseTitle;
        private string firstName;
        private string lastName;


        public TrainersPerCourse() { }
        public TrainersPerCourse(string courseTitle, string firstName, string lastName)
        {
            this.courseTitle = courseTitle;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public void ListOfTrainersPerCourseOutput(List<TrainersPerCourse> trainersPerCourse)
        {
            int counter = 1;
            int longestCourseTitle = 1;
            int longestFirstName = 1;
            int differenceAtCourseTitleLength;
            int differenceAtFirstNameLength;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("\tList of trainers");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            for (int i = 0; i < trainersPerCourse.Count; i++) //Find the longest title name of list students
            {
                if (trainersPerCourse[i].courseTitle.Length > longestCourseTitle)
                {
                    longestCourseTitle = trainersPerCourse[i].courseTitle.Length;
                }

                if (trainersPerCourse[i].firstName.Length > longestFirstName) //Find the longest first name of list students
                {
                    longestFirstName = trainersPerCourse[i].firstName.Length;
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
                Console.WriteLine("First name" + new string(' ', longestFirstName - "First name".Length) + "  " + "Last name");
            }
            else
            {
                Console.WriteLine("First name" + "  " + "Last name");
            }
            Console.ForegroundColor = ConsoleColor.White;

            //Output all fields alligned
            foreach (var item in trainersPerCourse)
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
                if (differenceAtFirstNameLength > 0 && ((longestFirstName - "First name".Length) >= 0)) //First Name and the other fields
                {
                    Console.WriteLine(item.firstName + new string(' ', differenceAtFirstNameLength) + "  " + item.lastName);
                }
                else if ((longestFirstName - "First name".Length) < 0)
                {
                    Console.WriteLine(item.firstName + new string(' ', differenceAtFirstNameLength + ("First name".Length - longestFirstName)) + "  " + item.lastName);
                }
                else
                {
                    Console.WriteLine(item.firstName + "  " + item.lastName);
                }
                counter++;
            }
        }
    }
}
