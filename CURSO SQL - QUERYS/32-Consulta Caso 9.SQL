use SBODemoBR
go

--SELECIONANDO OS CAMPOS

SELECT	T0.CardCode,
		T0.CardName,
		(Sum(coalesce(T1.Debit,0)) - SUM(coalesce(T1.Credit,0))) as '2012',
		((SUM(coalesce(T1.Debit,0)) - SUM(coalesce(T1.Credit,0)))/12) AS 'Média de 2012',
		(Sum(coalesce(T2.Debit,0)) - SUM(coalesce(T2.Credit,0))) as '2014',
		((SUM(coalesce(T2.Debit,0)) - SUM(coalesce(T2.Credit,0)))/MONTH('2014/06/03')) AS 'Média de 2014'

--SELECIONANDO OS CAMPOS

FROM	dbo.OCRD T0
LEFT JOIN dbo.JDT1 T1
	ON T1.ShortName = T0.CardCode
AND		Year(T1.DueDate) = 2012
AND		T1.TransType IN('13',
					    '14') 


LEFT JOIN dbo.JDT1 T2
	ON T2.ShortName = T0.CardCode
AND		Year(T2.DueDate) = 2012
AND		T2.TransType IN('13',
					    '14') 

--CONDIÇÕES

WHERE T0.CardType = 'C'
GROUP BY T0.CardCode,T0.CardName



