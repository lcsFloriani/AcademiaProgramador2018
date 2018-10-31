CREATE TABLE [dbo].[TBBolaoConcurso]
(
	[Id_bolao_concurso] INT NOT NULL PRIMARY KEY IDENTITY, 
    [bolao_id] INT NOT NULL, 
    [concurso_id] INT NOT NULL,
	CONSTRAINT [FK_TBConcurso_bolao] FOREIGN KEY ([concurso_id]) REFERENCES [dbo].[TBConcurso] ([Id_concurso]),
	CONSTRAINT [FK_TBBolao_concurso] FOREIGN KEY ([bolao_id]) REFERENCES [dbo].[TBBolao] ([Id_bolao])
)
