using System;
using System.Collections.Generic;


namespace MainStacture
{
    public class AssignmentsPerCourse
    {
        private string courseTitle;
        private string assignmentTitle;
        private string description;
        Course course;
        int userSelectAssignment;
        string addAnotherAssignmentfromList;

        public AssignmentsPerCourse() { }
        public AssignmentsPerCourse(string courseTitle, string assignmentTitle, string description)
        {
            this.courseTitle = courseTitle;
            this.assignmentTitle = assignmentTitle;
            this.description = description;
        }

        public void OutputAssignmetsPerCourse(List<AssignmentsPerCourse> assignmentsPerCourse)
        {
            int counter = 1;
            int longestCourseTitle = 1;
            int longestAssignmentTitle = 1;
            int differenceAtCourseTitleLength;
            int differenceAtAssignmentTitleLength;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("\tList of assignments per course");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            for (int i = 0; i < assignmentsPerCourse.Count; i++) //Find the longest title name of list students
            {
                if (assignmentsPerCourse[i].courseTitle.Length > longestCourseTitle)
                {
                    longestCourseTitle = assignmentsPerCourse[i].courseTitle.Length;
                }

                if (assignmentsPerCourse[i].assignmentTitle.Length > longestAssignmentTitle) //Find the longest assignment title of list students
                {
                    longestAssignmentTitle = assignmentsPerCourse[i].assignmentTitle.Length;
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
            foreach (var item in assignmentsPerCourse)
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
                if (differenceAtCourseTitleLength > 0 && ((longestCourseTitle - "Course title".Length) >= 0)) //Course
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

                differenceAtAssignmentTitleLength = longestAssignmentTitle - item.assignmentTitle.Length;
                if (differenceAtAssignmentTitleLength > 0 && ((longestAssignmentTitle - "Assignment title".Length) >= 0)) //Assignment title and the other fields
                {
                    Console.WriteLine(item.assignmentTitle + new string(' ', differenceAtAssignmentTitleLength) + "  " + item.description);
                }
                else if ((longestAssignmentTitle - "Assignment title".Length) < 0)
                {
                    Console.WriteLine(item.assignmentTitle + new string(' ', differenceAtAssignmentTitleLength + ("Assignment title".Length - longestAssignmentTitle)) + "  " + item.description);
                }
                else
                {
                    Console.WriteLine(item.assignmentTitle + "  " + item.description);
                }
                counter++;
            }
        }
    }
}
