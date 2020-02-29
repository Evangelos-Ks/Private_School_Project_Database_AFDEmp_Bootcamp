using MainStacture;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceInsert
    {
        public static string conString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        public void InsertStudent()
        {
            string firstName;
            string lastName;
            DateTime dateOfBirth;
            decimal tuitionFees = 1;
            string addAnotherStudent = "";
            bool notSucceededTheConvert = true; //Convert from string to decimal
            DateTime FalseDate = new DateTime(0001, 1, 1); //Compere for wrong input date 


            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("\tNew student");
                Console.ForegroundColor = ConsoleColor.White;


                //Input fields-------------------------------------------------------------------------------------
                Console.WriteLine();
                Console.Write("\tFirst name : ");
                firstName = Console.ReadLine();

                Console.Write("\tLast name : ");
                lastName = Console.ReadLine();

                do
                {
                    Console.Write("\tDate of birth YYYY/MM/DD : ");
                    dateOfBirth = MyStaticClass.InputDate();
                } while (dateOfBirth == FalseDate);

                do
                {
                    Console.Write("\tTuition fees : ");

                    try
                    {
                        tuitionFees = Convert.ToDecimal(Console.ReadLine().Replace(".", ","));
                        notSucceededTheConvert = false;
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tPlease give a right form of fees.");
                        Console.ForegroundColor = ConsoleColor.White;
                        notSucceededTheConvert = true;
                    }

                } while (notSucceededTheConvert);


                //Connect with database
                string qr = "insert into Student (firstName, lastName, dateOfBirth, tuitionFees) values (@firstName, @lastName, @dateOfBirth, @tuitionFees)";

                using (SqlConnection con = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand(qr, con);

                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                    cmd.Parameters.AddWithValue("@tuitionFees", tuitionFees);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine();
                        Console.WriteLine("\tRecords Inserted Successfully");
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("Error Generated. Details: " + e.ToString());
                    }

                }


                //Ask to continue--------------------------------------------------------------------------------------
                do
                {
                    Console.WriteLine();
                    Console.Write("\tWould you like to add another student? Y/N : ");
                    addAnotherStudent = Console.ReadLine();
                } while (addAnotherStudent.ToUpper() != "Y" && addAnotherStudent.ToUpper() != "N");

            } while (addAnotherStudent.ToUpper() != "N");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t=================================================================================\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void InsertTrainer()
        {
            string firstName;
            string lastName;
            string subject;
            string addAnotherTrainer = "";

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("\tNew trainer");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;

                //Input fields
                Console.WriteLine();
                Console.Write("\tFirst Name : ");
                firstName = Console.ReadLine();

                Console.Write("\tLast Name : ");
                lastName = Console.ReadLine();

                Console.Write("\tSubject : ");
                subject = Console.ReadLine();

                //Connect with database
                string qr = "insert into Trainer (firstName, lastName, subject) values(@firstName, @lastName, @subject)";

                using (SqlConnection con = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand(qr, con);

                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@subject", subject);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine();
                        Console.WriteLine("\tRecords Inserted Successfully");
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("Error Generated. Details: " + e.ToString());
                    }
                }

                //Ask to continue
                do
                {
                    Console.WriteLine();
                    Console.Write("\tWould you like to add another course? Y/N : ");
                    addAnotherTrainer = Console.ReadLine();
                } while (addAnotherTrainer.ToUpper() != "Y" && addAnotherTrainer.ToUpper() != "N");

            } while (addAnotherTrainer.ToUpper() != "N");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t=================================================================================\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void InsertAssignment()
        {
            string title;
            string description;
            DateTime subDateTime;
            string addAnotherAssignment = "";
            DateTime FalseDate = new DateTime(0001, 1, 1); //Compere for wrong input date 

            do
            {
                Assignment assignment = new Assignment();
                bool isSubmitInWeekentd;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("\tNew assignment");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;

                //Input fields
                Console.WriteLine();
                Console.Write("\tTitle : ");
                title = Console.ReadLine();

                Console.Write("\tDescription : ");
                description = Console.ReadLine();


                do
                {
                    Console.Write("\tSubmission date YYYY/MM/DD : ");
                    subDateTime = MyStaticClass.InputDate();
                    if (Convert.ToDateTime(subDateTime).DayOfWeek == DayOfWeek.Saturday || Convert.ToDateTime(subDateTime).DayOfWeek == DayOfWeek.Sunday)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tSubmissions cannot be submitted at the weekend. Enter an appropriate date.");
                        Console.ForegroundColor = ConsoleColor.White;
                        isSubmitInWeekentd = true;
                    }
                    else
                    {
                        isSubmitInWeekentd = false;
                    }
                } while (subDateTime == FalseDate || isSubmitInWeekentd);



                //Connect with database
                string qr = "insert into Assignment (title, description, subDateTime) values(@title, @description, @subDateTime)";

                using (SqlConnection con = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand(qr, con);

                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@subDateTime", subDateTime);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine();
                        Console.WriteLine("\tRecords Inserted Successfully");
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("Error Generated. Details: " + e.ToString());
                    }
                }

                //Ask to continue
                do
                {
                    Console.WriteLine();
                    Console.Write("\tWould you like to add another assignment? Y/N : ");
                    addAnotherAssignment = Console.ReadLine();
                } while (addAnotherAssignment.ToUpper() != "Y" && addAnotherAssignment.ToUpper() != "N");

            } while (addAnotherAssignment.ToUpper() != "N");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t=================================================================================\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void InsertNewAssignmentAtCourse(int cid)
        {
            string title;
            string description;
            DateTime subDateTime;
            string addAnotherAssignment = "";
            DateTime FalseDate = new DateTime(0001, 1, 1); //Compere for wrong input date 

            do
            {
                Assignment assignment = new Assignment();
                bool isSubmitInWeekentd;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("\tNew assignment");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;

                //Input fields
                Console.WriteLine();
                Console.Write("\tTitle : ");
                title = Console.ReadLine();

                Console.Write("\tDescription : ");
                description = Console.ReadLine();


                do
                {
                    Console.Write("\tSubmission date YYYY/MM/DD : ");
                    subDateTime = MyStaticClass.InputDate();
                    if (Convert.ToDateTime(subDateTime).DayOfWeek == DayOfWeek.Saturday || Convert.ToDateTime(subDateTime).DayOfWeek == DayOfWeek.Sunday)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tSubmissions cannot be submitted at the weekend. Enter an appropriate date.");
                        Console.ForegroundColor = ConsoleColor.White;
                        isSubmitInWeekentd = true;
                    }
                    else
                    {
                        isSubmitInWeekentd = false;
                    }
                } while (subDateTime == FalseDate || isSubmitInWeekentd);



                //Connect with database
                string qr = "insert into Assignment (title, description, subDateTime, Cid) values(@title, @description, @subDateTime, @Cid)";

                using (SqlConnection con = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand(qr, con);

                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@subDateTime", subDateTime);
                    cmd.Parameters.AddWithValue("@Cid", cid);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine();
                        Console.WriteLine("\tRecords Inserted Successfully");
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("Error Generated. Details: " + e.ToString());
                    }
                }

                //Ask to continue
                do
                {
                    Console.WriteLine();
                    Console.Write("\tWould you like to add another assignment in this course? Y/N : ");
                    addAnotherAssignment = Console.ReadLine();
                } while (addAnotherAssignment.ToUpper() != "Y" && addAnotherAssignment.ToUpper() != "N");

            } while (addAnotherAssignment.ToUpper() != "N");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t=================================================================================\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void InsertAssignmentAtCourse(int aid, int cid)
        {
            ServiceGet serviceGet = new ServiceGet();
            List<Assignment> assignments;
            List<Assignment> assignment;


            assignments = serviceGet.GetAllAssignments();
            assignment = assignments.Where(x => (int)x.Aid == aid).ToList();
          
            string qr = "insert into Assignment (title, description, subDateTime, Cid) values(@title, @description, @subDateTime, @Cid)";
           
                using (SqlConnection con = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand(qr, con);

                    cmd.Parameters.AddWithValue("@title", assignment[0].getTitle());
                    cmd.Parameters.AddWithValue("@description", assignment[0].getDescription());
                    cmd.Parameters.AddWithValue("@subDateTime", assignment[0].getSubDateTime());
                    cmd.Parameters.AddWithValue("@Cid", cid);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine();
                        Console.WriteLine("\tRecords Inserted Successfully");
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("Error Generated. Details: " + e.ToString());
                    }
                }
        }

        public void InsertCourse()
        {
            string title;
            string stream;
            string type;
            DateTime startDate;
            DateTime endDate;
            string addAnotherCourse = "";
            DateTime FalseDate = new DateTime(0001, 1, 1); //Compere for wrong input date 

            do
            {

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("\tNew course");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;

                //Input fields
                Console.WriteLine();
                Console.Write("\tTitle : ");
                title = Console.ReadLine();

                Console.Write("\tStream : ");
                stream = Console.ReadLine();

                Console.Write("\tType : ");
                type = Console.ReadLine();

                do
                {
                    Console.Write("\tStart date YYYY/MM/DD : ");
                    startDate = MyStaticClass.InputDate();
                } while (startDate == FalseDate);

                do
                {
                    Console.Write("\tEnd date YYYY/MM/DD : ");
                    endDate = MyStaticClass.InputDate();

                    if (startDate > endDate && endDate != FalseDate)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tEnd date can't be before than start date.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                } while (endDate == FalseDate || startDate > endDate);

                //Connect with database
                string qr = "insert into Course (title, stream, type, startDate, endDate) values(@title, @stream, @type, @startDate, @endDate)";

                using (SqlConnection con = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand(qr, con);

                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@stream", stream);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine();
                        Console.WriteLine("\tRecords Inserted Successfully");
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("Error Generated. Details: " + e.ToString());
                    }
                }

                //Ask to continue
                do
                {
                    Console.WriteLine();
                    Console.Write("\tWould you like to add another course? Y/N : ");
                    addAnotherCourse = Console.ReadLine();
                } while (addAnotherCourse.ToUpper() != "Y" && addAnotherCourse.ToUpper() != "N");

            } while (addAnotherCourse.ToUpper() != "N");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t=================================================================================\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void InsertStudentAtCourse(int Sid, int Cid)
        {
            //Connect with database
            string qr = "insert into StudentCourse (Sid,Cid) values(@Sid, @Cid)";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(qr, con);

                cmd.Parameters.AddWithValue("@Sid", Sid);
                cmd.Parameters.AddWithValue("@Cid", Cid);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine();
                    Console.WriteLine("\tRecords Inserted Successfully");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
            }
        }

        public void InsertTrainerAtCourse(int tid, int cid)
        {
            string qr = "insert into TrainerCourse (Tid,Cid) values(@Tid, @Cid)";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(qr, con);

                cmd.Parameters.AddWithValue("@Tid", tid);
                cmd.Parameters.AddWithValue("@Cid", cid);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine();
                    Console.WriteLine("\tRecords Inserted Successfully");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
            }
        }

        public void InsertAssignmentsPerCoursePerStudent(int cid, int sid, int aid)
        {
            ServiceGet serviceGet = new ServiceGet();
            List<Assignment> assignment = serviceGet.GetAllAssignments().Where(x => x.Cid == cid).ToList();

            if (cid == assignment[0].Cid)
            {
                //InsertAssignmentAtStudent(5,3);
            }
        }

        public void InsertAssignmentAtStudent(int aid, int sid)
        {
            ServiceGet serviceGet = new ServiceGet();
            //List<Assignment> assignments;
            List<Assignment> assignment;


            assignment = serviceGet.GetAllAssignments().Where(x => x.Aid == aid).ToList();

            string qr = "insert into StudentAssignment (Sid, Aid) values(@Sid, @dAid)";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(qr, con);

                cmd.Parameters.AddWithValue("@Sid", sid);
                cmd.Parameters.AddWithValue("@dAid", aid);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine();
                    Console.WriteLine("\tRecords Inserted Successfully");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
            }
        }
    }
}
