CREATE TABLE [Courses] (
	CoursID int NOT NULL,
	Name nvarchar(100) NOT NULL,
	Description nvarchar(4000) NULL,
	Price money NOT NULL,
  CONSTRAINT [PK_COURSES_CoursID] PRIMARY KEY CLUSTERED
  (
  [CoursID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Schedule] (
	ScheduleID int NOT NULL,
	CoursID int NOT NULL,
	StartDate datetime NOT NULL,
	EndDate datetime NOT NULL,
  CONSTRAINT [PK_SCHEDULE_ScheduleID] PRIMARY KEY CLUSTERED
  (
  [ScheduleID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF),
  CONSTRAINT FK_Schedule_CoursID_Courses FOREIGN KEY (CoursID)
	REFERENCES Courses(CoursID)

)
GO



