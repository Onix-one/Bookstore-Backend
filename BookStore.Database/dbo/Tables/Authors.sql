CREATE TABLE [dbo].[Authors] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (MAX) NULL,
    [SecondName]  NVARCHAR (MAX) NULL,
    [DateOfBirth] DATETIME2 (7)  NOT NULL,
    [Biografy]    NVARCHAR (MAX) NULL,
    [Nationality] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED ([Id] ASC)
);

