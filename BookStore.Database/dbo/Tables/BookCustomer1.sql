CREATE TABLE [dbo].[BookCustomer1] (
    [BooksReadyToBuyId]      INT NOT NULL,
    [CustomersWantedToBuyId] INT NOT NULL,
    CONSTRAINT [PK_BookCustomer1] PRIMARY KEY CLUSTERED ([BooksReadyToBuyId] ASC, [CustomersWantedToBuyId] ASC),
    CONSTRAINT [FK_BookCustomer1_Books_BooksReadyToBuyId] FOREIGN KEY ([BooksReadyToBuyId]) REFERENCES [dbo].[Books] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookCustomer1_Customers_CustomersWantedToBuyId] FOREIGN KEY ([CustomersWantedToBuyId]) REFERENCES [dbo].[Customers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BookCustomer1_CustomersWantedToBuyId]
    ON [dbo].[BookCustomer1]([CustomersWantedToBuyId] ASC);

