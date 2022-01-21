CREATE TABLE [dbo].[Books] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [Rating]      INT            NOT NULL,
    [Price]       FLOAT (53)     NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [BookUrl]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([Id] ASC)
);

