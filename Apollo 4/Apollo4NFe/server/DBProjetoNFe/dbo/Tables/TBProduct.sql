CREATE TABLE [dbo].[TBProduct]
(
	[IdProduct] INT NOT NULL PRIMARY KEY IDENTITY,
	[Code] VARCHAR(10) NOT NULL, 
    [Description] VARCHAR(50) NOT NULL, 
    [UnitaryValue] DECIMAL(8, 2) NOT NULL
)
