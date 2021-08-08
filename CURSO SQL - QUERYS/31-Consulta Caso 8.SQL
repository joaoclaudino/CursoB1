use SBODemoBR
go

SELECT		T0.CardCode,
			T0.CardName,
			(SUM(T1.Debit) - SUM(T1.Credit)) AS 'JULHO', 
			(SUM(T1.Debit) - SUM(T1.Credit)) AS 'Agosto'

FROM		dbo.OCRD T0
LEFT JOIN	dbo.JDT1 T1
	ON T1.ShortName = T0.CardCode
AND			MONTH(T1.DueDate) = 7
or			MONTH(T1.DueDate) = year(GetDate())
AND			T1.TransType IN ('13','14')


LEFT JOIN	dbo.JDT1 T2
	ON	T2.ShortName = T0.CardName
AND			MONTH(T2.DueDate) = 8
or			MONTH(T2.DueDate) = year(GetDate())
AND			T2.TransType IN ('13','14')



WHERE		T0.CardType = 'C'
GROUP BY	T0.CardCode,
			T0.CardName