Create Database dbTestQuestionnaire
Use dbTestQuestionnaire

create table tblTeacher
(
T_ID varchar(30) Primary key,
T_Username varchar(30),
T_Password varchar(30),
T_LastName Nvarchar(30),
T_FirstName Nvarchar(30),
T_UserType varchar(30)
)

--insert Admin, Section, Student
Insert into tblTeacher values ('Admin-0001', 'admin', 'admin', 'admin', 'admin', 'ADMIN')

select * from tblSection
select * from tblTeacher
select * from tblStudent
select * from tblScore
select * from tblQuestion

delete from tblStudent
delete  from tblSection
delete from tblTeacher
delete from tblQuestion where Question = 'sefasef'
delete from tblScore

create table tblStudent
(
S_ID varchar(30) Primary Key,
S_Username varchar(30),
S_Password varchar(30),
S_LastName nvarchar(30),
S_FirstName nvarchar(30),
Section_Grade varchar(30),
Section_name varchar(30),
T_ID varchar(30) Foreign Key references tblTeacher(T_ID),
T_name varchar(30)
)

create table tblSection
(
Section_ID varchar(30) primary key,
Section_name varchar(30),
Section_Grade varchar(30),
T_ID varchar(30) Foreign Key references tblTeacher(T_ID),
T_Name varchar(30)
)

create table tblScore
(
S_ID varchar(30) Foreign Key references tblStudent(S_ID),
T_ID varchar(30) Foreign Key references tblTeacher(T_ID),
S_LastName nvarchar(30),
S_FirstName nvarchar(30),
Section_Grade varchar(30),
Section_name varchar(30),
Correct varchar(30),
Wrong varchar(30),
)

create table tblQuestion
(
No int,
Section_Grade varchar(30),
Section_name varchar(30),
Question nvarchar(80),
Answer nvarchar(80),
Choice1 nvarchar(80),
Choice2 nvarchar(80),
Choice3 nvarchar(80),
T_ID varchar(30) Foreign Key references tblTeacher(T_ID)
)





-------------STORED PROCEDURES-----------------------------

--retrieve username and password to Student
create proc sp_retrieveStudent
@S_Username varchar(30),
@S_Password varchar(30)
as select * from tblStudent where S_Username = @S_Username and S_Password = @S_Password

--retrieve Username to Student
create proc sp_retrieveUsernameStudent
@S_Username varchar(30)
as select * from tblStudent where S_Username = @S_Username

--retrieve username and password to Teacher
create proc sp_retrieveTeacher
@T_Username varchar(30),
@T_Password varchar(30)
as select * from tblTeacher where T_Username = @T_Username and T_Password = @T_Password

--retrieve userID
create proc sp_retrieveID
@T_ID varchar(30)
as select * from tblTeacher where T_ID = @T_ID

--retrieve username to teacher
create proc sp_retrieveUsernameTeacher
@T_Username varchar(30)
as select * from tblTeacher where T_Username = @T_Username

--retrieve Teacher Name
create proc sp_retrieveName
@T_LastName Nvarchar(30),
@T_FirstName Nvarchar(30)
as select * from tblTeacher where T_LastName = @T_LastName and T_FirstName = @T_FirstName

--delete Teacher
create proc sp_deleteTeacher
@T_LastName Nvarchar(30),
@T_FirstName Nvarchar(30)
as delete from tblTeacher where T_LastName = @T_LastName and T_FirstName = @T_FirstName

--View Teacher
create proc sp_viewTeacher
as select T_LastName as 'LastName',
		  T_FirstName as 'FirstName'
from tblTeacher where T_UserType != 'admin'

--Update Teacher
create proc sp_UpdateTeacher
@T_ID varchar(30),
@T_Username varchar(30),
@T_Password varchar(30),
@T_LastName Nvarchar(30),
@T_FirstName Nvarchar(30)
as update tblTeacher
set T_Username = @T_Username, T_Password = @T_Password, T_LastName = @T_LastName, T_FirstName = @T_FirstName
where T_ID = @T_ID

--Search Teacher
create proc sp_searchT
@key varchar(100)
as
select T_LastName as 'Last Name',
	   T_FirstName as 'First Name'
from tblTeacher where T_UserType != 'Admin' and T_LastName like @key + '%' or T_FirstName like @key 

--Search Section
create proc sp_searchS
@key varchar(100)
as
select Section_name as Section,
	   Section_Grade as Grade,
       T_Name as Teacher
from tblSection where Section_name like @key + '%' or Section_Grade like @key + '%' or T_Name like @key

--view Section
create proc sp_viewSection
as select Section_name as Section,
		  Section_Grade as Grade,
          T_Name as Teacher
from tblSection

--Update Section
create proc sp_updateSection
@Section_ID varchar(30),
@Section_name varchar(30),
@Section_Grade varchar(30),
@T_ID varchar(30),
@T_Name varchar(30)
as update tblSection
set Section_ID = @Section_ID, Section_name = @Section_name, Section_Grade = @Section_Grade, T_ID = @T_ID, T_Name = @T_Name
where Section_ID = @Section_ID

--Retrieve ID in Section
create proc sp_retrieveSection
@Section_name varchar(30),
@Section_Grade varchar(30),
@T_Name varchar(30)
as select * from tblSection where Section_name = @Section_name and Section_Grade = @Section_Grade and T_Name = @T_Name

--Retrieve info in Student
create proc sp_retrieveInfoStudent
@S_LastName nvarchar(30),
@S_FirstName nvarchar(30),
@Section_Grade varchar(30),
@Section_name varchar(30)
as select * from tblStudent where S_LastName = @S_LastName and S_FirstName = @S_FirstName and Section_Grade = @Section_Grade and Section_name = @Section_name

--Retrieve ID in Student
create proc sp_retrieveIDStudent
@S_ID varchar(30)
as select * from tblStudent where S_ID = @S_ID

--Retrieve Score
create proc sp_retrieveScore
@S_ID varchar(30)
as select * from tblScore where S_ID = @S_ID

--Update Student
create proc sp_updateStudent
@S_ID varchar(30),
@S_Username varchar(30),
@S_Password varchar(30),
@S_LastName nvarchar(30),
@S_FirstName nvarchar(30),
@Section_Grade varchar(30),
@Section_name varchar(30)
as 
update tblStudent
set S_Username = @S_Username, S_Password = @S_Password, S_LastName = @S_LastName, S_FirstName = @S_FirstName, Section_Grade = @Section_Grade, Section_name = @Section_name
where S_ID = @S_ID

--Update Student1
create proc sp_updateStudent1
@S_ID varchar(30),
@S_Username varchar(30),
@S_Password varchar(30)
as 
update tblStudent
set S_Username = @S_Username, S_Password = @S_Password
where S_ID = @S_ID

--Add Teacher
create proc sp_addTeacher
@T_ID varchar(30),
@T_Username varchar(30),
@T_Password varchar(30),
@T_LastName Nvarchar(30),
@T_FirstName Nvarchar(30),
@T_UserType varchar(30)
as insert into tblTeacher(T_ID, T_Username, T_Password, T_LastName, T_FirstName, T_UserType)
values (@T_ID, @T_Username, @T_Password, @T_LastName, @T_FirstName, @T_UserType)

--add Section
create proc sp_addSection
@Section_ID varchar(30),
@Section_name varchar(30),
@Section_Grade varchar(30),
@T_ID varchar(30),
@T_Name varchar(30)
as insert into tblSection(Section_ID, Section_name, Section_Grade, T_ID, T_Name)
values (@Section_ID, @Section_name, @Section_Grade, @T_ID, @T_Name)


--Teacher ID count
create proc sp_teacherID
as select COUNT(*) as CountT from tblTeacher

--Section ID count
create proc sp_sectionID
as select COUNT(*) as CountS from tblSection

--Select All Teacher
create proc sp_SelectTeacher
as select T_LastName, T_FirstName from tblTeacher where T_UserType != 'admin'

--Retrieve Name Teacher and get ID on it
create proc sp_NameTeacher
@T_FirstName varchar(30),
@T_LastName varchar(30)
as select * from tblTeacher where T_FirstName = @T_FirstName and T_LastName = @T_LastName

--Retrieve Student Info
create proc sp_viewStudent
@T_ID varchar(30)
as select S_LastName as Lastname,
          S_FirstName as Firstname,
		  Section_name as Section,
		  Section_Grade as Grade
from tblStudent where T_ID = @T_ID

--Search Student
create proc sp_searchStudent
@key varchar(100)
as select S_LastName as Lastname,
          S_FirstName as Firstname,
		  Section_name as Section,
		  Section_Grade as Grade
from tblStudent where S_LastName like @key + '%' or S_FirstName like @key + '%' or Section_name like @key + '%' or Section_Grade like @key

--Student ID
create proc sp_StudentID
as select Count(*) as CountS from tblStudent 

--Add Student
create proc sp_addStudent
@S_ID varchar(30),
@S_Username varchar(30),
@S_Password varchar(30),
@S_LastName nvarchar(30),
@S_FirstName nvarchar(30),
@Section_Grade varchar(30),
@Section_name varchar(30),
@T_ID varchar(30),
@T_name varchar(30)
as insert into tblStudent(S_ID, S_Username, S_Password, S_LastName, S_FirstName, Section_Grade, Section_name, T_ID, T_name)
values (@S_ID, @S_Username, @S_Password, @S_LastName, @S_FirstName, @Section_Grade, @Section_name, @T_ID, @T_name)

--Select Section
create proc sp_selectSection
@T_ID varchar(30)
as select Section_Name from tblSection where T_ID = @T_ID

--Find Section from tblsection in grade
create proc sp_selectSectioninGrade
@Section_Grade varchar(30),
@T_ID varchar(30)
as select Section_Name, Section_Grade from tblSection where Section_Grade = @Section_Grade AND T_ID = @T_ID

--view Question
create proc sp_viewQuestion
@Section_Grade varchar(30),
@Section_name varchar(30),
@T_ID varchar(30)
as select No, Question from tblQuestion where  Section_Grade = @Section_Grade AND Section_name = @Section_name AND T_ID = @T_ID

--Search Question
create proc sp_searchQuestion
@key varchar(100),
@Section_Grade varchar(30),
@Section_name varchar(30),
@T_ID varchar(30)
as select No, Question from tblQuestion where Section_Grade = @Section_Grade AND Section_name = @Section_name AND T_ID = @T_ID and No like @key + '%' or Question like @key

--add Question
create proc sp_addQuestion
@No int,
@Question nvarchar(80),
@Answer nvarchar(80),
@Choice1 nvarchar(80),
@Choice2 nvarchar(80),
@Choice3 nvarchar(80),
@Section_Grade varchar(30),
@Section_name varchar(30),
@T_ID varchar(30)
as insert into tblQuestion values (@No, @Question, @Answer, @Choice1, @Choice2, @Choice3, @Section_Grade, @Section_name, @T_ID) 

--view Score
create proc sp_viewScore
@T_ID varchar(30),
@Section_name varchar(30),
@Section_Grade varchar(30)
as select S_LastName as Lastname, 
		  S_FirstName as Firstname,
		  Correct,
		  Wrong
from tblScore where Section_name = @Section_name AND T_ID = @T_ID AND Section_Grade = @Section_Grade



--Too see if he/she take the exam
create proc sp_SelectScore
@S_ID varchar(30)
as select * from tblScore where S_ID = @S_ID

--Add Score
create proc sp_addScore
@S_ID varchar(30), 
@T_ID varchar(30), 
@S_LastName nvarchar(30),
@S_FirstName nvarchar(30),
@Section_Grade varchar(30),
@Section_name varchar(30),
@Correct varchar(30),
@Wrong varchar(30)
as insert into tblScore values (@S_ID, @T_ID, @S_LastName, @S_FirstName, @Section_Grade, @Section_name, @Correct, @Wrong)

--Count Question
create proc sp_countQuez
@Section_Grade varchar(30),
@Section_name varchar(30)
as select Count(*) as countQ from tblQuestion where Section_Grade = @Section_Grade and Section_name = @Section_name

--Retrieve Question
create proc sp_RetrieveQuiz
@No int,
@Section_Grade varchar(30),
@Section_name varchar(30),
@T_ID varchar(30)
as select * from tblQuestion where No = @No AND Section_Grade = @Section_Grade AND Section_name = @Section_name and T_ID = @T_ID

--View Question1
create proc sp_ViewQuizNo
@No int,
@Section_Grade varchar(30),
@Section_name varchar(30)
as select * from tblQuestion where No = @No AND Section_Grade = @Section_Grade AND Section_name = @Section_name

--Update Question
create proc sp_updateQuiz
@No int,
@Question nvarchar(80),
@Answer nvarchar(80),
@Choice1 nvarchar(80),
@Choice2 nvarchar(80),
@Choice3 nvarchar(80),
@Section_Grade varchar(30),
@Section_name varchar(30),
@T_ID varchar(30)
as 
update tblQuestion
set Question = @Question, Answer = @Answer, Choice1 = @Choice1, Choice2 = @Choice2, Choice3 = @Choice3
where No = @No AND Section_Grade = @Section_Grade AND Section_name = @Section_name AND T_ID = @T_ID
 
--Update Score
create proc sp_updateScore
@S_ID varchar(30),
@Correct varchar(30),
@Wrong varchar(30)
as 
update tblScore
set Correct = @Correct, Wrong = @Wrong
where S_ID = @S_ID


--Crytal Report
select S_LastName as Lastname, 
		  S_FirstName as Firstname,
		  Correct,
		  Wrong,
		  @Section_name,
		  @T_ID,
		  @Section_Grade
from tblScore where Section_name = @Section_name AND T_ID = @T_ID AND Section_Grade = @Section_Grade

