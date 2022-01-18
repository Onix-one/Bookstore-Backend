CREATE TABLE [dbo].[CustomerGenreOfBook] (
    [FansOfGenresId]  INT NOT NULL,
    [FavoriteTypesId] INT NOT NULL,
    CONSTRAINT [PK_CustomerGenreOfBook] PRIMARY KEY CLUSTERED ([FansOfGenresId] ASC, [FavoriteTypesId] ASC),
    CONSTRAINT [FK_CustomerGenreOfBook_Customers_FansOfGenresId] FOREIGN KEY ([FansOfGenresId]) REFERENCES [dbo].[Customers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CustomerGenreOfBook_GenresOfBooks_FavoriteTypesId] FOREIGN KEY ([FavoriteTypesId]) REFERENCES [dbo].[GenresOfBooks] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CustomerGenreOfBook_FavoriteTypesId]
    ON [dbo].[CustomerGenreOfBook]([FavoriteTypesId] ASC);

