CREATE TABLE [dbo].[BookAuthor] (
    [BookId]   INT NOT NULL,
    [AuthorId] INT NOT NULL,
    [Id]       INT NOT NULL,
    CONSTRAINT [PK_BookAuthor] PRIMARY KEY CLUSTERED ([BookId] ASC, [AuthorId] ASC),
    CONSTRAINT [FK_BookAuthor_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Authors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookAuthor_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BookAuthor_AuthorId]
    ON [dbo].[BookAuthor]([AuthorId] ASC);

