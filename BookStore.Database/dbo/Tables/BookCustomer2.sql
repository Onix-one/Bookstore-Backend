CREATE TABLE [dbo].[BookCustomer2] (
    [FansId]          INT NOT NULL,
    [FavoriteBooksId] INT NOT NULL,
    CONSTRAINT [PK_BookCustomer2] PRIMARY KEY CLUSTERED ([FansId] ASC, [FavoriteBooksId] ASC),
    CONSTRAINT [FK_BookCustomer2_Books_FavoriteBooksId] FOREIGN KEY ([FavoriteBooksId]) REFERENCES [dbo].[Books] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookCustomer2_Customers_FansId] FOREIGN KEY ([FansId]) REFERENCES [dbo].[Customers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BookCustomer2_FavoriteBooksId]
    ON [dbo].[BookCustomer2]([FavoriteBooksId] ASC);

