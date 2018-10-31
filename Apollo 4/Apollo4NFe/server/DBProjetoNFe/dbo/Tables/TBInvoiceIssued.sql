CREATE TABLE [dbo].[TBInvoiceIssued]
(
	[IdInvoiceIssued] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AccessKey] VARCHAR(50) NOT NULL, 
    [TotalValue] DECIMAL(18, 3) NOT NULL, 
    [ConveyorCpf_Cnpj] VARCHAR(20) NULL, 
    [EmitterCnpj] VARCHAR(20) NOT NULL, 
    [ReceiverCpf_Cnpj] VARCHAR(20) NOT NULL, 
    [Xml] XML NULL
)
