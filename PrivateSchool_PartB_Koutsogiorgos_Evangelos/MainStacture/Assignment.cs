using System;
using System.Collections.Generic;


namespace MainStacture
{
    public class Assignment
    {
        //Fields==============================================================================================================
        private string title;
        private string description;
        private DateTime? subDateTime;
        private decimal? oralMark;
        private decimal? totalMark;

        public List<Assignment> assignments = new List<Assignment>();
        public List<Course> courses = new List<Course>();
        public List<Student> students = new List<Student>();

        //Properties===============================================================================================================
        public int? Aid { get; }
        public int? Cid { get; set; }

        //Constructors====================================================================================================================
        public Assignment() { }

        public Assignment(int? Aid, string title, string description, DateTime? subDateTime, decimal? oralMark, decimal? totalMark, int? cid)
        {
            this.Aid = Aid;
            this.title = title;
            this.description = description;
            this.subDateTime = subDateTime;
            this.oralMark = oralMark;
            this.totalMark = totalMark;
            this.Cid = cid;
        }



        //Getters & setters==============================================================================================================
        public string getTitle() { return title; }

        public string getDescription() { return description; }

        public DateTime? getSubDateTime() { return subDateTime; }

        //Methods==============================================================================================================

        //Output a List of assignments-------------------------------------------------------------------------------------
        public void ListOfAssignmentsOutput(List<Assignment> assignments)
        {
            int counter = 1;
            int longestTitle = 1;
            int longestDescription = 1;
            int differenceAtTitleLength;
            int differenceAtDescriptionLength;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("\tList of assignments");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            for (int i = 0; i < assignments.Count; i++) //Find the longest title of list assignments
            {
                if (assignments[i].title.Length > longestTitle)
                {
                    longestTitle = assignments[i].title.Length;
                }

                if (assignments[i].description.Length > longestDescription) //Find the longest description of list assignments
                {
                    longestDescription = assignments[i].description.Length;
                }
            }

            //Headings
            Console.ForegroundColor = ConsoleColor.Yellow;
            if ((longestTitle - "Title".Length) > 0) //Output Headings
            {
                Console.Write("\t" + "      " + "Title" + new string(' ', longestTitle - "Title".Length) + "  ");
            }
            else
            {
                Console.Write("\t" + "      " + "Title" + "  ");
            }

            if ((longestDescription - "Description".Length) > 0) //Output Headings
            {
                Console.WriteLine("Description" + new string(' ', longestDescription - "Description".Length) + "  " + "Submission date" + "   " + "Oral mark" + "   " + "Total mark");
            }
            else
            {
                Console.WriteLine("Description" + "  " + "Submission date" + "   " + "Oral mark" + "   " + "Total mark");
            }
            Console.ForegroundColor = ConsoleColor.White;

            //Output all fields alligned
            foreach (var item in assignments)
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

                differenceAtTitleLength = longestTitle - item.title.Length;
                if (differenceAtTitleLength > 0 && ((longestTitle - "Title".Length) >= 0)) //Title
                {
                    Console.Write(item.title + new string(' ', differenceAtTitleLength) + "  ");
                }
                else if ((longestTitle - "Title".Length) < 0)
                {
                    Console.Write(item.title + new string(' ', differenceAtTitleLength + ("Title".Length - longestTitle)) + "  ");
                }
                else
                {
                    Console.Write(item.title + "  ");
                }

                differenceAtDescriptionLength = longestDescription - item.description.Length;
                if (differenceAtDescriptionLength > 0 && ((longestDescription - "Description".Length) >= 0)) //Description and the other fields
                {
                    Console.WriteLine(item.description + new string(' ', differenceAtDescriptionLength) + "  " + Convert.ToDateTime(item.subDateTime).ToString("dd/MM/yyyy") + new string(' ', 8) + item.oralMark + new string(' ', 12 - item.oralMark.ToString().Length) + item.totalMark);
                }
                else if ((longestDescription - "Description".Length) < 0)
                {
                    Console.WriteLine(item.description + new string(' ', differenceAtDescriptionLength + ("Description".Length - longestDescription)) + "  " + Convert.ToDateTime(item.subDateTime).ToString("dd/MM/yyyy") + new string(' ', 8) + item.oralMark + new string(' ', 12 - item.oralMark.ToString().Length) + item.totalMark);
                }
                else
                {
                    Console.WriteLine(item.description + "  " + Convert.ToDateTime(item.subDateTime).ToString("dd/MM/yyyy") + new string(' ', 8) + item.oralMark + new string(' ', 12 - item.oralMark.ToString().Length) + item.totalMark);
                }
                counter++;
            }
        }

        public void ListOfAssignmentsWithoutMarkOutput(List<Assignment> assignments)
        {
            int counter = 1;
            int longestTitle = 1;
            int longestDescription = 1;
            int differenceAtTitleLength;
            int differenceAtDescriptionLength;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("\tList of assignments");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            for (int i = 0; i < assignments.Count; i++) //Find the longest title of list assignments
            {
                if (assignments[i].title.Length > longestTitle)
                {
                    longestTitle = assignments[i].title.Length;
                }

                if (assignments[i].description.Length > longestDescription) //Find the longest description of list assignments
                {
                    longestDescription = assignments[i].description.Length;
                }
            }

            //Headings
            Console.ForegroundColor = ConsoleColor.Yellow;
            if ((longestTitle - "Title".Length) > 0) //Output Headings
            {
                Console.Write("\t" + "      " + "Title" + new string(' ', longestTitle - "Title".Length) + "  ");
            }
            else
            {
                Console.Write("\t" + "      " + "Title" + "  ");
            }

            if ((longestDescription - "Description".Length) > 0) //Output Headings
            {
                Console.WriteLine("Description" + new string(' ', longestDescription - "Description".Length) + "  " + "Submission date");
            }
            else
            {
                Console.WriteLine("Description" + "  " + "Submission date");
            }
            Console.ForegroundColor = ConsoleColor.White;

            //Output all fields alligned
            foreach (var item in assignments)
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

                differenceAtTitleLength = longestTitle - item.title.Length;
                if (differenceAtTitleLength > 0 && ((longestTitle - "Title".Length) >= 0)) //Title
                {
                    Console.Write(item.title + new string(' ', differenceAtTitleLength) + "  ");
                }
                else if ((longestTitle - "Title".Length) < 0)
                {
                    Console.Write(item.title + new string(' ', differenceAtTitleLength + ("Title".Length - longestTitle)) + "  ");
                }
                else
                {
                    Console.Write(item.title + "  ");
                }

                differenceAtDescriptionLength = longestDescription - item.description.Length;
                if (differenceAtDescriptionLength > 0 && ((longestDescription - "Description".Length) >= 0)) //Description and the other fields
                {
                    Console.WriteLine(item.description + new string(' ', differenceAtDescriptionLength) + "  " + Convert.ToDateTime(item.subDateTime).ToString("dd/MM/yyyy"));
                }
                else if ((longestDescription - "Description".Length) < 0)
                {
                    Console.WriteLine(item.description + new string(' ', differenceAtDescriptionLength + ("Description".Length - longestDescription)) + "  " + Convert.ToDateTime(item.subDateTime).ToString("dd/MM/yyyy"));
                }
                else
                {
                    Console.WriteLine(item.description + "  " + Convert.ToDateTime(item.subDateTime).ToString("dd/MM/yyyy"));
                }
                counter++;
            }
        }        

        //Output students from assingment wich must submit.
        public void StudentsSubmitAssignments(List<Assignment> assignments)
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

            for (int i = 0; i < assignments.Count; i++)
            {
                for (int j = 0; j < assignments[i].students.Count; j++) //Find the longest first name of list students
                {
                    if (assignments[i].students[j].getFirstName().Length > longestFirstName)
                    {
                        longestFirstName = assignments[i].students[j].getFirstName().Length;
                    }

                    if (assignments[i].students[j].getLastName().Length > longestLastName) //Find the longest first last of list students
                    {
                        longestLastName = assignments[i].students[j].getLastName().Length;
                    }
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
                Console.WriteLine("Last name" + new string(' ', longestLastName - "Last name".Length) + "  " + "Submission date" + "   " + "Title");
            }
            else
            {
                Console.WriteLine("Last name" + "  " + "Submission date" + "   " + "Title");
            }
            Console.ForegroundColor = ConsoleColor.White;

            //Output all fields alligned
            foreach (var item in assignments)
            {
                if (item.students.Count > 1)
                {
                    for (int i = 0; i < item.students.Count; i++)
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

                        differenceAtFirstNameLength = longestFirstName - item.students[i].getFirstName().Length;
                        if (differenceAtFirstNameLength > 0 && ((longestFirstName - "First name".Length) >= 0)) //First Name
                        {
                            Console.Write(item.students[i].getFirstName() + new string(' ', differenceAtFirstNameLength) + "  ");
                        }
                        else if ((longestFirstName - "First name".Length) < 0)
                        {
                            Console.Write(item.students[i].getFirstName() + new string(' ', differenceAtFirstNameLength + ("First name".Length - longestFirstName)) + "  ");
                        }
                        else
                        {
                            Console.Write(item.students[i].getFirstName() + "  ");
                        }

                        differenceAtLastNameLength = longestLastName - item.students[i].getLastName().Length;
                        if (differenceAtLastNameLength > 0 && ((longestLastName - "Last name".Length) >= 0)) //Last name and the other fields
                        {
                            Console.WriteLine(item.students[i].getLastName() + new string(' ', differenceAtLastNameLength) + "  " + Convert.ToDateTime(item.subDateTime).ToString("dd/MM/yyyy") + new string(' ', 8) + item.title);
                        }
                        else if ((longestLastName - "Last name".Length) < 0)
                        {
                            Console.WriteLine(item.students[i].getLastName() + new string(' ', differenceAtLastNameLength + ("Last name".Length - longestLastName)) + "  " + Convert.ToDateTime(item.subDateTime).ToString("dd/MM/yyyy") + new string(' ', 8) + item.title);
                        }
                        else
                        {
                            Console.WriteLine(item.students[i].getLastName() + "  " + Convert.ToDateTime(item.subDateTime).ToString("dd/MM/yyyy") + new string(' ', 8) + item.title);
                        }
                        counter++;
                    }
                }
                else
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

                    differenceAtFirstNameLength = longestFirstName - item.title.Length;
                    if (differenceAtFirstNameLength > 0 && ((longestFirstName - "First name".Length) >= 0)) //Title
                    {
                        Console.Write(item.students[0].getFirstName() + new string(' ', differenceAtFirstNameLength) + "  ");
                    }
                    else if ((longestFirstName - "First name".Length) < 0)
                    {
                        Console.Write(item.students[0].getFirstName() + new string(' ', differenceAtFirstNameLength + ("First name".Length - longestFirstName)) + "  ");
                    }
                    else
                    {
                        Console.Write(item.students[0].getFirstName() + "  ");
                    }

                    differenceAtLastNameLength = longestLastName - item.description.Length;
                    if (differenceAtLastNameLength > 0 && ((longestLastName - "Last name".Length) >= 0)) //Description and the other fields
                    {
                        Console.WriteLine(item.students[0].getLastName() + new string(' ', differenceAtLastNameLength) + "  " + Convert.ToDateTime(item.subDateTime).ToString("dd/MM/yyyy") + new string(' ', 8) + item.title);
                    }
                    else if ((longestLastName - "Last name".Length) < 0)
                    {
                        Console.WriteLine(item.students[0].getLastName() + new string(' ', differenceAtLastNameLength + ("Last name".Length - longestLastName)) + "  " + Convert.ToDateTime(item.subDateTime).ToString("dd/MM/yyyy") + new string(' ', 8) + item.title);
                    }
                    else
                    {
                        Console.WriteLine(item.students[0].getLastName() + "  " + Convert.ToDateTime(item.subDateTime).ToString("dd/MM/yyyy") + new string(' ', 8) + item.title);
                    }
                }
                counter++;
            }
        }
    }
}

