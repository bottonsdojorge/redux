CREATE TABLE ProdutoCarrinho(
produtoId INT NOT NULL,
carrinhoId INT NOT NULL,
quantidade INT NOT NULL,
PRIMARY KEY(produtoId, carrinhoId)
)

CREATE TABLE Usuario(
id INT IDENTITY(1,1) NOT NULL,
nome VARCHAR(100) NOT NULL,
carrinho_id INT NOT NULL,
produtoCarrinho_ProdutoId INT NOT NULL,
produtoCarrinho_CarrinhoId INT NOT NULL,
adm BIT NOT NULL,
aspnet_Users_UserId uniqueidentifier NOT NULL,
PRIMARY KEY(id),
FOREIGN KEY(produtoCarrinho_ProdutoId, produtoCarrinho_CarrinhoId) REFERENCES ProdutoCarrinho(produtoId, carrinhoId),
FOREIGN KEY(aspnet_Users_UserId) REFERENCES aspnet_Users(UserID)
)

CREATE TABLE Telefone(
id INT IDENTITY(1,1) NOT NULL,
numero VARCHAR(100) NOT NULL,
usuario_id INT NOT NULL,
PRIMARY KEY(id),
FOREIGN KEY(usuario_id) REFERENCES Usuario(id)
)

CREATE TABLE Mensagem(
id INT IDENTITY(1,1) NOT NULL,
data DATE NOT NULL,
corpo VARCHAR(1000) NOT NULL,
usuarioDestinatario INT NOT NULL,
usuarioRemetente INT NOT NULL,
PRIMARY KEY(id),
FOREIGN KEY(usuarioDestinatario) REFERENCES Usuario(id),
FOREIGN KEY(usuarioRemetente) REFERENCES Usuario(id)
)

CREATE TABLE EncStatus(
id INT IDENTITY(1,1) NOT NULL,
descricao VARCHAR(45) NOT NULL,
PRIMARY KEY(id)
)

CREATE TABLE LocalEntrega(
id INT IDENTITY(1,1) NOT NULL,
rua VARCHAR(45) NOT NULL,
numero INT NOT NULL,
bairro VARCHAR(45) NOT NULL,
complemento VARCHAR(45),
descricao VARCHAR(45),
cep VARCHAR(8),
PRIMARY KEY(id)
)

CREATE TABLE Encomenda(
id INT IDENTITY(1,1) NOT NULL,
precoTotal NUMERIC(10,2) NOT NULL,
dataEntrega DATE NOT NULL,
statusId INT NOT NULL,
localEntregaId INT NOT NULL,
usuarioId INT NOT NULL,
PRIMARY KEY(id),
FOREIGN KEY (statusId) REFERENCES EncStatus(id),
FOREIGN KEY (localEntregaId) REFERENCES LocalEntrega(id),
FOREIGN KEY (usuarioId) REFERENCES Usuario(id)
)

CREATE TABLE Produto(
id INT IDENTITY(1,1) NOT NULL,
descricao VARCHAR(200) NOT NULL,
imagem VARCHAR(1000) NOT NULL,
tamanho VARCHAR(45) NOT NULL,
preco NUMERIC(10,2) NOT NULL,
PRIMARY KEY(id)
)

CREATE TABLE Marcador(
id INT IDENTITY(1,1) NOT NULL,
marcador VARCHAR(45) NOT NULL,
Produto_id INT NOT NULL,
PRIMARY KEY(id),
FOREIGN KEY(Produto_id) REFERENCES Produto(id)
)

CREATE TABLE ProdutoEncomenda(
encomenda_id INT NOT NULL,
produto_id INT NOT NULL,
quantidade INT NOT NULL,
PRIMARY KEY(encomenda_id, produto_id)
)