CREATE TABLE [dbo].[BookGenreOfBook] (
    [BooksId]        INT NOT NULL,
    [GenresOfBookId] INT NOT NULL,
    CONSTRAINT [PK_BookGenreOfBook] PRIMARY KEY CLUSTERED ([BooksId] ASC, [GenresOfBookId] ASC),
    CONSTRAINT [FK_BookGenreOfBook_Books_BooksId] FOREIGN KEY ([BooksId]) REFERENCES [dbo].[Books] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookGenreOfBook_GenresOfBooks_GenresOfBookId] FOREIGN KEY ([GenresOfBookId]) REFERENCES [dbo].[GenresOfBooks] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BookGenreOfBook_GenresOfBookId]
    ON [dbo].[BookGenreOfBook]([GenresOfBookId] ASC);

