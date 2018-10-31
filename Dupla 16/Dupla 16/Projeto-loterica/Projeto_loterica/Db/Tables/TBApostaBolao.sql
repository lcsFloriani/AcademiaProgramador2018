CREATE TABLE [dbo].[TBApostaBolao]
(
	[Id_aposta_bolao] INT NOT NULL PRIMARY KEY IDENTITY, 
    [aposta_id] INT NOT NULL,
	[bolao_id] INT NOT NULL,	
    CONSTRAINT [FK_TBAposta] FOREIGN KEY ([aposta_id]) REFERENCES [dbo].[TBAposta] ([Id_aposta]),
	CONSTRAINT [FK_TBBolao] FOREIGN KEY ([bolao_id]) REFERENCES [dbo].[TBBolao] ([Id_bolao])
)
