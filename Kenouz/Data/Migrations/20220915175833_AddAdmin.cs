using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kenouz.Data.Migrations
{
    public partial class AddAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'335ebf39-c8b5-44e5-abf6-b376cce5284b', N'0A209d429admin', N'0A209D429ADMIN', N'0A209d429admin', N'0A209D429ADMIN', 0, N'AQAAAAEAACcQAAAAEOpPre361Xzxi0E5iJ6DhzgFaalWcOa+G98EmYaoZxf5QalrKC/vHnXMdzaoAqJpRQ==', N'43GPQMXM43FJDNXTZ7HTGMJTJFMNY2M6', N'62df48d9-69d2-40a5-8a9a-dcdff4b34fd5', NULL, 0, 0, NULL, 1, 0)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetUsers] WHERE Id='335ebf39-c8b5-44e5-abf6-b376cce5284b'");
        }
    }
}
