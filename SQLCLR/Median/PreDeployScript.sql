--ALTER DATABASE AdventureWorks2012 SET TRUSTWORTHY ON;

--sp_configure 'clr enabled',1
--go
--RECONFIGURE
--go
--sp_configure 'clr enabled'
--go

IF EXISTS (SELECT name FROM sysobjects WHERE name = 'Median')
   DROP AGGREGATE Median
go

IF EXISTS (SELECT name FROM sys.assemblies WHERE name = 'SQLCLR_Library')
   DROP ASSEMBLY SQLCLR_Library
go


CREATE ASSEMBLY SQLCLR_Library
FROM 'C:\Median.dll'
WITH PERMISSION_SET = SAFE
GO 

CREATE AGGREGATE dbo.Median
(@input float)
RETURNS float
EXTERNAL NAME SQLCLR_Library.Median
