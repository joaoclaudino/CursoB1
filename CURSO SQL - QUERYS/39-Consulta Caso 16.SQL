use SBODemoBR
go


--SELECIONANDO OS CAMPOS

SELECT	T1.CardCode		AS 'Código do Cliente',
		T1.CardName		AS 'Nome Do Cliente',
		T2.SlpName		AS 'Nome do Vendedor',
		T1.DocNum		AS 'Número do Documento',
		T1.DocDate		AS 'Data do Lançamento',
		T1.DocTotal		AS 'Total do Documento',
		T4.DocNum		AS 'Número da Fatura',
		T3.SumApplied	AS 'Pago Até a Nota Fiscal'

--SELECIONANDO AS TABELAS

FROM	dbo.OCRD T0
		INNER JOIN dbo.ORCT T1
			ON T0.CardCode = T1.CardCode
		LEFT JOIN dbo.OSLP T2
			ON T0.SlpCode = T2.SlpCode
		INNER JOIN dbo.RCT2 T3
			ON T3.DocNum = T1.DocNum
		INNER JOIN dbo.OINV T4
			ON T4.DocEntry = T3.DocEntry
				AND T3.InvType = '13'

--CONDIÇÕES

WHERE	T1.DocDate >= [%0]	
		AND T1.DocDate <= [%1]

ORDER BY T1.DocDate