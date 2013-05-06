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



To deploy one of the sql project(s), just right-click the project and select "Publish..."
Set the target database connection by clicking on the "Edit..." button.
Set your connection (and authentication) to the sql server and database where you will want this dll deployed.
Then publish.



