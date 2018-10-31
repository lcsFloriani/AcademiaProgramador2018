CREATE TABLE [dbo].[TBCompromissos]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [assunto] NVARCHAR(255) NOT NULL, 
    [local] NVARCHAR(100) NOT NULL, 
    [data_inicio] DATETIME NOT NULL, 
    [data_fim] DATETIME NULL
)
