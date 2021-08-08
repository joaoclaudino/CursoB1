*****Estas consultas não retornam nada

HaVING SUM
	(ISNULL(T0.Debit,0) - ISNULL(T0.Credit,0)) > 0

-----------------------------------------------------------
ORDER BY SUM
	(T0.Debit,0) - ISNULL(T0.Credit,0)) DESC

-----------------------------------------
IS NULL(Value1,Value2)

-----------------------------------------------------
SUM ([ALL | DISTINCT] value)

-----------------------