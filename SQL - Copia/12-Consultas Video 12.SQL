SELECT CASE
         WHEN ( Datediff(dd, T0.refdate, Getdate()) ) >= 90 THEN
           CASE
             WHEN T0.syscred = 0 THEN T0.sysdeb
             WHEN T0.sysdeb = 0 THEN -T0.syscred
           END
       END "90 + DAYS"
FROM   dbo.jdt1 T0
WHERE  T0.shortname LIKE '[%0]%' 
---------------------------------------------------------
IF EXISTS (SELECT T1.docentry
           FROM   oige T0
                  INNER JOIN ige1 T1
                          ON T0.docentry = T1.docentry
           WHERE  T0.docentry = @list_of_cols_val_tab_del
           GROUP  BY T1.docentry
           HAVING Sum (T1.quantity) <= T0.u_nqty)
  BEGIN
      SELECT @error = 111,
             @error_message = 'error quantity entered'
  END 