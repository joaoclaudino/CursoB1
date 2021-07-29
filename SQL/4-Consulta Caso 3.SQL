use SBODemoBR 
 
go 
 

SELECT GetDate()
 
go 
 
Select DatePart(weekday,GetDate()) - 2

 
go 
 

select docdate from ordr
 
go 
 

SELECT datediff(dd,'2012/04/10','2012/07/15')
 
go 
 


SELECT T0.docdate                  AS 'Número do Doc',
       T0.cardcode                 AS 'Código do cliente/fornecedor',
       T0.cardname                 AS 'Nome do cliente/fornecedor',
       T0.numatcard                AS 'Número de referência do PN',
       T0.doccur                   AS 'Moeda',
       ( T0.doctotal - T0.vatsum ) AS 'TOTAL',
	   Datediff(dd, T0.docdate, Getdate()),
	   Datediff(dd, T0.docdate, Getdate()),
	   Datediff(dd, T0.docdate, convert(varchar, '01/02/2012', 103)),
	   Datediff(dd, T0.docdate, convert(varchar, '01/02/2012', 103))
FROM   
	dbo.ordr T0
WHERE  
	(
		Datediff(dd, T0.docdate, Getdate()) > 0
		AND Datediff(dd, T0.docdate, Getdate()) < 8 
	)
	or
	(
		Datediff(dd, T0.docdate, convert(varchar, '01/02/2012', 103)) > 0
		AND Datediff(dd, T0.docdate, convert(varchar, '01/02/2012', 103)) < 8 
	)
 
go 
 

SELECT T0.docdate                  AS 'Número do Doc',
       T0.cardcode                 AS 'Código do cliente/fornecedor',
       T0.cardname                 AS 'Nome do cliente/fornecedor',
       T0.numatcard                AS 'Número de referência do PN',
       T0.doccur                   AS 'Moeda',
       ( T0.doctotal - T0.vatsum ) AS 'TOTAL'
FROM   dbo.ordr T0
WHERE
	(
		Datediff(dd, T0.docdate, Getdate()) > 0
		AND Datediff(dd, T0.docdate, Getdate()) < 8 
	)
	or
	(
		Datediff(dd, T0.docdate, convert(varchar, '01/02/2012', 103)) > 0
		AND Datediff(dd, T0.docdate, convert(varchar, '01/02/2012', 103)) < 8 
	)