Some SQL-CLR functions that I've created so far.


To get started, the database will need to be setup to be Trustworthy, and CLR Enabled.
For example:

ALTER DATABASE AdventureWorks2012 SET TRUSTWORTHY ON;

sp_configure 'clr enabled',1
go
RECONFIGURE
go
sp_configure 'clr enabled'
go

