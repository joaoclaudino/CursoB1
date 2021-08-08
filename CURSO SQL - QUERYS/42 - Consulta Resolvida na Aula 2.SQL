IF(@Object_Type = '46') AND (@transaction_type in (N'A',N'U'))
	BEGIN
		IF EXISTS (SELECT T0.DocNum
		FROM OVPM T0
		WHERE T0.DocEntry = @list_of_cols_val_tab_del AND
		T0.CardCode = 'V10000')

		Begin

			SET @error = 10
			SET @error_message = N'Parceiro de Negócios bloqueado'

		End
	END