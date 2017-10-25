USE [QDSgames]
GO

insert into MSLID (LOGOPIC) 
SELECT BulkColumn 
FROM Openrowset( Bulk '\\Mac\Home\Documents\GitHub\Honors_Team_Project\qdsgames.com\Pictures\fb.png', Single_Blob) as img

GO

insert into MSLID (LOGOPIC) 
SELECT BulkColumn 
FROM Openrowset( Bulk '\\Mac\Home\Documents\GitHub\Honors_Team_Project\qdsgames.com\Pictures\instagram.png', Single_Blob) as img

GO

insert into MSLID (LOGOPIC) 
SELECT BulkColumn 
FROM Openrowset( Bulk '\\Mac\Home\Documents\GitHub\Honors_Team_Project\qdsgames.com\Pictures\twitch.png', Single_Blob) as img

GO

UPDATE MSLID
SET NAME = 'FACEBOOK', LINK = 'https://www.facebook.com/'
WHERE ID = 1

GO

UPDATE MSLID
SET NAME = 'INSTAGRAM', LINK = 'https://www.instagram.com'
WHERE ID = 2

GO

UPDATE MSLID
SET NAME = 'TWITCH', LINK = 'https://www.twitch.tv/'
WHERE ID = 3

GO