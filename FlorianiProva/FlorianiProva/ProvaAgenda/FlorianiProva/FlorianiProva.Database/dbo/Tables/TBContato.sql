CREATE TABLE [dbo].[TBContato]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [nome] NVARCHAR(100) NOT NULL, 
    [email] NVARCHAR(50) NOT NULL, 
    [departamento] NVARCHAR(100) NOT NULL, 
    [endereco] NVARCHAR(200) NOT NULL, 
    [telefone] NVARCHAR(50) NOT NULL
)
