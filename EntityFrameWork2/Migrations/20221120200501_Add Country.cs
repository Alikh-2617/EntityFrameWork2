using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWork2.Migrations
{
    public partial class AddCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: "2d3b8d8d-0a91-49e3-9dc7-b27bb73b8a87");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: "358c9721-60e9-4094-9a6a-793cace7f8a4");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: "fae4f872-b5bc-46d6-9e8f-7364bab6babc");

            migrationBuilder.AddColumn<string>(
                name: "CountryVMName",
                table: "City",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Name);
                });

            migrationBuilder.InsertData(
                table: "Country",
                column: "Name",
                values: new object[]
                {
                    "Norway",
                    "Swedan"
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "EfterName", "Name", "PhoneNumber", "age" },
                values: new object[,]
                {
                    { "129bc746-4c3d-40ab-846b-0852b9d5bd96", "khawari33", "Ali33", "1245", 32 },
                    { "5539ef22-201e-4d4c-8101-04483a45111e", "khawari22", "Ali22", "1245", 32 },
                    { "f7d177a2-7d74-44cc-b18a-a999d7c8ae79", "khawari", "Ali", "1245", 32 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryVMName",
                table: "City",
                column: "CountryVMName");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CountryVMName",
                table: "City",
                column: "CountryVMName",
                principalTable: "Country",
                principalColumn: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_CountryVMName",
                table: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_City_CountryVMName",
                table: "City");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: "129bc746-4c3d-40ab-846b-0852b9d5bd96");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: "5539ef22-201e-4d4c-8101-04483a45111e");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: "f7d177a2-7d74-44cc-b18a-a999d7c8ae79");

            migrationBuilder.DropColumn(
                name: "CountryVMName",
                table: "City");

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "EfterName", "Name", "PhoneNumber", "age" },
                values: new object[] { "2d3b8d8d-0a91-49e3-9dc7-b27bb73b8a87", "khawari", "Ali", "1245", 32 });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "EfterName", "Name", "PhoneNumber", "age" },
                values: new object[] { "358c9721-60e9-4094-9a6a-793cace7f8a4", "khawari33", "Ali33", "1245", 32 });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "EfterName", "Name", "PhoneNumber", "age" },
                values: new object[] { "fae4f872-b5bc-46d6-9e8f-7364bab6babc", "khawari22", "Ali22", "1245", 32 });
        }
    }
}
