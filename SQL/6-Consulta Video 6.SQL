use SBODemoBR 
 
go 
 
SELECT T0.cardcode AS 'Código do PN',
       T0.docnum   AS 'Doc No.',
       T0.docdate,
       T1.itemcode,
       T1.price    AS 'Preço',
       T1.quantity,
       T1.linetotal
FROM   dbo.oinv T0
       INNER JOIN dbo.inv1 T1
               ON T1.docentry = T0.docentry 
go 
 
SELECT    T0.[cardcode],
          T0.[cardname],
          T0.[balance],
          T1.[docnum],
          T1.[docdate],
          T1.[doctotal]
FROM      dbo.ocrd T0
LEFT JOIN dbo.oinv T1
ON        T0.cardcode = T1.cardcode
WHERE     T0.cardcode < 'C70000'
order by 1
go 
 

SELECT    T0.[cardcode],
          T0.[cardname],
          T0.[balance],
          T1.[docnum],
          T1.[docdate],
          T1.[doctotal]
FROM      dbo.ocrd T0
			RIGHT JOIN dbo.oinv T1 ON  T0.cardcode = T1.cardcode
WHERE     T0.cardcode < 'C70000'














