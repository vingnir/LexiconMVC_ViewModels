using Microsoft.EntityFrameworkCore.Migrations;

namespace LexiconMVC_ViewModels.Migrations
{
    public partial class Addedidandvm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_CountryName",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_People_City_CityName",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_CityName",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_City_CountryName",
                table: "City");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Bangalore");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Bangkok");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Berlin");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Baharain");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Bangladesh");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Spain");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "City");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "People",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Country",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Country",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "City",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "City",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "City",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "CityId");

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityId", "CityName", "CountryId" },
                values: new object[,]
                {
                    { 7, "Bangkok", null },
                    { 8, "Berlin", null },
                    { 9, "Bangalore", null }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[,]
                {
                    { 117, "Bangladesh" },
                    { 118, "Baharain" },
                    { 119, "Spain" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_CityId",
                table: "People",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CountryId",
                table: "City",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_City_CityId",
                table: "People",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_CountryId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_People_City_CityId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_CityId",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_City_CountryId",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "City");

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "People",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Country",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "City",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "City",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "CountryName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "CityName");

            migrationBuilder.CreateIndex(
                name: "IX_People_CityName",
                table: "People",
                column: "CityName");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryName",
                table: "City",
                column: "CountryName");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CountryName",
                table: "City",
                column: "CountryName",
                principalTable: "Country",
                principalColumn: "CountryName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_City_CityName",
                table: "People",
                column: "CityName",
                principalTable: "City",
                principalColumn: "CityName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
