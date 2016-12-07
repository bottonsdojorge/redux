CREATE TRIGGER t_calcularPrecoCarrinho ON itemCarrinho
AFTER INSERT, UPDATE
AS
	DECLARE @id INT
	SELECT @id = carrinho_id FROM INSERTED
	
	EXEC sp_calcularPrecoCarrinho @id
