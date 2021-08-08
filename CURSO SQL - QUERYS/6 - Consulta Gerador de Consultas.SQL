
use SBODemoBR
go
SELECT t0.[itemcode],
       t0.[itemname],
       t0.[cardcode],
       T2.[cardcode]
FROM   oitm t0
       INNER JOIN oitb T1
               ON t0.[itmsgrpcod] = T1.[itmsgrpcod]
       INNER JOIN ocrd T2
               ON t0.cardcode = T2.cardcode
WHERE  t0.[itemcode] <> [%0] 