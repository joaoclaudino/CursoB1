use SBODemoBR
go

SELECT CASE
         WHEN ( Datediff(dd, T0.refdate, Getdate()) ) >= 90 THEN
           CASE
             WHEN T0.syscred = 0 THEN T0.sysdeb
             WHEN T0.sysdeb = 0 THEN -T0.syscred
           END
       END "90 + DAYS"
FROM   dbo.jdt1 T0
WHERE  T0.shortname LIKE '[%0]%' 