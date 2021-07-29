
SELECT GetDate()

Select DatePart(weekday,GetDate()) - 2



select docdate from ordr


SELECT datediff(dd,'2012/04/10','2012/07/15')



SELECT T0.docdate                  AS 'Número do Doc',
       T0.cardcode                 AS 'Código do cliente/fornecedor',
       T0.cardname                 AS 'Nome do cliente/fornecedor',
       T0.numatcard                AS 'Número de referência do PN',
       T0.doccur                   AS 'Moeda',
       ( T0.doctotal - T0.vatsum ) AS 'TOTAL'
FROM   dbo.ordr T0
WHERE  Datediff(dd, T0.docdate, Getdate()) > 0
       AND Datediff(dd, T0.docdate, Getdate()) < 8 

------------------------------------------------------------------------------

SELECT T0.docdate                  AS 'Número do Doc',
       T0.cardcode                 AS 'Código do cliente/fornecedor',
       T0.cardname                 AS 'Nome do cliente/fornecedor',
       T0.numatcard                AS 'Número de referência do PN',
       T0.doccur                   AS 'Moeda',
       ( T0.doctotal - T0.vatsum ) AS 'TOTAL'
FROM   dbo.ordr T0
WHERE  Datediff(dd, T0.docdate, '2012/07/15') > 0
       AND Datediff(dd, T0.docdate, '2012/07/15') < 8 