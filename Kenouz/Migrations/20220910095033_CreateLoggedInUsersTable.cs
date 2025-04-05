using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kenouz.Migrations
{
    public partial class CreateLoggedInUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logged_In_Users",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logged_In_Users", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logged_In_Users");
        }
    }
}
