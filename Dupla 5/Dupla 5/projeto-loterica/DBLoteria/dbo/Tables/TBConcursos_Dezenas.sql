CREATE TABLE [dbo].[TBConcursos_Dezenas] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [ConcursoId] INT NOT NULL,
    [Dezena]     INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ConcursoDezenas] FOREIGN KEY ([ConcursoId]) REFERENCES [dbo].[TBConcursos] ([Id])
);


