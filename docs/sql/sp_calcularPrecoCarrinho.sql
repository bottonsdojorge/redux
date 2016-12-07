CREATE PROCEDURE sp_calcularPrecoCarrinho
	@idCarrinho INT
AS
BEGIN
	DECLARE 
		@precoTotal NUMERIC(10,2),
		@subTotal NUMERIC(10,2),
		@desconto NUMERIC(10,2),
		@quantidadeDeItens INT
	
	SET @desconto = 0

	-- Sub total sem descontos.	
	SELECT @subTotal = 
		(SELECT SUM(ic.quantidade * t.precoUnitario) 'subTotal' 
			FROM itemCarrinho ic 
			INNER JOIN Tamanho t 
			ON t.id = ic.item_tamanho_id 
			WHERE ic.Carrinho_id = @idCarrinho)

	-- Quantidade total de itens
	SELECT @quantidadeDeItens = 
		SUM(quantidade) 
		FROM ItemCarrinho 
		WHERE Carrinho_id = @idCarrinho

	-- Calculo de descontos

	-- Se itens for menor que 50, desconto absoluto.
	IF(@quantidadeDeItens < 50)
	BEGIN
		SET @desconto = @quantidadeDeItens/3
	END

	-- Itens maior que 50 e menor que 100 itens, desconto de 20%
	ELSE IF (@quantidadeDeItens >= 50 AND @quantidadeDeItens < 100)
	BEGIN
		SET @desconto = @subTotal * 0.2
	END

	-- Itens maior que 100 de 40%
	ELSE
	BEGIN
		SET @desconto = @subTotal * 0.4
	END

	SET @precoTotal = @subTotal - @desconto

	UPDATE Carrinho SET precoTotal = @precoTotal, desconto = @desconto, subTotal = @subtotal WHERE Usuario_id = @idCarrinho
END