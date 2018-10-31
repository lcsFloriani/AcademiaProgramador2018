CREATE TABLE [dbo].[TBCompromissos_Contatos]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [id_compromisso] INT NOT NULL FOREIGN KEY REFERENCES TBCompromissos(Id),
    [id_contato] INT NOT NULL FOREIGN KEY REFERENCES TBContato(Id)
)
