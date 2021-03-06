USE [master]
GO
CREATE DATABASE [AdoWebApi]
GO
USE [AdoWebApi]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[DismissalDate] [date] NULL,
	[Function] [nvarchar](50) NULL,
	[HireDate] [date] NOT NULL,
	[RoomId] [int] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 07/09/2021 00:32:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [Name], [Surname], [DismissalDate], [Function], [HireDate], [RoomId]) VALUES (1, N'Mario', N'Rossi', NULL, NULL, CAST(0x90400B00 AS Date), NULL)
INSERT [dbo].[Employees] ([Id], [Name], [Surname], [DismissalDate], [Function], [HireDate], [RoomId]) VALUES (2, N'Giovanni', N'Verdi', CAST(0xFD410B00 AS Date), NULL, CAST(0x7C3B0B00 AS Date), NULL)
INSERT [dbo].[Employees] ([Id], [Name], [Surname], [DismissalDate], [Function], [HireDate], [RoomId]) VALUES (3, N'Fabio', N'Cavallari', NULL, N'FullStack Developer', CAST(0xDA400B00 AS Date), 2)
SET IDENTITY_INSERT [dbo].[Employees] OFF
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([Id], [Name]) VALUES (1, N'Reception')
INSERT [dbo].[Rooms] ([Id], [Name]) VALUES (2, N'Ufficio 1')
INSERT [dbo].[Rooms] ([Id], [Name]) VALUES (3, N'Ufficio 2')
SET IDENTITY_INSERT [dbo].[Rooms] OFF
USE [master]
GO
ALTER DATABASE [AdoWebApi] SET  READ_WRITE 
GO
