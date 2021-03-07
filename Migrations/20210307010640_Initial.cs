﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookTitle = table.Column<string>(nullable: false),
                    BookAuthorFirstName = table.Column<string>(nullable: false),
                    BookAuthorMiddleName = table.Column<string>(nullable: true),
                    BookAuthorLastName = table.Column<string>(nullable: false),
                    BookPublisher = table.Column<string>(nullable: false),
                    BookISBN = table.Column<string>(nullable: false),
                    BookClassification = table.Column<string>(nullable: true),
                    BookCategory = table.Column<string>(nullable: false),
                    BookPrice = table.Column<double>(nullable: false),
                    BookPages = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
