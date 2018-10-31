CREATE TABLE [dbo].[TBInvoiceInProcess]
(
	[IdInvoiceInProcess] INT NOT NULL PRIMARY KEY IDENTITY, 
    [EntryDate] DATETIME NOT NULL, 
	[NatureOperation] Varchar(50) NOT NULL,
    [ConveyorId] INT NULL, 
    [EmitterId] INT NOT NULL, 
    [ReceiverId] INT NOT NULL, 
    [ValueFreight] DECIMAL(18, 2) NULL, 
    CONSTRAINT [FK_TBInvoiceInProcess_ToTBConveyor] FOREIGN KEY ([ConveyorId]) REFERENCES [TBConveyor]([IdConveyor]), 
    CONSTRAINT [FK_TBInvoiceInProcess_ToTBEmitter] FOREIGN KEY ([EmitterId]) REFERENCES [TBEmitter]([IdEmitter]), 
    CONSTRAINT [FK_TBInvoiceInProcess_ToTBReceiver] FOREIGN KEY ([ReceiverId]) REFERENCES [TBReceiver]([IdReceiver])
)
