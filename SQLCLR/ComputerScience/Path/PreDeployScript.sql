-- CreateDemoDatabase.sql
-- creates a database to demo a CLR stored procedure
-- that does shortest path analysis

use master
go

if exists(select * from sys.sysdatabases where name='dbShortPathWithCLR')
  drop database dbShortPathWithCLR
go

create database dbShortPathWithCLR
go

use dbShortPathWithCLR
go

create table tblGraph
(
fromNode bigint not null,
toNode bigint not null,
edgeWeight real not null -- float(24)
)
go

set nocount on
insert into tblGraph values(111,222,1.0)
insert into tblGraph values(111,555,1.0)
insert into tblGraph values(222,111,2.0)
insert into tblGraph values(222,333,1.0)
insert into tblGraph values(222,555,1.0)
insert into tblGraph values(333,666,1.0)
insert into tblGraph values(333,888,1.0)
insert into tblGraph values(444,888,1.0)
insert into tblGraph values(555,111,2.0)
insert into tblGraph values(555,666,1.0)
insert into tblGraph values(666,333,2.0)
insert into tblGraph values(666,777,1.0)
insert into tblGraph values(777,444,2.0)
insert into tblGraph values(777,888,1.0)
go

create nonclustered index idxTblGraphFromNode on tblGraph(fromNode)
go
create nonclustered index idxTblGraphToNode on tblGraph(toNode)
go

alter database dbShortPathWithCLR set trustworthy on  
go
select is_trustworthy_on from sys.databases where name = 'dbShortPathWithCLR'
go

-- end create database statements


