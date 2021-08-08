use SBODemoBR
go

--SELECIONANDO OS CAMPOS

SELECT DISTINCT T0.ItemCode,
				T0.ItemName

--SELECIONANDO AS TABELAS

FROM			dbo.OITM T0
WHERE			T0.SellItem = 'Y'
AND				T0.ItemCode NOT IN
									(
									SELECT DISTINCT T1.ItemCode
									FROM			dbo.DLN1 T1
									INNER JOIN		dbo.ODLN T2
										ON T2.DocEntry = T1.DocEntry
									WHERE DateDiff(dd,T2.DocDate, '2012/08/02')<31
									)
