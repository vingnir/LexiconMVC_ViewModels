using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LexiconMVC_ViewModels.Migrations
{
    public partial class DataseedTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "City", "Created", "Edited", "Name", "PhoneNumber" },
                values: new object[] { 666, "Dog Town", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doggy Dog", "12345-7899" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "City", "Created", "Edited", "Name", "PhoneNumber" },
                values: new object[] { 999, "Rabbit Town", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kalle Kanin", "12345-7585" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "City", "Created", "Edited", "Name", "PhoneNumber" },
                values: new object[] { 123, "Rabbit Town", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hasse Hare", "12345-8522" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 666);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 999);
        }
    }
}
