﻿CREATE TABLE [dbo].[TBAvaliacao]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Assunto] NVARCHAR(255) NOT NULL, 
    [Data] DATETIME2 NOT NULL
)