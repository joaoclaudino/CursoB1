SELECT T0.docnum    AS 'Número do Doc.',
       T0.docdate   AS 'Data',
       T0.cardcode  AS 'Code',
       T0.doctotal  AS 'Total',
       T0.docstatus AS 'Status'
FROM   dbo.ordr T0
       INNER JOIN dbo.ocrd T1
               ON T1.carcode = T0.cardcode
       INNER JOIN dbo.ocrg T2
               ON T2.groupcode = T1.groupcode
WHERE  T0.docstatus = [%0]
       AND T0.docdate >= [%1]
       AND T2.groupname LIKE '[%2]' 