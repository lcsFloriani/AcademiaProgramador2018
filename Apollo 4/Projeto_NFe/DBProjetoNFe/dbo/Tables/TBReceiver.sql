CREATE TABLE [dbo].[TBReceiver]
(
	[IdReceiver] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name_CompanyName] VARCHAR(50) NULL, 
    [Cpf_Cnpj] VARCHAR(20) NULL, 
    [StateRegistration] VARCHAR(50) NULL, 
    [Type] VARCHAR(10) NULL,
	[Street] VARCHAR(50) NOT NULL,
	[Number] INT NOT NULL,
	[Neighbourhood] VARCHAR(50) NOT NULL,
	[City] VARCHAR(50) NOT NULL,
	[State] VARCHAR(50) NOT NULL,
)
