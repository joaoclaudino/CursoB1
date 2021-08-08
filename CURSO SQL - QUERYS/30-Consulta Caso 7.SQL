use SBODemoBR
go

--PDN1 Recebimento de mercadorias
--POR1 Pedido de Compra
--RDP1 Devoluções linhas


--SELECIONANDO OS CAMPOS
SELECT  T0.ItemCode,
		Sum(T0.Quantity) 'Quantidade comprada',
		SUM(T1.Quantity) 'Quantidade recebida',
		Sum(T2.Quantity) 'Quantidade devolvida'

--SELECIONANDO AS TABELAS

FROM	dbo.POR1 T0
		LEFT JOIN dbo.PDN1 T1
			ON T0.DocEntry = T1.BaseEntry	
				AND T0.LineNum = T1.BaseLine
		LEFT JOIN dbo.RPD1 T2
			ON T1.DocEntry = T2.BaseEntry
				AND T1.LineNum = T2.BaseLine


--CONDIÇÕES

WHERE	T0.ItemCode IS NOT NULL
		AND T0.DocDate >= [%0]
		AND T0.DocDate <= [%1]
GROUP BY T0.ItemCode
ORDER BY T0.ItemCode

