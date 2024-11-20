CREATE TABLE Clientes (
    Id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(50),
    cpf VARCHAR(50) UNIQUE,
    email VARCHAR(100) UNIQUE,
    telefone VARCHAR(50),
    dataRegistro DATE
);

CREATE TABLE Tipos (
    Id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(50),
    descricao TEXT
);

CREATE TABLE Produtos (
    Id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(50),
    preco DECIMAL(18, 2),
    quantidade INT,
    foto VARCHAR(255),
    idTipo INT,
    FOREIGN KEY (idTipo) REFERENCES Tipos(Id)
);

CREATE TABLE Vendas (
    Id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    total DECIMAL(18, 2),
    dataVenda DATE,
    idCliente INT,
    FOREIGN KEY (idCliente) REFERENCES Clientes(Id)
);

CREATE TABLE ProdutosVendas (
    Id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    idProduto INT,
    idVenda INT,
    quantidade INT,
    valorUnitário DECIMAL(18, 2),
    FOREIGN KEY (idProduto) REFERENCES Produtos(Id),
    FOREIGN KEY (idVenda) REFERENCES Vendas(Id)
);

INSERT INTO Tipos(nome, descricao)
VALUES  ('Action Figures e Colecionáveis', 'Figuras detalhadas e estatuetas de personagens icônicos.'),
		('Consoles e Jogos Eletrônicos', 'Videogames, jogos e acessórios para entretenimento digital com uma variedade de estilos.'),
		('Jogos de Tabuleiro e RPG', 'Jogos que incentivam interação e criatividade, desde aventuras de RPG até jogos de estratégia.'),
		('Livros e HQs', 'Publicações com histórias e ilustrações de personagens e universos de ficção.'),
		('Produtos de Casa e Decoração', 'Artigos decorativos para personalizar ambientes com referências de filmes, séries e jogos.'),
		('Produtos de Tecnologia', 'Gadgets e acessórios que combinam tecnologia com designs inspirados em temas geek.'),
		('Roupas e Acessórios', 'Vestuário e acessórios inspirados em franquias da cultura pop.');