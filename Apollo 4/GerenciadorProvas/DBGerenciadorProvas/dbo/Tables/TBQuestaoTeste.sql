CREATE TABLE [dbo].[TBQuestaoTeste]
(
	[Id] INT IDENTITY(1,1) NOT NULL, 
    [IdTeste] INT NULL, 
    [IdQuestao] INT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_TBQuestaoTeste_Teste] FOREIGN KEY ([IdTeste]) REFERENCES [dbo].[TBTeste] ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_TBQuestaoTeste_Questao] FOREIGN KEY ([IdQuestao]) REFERENCES [dbo].[TBQuestao] ([Id])
)
