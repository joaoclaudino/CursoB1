SELECT T0.[docnum],
       T0.[cardcode],
       T0.[cardname],
       T0.[objtype],
       T1.[groupcode],
       T2.[groupname]
FROM   oinv T0
       INNER JOIN ocrd T1
               ON T0.[cardcode] = T1.[cardcode]
       INNER JOIN ocrg T2
               ON T1.[groupcode] = T2.[groupcode]
WHERE  T0.[cardname] <> [%0]
ORDER  BY T0.[cardname] 