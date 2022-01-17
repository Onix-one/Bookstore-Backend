CREATE TABLE [dbo].[ExchangeRates] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [TypeCurrency] INT            NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [Rate]         FLOAT (53)     NOT NULL,
    [Abbreviation] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ExchangeRates] PRIMARY KEY CLUSTERED ([Id] ASC)
);

