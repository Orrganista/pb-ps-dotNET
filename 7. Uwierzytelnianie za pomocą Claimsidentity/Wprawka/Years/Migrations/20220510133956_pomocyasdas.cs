using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Years.Migrations
{
    public partial class pomocyasdas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "huj",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "huj",
                table: "User");
        }
    }
}
