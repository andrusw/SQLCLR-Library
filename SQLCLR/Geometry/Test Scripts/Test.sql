DECLARE @a POINT
DECLARE @b POINT
DECLARE @c POINT

DECLARE @p POINT3D
DECLARE @q POINT3D
DECLARE @r POINT3D



--Centroid of Triangle (-1,-3)(2,1)(8,-4) Ans: (3,-2)
SET @a = '-1:-3'
SET @b = '2:1'
SET @c = '8:-4'

select CAST(dbo.CentroidOfTriangle(@a,@b,@c) as varchar)

--Distance between two points (-1,1)(-2,2) Ans: sqrt of 2

SET @a = '-1:1'
SET @b = '-2:2'

select dbo.DistanceBetweenTwoPoints(@a,@b)

--Distance between two points 3D (1,2,3)(1,3,2) Ans: sqrt(2)
SET @p = '1:2:3'
SET @q = '1:3:2'

select dbo.DistanceBetweenTwoPoints3D(@p,@q)

--Midpoint (-1,-3)(-5,-7) Ans: (-3,-5)
SET @a = '-1:-3'
SET @b = '-5:-7'

select CAST(dbo.MidPoint(@a,@b) as varchar)


--Midpoint3D (1,2,3)(3,2,1) Ans: (2,2,2)
SET @q = '3:2:1'

select CAST(dbo.MidPoint3D(@p,@q)as varchar)

--PerpendicularBisecort (5,7)(6,6) Ans: y = x + 1
SET @a = '5:7'
SET @b = '6:6'

select dbo.PerpendicularBisector(@a,@b)

--TODO: FIX
--Perpendicular Length (4,3) on line x + 2y + 5 = 0  Ans: 3
SET @a = '4:3'
select dbo.PerpendicularLength(@a,1,2,5)


--Point Slope (-3,2) slope of 2 Ans:    y = 2x + 8
SET @a = '-3:2'
select dbo.PointSlope(@a,2)

--Ratio3D Externally (1,2,3)(1,2,3) ratio: 1:2  Ans: (1,2,3)
SET @p = '1:2:3'
select CAST(dbo.Ratio3DExternally(@p,@p,1,2) as varchar)


--Ratio3D Internally (1,3,5)(2,4,6) ratio 2:3  
SET @p = '1:3:5'
SET @q = '2:4:6'

select CAST(dbo.Ratio3DInternally(@p,@q,2,3) as varchar)



