﻿/*    ==Scripting Parameters==



	Source Server Version : SQL Server 2016 (13.0.4001)

	Source Database Engine Edition : Microsoft SQL Server Express Edition

	Source Database Engine Type : Standalone SQL Server



	Target Server Version : SQL Server 2017

	Target Database Engine Edition : Microsoft SQL Server Standard Edition

	Target Database Engine Type : Standalone SQL Server

*/



GO

/****** Object:  Table [dbo].[FOLLOW]    Script Date: 9/29/17 12:55:00 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[FOLLOW](

	[FOLLOWID] [int] NOT NULL,

	[USERID] [int] NOT NULL,

	[FRIENDID] [int] NOT NULL,

	[SFB1] [varchar](100) NULL,

	[SFB2] [varchar](100) NULL,

	[SFB3] [varchar](100) NULL,

	[SFB4] [varchar](100) NULL,

	[SFB5] [varchar](100) NULL,

	[SFB6] [varchar](100) NULL,

 CONSTRAINT [PK_FOLLOW] PRIMARY KEY CLUSTERED 

(

	[FOLLOWID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[FUID]    Script Date: 9/29/17 12:55:03 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[FUID](

	[ID] [int] NOT NULL,

	[FRIENDID] [int] NOT NULL,

	[BLOCK] [bit] NOT NULL,

	[USERID] [int] NOT NULL,

 CONSTRAINT [PK_FUID] PRIMARY KEY CLUSTERED 

(

	[ID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[LVIDEO]    Script Date: 9/29/17 12:55:03 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[LVIDEO](

	[ID] [int] NOT NULL,

	[V1] [varchar](100) NULL,

	[V2] [varchar](100) NULL,

	[V3] [varchar](100) NULL,

	[V4] [varchar](100) NULL,

	[V6] [varchar](100) NULL,

 CONSTRAINT [PK_LVIDEO] PRIMARY KEY CLUSTERED 

(

	[ID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[MSLID]    Script Date: 9/29/17 12:55:03 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[MSLID](

	[ID] [int] NOT NULL,

	[NAME] [varchar](20) NULL,

	[LINK] [varchar](50) NULL,

	[LOGOPIC] [image] NULL,

 CONSTRAINT [PK_MSLID] PRIMARY KEY CLUSTERED 

(

	[ID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[SEQURITY]    Script Date: 9/29/17 12:55:03 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[SEQURITY](

	[ID] [int] NOT NULL,

	[UserName] [varchar](20) NOT NULL,

	[Password] [varchar](20) NOT NULL,

 CONSTRAINT [PK_SEQURITY] PRIMARY KEY CLUSTERED 

(

	[ID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[UCLT]    Script Date: 9/29/17 12:55:03 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[UCLT](

	[ID] [int] NOT NULL,

	[UserID] [int] NOT NULL,

	[MLSID] [int] NOT NULL,

	[URL] [varchar](120) NULL,

 CONSTRAINT [PK_UCLTpaid] PRIMARY KEY CLUSTERED 

(

	[ID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[USERS]    Script Date: 9/29/17 12:55:03 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[USERS](

	[ID] [int] NOT NULL,

	[NAME] [varchar](50) NOT NULL,

	[DOB] [date] NOT NULL,

	[EMAIL] [varchar](50) NOT NULL,

	[SecurityQuestion] [varchar](120) NULL,

	[SecurityAnswer] [varchar](50) NULL,

	[PHONE] [varchar](10) NULL,

	[ADDRESS] [nvarchar](70) NOT NULL,

	[STATE/PROVINCE] [varchar](2) NULL,

	[COUNTRY] [varchar](50) NULL,

	[USERTYPE] [numeric](1, 0) NULL,

	[BAN] [bit] NULL,

	[CREATEDATE] [datetime2](7) NULL,

	[LASTONDATE] [datetime2](7) NULL,

 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 

(

	[ID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]

GO

ALTER TABLE [dbo].[USERS] ADD  CONSTRAINT [DF_USERS_USERTYPE]  DEFAULT ((0)) FOR [USERTYPE]

GO

ALTER TABLE [dbo].[FOLLOW]  WITH CHECK ADD  CONSTRAINT [FK_FOLLOWfriendid_USERid] FOREIGN KEY([FRIENDID])

REFERENCES [dbo].[USERS] ([ID])

GO

ALTER TABLE [dbo].[FOLLOW] CHECK CONSTRAINT [FK_FOLLOWfriendid_USERid]

GO

ALTER TABLE [dbo].[FOLLOW]  WITH CHECK ADD  CONSTRAINT [FK_FOLLOWuserid_USERid] FOREIGN KEY([USERID])

REFERENCES [dbo].[USERS] ([ID])

GO

ALTER TABLE [dbo].[FOLLOW] CHECK CONSTRAINT [FK_FOLLOWuserid_USERid]

GO

ALTER TABLE [dbo].[FUID]  WITH CHECK ADD  CONSTRAINT [FK_FUIDFriendID_USERid] FOREIGN KEY([ID])

REFERENCES [dbo].[USERS] ([ID])

GO

ALTER TABLE [dbo].[FUID] CHECK CONSTRAINT [FK_FUIDFriendID_USERid]

GO

ALTER TABLE [dbo].[FUID]  WITH CHECK ADD  CONSTRAINT [FK_FUIDuserid_USERid] FOREIGN KEY([USERID])

REFERENCES [dbo].[USERS] ([ID])

GO

ALTER TABLE [dbo].[FUID] CHECK CONSTRAINT [FK_FUIDuserid_USERid]

GO

ALTER TABLE [dbo].[LVIDEO]  WITH CHECK ADD  CONSTRAINT [FK_LVIDEOid_USERid] FOREIGN KEY([ID])

REFERENCES [dbo].[USERS] ([ID])

GO

ALTER TABLE [dbo].[LVIDEO] CHECK CONSTRAINT [FK_LVIDEOid_USERid]

GO

ALTER TABLE [dbo].[SEQURITY]  WITH CHECK ADD  CONSTRAINT [FK_SEQURITYid_USERid] FOREIGN KEY([ID])

REFERENCES [dbo].[USERS] ([ID])

GO

ALTER TABLE [dbo].[SEQURITY] CHECK CONSTRAINT [FK_SEQURITYid_USERid]

GO

ALTER TABLE [dbo].[UCLT]  WITH CHECK ADD  CONSTRAINT [FK_UCLTmls_MLSid] FOREIGN KEY([MLSID])

REFERENCES [dbo].[MSLID] ([ID])

GO

ALTER TABLE [dbo].[UCLT] CHECK CONSTRAINT [FK_UCLTmls_MLSid]

GO

ALTER TABLE [dbo].[UCLT]  WITH CHECK ADD  CONSTRAINT [FK_UCLTuser_USERSid] FOREIGN KEY([UserID])

REFERENCES [dbo].[USERS] ([ID])

GO

ALTER TABLE [dbo].[UCLT] CHECK CONSTRAINT [FK_UCLTuser_USERSid]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Followed Users List' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FOLLOW'

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Video Links Table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LVIDEO'

GO