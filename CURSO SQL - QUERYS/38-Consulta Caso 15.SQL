use SBODemoBR
go


--SELECIONANDO OS CAMPOS

SELECT	T0.CardCode as 'Código do Cliente',
		T0.CardName as 'Nome do Cliente',
		T0.DocNum as 'Número do Pagamento',
		T1.SumApplied as 'Pago até a Nota Fiscal',
		T0.DocDate as 'Data do Pagamento',
		T2.DocNum as 'Número da Fatura',
		T2.DocDate as 'Data da Fatura'

--SELECIONANDO AS TABELAS
FROM	dbo.ORCT T0
		INNER JOIN dbo.RCT2 T1
			ON T0.DocNum = T1.DocNum
		INNER JOIN dbo.OINV T2
			ON T1.DocEntry = T2.DocEntry

--CONDIÇÕES

WHERE	T0.DocDate >= [%0]
		AND T0.DocDate <= [%1]