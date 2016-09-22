CREATE TABLE Usuario(
	id INT IDENTITY PRIMARY KEY,
	nome VARCHAR(100) NOT NULL,
	dataRegistro DATETIME NOT NULL,
	adm BIT NOT NULL,
	aspnet_id UNIQUEIDENTIFIER,
	FOREIGN KEY (aspnet_id) REFERENCES aspnet_Users(UserId) 
)
CREATE TABLE Telefone(
	id INT IDENTITY PRIMARY KEY,
	numero VARCHAR(11) NOT NULL,
	Usuario_id INT NOT NULL, 
	FOREIGN KEY (Usuario_id) REFERENCES Usuario(id)
)
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
CREATE TABLE localEntrega(	
	id INT IDENTITY PRIMARY KEY,
	rua VARCHAR(50) NOT NULL,
	numero INT NOT NULL,
	bairro VARCHAR(30) NOT NULL,
	complemento VARCHAR(50) NOT NULL,
	descricao VARCHAR(50) NOT NULL,
	cep VARCHAR(8) NOT NULL
)
CREATE TABLE Status(	
	id INT IDENTITY PRIMARY KEY,
	descricao VARCHAR(20) NOT NULL
)
CREATE TABLE Encomenda(	
	id INT IDENTITY PRIMARY KEY,
	precoTotal NUMERIC(10,2) NOT NULL,
	dataEntrega DATETIME,
	Usuario_id INT NOT NULL,
	localEntrega_id INT NOT NULL,
	Status_id INT NOT NULL,
	FOREIGN KEY (Usuario_id) REFERENCES Usuario(id),
	FOREIGN KEY (localEntrega_id) REFERENCES localEntrega(id),
	FOREIGN KEY (Status_id) REFERENCES Status(id)
)
CREATE TABLE Marcador(
	id INT IDENTITY PRIMARY KEY,
	descricao VARCHAR(20) NOT NULL
)
CREATE TABLE Produto(
	id INT IDENTITY PRIMARY KEY,
	descricao VARCHAR(20) NOT NULL,
	imagem VARCHAR(100) NOT NULL	
)
CREATE TABLE marcadorProduto(
	Produto_id INT NOT NULL,
	Marcador_id INT NOT NULL,
	descricao VARCHAR(20) NOT NULL,
	FOREIGN KEY (Produto_id) REFERENCES Produto(id),
	FOREIGN KEY (Marcador_id) REFERENCES Marcador(id)
)
CREATE TABLE Tamanho(
	id INT IDENTITY PRIMARY KEY,
	descricao VARCHAR(20) NOT NULL,
	precoUnitario NUMERIC(10,2) NOT NULL
)
CREATE TABLE Item(
	Tamanho_id INT NOT NULL,
	Produto_id INT NOT NULL,
	FOREIGN KEY (Tamanho_id) REFERENCES Tamanho(id),
	FOREIGN KEY (Produto_id) REFERENCES Produto(id)
)
CREATE TABLE Carrinho(
	Usuario_id INT NOT NULL,
	precoTotal NUMERIC(10,2) NOT NULL,
	FOREIGN KEY (Usuario_id) REFERENCES Usuario(id)
)
CREATE TABLE itemCarrinho(
	Carrinho_id INT NOT NULL,
	item_tamanho_id INT NOT NULL,
	item_Produto_id INT NOT NULL,
	quantidade INT NOT NULL,
	FOREIGN KEY (carrinho_id) REFERENCES Carrinho(Usuario_id),
	FOREIGN KEY (item_tamanho_id) REFERENCES Item(Tamanho_id),
	FOREIGN KEY (item_Produto_id) REFERENCES Item(Produto_id)
)
CREATE TABLE itemEncomenda(
	Encomenda_id INT NOT NULL,
	item_tamanho_id INT NOT NULL,
	item_Produto_id INT NOT NULL,
	precoUnitario NUMERIC(10,2) NOT NULL,
	quantidade INT NOT NULL,
	FOREIGN KEY (Encomenda_id) REFERENCES Encomenda(Usuario_id),
	FOREIGN KEY (item_tamanho_id) REFERENCES Item(Tamanho_id),
	FOREIGN KEY (item_Produto_id) REFERENCES Item(Produto_id)
)