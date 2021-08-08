use SBODemoBR
go

--SELECIONANDO OS CAMPOS

SELECT  T3.WhsCode													AS 'Código do depósito',
		T1.GroupName												AS 'Nome do Grupo',
		(SUM(ISNULL(T3.Quantity,0)) - SUM(ISNULL(T5.Quantity,0)))	AS 'Quantidade'	,
		(SUM(ISNULL(T3.LineTotal,0)) - SUM(ISNULL(T5.LineTotal,0))) AS 'Total da linha',
		(SUM(ISNULL(T3.LineVat,0)) - SUM(ISNULL(T5.LineVat,0)))		AS 'Total do imposto líquido'

--SELECIONANDO AS TABELAS

FROM	dbo.OCRD T0
		INNER JOIN dbo.OCRG T1
			ON T0.GroupCode = T1.GroupCode
		INNER JOIN dbo.OINV T2
			ON T0.CardCode = T2.CardCode
				AND T2.DocType = 'I'
		INNER JOIN dbo.INV1 T3
			ON T2.DocEntry = T3.DocEntry
		LEFT JOIN dbo.ORIN T4 
			ON T0.CardCode = T4.CardCode
		LEFT JOIN dbo.RIN1 T5
			ON T4.DocEntry = T5.DocEntry
				AND T3.WhsCode = T5.WhsCode

--AGREGAÇÃO
GROUP BY T3.WhsCode,
		 T1.GroupName