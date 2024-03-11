USE [GerTarefasDB]
GO

/****** Object:  Table [dbo].[LogTasks]    Script Date: 11/03/2024 00:06:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LogTasks](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[History] [nvarchar](500) NOT NULL,
	[Comment] [nvarchar](500) NOT NULL,
	[StatusTask] [int] NOT NULL,
	[TaskID] [int] NOT NULL,
	[UserAccountUserId] [int] NULL,
	[UserName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_LogTasks] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Projects]    Script Date: 11/03/2024 00:06:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Projects](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[TasksProject]    Script Date: 11/03/2024 00:06:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TasksProject](
	[TaskID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[DueDate] [datetime2](7) NOT NULL,
	[Status] [int] NOT NULL,
	[Priority] [int] NOT NULL,
	[Comment] [nvarchar](500) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TasksProject] PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[UsersAccount]    Script Date: 11/03/2024 00:06:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UsersAccount](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[Function] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_UsersAccount] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT (N'') FOR [UserName]
GO

ALTER TABLE [dbo].[TasksProject] ADD  DEFAULT (N'') FOR [UserName]
GO

USE [GerTarefasDB]
GO

INSERT INTO [dbo].[UsersAccount]
           ([UserName]
           ,[Function]
           ,[Email]
           ,[IsActive])
     VALUES
           ('UsuarioGerente',
            'Gerente',
            'ug@email.com',
            1)
GO

INSERT INTO [dbo].[UsersAccount]
           ([UserName]
           ,[Function]
           ,[Email]
           ,[IsActive])
     VALUES
           ('UsuarioAnalista',
            'Analista',
            'ua@email.com',
            1)
GO


