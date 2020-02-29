using MainStacture;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;


namespace Services
{
    public class ServiceGet
    {
        public static string conString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string queryString = "select * from Student";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(queryString, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Student s = new Student(Sid: Convert.ToInt32(reader[0].ToString()), firstName: reader[1].ToString(), lastName: reader[2].ToString(), dateOfBirth: DateTime.Parse(reader[3].ToString()), tuitionFees: Convert.ToDecimal(reader[4].ToString()));
                        students.Add(s);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong Code: S_S_GAS");
            }
            return students;
        }

        public List<Trainer> GetAllTrainers()
        {
            List<Trainer> trainers = new List<Trainer>();

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string queryString = "select * from Trainer";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(queryString, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Trainer tr = new Trainer(Tid: Convert.ToInt32(reader["Tid"].ToString()), firstName: reader["firstName"].ToString(), lastName: reader["lastName"].ToString(), reader["subject"].ToString());
                        trainers.Add(tr);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong Code: S_S_GAT");
            }
            return trainers;
        }

        public List<Assignment> GetAllAssignments()
        {
            List<Assignment> assignments = new List<Assignment>();

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string queryString = "select * from Assignment";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(queryString, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Assignment a = new Assignment(Aid: Convert.ToInt32(reader["Aid"].ToString()), title: reader["title"].ToString(), description: reader["description"].ToString(), subDateTime: DateTime.Parse(reader["subDateTime"].ToString()), oralMark: null, totalMark: null, cid: Convert.ToInt32(reader["Cid"].ToString()));
                        assignments.Add(a);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong Code: S_S_GAA");
            }
            return assignments;
        }

        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string queryString = "select * from Course";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(queryString, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Course c = new Course(Cid: Convert.ToInt32(reader["Cid"].ToString()), title: reader["title"].ToString(), stream: reader["stream"].ToString(), type: reader["type"].ToString(), startDate: DateTime.Parse(reader["startDate"].ToString()), endDate: DateTime.Parse(reader["endDate"].ToString()));
                        courses.Add(c);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong Code: S_S_GAC");
            }
            return courses;
        }

        public List<StudentsPerCourse> GetStudentsPerCourse()
        {
            List<StudentsPerCourse> studentsPerCourse = new List<StudentsPerCourse>();

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string queryString = "select  Course.title as [Course],  firstName as [First name], lastName as [Last name]  from Student" +
                                         " inner join StudentCourse" +
                                         " on Student.Sid = StudentCourse.Sid" +
                                         " inner join Course" +
                                         " on Course.Cid = StudentCourse.Cid" +
                                         " group by  title, firstName,lastName";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(queryString, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        StudentsPerCourse spc = new StudentsPerCourse(courseTitle: reader[0].ToString(), firstName: reader[1].ToString(), lastName: reader[2].ToString());
                        studentsPerCourse.Add(spc);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong Code: S_S_GSPC");
            }
            return studentsPerCourse;
        }

        public List<TrainersPerCourse> GetTrainersPerCourse()
        {
            List<TrainersPerCourse> trainersPerCourse = new List<TrainersPerCourse>();

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string queryString = "select Course.title as [Course], firstName as [First name], lastName as [Last name] from Trainer " +
                                         "inner join TrainerCourse " +
                                         "on Trainer.Tid = TrainerCourse.Tid " +
                                         "inner join Course on Course.Cid = TrainerCourse.Cid " +
                                         "group by title, firstName, lastName";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(queryString, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TrainersPerCourse tpc = new TrainersPerCourse(courseTitle: reader[0].ToString(), firstName: reader[1].ToString(), lastName: reader[2].ToString());
                        trainersPerCourse.Add(tpc);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong Code: S_S_GTPC");
            }
            return trainersPerCourse;
        }

        public List<AssignmentsPerCourse> GetAssignmetsPerCourse()
        {
            List<AssignmentsPerCourse> assignmentsPerCourse = new List<AssignmentsPerCourse>();

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string queryString = "select Course.Title as Course , Assignment.title as [Assignment title], " +
                                         "description as Description from Assignment, Course where Assignment.Cid = Course.Cid";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(queryString, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        AssignmentsPerCourse apc = new AssignmentsPerCourse(courseTitle: reader[0].ToString(), assignmentTitle: reader[1].ToString(), description: reader[2].ToString());
                        assignmentsPerCourse.Add(apc);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong Code: S_S_GAPC");
            }
            return assignmentsPerCourse;
        }

        public List<AssignmentsPerCoursePerStudent> GetAssignmentsPerCoursePerStudents()
        {
            List<AssignmentsPerCoursePerStudent> assignmentsPerCoursePerStudent = new List<AssignmentsPerCoursePerStudent>();

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string queryString = "select Course.title as Course, Student.firstName as [First name], Student.lastName as [Last name], " +
                                         "Assignment.title as [Assignment title], Assignment.description as Description " +
                                         "from Course, Student, Assignment, StudentCourse, StudentAssignment where Course.Cid = Assignment.Cid " +
                                         "and Course.Cid = StudentCourse.Cid and Student.Sid = StudentCourse.Sid and Student.Sid = StudentAssignment.Sid and Assignment.Aid = StudentAssignment.Aid group by " +
                                         "Course.title, Student.firstName, Student.lastName , Assignment.title, Assignment.description; ";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(queryString, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        AssignmentsPerCoursePerStudent apcps = new AssignmentsPerCoursePerStudent(courseTitle: reader[0].ToString(), firstName: reader[1].ToString(), lastName: reader[2].ToString(), assignmentTitle: reader[3].ToString(), assignmentDescription: reader[4].ToString());
                        assignmentsPerCoursePerStudent.Add(apcps);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong Code: S_S_GAPCPS");
            }
            return assignmentsPerCoursePerStudent;
        }

        public List<StudentsWithMoreThanOneCourse> GetStudentsWithMoreThanOneCourses()
        {
            List<StudentsWithMoreThanOneCourse> studentsWithMoreThanOneCourse = new List<StudentsWithMoreThanOneCourse>();

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string queryString = "select Student.firstName as [First name], Student.lastName as [Last name] , " +
                                         "count(StudentCourse.Sid) as [Number of courses] from Student " +
                                         "inner join StudentCourse on Student.Sid = StudentCourse.Sid " +
                                         "where Student.Sid = StudentCourse.Sid group by Student.firstName, Student.lastName " +
                                         "having count(StudentCourse.Sid) > 1; ";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(queryString, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        StudentsWithMoreThanOneCourse s = new StudentsWithMoreThanOneCourse(firstName: reader[0].ToString(), lastName: reader[1].ToString(), numberOfCourses: Convert.ToInt16(reader[2].ToString()));
                        studentsWithMoreThanOneCourse.Add(s);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong Code: S_S_GSWMTOC");
            }
            return studentsWithMoreThanOneCourse;
        }


    }

}
