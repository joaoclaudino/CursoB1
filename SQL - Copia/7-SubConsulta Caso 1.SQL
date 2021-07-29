SELECT t0.cardname,
       t0.address,
       t0.zipcode,
       t0.city,
       t0.e_mail
FROM   dbo.ocrd T0
WHERE  t0.cardcode IN
       (
                SELECT   t1.cardcode
                FROM     dbo.oinv T1
                WHERE    Year(t1.docdate) = Year('2012/05/26')
                GROUP BY t1.cardcode
                HAVING   Sum(t1.doctotal) > [%0])