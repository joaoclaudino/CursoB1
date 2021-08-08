use SBODemoBR
go


SELECT T0.docnum                              AS 'Número do Doc',
       T0.docdate                             AS 'Data',
       Datediff(dd, T0.docdate, '2012/07/30') AS 'DayDiff',
       T0.cardcode                            AS 'Código do Cliente',
       T0.cardname                            AS 'Nome do Cliente',
       T0.numatcard                           AS 'Número de referência do PN',
       ( T0.doctotal - T0.vatsum )            AS 'Total',
       T1.slpname
FROM   dbo.ordr T0
       INNER JOIN dbo.oslp T1
               ON T1.slpcode = T0.slpcode
WHERE  Datediff(mm, T0.docdate, '2012/07/30') BETWEEN 1 AND 7 