using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kenouz.Migrations.KenouzDb
{
    public partial class seedingClassYears : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ClassYears",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "الصف الأول الثانوي" });

            migrationBuilder.InsertData(
                table: "ClassYears",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "الصف الثاني الثانوي" });

            migrationBuilder.InsertData(
                table: "ClassYears",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "الصف الثالث الثانوي" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassYears",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClassYears",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClassYears",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
