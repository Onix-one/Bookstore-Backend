USE [bookStore]
GO

SET IDENTITY_INSERT [dbo].[Books] ON
INSERT INTO [dbo].[Books] ([Id],[Name], [Rating], [Price], [Description],BookUrl) 
	VALUES (1,'First book', 4,20, 'Horror story','Books\1\1.pdf'),
		   (2,'Second book', 3,5, 'Interesting book',null),
		    (3,'Third book', 3,25, 'Sad story',null),
			(4,'Fourth book', 5,13, 'Nothing interesting',null),
			(5,'Fifth book', 5,1, 'Cool',null),
			(6,'Sixth book', 4,21, 'Boring',null),
			(7, 'Seventh book', 3,11, 'The best',null)
SET IDENTITY_INSERT [dbo].[Books] OFF
GO

SET IDENTITY_INSERT [dbo].[GenresOfBooks] ON
INSERT INTO [dbo].[GenresOfBooks] ( [Id], [Name], [Description])
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
		(3,'Nikolai','Nikolaevich','2015-12-17','have not born yet','France'),
		(4,'Kolia','Pushkin','2015-12-17','never died','Russia'),
		(5,'Petia','Puslhkin','2015-12-17','never died','Russia')
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO


INSERT INTO [dbo].[BookGenreOfBook] ([BooksId], [GenreOfBooksId])
		VALUES (1,2),
		(2,1),
		(3,3),
		(4,4),
		(3,1),
		(5,2)
GO

INSERT INTO [dbo].[AuthorBook] ([AuthorsId], [BooksId])
		VALUES (1,1),
		(2,2),
		(3,3),
		(3,4),
		(2,5)
GO

SET IDENTITY_INSERT [dbo].[BookImages] ON
INSERT INTO [dbo].[BookImages] ([Id], [ImageUrl], [BookId]) 
		VALUES (1,null,1),
		(2,null,2),
		(3,null,3),
		(4,null,4),
		(5,null,5),
		(6,null,6),
		(7,null,7)
SET IDENTITY_INSERT [dbo].[BookImages] OFF
GO
