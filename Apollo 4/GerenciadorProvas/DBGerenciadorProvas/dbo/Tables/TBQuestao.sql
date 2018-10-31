CREATE TABLE [dbo].[TBQuestao]
(
	[Id] INT   IDENTITY (1, 1)  NOT NULL, 
    [Enunciado] VARCHAR(500) NULL, 
    [Bimestre] VARCHAR(15) NULL, 
    [IdMateria] INT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBQuestao_Materia] FOREIGN KEY ([IdMateria]) REFERENCES [dbo].[TBMateria] ([Id])
)
