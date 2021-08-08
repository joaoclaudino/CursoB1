use SBODemoBR
go
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