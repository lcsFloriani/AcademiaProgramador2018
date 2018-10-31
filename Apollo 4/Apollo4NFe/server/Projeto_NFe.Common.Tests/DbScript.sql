CREATE DATABASE DBProjetoNFe;

USE DBProjetoNFe;

CREATE TABLE [dbo].[TBEmitter]
(
	[IdEmitter] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FantasyName] VARCHAR(50) NULL, 
    [CompanyName] VARCHAR(50) NULL, 
    [Cnpj] VARCHAR(20) NULL, 
    [StateRegistration] VARCHAR(50) NULL, 
    [MunicipalRegistration] VARCHAR(50) NULL, 
    
)

CREATE TABLE [dbo].[TBReceiver]
(
	[IdReceiver] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name_CompanyName] VARCHAR(50) NULL, 
    [Cpf_Cnpj] VARCHAR(20) NULL, 
    [StateRegistration] VARCHAR(50) NULL, 
    [Type] VARCHAR(10) NULL
)

CREATE TABLE [dbo].[TBConveyor]
(
	[IdConveyor] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name_CompanyName] VARCHAR(50) NOT NULL, 
    [Cpf_Cnpj] VARCHAR(20) NOT NULL, 
    [FreightResponsibility] VARCHAR(10) NOT NULL, 
    [Type] VARCHAR(10) NOT NULL,

)

CREATE TABLE [dbo].[TBAddress]
(
	[IdAddress] INT NOT NULL PRIMARY KEY IDENTITY, 
	[Street] VARCHAR(50) NOT NULL,
	[Number] INT NOT NULL,
	[Neighbourhood] VARCHAR(50) NOT NULL,
	[City] VARCHAR(50) NOT NULL,
	[State] VARCHAR(50) NOT NULL,
	[EmitterId] INT,
	[ReceiverId] INT,
	[ConveyorId] INT,
	CONSTRAINT [FK_TBAddress_TBEmitter] FOREIGN KEY ([EmitterId]) REFERENCES [dbo].[TBEmitter] ([IdEmitter]) ON DELETE CASCADE,
	CONSTRAINT [FK_TBAddress_TBReceiver] FOREIGN KEY ([ReceiverId]) REFERENCES [dbo].[TBReceiver] ([IdReceiver]) ON DELETE CASCADE,
	CONSTRAINT [FK_TBAddress_TBConveyor] FOREIGN KEY ([ConveyorId]) REFERENCES [dbo].[TBConveyor] ([IdConveyor]) ON DELETE CASCADE
)

CREATE TABLE [dbo].[TBProduct]
(
	[IdProduct] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] VARCHAR(50) NOT NULL, 
    [UnitaryValue] DECIMAL(8, 2) NOT NULL
)

CREATE TABLE [dbo].[TBInvoice]
(
	[IdInvoice] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AccessKey] VARCHAR(50) NOT NULL
)

CREATE TABLE [dbo].[TBItemInvoice]
(
	[IdItemInvoice] INT NOT NULL PRIMARY KEY IDENTITY, 
    [InvoiceId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
	CONSTRAINT [FK_TBItemInvoice_TBInvoice] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[TBInvoice] ([IdInvoice]) ON DELETE CASCADE,
	CONSTRAINT [FK_TBItemInvoice_TBProduct] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[TBProduct] ([IdProduct])
)
