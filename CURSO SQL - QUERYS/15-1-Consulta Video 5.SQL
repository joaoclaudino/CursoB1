use SBODemoBR
go
SELECT T1.cardcode   AS "CustCode",
       T1.cardname   AS "CustName",
       T2.slpname,
       T1.docnum     "Incoming#",
       T1.docdate,
       T1.doctotal   AS "Payment Total",
       T4.docnum     AS "Invoice#",
       T3.sumapplied AS "Applied Total"
FROM   dbo.ocrd T0
       INNER JOIN dbo.orct T1
               ON T0.cardcode = T1.cardcode
       LEFT JOIN dbo.oslp T2
              ON T0.slpcode = T2.slpcode
       INNER JOIN dbo.rct2 T3
               ON T3.docnum = T1.docnum
       INNER JOIN dbo.oinv T4
               ON T4.docentry = T3.docentry
                  AND T3.invtype = '13'
WHERE  T1.docdate >= [%0]
       AND T1.docdate <= [%1]
ORDER  BY T1.docdate 