IF @object_type = '60' and @transaction_type = 'A'
BEGIN
	IF EXISTS
		(SELECT T0.DocEntry
		FROM OIGE T0
		INNER JOIN IGE1 T1 ON T0.DocEntry = T1.DocEntry
		WHERE T0.DocEntry = @list_of_cols_val_tab_del
		GROUP BY T1.DocEntry, T0.U_nQty, T0.DocEntry
		HAVING SUM (T1.Quantity) <= T0.U_nQty)
	Begin
		SELECT @error = 1,@error_message = 'error'
	End
END