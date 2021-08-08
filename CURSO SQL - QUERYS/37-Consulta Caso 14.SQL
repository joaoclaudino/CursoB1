use SBODemoBR
go


--SELECIONANDO OS CAMPOS


SELECT TOP 5	T0.ShortName									AS 'Cliente',
				MAX(T2.CardName)								AS'Nome do Cliente',
				SUM(ISNULL(T0.Debit,0) - ISNULL(T0.Credit,0))	AS 'Quantidade'

--SELECIONANDO AS TABELAS

FROM			dbo.JDT1 T0
				INNER JOIN dbo.OJDT T1
					ON T1.TransId = T0.TransId	
						AND T0.TransType IN ('13','14')
				INNER JOIN dbo.OCRD T2
					ON T2.CardCode = T0.ShortName

--CONDIÇÕES	


WHERE T1.RefDate >= [%0]
	AND T1.RefDate <= [%1]

GROUP BY T0.ShortName
ORDER BY SUM(ISNULL(T0.Debit,0) - ISNULL(T0.Credit,0)) DESC