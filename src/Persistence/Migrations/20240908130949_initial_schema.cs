using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial_schema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MpaaRating = table.Column<int>(type: "INTEGER", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: false),
                    DirectorId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Lana Wachowski" },
                    { 2L, "Lilly Wachowski" },
                    { 3L, "Christopher Nolan" },
                    { 4L, "Roger Allers" },
                    { 5L, "Rob Minkoff" },
                    { 6L, "Quentin Tarantino" },
                    { 7L, "Robert Zemeckis" },
                    { 8L, "John Lasseter" },
                    { 9L, "Christopher Nolan" },
                    { 10L, "David Fincher" },
                    { 11L, "Francis Ford Coppola" },
                    { 12L, "Frank Darabont" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DirectorId", "Genre", "MpaaRating", "Name", "Rating", "ReleaseDate" },
                values: new object[,]
                {
                    { 1L, 1L, "Sci-Fi", 3, "The Matrix", 8.6999999999999993, new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, 2L, "Sci-Fi", 2, "Inception", 8.8000000000000007, new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, 3L, "Animation", 0, "The Lion King", 8.5, new DateTime(1994, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, 7L, "Crime", 3, "Pulp Fiction", 8.9000000000000004, new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, 8L, "Drama", 2, "Forrest Gump", 8.8000000000000007, new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, 9L, "Animation", 0, "Toy Story", 8.3000000000000007, new DateTime(1995, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, 10L, "Action", 2, "The Dark Knight", 9.0, new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, 1L, "Drama", 3, "Fight Club", 8.8000000000000007, new DateTime(1999, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, 2L, "Crime", 3, "The Godfather", 9.1999999999999993, new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, 3L, "Drama", 3, "The Shawshank Redemption", 9.3000000000000007, new DateTime(1994, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
