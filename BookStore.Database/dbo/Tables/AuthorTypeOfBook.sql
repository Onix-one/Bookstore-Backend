CREATE TABLE [dbo].[AuthorTypeOfBook] (
    [AuthorsId]     INT NOT NULL,
    [TypesOfBookId] INT NOT NULL,
    CONSTRAINT [PK_AuthorTypeOfBook] PRIMARY KEY CLUSTERED ([AuthorsId] ASC, [TypesOfBookId] ASC),
    CONSTRAINT [FK_AuthorTypeOfBook_Authors_AuthorsId] FOREIGN KEY ([AuthorsId]) REFERENCES [dbo].[Authors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AuthorTypeOfBook_TypeOfBooks_TypesOfBookId] FOREIGN KEY ([TypesOfBookId]) REFERENCES [dbo].[TypeOfBooks] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AuthorTypeOfBook_TypesOfBookId]
    ON [dbo].[AuthorTypeOfBook]([TypesOfBookId] ASC);

