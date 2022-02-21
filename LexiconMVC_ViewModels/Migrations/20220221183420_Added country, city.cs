using Microsoft.EntityFrameworkCore.Migrations;

namespace LexiconMVC_ViewModels.Migrations
{
    public partial class Addedcountrycity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "People",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryName);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityName = table.Column<string>(nullable: false),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityName);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryName",
                        column: x => x.CountryName,
                        principalTable: "Country",
                        principalColumn: "CountryName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityName", "CountryName" },
                values: new object[,]
                {
                    { "Bangkok", null },
                    { "Berlin", null },
                    { "Bangalore", null }
                });

            migrationBuilder.InsertData(
                table: "Country",
                column: "CountryName",
                values: new object[]
                {
                    "Bangladesh",
                    "Baharain",
                    "Spain"
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_CityName",
                table: "People",
                column: "CityName");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryName",
                table: "City",
                column: "CountryName");

            migrationBuilder.AddForeignKey(
                name: "FK_People_City_CityName",
                table: "People",
                column: "CityName",
                principalTable: "City",
                principalColumn: "CityName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_City_CityName",
                table: "People");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_People_CityName",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 123,
                column: "City",
                value: "Rabbit Town");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 666,
                column: "City",
                value: "Dog Town");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 999,
                column: "City",
                value: "Rabbit Town");
        }
    }
}
