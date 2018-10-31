CREATE TABLE [dbo].[TBConcursos] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [Numero]                 INT            NOT NULL,
    [Data]                   DATETIME       NOT NULL,
    [Premio]                 DECIMAL (9, 2) NOT NULL,
    [PremioQuadra]           DECIMAL (9, 2) NOT NULL,
    [PremioQuina]            DECIMAL (9, 2) NOT NULL,
    [PremioSena]             DECIMAL (9, 2) NOT NULL,
    [LucroLoterica]          DECIMAL (9, 2) NOT NULL,
    [GanhadoresQuadra]       INT            NOT NULL,
    [GanhadoresQuina]        INT            NOT NULL,
    [GanhadoresSena]         INT            NOT NULL,
    [PremioGanhadoresQuadra] DECIMAL (9, 2) NOT NULL,
    [PremioGanhadoresQuina]  DECIMAL (9, 2) NOT NULL,
    [PremioGanhadoresSena]   DECIMAL (9, 2) NOT NULL,
    [Situacao]               BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


