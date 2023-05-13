using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LataPrzestepneIdenity.Data.Migrations
{
    public partial class USerIdAddedToYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "LeapYears",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "LeapYears",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "LeapYears");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "LeapYears");
        }
    }
}
