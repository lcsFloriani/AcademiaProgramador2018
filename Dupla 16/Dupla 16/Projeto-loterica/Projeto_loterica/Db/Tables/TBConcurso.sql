CREATE TABLE [dbo].[TBConcurso]
(
	[Id_concurso] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ResultadoSorteado] VARCHAR(50) NOT NULL, 
    [ResultadoValor] DECIMAL(18, 2) NOT NULL, 
    [DataConcurso] DATETIME NOT NULL, 
    [QuantidadeQuina] INT NOT NULL, 
    [QuantidadeMega] INT NOT NULL, 
    [QuantidadeQuadra] INT NOT NULL,
	[MediaQuina] INT NOT NULL, 
    [MediaSena] INT NOT NULL, 
    [MediaQuadra] INT NOT NULL
)
