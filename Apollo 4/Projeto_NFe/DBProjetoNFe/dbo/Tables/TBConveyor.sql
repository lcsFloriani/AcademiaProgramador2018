CREATE TABLE [dbo].[TBConveyor]
(
	[IdConveyor] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name_CompanyName] VARCHAR(50) NOT NULL, 
    [Cpf_Cnpj] VARCHAR(20) NOT NULL, 
    [FreightResponsibility] VARCHAR(10) NOT NULL, 
    [Type] VARCHAR(10) NOT NULL,
	[Street] VARCHAR(50) NOT NULL,
	[Number] INT NOT NULL,
	[Neighbourhood] VARCHAR(50) NOT NULL,
	[City] VARCHAR(50) NOT NULL,
	[State] VARCHAR(50) NOT NULL,
)