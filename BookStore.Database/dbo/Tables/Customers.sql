CREATE TABLE [dbo].[Customers] (
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    [Bonuses] INT NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

