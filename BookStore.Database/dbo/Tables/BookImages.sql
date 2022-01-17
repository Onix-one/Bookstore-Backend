CREATE TABLE [dbo].[BookImages] (
    [Id]     INT             IDENTITY (1, 1) NOT NULL,
    [BookId] INT             DEFAULT ((0)) NOT NULL,
    [Image]  VARBINARY (MAX) NULL,
    CONSTRAINT [PK_BookImages] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BookImages_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BookImages_BookId]
    ON [dbo].[BookImages]([BookId] ASC);

