--2 & 8 = 4
select dbo.GeometricMean(x.y)
from
(
	select 2 as y
	union all
	select 8 as y
)x
--4 & 1 & 1/32 = 1/2
select dbo.GeometricMean(x.y)
from
(
	select 4 as y
	union all
	select 1 as y
	union all
	select convert(float,1)/32 as y
)x

--1,2,3,4,5 = 2.60517
select dbo.GeometricMean(x.y)
from
(
	select 1 as y
		union all
	select 2 as y
		union all
	select 3 as y
		union all
	select 4 as y
		union all
	select 5 as y
)x



select dbo.GeometricMean(x.y)
from
(
	SELECT Top 1139 convert(float,OrderQty) as y
	FROM Sales.SalesOrderDetail
)x

select dbo.GeometricMean(x.y)
from
(
	SELECT Top 64 convert(float,LineTotal) as y
	FROM Sales.SalesOrderDetail
)x

-----ERROR Arithmetic Overflow
-----We are multiplying numbers, and will end up with a overflow for double/sqldouble
-----SqlDouble Max Value = 1.79E+308 
-----Double Max Value = 1.7976931348623157E+308
--select dbo.GeometricMean(x.y)
--from
--(
--	SELECT Top 1140 convert(float,OrderQty) as y
--	FROM Sales.SalesOrderDetail
--)x
