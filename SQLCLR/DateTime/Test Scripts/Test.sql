DECLARE @d datetime
DECLARE @u datetime
SET @d = GETDATE()
SET @u = GETUTCDATE()


select dbo.DayOfWeek(@d)
select dbo.DaysInMonth(DATEPART(year,@d),DATEPART(month,@d))

select dbo.FromFileTime(47966940000000000)
select dbo.ToFileTime(@d)

select dbo.FromFileTime(dbo.ToFileTime(@d))

select dbo.FromFileTimeUTC(47966940000000000)
select dbo.ToFileTimeUTC(@u)

select dbo.FromFileTimeUTC(dbo.ToFileTimeUTC(@u))

select dbo.DayOfYear(@d)

select dbo.IsDayLightSavings(@d)
select dbo.IsDayLightSavings(DATEADD(day,183,@d))

select dbo.Ticks(@d)

select dbo.ToUniversalTime(@d)
select dbo.ToLocalTime(@u)

select dbo.ToOADate(@d)
select dbo.FromOADate(dbo.ToOADate(@d))

select dbo.ToBinary(@d)

select dbo.IsLeapYear(DATEPART(year,@d))
select dbo.IsLeapYear(DATEPART(year,DATEADD(year,1,@d)))
select dbo.IsLeapYear(DATEPART(year,DATEADD(year,2,@d)))
select dbo.IsLeapYear(DATEPART(year,DATEADD(year,3,@d)))









