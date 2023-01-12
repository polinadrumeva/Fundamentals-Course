CREATE TABLE Students_2 
(
	Id INT IDENTITY PRIMARY KEY, 
	FirstName NVARCHAR(10) NOT NULL, 
	LastName NVARCHAR(10) NOT NULL, 
	FacultyNumber CHAR(6) NOT NULL,
	Photo VARBINARY(MAX), 
	[Date] DATE, 
	Courses NVARCHAR(200)
)