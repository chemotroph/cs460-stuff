CREATE TABLE [dbo].[Homework]
(
    [ID]        INT IDENTITY (1,1)				NOT NULL,
    [HomeworkTitle] NVARCHAR(128)			   NOT NULL,
	[Department] NVARCHAR(128)					 NOT NULL,
	[CourseNumber] INT							NOT NULL,
	[Priority] INT					NOT NULL,
    [Notes]    NVARCHAR(256),
    [DueDate]        DATETIME				  NOT NULL,
    CONSTRAINT [PK_dbo.Homework] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[Homework] (HomeworkTitle, Department, CourseNumber, Priority, Notes, DueDate) VALUES
    ('Lab5', 'CS', '460', 1,  'MVC with simple database','2019-11-05 22:00:00'),
    ('Lab6', 'CS', '460', 1,  'MVC with pre-existing database','2019-11-12 22:00:00'),
	('Lab7', 'CS', '460', 1,  'MVC AJAX single page app','2019-11-19 22:00:00'),
	('Lab8', 'CS', '460', 1,  'MVC Multitable relational database', '2019-11-26 22:00:00'),
	('Lab8', 'CS', '460', 1,  'MVC Cloud Deployment', '2019-12-02 22:00:00')
GO