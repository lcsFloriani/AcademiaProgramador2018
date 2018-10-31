CREATE TABLE [dbo].[TBApostas_Dezenas] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [ApostaId] INT NOT NULL,
    [Dezena]   INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ApostaDezena] FOREIGN KEY ([ApostaId]) REFERENCES [dbo].[TBApostas] ([Id])
);


