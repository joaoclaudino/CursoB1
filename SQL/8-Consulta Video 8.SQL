use SBODemoBR 
 
go 
 
SELECT T0.cardcode      AS 'BP Code',
       T0.cardname      AS 'BP Named',
       Sum(T0.doctotal) AS 'Total'
FROM   dbo.oinv T0
WHERE  T0.cardcode < 'C70000'
GROUP  BY T0.cardcode,
          T0.cardname
order by 1

