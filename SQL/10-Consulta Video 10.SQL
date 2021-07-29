use SBODemoBR 
 
go 
 

select 
	T0.TransID
from 
	JDT1 T0
group by 
	T0.TransID
HaVING 
	SUM	(ISNULL(T0.Debit,0) + ISNULL(T0.Credit,0)) > 0
ORDER BY 
	SUM(ISNULL(T0.Debit,0) - ISNULL(T0.Credit,0)) DESC

--quando o campo1 for nulo, automaticamente vem o valor do campo 2
select ISNULL('campo1','campo2')

--all quer dizer que vai pegar todas as linhas do campo
--quando e distinct não ira pegar as linhas que repetem valor
SUM ([ALL | DISTINCT] value)
