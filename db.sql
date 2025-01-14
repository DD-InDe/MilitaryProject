USE [master]
GO
/****** Object:  Database [MilitaryConscriptionDatabase]    Script Date: 15.01.2025 0:42:12 ******/
CREATE DATABASE [MilitaryConscriptionDatabase]
GO
USE [MilitaryConscriptionDatabase]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 15.01.2025 0:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Description] [nvarchar](200) NULL,
	[CategoryId] [int] NOT NULL,
	[CategoryKey] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Conscript]    Script Date: 15.01.2025 0:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conscript](
	[PassportId] [int] NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[MiddleName] [nvarchar](100) NULL,
	[BirthDate] [date] NULL,
	[RegistrationDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[PassportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConscriptDocument]    Script Date: 15.01.2025 0:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConscriptDocument](
	[ConscriptDocumentId] [int] IDENTITY(1,1) NOT NULL,
	[ConscriptId] [int] NULL,
	[DocumentFile] [varbinary](max) NULL,
	[DocumentName] [nvarchar](200) NULL,
	[Description] [nvarchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[ConscriptDocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConscriptionCommission]    Script Date: 15.01.2025 0:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConscriptionCommission](
	[ConscriptionCommissionId] [int] IDENTITY(1,1) NOT NULL,
	[CreateDate] [date] NULL,
	[WorksUntilDate] [date] NULL,
	[Protocol] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ConscriptionCommissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConscriptionCommissionEmployee]    Script Date: 15.01.2025 0:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConscriptionCommissionEmployee](
	[ConscriptionCommissionEmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[ConscriptionCommissionId] [int] NULL,
	[EmployeeId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ConscriptionCommissionEmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 15.01.2025 0:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[PassportId] [int] NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[MiddleName] [nvarchar](100) NULL,
	[BirthDate] [date] NULL,
	[PositionId] [int] NULL,
	[Login] [nvarchar](100) NULL,
	[Password] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[PassportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicalCommission]    Script Date: 15.01.2025 0:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalCommission](
	[MilitaryDraftNoticeId] [int] NOT NULL,
	[HealthComplaints] [nvarchar](500) NULL,
	[Diagnoses] [nvarchar](500) NULL,
	[Note] [nvarchar](200) NULL,
	[Confirmed] [bit] NULL,
	[CategoryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MilitaryDraftNoticeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MilitaryDraftNotice]    Script Date: 15.01.2025 0:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MilitaryDraftNotice](
	[MilitaryDraftNoticeId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Address] [nvarchar](200) NULL,
	[ConscriptId] [int] NULL,
	[ConscriptionCommissionId] [int] NULL,
	[Time] [time](7) NULL,
	[ResultId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MilitaryDraftNoticeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passport]    Script Date: 15.01.2025 0:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passport](
	[PassportId] [int] IDENTITY(1,1) NOT NULL,
	[Serial] [int] NULL,
	[Number] [int] NULL,
	[IssuedBy] [nvarchar](200) NULL,
	[IssuedDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[PassportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 15.01.2025 0:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[PositionId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Result]    Script Date: 15.01.2025 0:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[ResultId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ResultId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Category] ([Description], [CategoryId], [CategoryKey]) VALUES (N'Годен к военной службе', 1, N'А')
INSERT [dbo].[Category] ([Description], [CategoryId], [CategoryKey]) VALUES (N'Годен с незначительными ограничениями', 2, N'Б')
INSERT [dbo].[Category] ([Description], [CategoryId], [CategoryKey]) VALUES (N'Ограниченно годен', 3, N'В')
INSERT [dbo].[Category] ([Description], [CategoryId], [CategoryKey]) VALUES (N'Временно не годен
', 4, N'Г')
INSERT [dbo].[Category] ([Description], [CategoryId], [CategoryKey]) VALUES (N'Не годен
', 5, N'Д')
GO
INSERT [dbo].[Conscript] ([PassportId], [FirstName], [LastName], [MiddleName], [BirthDate], [RegistrationDate]) VALUES (5, N'Иван', N'Иванов', N'Иванович', CAST(N'2000-06-15' AS Date), CAST(N'2024-06-06' AS Date))
GO
SET IDENTITY_INSERT [dbo].[ConscriptionCommission] ON 

INSERT [dbo].[ConscriptionCommission] ([ConscriptionCommissionId], [CreateDate], [WorksUntilDate], [Protocol]) VALUES (2, CAST(N'2025-01-11' AS Date), CAST(N'2025-02-01' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[ConscriptionCommission] OFF
GO
SET IDENTITY_INSERT [dbo].[ConscriptionCommissionEmployee] ON 

INSERT [dbo].[ConscriptionCommissionEmployee] ([ConscriptionCommissionEmployeeId], [ConscriptionCommissionId], [EmployeeId]) VALUES (2, 2, 3)
INSERT [dbo].[ConscriptionCommissionEmployee] ([ConscriptionCommissionEmployeeId], [ConscriptionCommissionId], [EmployeeId]) VALUES (3, 2, 2)
INSERT [dbo].[ConscriptionCommissionEmployee] ([ConscriptionCommissionEmployeeId], [ConscriptionCommissionId], [EmployeeId]) VALUES (4, 2, 1)
INSERT [dbo].[ConscriptionCommissionEmployee] ([ConscriptionCommissionEmployeeId], [ConscriptionCommissionId], [EmployeeId]) VALUES (5, 2, 4)
SET IDENTITY_INSERT [dbo].[ConscriptionCommissionEmployee] OFF
GO
INSERT [dbo].[Employee] ([PassportId], [FirstName], [LastName], [MiddleName], [BirthDate], [PositionId], [Login], [Password]) VALUES (1, N'Никита', N'Федькин', N'Александрович', CAST(N'1991-01-12' AS Date), 1, N'log1', N'pas1')
INSERT [dbo].[Employee] ([PassportId], [FirstName], [LastName], [MiddleName], [BirthDate], [PositionId], [Login], [Password]) VALUES (2, N'Антон', N'Редькин', N'Витальевич', CAST(N'1990-03-04' AS Date), 2, N'log2', N'pas2')
INSERT [dbo].[Employee] ([PassportId], [FirstName], [LastName], [MiddleName], [BirthDate], [PositionId], [Login], [Password]) VALUES (3, N'Марина', N'Баженова', N'Геннадьевна', CAST(N'1986-02-02' AS Date), 3, N'log3', N'pas3')
INSERT [dbo].[Employee] ([PassportId], [FirstName], [LastName], [MiddleName], [BirthDate], [PositionId], [Login], [Password]) VALUES (4, N'Анатолий', N'Лихой', NULL, CAST(N'2000-10-12' AS Date), 4, N'log4', N'pas4')
INSERT [dbo].[Employee] ([PassportId], [FirstName], [LastName], [MiddleName], [BirthDate], [PositionId], [Login], [Password]) VALUES (6, N'Админ', N'Админ', NULL, CAST(N'2000-04-15' AS Date), 5, N'admin', N'admin')
GO
INSERT [dbo].[MedicalCommission] ([MilitaryDraftNoticeId], [HealthComplaints], [Diagnoses], [Note], [Confirmed], [CategoryId]) VALUES (2, N'нет', N'нет', NULL, 0, 1)
INSERT [dbo].[MedicalCommission] ([MilitaryDraftNoticeId], [HealthComplaints], [Diagnoses], [Note], [Confirmed], [CategoryId]) VALUES (3, N'нет', N'нет', N'хороший мальчик', 0, 1)
GO
SET IDENTITY_INSERT [dbo].[MilitaryDraftNotice] ON 

INSERT [dbo].[MilitaryDraftNotice] ([MilitaryDraftNoticeId], [Date], [Address], [ConscriptId], [ConscriptionCommissionId], [Time], [ResultId]) VALUES (2, CAST(N'2025-01-24' AS Date), N'ул. Ворошилова', 5, 2, CAST(N'16:00:00' AS Time), 1)
INSERT [dbo].[MilitaryDraftNotice] ([MilitaryDraftNoticeId], [Date], [Address], [ConscriptId], [ConscriptionCommissionId], [Time], [ResultId]) VALUES (3, CAST(N'2025-01-15' AS Date), N'Ворошилова 17а', 5, 2, CAST(N'00:14:51' AS Time), 3)
SET IDENTITY_INSERT [dbo].[MilitaryDraftNotice] OFF
GO
SET IDENTITY_INSERT [dbo].[Passport] ON 

INSERT [dbo].[Passport] ([PassportId], [Serial], [Number], [IssuedBy], [IssuedDate]) VALUES (1, 1234, 123456, N'ГУ МВД', CAST(N'2018-01-12' AS Date))
INSERT [dbo].[Passport] ([PassportId], [Serial], [Number], [IssuedBy], [IssuedDate]) VALUES (2, 1234, 123457, N'ГУ МВД', CAST(N'2018-01-12' AS Date))
INSERT [dbo].[Passport] ([PassportId], [Serial], [Number], [IssuedBy], [IssuedDate]) VALUES (3, 1234, 123458, N'ГУ МВД', CAST(N'2018-01-12' AS Date))
INSERT [dbo].[Passport] ([PassportId], [Serial], [Number], [IssuedBy], [IssuedDate]) VALUES (4, 1234, 123459, N'ГУ МВД', CAST(N'2018-01-12' AS Date))
INSERT [dbo].[Passport] ([PassportId], [Serial], [Number], [IssuedBy], [IssuedDate]) VALUES (5, 1234, 123433, N'ГУ МВД', CAST(N'2025-01-11' AS Date))
INSERT [dbo].[Passport] ([PassportId], [Serial], [Number], [IssuedBy], [IssuedDate]) VALUES (6, 1234, 123456, N'ГУ МВД', CAST(N'2018-01-12' AS Date))
SET IDENTITY_INSERT [dbo].[Passport] OFF
GO
SET IDENTITY_INSERT [dbo].[Position] ON 

INSERT [dbo].[Position] ([PositionId], [Name]) VALUES (1, N'Секретарь')
INSERT [dbo].[Position] ([PositionId], [Name]) VALUES (2, N'Председатель')
INSERT [dbo].[Position] ([PositionId], [Name]) VALUES (3, N'Заместитель')
INSERT [dbo].[Position] ([PositionId], [Name]) VALUES (4, N'Врач')
INSERT [dbo].[Position] ([PositionId], [Name]) VALUES (5, N'Администратор')
SET IDENTITY_INSERT [dbo].[Position] OFF
GO
SET IDENTITY_INSERT [dbo].[Result] ON 

INSERT [dbo].[Result] ([ResultId], [Description]) VALUES (1, N'Полное освобождение от военной службы по результатам медицинского обследования')
INSERT [dbo].[Result] ([ResultId], [Description]) VALUES (2, N'Зачисление призывника в запас')
INSERT [dbo].[Result] ([ResultId], [Description]) VALUES (3, N'Призыв, согласно протоколу')
INSERT [dbo].[Result] ([ResultId], [Description]) VALUES (4, N'Предоставление временной отсрочки от военной службы')
SET IDENTITY_INSERT [dbo].[Result] OFF
GO
ALTER TABLE [dbo].[MedicalCommission] ADD  DEFAULT ((0)) FOR [Confirmed]
GO
ALTER TABLE [dbo].[Conscript]  WITH CHECK ADD FOREIGN KEY([PassportId])
REFERENCES [dbo].[Passport] ([PassportId])
GO
ALTER TABLE [dbo].[ConscriptDocument]  WITH CHECK ADD FOREIGN KEY([ConscriptId])
REFERENCES [dbo].[Conscript] ([PassportId])
GO
ALTER TABLE [dbo].[ConscriptionCommissionEmployee]  WITH CHECK ADD FOREIGN KEY([ConscriptionCommissionId])
REFERENCES [dbo].[ConscriptionCommission] ([ConscriptionCommissionId])
GO
ALTER TABLE [dbo].[ConscriptionCommissionEmployee]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([PassportId])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([PassportId])
REFERENCES [dbo].[Passport] ([PassportId])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([PositionId])
REFERENCES [dbo].[Position] ([PositionId])
GO
ALTER TABLE [dbo].[MedicalCommission]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[MedicalCommission]  WITH CHECK ADD FOREIGN KEY([MilitaryDraftNoticeId])
REFERENCES [dbo].[MilitaryDraftNotice] ([MilitaryDraftNoticeId])
GO
ALTER TABLE [dbo].[MilitaryDraftNotice]  WITH CHECK ADD FOREIGN KEY([ConscriptId])
REFERENCES [dbo].[Conscript] ([PassportId])
GO
ALTER TABLE [dbo].[MilitaryDraftNotice]  WITH CHECK ADD FOREIGN KEY([ConscriptionCommissionId])
REFERENCES [dbo].[ConscriptionCommission] ([ConscriptionCommissionId])
GO
ALTER TABLE [dbo].[MilitaryDraftNotice]  WITH CHECK ADD FOREIGN KEY([ResultId])
REFERENCES [dbo].[Result] ([ResultId])
GO
USE [master]
GO
ALTER DATABASE [MilitaryConscriptionDatabase] SET  READ_WRITE 
GO
