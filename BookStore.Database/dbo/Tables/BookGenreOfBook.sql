CREATE TABLE [dbo].[BookGenreOfBook] (
    [BooksId]        INT NOT NULL,
    [GenreOfBooksId] INT NOT NULL,
    CONSTRAINT [PK_BookGenreOfBook] PRIMARY KEY CLUSTERED ([BooksId] ASC, [GenreOfBooksId] ASC),
    CONSTRAINT [FK_BookGenreOfBook_Books_BooksId] FOREIGN KEY ([BooksId]) REFERENCES [dbo].[Books] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookGenreOfBook_GenresOfBooks_GenreOfBooksId] FOREIGN KEY ([GenreOfBooksId]) REFERENCES [dbo].[GenresOfBooks] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BookGenreOfBook_GenreOfBooksId]
    ON [dbo].[BookGenreOfBook]([GenreOfBooksId] ASC);

