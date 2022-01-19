CREATE TABLE [dbo].[AuthorGenreOfBook] (
    [AuthorId]      INT NOT NULL,
    [GenreOfBookId] INT NOT NULL,
    [Id]            INT NOT NULL,
    CONSTRAINT [PK_AuthorGenreOfBook] PRIMARY KEY CLUSTERED ([GenreOfBookId] ASC, [AuthorId] ASC),
    CONSTRAINT [FK_AuthorGenreOfBook_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Authors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AuthorGenreOfBook_GenresOfBooks_GenreOfBookId] FOREIGN KEY ([GenreOfBookId]) REFERENCES [dbo].[GenresOfBooks] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AuthorGenreOfBook_AuthorId]
    ON [dbo].[AuthorGenreOfBook]([AuthorId] ASC);

