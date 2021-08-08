use SBODemoBR
go

SELECT T0.cardcode,
       Max(T0.doctotal) 'Total'
FROM   dbo.oinv T0
WHERE  T0.cardcode LIKE '[%0]%'
GROUP  BY T0.cardcode
ORDER  BY Max(T0.doctotal) DESC 


