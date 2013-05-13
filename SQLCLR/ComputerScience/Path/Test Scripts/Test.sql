declare @startNode bigint
declare @endNode bigint
declare @maxNodesToCheck int
declare @pathResult varchar(4000)
declare @distResult float

set @startNode = 222
set @endNode = 444
set @maxNodesToCheck = 100000

exec shortestPath @startNode, @endNode, @maxNodesToCheck, @pathResult output, @distResult output

select @pathResult

select @distResult

