SELECT code,
       NAME,
       remarks
FROM   oudp 
---------------------------------------
SELECT DISTINCT T0.[docnum],
                T1.docnum,
                T0.[doctype],
                T0.[cardcode],
                T0.[cardname],
                T0.[usersign],
                T0.[usersign2],
                T1.[usersign],
                T1.[usersign2]
FROM   dbo.adoc T0
       INNER JOIN dbo.orin T1
               ON T0.docnum = T1.docnum
WHERE  T0.[objtype] = '14'
       AND T0.[usersign2] != T1.[usersign2] 
----------------------------------------------------
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
               ON T2.docnum = T1.docnum
       INNER JOIN dbo.oinv T4
               ON T4.docentry = T3.docentry
                  AND T3.invtype = '13'
WHERE  T1.docdate >= [%0]
       AND T1.docdate <= [%1]
ORDER  BY T1.docdate 










