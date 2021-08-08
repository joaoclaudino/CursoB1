use SBODemoBR
go

--SELECIONANDO OS CAMPOS


SELECT DISTINCT T0.DocNum		As 'Número do Documento',
				T0.ItemCode		AS 'Número do Produto',
				T1.ItemName		AS 'Nome do Produto',
				T0.PostDate		AS 'Data do Pedido',
				T0.PlannedQty	AS 'Quantidade Planejada - cabecalho',
				T2.NumAtCard

--SELECIONANDO AS TABELAS
FROM			dbo.OWOR T0
				INNER JOIN dbo.OITM T1
					ON T0.ItemCode = T1.ItemCode
				LEFT JOIN dbo.ORDR T2
					ON T2.DocEntry = T0.OriginAbs
						AND T0.OriginType = 'S'

--AS CONDIÇÕES

WHERE T0.Status != 'C'