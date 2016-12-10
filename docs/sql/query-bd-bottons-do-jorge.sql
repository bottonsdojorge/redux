-- ATENÇÃO! EXECUTAR REGSQL PRIMEIRO!
-- DROPS TABLES
DROP TABLE dbo.Mensagem
GO
DROP TABLE dbo.Telefone
GO
DROP TABLE dbo.EnderecoUsuario
GO
DROP TABLE dbo.itemEncomenda
GO
DROP TABLE dbo.Encomenda
GO
DROP TABLE dbo.localEntrega
GO
DROP TABLE dbo.Status
GO
DROP TABLE dbo.itemCarrinho
GO
DROP TABLE dbo.Carrinho
GO
DROP TABLE dbo.Usuario
GO
DROP TABLE dbo.Item
GO
DROP TABLE dbo.Tamanho
GO
DROP TABLE dbo.marcadorProduto
GO
DROP TABLE dbo.Produto
GO
DROP TABLE dbo.Marcador
GO
-- DROP FUNCTIONS
DROP FUNCTION fn_corrigirQuantidade
GO
-- DROP PROCEDURES
DROP PROCEDURE sp_calcularPrecoCarrinho
GO
DROP PROCEDURE sp_inserirTamanhosNoProduto
GO
DROP PROCEDURE sp_criarProdutoComMarcador
GO
-- DROP TRIGGERS
DROP TRIGGER t_calcularPrecoCarrinho
GO
DROP TRIGGER t_criarCarrinhoUsuario
GO
DROP TRIGGER t_checarCep
GO

-- CREATE TABLE
CREATE TABLE Usuario(
	id INT IDENTITY PRIMARY KEY,
	aspnet_id UNIQUEIDENTIFIER NOT NULL,
	nome VARCHAR(100),
	FOREIGN KEY (aspnet_id) REFERENCES aspnet_Users(UserId) 
)
GO
CREATE TABLE Telefone(
	id INT IDENTITY PRIMARY KEY,
	numero VARCHAR(11) NOT NULL,
	Usuario_id INT NOT NULL, 
	FOREIGN KEY (Usuario_id) REFERENCES Usuario(id)
)
GO
CREATE TABLE Mensagem(
	id INT IDENTITY PRIMARY KEY,
	data DATETIME NOT NULL,
	corpo TEXT NOT NULL,
	visualizada BIT NOT NULL,
	UsuarioDestinatario_id INT NOT NULL,	
	UsuarioRemetente_id INT NOT NULL,
	FOREIGN KEY (UsuarioDestinatario_id) REFERENCES Usuario(id),
	FOREIGN KEY (UsuarioRemetente_id) REFERENCES Usuario(id)
)
GO
CREATE TABLE localEntrega(	
	id INT IDENTITY PRIMARY KEY,
	rua VARCHAR(50) NOT NULL,
	numero INT NOT NULL,
	bairro VARCHAR(30) NOT NULL,
	complemento VARCHAR(50) NULL,
	descricao VARCHAR(50) NOT NULL,
	cep VARCHAR(8) NOT NULL
)
GO
CREATE TABLE EnderecoUsuario(
	Usuario_id INT,
	localEntrega_id INT,
	PRIMARY KEY (Usuario_id, localEntrega_id),
	FOREIGN KEY (Usuario_id) REFERENCES Usuario(id),
	FOREIGN KEY (localEntrega_id) REFERENCES localEntrega(id),
)
GO
CREATE TABLE Status(
	id INT IDENTITY PRIMARY KEY,
	descricao VARCHAR(20) NOT NULL
)
GO
CREATE TABLE Encomenda(
	id int identity primary key,
	Usuario_id int not null,
	precoTotal numeric(10,2) not null,
	subTotal numeric(10,2) not null,
	desconto numeric(10,2) not null,
	localEntrega_id int not null,
	Status_id int not null,
	FOREIGN KEY (Usuario_id) REFERENCES Usuario(id),
	FOREIGN KEY (localEntrega_id) REFERENCES localEntrega(id),
	FOREIGN KEY (Status_id) REFERENCES Status(id),
)
GO
CREATE TABLE Marcador(
	id INT IDENTITY PRIMARY KEY,
	descricao VARCHAR(20) NOT NULL
)
GO
CREATE TABLE Produto(
	id INT IDENTITY PRIMARY KEY,
	descricao VARCHAR(20) NOT NULL,
	imagem VARCHAR(100) NOT NULL	
)
GO
CREATE TABLE marcadorProduto(
	Produto_id INT NOT NULL,
	Marcador_id INT NOT NULL,
	PRIMARY KEY (Marcador_id, Produto_id),
	FOREIGN KEY (Produto_id) REFERENCES Produto(id),
	FOREIGN KEY (Marcador_id) REFERENCES Marcador(id)
)
GO
CREATE TABLE Tamanho(
	id INT IDENTITY PRIMARY KEY,
	descricao VARCHAR(20) NOT NULL,
	precoUnitario NUMERIC(10,2) NOT NULL
)
GO
CREATE TABLE Item(
	Tamanho_id INT NOT NULL,
	Produto_id INT NOT NULL,
	PRIMARY KEY (Tamanho_id, Produto_id),
	FOREIGN KEY (Tamanho_id) REFERENCES Tamanho(id),
	FOREIGN KEY (Produto_id) REFERENCES Produto(id)
)
GO
CREATE TABLE Carrinho(
	Usuario_id INT NOT NULL,
	precoTotal NUMERIC(10,2) NOT NULL,
	subTotal NUMERIC(10,2) NOT NULL,
	desconto NUMERIC(10,2) NOT NULL,
	PRIMARY KEY(Usuario_id),
	FOREIGN KEY (Usuario_id) REFERENCES Usuario(id)
)
GO
CREATE TABLE itemCarrinho(
	Carrinho_id INT NOT NULL,
	item_tamanho_id INT NOT NULL,
	item_Produto_id INT NOT NULL,
	quantidade INT NOT NULL,	
	PRIMARY KEY (Carrinho_id, item_tamanho_id, item_Produto_id),
	FOREIGN KEY (carrinho_id) REFERENCES Carrinho(Usuario_id),
	FOREIGN KEY (item_tamanho_id, item_Produto_id) REFERENCES Item(Tamanho_id, Produto_id),
)
GO
CREATE TABLE itemEncomenda(
	Encomenda_id INT NOT NULL,
	item_tamanho_id INT NOT NULL,
	item_Produto_id INT NOT NULL,
	precoUnitario NUMERIC(10,2) NOT NULL,
	quantidade INT NOT NULL,
	FOREIGN KEY (Encomenda_id) REFERENCES Encomenda(id),
	FOREIGN KEY (item_tamanho_id, item_Produto_id) REFERENCES Item(Tamanho_id,Produto_id)
)
GO

-- CREATE FUNCTIONS
CREATE FUNCTION fn_corrigirQuantidade (@quantidade INT)
RETURNS INT
AS
BEGIN
	IF (@quantidade >= 0)
		RETURN @quantidade
	RETURN 0
END
GO

-- CREATE STORAGE PROCEDURES
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
GO
CREATE PROCEDURE sp_inserirTamanhosNoProduto
	@idProduto INT
AS
BEGIN
	DECLARE @idTamanho INT = 0
	-- Loop por todos os Tamanhos
	WHILE (1 = 1)
	BEGIN
		SELECT @idTamanho = MIN(id)
		FROM Tamanho WHERE id > @idTamanho
		IF @idTamanho IS NULL BREAK
		INSERT INTO Item(Tamanho_id, Produto_id) VALUES (@idTamanho, @idProduto)
	END
END
GO
CREATE PROCEDURE sp_criarProdutoComMarcador 
	@descricao VARCHAR(20),
	@imagem VARCHAR(100),
	@idMarcador INT
AS
BEGIN
	DECLARE @tableInserido TABLE(id INT)
	DECLARE @idProduto INT
	IF EXISTS (SELECT * FROM Marcador WHERE id = @idMarcador)
	BEGIN
		-- Insere o produto
		INSERT INTO Produto (descricao, imagem)
			OUTPUT INSERTED.id 
			INTO @tableInserido 
			VALUES (@descricao, @imagem)	
		SELECT @idProduto = id FROM @tableInserido

		-- Insere o marcador
		INSERT INTO marcadorProduto(Produto_id, Marcador_id) VALUES (@idProduto, @idMarcador)
	END
	ELSE
	BEGIN
		RAISERROR ('Marcador inexistente', 16, 1)
	END
END
GO

-- CREATE TRIGGERS
CREATE TRIGGER t_criarCarrinhoUsuario ON Usuario
AFTER INSERT
AS
	DECLARE @id INT
	SELECT @id = id
	FROM inserted
	INSERT INTO Carrinho(Usuario_id, precoTotal, subTotal, desconto) VALUES (@id, 0, 0, 0)
GO
CREATE TRIGGER t_calcularPrecoCarrinho ON itemCarrinho
AFTER INSERT, UPDATE
AS
	DECLARE @id INT
	SELECT @id = carrinho_id FROM INSERTED
	EXEC sp_calcularPrecoCarrinho @id
GO
CREATE TRIGGER t_checarCep ON LocalEntrega
FOR INSERT, UPDATE
AS
	DECLARE @cep VARCHAR(8)

	SELECT @cep = cep
		FROM inserted

	IF(@cep NOT LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]') 
		BEGIN
			RAISERROR('cep inválido', 16, 1)
			ROLLBACK TRANSACTION
		END
GO
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

-- INSERTS
INSERT INTO localEntrega (rua, numero, bairro, descricao, cep) 
	VALUES 
		('Av. Engenheiro Roberto Freire', 0340, 'Capim Macio', 'Frente à Magic Games do Cidade Jardim', '59080900'),
		('Av. Sen. Salgado Filho', 3000, 'Lagoa Nova', 'Parada de ônibus ECT','59078900'),
		('Av. Sen. Salgado Filho', 1559, 'Lagoa Nova', 'Cantina IFRN CNAT','59015000'), 
		('Av. Sen. Salgado Filho', 2234, 'Candelária', 'Praça de alimentação Natal Shopping','59064900')
GO
INSERT INTO Status (descricao)
	VALUES ('Em espera'), ('Em produção'), ('Aguardando entrega'), ('Entregue'), ('Cancelado')
GO
INSERT INTO Tamanho (descricao, precoUnitario)
	VALUES ('Pequeno', 1.75), ('Médio', 2.00), ('Grande', 2.50)
GO
INSERT INTO Marcador (descricao)
	VALUES
		('Música'), ('Filme'), ('Série'), ('Desenho'), 
		('Emoji'), ('Esporte'), ('Super-héroi'), ('Jogo'), 
		('Livro'), ('Filmes'), ('Personalizado')
GO
BEGIN /* Produtos da loja com Marcador */
	EXEC sp_criarProdutoComMarcador 'Emoji apaixonado', 'loja/apaixonado.png', 5
	EXEC sp_criarProdutoComMarcador 'Cap. América', 'loja/capamerica1.png', 7
	EXEC sp_criarProdutoComMarcador 'Escudo Palmeiras', 'loja/palmeiras.gif', 6
	EXEC sp_criarProdutoComMarcador 'Ghost Busters', 'loja/ghostbusters.png', 2
	EXEC sp_criarProdutoComMarcador 'Coruja HP', 'loja/harrypotter.png', 2
	EXEC sp_criarProdutoComMarcador 'Narcos', 'loja/narcos1.png', 3
	EXEC sp_criarProdutoComMarcador 'Guitarra', 'loja/rockband.png', 1
	EXEC sp_criarProdutoComMarcador 'Milhouse', 'loja/simpsons2.png', 4
	EXEC sp_criarProdutoComMarcador 'Chun-li Arlequina', 'loja/streetfighter.png', 8
	EXEC sp_criarProdutoComMarcador 'Negan', 'loja/twd.png', 3
	EXEC sp_criarProdutoComMarcador 'Vampiro', 'loja/vampiro.png', 2
END
GO
BEGIN /* Gerar tamanho para todos os produtos da loja */
	DECLARE @idProduto INT = 0
	WHILE (1 = 1)
	BEGIN	
		SELECT @idProduto = MIN(id)
		FROM Produto WHERE id > @idProduto
		IF @idProduto IS NULL BREAK
		EXEC sp_inserirTamanhosNoProduto @idProduto
	END
END
GO