using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kenouz.Data.Migrations
{
    public partial class AssignAdminRoleToAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [AspNetUserRoles](UserId,RoleId) SELECT '335ebf39-c8b5-44e5-abf6-b376cce5284b',Id FROM [AspNetRoles] WHERE [AspNetRoles].Name = 'Admin' ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetUserRoles] WHERE [AspNetUserRoles].UserId = '335ebf39-c8b5-44e5-abf6-b376cce5284b'");
        }
    }
}
