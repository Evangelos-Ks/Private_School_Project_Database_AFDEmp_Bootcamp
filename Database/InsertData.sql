
use [PrivateSchool_KoutsogiorgosEvangelos]
go

--Input Students
insert into Student (firstName, lastName, dateOfBirth, tuitionFees) values ('Maria', 'Fafouti', convert(date ,'1990/7/1'), 500);
insert into Student (firstName, lastName, dateOfBirth, tuitionFees) values ('Evangelos', 'Koutsogiorgos', convert(date ,'1989/11/9'), 1000);
insert into Student (firstName, lastName, dateOfBirth, tuitionFees) values ('Panagiotis', 'Koutsogiorgos', convert(date ,'1991/3/26'), 600);
insert into Student (firstName, lastName, dateOfBirth, tuitionFees) values ('Ioannis', 'Angelopoulos', convert(date ,'1985/6/19'), 500);
insert into Student (firstName, lastName, dateOfBirth, tuitionFees) values ('Sophia', 'Georgiou', convert(date ,'1992/6/13'), 700);
insert into Student (firstName, lastName, dateOfBirth, tuitionFees) values ('Eleni', 'Parisi', convert(date ,'1989/12/3'), 1200);
insert into Student (firstName, lastName, dateOfBirth, tuitionFees) values ('Eleutherios', 'Danopoulos', convert(date ,'1992/1/14'), 500);
insert into Student (firstName, lastName, dateOfBirth, tuitionFees) values ('Dimitra', 'Alexiou', convert(date ,'1991/10/29'), 900);
insert into Student (firstName, lastName, dateOfBirth, tuitionFees) values ('George', 'Leras', convert(date ,'1990/8/13'), 1100);
insert into Student (firstName, lastName, dateOfBirth, tuitionFees) values ('Thanasis', 'Sdralias', convert(date ,'1985/5/13'), 800);

--input Courses
insert into Course (title, stream, type, startDate, endDate) values('Chem' , 'Full time', 'Chemistry', convert(date ,'2019/10/1'), convert(date ,'2020/6/16'));
insert into Course (title, stream, type, startDate, endDate) values('Phys' , 'Full time', 'Physics', convert(date ,'2019/10/1'), convert(date ,'2020/6/23'));

--input Trainers
insert into Trainer (firstName, lastName, subject) values('Marie', 'Curie', 'Chemistry');
insert into Trainer (firstName, lastName, subject) values('Luis', 'Pasteur', 'Chemistry');
insert into Trainer (firstName, lastName, subject) values('Albert', 'Einstain', 'Physics');
insert into Trainer (firstName, lastName, subject) values('Richard', 'Faynman', 'Physics');

--input Assignment
insert into Assignment (title, description, subDateTime, Cid) values('OrgChem', 'Organic Chemistry', convert(date ,'2020/1/10'), 1)
insert into Assignment (title, description, subDateTime, Cid) values('InorgChem', 'Inorganic Chemistry', convert(date ,'2020/1/9'), 1)
insert into Assignment (title, description, subDateTime, Cid) values('MecPhys', 'Mecanics', convert(date ,'2020/1/23'), 2)
insert into Assignment (title, description, subDateTime, Cid) values('OptPhys', 'Optics', convert(date ,'2020/1/20'), 2)

--populate Mark
insert into Mark (oralMark, totalMark) values(77, 88);
insert into Mark (oralMark, totalMark) values(65, 92);
insert into Mark (oralMark, totalMark) values(69, 72);
insert into Mark (oralMark, totalMark) values(83, 75);

--populate StudentCourse
insert into StudentCourse (Sid,Cid) values(1,1);
insert into StudentCourse (Sid,Cid) values(2,1);
insert into StudentCourse (Sid,Cid) values(3,1);
insert into StudentCourse (Sid,Cid) values(4,1);
insert into StudentCourse (Sid,Cid) values(5,1);
insert into StudentCourse (Sid,Cid) values(1,2);
insert into StudentCourse (Sid,Cid) values(2,2);
insert into StudentCourse (Sid,Cid) values(6,2);
insert into StudentCourse (Sid,Cid) values(7,2);
insert into StudentCourse (Sid,Cid) values(8,2);
insert into StudentCourse (Sid,Cid) values(9,2);
insert into StudentCourse (Sid,Cid) values(10,2);

--populate TrainerCourse
insert into TrainerCourse (Tid,Cid) values(1,1);
insert into TrainerCourse (Tid,Cid) values(2,1);
insert into TrainerCourse (Tid,Cid) values(3,2);
insert into TrainerCourse (Tid,Cid) values(4,2);

--populate StudentAssignment
insert into StudentAssignment (Sid, Aid, Mid) values(1 , 1, 1);
insert into StudentAssignment (Sid, Aid, Mid) values(2 , 1, 2);
insert into StudentAssignment (Sid, Aid, Mid) values(3 , 1, 3);
insert into StudentAssignment (Sid, Aid, Mid) values(4 , 1, 4);
insert into StudentAssignment (Sid, Aid, Mid) values(5 , 1, 1);
insert into StudentAssignment (Sid, Aid, Mid) values(1 , 2, 2);
insert into StudentAssignment (Sid, Aid, Mid) values(2 , 2, 3);
insert into StudentAssignment (Sid, Aid, Mid) values(3 , 2, 4);
insert into StudentAssignment (Sid, Aid, Mid) values(4 , 2, 1);
insert into StudentAssignment (Sid, Aid, Mid) values(5 , 2, 2);
insert into StudentAssignment (Sid, Aid, Mid) values(6 , 3, 3);
insert into StudentAssignment (Sid, Aid, Mid) values(7 , 3, 4);
insert into StudentAssignment (Sid, Aid, Mid) values(8 , 3, 1);
insert into StudentAssignment (Sid, Aid, Mid) values(9 , 3, 2);
insert into StudentAssignment (Sid, Aid, Mid) values(10 , 3, 3);
insert into StudentAssignment (Sid, Aid, Mid) values(6 , 4, 4);
insert into StudentAssignment (Sid, Aid, Mid) values(7 , 4, 1);
insert into StudentAssignment (Sid, Aid, Mid) values(8 , 4, 2);
insert into StudentAssignment (Sid, Aid, Mid) values(9 , 4, 3);
insert into StudentAssignment (Sid, Aid, Mid) values(10 , 4, 4);





