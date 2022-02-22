using Microsoft.EntityFrameworkCore.Migrations;

namespace LexiconMVC_ViewModels.Migrations
{
    public partial class AddedcityID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_City_CityId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_CityId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "CurrentCityId",
                table: "People",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 123,
                column: "CurrentCityId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 666,
                column: "CurrentCityId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 999,
                column: "CurrentCityId",
                value: 8);

            migrationBuilder.CreateIndex(
                name: "IX_People_CurrentCityId",
                table: "People",
                column: "CurrentCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_City_CurrentCityId",
                table: "People",
                column: "CurrentCityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_City_CurrentCityId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_CurrentCityId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CurrentCityId",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "People",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_CityId",
                table: "People",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_City_CityId",
                table: "People",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
