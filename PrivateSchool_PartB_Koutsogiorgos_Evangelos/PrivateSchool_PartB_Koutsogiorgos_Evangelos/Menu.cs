using MainStacture;
using Services;
using System;
using System.Collections.Generic;


namespace PrivateSchool_PartB_Koutsogiorgos_Evangelos
{
    public static class Menu
    {
        public static void Run()
        {

            Course c1 = new Course();
            Assignment a1 = new Assignment();
            Trainer tr1 = new Trainer();
            Student s1 = new Student();
            StudentsPerCourse sPC = new StudentsPerCourse();
            TrainersPerCourse tPC = new TrainersPerCourse();
            AssignmentsPerCourse aPC = new AssignmentsPerCourse();
            AssignmetsPerStudent aPS = new AssignmetsPerStudent();
            AssignmentsPerCoursePerStudent aPCPS = new AssignmentsPerCoursePerStudent();
            StudentsWithMoreThanOneCourse sMTOC = new StudentsWithMoreThanOneCourse();
            ServiceGet serviseGet = new ServiceGet();
            ServiceInsert serviseInsert = new ServiceInsert();
            ServiceCheck serviceCheck = new ServiceCheck();

            string userInput2 = "", userInput3 = "", userInput5 = "";
            int selectCourse;


            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("\tWellcome to Private School! What would you like to do?");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\t0. Exit.");
                Console.WriteLine("\t1. Course.");
                Console.WriteLine("\t2. Assignment.");
                Console.WriteLine("\t3. Trainer.");
                Console.WriteLine("\t4. Student.");


                Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                userInput2 = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t=================================================================================\n");
                Console.ForegroundColor = ConsoleColor.White;

                //UserInput2 = 1, normal mode, Course--------------------------------------------------------------------------------------------------------------------
                if (userInput2 == "1")
                {
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine();
                        Console.WriteLine("\tYou are in the course mode! What would you like to do?");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("\t0. Exit.");
                        Console.WriteLine("\t1. New course.");
                        Console.WriteLine("\t2. Output list with all courses.");
                        Console.WriteLine("\t3. Add students at courses.");
                        Console.WriteLine("\t4. Output students per course.");
                        Console.WriteLine("\t5. Add trainers at courses.");
                        Console.WriteLine("\t6. Output trainers per course.");
                        Console.WriteLine("\t7. Add assignments at courses.");
                        Console.WriteLine("\t8. Output assignments per course.");
                        Console.WriteLine("\t9. Go back.");

                        Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                        userInput3 = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\t=================================================================================\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        //UserInput3 = 1, normal mode, New course-------------------------------------------------------------------------------------------------------
                        if (userInput3 == "1")
                        {
                            serviseInsert.InsertCourse();
                        }
                        //UserInput3 = 2, normal mode, List of courses-------------------------------------------------------------------------------------------------------
                        else if (userInput3 == "2")
                        {
                            c1.ListOfCoursecOutput(serviseGet.GetAllCourses());
                            MyStaticClass.PressKeyToContinue();
                        }
                        //UserInput3 = 3, normal mode, Add students at courses-------------------------------------------------------------------------------------------------------
                        else if (userInput3 == "3")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine();
                            Console.WriteLine("\tSelect the number of course that you want to add students.");
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;


                            List<Course> allCourses = serviseGet.GetAllCourses();
                            c1.ListOfCoursecOutput(allCourses);
                            Console.WriteLine();

                            do
                            {
                                Console.Write("\tEnter the apropriate number : ");
                                selectCourse = MyStaticClass.InputTryToConvertToInt();
                            } while (selectCourse <= 0 || selectCourse > allCourses.Count);


                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n\t=================================================================================\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\tSelect how you want to add a student.");
                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine();
                                Console.WriteLine("\t1. Add a new student.");
                                Console.WriteLine("\t2. Add an excisting student.");
                                Console.WriteLine("\t9. Go back.");

                                Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                                userInput5 = Console.ReadLine();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n\t=================================================================================\n");
                                Console.ForegroundColor = ConsoleColor.White;

                                if (userInput5 == "1")
                                {
                                    serviseInsert.InsertStudent();
                                    List<Student> students = serviseGet.GetAllStudents();
                                    serviseInsert.InsertStudentAtCourse((int)students[students.Count - 1].Sid, (int)allCourses[selectCourse - 1].Cid);
                                }
                                else if (userInput5 == "2")
                                {
                                    string addAnotherStudentfromList;
                                    bool notSuccededAdd = true;
                                    do
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine();
                                        Console.WriteLine("\tSelect the number of student.");
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.White;

                                        List<Student> allStudents = serviseGet.GetAllStudents();
                                        s1.ListOfStudentsOutput(allStudents);

                                        do
                                        {
                                            int userSelectStudent = 0;
                                            try
                                            {
                                                Console.WriteLine();
                                                Console.Write("\tEnter a propriate number : ");

                                                userSelectStudent = Convert.ToInt32(Console.ReadLine());
                                                if (userSelectStudent >= 0 && userSelectStudent <= allStudents.Count)
                                                {
                                                    if (serviceCheck.ExistStudentsPerCourse((int)allStudents[userSelectStudent - 1].Sid, (int)allCourses[selectCourse - 1].Cid))
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine();
                                                        Console.WriteLine("\tThe student already exist in the course.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        notSuccededAdd = true;
                                                    }
                                                    else
                                                    {
                                                        serviseInsert.InsertStudentAtCourse((int)allStudents[userSelectStudent - 1].Sid, (int)allCourses[selectCourse - 1].Cid);
                                                        notSuccededAdd = false;
                                                    }

                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\tPlease select a propriate number.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    notSuccededAdd = true;
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\tPlease select a propriate number.");

                                                Console.ForegroundColor = ConsoleColor.White;
                                                notSuccededAdd = true;
                                            }
                                        } while (notSuccededAdd);

                                        //Ask to add another student from the list in course
                                        do
                                        {
                                            Console.WriteLine();
                                            Console.Write("\tWould you like to add another student from the list in course? Y/N : ");
                                            addAnotherStudentfromList = Console.ReadLine();
                                            Console.WriteLine();
                                        } while (addAnotherStudentfromList.ToUpper() != "Y" && addAnotherStudentfromList.ToUpper() != "N");

                                    } while (addAnotherStudentfromList.ToUpper() != "N");
                                }

                            } while ((userInput5 != "1" && userInput5 != "2") && userInput5 != "9");
                        }
                        //UserInput3 = 4, normal mode, Output students per course-------------------------------------------------------------------------------------------------------
                        else if (userInput3 == "4")
                        {
                            sPC.ListOfStudentsPerCourseOutput(serviseGet.GetStudentsPerCourse());
                            MyStaticClass.PressKeyToContinue();
                        }
                        //UserInput3 = 5, normal mode, Add trainers at courses-------------------------------------------------------------------------------------------------------
                        else if (userInput3 == "5")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine();
                            Console.WriteLine("\tSelect the number of course that you want to add trainers.");
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;

                            List<Course> allCourses = serviseGet.GetAllCourses();
                            c1.ListOfCoursecOutput(allCourses);
                            Console.WriteLine();

                            do
                            {
                                Console.Write("\tEnter the apropriate number : ");
                                selectCourse = MyStaticClass.InputTryToConvertToInt();
                            } while (selectCourse <= 0 || selectCourse > allCourses.Count);


                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n\t=================================================================================\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\tSelect how you want to add a trainer.");
                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine();
                                Console.WriteLine("\t1. Add a new trainer.");
                                Console.WriteLine("\t2. Add an excisting trainer.");
                                Console.WriteLine("\t9. Go back.");

                                Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                                userInput5 = Console.ReadLine();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n\t=================================================================================\n");
                                Console.ForegroundColor = ConsoleColor.White;

                            } while ((userInput5 != "1" && userInput5 != "2") && userInput5 != "9");

                            if (userInput5 == "1")
                            {
                                serviseInsert.InsertTrainer();
                                List<Trainer> trainers = serviseGet.GetAllTrainers();
                                serviseInsert.InsertTrainerAtCourse((int)trainers[trainers.Count - 1].Tid, (int)allCourses[selectCourse - 1].Cid);
                            }
                            else if (userInput5 == "2")
                            {
                                string addAnotherTrainerfromList;
                                bool notSuccededAdd = true;
                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine();
                                    Console.WriteLine("\tSelect the number of trainer.");
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.White;

                                    List<Trainer> allTrainers = serviseGet.GetAllTrainers();
                                    tr1.ListOfTrainersOutput(allTrainers);

                                    do
                                    {
                                        int selectTrainer = 0;
                                        try
                                        {
                                            Console.WriteLine();
                                            Console.Write("\tEnter a propriate number : ");

                                            selectTrainer = Convert.ToInt32(Console.ReadLine());
                                            if (selectTrainer >= 0 && selectTrainer <= allTrainers.Count)
                                            {
                                                if (serviceCheck.ExistTrainerPerCourse((int)allTrainers[selectTrainer - 1].Tid, (int)allCourses[selectCourse - 1].Cid))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine();
                                                    Console.WriteLine("\tThe trainer already exist in the course.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    notSuccededAdd = true;
                                                }
                                                else
                                                {
                                                    serviseInsert.InsertTrainerAtCourse((int)allTrainers[selectTrainer - 1].Tid, (int)allCourses[selectCourse - 1].Cid);
                                                    notSuccededAdd = false;
                                                }

                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\tPlease select a propriate number.");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                notSuccededAdd = true;
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("\tPlease select a propriate number.");

                                            Console.ForegroundColor = ConsoleColor.White;
                                            notSuccededAdd = true;
                                        }
                                    } while (notSuccededAdd);

                                    //Ask to add another student from the list in course
                                    do
                                    {
                                        Console.WriteLine();
                                        Console.Write("\tWould you like to add another student from the list in course? Y/N : ");
                                        addAnotherTrainerfromList = Console.ReadLine();
                                        Console.WriteLine();
                                    } while (addAnotherTrainerfromList.ToUpper() != "Y" && addAnotherTrainerfromList.ToUpper() != "N");

                                } while (addAnotherTrainerfromList.ToUpper() != "N");
                            }
                        }
                        //UserInput3 = 6, normal mode, Output trainers per course-------------------------------------------------------------------------------------------------------
                        else if (userInput3 == "6")
                        {
                            tPC.ListOfTrainersPerCourseOutput(serviseGet.GetTrainersPerCourse());
                            MyStaticClass.PressKeyToContinue();
                        }
                        //UserInput3 = 7, normal mode, Add assignments at courses-------------------------------------------------------------------------------------------------------
                        else if (userInput3 == "7")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine();
                            Console.WriteLine("\tSelect the number of course that you want to add assignments.");
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;


                            List<Course> allCourses = serviseGet.GetAllCourses();
                            c1.ListOfCoursecOutput(allCourses);
                            Console.WriteLine();

                            do
                            {
                                Console.Write("\tEnter the apropriate number : ");
                                selectCourse = MyStaticClass.InputTryToConvertToInt();
                            } while (selectCourse <= 0 || selectCourse > allCourses.Count);


                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n\t=================================================================================\n");
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\tSelect how you want to add an assignment.");
                            Console.ForegroundColor = ConsoleColor.White;
                            do
                            {

                                Console.WriteLine();
                                Console.WriteLine("\t1. Add a new assignment.");
                                Console.WriteLine("\t2. Add an excisting assignment.");
                                Console.WriteLine("\t9. Go back.");

                                Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                                userInput5 = Console.ReadLine();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n\t=================================================================================\n");
                                Console.ForegroundColor = ConsoleColor.White;

                            } while ((userInput5 != "1" && userInput5 != "2") && userInput5 != "9");

                            if (userInput5 == "1")
                            {
                                serviseInsert.InsertNewAssignmentAtCourse((int)allCourses[selectCourse - 1].Cid);
                            }
                            else if (userInput5 == "2")
                            {
                                string addAnotherAssignmentfromList;
                                bool notSuccededAdd = true;

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine();
                                Console.WriteLine("\tSelect the number of the assignment.");
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.White;

                                List<Assignment> allAssignments = serviseGet.GetAllAssignments();
                                a1.ListOfAssignmentsOutput(allAssignments);

                                do
                                {
                                    int selectAssignment = 0;
                                    try
                                    {
                                        Console.WriteLine();
                                        Console.Write("\tEnter a propriate number : ");

                                        selectAssignment = Convert.ToInt32(Console.ReadLine());
                                        if (selectAssignment >= 0 && selectAssignment <= allAssignments.Count)
                                        {
                                            serviseInsert.InsertAssignmentAtCourse((int)allAssignments[selectAssignment - 1].Aid, (int)allCourses[selectCourse - 1].Cid);
                                            notSuccededAdd = false;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("\tPlease select a propriate number.");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            notSuccededAdd = true;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\tPlease select a propriate number.");

                                        Console.ForegroundColor = ConsoleColor.White;
                                        notSuccededAdd = true;
                                    }
                                } while (notSuccededAdd);
                            }
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n\t=================================================================================\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        //UserInput3 = 8, normal mode, Output assignments per course-------------------------------------------------------------------------------------------------------
                        else if (userInput3 == "8")
                        {
                            aPC.OutputAssignmetsPerCourse(serviseGet.GetAssignmetsPerCourse());
                            MyStaticClass.PressKeyToContinue();
                        }
                    } while (userInput3 != "0" && userInput3 != "9");
                }
                //UserInput2 = 2, normal mode, Assignment--------------------------------------------------------------------------------------------------------------------
                else if (userInput2 == "2")
                {
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine();
                        Console.WriteLine("\tYou are in the assignment mode! What would you like to do?");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\t0. Exit.");
                        Console.WriteLine("\t1. New assignment.");
                        Console.WriteLine("\t2. Output list with all assignments.");
                        Console.WriteLine("\t3. Output list with assignments per course per student.");
                        Console.WriteLine("\t9. Go back.");

                        Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                        userInput3 = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\t=================================================================================\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        //UserInput3 = 1, normal mode, New Assignment-------------------------------------------------------------------------------------------------------
                        if (userInput3 == "1")
                        {
                            serviseInsert.InsertAssignment();
                        }
                        //UserInput3 = 2, normal mode, List of assignments-------------------------------------------------------------------------------------------------------
                        else if (userInput3 == "2")
                        {
                            a1.ListOfAssignmentsWithoutMarkOutput(serviseGet.GetAllAssignments());
                            MyStaticClass.PressKeyToContinue();
                        }
                        else if (userInput3 == "3")
                        {
                            aPCPS.ListOfAssignmentsPerCoursePerStudentOutput(serviseGet.GetAssignmentsPerCoursePerStudents());
                            MyStaticClass.PressKeyToContinue();
                        }

                    } while ((userInput3 != "0" && userInput3 != "9") && (userInput3 != "1" && (userInput3 != "2" && userInput3 != "3")));
                }
                //UserInput2 = 3, normal mode, Trainer--------------------------------------------------------------------------------------------------------------------
                else if (userInput2 == "3")
                {
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine();
                        Console.WriteLine("\tYou are in the trainer mode! What would you like to do?");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\t0. Exit.");
                        Console.WriteLine("\t1. New trainer.");
                        Console.WriteLine("\t2. Output list with all trainers.");
                        Console.WriteLine("\t9. Go back.");

                        Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                        userInput3 = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\t=================================================================================\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        //UserInput3 = 1, normal mode, New trainer-------------------------------------------------------------------------------------------------------
                        if (userInput3 == "1")
                        {
                            serviseInsert.InsertTrainer();
                        }
                        //UserInput3 = 2, normal mode, List of trainers-------------------------------------------------------------------------------------------------------
                        else if (userInput3 == "2")
                        {
                            tr1.ListOfTrainersOutput(serviseGet.GetAllTrainers());
                            MyStaticClass.PressKeyToContinue();
                        }

                    } while ((userInput3 != "0" && userInput3 != "9") && (userInput3 != "1" && userInput3 != "2"));
                }
                //UserInput2 = 4, normal mode, Student--------------------------------------------------------------------------------------------------------------------
                else if (userInput2 == "4")
                {
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine();
                        Console.WriteLine("\tYou are in the student mode! What would you like to do?");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\t0. Exit.");
                        Console.WriteLine("\t1. New student.");
                        Console.WriteLine("\t2. Output list with all students.");
                        Console.WriteLine("\t3. Output list witn students who belongs to more than one course.");
                        Console.WriteLine("\t9. Go back.");

                        Console.Write("\n\tPlease enter the appropriate number to select the field you are interested in : ");
                        userInput3 = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\t=================================================================================\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        //UserInput3 = 1, normal mode, New Student-------------------------------------------------------------------------------------------------------
                        if (userInput3 == "1")
                        {
                            serviseInsert.InsertStudent();
                        }
                        //UserInput3 = 2, normal mode, List of students-------------------------------------------------------------------------------------------------------
                        else if (userInput3 == "2")
                        {
                            s1.ListOfStudentsOutput(serviseGet.GetAllStudents());
                            MyStaticClass.PressKeyToContinue();
                        }
                        
                        //UserInput3 = 3, normal mode, List of students who belongs to more than one course------------------------------------------------------------------------------------------------------ -
                        else if (userInput3 == "3")
                        {
                            sMTOC.ListOfStudentsOutput(serviseGet.GetStudentsWithMoreThanOneCourses());
                            MyStaticClass.PressKeyToContinue();
                        }
                    } while ((userInput3 != "0" && userInput3 != "9") && (userInput3 != "1" && userInput3 != "2") && (userInput3 != "3" ));
                }
            } while ((userInput2 != "0" && userInput2 != "9") && userInput3 != "0");


            Console.WriteLine("\n\tTHANK YOU!!!");


            Console.ReadKey();
        }
    }
}

