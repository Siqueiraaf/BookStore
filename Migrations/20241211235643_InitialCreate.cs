using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bookapi");

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "bookapi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Language = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalPages = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "bookapi",
                table: "Books",
                columns: new[] { "Id", "Author", "Category", "Description", "Language", "Title", "TotalPages" },
                values: new object[,]
                {
                    { new Guid("3e82e389-8e71-4c36-a0bf-5a7cf5230be6"), "Paulo Coelho", "Fiction", "O alquimista um clássico contemporâneo sobre o poder transformador dos sonhos.", "Portuguese", "O Alquimista", 208 },
                    { new Guid("73679f4d-b7a0-42ab-923e-847e8317a011"), "Paulo Coelho", "Fiction", "O alquimista um clássico contemporâneo sobre o poder transformador dos sonhos.", "Portuguese", "O Alquimista", 208 },
                    { new Guid("80c763da-fd0f-4195-9ebc-3128023dd472"), "Harper Lee", "Fiction", "A novel about the serious issues of rape and racial inequality.", "English", "To Kill a Mockingbird", 281 },
                    { new Guid("8ad8a084-6ae5-4491-b69f-8f28a8222eb7"), "George Orwell", "Fiction", "A dystopian social science fiction novel and cautionary tale about the dangers of totalitarianism. ", "English", "1984", 328 },
                    { new Guid("b09b329d-6611-43b0-8876-b39fade33cef"), "Harper Lee", "Fiction", "A novel about the serious issues of rape and racial inequality.", "English", "To Kill a Mockingbird", 281 },
                    { new Guid("b3b714b7-159c-4d60-b12a-38fb1601cf54"), "George Orwell", "Fiction", "A dystopian social science fiction novel and cautionary tale about the dangers of totalitarianism. ", "English", "1984", 328 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books",
                schema: "bookapi");
        }
    }
}
