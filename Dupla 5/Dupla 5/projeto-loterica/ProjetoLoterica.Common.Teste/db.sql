CREATE DATABASE DBLoteria
GO
USE DBLoteria
GO
CREATE TABLE TBConcursos
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
	[Numero] INT NOT NULL, 
    [Data] DATETIME NOT NULL, 
    [Premio] DECIMAL(9, 2) NOT NULL, 
    [PremioQuadra] DECIMAL(9, 2) NOT NULL, 
    [PremioQuina] DECIMAL(9, 2) NOT NULL, 
    [PremioSena] DECIMAL(9, 2) NOT NULL, 
    [LucroLoterica] DECIMAL(9, 2) NOT NULL, 
    [GanhadoresQuadra] INT NOT NULL, 
    [GanhadoresQuina] INT NOT NULL, 
    [GanhadoresSena] INT NOT NULL, 
    [PremioGanhadoresQuadra] DECIMAL(9,2) NOT NULL, 
    [PremioGanhadoresQuina] DECIMAL(9,2) NOT NULL, 
    [PremioGanhadoresSena] DECIMAL(9,2) NOT NULL, 
    [Situacao] BIT NOT NULL, 
)

CREATE TABLE TBApostas
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ConcursoId] INT NOT NULL, 
    [BolaoId] INT, 
    [Data] DATETIME NOT NULL, 
    [Valor] DECIMAL(9, 2) NOT NULL,
	CONSTRAINT FK_ApostaConcurso FOREIGN KEY (ConcursoId) REFERENCES TBConcursos(Id)
)

CREATE TABLE TBApostas_Dezenas
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ApostaId] INT NOT NULL, 
    [Dezena] INT NOT NULL,
	CONSTRAINT FK_ApostaDezena FOREIGN KEY (ApostaId)
    REFERENCES TBApostas(Id)
)

CREATE TABLE TBConcursos_Dezenas
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ConcursoId] INT NOT NULL,
    [Dezena] INT NOT NULL,
	CONSTRAINT FK_ConcursoDezenas FOREIGN KEY (ConcursoId)
    REFERENCES TBConcursos(Id)
)

CREATE TABLE TBBoloes
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Numero] INT NOT NULL,
)
