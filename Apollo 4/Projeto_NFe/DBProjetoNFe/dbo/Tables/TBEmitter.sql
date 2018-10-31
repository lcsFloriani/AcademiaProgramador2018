CREATE TABLE [dbo].[TBEmitter]
(
	[IdEmitter] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FantasyName] VARCHAR(50) NULL, 
    [CompanyName] VARCHAR(50) NULL, 
    [Cnpj] VARCHAR(20) NULL, 
    [StateRegistration] VARCHAR(50) NULL, 
    [MunicipalRegistration] VARCHAR(50) NULL,
	[Street] VARCHAR(50) NOT NULL,
	[Number] INT NOT NULL,
	[Neighbourhood] VARCHAR(50) NOT NULL,
	[City] VARCHAR(50) NOT NULL,
	[State] VARCHAR(50) NOT NULL,
)
