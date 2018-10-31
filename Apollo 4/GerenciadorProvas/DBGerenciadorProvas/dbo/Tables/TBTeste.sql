CREATE TABLE [dbo].[TBTeste]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [Titulo] VARCHAR(50) NULL, 
    [NumeroQuestoes] INT NULL, 
    [DataGeracao] DATE NULL, 
    [IdMateria] INT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBTeste_Materia] FOREIGN KEY ([IdMateria]) REFERENCES [dbo].[TBMateria] ([Id])
)
