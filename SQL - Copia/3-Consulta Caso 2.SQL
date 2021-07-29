SELECT DISTINCT T0.cardcode,
                T0.cardname,
                T0.docnum,
                T0.doctotal,
                T0.grosprofit,
                T0.docdate
FROM   dbo.adoc T0
WHERE  T0.cardcode LIKE '%C'
       AND T0.docdate BETWEEN [%0] AND [%1]
       AND T0.cardcode LIKE '%[%2]%' 