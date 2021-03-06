USE [DB12]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 28/04/2019 12:40:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseTitle] [nvarchar](50) NULL,
	[Section] [nvarchar](50) NULL,
	[InstructorName] [nvarchar](50) NULL,
	[CreditHour] [int] NULL,
	[Id] [int] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Fee]    Script Date: 28/04/2019 12:40:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fee](
	[Id] [int] NOT NULL,
	[FeeStatus] [nvarchar](50) NULL,
	[TotalFees] [int] NULL,
	[Fine] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Instructor]    Script Date: 28/04/2019 12:40:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instructor](
	[InstId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RePassword] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Instructor] PRIMARY KEY CLUSTERED 
(
	[InstId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Login]    Script Date: 28/04/2019 12:40:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[UserType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Result]    Script Date: 28/04/2019 12:40:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[Id] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[ObtainedMarks] [int] NOT NULL,
	[Grade] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 28/04/2019 12:40:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RePassword] [nvarchar](50) NOT NULL,
	[Roll No] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Mobile No] [int] NOT NULL,
	[Department] [nvarchar](50) NOT NULL,
	[Session] [int] NOT NULL,
	[Section] [nvarchar](1) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([CourseId], [CourseTitle], [Section], [InstructorName], [CreditHour], [Id]) VALUES (4, N'Project Management', N'C', N'Sir Samyan Qayyum', 3, NULL)
INSERT [dbo].[Course] ([CourseId], [CourseTitle], [Section], [InstructorName], [CreditHour], [Id]) VALUES (5, N'Project Management', N'B', N'Sir Ahmed Anwar', 2, NULL)
INSERT [dbo].[Course] ([CourseId], [CourseTitle], [Section], [InstructorName], [CreditHour], [Id]) VALUES (7, N'Project Management', N'C', N'Miss Sehar Waqar', 3, 2)
INSERT [dbo].[Course] ([CourseId], [CourseTitle], [Section], [InstructorName], [CreditHour], [Id]) VALUES (8, N'Linear Algebra  ', N'C', N'Miss Sehar Waqar', 1, 2)
SET IDENTITY_INSERT [dbo].[Course] OFF
INSERT [dbo].[Fee] ([Id], [FeeStatus], [TotalFees], [Fine]) VALUES (2, N'Pending', 345678, 0)
SET IDENTITY_INSERT [dbo].[Instructor] ON 

INSERT [dbo].[Instructor] ([InstId], [FirstName], [LastName], [Email], [Password], [RePassword]) VALUES (1, N'rav', N'asdsd', N'rgf', N'43534', N'45454')
SET IDENTITY_INSERT [dbo].[Instructor] OFF
SET IDENTITY_INSERT [dbo].[Login] ON 

INSERT [dbo].[Login] ([id], [Email], [Password], [UserType]) VALUES (1, N'admin', N'1234', N'Admin')
INSERT [dbo].[Login] ([id], [Email], [Password], [UserType]) VALUES (2, N'rabeya@gmail.com', N'12345', N'Student')
INSERT [dbo].[Login] ([id], [Email], [Password], [UserType]) VALUES (3, N'amjad', N'amjad', N'Instructor')
INSERT [dbo].[Login] ([id], [Email], [Password], [UserType]) VALUES (4, N'student', N'123', N'Student')
SET IDENTITY_INSERT [dbo].[Login] OFF
INSERT [dbo].[Result] ([Id], [CourseId], [ObtainedMarks], [Grade]) VALUES (2, 8, 34, N'B+')
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Email], [Password], [RePassword], [Roll No], [Address], [Mobile No], [Department], [Session], [Section]) VALUES (2, N'ffghjdf', N'dfbdfh', N'gdfjgdfj', N'34324', N'3434534', N'4534jkdf', N'djdfgdj', 438345, N'Computer Engineering', 2016, N'C')
SET IDENTITY_INSERT [dbo].[Student] OFF
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Student] FOREIGN KEY([Id])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Student]
GO
ALTER TABLE [dbo].[Fee]  WITH CHECK ADD  CONSTRAINT [FK_Fee_Student] FOREIGN KEY([Id])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[Fee] CHECK CONSTRAINT [FK_Fee_Student]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Course]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Student] FOREIGN KEY([Id])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Student]
GO
