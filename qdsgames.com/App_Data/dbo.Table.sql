CREATE TABLE [dbo].[USERS] (
    [ID]       INT           NOT NULL,
    [NAME]     VARCHAR (50)  NOT NULL,
    [DOB]      DATE          NOT NULL,
    [EMAIL]    VARCHAR (50)  NOT NULL,
    [PHONE]    NVARCHAR(50)  NULL,
    [ADDRESS]  NVARCHAR (70) NOT NULL,
    [USERTYPE] NUMERIC (1)   NULL,
    [BAN]      BIT           NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);
