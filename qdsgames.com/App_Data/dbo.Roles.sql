/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [QDSgames]
GO
/****** Object:  User [QDSadmin]    Script Date: 10/19/17 11:43:52 AM ******/
CREATE USER [QDSadmin] FOR LOGIN [QDSadmin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [Admin_View]    Script Date: 10/19/17 11:43:53 AM ******/
CREATE ROLE [Admin_View]
GO
/****** Object:  DatabaseRole [DB_Developer]    Script Date: 10/19/17 11:43:53 AM ******/
CREATE ROLE [DB_Developer]
GO
/****** Object:  DatabaseRole [db_User]    Script Date: 10/19/17 11:43:53 AM ******/
CREATE ROLE [db_User]
GO
/****** Object:  DatabaseRole [Friend_View]    Script Date: 10/19/17 11:43:53 AM ******/
CREATE ROLE [Friend_View]
GO
/****** Object:  DatabaseRole [UCLT_View]    Script Date: 10/19/17 11:43:53 AM ******/
CREATE ROLE [UCLT_View]
GO
/****** Object:  DatabaseRole [User_Creator]    Script Date: 10/19/17 11:43:53 AM ******/
CREATE ROLE [User_Creator]
GO
