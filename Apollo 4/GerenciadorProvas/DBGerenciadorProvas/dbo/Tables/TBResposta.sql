CREATE TABLE [dbo].[TBResposta]
(
	[Id] INT IDENTITY (1, 1)  NOT NULL, 
    [Descricao] VARCHAR(100) NULL, 
    [Certa] BIT NULL, 
    [Letra] CHAR(1) NULL, 
    [IdQuestao] INT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBResposta_Questao] FOREIGN KEY ([IdQuestao]) REFERENCES [dbo].[TBQuestao] ([Id]) ON DELETE CASCADE
)
