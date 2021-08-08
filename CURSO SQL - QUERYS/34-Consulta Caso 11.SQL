use SBODemoBR
go

--SELECIONANDO OS CAMPOS

SELECT distinct T2.CardCode,
		T2.CardName,
		T1.RefDate,
		T0.BaseRef,
		T0.Debit,
		T0.Credit,
		T0.BalDueDeb,
		T0.BalDueCred


--SELECIONANDO AS TABELAS

FROM	dbo.JDT1 T0
		INNER JOIN dbo.OJDT T1
			ON T0.TransId = T1.TransId
		INNER JOIN dbo.OCRD T2
			ON T2.CardCode = T0.ShortName
		INNER JOIN dbo.OCRG T3
			ON T2.GroupCode = T3.GroupCode
		INNER JOIN dbo.OINV T4
			ON T2.CardCode = T4.CardCode
		INNER JOIN dbo.INV1 T5
			ON T5.DocEntry = T4.DocEntry
		LEFT JOIN dbo.OITM T6
			ON T6.ItemCode = T5.ItemCode
		LEFT JOIN dbo.OITB T7
			ON T7.ItmsGrpCod = T6.ItmsGrpCod

--CONDIÇÃO

WHERE T0.RefDate BETWEEN '[%0]' AND '[%1]'
	AND T0.BalDueDeb != 0
	AND T3.GroupName != '[%2]'
	AND T7.ItmsGrpNam = '[%3]'