CREATE TABLE [dbo].[BookImages] (
    [Id]     INT             IDENTITY (1, 1) NOT NULL,
    [Image]  VARBINARY (MAX) NULL,
    [BookId] INT             NULL,
    CONSTRAINT [PK_BookImages] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BookImages_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_BookImages_BookId]
    ON [dbo].[BookImages]([BookId] ASC);

