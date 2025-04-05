using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kenouz.Migrations
{
    public partial class CreateDeactivatedUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeactivatedUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeactivatedUsers", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeactivatedUsers");
        }
    }
}
