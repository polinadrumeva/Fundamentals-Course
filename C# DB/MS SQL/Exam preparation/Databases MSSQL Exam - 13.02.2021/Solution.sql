--01. DDL
CREATE DATABASE Bitbucket

USE Bitbucket

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	Password VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id),
	ContributorId INT FOREIGN KEY REFERENCES Users(Id),
	PRIMARY KEY(RepositoryId, ContributorId)
)

CREATE TABLE Issues
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus VARCHAR(6) NOT NULL,
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits
(
	Id INT PRIMARY KEY IDENTITY,
	Message VARCHAR(255) NOT NULL,
	IssueId INT FOREIGN KEY REFERENCES Issues(Id),
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(100) NOT NULL,
	Size DECIMAL(16,2) NOT NULL,
	ParentId INT FOREIGN KEY REFERENCES Files(Id),
	CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)


--02. Insert
INSERT INTO Files (Name, Size, ParentId, CommitId) 
	VALUES
	('Trade.idk', 2598.0, 1, 1),
	('menu.net', 9238.31, 2, 2),
	('Administrate.soshy', 1246.93, 3, 3),
	('Controller.php', 7353.15, 4, 4),
	('Find.java', 9957.86, 5, 5), 
	('Controller.json', 14034.87, 3, 6), 
	('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues (Title, IssueStatus, RepositoryId, AssigneeId)
	VALUES
	('Critical Problem with HomeController.cs file', 'open', 1, 4), 
	('Typo fix in Judge.html', 'open', 4, 3),
	('Implement documentation for UsersService.cs', 'closed', 8, 2),
	('Unreachable code in Index.cs', 'open', 9, 8)


--03. Update
UPDATE Issues
	SET IssueStatus = 'closed'
	WHERE AssigneeId = 6


--04. Delete
SELECT * 
	FROM Repositories

DELETE 
	FROM RepositoriesContributors
	WHERE RepositoryId = 3

DELETE 
	FROM Issues
	WHERE RepositoryId = 3


--05. Commits
SELECT Id, Message, RepositoryId, ContributorId
	FROM Commits
	ORDER BY Id, Message, RepositoryId, ContributorId


--06. Front-end
SELECT Id, Name, Size
	FROM Files
	WHERE Size > 1000 AND Name LIKE '%html%'
	ORDER BY Size DESC, Id, Name


--07. Issue Assignment
SELECT i.Id, CONCAT(u.Username, ' : ', i.Title) AS IssueAssignee
	FROM Issues i
	LEFT JOIN Users u ON i.AssigneeId = u.Id
	ORDER BY i.Id DESC, i.AssigneeId


--08. Single Files
SELECT f.Id, f.Name, CONCAT(f.Size, 'KB') AS Size	 
	FROM Files f
	LEFT JOIN Files ff ON f.Id = ff.ParentId
	WHERE ff.ParentId IS NULL
	ORDER BY f.Id, f.Name, f.Size DESC


--09. Commits in Repositories
SELECT TOP(5) r.Id, r.Name, COUNT(r.Id) AS Commits
	FROM Repositories r
	JOIN Commits c ON r.Id = c.RepositoryId
	JOIN RepositoriesContributors rc ON r.Id = rc.RepositoryId
	GROUP BY r.Id, r.Name
	ORDER BY Commits DESC, r.Id, r.Name


--10. Average Size
SELECT u.Username, AVG(f.Size) AS Size 
	FROM Users u
	JOIN Commits c ON u.Id = c.ContributorId
	JOIN Files f ON c.Id = f.CommitId
	GROUP BY u.Username
	ORDER BY Size DESC, u.Username


--11. All User Commits
CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
AS
	BEGIN
		RETURN (SELECT COUNT(u.Id)
				FROM Users u
				LEFT JOIN Commits c ON u.Id = c.ContributorId
				WHERE u.Username = @username)
	END
GO

SELECT dbo.udf_AllUserCommits('UnderSinduxrein')


--12. Search for Files
CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(50))
AS
	SELECT Id, Name, CONCAT(Size, 'KB') AS Size
		FROM Files
		WHERE Name LIKE CONCAT('%', @fileExtension, '%')
		ORDER BY Id, Name, Size DESC
GO

EXEC usp_SearchForFiles 'txt'