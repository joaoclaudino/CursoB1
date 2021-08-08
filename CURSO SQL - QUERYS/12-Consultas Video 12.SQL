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