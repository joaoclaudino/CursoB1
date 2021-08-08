use SBODemoBR
go


--SELECIONANDO OS CAMPOS

SELECT	Count(*) AS 'Created',
	CASE T0.TransType
		WHEN 13 THEN 'Fatura de Contas a Receber'
		WHEN 18 THEN 'Fatura de Contas a Pagar'
		WHEN 19 THEN 'Nota de Crédito de Contas a Pagar'
		WHEN 20 THEN 'Recebimento de Mercadorias'
	END AS TransType, T0.UserSign

--SELECIONANDO AS TABELAS

FROM		dbo.OJDT T0
WHERE		T0.RefDate >= '20120101'
		AND	T0.RefDate <= '20160404'
GROUP BY	T0.TransType,
			T0.UserSign