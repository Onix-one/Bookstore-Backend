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
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeCurrency = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bonuses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInformations", x => x.Id);
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
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "BookTypeOfBook",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    TypesOfBookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTypeOfBook", x => new { x.BooksId, x.TypesOfBookId });
                    table.ForeignKey(
                        name: "FK_BookTypeOfBook_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookTypeOfBook_TypeOfBooks_TypesOfBookId",
                        column: x => x.TypesOfBookId,
                        principalTable: "TypeOfBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookUserInformation",
                columns: table => new
                {
                    BroughtBooksId = table.Column<int>(type: "int", nullable: false),
                    BuyersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUserInformation", x => new { x.BroughtBooksId, x.BuyersId });
                    table.ForeignKey(
                        name: "FK_BookUserInformation_Books_BroughtBooksId",
                        column: x => x.BroughtBooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUserInformation_UserInformations_BuyersId",
                        column: x => x.BuyersId,
                        principalTable: "UserInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookUserInformation1",
                columns: table => new
                {
                    BooksReadyToBuyId = table.Column<int>(type: "int", nullable: false),
                    ReadyToPayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUserInformation1", x => new { x.BooksReadyToBuyId, x.ReadyToPayId });
                    table.ForeignKey(
                        name: "FK_BookUserInformation1_Books_BooksReadyToBuyId",
                        column: x => x.BooksReadyToBuyId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUserInformation1_UserInformations_ReadyToPayId",
                        column: x => x.ReadyToPayId,
                        principalTable: "UserInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookUserInformation2",
                columns: table => new
                {
                    FansId = table.Column<int>(type: "int", nullable: false),
                    FavotiteBooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUserInformation2", x => new { x.FansId, x.FavotiteBooksId });
                    table.ForeignKey(
                        name: "FK_BookUserInformation2_Books_FavotiteBooksId",
                        column: x => x.FavotiteBooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUserInformation2_UserInformations_FansId",
                        column: x => x.FansId,
                        principalTable: "UserInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfBookUserInformation",
                columns: table => new
                {
                    FansOfTypesId = table.Column<int>(type: "int", nullable: false),
                    FavoriteTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfBookUserInformation", x => new { x.FansOfTypesId, x.FavoriteTypesId });
                    table.ForeignKey(
                        name: "FK_TypeOfBookUserInformation_TypeOfBooks_FavoriteTypesId",
                        column: x => x.FavoriteTypesId,
                        principalTable: "TypeOfBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeOfBookUserInformation_UserInformations_FansOfTypesId",
                        column: x => x.FansOfTypesId,
                        principalTable: "UserInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksId",
                table: "AuthorBook",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_BookImages_BookId",
                table: "BookImages",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTypeOfBook_TypesOfBookId",
                table: "BookTypeOfBook",
                column: "TypesOfBookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookUserInformation_BuyersId",
                table: "BookUserInformation",
                column: "BuyersId");

            migrationBuilder.CreateIndex(
                name: "IX_BookUserInformation1_ReadyToPayId",
                table: "BookUserInformation1",
                column: "ReadyToPayId");

            migrationBuilder.CreateIndex(
                name: "IX_BookUserInformation2_FavotiteBooksId",
                table: "BookUserInformation2",
                column: "FavotiteBooksId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfBookUserInformation_FavoriteTypesId",
                table: "TypeOfBookUserInformation",
                column: "FavoriteTypesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropTable(
                name: "BookImages");

            migrationBuilder.DropTable(
                name: "BookTypeOfBook");

            migrationBuilder.DropTable(
                name: "BookUserInformation");

            migrationBuilder.DropTable(
                name: "BookUserInformation1");

            migrationBuilder.DropTable(
                name: "BookUserInformation2");

            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.DropTable(
                name: "TypeOfBookUserInformation");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "TypeOfBooks");

            migrationBuilder.DropTable(
                name: "UserInformations");
        }
    }
}
