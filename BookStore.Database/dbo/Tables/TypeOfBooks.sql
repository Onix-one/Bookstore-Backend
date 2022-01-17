CREATE TABLE [dbo].[TypeOfBooks] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Type]        INT            NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_TypeOfBooks] PRIMARY KEY CLUSTERED ([Id] ASC)
);

