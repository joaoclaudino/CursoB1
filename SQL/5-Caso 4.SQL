use SBODemoBR 
 
go 
 
SELECT T0.docnum,
       T0.docdate,
       T0.doctotal,
       T0.grosprofit,
       T0.numatcard,
       ( T0.grosprofit / ( T0.doctotal - T0.grosprofit ) ) * 100 AS '% Lucro',
       T1.cardcode,
       T1.cardname,
       T1.phone1,
       T1.cntctprsn,
       T2.groupname
	  -- ,Datediff(mm,T0.docdate, convert(varchar, '22/02/2012', 103))
	  ,Datepart(dw, T0.docdate)
FROM   dbo.oinv T0
       INNER JOIN dbo.ocrd T1
               ON T0.cardcode = T1.cardcode
       INNER JOIN dbo.ocrg T2
               ON T1.groupcode = T2.groupcode
WHERE  Datediff(mm,T0.docdate, convert(varchar, '22/02/2012', 103)/*Getdate()*/) = 1
       AND Datepart(dw, T0.docdate) IN ( 6, 1 ) 
order by 1