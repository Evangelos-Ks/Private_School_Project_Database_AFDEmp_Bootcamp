using System;
using System.Collections.Generic;

namespace MainStacture
{
    public class Course
    {
        //Fields==============================================================================================================
        private string title;
        private string stream;
        private string type;
        private DateTime? startDate;
        private DateTime? endDate;

        public List<Course> courses = new List<Course>();
        public List<Student> students = new List<Student>();
        public List<Trainer> trainers = new List<Trainer>();
        public List<Assignment> assignments = new List<Assignment>();

        //Properties===============================================================================================================
        public int? Cid { get; }

        //Constuctors====================================================================================================================
        public Course() { }

        public Course(int? Cid, string title, string stream, string type, DateTime? startDate, DateTime? endDate)
        {
            this.Cid = Cid;
            this.title = title;
            this.stream = stream;
            this.type = type;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        //Methods==============================================================================================================

        //Output a List of courses-------------------------------------------------------------------------------------
        public void ListOfCoursecOutput(List<Course> courses)
        {
            int counter = 1;
            int longestTitle = 1;
            int longestStream = 1;
            int longestType = 1;
            int differenceAtTitleLength;
            int differenceAtStreamLength;
            int differenceAtTypeLength;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("\tList of courses");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            for (int i = 0; i < courses.Count; i++) //Find the longest title of list courses
            {
                if (courses[i].title.Length > longestTitle)
                {
                    longestTitle = courses[i].title.Length;
                }

                if (courses[i].stream.Length > longestStream) //Find the longest stream of list courses
                {
                    longestStream = courses[i].stream.Length;
                }

                if (courses[i].type.Length > longestType) //Find the longest type of list courses
                {
                    longestType = courses[i].type.Length;
                }
            }

            //Headings
            Console.ForegroundColor = ConsoleColor.Yellow;
            if ((longestTitle - "Title".Length) > 0) //Output Heading of Title
            {
                Console.Write("\t" + "      " + "Title" + new string(' ', longestTitle - "Title".Length) + "  ");
            }
            else
            {
                Console.Write("\t" + "      " + "Title" + "  ");
            }

            if ((longestStream - "stream".Length) > 0) //Output Heading of stream
            {
                Console.Write("stream" + new string(' ', longestStream - "stream".Length) + "  ");
            }
            else
            {
                Console.Write("stream" + "  ");
            }

            if ((longestType - "type".Length) > 0) //Output Heading of type and others hedings
            {
                Console.WriteLine("Type" + new string(' ', longestType - "type".Length) + "  " + "Start date" + "   " + "End date");
            }
            else
            {
                Console.WriteLine("Type" + "  " + "Start date" + "   " + "End date");
            }
            Console.ForegroundColor = ConsoleColor.White;

            //Output all fields alligned
            foreach (var item in courses)
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
                    Console.Write(item.title + new string(' ', (differenceAtTitleLength + ("Title".Length - longestTitle))) + "  ");
                }
                else
                {
                    Console.Write(item.title + "  ");
                }

                differenceAtStreamLength = longestStream - item.stream.Length;
                if (differenceAtStreamLength > 0 && ((longestStream - "Stream".Length) >= 0)) //Stream
                {
                    Console.Write(item.stream + new string(' ', differenceAtStreamLength) + "  ");
                }
                else if ((longestStream - "Stream".Length) < 0)
                {
                    Console.Write(item.stream + new string(' ', (differenceAtStreamLength + ("Stream".Length - longestStream))) + "  ");
                }
                else
                {
                    Console.Write(item.stream + "  ");
                }

                differenceAtTypeLength = longestType - item.type.Length;
                if (differenceAtTypeLength > 0 && ((longestType - "Type".Length) >= 0)) //type and the other fields
                {
                    Console.WriteLine(item.type + new string(' ', differenceAtTypeLength) + "  " + Convert.ToDateTime(item.startDate).ToString("dd/MM/yyyy") + "   " + Convert.ToDateTime(item.endDate).ToString("dd/MM/yyyy"));
                }
                else if ((longestType - "Type".Length) < 0)
                {
                    Console.WriteLine(item.type + new string(' ', (differenceAtTypeLength + ("Type".Length - longestType))) + "  " + Convert.ToDateTime(item.startDate).ToString("dd/MM/yyyy") + "   " + Convert.ToDateTime(item.endDate).ToString("dd/MM/yyyy"));
                }
                else
                {
                    Console.WriteLine(item.type + "  " + Convert.ToDateTime(item.startDate).ToString("dd/MM/yyyy") + "   " + Convert.ToDateTime(item.endDate).ToString("dd/MM/yyyy"));
                }
                counter++;
            }
        }
    }
}