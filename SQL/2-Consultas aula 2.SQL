use SBODemoBR 
 
go 
 
SELECT T0.docnum                           AS 'SO.NO',
       T0.docdate                          AS 'Date',
       Datediff(dd, T0.docdate, Getdate()) AS 'DayDiff',
       T0.cardcode                         AS 'Customer Code',
       T0.cardname                         AS 'Custumer Name',
       T0.numatcard                        AS 'Ref/PO No.',
       ( T0.doctotal - T0.vatsum )         AS 'SO Amt',
       T1.slpname
FROM   dbo.ordr T0
       INNER JOIN dbo.oslp T1
               ON T1.slpcode = T0.slpcode
WHERE  Datediff(dd, T0.docdate, Getdate()) BETWEEN 1 AND 7 

go 
 
SELECT 'YES' AS 'Yes/No'
SELECT 10    AS 'No.'
go 
 

SELECT 'YES'                AS 'Yes/No',
       10                   AS 'No.',
       'This is an example' AS 'Content' 
go 
 

SELECT T0.CompnyName
FROM 	OADM T0
go 
 

SELECT T0.compnyname,
       T0.compnyaddr,
       T0.country,
       T0.phone1
FROM   dbo.oadm T0 











