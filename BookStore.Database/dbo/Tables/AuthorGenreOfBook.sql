CREATE TABLE [dbo].[AuthorGenreOfBook] (
    [AuthorsId]       INT NOT NULL,
    [GenresOfBooksId] INT NOT NULL,
    CONSTRAINT [PK_AuthorGenreOfBook] PRIMARY KEY CLUSTERED ([AuthorsId] ASC, [GenresOfBooksId] ASC),
    CONSTRAINT [FK_AuthorGenreOfBook_Authors_AuthorsId] FOREIGN KEY ([AuthorsId]) REFERENCES [dbo].[Authors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AuthorGenreOfBook_GenresOfBooks_GenresOfBooksId] FOREIGN KEY ([GenresOfBooksId]) REFERENCES [dbo].[GenresOfBooks] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AuthorGenreOfBook_GenresOfBooksId]
    ON [dbo].[AuthorGenreOfBook]([GenresOfBooksId] ASC);

