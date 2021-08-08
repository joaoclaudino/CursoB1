use SBODemoBR
go

--SELECIONANDO OS CAMPOS

SELECT DISTINCT T0.ItemCode,
				T2.TaxDate,
				T2.CardName

--SELECIONANDO OS CAMPOS

FROM	dbo.PCH1 T0
		INNER JOIN dbo.OPCH T2
			ON T2.DocEntry = T0.DocEntry
WHERE	T2.TaxDate > '[%0]'
		AND T0.DocEntry IN (SELECT Max (T1.DocEntry)
							FROM dbo.PCH1 T1
							WHERE T0.ItemCode = T1.ItemCode
							GROUP BY T1.ItemCode)

