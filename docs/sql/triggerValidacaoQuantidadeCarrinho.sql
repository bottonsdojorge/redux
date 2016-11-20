-- Retorna 0 se a quantidade for menor que 0
CREATE FUNCTION fn_corrigirQuantidade (@quantidade int)
RETURNS INT
AS
BEGIN
	IF (@quantidade >= 0)
		RETURN @quantidade
	RETURN 0
END
GO

-- Triggers
CREATE TRIGGER tr_i_corrigirQuantidadeCarrinho ON itemCarrinho
INSTEAD OF INSERT
AS
	DECLARE @quantidade INT
	DECLARE @idCarrinho INT
	DECLARE @idTamanho INT
	DECLARE @idProduto INT
	
	SELECT @quantidade = dbo.fn_corrigirQuantidade(quantidade),
		@idCarrinho = Carrinho_id,
		@idTamanho = item_tamanho_id,
		@idProduto = item_Produto_id
	FROM inserted

	INSERT INTO itemCarrinho(Carrinho_id, item_Produto_id, item_tamanho_id, quantidade) VALUES (@idCarrinho, @idProduto, @idTamanho, @quantidade)
GO

CREATE TRIGGER tr_u_corrigirQuantidadeCarrinho ON itemCarrinho
INSTEAD OF UPDATE
AS
	DECLARE @quantidade INT
	DECLARE @idCarrinho INT
	DECLARE @idTamanho INT
	DECLARE @idProduto INT
	
	SELECT @quantidade = dbo.fn_corrigirQuantidade(quantidade),
		@idCarrinho = Carrinho_id,
		@idTamanho = item_tamanho_id,
		@idProduto = item_Produto_id
	FROM inserted

	UPDATE itemCarrinho SET quantidade = @quantidade WHERE Carrinho_id = @idCarrinho AND item_Produto_id = @idProduto AND item_tamanho_id = @idTamanho
GO
	
