CREATE TABLE [dbo].[USERS] (
    [ID]       INT           NOT NULL,
    [NAME]     VARCHAR (50)  NOT NULL,
    [DOB]      DATE          NULL,
    [EMAIL]    VARCHAR (50)  NULL,
    [PHONE]    NUMERIC (10)  NULL,
    [ADDRESS]  NVARCHAR (70) NULL,
    [USERTYPE] NUMERIC (1)   NULL,
    [BAN]      BIT           NULL,
    [Password] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);

