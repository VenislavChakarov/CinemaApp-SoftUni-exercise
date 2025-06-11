using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier for the movie"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Title of the movie"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Description of the movie"),
                    Director = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Director of the movie"),
                    Genre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Genre of the movie"),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Release date of the movie"),
                    Duration = table.Column<int>(type: "int", nullable: false, comment: "Duration of the movie in minutes"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "URL of the movie's poster image"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                },
                comment: "Movie in the system");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
