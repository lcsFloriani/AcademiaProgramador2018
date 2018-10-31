CREATE TABLE [dbo].[TBMateria] (
    [Id]           INT        IDENTITY (1, 1) NOT NULL,
    [Nome]         VARCHAR(50) NULL,
    [IdSerie]      INT        NULL,
    [IdDisciplina] INT        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBMateria_Disciplina] FOREIGN KEY ([IdDisciplina]) REFERENCES [dbo].[TBDisciplina] ([Id]),
    CONSTRAINT [FK_TBMateria_Serie] FOREIGN KEY ([IdSerie]) REFERENCES [dbo].[TBSerie] ([Id])
);

