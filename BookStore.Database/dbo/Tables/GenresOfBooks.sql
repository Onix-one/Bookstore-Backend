CREATE TABLE [dbo].[GenresOfBooks] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Genre]       NVARCHAR (MAX) NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_GenresOfBooks] PRIMARY KEY CLUSTERED ([Id] ASC)
);

