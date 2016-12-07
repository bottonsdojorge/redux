USE [2016TiiGrupo1]
GO
/****** Object:  Trigger [dbo].[calcularDescontos]    Script Date: 07/12/2016 11:43:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER[dbo].[calcularDescontos] ON [dbo].[itemCarrinho]
FOR INSERT, UPDATE, DELETE
AS
DECLARE 
	@descontos INT,
	@precototal NUMERIC(10,2),
	@qtditens INT,
	@usuario_id INT
 
	SELECT @usuario_id = Carrinho_id
		FROM inserted
	SELECT @qtditens = SUM(quantidade)
		FROM itemCarrinho
		WHERE Carrinho_id = @usuario_id
	SELECT @precototal = precoTotal
		FROM Carrinho
		WHERE Usuario_id = @usuario_id
	
	SET @descontos = 0
	
	PRINT 'INICIO'
	print @usuario_id
	print @qtditens
	print @precototal

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
	
	print 'fim'
	PRINT @descontos
	print @precototal

	UPDATE Carrinho SET precoTotal = @precototal WHERE usuario_id = @usuario_id
