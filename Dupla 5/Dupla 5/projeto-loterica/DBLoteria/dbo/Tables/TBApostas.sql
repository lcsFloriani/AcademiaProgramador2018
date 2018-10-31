CREATE TABLE [dbo].[TBApostas] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [ConcursoId] INT            NOT NULL,
    [BolaoId]    INT            NULL,
    [Data]       DATETIME       NOT NULL,
    [Valor]      DECIMAL (9, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ApostaConcurso] FOREIGN KEY ([ConcursoId]) REFERENCES [dbo].[TBConcursos] ([Id])
);


