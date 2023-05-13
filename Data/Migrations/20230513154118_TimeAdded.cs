using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LataPrzestepneIdenity.Data.Migrations
{
    public partial class TimeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "LeapYears",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "LeapYears");
        }
    }
}
