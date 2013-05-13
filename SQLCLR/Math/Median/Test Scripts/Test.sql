--Test 1 value see if any errors occur
select 
dbo.Median(x.y)
from
(
	select 1 as y
)x
GO

--Test Accuracy
select 
dbo.Median(x.y)
from
(
	select 1 as y
	union all
	select 2 as y
)x
GO

--Test on database table
SELECT dbo.Median(LineTotal) FROM Sales.SalesOrderDetail


