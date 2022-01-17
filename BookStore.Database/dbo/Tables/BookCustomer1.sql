CREATE TABLE [dbo].[BookCustomer1] (
    [BooksReadyToBuyId] INT NOT NULL,
    [ReadyToPayId]      INT NOT NULL,
    CONSTRAINT [PK_BookCustomer1] PRIMARY KEY CLUSTERED ([BooksReadyToBuyId] ASC, [ReadyToPayId] ASC),
    CONSTRAINT [FK_BookCustomer1_Books_BooksReadyToBuyId] FOREIGN KEY ([BooksReadyToBuyId]) REFERENCES [dbo].[Books] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookCustomer1_Customers_ReadyToPayId] FOREIGN KEY ([ReadyToPayId]) REFERENCES [dbo].[Customers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BookCustomer1_ReadyToPayId]
    ON [dbo].[BookCustomer1]([ReadyToPayId] ASC);

