CREATE TABLE [dbo].[BookTypeOfBook] (
    [BooksId]       INT NOT NULL,
    [TypesOfBookId] INT NOT NULL,
    CONSTRAINT [PK_BookTypeOfBook] PRIMARY KEY CLUSTERED ([BooksId] ASC, [TypesOfBookId] ASC),
    CONSTRAINT [FK_BookTypeOfBook_Books_BooksId] FOREIGN KEY ([BooksId]) REFERENCES [dbo].[Books] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookTypeOfBook_TypeOfBooks_TypesOfBookId] FOREIGN KEY ([TypesOfBookId]) REFERENCES [dbo].[TypeOfBooks] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BookTypeOfBook_TypesOfBookId]
    ON [dbo].[BookTypeOfBook]([TypesOfBookId] ASC);

