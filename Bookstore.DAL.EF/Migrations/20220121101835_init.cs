using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.DAL.EF.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Biografy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bonuses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenresOfBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenresOfBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    BooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookImages_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookCustomer",
                columns: table => new
                {
                    BroughtBooksId = table.Column<int>(type: "int", nullable: false),
                    BuyersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCustomer", x => new { x.BroughtBooksId, x.BuyersId });
                    table.ForeignKey(
                        name: "FK_BookCustomer_Books_BroughtBooksId",
                        column: x => x.BroughtBooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCustomer_Customers_BuyersId",
                        column: x => x.BuyersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCustomer1",
                columns: table => new
                {
                    BooksReadyToBuyId = table.Column<int>(type: "int", nullable: false),
                    CustomersWantedToBuyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCustomer1", x => new { x.BooksReadyToBuyId, x.CustomersWantedToBuyId });
                    table.ForeignKey(
                        name: "FK_BookCustomer1_Books_BooksReadyToBuyId",
                        column: x => x.BooksReadyToBuyId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCustomer1_Customers_CustomersWantedToBuyId",
                        column: x => x.CustomersWantedToBuyId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCustomer2",
                columns: table => new
                {
                    FansId = table.Column<int>(type: "int", nullable: false),
                    FavoriteBooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCustomer2", x => new { x.FansId, x.FavoriteBooksId });
                    table.ForeignKey(
                        name: "FK_BookCustomer2_Books_FavoriteBooksId",
                        column: x => x.FavoriteBooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCustomer2_Customers_FansId",
                        column: x => x.FansId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorGenreOfBook",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    GenreOfBooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorGenreOfBook", x => new { x.AuthorsId, x.GenreOfBooksId });
                    table.ForeignKey(
                        name: "FK_AuthorGenreOfBook_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorGenreOfBook_GenresOfBooks_GenreOfBooksId",
                        column: x => x.GenreOfBooksId,
                        principalTable: "GenresOfBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookGenreOfBook",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    GenreOfBooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenreOfBook", x => new { x.BooksId, x.GenreOfBooksId });
                    table.ForeignKey(
                        name: "FK_BookGenreOfBook_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenreOfBook_GenresOfBooks_GenreOfBooksId",
                        column: x => x.GenreOfBooksId,
                        principalTable: "GenresOfBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerGenreOfBook",
                columns: table => new
                {
                    FansOfGenresId = table.Column<int>(type: "int", nullable: false),
                    FavoriteTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGenreOfBook", x => new { x.FansOfGenresId, x.FavoriteTypesId });
                    table.ForeignKey(
                        name: "FK_CustomerGenreOfBook_Customers_FansOfGenresId",
                        column: x => x.FansOfGenresId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerGenreOfBook_GenresOfBooks_FavoriteTypesId",
                        column: x => x.FavoriteTypesId,
                        principalTable: "GenresOfBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksId",
                table: "AuthorBook",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorGenreOfBook_GenreOfBooksId",
                table: "AuthorGenreOfBook",
                column: "GenreOfBooksId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCustomer_BuyersId",
                table: "BookCustomer",
                column: "BuyersId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCustomer1_CustomersWantedToBuyId",
                table: "BookCustomer1",
                column: "CustomersWantedToBuyId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCustomer2_FavoriteBooksId",
                table: "BookCustomer2",
                column: "FavoriteBooksId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenreOfBook_GenreOfBooksId",
                table: "BookGenreOfBook",
                column: "GenreOfBooksId");

            migrationBuilder.CreateIndex(
                name: "IX_BookImages_BookId",
                table: "BookImages",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGenreOfBook_FavoriteTypesId",
                table: "CustomerGenreOfBook",
                column: "FavoriteTypesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropTable(
                name: "AuthorGenreOfBook");

            migrationBuilder.DropTable(
                name: "BookCustomer");

            migrationBuilder.DropTable(
                name: "BookCustomer1");

            migrationBuilder.DropTable(
                name: "BookCustomer2");

            migrationBuilder.DropTable(
                name: "BookGenreOfBook");

            migrationBuilder.DropTable(
                name: "BookImages");

            migrationBuilder.DropTable(
                name: "CustomerGenreOfBook");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "GenresOfBooks");
        }
    }
}
