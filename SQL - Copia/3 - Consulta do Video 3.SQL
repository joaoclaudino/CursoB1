SELECT T1.[cardcode]  AS 'Código do PN',
       T1.[cardname]  AS 'Nome do PN',
       T1.[cardtype]  AS 'Tipo de PN',
       T0.[groupname] AS 'Nome do grupo'
FROM   [dbo].[ocrg] T0
       INNER JOIN [dbo].[ocrd] T1
               ON T1.[groupcode] = T0.[groupcode]
WHERE  ( T1.[cardcode] <> ( N'C20000' ) ) 