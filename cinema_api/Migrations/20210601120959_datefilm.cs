using Microsoft.EntityFrameworkCore.Migrations;

namespace cinema_api.Migrations
{
    public partial class datefilm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateFilm",
                table: "Film",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFilm",
                table: "Film");
        }
    }
}
