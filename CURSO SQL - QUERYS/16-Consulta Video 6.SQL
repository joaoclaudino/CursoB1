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






















