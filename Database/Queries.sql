use [PrivateSchool_KoutsogiorgosEvangelos]
go

--list of all the students
select * from Student;

--list of all the trainers
select * from Trainer;

--list of all the assignments 
select * from Assignment;

--list of all the courses
select * from Course;

--All the students per course
select  Course.title as [Course],  firstName as [First name], lastName as [Last name]  from Student 
inner join StudentCourse
on Student.Sid = StudentCourse.Sid 
inner join Course
on Course.Cid = StudentCourse.Cid
group by  title, firstName,lastName;

--All the trainers per course
select Course.title as "Course", firstName as "First name", lastName as "Last name" from Trainer
inner join TrainerCourse
on Trainer.Tid = TrainerCourse.Tid 
inner join Course
on Course.Cid = TrainerCourse.Cid
group by title, firstName, lastName;

--All the assignments per course
select Course.Title as Course , Assignment.title as "Assignment title", description as Description from Assignment, Course
where Assignment.Cid = Course.Cid;

--All the assignments per course per student
select Course.title as Course, Student.firstName as "First name", Student.lastName as "Last name", Assignment.title as "Assignment title", Assignment.description as Description
from Course, Student, Assignment, StudentCourse, StudentAssignment
where Course.Cid = Assignment.Cid and Course.Cid = StudentCourse.Cid and Student.Sid = StudentCourse.Sid and Student.Sid = StudentAssignment.Sid and Assignment.Aid = StudentAssignment.Aid
group by Course.title, Student.firstName, Student.lastName , Assignment.title, Assignment.description;

--List of students that belong to more than one courses
select Student.firstName as "First name", Student.lastName as "Last name" , count(StudentCourse.Sid) as "Number of courses"
from Student
inner join StudentCourse
on Student.Sid = StudentCourse.Sid
where  Student.Sid = StudentCourse.Sid
group by Student.firstName, Student.lastName
having count(StudentCourse.Sid) > 1;

