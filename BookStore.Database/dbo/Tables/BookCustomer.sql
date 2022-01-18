CREATE TABLE [dbo].[BookCustomer] (
    [BroughtBooksId] INT NOT NULL,
    [BuyersId]       INT NOT NULL,
    CONSTRAINT [PK_BookCustomer] PRIMARY KEY CLUSTERED ([BroughtBooksId] ASC, [BuyersId] ASC),
    CONSTRAINT [FK_BookCustomer_Books_BroughtBooksId] FOREIGN KEY ([BroughtBooksId]) REFERENCES [dbo].[Books] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookCustomer_Customers_BuyersId] FOREIGN KEY ([BuyersId]) REFERENCES [dbo].[Customers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BookCustomer_BuyersId]
    ON [dbo].[BookCustomer]([BuyersId] ASC);

