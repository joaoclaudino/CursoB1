use SBODemoBR 
 
go 
 
SELECT     t1.[CardCode] AS 'Código do cliente/fornecedor',
           t1.[CardName] AS 'Nome do cliente/fornecedor',
           t1.[DocDate]  AS 'Data de lançamento',
           t1.[DocTotal] AS 'Total do documento',
           t0.[ItemCode] AS 'Número do Item'
FROM       [dbo].[INV1] T0
INNER JOIN [dbo].[OINV] T1
ON         t1.[DocEntry] = t0.[DocEntry]
WHERE      (
                      t1.[DocTotal] > (1000))
ORDER BY   t1.[CardCode]