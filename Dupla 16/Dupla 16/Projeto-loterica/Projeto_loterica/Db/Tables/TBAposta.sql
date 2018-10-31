CREATE TABLE [dbo].[TBAposta]
(
	[Id_aposta] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Numeros] NVARCHAR(20) NOT NULL, 
    [Vencedor] INT NOT NULL, 
    [ValorRecebido] DECIMAL(18, 2) NOT NULL, 
    [ValorPago] DECIMAL(18, 2) NOT NULL
)
