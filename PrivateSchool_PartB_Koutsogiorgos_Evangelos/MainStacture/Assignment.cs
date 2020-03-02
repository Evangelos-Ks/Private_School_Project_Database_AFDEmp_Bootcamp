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
    }
}

