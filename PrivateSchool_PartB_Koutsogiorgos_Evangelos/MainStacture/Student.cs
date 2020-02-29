using System;
using System.Collections.Generic;


namespace MainStacture
{
    public class Student
    {
        //Fields==============================================================================================================
        private string firstName;
        private string lastName;
        private DateTime? dateOfBirth;
        private decimal? tuitionFees;

        public List<Student> students = new List<Student>();
        public List<Course> courses = new List<Course>();
        public List<Assignment> assignments = new List<Assignment>();

        //Properties===============================================================================================================
        public int? Sid { get; }

        //Constructors===================================================================================================================
        public Student() { }

        public Student(int? Sid, string firstName, string lastName, DateTime? dateOfBirth, decimal? tuitionFees)
        {
            this.Sid = Sid;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.tuitionFees = tuitionFees;
        }

        //Getters & setters==============================================================================================================
        public string getFirstName() { return firstName; }

        public string getLastName() { return lastName; }

        //Methods=========================================================================================================================

        //Output a List of students-------------------------------------------------------------------------------------
        public void ListOfStudentsOutput(List<Student> students)
        {
            int counter = 1;
            int longestFirstName = 1;
            int longestLastName = 1;
            int differenceAtFirstNameLength;
            int differenceAtLastNameLength;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("\tList of students");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            for (int i = 0; i < students.Count; i++) //Find the longest first name of list students
            {
                if (students[i].firstName.Length > longestFirstName)
                {
                    longestFirstName = students[i].firstName.Length;
                }

                if (students[i].lastName.Length > longestLastName) //Find the longest first last of list students
                {
                    longestLastName = students[i].lastName.Length;
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
                Console.WriteLine("Last name" + new string(' ', longestLastName - "Last name".Length) + "  " + "Date of Birth" + "  " + "Fees");
            }
            else
            {
                Console.WriteLine("Last name" + "  " + "Date of Birth" + "  " + "Fees");
            }
            Console.ForegroundColor = ConsoleColor.White;

            //Output all fields alligned
            foreach (var item in students)
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
                if (differenceAtLastNameLength > 0 && ((longestLastName - "Last name".Length) >= 0)) //Last Name and the other fields
                {
                    Console.WriteLine(item.lastName + new string(' ', differenceAtLastNameLength) + "  " + Convert.ToDateTime(item.dateOfBirth).ToString("dd/MM/yyyy") + "     " + item.tuitionFees);
                }
                else if ((longestLastName - "Last name".Length) < 0)
                {
                    Console.WriteLine(item.lastName + new string(' ', differenceAtLastNameLength + ("Last name".Length - longestLastName)) + "  " + Convert.ToDateTime(item.dateOfBirth).ToString("dd/MM/yyyy") + "     " + item.tuitionFees);
                }
                else
                {
                    Console.WriteLine(item.lastName + "  " + Convert.ToDateTime(item.dateOfBirth).ToString("dd/MM/yyyy") + "     " + item.tuitionFees);
                }
                counter++;
            }
        }
    }
}
