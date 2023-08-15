using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserSupportSystem.Data.Migrations
{
    public partial class TeamsTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupportTeamID",
                table: "Agent",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SupportTeams",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportTeams", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agent_SupportTeamID",
                table: "Agent",
                column: "SupportTeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_SupportTeams_SupportTeamID",
                table: "Agent",
                column: "SupportTeamID",
                principalTable: "SupportTeams",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agent_SupportTeams_SupportTeamID",
                table: "Agent");

            migrationBuilder.DropTable(
                name: "SupportTeams");

            migrationBuilder.DropIndex(
                name: "IX_Agent_SupportTeamID",
                table: "Agent");

            migrationBuilder.DropColumn(
                name: "SupportTeamID",
                table: "Agent");
        }
    }
}
