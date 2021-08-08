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






















