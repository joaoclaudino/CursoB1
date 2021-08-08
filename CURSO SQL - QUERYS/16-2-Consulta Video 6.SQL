use SBODemoBR
go
SELECT    T0.[cardcode],
          T0.[cardname],
          T0.[balance],
          T1.[docnum],
          T1.[docdate],
          T1.[doctotal]
FROM      dbo.ocrd T0
LEFT JOIN dbo.oinv T1
ON        T0.cardcode = T1.cardcode
WHERE     T0.cardcode < 'C100005'