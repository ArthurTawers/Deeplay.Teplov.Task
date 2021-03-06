USE [PersonnelBase]
GO
/****** Object:  Table [dbo].[Controllers]    Script Date: 09.06.2022 21:36:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Controllers](
	[ID_People] [bigint] NOT NULL,
	[Machine_Info] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Controllers] PRIMARY KEY CLUSTERED 
(
	[ID_People] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Directors]    Script Date: 09.06.2022 21:36:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Directors](
	[ID_People] [bigint] NOT NULL,
	[Department] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Directors] PRIMARY KEY CLUSTERED 
(
	[ID_People] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Divisions]    Script Date: 09.06.2022 21:36:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Divisions](
	[ID_Division] [int] IDENTITY(1,1) NOT NULL,
	[Name_Division] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Divisions] PRIMARY KEY CLUSTERED 
(
	[ID_Division] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Head_Departnent]    Script Date: 09.06.2022 21:36:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Head_Departnent](
	[ID_People] [bigint] NOT NULL,
	[ID_Division] [int] NOT NULL,
 CONSTRAINT [PK_Head_Departnent_1] PRIMARY KEY CLUSTERED 
(
	[ID_People] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[People]    Script Date: 09.06.2022 21:36:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[FIO] [nvarchar](50) NOT NULL,
	[Gender] [nchar](3) NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Worker]    Script Date: 09.06.2022 21:36:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Worker](
	[ID_People] [bigint] NOT NULL,
	[FIO_Directors] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Worker_1] PRIMARY KEY CLUSTERED 
(
	[ID_People] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Controllers] ([ID_People], [Machine_Info]) VALUES (10010, N'Симонов Андрей Петрович')
INSERT [dbo].[Controllers] ([ID_People], [Machine_Info]) VALUES (10013, N'Станок1')
INSERT [dbo].[Controllers] ([ID_People], [Machine_Info]) VALUES (10014, N'Станок2')
INSERT [dbo].[Controllers] ([ID_People], [Machine_Info]) VALUES (10033, N'рук4')
GO
INSERT [dbo].[Directors] ([ID_People], [Department]) VALUES (10010, N'Подразделение 1')
INSERT [dbo].[Directors] ([ID_People], [Department]) VALUES (10017, N'Горячий цех')
INSERT [dbo].[Directors] ([ID_People], [Department]) VALUES (10018, N'Холодный цех')
INSERT [dbo].[Directors] ([ID_People], [Department]) VALUES (10019, N'Заготовочный цех')
INSERT [dbo].[Directors] ([ID_People], [Department]) VALUES (10038, N'ПодразделениеК')
INSERT [dbo].[Directors] ([ID_People], [Department]) VALUES (10044, N'Подразделение 4')
INSERT [dbo].[Directors] ([ID_People], [Department]) VALUES (10048, N'ОтделК')
GO
SET IDENTITY_INSERT [dbo].[Divisions] ON 

INSERT [dbo].[Divisions] ([ID_Division], [Name_Division]) VALUES (1, N'Подразделение 1')
INSERT [dbo].[Divisions] ([ID_Division], [Name_Division]) VALUES (2, N'Подразделение 2')
INSERT [dbo].[Divisions] ([ID_Division], [Name_Division]) VALUES (3, N'Подразделение 3')
INSERT [dbo].[Divisions] ([ID_Division], [Name_Division]) VALUES (4, N'Подразделение 4')
INSERT [dbo].[Divisions] ([ID_Division], [Name_Division]) VALUES (5, N'ОтделК')
INSERT [dbo].[Divisions] ([ID_Division], [Name_Division]) VALUES (6, N'Станок5')
INSERT [dbo].[Divisions] ([ID_Division], [Name_Division]) VALUES (7, N'Департамаент 2')
INSERT [dbo].[Divisions] ([ID_Division], [Name_Division]) VALUES (8, N'Департамаент 3')
SET IDENTITY_INSERT [dbo].[Divisions] OFF
GO
INSERT [dbo].[Head_Departnent] ([ID_People], [ID_Division]) VALUES (10046, 7)
INSERT [dbo].[Head_Departnent] ([ID_People], [ID_Division]) VALUES (10047, 8)
GO
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10010, CAST(N'2000-05-01' AS Date), N'Симонов Арсений Петрович', N'муж')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10011, CAST(N'2000-05-01' AS Date), N'Симонов Андрей Петрович', N'муж')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10013, CAST(N'2000-05-01' AS Date), N'Симонов Андрей Петрович', N'муж')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10014, CAST(N'2000-05-01' AS Date), N'Симонов Андрей Петрович', N'муж')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10017, CAST(N'2000-05-01' AS Date), N'Симонов Андрей Петрович', N'муж')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10018, CAST(N'2000-05-01' AS Date), N'Симонов Андрей Петрович', N'муж')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10019, CAST(N'2000-05-01' AS Date), N'Симонов Андрей Петрович', N'муж')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10022, CAST(N'2000-05-01' AS Date), N'Симонов Андрей Петрович', N'муж')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10023, CAST(N'2005-03-12' AS Date), N'Баранов Александр Юрьевич', N'муж')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10024, CAST(N'2000-03-12' AS Date), N'Кто-тот аокйевич', N'жен')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10025, CAST(N'2002-03-12' AS Date), N'Александр Юрьевич', N'муж')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10026, CAST(N'2002-02-12' AS Date), N'Александр Юрьевич', N'муж')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10027, CAST(N'2002-03-12' AS Date), N'Фио Фио Фио', N'муж')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10028, CAST(N'2002-03-12' AS Date), N'Фиофио', N'жен')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10029, CAST(N'2000-02-12' AS Date), N'фио', N'жен')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10030, CAST(N'2000-03-22' AS Date), N'фио2', N'муж')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10033, CAST(N'2000-03-12' AS Date), N'Андрей', N'жен')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10034, CAST(N'2000-03-12' AS Date), N'Андрей', N'муж')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10037, CAST(N'1999-04-04' AS Date), N'Вася Вася', N'жен')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10038, CAST(N'2000-02-12' AS Date), N'Дирек Дирекович', N'жен')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10039, CAST(N'1998-05-12' AS Date), N'Гражданин Какой-то', N'муж')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10042, CAST(N'2000-05-01' AS Date), N'Симонов Андрей Петрович', N'муж')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10043, CAST(N'2000-05-01' AS Date), N'Симонов Андрей Петрович', N'муж')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10044, CAST(N'2002-08-08' AS Date), N'Олег Георгиевич Смоленков', N'муж')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10045, CAST(N'2000-05-01' AS Date), N'Симонов Андрей Петрович', N'муж')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10046, CAST(N'2000-03-12' AS Date), N'Геогрий Георгиевич', N'муж')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10047, CAST(N'2000-03-12' AS Date), N'Александ Семенов', N'муж')
INSERT [dbo].[People] ([ID], [DateOfBirth], [FIO], [Gender]) VALUES (10048, CAST(N'1999-12-12' AS Date), N'Фио Чела', N'муж')
SET IDENTITY_INSERT [dbo].[People] OFF
GO
INSERT [dbo].[Worker] ([ID_People], [FIO_Directors]) VALUES (10011, N'Станок4')
GO
ALTER TABLE [dbo].[Controllers]  WITH CHECK ADD  CONSTRAINT [FK_Controllers_People] FOREIGN KEY([ID_People])
REFERENCES [dbo].[People] ([ID])
GO
ALTER TABLE [dbo].[Controllers] CHECK CONSTRAINT [FK_Controllers_People]
GO
ALTER TABLE [dbo].[Directors]  WITH CHECK ADD  CONSTRAINT [FK_Directors_People] FOREIGN KEY([ID_People])
REFERENCES [dbo].[People] ([ID])
GO
ALTER TABLE [dbo].[Directors] CHECK CONSTRAINT [FK_Directors_People]
GO
ALTER TABLE [dbo].[Head_Departnent]  WITH CHECK ADD  CONSTRAINT [FK_Head_Departnent_Divisions] FOREIGN KEY([ID_Division])
REFERENCES [dbo].[Divisions] ([ID_Division])
GO
ALTER TABLE [dbo].[Head_Departnent] CHECK CONSTRAINT [FK_Head_Departnent_Divisions]
GO
ALTER TABLE [dbo].[Head_Departnent]  WITH CHECK ADD  CONSTRAINT [FK_Head_Departnent_People] FOREIGN KEY([ID_People])
REFERENCES [dbo].[People] ([ID])
GO
ALTER TABLE [dbo].[Head_Departnent] CHECK CONSTRAINT [FK_Head_Departnent_People]
GO
ALTER TABLE [dbo].[Worker]  WITH CHECK ADD  CONSTRAINT [FK_Worker_People] FOREIGN KEY([ID_People])
REFERENCES [dbo].[People] ([ID])
GO
ALTER TABLE [dbo].[Worker] CHECK CONSTRAINT [FK_Worker_People]
GO
