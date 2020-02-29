use [PrivateSchool_KoutsogiorgosEvangelos]
go

--Create table student
create table Student(
	[Sid] int identity (1, 1) not null,
	firstName nvarchar(50) null,
	lastName nvarchar(50) null,
	dateOfBirth date null,
	tuitionFees decimal(8,2) null
	Primary key (Sid),
);

--Create course table
create table Course(
	[Cid] int identity (1, 1) not null,
	title nvarchar(50) null,
	stream nvarchar(50) null,
	type nvarchar(50) null,
	startDate date null,
	endDate date null,
	Primary key (Cid)
);

--Create Assignment table
create table Assignment(
	[Aid] int identity (1, 1) not null,
	title nvarchar(50) null,
	[description] nvarchar(50) null,
	subDateTime date null,
	Cid int null,
	Primary key (Aid),
	constraint fk_Assignment foreign key (Cid) references Course(Cid)
);


--Create Trainer table
create table Trainer(
	[Tid] int identity (1, 1) not null,
	firstName nvarchar(50) null,
	lastName nvarchar(50) null,
	subject nvarchar(50) null,
	Primary key (Tid)
);

--Create Mark table
create table Mark(
	[Mid] int identity(1,1) not null,
	oralMark decimal(5,2) null,
	totalMark decimal(5,2) null,
	primary key (Mid)
);

--Create StudentAssignment table
create table StudentAssignment(
	[Sid] int not null,
	[Aid] int not null,
	[Mid] int null,
	primary key (Sid, Aid),
	constraint fk1_StudentAssignment foreign key (Sid) references Student(Sid),
	constraint fk2_StudentAssignment foreign key (Aid) references Assignment(Aid),
	constraint fk3_StudentAssignment foreign key (Mid) references Mark(Mid)
);

--Create StudentCourse table
create table StudentCourse(
	[Sid] int not null,
	[Cid] int not null,
	primary key (Sid, Cid),
	constraint fk1_StudentCourse foreign key (Sid) references Student(Sid),
	constraint fk2_StudentCourse foreign key (Cid) references Course(Cid)
);

--Create TrainerCourse table
create table TrainerCourse(
	[Cid] int not null,
	[Tid] int not null,
	primary key (Tid, Cid),
	constraint fk1_TrainerCourse foreign key (Tid) references Trainer(Tid),
	constraint fk2_TrainerCourse foreign key (Cid) references Course(Cid)
);