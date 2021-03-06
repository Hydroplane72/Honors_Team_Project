USE [QDSgames]
GO

CREATE ROLE [DBA]
GO
GRANT SELECT TO DBA
GO
GRANT UPDATE TO DBA
GO
GRANT INSERT TO DBA
GO
GRANT BACKUP DATABASE TO DBA
GO
GRANT BACKUP LOG TO DBA
GO
GRANT CREATE DEFAULT TO DBA
GO
GRANT CREATE FUNCTION TO DBA
GO
GRANT CREATE PROCEDURE TO DBA
GO
GRANT CREATE RULE TO DBA
GO
GRANT CREATE TABLE TO DBA
GO
GRANT CREATE VIEW TO DBA
GO
GRANT EXECUTE TO DBA
GO
GRANT REFERENCES TO DBA
GO
GRANT DELETE TO DBA
GO


CREATE ROLE [DB_DEVELOPER]
GO
GRANT SELECT TO DB_DEVELOPER
GO
GRANT UPDATE TO DB_DEVELOPER
GO
GRANT INSERT TO DB_DEVELOPER
GO
GRANT BACKUP DATABASE TO DB_DEVELOPER
GO
GRANT BACKUP LOG TO DB_DEVELOPER
GO
GRANT CREATE DEFAULT TO DB_DEVELOPER
GO
GRANT CREATE FUNCTION TO DB_DEVELOPER
GO
GRANT CREATE PROCEDURE TO DB_DEVELOPER
GO
GRANT CREATE RULE TO DB_DEVELOPER
GO
GRANT CREATE TABLE TO DB_DEVELOPER
GO
GRANT CREATE VIEW TO DB_DEVELOPER
GO
GRANT EXECUTE TO DB_DEVELOPER
GO
GRANT REFERENCES TO DB_DEVELOPER
GO


CREATE ROLE [DBD_CHECK]
GO
GRANT SELECT TO DBD_CHECK
GO

CREATE ROLE [DB_USER]
GO
GRANT EXECUTE TO DB_USER
GO


