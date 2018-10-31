CREATE TABLE [dbo].[TBItemInvoice]
(
	[IdItemInvoice] INT NOT NULL PRIMARY KEY IDENTITY, 
    [InvoiceId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
	CONSTRAINT [FK_TBItemInvoice_TBInvoice] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[TBInvoiceInProcess] ([IdInvoiceInProcess]) ON DELETE CASCADE,
	CONSTRAINT [FK_TBItemInvoice_TBProduct] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[TBProduct] ([IdProduct])
)
