USE [master]
GO

IF EXISTS (SELECT name FROM master.sys.databases WHERE name = N'ZTOOLDB')
DROP DATABASE [ZTOOLDB]
GO

CREATE DATABASE ZTOOLDB 
COLLATE Thai_CI_AS_KS
GO 

USE [ZTOOLDB]
GO

IF NOT EXISTS (SELECT name FROM master.sys.database_principals WHERE name = N'ztool_devusr')
DROP LOGIN [ztool_devusr];
CREATE LOGIN [ztool_devusr] WITH PASSWORD = '2NNiw9HyUEPQQw3';  
CREATE USER [ztool_devusr] FROM LOGIN [ztool_devusr];
EXEC sp_addrolemember N'db_owner', N'ztool_devusr';
GO

USE [ZTOOLDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Enterprise](
	[ID] [uniqueidentifier] NOT NULL,
	[EnterpriseID] [nvarchar](10) NOT NULL,
	[EnterpriseName] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [nvarchar](50) NOT NULL,
	[ModifyDate] [datetime] NOT NULL,
	[ModifyBy] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Enterprise] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_EnterpriseID] UNIQUE NONCLUSTERED 
(
	[EnterpriseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_EnterpriseName] UNIQUE NONCLUSTERED 
(
	[EnterpriseName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[EmailLog](
	[ID] [uniqueidentifier] NOT NULL,
	[EnterpriseFK] [uniqueidentifier] NOT NULL,
	[Subject] [nvarchar](250) NOT NULL,
	[FromEmail] [nvarchar](250) NOT NULL,
	[ToEmail] [text] NOT NULL,
	[CcEmail] [text] NULL,
	[BccEmail] [text] NULL,
	[FileAttachment] [text] NULL,
	[SendStatus] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [nvarchar](50) NOT NULL,
	[ModifyDate] [datetime] NOT NULL,
	[ModifyBy] [nvarchar](50) NOT NULL,
	[ExceptionText] [text] NULL,
 CONSTRAINT [PK_EmailLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[EmailLog]  WITH CHECK ADD  CONSTRAINT [FK_EmailLog_Enterprise] FOREIGN KEY([EnterpriseFK])
REFERENCES [dbo].[Enterprise] ([ID])
GO

ALTER TABLE [dbo].[EmailLog] CHECK CONSTRAINT [FK_EmailLog_Enterprise]
GO