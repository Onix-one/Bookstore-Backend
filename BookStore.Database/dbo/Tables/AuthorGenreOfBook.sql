CREATE TABLE [dbo].[AuthorGenreOfBook] (
    [AuthorsId]      INT NOT NULL,
    [GenreOfBooksId] INT NOT NULL,
    CONSTRAINT [PK_AuthorGenreOfBook] PRIMARY KEY CLUSTERED ([AuthorsId] ASC, [GenreOfBooksId] ASC),
    CONSTRAINT [FK_AuthorGenreOfBook_Authors_AuthorsId] FOREIGN KEY ([AuthorsId]) REFERENCES [dbo].[Authors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AuthorGenreOfBook_GenresOfBooks_GenreOfBooksId] FOREIGN KEY ([GenreOfBooksId]) REFERENCES [dbo].[GenresOfBooks] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AuthorGenreOfBook_GenreOfBooksId]
    ON [dbo].[AuthorGenreOfBook]([GenreOfBooksId] ASC);

