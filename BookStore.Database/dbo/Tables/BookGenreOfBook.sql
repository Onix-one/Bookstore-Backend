CREATE TABLE [dbo].[BookGenreOfBook] (
    [BookId]        INT NOT NULL,
    [GenreOfBookId] INT NOT NULL,
    [Id]            INT NOT NULL,
    CONSTRAINT [PK_BookGenreOfBook] PRIMARY KEY CLUSTERED ([BookId] ASC, [GenreOfBookId] ASC),
    CONSTRAINT [FK_BookGenreOfBook_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookGenreOfBook_GenresOfBooks_GenreOfBookId] FOREIGN KEY ([GenreOfBookId]) REFERENCES [dbo].[GenresOfBooks] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BookGenreOfBook_GenreOfBookId]
    ON [dbo].[BookGenreOfBook]([GenreOfBookId] ASC);

