USE [BookStore]
GO

SET IDENTITY_INSERT [dbo].[Books] ON
INSERT INTO [dbo].[Books] ([Id],[Name], [Rating], [Price], [Description]) 
	VALUES (1,'First book', 4,20, 'Horror story'),
		   (2,'Second book', 3,5, 'Interesting book'),
		    (3,'Third book', 3,25, 'Sad story'),
			(4,'Fourth book', 5,13, 'Nothing interesting'),
			(5,'Fifth book', 5,1, 'Cool'),
			(6,'Sixth book', 4,21, 'Boring'),
			(7, 'Seventh book', 3,11, 'The best')
SET IDENTITY_INSERT [dbo].[Books] OFF
GO

SET IDENTITY_INSERT [dbo].[GenresOfBooks] ON
INSERT INTO [dbo].[GenresOfBooks] ( [Id], [Genre], [Description])
	VALUES (1,1,'for adult'),
			(2,2,'intresting'),
			(3,3,'lovely'),
			(4,4,'nothing')
SET IDENTITY_INSERT [dbo].[GenresOfBooks] OFF
GO

SET IDENTITY_INSERT [dbo].[Authors] ON
INSERT INTO [dbo].[Authors] ([Id],[FirstName], [SecondName], [DateOfBirth], [Biografy], [Nationality])
		VALUES (1,'Ivan','Ivanov','2015-12-17','born live died','USA'),
		(2,'Vasia','Pushkin','2015-12-17','never died','Russia'),
		(3,'Nikolai','Nikolaevich','2015-12-17','have not born yet','France')
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO


INSERT INTO [dbo].[BookGenreOfBook] ([BookId], [GenreOfBookId],[Id])
		VALUES (1,2,11),
		(2,1,2),
		(3,3,3),
		(4,4,4),
		(3,1,5),
		(5,2,6)

GO

INSERT INTO [dbo].[BookAuthor] ([AuthorId], [BookId])
		VALUES (1,1),
		(2,2),
		(3,3),
		(3,4),
		(2,5)
GO

SET IDENTITY_INSERT [dbo].[Customers] ON
INSERT INTO [dbo].[Customers] ([Id],[Bonuses])
		VALUES (1,0),
		(2,25),
		(3,0),
		(4,5),
		(5,3)
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO

INSERT INTO [dbo].[BookCustomer] ([BroughtBooksId], [BuyersId])
		VALUES (1,1),
		(2,2),
		(3,3),
		(3,4),
		(2,5)
GO

SET IDENTITY_INSERT [dbo].[BookImages] ON
INSERT INTO [dbo].[BookImages] ([Id], [Image], [BookId])
		VALUES (1,null,1),
		(2,null,2),
		(3,null,3),
		(4,null,4),
		(5,null,5),
		(6,null,6),
		(7,null,7)
SET IDENTITY_INSERT [dbo].[BookImages] OFF
GO
