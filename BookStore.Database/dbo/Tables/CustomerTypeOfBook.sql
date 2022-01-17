CREATE TABLE [dbo].[CustomerTypeOfBook] (
    [FansOfTypesId]   INT NOT NULL,
    [FavoriteTypesId] INT NOT NULL,
    CONSTRAINT [PK_CustomerTypeOfBook] PRIMARY KEY CLUSTERED ([FansOfTypesId] ASC, [FavoriteTypesId] ASC),
    CONSTRAINT [FK_CustomerTypeOfBook_Customers_FansOfTypesId] FOREIGN KEY ([FansOfTypesId]) REFERENCES [dbo].[Customers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CustomerTypeOfBook_TypeOfBooks_FavoriteTypesId] FOREIGN KEY ([FavoriteTypesId]) REFERENCES [dbo].[TypeOfBooks] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CustomerTypeOfBook_FavoriteTypesId]
    ON [dbo].[CustomerTypeOfBook]([FavoriteTypesId] ASC);

