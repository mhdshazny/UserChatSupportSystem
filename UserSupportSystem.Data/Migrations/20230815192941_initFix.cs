using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserSupportSystem.Data.Migrations
{
    public partial class initFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveCount",
                table: "Role");

            migrationBuilder.AddColumn<int>(
                name: "ActiveCount",
                table: "Agent",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveCount",
                table: "Agent");

            migrationBuilder.AddColumn<int>(
                name: "ActiveCount",
                table: "Role",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
