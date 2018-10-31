CREATE TABLE [dbo].[TBApostaConcurso]
(
	[Id_aposta_concurso] INT NOT NULL PRIMARY KEY IDENTITY, 
    [aposta_id] INT NOT NULL,
	[concurso_id] INT NOT NULL,
	CONSTRAINT [FK_TBAposta_concurso] FOREIGN KEY ([aposta_id]) REFERENCES [dbo].[TBAposta] ([Id_aposta]),
	CONSTRAINT [FK_TBConcurso] FOREIGN KEY ([concurso_id]) REFERENCES [dbo].[TBConcurso] ([Id_concurso])
)
