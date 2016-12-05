ALTER TRIGGER [dbo].[Descontos] ON [dbo].[Carrinho]
AFTER INSERT, UPDATE AS
DECLARE 
	@descontos INT,
	@precototal NUMERIC(10,2),
	@qtditens INT,
	@usuario_id INT
 
	SELECT @usuario_id = Usuario_id
		FROM inserted
	SELECT @qtditens = quantidade
		FROM itemCarrinho 
		WHERE Carrinho_id = @usuario_id
	SELECT @precototal = precoTotal
		FROM Carrinho
		WHERE Usuario_id = @usuario_id
	IF(@qtditens < 50)
			BEGIN
				WHILE(@qtditens > 0)
				BEGIN
					SET @descontos = @descontos + 1
					SET @qtditens = @qtditens - 1
				END
				SET @precototal -= @descontos/3
			END

		ELSE IF (@qtditens >= 50 AND @qtditens < 100)
			BEGIN
				SET @precototal = @precototal * 0.8
			END

		ELSE
			BEGIN
				SET @precototal = @precototal * 0.6
			END

	UPDATE Carrinho SET precoTotal = @precototal WHERE usuario_id = @usuario_id