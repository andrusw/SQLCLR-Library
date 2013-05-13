IF EXISTS (SELECT name FROM sysobjects WHERE name = 'CountVowels')
   DROP AGGREGATE CountVowels
go

IF EXISTS (SELECT name FROM sys.assemblies WHERE name = 'AggregateFunctionDemo')
   DROP ASSEMBLY AggregateFunctionDemo
go


CREATE ASSEMBLY AggregateFunctionDemo
FROM 'C:\VowelCount.dll'
WITH PERMISSION_SET = SAFE
GO 

CREATE AGGREGATE dbo.CountVowels
(@input NVARCHAR(MAX))
RETURNS INT
EXTERNAL NAME AggregateFunctionDemo.CountVowels