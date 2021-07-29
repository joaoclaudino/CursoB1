SELECT T0.cardcode      AS 'Código do Cliente/Fornecedor',
       T0.cardname      AS 'Nome do Cliente/Fornecedor',
       Sum(T0.doctotal) 'Total do Doc.'
FROM   dbo.oinv T0
WHERE  T0.cardcode < 'C50000'
GROUP  BY T0.cardcode,
          T0.cardname 